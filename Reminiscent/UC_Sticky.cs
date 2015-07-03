using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Reflection;
using System.Globalization;

namespace Reminiscent
{
    public partial class UC_Sticky : UserControl
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        int iFlag = 0;
        int iID = 0;
        
        public UC_Sticky()
        {
            InitializeComponent();
        }

        #region Page Load
        private void UC_Sticky_Load(object sender, EventArgs e)
        {
            dtNote.Enabled = false;
            txtNote.ReadOnly = true;
            txtWidth.ReadOnly = true;
            txtHeight.ReadOnly = true;
            txtLX.ReadOnly = true;
            txtLY.ReadOnly = true;
            cboColor.Enabled = false;
            chkOnTop.Enabled = false;
            chkShow.Enabled = false;

            chkOnTop.Checked = true;
            chkShow.Checked = true;

            LoadListView();

            cboColor.Items.Add("Blue");
            cboColor.Items.Add("Pink");
            cboColor.Items.Add("Green");
            cboColor.Items.Add("Purple");
            cboColor.Items.Add("White");
            cboColor.Items.Add("Yellow");
            cboColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboColor.SelectedIndex = 0;

            #region Language
            XmlDocument xmlDocLng = new XmlDocument();
            if (frmMain.strLanguage == "English")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-English.xml");
            }
            else if (frmMain.strLanguage == "Vietnamese")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-Vietnamese.xml");
            }

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (node.SelectSingleNode("Name").InnerText == this.Name)
                {
                    lblStickyTitle.Text = node.SelectSingleNode("Text").InnerText;

                    lblDate.Text = node.SelectSingleNode("lbl1").InnerText;
                    lblSize.Text = node.SelectSingleNode("lbl2").InnerText;
                    lblLocation.Text = node.SelectSingleNode("lbl3").InnerText;
                    lblColor.Text = node.SelectSingleNode("lbl4").InnerText;
                    lblOnTop.Text = node.SelectSingleNode("lbl5").InnerText;
                    lblShow.Text = node.SelectSingleNode("lbl6").InnerText;

                    btnNew.Text = node.SelectSingleNode("btn1").InnerText;
                    btnSaveAs.Text = node.SelectSingleNode("btn2").InnerText;
                    btnDel.Text = node.SelectSingleNode("btn3").InnerText;
                    btnSave.Text = node.SelectSingleNode("btn4").InnerText;

                    //colID.Text = node.SelectSingleNode("col1").InnerText;
                    //colDate.Text = node.SelectSingleNode("col2").InnerText;
                    //colNote.Text = node.SelectSingleNode("col3").InnerText;
                    //colWidth.Text = node.SelectSingleNode("col4").InnerText;
                    //colHeight.Text = node.SelectSingleNode("col5").InnerText;
                    //colLocationX.Text = node.SelectSingleNode("col6").InnerText;
                    //colLocationY.Text = node.SelectSingleNode("col7").InnerText;
                    //colColor.Text = node.SelectSingleNode("col8").InnerText;
                    //colOnTop.Text = node.SelectSingleNode("col9").InnerText;
                    //colShow.Text = node.SelectSingleNode("col10").InnerText;

                    dgvNote.Columns[0].HeaderText = node.SelectSingleNode("col1").InnerText;
                    dgvNote.Columns[1].HeaderText = node.SelectSingleNode("col2").InnerText;
                    dgvNote.Columns[2].HeaderText = node.SelectSingleNode("col3").InnerText;
                    dgvNote.Columns[3].HeaderText = node.SelectSingleNode("col4").InnerText;
                    dgvNote.Columns[4].HeaderText = node.SelectSingleNode("col5").InnerText;
                    dgvNote.Columns[5].HeaderText = node.SelectSingleNode("col6").InnerText;
                    dgvNote.Columns[6].HeaderText = node.SelectSingleNode("col7").InnerText;
                    dgvNote.Columns[7].HeaderText = node.SelectSingleNode("col8").InnerText;
                    dgvNote.Columns[8].HeaderText = node.SelectSingleNode("col9").InnerText;
                    dgvNote.Columns[9].HeaderText = node.SelectSingleNode("col10").InnerText;
                    break;
                }
            }
            #endregion

            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            dgvNote.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy";
        }
        #endregion

        #region Load List View
        internal void LoadListView()
        {
            //lstNote.Items.Clear();
            dgvNote.Rows.Clear();

            if (File.Exists(Application.StartupPath + "/Data/StickyNote.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/StickyNote.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Notes = root.GetElementsByTagName("Notes");

                for (int i = 0; i < Notes.Count; i++)
                {
                    try
                    {
                        frmMain.iMaxPage = Notes.Count - 1;
                        //ListViewItem lvi = new ListViewItem();
                        //lvi.Text = Notes[i].ChildNodes[0].InnerText;
                        //lvi.SubItems.Add(Notes[i].ChildNodes[1].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[2].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[3].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[4].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[5].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[6].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[7].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[8].InnerText);
                        //lvi.SubItems.Add(Notes[i].ChildNodes[9].InnerText);
                        //lstNote.Items.Add(lvi);

                        DataGridViewRow row = (DataGridViewRow)dgvNote.Rows[0].Clone();
                        row.Cells[0].Value = Convert.ToInt32(Notes[i].ChildNodes[0].InnerText);//ID
                        row.Cells[1].Value = DateTime.ParseExact(Notes[i].ChildNodes[1].InnerText, "d/M/yyyy", CultureInfo.InvariantCulture);//Date
                        row.Cells[2].Value = Notes[i].ChildNodes[2].InnerText;//Note
                        row.Cells[3].Value = Convert.ToInt32(Notes[i].ChildNodes[3].InnerText);//Width
                        row.Cells[4].Value = Convert.ToInt32(Notes[i].ChildNodes[4].InnerText);//Height
                        row.Cells[5].Value = Convert.ToInt32(Notes[i].ChildNodes[5].InnerText);//Lx
                        row.Cells[6].Value = Convert.ToInt32(Notes[i].ChildNodes[6].InnerText);//Ly
                        row.Cells[7].Value = Notes[i].ChildNodes[7].InnerText;//Color
                        row.Cells[8].Value = Notes[i].ChildNodes[8].InnerText;//Ontop
                        row.Cells[9].Value = Notes[i].ChildNodes[9].InnerText;//Show
                        dgvNote.Rows.Add(row);
                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "/Data/StickyNote.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/StickyNote.xml", Application.StartupPath + "/Data/StickyNote.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/StickyNote.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/StickyNote.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("Sticky");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Sticky database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }
        #endregion

        internal void PgUp()
        {
            if (dgvNote.Rows.Count > 0)
            {
                if (frmMain.iPage < 44)
                {
                    dgvNote.Focus();
                    dgvNote.Rows[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    dgvNote.Focus();
                    dgvNote.Rows[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void PgDn()
        {
            if (dgvNote.Rows.Count > 0)
            {
                if (frmMain.iPage > dgvNote.Rows.Count - 2)
                {
                    dgvNote.Focus();
                    dgvNote.Rows[dgvNote.Rows.Count - 2].Selected = true;
                    frmMain.iPage = dgvNote.Rows.Count - 2;
                }
                else
                {
                    dgvNote.Focus();
                    dgvNote.Rows[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void Search(string strSearch, string strBy)
        {
            if (dgvNote.Rows.Count > 0)
            {
                if (frmMain.iSearch == dgvNote.Rows.Count - 1)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < dgvNote.Rows.Count - 1; i++)
                {
                    if (strBy == "Date")
                    {
                        if (dgvNote.Rows[i].Cells[1].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvNote.Focus();
                            dgvNote.Rows[i].Selected = true;
                            if (i == dgvNote.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvNote.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Note")
                    {
                        if (dgvNote.Rows[i].Cells[2].Value.ToString().ToLower().Contains(strSearch.ToLower()))
                        {
                            dgvNote.Focus();
                            dgvNote.Rows[i].Selected = true;
                            if (i == dgvNote.Rows.Count - 2)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == dgvNote.Rows.Count - 2)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }

        #region Refresh
        private void btnNew_Click(object sender, EventArgs e)
        {
            iFlag = 1;
            dtNote.Text = DateTime.Now.ToShortDateString();
            txtNote.Text = "";
            txtHeight.Text = "120";
            txtWidth.Text = "180";
            txtLX.Text = "0";
            txtLY.Text = "0";
            cboColor.SelectedIndex = 5;
            chkOnTop.Checked = true;
            chkShow.Checked = true;

            txtNote.ReadOnly = false;
            txtWidth.ReadOnly = false;
            txtHeight.ReadOnly = false;
            txtLX.ReadOnly = false;
            txtLY.ReadOnly = false;
            cboColor.Enabled = true;
            chkOnTop.Enabled = true;
            chkShow.Enabled = true;
        }
        #endregion

        #region Save As
        private void btnEdit_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Trim();
            #region New
            //Add new sticky note
            if (iFlag == 2)
            {
                if (txtNote.Text != "")
                {
                    if (txtHeight.Text == "")
                        txtHeight.Text = "120";
                    if (txtWidth.Text == "")
                        txtWidth.Text = "180";
                    if (txtLX.Text == "")
                        txtLX.Text = "0";
                    if (txtLY.Text == "")
                        txtLY.Text = "0";

                    XmlDocument xd = new XmlDocument();
                    xd.Load(Application.StartupPath + "/Data/StickyNote.xml");

                    XmlNode nodeNotes = xd.CreateNode(XmlNodeType.Element, "Notes", null);

                    XmlNode nodeID = xd.CreateElement("ID");
                    if (dgvNote.Rows.Count > 0)
                    {
                        int iMax = 0;
                        for (int i = 0; i < dgvNote.Rows.Count - 1; i++)
                        {
                            if (iMax < Convert.ToInt32(dgvNote.Rows[i].Cells[0].Value.ToString()))
                                iMax = Convert.ToInt32(dgvNote.Rows[i].Cells[0].Value.ToString());
                        }
                        nodeID.InnerText = (iMax + 1).ToString();
                    }
                    else
                    {
                        nodeID.InnerText = "0";
                    }
                    XmlNode nodeDate = xd.CreateElement("Date");
                    nodeDate.InnerText = dtNote.Text;

                    XmlNode nodeNote = xd.CreateElement("Text");
                    nodeNote.InnerText = txtNote.Text;

                    XmlNode nodeWidth = xd.CreateElement("Width");
                    nodeWidth.InnerText = txtWidth.Text;

                    XmlNode nodeHeight = xd.CreateElement("Height");
                    nodeHeight.InnerText = txtHeight.Text;

                    XmlNode nodeLocationX = xd.CreateElement("LocationX");
                    nodeLocationX.InnerText = txtLX.Text;

                    XmlNode nodeLocationY = xd.CreateElement("LocationY");
                    nodeLocationY.InnerText = txtLY.Text;

                    XmlNode nodeColor = xd.CreateElement("Color");
                    nodeColor.InnerText = cboColor.Text;

                    XmlNode nodeOnTop = xd.CreateElement("OnTop");
                    nodeOnTop.InnerText = chkOnTop.Text;

                    XmlNode nodeShow = xd.CreateElement("Show");
                    nodeShow.InnerText = chkShow.Text;

                    nodeNotes.AppendChild(nodeID);
                    nodeNotes.AppendChild(nodeDate);
                    nodeNotes.AppendChild(nodeNote);
                    nodeNotes.AppendChild(nodeWidth);
                    nodeNotes.AppendChild(nodeHeight);
                    nodeNotes.AppendChild(nodeLocationX);
                    nodeNotes.AppendChild(nodeLocationY);
                    nodeNotes.AppendChild(nodeColor);
                    nodeNotes.AppendChild(nodeOnTop);
                    nodeNotes.AppendChild(nodeShow);

                    xd.DocumentElement.AppendChild(nodeNotes);
                    xd.Save(Application.StartupPath + "/Data/StickyNote.xml");
                    //frmMain.Upload();
                }
                else
                {
                    MessageBox.Show("Note text can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion

            //Sort By Element
            XElement root = XElement.Load(Application.StartupPath + "/Data/StickyNote.xml");
            var orderedtabs = root.Elements("Notes")
                                  .OrderBy(xtab => DateTime.ParseExact(xtab.Element("Date").Value.ToString(), "d/M/yyyy", CultureInfo.InvariantCulture))
                                  .ToArray();
            root.RemoveAll();
            foreach (XElement tab in orderedtabs)
                root.Add(tab);
            root.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            txtNote.ReadOnly = true;
            txtWidth.ReadOnly = true;
            txtHeight.ReadOnly = true;
            txtLX.ReadOnly = true;
            txtLY.ReadOnly = true;
            cboColor.Enabled = false;
            chkOnTop.Enabled = false;
            chkShow.Enabled = false;

            LoadListView();

            for (int fcount = 0; fcount <= Application.OpenForms.Count + 1; fcount++)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Text == "Sticky Note")
                    {
                        frm.Close();
                        break;
                    }
                }
            }
            classShowSticky.Load();

            iFlag = 0;
        }
        #endregion

        #region Del
        private void btnDel_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Trim();
            if (iFlag == 2)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    if (File.Exists(Application.StartupPath + "/Data/StickyNote.xml"))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(Application.StartupPath + "/Data/StickyNote.xml");

                        foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
                        {
                            if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                            {
                                node.ParentNode.RemoveChild(node);
                            }

                        }
                        doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
                        frmMain.Upload();

                        txtNote.Text = "";
                        LoadListView();

                        for (int fcount = 0; fcount <= Application.OpenForms.Count + 1; fcount++)
                        {
                            foreach (Form frm in Application.OpenForms)
                            {
                                if (frm.Text == "Sticky Note")
                                {
                                    frm.Close();
                                    break;
                                }
                            }
                        }
                        classShowSticky.Load();
                    }
                }
            }
        }
        #endregion

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            txtNote.Text = txtNote.Text.Trim();
            if (txtLX.Text == "")
            {
                txtLX.Text = "0";
            }
            if (txtLY.Text == "")
            {
                txtLY.Text = "0";
            }
            if (txtWidth.Text == "")
            {
                txtWidth.Text = "0";
            }
            if (txtHeight.Text == "")
            {
                txtHeight.Text = "0";
            }

            if (Convert.ToInt32(txtWidth.Text) < 180)
            {
                txtWidth.Text = "180";
            }

            if (Convert.ToInt32(txtHeight.Text) < 120)
            {
                txtHeight.Text = "120";
            }

            #region File exists
            if (!File.Exists(Application.StartupPath + "/Data/StickyNote.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/StickyNote.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented; //Xuống dòng
                writer.WriteStartDocument();
                writer.WriteStartElement("Sticky");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
            #endregion

            if (txtNote.Text != "")
                {
                    if (txtHeight.Text == "")
                        txtHeight.Text = "120";
                    if (txtWidth.Text == "")
                        txtWidth.Text = "180";
                    if (txtLX.Text == "")
                        txtLX.Text = "0";
                    if (txtLY.Text == "")
                        txtLY.Text = "0";

            #region New
            //Add new sticky note
            if (iFlag == 1)
            {
                XmlDocument xd = new XmlDocument();
                xd.Load(Application.StartupPath + "/Data/StickyNote.xml");

                XmlNode nodeNotes = xd.CreateNode(XmlNodeType.Element, "Notes", null);

                XmlNode nodeID = xd.CreateElement("ID");
                if (dgvNote.Rows.Count > 0)
                {
                    int iMax = 0;
                    for (int i = 0; i < dgvNote.Rows.Count - 1; i++)
                    {
                        if (iMax < Convert.ToInt32(dgvNote.Rows[i].Cells[0].Value.ToString()))
                            iMax = Convert.ToInt32(dgvNote.Rows[i].Cells[0].Value.ToString());
                    }
                    nodeID.InnerText = (iMax + 1).ToString();
                }
                else
                {
                    nodeID.InnerText = "0";
                }
                XmlNode nodeDate = xd.CreateElement("Date");
                nodeDate.InnerText = dtNote.Text;

                XmlNode nodeNote = xd.CreateElement("Text");
                nodeNote.InnerText = txtNote.Text;

                XmlNode nodeWidth = xd.CreateElement("Width");
                nodeWidth.InnerText = txtWidth.Text;

                XmlNode nodeHeight = xd.CreateElement("Height");
                nodeHeight.InnerText = txtHeight.Text;

                XmlNode nodeLocationX = xd.CreateElement("LocationX");
                nodeLocationX.InnerText = txtLX.Text;

                XmlNode nodeLocationY = xd.CreateElement("LocationY");
                nodeLocationY.InnerText = txtLY.Text;

                XmlNode nodeColor = xd.CreateElement("Color");
                nodeColor.InnerText = cboColor.Text;

                XmlNode nodeOnTop = xd.CreateElement("OnTop");
                nodeOnTop.InnerText = chkOnTop.Text;

                XmlNode nodeShow = xd.CreateElement("Show");
                nodeShow.InnerText = chkShow.Text;

                nodeNotes.AppendChild(nodeID);
                nodeNotes.AppendChild(nodeDate);
                nodeNotes.AppendChild(nodeNote);
                nodeNotes.AppendChild(nodeWidth);
                nodeNotes.AppendChild(nodeHeight);
                nodeNotes.AppendChild(nodeLocationX);
                nodeNotes.AppendChild(nodeLocationY);
                nodeNotes.AppendChild(nodeColor);
                nodeNotes.AppendChild(nodeOnTop);
                nodeNotes.AppendChild(nodeShow);

                xd.DocumentElement.AppendChild(nodeNotes);
                xd.Save(Application.StartupPath + "/Data/StickyNote.xml");
                //frmMain.Upload();
            }
            #endregion

            #region Edit
            //Edit sticky note
            if (iFlag == 2)
            {
                XmlDocument doc = new XmlDocument();
                //Load StickyNote.xml
                doc.Load(Application.StartupPath + "/Data/StickyNote.xml");

                //Search in Root/Node
                foreach (XmlNode node in doc.SelectNodes("Sticky/Notes"))
                {
                    //If Element ID = Selected ID
                    if (node.SelectSingleNode("ID").InnerText == iID.ToString())
                    {
                        node.SelectSingleNode("Date").InnerText = dtNote.Text;
                        node.SelectSingleNode("Text").InnerText = txtNote.Text;
                        node.SelectSingleNode("Width").InnerText = txtWidth.Text;
                        node.SelectSingleNode("Height").InnerText = txtHeight.Text;
                        node.SelectSingleNode("LocationX").InnerText = txtLX.Text;
                        node.SelectSingleNode("LocationY").InnerText = txtLY.Text;
                        node.SelectSingleNode("Color").InnerText = cboColor.Text;
                        node.SelectSingleNode("OnTop").InnerText = chkOnTop.Text;
                        node.SelectSingleNode("Show").InnerText = chkShow.Text;
                    }
                }

                //Save XML
                doc.Save(Application.StartupPath + "/Data/StickyNote.xml");
                //frmMain.Upload();
            }
            #endregion

                }
            else
            {
                MessageBox.Show("Note text can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Sort By Element
            XElement root = XElement.Load(Application.StartupPath + "/Data/StickyNote.xml");
            var orderedtabs = root.Elements("Notes")
                                  .OrderBy(xtab => (string)xtab.Element("Date"))
                                  .ToArray();
            root.RemoveAll();
            foreach (XElement tab in orderedtabs)
                root.Add(tab);
            root.Save(Application.StartupPath + "/Data/StickyNote.xml");
            frmMain.Upload();

            txtNote.ReadOnly = true;
            txtWidth.ReadOnly = true;
            txtHeight.ReadOnly = true;
            txtLX.ReadOnly = true;
            txtLY.ReadOnly = true;
            cboColor.Enabled = false;
            chkOnTop.Enabled = false;
            chkShow.Enabled = false;
            LoadListView();

            for (int fcount = 0; fcount <= Application.OpenForms.Count + 1; fcount++)
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Text == "Sticky Note")
                    {
                        frm.Close();
                        break;
                    }
                }
            }
            classShowSticky.Load();

            iFlag = 0;
        }
        #endregion

        #region List View Selected Index Change
        private void lstNote_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lstNote.SelectedItems.Count > 0)
            //{
            //    txtNote.ReadOnly = true;
            //    txtWidth.ReadOnly = true;
            //    txtHeight.ReadOnly = true;
            //    txtLX.ReadOnly = true;
            //    txtLY.ReadOnly = true;
            //    cboColor.Enabled = false;
            //    chkOnTop.Enabled = false;
            //    chkShow.Enabled = false;

            //    foreach (ListViewItem lvi in lstNote.SelectedItems)
            //    {
            //        iFlag = 2;
            //        dtNote.Text = DateTime.Now.ToShortDateString();

            //        btnSave.Enabled = true;

            //        txtNote.ReadOnly = false;
            //        txtWidth.ReadOnly = false;
            //        txtHeight.ReadOnly = false;
            //        txtLX.ReadOnly = false;
            //        txtLY.ReadOnly = false;
            //        cboColor.Enabled = true;
            //        chkOnTop.Enabled = true;
            //        chkShow.Enabled = true;


            //        frmMain.iPage = lvi.Index;
            //        iID = Convert.ToInt32(lvi.Text);
            //        dtNote.Text = DateTime.ParseExact(lvi.SubItems[1].Text, "d/M/yyyy", CultureInfo.InvariantCulture).ToString();
            //        txtNote.Text = lvi.SubItems[2].Text;
            //        txtWidth.Text = lvi.SubItems[3].Text;
            //        txtHeight.Text = lvi.SubItems[4].Text;
            //        txtLX.Text = lvi.SubItems[5].Text;
            //        txtLY.Text = lvi.SubItems[6].Text;
            //        cboColor.Text = lvi.SubItems[7].Text;

            //        if (lvi.SubItems[8].Text == "Yes")
            //            chkOnTop.Checked = true;
            //        else
            //            chkOnTop.Checked = false;

            //        if (lvi.SubItems[9].Text == "Yes")
            //            chkShow.Checked = true;
            //        else
            //            chkShow.Checked = false;
            //    }
            //}
            //else
            //{

            //}
        }
        #endregion

        #region Mouse Hover
        //Move
        private void btnNew_MouseMove(object sender, MouseEventArgs e)
        {
            btnNew.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnEdit_MouseMove(object sender, MouseEventArgs e)
        {
            btnSaveAs.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDel_MouseMove(object sender, MouseEventArgs e)
        {
            btnDel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnSave_MouseMove(object sender, MouseEventArgs e)
        {
            btnSave.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void chkOnTop_MouseMove(object sender, MouseEventArgs e)
        {
            chkOnTop.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void chkShow_MouseMove(object sender, MouseEventArgs e)
        {
            chkShow.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        //Leave
        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnSaveAs.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnDel_MouseLeave(object sender, EventArgs e)
        {
            btnDel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void chkOnTop_MouseLeave(object sender, EventArgs e)
        {
            if (chkOnTop.Checked)
            {
                chkOnTop.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkOnTop.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }

        private void chkShow_MouseLeave(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                chkShow.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkShow.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }
        #endregion

        #region Checked change
        private void chkOnTop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOnTop.Checked)
            {
                chkOnTop.Text = "Yes";
                chkOnTop.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkOnTop.Text = "No";
                chkOnTop.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }

        private void chkShow_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShow.Checked)
            {
                chkShow.Text = "Yes";
                chkShow.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkShow.Text = "No";
                chkShow.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }
        #endregion

        #region KeyPress
        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false && e.KeyChar != ('-'))
                e.Handled = true;
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false && e.KeyChar != ('-'))
                e.Handled = true;
        }

        private void txtLX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false && e.KeyChar != ('-'))
                e.Handled = true;
        }

        private void txtLY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) == false && char.IsControl(e.KeyChar) == false && e.KeyChar != ('-'))
                e.Handled = true;
        }
        #endregion

        private void dgvNote_Paint(object sender, PaintEventArgs e)
        {
            int rowHeight = this.dgvNote.RowTemplate.Height;

            int h = this.dgvNote.ColumnHeadersHeight + rowHeight * (this.dgvNote.NewRowIndex + 1);
            Bitmap rowImg = new Bitmap(this.dgvNote.Width, rowHeight);
            Graphics g = Graphics.FromImage(rowImg);
            Rectangle rFrame = new Rectangle(1, 0, this.dgvNote.Width, rowHeight);
            g.DrawRectangle(new Pen(Color.FromArgb(240, 240, 240)), rFrame);
            Rectangle rFill = new Rectangle(1, 1, this.dgvNote.Width - 2, rowHeight - 2);
            g.FillRectangle(Brushes.White, rFill);

            int w = -4;
            for (int j = 0; j < this.dgvNote.ColumnCount; j++)
            {
                w += this.dgvNote.Columns[j].Width;
                g.DrawLine(new Pen(Color.FromArgb(240, 240, 240)), new Point(w, 0), new Point(w, rowHeight));
            }

            int loop = (this.dgvNote.Height - h) / rowHeight;
            for (int j = 0; j < loop + 1; j++)
            {
                e.Graphics.DrawImage(rowImg, 0, h + j * rowHeight);
            }
        }

        private void dgvNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRIndex = dgvNote.CurrentCell.RowIndex;
            if (dgvNote.Rows[iRIndex].Cells[0].Value != null)
            {
                txtNote.ReadOnly = true;
                txtWidth.ReadOnly = true;
                txtHeight.ReadOnly = true;
                txtLX.ReadOnly = true;
                txtLY.ReadOnly = true;
                cboColor.Enabled = false;
                chkOnTop.Enabled = false;
                chkShow.Enabled = false;

                iFlag = 2;
                dtNote.Text = DateTime.Now.ToShortDateString();

                btnSave.Enabled = true;

                txtNote.ReadOnly = false;
                txtWidth.ReadOnly = false;
                txtHeight.ReadOnly = false;
                txtLX.ReadOnly = false;
                txtLY.ReadOnly = false;
                cboColor.Enabled = true;
                chkOnTop.Enabled = true;
                chkShow.Enabled = true;


                frmMain.iPage = iRIndex;
                iID = Convert.ToInt32(dgvNote.Rows[iRIndex].Cells[0].Value);
                dtNote.Text = DateTime.Now.ToShortDateString();
                txtNote.Text = dgvNote.Rows[iRIndex].Cells[2].Value.ToString();
                txtWidth.Text = dgvNote.Rows[iRIndex].Cells[3].Value.ToString();
                txtHeight.Text = dgvNote.Rows[iRIndex].Cells[4].Value.ToString();
                txtLX.Text = dgvNote.Rows[iRIndex].Cells[5].Value.ToString();
                txtLY.Text = dgvNote.Rows[iRIndex].Cells[6].Value.ToString();
                cboColor.Text = dgvNote.Rows[iRIndex].Cells[7].Value.ToString();

                if (dgvNote.Rows[iRIndex].Cells[8].Value.ToString() == "Yes")
                    chkOnTop.Checked = true;
                else
                    chkOnTop.Checked = false;

                if (dgvNote.Rows[iRIndex].Cells[9].Value.ToString() == "Yes")
                    chkShow.Checked = true;
                else
                    chkShow.Checked = false;
            }
            else
            {
                dgvNote.ClearSelection();
            }
        }
    }
}
