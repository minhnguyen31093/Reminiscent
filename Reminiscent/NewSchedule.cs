using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Xml.Linq;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Reminiscent
{
    public partial class NewSchedule : Form
    {
        public NewSchedule()
        {
            InitializeComponent();
        }
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        int iID = -1;
        int iIDi = 0;
        int iIDj = 0;
        public static string strMode = "D";
        public static int iIDChild = -1;
        int iPercent = 0;
        int iCT = 0;
        int iPC = 0;
        string strTime = "Time";
        string strWork = "Work";
        Boolean bFileSaved = false;
        Boolean bFileNull = false;
        List<int> idID1 = new List<int>();
        List<int> idID2 = new List<int>();

        string strDelMainFile = "";
        List<string> strDelChildFiles = new List<string>();

        #region PageLoad
        private void NewSchedule_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule-temp.xml"))
                File.Delete(Application.StartupPath + "/Data/Schedule-temp.xml");

            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
                File.Copy(Application.StartupPath + "/Data/Schedule.xml", Application.StartupPath + "/Data/Schedule-temp.xml");

            #region File exists
            if (!File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                bFileNull = true;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement p = xDoc.DocumentElement;
                XmlNodeList T = p.GetElementsByTagName("Tasks");
                if (T.Count == 0)
                {
                    bFileNull = true;
                }
            }
            #endregion

            dtEnd.MinDate = dtStart.Value;

            txtAbstract.Select(0, 0);
            txtAbstract.Clear();
            txtAbstract.SetLayoutType(ExtendedRichTextBox.LayoutModes.WYSIWYG);
            cboFontSize.Text = Convert.ToInt32(txtAbstract.Font.Size).ToString();

            txtTaskName.ReadOnly = true;
            txtTaskDes.ReadOnly = true;
            nPPP.Enabled = false;
            nPA.Enabled = false;
            nPH.Enabled = false;
            tlsTask.Enabled = false;

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

            string strDetail = "";
            string strNew1 = "";
            string strNew2 = "";
            string strEdit = "";

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    strDetail = frmMain.Decryption(node.SelectSingleNode("Detail").InnerText);
                    strNew1 = frmMain.Decryption(node.SelectSingleNode("New1").InnerText);
                    strNew2 = frmMain.Decryption(node.SelectSingleNode("New2").InnerText);
                    strEdit = frmMain.Decryption(node.SelectSingleNode("Edit").InnerText);

                    lblProjectName.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblPTime.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblStart.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    lblEnd.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    lblAbstract.Text = frmMain.Decryption(node.SelectSingleNode("lbl5").InnerText);
                    lblTaskName.Text = frmMain.Decryption(node.SelectSingleNode("lbl6").InnerText);
                    lblTInfo.Text = frmMain.Decryption(node.SelectSingleNode("lbl7").InnerText);
                    lblPPP.Text = frmMain.Decryption(node.SelectSingleNode("lbl8").InnerText);
                    lblPA.Text = frmMain.Decryption(node.SelectSingleNode("lbl9").InnerText);
                    lblHour.Text = frmMain.Decryption(node.SelectSingleNode("lbl10").InnerText);
                    lblDes.Text = frmMain.Decryption(node.SelectSingleNode("lbl11").InnerText);

                    strTime = frmMain.Decryption(node.SelectSingleNode("str1").InnerText);
                    strWork = frmMain.Decryption(node.SelectSingleNode("str2").InnerText);

                    colTask.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colName.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colPercent.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    colAccomplished.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colHour.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);
                    break;
                }
            }
            #endregion

            #region Mode
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");

                if (UC_Schedule.strScheduleMode == "D")
                {
                    this.Text = strDetail;
                    GetInfo(Tasks);
                    iID = UC_Schedule.iID;

                    tlsTool.Enabled = false;
                    txtProject.ReadOnly = true;
                    txtAbstract.ReadOnly = true;
                    dtStart.Enabled = false;
                    dtEnd.Enabled = false;

                    lstTasks.Size = new Size(lstTasks.Size.Width, lstTasks.Size.Height + 35);
                    txtTaskDes.Size = new Size(txtTaskDes.Size.Width, txtTaskDes.Size.Height + 35);

                    btnSave.Hide();
                    btnSaveAs.Hide();
                    btnRefresh.Hide();
                    btnDelete.Hide();

                    btnOK.Hide();
                    btnCancel.Location = new Point(this.Width/2 - btnCancel.Size.Width/2, btnCancel.Location.Y);
                }
                else if (UC_Schedule.strScheduleMode == "NFP")
                {
                    this.Text = strNew1;
                    iID = GetMaxID(Tasks);
                    iIDi = iID - 1;

                    for (int i = 0; i < Tasks.Count; i++)
                    {
                        if (Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)) == UC_Schedule.iID)
                        {
                            Tasks[i].ParentNode.AppendChild(Tasks[i].CloneNode(true));
                            xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");

                            strDelMainFile = Application.StartupPath + "/Data/Schedule/" + iID.ToString() + ".rtf";

                            if (File.Exists(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + ".rtf"))
                                File.Copy(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + ".rtf", strDelMainFile);

                            if (Tasks[i].LastChild.Name == "ChildTask")
                                for (int z = 1; z <= Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count; z++)
                                {
                                    strDelChildFiles.Add(Application.StartupPath + "/Data/Schedule/" + iID.ToString() + "-" + z + ".rtf");

                                    if (File.Exists(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + "-" + z + ".rtf"))
                                        File.Copy(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + "-" + z + ".rtf", Application.StartupPath + "/Data/Schedule/" + iID.ToString() + "-" + z + ".rtf");
                                }

                            break;
                        }
                    }
                    Tasks[iIDi].SelectSingleNode("ID").InnerText = frmMain.Encryption(iID.ToString());
                    xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");

                    GetInfo(Tasks);
                    
                    //CreateNew();
                }
                else if (UC_Schedule.strScheduleMode == "N")
                {
                    this.Text = strNew2;
                    iID = GetMaxID(Tasks);
                    iIDi = iID - 1;
                    CreateNew();
                }
                else if (UC_Schedule.strScheduleMode == "E")
                {
                    this.Text = strEdit;
                    GetInfo(Tasks);
                    iID = UC_Schedule.iID;
                }
                CountTime();
                PanelChart.Invalidate();
            }
            #endregion

            #region Theme
            XmlDocument xmlDocTheme = new XmlDocument();
            if (frmMain.strTheme == "Blue")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Blue.xml");
            }
            else if (frmMain.strTheme == "White")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-White.xml");
            }
            else if (frmMain.strTheme == "Simple")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Simple.xml");
            }

            foreach (XmlNode node in xmlDocTheme.SelectNodes("Theme/Style"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == frmMain.strTheme)
                {
                    this.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg5").InnerText)));
                    break;
                }
            }
            #endregion

            LoadListTask();

            CalculatePercent();
        }
        #endregion

        #region RichText
        private Color GetColor(Color initColor)
        {
            using (ColorDialog dlgColor = new ColorDialog())
            {
                dlgColor.Color = initColor;
                dlgColor.AllowFullOpen = true;
                dlgColor.AnyColor = true;
                dlgColor.FullOpen = true;
                dlgColor.ShowHelp = false;
                dlgColor.SolidColorOnly = false;
                if (dlgColor.ShowDialog() == DialogResult.OK)
                {
                    return dlgColor.Color;
                }
                else
                {
                    return initColor;
                }
            }
        }
        private Font GetFont(Font initFont)
        {
            using (FontDialog dlgFont = new FontDialog())
            {
                dlgFont.Font = initFont;
                dlgFont.AllowSimulations = true;
                dlgFont.AllowVectorFonts = true;
                dlgFont.AllowVerticalFonts = true;
                dlgFont.FontMustExist = true;
                dlgFont.ShowHelp = false;
                dlgFont.ShowEffects = true;
                dlgFont.ShowColor = false;
                dlgFont.ShowApply = false;
                dlgFont.FixedPitchOnly = false;

                if (dlgFont.ShowDialog() == DialogResult.OK)
                {
                    return dlgFont.Font;
                }
                else
                {
                    return initFont;
                }
            }
        }
        private string GetImagePath()
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Multiselect = false;
            dlgOpen.ShowReadOnly = false;
            dlgOpen.RestoreDirectory = true;
            dlgOpen.ReadOnlyChecked = false;
            dlgOpen.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                return dlgOpen.FileName;
            }
            else
            {
                return "";
            }
        }

        #region CharStyle
        private void btnBold_Click(object sender, EventArgs e)
        {
            if (txtAbstract.SelectionCharStyle.Bold == true)
            {
                btnBold.Checked = false;
                ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                cs.Bold = false;
                txtAbstract.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                btnBold.Checked = true;
                ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                cs.Bold = true;
                txtAbstract.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAbstract.SelectionCharStyle.Italic == true)
                {
                    btnItalic.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                    cs.Italic = false;
                    txtAbstract.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnItalic.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                    cs.Italic = true;
                    txtAbstract.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAbstract.SelectionCharStyle.Underline == true)
                {
                    btnUnderline.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                    cs.Underline = false;
                    txtAbstract.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnUnderline.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtAbstract.SelectionCharStyle;
                    cs.Underline = true;
                    txtAbstract.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Align
        private void btnLeftAlign_Click(object sender, EventArgs e)
        {
            txtAbstract.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            btnAlignLeft.Checked = true;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = false;
        }

        private void btnCenterAlign_Click(object sender, EventArgs e)
        {
            txtAbstract.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = false;
            btnAlignCenter.Checked = true;
        }

        private void btnRightAlign_Click(object sender, EventArgs e)
        {
            txtAbstract.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            btnAlignLeft.Checked = false;
            btnAlignRight.Checked = true;
            btnAlignCenter.Checked = false;
        }
        #endregion

        private void txtAbstract_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Aglin
                if (txtAbstract.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                else if (txtAbstract.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = true;
                    btnAlignRight.Checked = false;
                }
                else if (txtAbstract.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
                {
                    btnAlignLeft.Checked = false;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = true;
                }
                else
                {
                    btnAlignLeft.Checked = true;
                    btnAlignCenter.Checked = false;
                    btnAlignRight.Checked = false;
                }
                #endregion

                #region Font
                FontFamily ff = new FontFamily("Tahoma");
                if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                {
                    btnBold.Enabled = true;
                    btnBold.Checked = txtAbstract.SelectionCharStyle.Bold;
                }
                else
                {
                    btnBold.Enabled = false;
                    btnBold.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    btnItalic.Enabled = true;
                    btnItalic.Checked = txtAbstract.SelectionCharStyle.Italic;
                }
                else
                {
                    btnItalic.Enabled = false;
                    btnItalic.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                {
                    btnUnderline.Enabled = true;
                    btnUnderline.Checked = txtAbstract.SelectionCharStyle.Underline;
                }
                else
                {
                    btnUnderline.Enabled = false;
                    btnUnderline.Checked = false;
                }

                ff.Dispose();
                #endregion

                //txtAbstract.UpdateObjects();
            }
            catch (Exception)
            { }
        }

        private void txtAbstract_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void txtAbstract_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (txtAbstract.SelectionType == RichTextBoxSelectionTypes.Object ||
                    txtAbstract.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(txtAbstract.SelectedObject().sizel.Width));
                }
            }
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            try
            {
                string imgPath = GetImagePath(); //Lấy đường dẫn file ảnh

                Bitmap BitmapPic = new Bitmap(imgPath); //Tạo một Bitmap ><

                Clipboard.SetDataObject(BitmapPic); //Đặt đối tượng dử liệu vào Clipboard

                DataFormats.Format FormatPic = DataFormats.GetFormat(DataFormats.Bitmap);//Lấy định dạng của hình

                if (txtAbstract.CanPaste(FormatPic)) //Nếu có thể chèn vào RTBox
                {
                    txtAbstract.Paste(FormatPic); //Chèn hình vào
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                txtAbstract.SelectionColor = GetColor(txtAbstract.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnHighLightColor_Click(object sender, EventArgs e)
        {
            try
            {
                txtAbstract.SelectionBackColor = GetColor(txtAbstract.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            txtAbstract.Undo();
        }

        private void btnRedo_Click(object sender, EventArgs e)
        {
            txtAbstract.Redo();
        }

        private void cboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboFontSize.Focused) return;
                txtAbstract.SelectionFont = new Font(txtAbstract.Font.Name, Convert.ToInt32(cboFontSize.Text), txtAbstract.SelectionFont.Style);
            }
            catch (Exception)
            {
            }
        }

        private void cboFontSize_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    txtAbstract.SelectionFont = new Font(txtAbstract.Font.Name, Convert.ToInt32(cboFontSize.Text));
                    txtAbstract.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        private void cboFontSize_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
                e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
                e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete)
            {
                //allow key
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Get
        void GetInfo(XmlNodeList Tasks)
        {
            if (Tasks.Count > 0)
            {
                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)) == UC_Schedule.iID)
                    {
                        iIDi = i;
                        txtProject.Text = frmMain.Decryption(Tasks[i].SelectSingleNode("Name").InnerText);
                        //txtAbstract.Text = Tasks[i].SelectSingleNode("Abstract").InnerText;
                        if (File.Exists(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + ".rtf"))
                            txtAbstract.LoadFile(Application.StartupPath + "/Data/Schedule/" + frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText) + ".rtf");
                        dtStart.Text = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateStart").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture).ToString();
                        dtEnd.Text = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateEnd").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture).ToString();
                        iPC = Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("PercentComplete").InnerText));
                    }
                }
            }
        }

        int GetMaxID(XmlNodeList Tasks)
        {
            int iMax = 0;
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (iMax < Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                {
                    iMax = Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText));
                }
            }
            iMax += 1;
            return iMax;
        }
        #endregion

        #region Creates
        void CreateNew()
        {
            if (!File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Schedule.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartDocument();
                writer.WriteStartElement("TasksList");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;

            XmlNode nodeTasks = xmlDoc.CreateNode(XmlNodeType.Element, "Tasks", null);

            XmlNode nodeID = xmlDoc.CreateElement("ID");
            nodeID.InnerText = iID.ToString();

            XmlNode nodeName = xmlDoc.CreateElement("Name");
            nodeName.InnerText = "";

            XmlNode nodeDateStart = xmlDoc.CreateElement("DateStart");
            nodeDateStart.InnerText = "";

            XmlNode nodeDateEnd = xmlDoc.CreateElement("DateEnd");
            nodeDateEnd.InnerText = "";

            XmlNode nodePercentComplete = xmlDoc.CreateElement("PercentComplete");
            nodePercentComplete.InnerText = "";

            XmlNode nodeAbstract = xmlDoc.CreateElement("Abstract");
            nodeAbstract.InnerText = "";

            nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);

            nodeTasks.AppendChild(nodeID);
            nodeTasks.AppendChild(nodeName);
            nodeTasks.AppendChild(nodeDateStart);
            nodeTasks.AppendChild(nodeDateEnd);
            nodeTasks.AppendChild(nodePercentComplete);
            nodeTasks.AppendChild(nodeAbstract);

            xmlDoc.DocumentElement.AppendChild(nodeTasks);
            xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
        }
        #endregion

        #region Click
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtProject.Text.Trim() != "" && txtAbstract.Text.Trim() != "")
            {
                int iflagerror = 0;

                #region File exists
                if (!File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Schedule.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented; //Xuống dòng
                    writer.WriteStartDocument();
                    writer.WriteStartElement("TasksList");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                #endregion

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement parent = xmlDoc.DocumentElement;

                if (bFileSaved == false)
                {
                    #region New
                    if (UC_Schedule.strScheduleMode == "NFP" || UC_Schedule.strScheduleMode == "N")
                    {
                        if (txtProject.Text != "")
                        {
                            if (txtAbstract.Text != "")
                            {
                                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
                                if (Tasks.Count == 0)
                                {
                                    iID = 1;
                                    XmlNode nodeTasks = xmlDoc.CreateNode(XmlNodeType.Element, "Tasks", null);

                                    XmlNode nodeID = xmlDoc.CreateElement("ID");
                                    nodeID.InnerText = frmMain.Encryption(iID.ToString());

                                    XmlNode nodeName = xmlDoc.CreateElement("Name");
                                    nodeName.InnerText = frmMain.Encryption(txtProject.Text);

                                    XmlNode nodeDateStart = xmlDoc.CreateElement("DateStart");
                                    nodeDateStart.InnerText = frmMain.Encryption(dtStart.Text);

                                    XmlNode nodeDateEnd = xmlDoc.CreateElement("DateEnd");
                                    nodeDateEnd.InnerText = frmMain.Encryption(dtEnd.Text);

                                    XmlNode nodePercentComplete = xmlDoc.CreateElement("PercentComplete");
                                    nodePercentComplete.InnerText = frmMain.Encryption(iPC.ToString());

                                    XmlNode nodeAbstract = xmlDoc.CreateElement("Abstract");
                                    nodeAbstract.InnerText = frmMain.Encryption(txtAbstract.Text);

                                    nodeTasks.AppendChild(nodeID);
                                    nodeTasks.AppendChild(nodeName);
                                    nodeTasks.AppendChild(nodeDateStart);
                                    nodeTasks.AppendChild(nodeDateEnd);
                                    nodeTasks.AppendChild(nodePercentComplete);
                                    nodeTasks.AppendChild(nodeAbstract);

                                    xmlDoc.DocumentElement.AppendChild(nodeTasks);
                                }
                                else
                                {
                                    //if (UC_Schedule.strScheduleMode == "NFP")
                                    for (int i = 0; i < Tasks.Count; i++)
                                    {
                                        if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                                        {
                                            Tasks[i].SelectSingleNode("Name").InnerText = frmMain.Encryption(txtProject.Text);
                                            Tasks[i].SelectSingleNode("DateStart").InnerText = frmMain.Encryption(dtStart.Text);
                                            Tasks[i].SelectSingleNode("DateEnd").InnerText = frmMain.Encryption(dtEnd.Text);
                                            Tasks[i].SelectSingleNode("PercentComplete").InnerText = frmMain.Encryption(iPC.ToString());
                                            Tasks[i].SelectSingleNode("Abstract").InnerText = frmMain.Encryption(txtAbstract.Text);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                iflagerror = 1;
                                MessageBox.Show("You can't leave Abstract empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            iflagerror = 1;
                            MessageBox.Show("You can't leave Project Name empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    #endregion
                }

                #region Edit
                if (UC_Schedule.strScheduleMode == "E")
                {
                    if (txtProject.Text != "")
                    {
                        if (txtAbstract.Text != "")
                        {
                            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
                            for (int i = 0; i < Tasks.Count; i++)
                            {
                                if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                                {
                                    Tasks[i].SelectSingleNode("Name").InnerText = frmMain.Encryption(txtProject.Text);
                                    Tasks[i].SelectSingleNode("DateStart").InnerText = frmMain.Encryption(dtStart.Text);
                                    Tasks[i].SelectSingleNode("DateEnd").InnerText = frmMain.Encryption(dtEnd.Text);
                                    Tasks[i].SelectSingleNode("PercentComplete").InnerText = frmMain.Encryption(iPC.ToString());
                                    Tasks[i].SelectSingleNode("Abstract").InnerText = frmMain.Encryption(txtAbstract.Text);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            iflagerror = 1;
                            MessageBox.Show("You can't leave Abstract empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        iflagerror = 1;
                        MessageBox.Show("You can't leave Project Name empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                #endregion

                if (!Directory.Exists(Application.StartupPath + "/Data/Schedule"))
                {
                    Directory.CreateDirectory(Application.StartupPath + "/Data/Schedule");
                }
                txtAbstract.SaveFile(Application.StartupPath + "/Data/Schedule/" + iID.ToString() + ".rtf");
                xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");

                #region Sort
                XElement root = XElement.Load(Application.StartupPath + "/Data/Schedule.xml");
                var orderedtabs = root.Elements("Tasks")
                                      .OrderBy(xtab => Convert.ToInt32(frmMain.Decryption(xtab.Element("ID").Value.ToString())))
                                      .ToArray();
                root.RemoveAll();
                foreach (XElement tab in orderedtabs)
                    root.Add(tab);
                root.Save(Application.StartupPath + "/Data/Schedule.xml");
                #endregion

                //Delete Child rtf
                for (int z = 0; z < idID1.Count; z++)
                {
                    if (File.Exists(Application.StartupPath + "/Data/Schedule/" + idID1[z] + "-" + idID2[z] + ".rtf"))
                    {
                        File.Delete(Application.StartupPath + "/Data/Schedule/" + idID1[z] + "-" + idID2[z] + ".rtf");
                    }
                }
                if (File.Exists(Application.StartupPath + "/Data/Schedule-temp.xml"))
                    File.Delete(Application.StartupPath + "/Data/Schedule-temp.xml");

                if (iflagerror == 0)
                {
                    frmMain.strRefeshUC = "Yes";
                    this.Close();
                }
            }
            else
                MessageBox.Show("Project name or abstract empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (bFileNull == true)
            { 
                if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
                    File.Delete(Application.StartupPath + "/Data/Schedule.xml");
                if (Directory.Exists(Application.StartupPath + "/Data/Schedule"))
                {
                    Array.ForEach(Directory.GetFiles(Application.StartupPath + "/Data/Schedule"), File.Delete);
                    Directory.Delete(Application.StartupPath + "/Data/Schedule");
                }
            }

            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml") && File.Exists(Application.StartupPath + "/Data/Schedule-temp.xml"))
            {
                File.Replace(Application.StartupPath + "/Data/Schedule-temp.xml", Application.StartupPath + "/Data/Schedule.xml", Application.StartupPath + "/Data/Schedule-bk.xml");
                File.Delete(Application.StartupPath + "/Data/Schedule-temp.xml");
                File.Delete(Application.StartupPath + "/Data/Schedule-bk.xml");
            }

            if (File.Exists(strDelMainFile))
                File.Delete(strDelMainFile);

            for (int i = 0; i < strDelChildFiles.Count; i++)
            {
                if (File.Exists(strDelChildFiles[i]))
                    File.Delete(strDelChildFiles[i]);
            }

            this.Close();
        }
        #endregion

        #region Hover
        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion

        #region ValueChanged
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dtEnd.MinDate = dtStart.Value;
            CountTime();
        }

        private void dtEnd_ValueChanged(object sender, EventArgs e)
        {
            CountTime();
        }
        #endregion

        #region Count
        void CountTime()
        {
            try
            {
                TimeSpan Date100 = dtEnd.Value - dtStart.Value;
                TimeSpan DateNow = DateTime.Now - dtStart.Value;

                if (DateNow.Days < Date100.Days)
                {
                    int iPOW = DateNow.Days * 100 / Date100.Days;
                    iCT = iPOW;
                    PanelChart.Invalidate();
                }
                else
                {
                    iCT = 100;
                    PanelChart.Invalidate();
                }
            }
            catch
            {
                MessageBox.Show("Error date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Chart
        private void PanelChart_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(PanelChart.BackColor);
            int i0 = 9;
            int i100 = e.ClipRectangle.Width - i0;
            int iy1 = e.ClipRectangle.Height / 3 - 7;
            int iy2 = e.ClipRectangle.Height * 2 / 3 + 7;
            Graphics gfx = e.Graphics;
            Pen p0 = new Pen(Color.Silver, 40);
            Pen p1 = new Pen(Color.LightGreen, 40);
            Pen p2 = new Pen(Color.Orange, 40);
            Pen p3 = new Pen(Color.Tomato, 40);

            gfx.DrawLine(p0, i0, iy1, i100, iy1);
            gfx.DrawLine(p0, i0, iy2, i100, iy2);

            int iTime = i0;
            if (iCT > 2)
                iTime = iCT * i100 / 100;

            p1 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iTime, 0), Color.SeaGreen, Color.SpringGreen), 40);
            p2 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iTime, 0), Color.Orange, Color.Yellow), 40);
            p3 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iTime, 0), Color.DeepSkyBlue, Color.Cyan), 40);

            if (iCT < 33)
                gfx.DrawLine(p1, i0, iy1, iTime, iy1);
            else if (iCT >= 33 && iCT < 66)
                gfx.DrawLine(p2, i0, iy1, iTime, iy1);
            else
                gfx.DrawLine(p3, i0, iy1, iTime, iy1);

            gfx.DrawString(iCT.ToString() + "% " + strTime, new Font("Arial", 10.0f, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(i100 / 2 - 20, iy1 - 7));

            int iWork = i0;
            if (Convert.ToInt32(iPC) > 2)
                iWork = Convert.ToInt32(iPC) * i100 / 100;

            p1 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iWork, 0), Color.SeaGreen, Color.SpringGreen), 40);
            p2 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iWork, 0), Color.Orange, Color.Yellow), 40);
            p3 = new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iWork, 0), Color.DeepSkyBlue, Color.Cyan), 40);

            if (Convert.ToInt32(iPC) < 33)
                gfx.DrawLine(p1, i0, iy2, iWork, iy2);
            else if (Convert.ToInt32(iPC) >= 33 && Convert.ToInt32(iPC) < 66)
                gfx.DrawLine(p2, i0, iy2, iWork, iy2);
            else
                gfx.DrawLine(p3, i0, iy2, iWork, iy2);

            gfx.DrawString(iPC.ToString() + "% " + strWork, new Font("Arial", 10.0f, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(i100 / 2 - 20, iy2 - 7));
        }
        #endregion

        #region Task
        void LoadListTask()
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                lstTasks.Items.Clear();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement parent = xmlDoc.DocumentElement;
                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");


                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                    {
                        if (Tasks[i].LastChild.Name == "ChildTask" && Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count > 0)
                        {
                            for (int j = 0; j < Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                            {
                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText);
                                lvi.SubItems.Add(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Name").InnerText));
                                lvi.SubItems.Add(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText) + "%");
                                lvi.SubItems.Add(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Accomplished").InnerText) + "%");
                                lvi.SubItems.Add(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Hour").InnerText));
                                lstTasks.Items.Add(lvi);
                            }
                            break;
                        }
                    }
                }
            }
            else
            { 
                
            }
        }

        int CalculateMaxID()
        {
            int iIDmax = 0;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
            XmlElement parent = xmlDoc.DocumentElement;
            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
            if (Tasks[iIDi].LastChild.Name == "ChildTask")
                for (int j = 0; j < Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                {
                    if (iIDmax < Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText)))
                        iIDmax = Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText));
                }
            iIDmax++;
            return iIDmax;
        }

        void CalculatePercent()
        {
            iPercent = 0;

            foreach (ListViewItem lvi in lstTasks.Items)
            { 
                iPercent += Convert.ToInt32(lvi.SubItems[3].Text.Substring(0, lvi.SubItems[3].Text.Length - 1))
                    * Convert.ToInt32(lvi.SubItems[2].Text.Substring(0, lvi.SubItems[2].Text.Length - 1)) 
                    / 100;
            }

            iPC = iPercent;
            PanelChart.Invalidate();
        }

        int CalculatePercentperProject()
        {
            int ippp = 0;
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement parent = xmlDoc.DocumentElement;
                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");
                if (Tasks[iIDi].LastChild.Name == "ChildTask")
                    for (int j = 0; j < Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                    {
                        ippp += Convert.ToInt32(frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText));
                    }
            }
            return ippp;
        }

        #region Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTaskName.Text.Trim() != "" && txtTaskDes.Text.Trim() != "")
            {
                #region File exists
                if (!File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Schedule.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented; //Xuống dòng
                    writer.WriteStartDocument();
                    writer.WriteStartElement("TasksList");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                #endregion

                #region New
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement p = xDoc.DocumentElement;
                XmlNodeList T = p.GetElementsByTagName("Tasks");
                if (T.Count == 0)
                {
                    iID = 1;
                    XmlNode nTasks = xDoc.CreateNode(XmlNodeType.Element, "Tasks", null);

                    XmlNode nID = xDoc.CreateElement("ID");
                    nID.InnerText = frmMain.Encryption(iID.ToString());

                    XmlNode nName = xDoc.CreateElement("Name");
                    nName.InnerText = frmMain.Encryption(txtProject.Text);

                    XmlNode nDateStart = xDoc.CreateElement("DateStart");
                    nDateStart.InnerText = frmMain.Encryption(dtStart.Text);

                    XmlNode nDateEnd = xDoc.CreateElement("DateEnd");
                    nDateEnd.InnerText = frmMain.Encryption(dtEnd.Text);

                    XmlNode nPercentComplete = xDoc.CreateElement("PercentComplete");
                    nPercentComplete.InnerText = frmMain.Encryption(iPC.ToString());

                    XmlNode nAbstract = xDoc.CreateElement("Abstract");
                    nAbstract.InnerText = frmMain.Encryption(txtAbstract.Text);

                    nTasks.AppendChild(nID);
                    nTasks.AppendChild(nName);
                    nTasks.AppendChild(nDateStart);
                    nTasks.AppendChild(nDateEnd);
                    nTasks.AppendChild(nPercentComplete);
                    nTasks.AppendChild(nAbstract);

                    xDoc.DocumentElement.AppendChild(nTasks);

                    xDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
                    bFileSaved = true;
                }
                #endregion

                if (strMode == "N")
                {
                    #region old unused
                    if (txtTaskName.Text != "")
                    {
                        if (CalculatePercentperProject() != 100)
                        {
                            if (CalculatePercentperProject() + nPPP.Value <= 100)
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                                XmlElement parent = xmlDoc.DocumentElement;
                                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                                //if (lstTasks.Items.Count > 0)
                                //{
                                //    foreach (ListViewItem lvi in lstTasks.Items)
                                //    {
                                //        if (iIDChild < Convert.ToInt32(lvi.Text))
                                //            iIDChild = Convert.ToInt32(lvi.Text);
                                //    }
                                //    iIDChild++;
                                //}
                                //else
                                //{
                                //    iIDChild = 0;
                                //}

                                for (int i = 0; i < Tasks.Count; i++)
                                {
                                    if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                                    {
                                        XmlNode nodeChildTask;
                                        if (Tasks[i].LastChild.Name != "ChildTask")
                                        {
                                            nodeChildTask = xmlDoc.CreateNode(XmlNodeType.Element, "ChildTask", null);
                                            Tasks[i].AppendChild(nodeChildTask);
                                        }
                                        else
                                        {
                                            nodeChildTask = Tasks[i].SelectSingleNode("ChildTask");
                                        }
                                        XmlNode nodeTask = xmlDoc.CreateNode(XmlNodeType.Element, "Task", null);

                                        XmlNode nodeID = xmlDoc.CreateElement("ID");
                                        nodeID.InnerText = frmMain.Encryption(CalculateMaxID().ToString());

                                        XmlNode nodeName = xmlDoc.CreateElement("Name");
                                        nodeName.InnerText = frmMain.Encryption(txtTaskName.Text);

                                        XmlNode nodePercent = xmlDoc.CreateElement("Percent");
                                        nodePercent.InnerText = frmMain.Encryption(nPPP.Value.ToString());

                                        XmlNode nodeAccomplished = xmlDoc.CreateElement("Accomplished");
                                        nodeAccomplished.InnerText = frmMain.Encryption(nPA.Value.ToString());

                                        XmlNode nodeDescription = xmlDoc.CreateElement("Description");
                                        nodeDescription.InnerText = frmMain.Encryption(txtTaskDes.Text);

                                        XmlNode nodeHour = xmlDoc.CreateElement("Hour");
                                        nodeHour.InnerText = frmMain.Encryption(nPH.Value.ToString());

                                        nodeTask.AppendChild(nodeID);
                                        nodeTask.AppendChild(nodeName);
                                        nodeTask.AppendChild(nodePercent);
                                        nodeTask.AppendChild(nodeAccomplished);
                                        nodeTask.AppendChild(nodeDescription);
                                        nodeTask.AppendChild(nodeHour);

                                        nodeChildTask.AppendChild(nodeTask);

                                        if (!Directory.Exists(Application.StartupPath + "/Data/Schedule/"))
                                            Directory.CreateDirectory(Application.StartupPath + "/Data/Schedule/");
                                        txtTaskDes.SaveFile(Application.StartupPath + "/Data/Schedule/" + iID + "-" + CalculateMaxID() + ".rtf");

                                        xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
                                        LoadListTask();
                                        strMode = "";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please set percent per project of new task lower than " + (100 - CalculatePercentperProject()) + "%", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You can't add task anymore!\r\nPlease delete or reduce percent per project of other task", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can't leave Task Name blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CalculatePercent();
                    #endregion
                }

                else if (strMode == "E")
                {
                    #region old unused
                    if (txtTaskName.Text != "")
                    {
                        int iPbig = 0;
                        foreach (ListViewItem lvi in lstTasks.SelectedItems)
                        {
                            iPbig = Convert.ToInt32(lvi.SubItems[2].Text.Substring(0, lvi.SubItems[2].Text.Length - 1));
                            break;
                        }
                        if (CalculatePercentperProject() - iPbig + nPPP.Value <= 100)
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                            XmlElement parent = xmlDoc.DocumentElement;
                            XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                            for (int i = 0; i < Tasks.Count; i++)
                            {
                                if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                                {
                                    for (int j = 0; j < Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                                    {
                                        if (iIDChild == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText)))
                                        {
                                            Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Name").InnerText = frmMain.Encryption(txtTaskName.Text);
                                            Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Percent").InnerText = frmMain.Encryption(nPPP.Value.ToString());
                                            Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Accomplished").InnerText = frmMain.Encryption(nPA.Value.ToString());
                                            Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Hour").InnerText = frmMain.Encryption(nPH.Value.ToString());
                                            Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("Description").InnerText = frmMain.Encryption(txtTaskDes.Text);
                                            xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");

                                            string streID1 = frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ID").InnerText);
                                            string streID2 = frmMain.Decryption(Tasks[iIDi].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText);
                                            txtTaskDes.SaveFile(Application.StartupPath + "/Data/Schedule/" + streID1 + "-" + streID2 + ".rtf");

                                            LoadListTask();
                                            strMode = "";
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please set percent per project of new task bigger than " + (100 - (CalculatePercentperProject() - iPbig)) + "%", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can't leave Task Name blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CalculatePercent();
                    #endregion
                }
            }
            else
                MessageBox.Show("Task name or description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Refresh
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (UC_Schedule.strScheduleMode != "D")
            {
                strMode = "N";
                txtTaskName.Text = "";
                nPPP.Value = 0;
                nPA.Value = 0;
                nPH.Value = 0;
                txtTaskDes.Text = "";

                txtTaskName.ReadOnly = false;
                txtTaskDes.ReadOnly = false;
                nPPP.Enabled = true;
                nPA.Enabled = true;
                nPH.Enabled = true;
                tlsTask.Enabled = true;
            }
        }
        #endregion

        #region Save As
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtTaskName.Text.Trim() != "" && txtTaskDes.Text.Trim() != "")
            {
                if (strMode == "E")
                {
                    #region old unused
                    if (txtTaskName.Text != "")
                    {
                        if (CalculatePercentperProject() != 100)
                        {
                            if (CalculatePercentperProject() + nPPP.Value <= 100)
                            {
                                XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                                XmlElement parent = xmlDoc.DocumentElement;
                                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                                //if (lstTasks.Items.Count > 0)
                                //{
                                //    foreach (ListViewItem lvi in lstTasks.Items)
                                //    {
                                //        if (iIDChild < Convert.ToInt32(lvi.Text))
                                //            iIDChild = Convert.ToInt32(lvi.Text);
                                //    }
                                //    iIDChild++;
                                //}
                                //else
                                //{
                                //    iIDChild = 0;
                                //}

                                for (int i = 0; i < Tasks.Count; i++)
                                {
                                    if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                                    {
                                        XmlNode nodeChildTask;
                                        if (Tasks[i].LastChild.Name != "ChildTask")
                                        {
                                            nodeChildTask = xmlDoc.CreateNode(XmlNodeType.Element, "ChildTask", null);
                                            Tasks[i].AppendChild(nodeChildTask);
                                        }
                                        else
                                        {
                                            nodeChildTask = Tasks[i].SelectSingleNode("ChildTask");
                                        }
                                        XmlNode nodeTask = xmlDoc.CreateNode(XmlNodeType.Element, "Task", null);

                                        XmlNode nodeID = xmlDoc.CreateElement("ID");
                                        nodeID.InnerText = frmMain.Encryption(CalculateMaxID().ToString());

                                        XmlNode nodeName = xmlDoc.CreateElement("Name");
                                        nodeName.InnerText = frmMain.Encryption(txtTaskName.Text);

                                        XmlNode nodePercent = xmlDoc.CreateElement("Percent");
                                        nodePercent.InnerText = frmMain.Encryption(nPPP.Value.ToString());

                                        XmlNode nodeAccomplished = xmlDoc.CreateElement("Accomplished");
                                        nodeAccomplished.InnerText = frmMain.Encryption(nPA.Value.ToString());

                                        XmlNode nodeDescription = xmlDoc.CreateElement("Description");
                                        nodeDescription.InnerText = frmMain.Encryption(txtTaskDes.Text);

                                        XmlNode nodeHour = xmlDoc.CreateElement("Hour");
                                        nodeHour.InnerText = frmMain.Encryption(nPH.Value.ToString());

                                        nodeTask.AppendChild(nodeID);
                                        nodeTask.AppendChild(nodeName);
                                        nodeTask.AppendChild(nodePercent);
                                        nodeTask.AppendChild(nodeAccomplished);
                                        nodeTask.AppendChild(nodeDescription);
                                        nodeTask.AppendChild(nodeHour);

                                        nodeChildTask.AppendChild(nodeTask);

                                        if (!Directory.Exists(Application.StartupPath + "/Data/Schedule/"))
                                            Directory.CreateDirectory(Application.StartupPath + "/Data/Schedule/");
                                        txtTaskDes.SaveFile(Application.StartupPath + "/Data/Schedule/" + iID + "-" + CalculateMaxID() + ".rtf");

                                        xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
                                        LoadListTask();
                                        strMode = "";
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please set percent per project of new task lower than " + (100 - CalculatePercentperProject()) + "%", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("You can't add task anymore!\r\nPlease delete or reduce percent per project of other task", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You can't leave Task Name blank!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    CalculatePercent();
                    #endregion
                }
            }
            else
                MessageBox.Show("Task name or description empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (strMode == "E")
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement parent = xmlDoc.DocumentElement;
                XmlNodeList Tasks = parent.GetElementsByTagName("Tasks");

                for (int i = 0; i < Tasks.Count; i++)
                {
                    if (iID == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ID").InnerText)))
                    {
                        for (int j = 0; j < Tasks[i].SelectSingleNode("ChildTask").ChildNodes.Count; j++)
                        {
                            if (iIDChild == Convert.ToInt32(frmMain.Decryption(Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j].SelectSingleNode("ID").InnerText)))
                            {
                                DialogResult dsDel = new DialogResult();
                                dsDel = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dsDel == DialogResult.Yes)
                                {
                                    XmlNode node = Tasks[i].SelectSingleNode("ChildTask").ChildNodes[j];
                                    node.ParentNode.RemoveChild(node);
                                    idID1.Add(iID);
                                    idID2.Add(iIDChild);
                                    xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
                                    LoadListTask();
                                    strMode = "";
                                }
                                break;
                            }
                        }
                    }
                }
                CalculatePercent();
            }
        }
        #endregion

        private void lstTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstTasks.SelectedItems)
                {
                    if (UC_Schedule.strScheduleMode != "D")
                    {
                        strMode = "E";
                        txtTaskName.ReadOnly = false;
                        txtTaskDes.ReadOnly = false;
                        nPPP.Enabled = true;
                        nPA.Enabled = true;
                        nPH.Enabled = true;
                        tlsTask.Enabled = true;
                    }
                    iIDChild = Convert.ToInt32(lvi.Text);
                    txtTaskName.Text = lvi.SubItems[1].Text;
                    nPPP.Value = Convert.ToInt32(lvi.SubItems[2].Text.Substring(0, lvi.SubItems[2].Text.LastIndexOf("%")));
                    nPA.Value = Convert.ToInt32(lvi.SubItems[3].Text.Substring(0, lvi.SubItems[3].Text.LastIndexOf("%")));
                    nPH.Value = Convert.ToInt32(lvi.SubItems[4].Text);
                    txtTaskDes.LoadFile(Application.StartupPath + "/Data/Schedule/" + iID + "-" + lvi.Text + ".rtf");
                    break;
                }
            }
            else
            {
                txtTaskName.ReadOnly = true;
                txtTaskDes.ReadOnly = true;
                nPPP.Enabled = false;
                nPA.Enabled = false;
                nPH.Enabled = false;
                tlsTask.Enabled = false;

                iIDChild = -1;
                txtTaskName.Text = "";
                nPPP.Value = 0;
                nPA.Value = 0;
                nPH.Value = 0;
                txtTaskDes.Text = "";
            }
        }
        #endregion

        bool bBigSize = false;
        #region ChangeSize and Border
        private void btnBigSize_Click(object sender, EventArgs e)
        {
            if (bBigSize == false)
            {
                bBigSize = true;
                btnBigSize.Text = "<";
                this.Size = new Size(this.Size.Width + 224, this.Size.Height);
                this.Location = new Point(this.Location.X - 112, this.Location.Y);

                btnBigSize.Location = new Point(btnBigSize.Location.X + 224, btnBigSize.Location.Y);
                btnSave.Location = new Point(btnSave.Location.X + 112, btnSave.Location.Y);
                btnSaveAs.Location = new Point(btnSaveAs.Location.X + 112, btnSaveAs.Location.Y);
                btnRefresh.Location = new Point(btnRefresh.Location.X + 112, btnRefresh.Location.Y);
                btnDelete.Location = new Point(btnDelete.Location.X + 112, btnDelete.Location.Y);
                btnOK.Location = new Point(btnOK.Location.X + 112, btnOK.Location.Y);
                btnCancel.Location = new Point(btnCancel.Location.X + 112, btnCancel.Location.Y);

                txtProject.Size = new Size(txtProject.Size.Width + 224, txtProject.Size.Height);
                txtTaskName.Size = new Size(txtTaskName.Size.Width + 224, txtTaskName.Size.Height);
                txtAbstract.Size = new Size(txtAbstract.Size.Width + 224, txtAbstract.Size.Height);
                txtTaskDes.Size = new Size(txtTaskDes.Size.Width + 224, txtTaskDes.Size.Height);

                tlsTool.Size = new Size(tlsTool.Size.Width + 224, tlsTool.Size.Height);
                tlsTask.Size = new Size(tlsTask.Size.Width + 224, tlsTask.Size.Height);

                lblProjectName.Size = new Size(lblProjectName.Size.Width + 224, lblProjectName.Size.Height);

                panel1.Size = new Size(panel1.Size.Width + 224, panel1.Size.Height);
                panel2.Size = new Size(panel2.Size.Width + 224, panel2.Size.Height);
            }
            else if (bBigSize == true)
            {
                bBigSize = false;
                btnBigSize.Text = ">";
                this.Size = new Size(this.Size.Width - 224, this.Size.Height);
                this.Location = new Point(this.Location.X + 112, this.Location.Y);

                btnBigSize.Location = new Point(btnBigSize.Location.X - 224, btnBigSize.Location.Y);
                btnSave.Location = new Point(btnSave.Location.X - 112, btnSave.Location.Y);
                btnSaveAs.Location = new Point(btnSaveAs.Location.X - 112, btnSaveAs.Location.Y);
                btnRefresh.Location = new Point(btnRefresh.Location.X - 112, btnRefresh.Location.Y);
                btnDelete.Location = new Point(btnDelete.Location.X - 112, btnDelete.Location.Y);
                btnOK.Location = new Point(btnOK.Location.X - 112, btnOK.Location.Y);
                btnCancel.Location = new Point(btnCancel.Location.X - 112, btnCancel.Location.Y);

                txtProject.Size = new Size(txtProject.Size.Width - 224, txtProject.Size.Height);
                txtTaskName.Size = new Size(txtTaskName.Size.Width - 224, txtTaskName.Size.Height);
                txtAbstract.Size = new Size(txtAbstract.Size.Width - 224, txtAbstract.Size.Height);
                txtTaskDes.Size = new Size(txtTaskDes.Size.Width - 224, txtTaskDes.Size.Height);

                tlsTool.Size = new Size(tlsTool.Size.Width - 224, tlsTool.Size.Height);
                tlsTask.Size = new Size(tlsTask.Size.Width - 224, tlsTask.Size.Height);

                lblProjectName.Size = new Size(lblProjectName.Size.Width - 224, lblProjectName.Size.Height);

                panel1.Size = new Size(panel1.Size.Width - 224, panel1.Size.Height);
                panel2.Size = new Size(panel2.Size.Width - 224, panel2.Size.Height);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 0, 0, e.ClipRectangle.Height - 1);   //Trái
            gfx.DrawLine(p, 0, 0, e.ClipRectangle.Width - 1, 0);   //Trên
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);       //Phải
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 0, e.ClipRectangle.Height - 1);      //Dưới
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 0, 0, e.ClipRectangle.Height - 1);   //Trái
            gfx.DrawLine(p, 0, 0, e.ClipRectangle.Width - 1, 0);   //Trên
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, 0, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);       //Phải
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 0, e.ClipRectangle.Height - 1);      //Dưới
        }
        #endregion

        #region RichText 2
        //private Color GetColor(Color initColor)
        //{
        //    using (ColorDialog dlgColor = new ColorDialog())
        //    {
        //        dlgColor.Color = initColor;
        //        dlgColor.AllowFullOpen = true;
        //        dlgColor.AnyColor = true;
        //        dlgColor.FullOpen = true;
        //        dlgColor.ShowHelp = false;
        //        dlgColor.SolidColorOnly = false;
        //        if (dlgColor.ShowDialog() == DialogResult.OK)
        //        {
        //            return dlgColor.Color;
        //        }
        //        else
        //        {
        //            return initColor;
        //        }
        //    }
        //}
        //private Font GetFont(Font initFont)
        //{
        //    using (FontDialog dlgFont = new FontDialog())
        //    {
        //        dlgFont.Font = initFont;
        //        dlgFont.AllowSimulations = true;
        //        dlgFont.AllowVectorFonts = true;
        //        dlgFont.AllowVerticalFonts = true;
        //        dlgFont.FontMustExist = true;
        //        dlgFont.ShowHelp = false;
        //        dlgFont.ShowEffects = true;
        //        dlgFont.ShowColor = false;
        //        dlgFont.ShowApply = false;
        //        dlgFont.FixedPitchOnly = false;

        //        if (dlgFont.ShowDialog() == DialogResult.OK)
        //        {
        //            return dlgFont.Font;
        //        }
        //        else
        //        {
        //            return initFont;
        //        }
        //    }
        //}
        //private string GetImagePath()
        //{
        //    OpenFileDialog dlgOpen = new OpenFileDialog();
        //    dlgOpen.Multiselect = false;
        //    dlgOpen.ShowReadOnly = false;
        //    dlgOpen.RestoreDirectory = true;
        //    dlgOpen.ReadOnlyChecked = false;
        //    dlgOpen.Filter = "Images|*.png;*.bmp;*.jpg;*.jpeg;*.gif;*.tif;*.tiff,*.wmf;*.emf";
        //    if (dlgOpen.ShowDialog() == DialogResult.OK)
        //    {
        //        return dlgOpen.FileName;
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}

        #region CharStyle
        private void btnB2_Click(object sender, EventArgs e)
        {
            if (txtTaskDes.SelectionCharStyle.Bold == true)
            {
                btnB2.Checked = false;
                ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                cs.Bold = false;
                txtTaskDes.SelectionCharStyle = cs;
                cs = null;
            }
            else
            {
                btnB2.Checked = true;
                ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                cs.Bold = true;
                txtTaskDes.SelectionCharStyle = cs;
                cs = null;
            }
        }

        private void btnI2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaskDes.SelectionCharStyle.Italic == true)
                {
                    btnI2.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Italic = false;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnI2.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Italic = true;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnU2_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTaskDes.SelectionCharStyle.Underline == true)
                {
                    btnU2.Checked = false;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Underline = false;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
                else
                {
                    btnU2.Checked = true;
                    ExtendedRichTextBox.CharStyle cs = txtTaskDes.SelectionCharStyle;
                    cs.Underline = true;
                    txtTaskDes.SelectionCharStyle = cs;
                    cs = null;
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion

        #region Align
        private void btnLeft2_Click(object sender, EventArgs e)
        {
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Left;
            btnLeft2.Checked = true;
            btnRight2.Checked = false;
            btnCenter2.Checked = false;
        }

        private void btnCenter2_Click(object sender, EventArgs e)
        {
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Center;
            btnLeft2.Checked = false;
            btnRight2.Checked = false;
            btnCenter2.Checked = true;
        }

        private void btnRight2_Click(object sender, EventArgs e)
        {
            txtTaskDes.SelectionAlignment = ExtendedRichTextBox.RichTextAlign.Right;
            btnLeft2.Checked = false;
            btnRight2.Checked = true;
            btnCenter2.Checked = false;
        }
        #endregion

        private void txtTaskDes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                #region Aglin
                if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Left)
                {
                    btnLeft2.Checked = true;
                    btnCenter2.Checked = false;
                    btnRight2.Checked = false;
                }
                else if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Center)
                {
                    btnLeft2.Checked = false;
                    btnCenter2.Checked = true;
                    btnRight2.Checked = false;
                }
                else if (txtTaskDes.SelectionAlignment == ExtendedRichTextBox.RichTextAlign.Right)
                {
                    btnLeft2.Checked = false;
                    btnCenter2.Checked = false;
                    btnRight2.Checked = true;
                }
                else
                {
                    btnLeft2.Checked = true;
                    btnCenter2.Checked = false;
                    btnRight2.Checked = false;
                }
                #endregion

                #region Font
                FontFamily ff = new FontFamily("Tahoma");
                if (ff.IsStyleAvailable(FontStyle.Bold) == true)
                {
                    btnB2.Enabled = true;
                    btnB2.Checked = txtTaskDes.SelectionCharStyle.Bold;
                }
                else
                {
                    btnB2.Enabled = false;
                    btnB2.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Italic) == true)
                {
                    btnI2.Enabled = true;
                    btnI2.Checked = txtTaskDes.SelectionCharStyle.Italic;
                }
                else
                {
                    btnI2.Enabled = false;
                    btnI2.Checked = false;
                }

                if (ff.IsStyleAvailable(FontStyle.Underline) == true)
                {
                    btnU2.Enabled = true;
                    btnU2.Checked = txtTaskDes.SelectionCharStyle.Underline;
                }
                else
                {
                    btnU2.Enabled = false;
                    btnU2.Checked = false;
                }

                ff.Dispose();
                #endregion

                //txtTaskDes.UpdateObjects();
            }
            catch (Exception)
            { }
        }

        private void txtTaskDes_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.LinkText);
            }
            catch (Exception)
            {
            }
        }

        private void txtTaskDes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (txtTaskDes.SelectionType == RichTextBoxSelectionTypes.Object ||
                    txtTaskDes.SelectionType == RichTextBoxSelectionTypes.MultiObject)
                {
                    MessageBox.Show(Convert.ToString(txtTaskDes.SelectedObject().sizel.Width));
                }
            }
        }

        private void btnAddPicture2_Click(object sender, EventArgs e)
        {
            try
            {
                string imgPath = GetImagePath(); //Lấy đường dẫn file ảnh

                Bitmap BitmapPic = new Bitmap(imgPath); //Tạo một Bitmap ><

                Clipboard.SetDataObject(BitmapPic); //Đặt đối tượng dử liệu vào Clipboard

                DataFormats.Format FormatPic = DataFormats.GetFormat(DataFormats.Bitmap);//Lấy định dạng của hình

                if (txtTaskDes.CanPaste(FormatPic)) //Nếu có thể chèn vào RTBox
                {
                    txtTaskDes.Paste(FormatPic); //Chèn hình vào
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnColor2_Click(object sender, EventArgs e)
        {
            try
            {
                txtTaskDes.SelectionColor = GetColor(txtTaskDes.SelectionColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnHighLight2_Click(object sender, EventArgs e)
        {
            try
            {
                txtTaskDes.SelectionBackColor = GetColor(txtTaskDes.SelectionBackColor);
            }
            catch (Exception)
            {
            }
        }

        private void btnUndo2_Click(object sender, EventArgs e)
        {
            txtTaskDes.Undo();
        }

        private void btnRedo2_Click(object sender, EventArgs e)
        {
            txtTaskDes.Redo();
        }

        private void cboFontSize2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!cboFontSize2.Focused) return;
                txtTaskDes.SelectionFont = new Font(txtTaskDes.Font.Name, Convert.ToInt32(cboFontSize2.Text), txtTaskDes.SelectionFont.Style);
            }
            catch (Exception)
            {
            }
        }

        private void cboFontSize2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    txtTaskDes.SelectionFont = new Font(txtTaskDes.Font.Name, Convert.ToInt32(cboFontSize2.Text));
                    txtTaskDes.Focus();
                }
                catch (Exception)
                {
                }
            }
        }

        private void cboFontSize2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 ||
                e.KeyCode == Keys.D3 || e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 ||
                e.KeyCode == Keys.D6 || e.KeyCode == Keys.D7 || e.KeyCode == Keys.D8 ||
                e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad0 || e.KeyCode == Keys.NumPad1 ||
                e.KeyCode == Keys.NumPad2 || e.KeyCode == Keys.NumPad3 || e.KeyCode == Keys.NumPad4 ||
                e.KeyCode == Keys.NumPad5 || e.KeyCode == Keys.NumPad6 || e.KeyCode == Keys.NumPad7 ||
                e.KeyCode == Keys.NumPad8 || e.KeyCode == Keys.NumPad9 || e.KeyCode == Keys.Back ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Delete)
            {
                //allow key
            }
            else
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion
    }
}
