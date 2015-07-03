using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace Reminiscent
{
    public partial class UC_Schedule : UserControl
    {
        public UC_Schedule()
        {
            InitializeComponent();
        }
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        public static string strScheduleMode = "";
        public static int iID = -1;
        int iPageNumber = 0;
        int iPageCount = 0;
        int iIndex = -1;
        string strPageName = "";
        string strTime = "Time";
        string strWork = "Work";
        bool bListSelected = false;
        int iYList = 340;

        #region Page Load
        private void UC_Schedule_Load(object sender, EventArgs e)
        {
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
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    colID.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colProject.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colAbstract.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    colPercent.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);

                    btnDetail.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnNfP.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnNew.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnEdit.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    btnDelete.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);

                    strPageName = frmMain.Decryption(node.SelectSingleNode("lbl").InnerText);

                    strTime = frmMain.Decryption(node.SelectSingleNode("str1").InnerText);
                    strWork = frmMain.Decryption(node.SelectSingleNode("str2").InnerText);
                    break;
                }
            }
            #endregion

            iPageNumber = 1;
            //btnDetail.Enabled = false;
            //btnNfP.Enabled = false;
            //btnEdit.Enabled = false;
            //btnDelete.Enabled = false;
            LoadListView();

            switch (Environment.OSVersion.Version.Major)
            {
                case 3:
                    //Windows NT 3.51
                    PanelChart.Location = new Point(524, 24);
                    iYList = 346;
                    PanelChart.Size = new Size(400, iYList);
                    break;
                case 4:
                    //Windows NT 4.0
                    PanelChart.Location = new Point(524, 24);
                    iYList = 346;
                    PanelChart.Size = new Size(400, iYList);
                    break;
                case 5:
                    //if (Environment.OSVersion.Version.Minor == 0)
                        //Windows 2000
                        //PanelChart.Location = new Point(524, 24);
                    //else
                        //Windows XP
                        PanelChart.Location = new Point(524, 24);
                        iYList = 340;
                        PanelChart.Size = new Size(400, iYList);
                    break;
                case 6:
                    //if (Environment.OSVersion.Version.Minor == 0)
                        //Windows Vista
                        //PanelChart.Location = new Point(524, 28);
                    //else 
                    if (Environment.OSVersion.Version.Minor == 1)
                    {
                        //Windows 7
                        PanelChart.Location = new Point(524, 28);
                        iYList = 340;
                        PanelChart.Size = new Size(400, iYList);
                    }
                    else if (Environment.OSVersion.Version.Minor == 2)
                    {
                        //Windows 8
                        PanelChart.Location = new Point(524, 28);
                        iYList = 340;
                        PanelChart.Size = new Size(400, iYList);
                    }
                    break;
                default:
                    PanelChart.Location = new Point(524, 28);
                    iYList = 340;
                    PanelChart.Size = new Size(400, iYList);
                    break;
            }
        }
        #endregion

        #region Load List View
        internal void LoadListView()
        {
            lstSchedule.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");

                if(Tasks.Count % 20 == 0)
                    iPageCount = Tasks.Count / 20;
                else
                    iPageCount = Tasks.Count / 20 + 1;

                lblPage.Text = strPageName + iPageNumber + "/" + iPageCount;

                for (int i = (iPageNumber - 1) * 20; i < Tasks.Count; i++)
                {
                    try
                    {
                        if (lstSchedule.Items.Count == 20)
                            break;
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = frmMain.Decryption(Tasks[i].ChildNodes[0].InnerText);
                        lvi.SubItems.Add(frmMain.Decryption(Tasks[i].ChildNodes[1].InnerText));
                        lvi.SubItems.Add(frmMain.Decryption(Tasks[i].ChildNodes[5].InnerText));
                        
                        DateTime dtStart = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateStart").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture);
                        DateTime dtEnd = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateEnd").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture);
                        TimeSpan Date100 = dtEnd - dtStart;
                        TimeSpan DateNow = DateTime.Now - dtStart;
                        float fPOW = 0;
                        if (DateNow.Days < Date100.Days)
                            fPOW = float.Parse(DateNow.Days.ToString()) * 100 / float.Parse(Date100.Days.ToString());
                        else
                            fPOW = 100;
                        float fPOC = float.Parse(frmMain.Decryption(Tasks[i].ChildNodes[4].InnerText));
                        lvi.SubItems.Add("Time: " + Math.Round(fPOW, 2) + "%                    Complete:" + Math.Round(fPOC, 2) + " %");

                        lstSchedule.Items.Add(lvi);

                        if (fPOW == 100 && fPOC < 100)
                        {
                            lvi.BackColor = Color.MediumSeaGreen;
                            //lvi.ForeColor = Color.White;
                        }
                        else if (fPOW > 60 && fPOC < fPOW)
                            lvi.BackColor = Color.LemonChiffon;
                        //else if (fPOW > 80 && fPOC < 80)
                        //    lvi.BackColor = Color.Orange;
                        //else if (fPOW == 100 && fPOC < 100)
                        //    lvi.BackColor = Color.Tomato;
                    }
                    catch
                    {
                        File.Delete(Application.StartupPath + "/Data/Schedule.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/Schedule.xml", Application.StartupPath + "/Data/Schedule.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/Schedule.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Schedule.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("TasksList");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Schedule database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
                PanelChart.Invalidate();
            }
        }
        #endregion

        #region Click
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");
                if (Tasks.Count > 0)
                {
                    if (bListSelected == true)
                    {
                        foreach (ListViewItem lvi in lstSchedule.SelectedItems)
                        {
                            if (lvi.Text != "")
                            {
                                strScheduleMode = "D";
                                //btnDetail.Enabled = false;
                                //btnNfP.Enabled = false;
                                //btnEdit.Enabled = false;
                                //btnDelete.Enabled = false;
                                iIndex = -1;
                                PanelChart.Invalidate();
                                lstSchedule.SelectedItems.Clear();
                                NewSchedule ns = new NewSchedule();
                                ns.ShowDialog();
                                PanelChart.Invalidate();
                            }
                        }
                    }
                }
            }
        }

        private void btnNfP_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");
                if (Tasks.Count > 0)
                {
                    if (bListSelected == true)
                    {
                        strScheduleMode = "NFP";
                        //btnDetail.Enabled = false;
                        //btnNfP.Enabled = false;
                        //btnEdit.Enabled = false;
                        //btnDelete.Enabled = false;
                        iIndex = -1;
                        PanelChart.Invalidate();
                        lstSchedule.SelectedItems.Clear();
                        NewSchedule ns = new NewSchedule();
                        ns.ShowDialog();
                        PanelChart.Invalidate();
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            strScheduleMode = "N";
            iIndex = -1;
            PanelChart.Invalidate();
            lstSchedule.SelectedItems.Clear();
            NewSchedule ns = new NewSchedule();
            ns.ShowDialog();
            PanelChart.Invalidate();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");
                if (Tasks.Count > 0)
                {
                    if (bListSelected == true)
                    {
                        strScheduleMode = "E";
                        //btnDetail.Enabled = false;
                        //btnNfP.Enabled = false;
                        //btnEdit.Enabled = false;
                        //btnDelete.Enabled = false;
                        iIndex = -1;
                        PanelChart.Invalidate();
                        lstSchedule.SelectedItems.Clear();
                        NewSchedule ns = new NewSchedule();
                        ns.ShowDialog();
                        PanelChart.Invalidate();
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");
                if (Tasks.Count > 0)
                {
                    if (bListSelected == true)
                    {
                        //btnDetail.Enabled = false;
                        //btnNfP.Enabled = false;
                        //btnEdit.Enabled = false;
                        //btnDelete.Enabled = false;
                        DialogResult dr = new DialogResult();
                        dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dr == DialogResult.Yes)
                        {
                            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
                            {
                                //XmlDocument xmlDoc = new XmlDocument();
                                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");

                                int iNOChild = 0;
                                foreach (XmlNode node in xmlDoc.SelectNodes("TasksList/Tasks"))
                                {
                                    string strtest = frmMain.Decryption(node.SelectSingleNode("ID").InnerText);
                                    if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == iID.ToString())
                                    {
                                        if (node.LastChild.Name == "ChildTask")
                                        {
                                            iNOChild = node.SelectSingleNode("ChildTask").ChildNodes.Count;
                                        }
                                        node.ParentNode.RemoveChild(node);
                                    }
                                }
                                xmlDoc.Save(Application.StartupPath + "/Data/Schedule.xml");
                                if (File.Exists(Application.StartupPath + "/Data/Schedule/" + iID + ".rtf"))
                                {
                                    File.Delete(Application.StartupPath + "/Data/Schedule/" + iID + ".rtf");
                                }
                                for (int i = 0; i <= iNOChild; i++)
                                {
                                    if (File.Exists(Application.StartupPath + "/Data/Schedule/" + iID + "-" + i + ".rtf"))
                                    {
                                        File.Delete(Application.StartupPath + "/Data/Schedule/" + iID + "-" + i + ".rtf");
                                    }
                                }
                                LoadListView();
                                PanelChart.Invalidate();
                            }
                        }
                    }
                }
            }
        }
        #endregion
        
        #region Selected Index Changed
        private void lstSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSchedule.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstSchedule.SelectedItems)
                {
                    if (lvi.Text != "")
                    {
                        frmMain.iPage = lvi.Index;
                        iID = Convert.ToInt32(lvi.Text);
                        iIndex = lvi.Index;
                        PanelChart.Invalidate();
                        break;
                    }
                    else
                    {
                        lstSchedule.SelectedItems.Clear();
                        break;
                    }
                }
                bListSelected = true;
                //btnDetail.Enabled = true;
                //btnNfP.Enabled = true;
                //btnEdit.Enabled = true;
                //btnDelete.Enabled = true;
            }
            else
            {
                iIndex = -1;
                PanelChart.Invalidate();
                bListSelected = false;
                //btnDetail.Enabled = false;
                //btnNfP.Enabled = false;
                //btnEdit.Enabled = false;
                //btnDelete.Enabled = false;
            }
        }
        #endregion

        #region Hover
        private void btnDetail_MouseMove(object sender, MouseEventArgs e)
        {
            btnDetail.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnNfP_MouseMove(object sender, MouseEventArgs e)
        {
            btnNfP.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnNew_MouseMove(object sender, MouseEventArgs e)
        {
            btnNew.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnEdit_MouseMove(object sender, MouseEventArgs e)
        {
            btnEdit.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDelete_MouseMove(object sender, MouseEventArgs e)
        {
            btnDelete.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnDetail_MouseLeave(object sender, EventArgs e)
        {
            btnDetail.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnNfP_MouseLeave(object sender, EventArgs e)
        {
            btnNfP.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnNew.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnEdit_MouseLeave(object sender, EventArgs e)
        {
            btnEdit.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
        #endregion

        #region Chart
        private void PanelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            int i0 = 0;
            int i100 = colPercent.Width;
            int iY = 0;
            int iYline = 0;
            if(lstSchedule.Items.Count < 1)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = "";
                lstSchedule.Items.Add(lvi);
            }
            int iListHeight = lstSchedule.GetItemRect(0).Height;

            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");

                
                i0 = 0;
                i100 = colPercent.Width;
                iY = 0;
                iYline = 0;

                for (int i = (iPageNumber - 1) * 20; i < Tasks.Count; i++)
                {
                    try
                    {
                        if (i == (iPageNumber - 1) * 20 + 20)
                            break;
                        DateTime dtStart = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateStart").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture);
                        DateTime dtEnd = DateTime.ParseExact(frmMain.Decryption(Tasks[i].SelectSingleNode("DateEnd").InnerText), "d/M/yyyy", CultureInfo.InvariantCulture);
                        TimeSpan Date100 = dtEnd - dtStart;
                        TimeSpan DateNow = DateTime.Now - dtStart;
                        float fPOW = 0;
                        if (DateNow.Days < Date100.Days)
                            fPOW = float.Parse(DateNow.Days.ToString()) * 100 / float.Parse(Date100.Days.ToString());
                        else
                            fPOW = 100;
                        float fPOC = float.Parse(frmMain.Decryption(Tasks[i].ChildNodes[4].InnerText));

                        if (i == iIndex || (iPageNumber > 1 && i % 10 == iIndex))
                            gfx.DrawLine(new Pen(SystemColors.Highlight, iListHeight), i0, iY + 8, i100, iY + 8);
                        else
                        {
                            if (fPOW == 100 && fPOC < 100)
                                gfx.DrawLine(new Pen(Color.MediumSeaGreen, iListHeight), i0, iY + 8, i100, iY + 8);
                            else if (fPOW > 60 && fPOC < fPOW)
                                gfx.DrawLine(new Pen(Color.LemonChiffon, iListHeight), i0, iY + 8, i100, iY + 8);
                            //else if (fPOW > 80 && fPOC < 80)
                            //    gfx.DrawLine(new Pen(Color.Orange, iListHeight), i0, iY + 8, i100, iY + 8);
                            //else if (fPOW == 100 && fPOC < 100)
                            //    gfx.DrawLine(new Pen(Color.Tomato, iListHeight), i0, iY + 8, i100, iY + 8);
                            
                        }

                        gfx.DrawLine(new Pen(Color.Gainsboro, iListHeight - 3), i0 + 1, iY + iListHeight / 2 + 1, i100 / 2 - 1, iY + iListHeight / 2 + 1);
                        gfx.DrawLine(new Pen(Color.Gainsboro, iListHeight - 3), i100 / 2 + 2, iY + iListHeight / 2 + 1, i100 - 1, iY + iListHeight / 2 + 1);

                        int iC1 = Convert.ToInt32(fPOW) * (i100 / 2 -1) / 100;
                        int iC2 = Convert.ToInt32(fPOC) * (i100 / 2 - 1) / 100 + i100 / 2 + 2;
                        //gfx.DrawLine(new Pen(Color.LightGreen, 6), i0 + 1, iY + 5, iC1 - 1, iY + 5);
                        //gfx.DrawLine(new Pen(Color.LightGreen, 6), i0 + 1, iY + 13, iC2 - 1, iY + 13);

                        if (fPOW < 33)
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC1, 0), Color.SeaGreen, Color.SpringGreen), iListHeight - 3), i0 + 1, iY + iListHeight / 2 + 1, iC1, iY + iListHeight / 2 + 1);
                        else if (fPOW >= 33 && fPOW < 66)
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC1, 0), Color.Orange, Color.Yellow), iListHeight - 3), i0 + 1, iY + iListHeight / 2 + 1, iC1, iY + iListHeight / 2 + 1);
                        else
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC1, 0), Color.DeepSkyBlue, Color.Cyan), iListHeight - 3), i0 + 1, iY + iListHeight / 2 + 1, iC1, iY + iListHeight / 2 + 1);

                        if (i == iIndex)// || (fPOW == 100 && fPOC < 100))
                            gfx.DrawString(Math.Round(fPOW, 2).ToString() + "% " + strTime, new Font("Arial", 8.0f, FontStyle.Bold), new SolidBrush(Color.White), new PointF(i100 / 4 - 20, iY + 2));
                        else
                            gfx.DrawString(Math.Round(fPOW, 2).ToString() + "% " + strTime, new Font("Arial", 8.0f, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(i100 / 4 - 20, iY + 2));

                        if (fPOC < 33)
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC2 / 2 + 1, 0), Color.SeaGreen, Color.SpringGreen), iListHeight - 3), i100 / 2 + 2, iY + iListHeight / 2 + 1, iC2, iY + iListHeight / 2 + 1);
                        else if (fPOC >= 33 && fPOC < 66)
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC2 / 2 + 1, 0), Color.Orange, Color.Yellow), iListHeight - 3), i100 / 2 + 2, iY + iListHeight / 2 + 1, iC2, iY + iListHeight / 2 + 1);
                        else
                            gfx.DrawLine(new Pen(new LinearGradientBrush(new Point(0, 0), new Point(iC2 / 2 + 1, 0), Color.DeepSkyBlue, Color.Cyan), iListHeight - 3), i100 / 2 + 2, iY + iListHeight / 2 + 1, iC2, iY + iListHeight / 2 + 1);

                        if (i == iIndex)// || (fPOW == 100 && fPOC < 100))
                            gfx.DrawString(Math.Round(fPOC, 2).ToString() + "% " + strWork, new Font("Arial", 8.0f, FontStyle.Bold), new SolidBrush(Color.White), new PointF(i100 * 3 / 4 - 20, iY + 2));
                        else
                            gfx.DrawString(Math.Round(fPOC, 2).ToString() + "% " + strWork, new Font("Arial", 8.0f, FontStyle.Bold), new SolidBrush(Color.Black), new PointF(i100 * 3 / 4 - 20, iY + 2));

                        iY += iListHeight;
                    }
                    catch
                    {

                    }
                }
            }

            for (int j = 0; j < 26; j++)
            {
                gfx.DrawLine(new Pen(Color.FromArgb(240, 240, 240), 1), i0, iYline, i100, iYline);
                iYline += iListHeight;
            }
        }
        #endregion

        #region Column Width Changing
        private void lstSchedule_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            int iY = 0;
            if (colID.Width + colProject.Width + colAbstract.Width + colPercent.Width > lstSchedule.Width)
            {
                if (lstSchedule.Items.Count < 1)
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = "";
                    lstSchedule.Items.Add(lvi);
                }
                int iListHeight = lstSchedule.GetItemRect(0).Height;
                iY = iYList - iListHeight;
            }
            else
                iY = iYList;
            PanelChart.Location = new Point(lstSchedule.Location.X + colID.Width + colProject.Width + colAbstract.Width + 3, 28);
            PanelChart.Size = new Size(colPercent.Width - 2, iY);
            //PanelChart.Size = new Size(lstSchedule.Width - colID.Width - colProject.Width - colAbstract.Width - 4, iY);
            PanelChart.Invalidate();
        }
        #endregion

        #region Page Change
        private void lblNext_Click(object sender, EventArgs e)
        {
            PageDown();
        }

        private void lblEnd_Click(object sender, EventArgs e)
        {
            iPageNumber = iPageCount;

            PageChange();
        }

        private void lblPre_Click(object sender, EventArgs e)
        {
            PageUp();
        }

        private void lblStart_Click(object sender, EventArgs e)
        {
            iPageNumber = 1;

            PageChange();
        }

        void PageChange()
        {
            btnDetail.Enabled = false;
            btnNfP.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            iIndex = -1;
            lblPage.Text = strPageName + iPageNumber + "/" + iPageCount;
            LoadListView();
            PanelChart.Invalidate();
        }

        internal void PageUp()
        {
            if (iPageNumber == 1)
                iPageNumber = iPageCount;
            else
                iPageNumber--;

            PageChange();
        }

        internal void PageDown()
        {
            if (iPageNumber == iPageCount)
                iPageNumber = 1;
            else
                iPageNumber++;

            PageChange();
        }
        #endregion

        #region Hover
        private void lblNext_MouseMove(object sender, MouseEventArgs e)
        {
            lblNext.ForeColor = Color.Gold;
        }

        private void lblEnd_MouseMove(object sender, MouseEventArgs e)
        {
            lblEnd.ForeColor = Color.Gold;
        }

        private void lblPre_MouseMove(object sender, MouseEventArgs e)
        {
            lblPre.ForeColor = Color.Gold;
        }

        private void lblStart_MouseMove(object sender, MouseEventArgs e)
        {
            lblStart.ForeColor = Color.Gold;
        }

        private void lblNext_MouseLeave(object sender, EventArgs e)
        {
            lblNext.ForeColor = Color.Black;
        }

        private void lblEnd_MouseLeave(object sender, EventArgs e)
        {
            lblEnd.ForeColor = Color.Black;
        }

        private void lblPre_MouseLeave(object sender, EventArgs e)
        {
            lblPre.ForeColor = Color.Black;
        }

        private void lblStart_MouseLeave(object sender, EventArgs e)
        {
            lblStart.ForeColor = Color.Black;
        }
        #endregion

        #region Down
        private void lblNext_MouseDown(object sender, MouseEventArgs e)
        {
            lblNext.ForeColor = Color.Red;
        }

        private void lblEnd_MouseDown(object sender, MouseEventArgs e)
        {
            lblEnd.ForeColor = Color.Red;
        }

        private void lblPre_MouseDown(object sender, MouseEventArgs e)
        {
            lblPre.ForeColor = Color.Red;
        }

        private void lblStart_MouseDown(object sender, MouseEventArgs e)
        {
            lblStart.ForeColor = Color.Red;
        }

        private void lblNext_MouseUp(object sender, MouseEventArgs e)
        {
            lblNext.ForeColor = Color.Black;
        }

        private void lblEnd_MouseUp(object sender, MouseEventArgs e)
        {
            lblEnd.ForeColor = Color.Black;
        }

        private void lblPre_MouseUp(object sender, MouseEventArgs e)
        {
            lblPre.ForeColor = Color.Black;
        }

        private void lblStart_MouseUp(object sender, MouseEventArgs e)
        {
            lblStart.ForeColor = Color.Black;
        }
        #endregion

        internal void Search(string strSearch, string strBy)
        {
            if (File.Exists(Application.StartupPath + "/Data/Schedule.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Schedule.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList Tasks = root.GetElementsByTagName("Tasks");

                for (int i = frmMain.iSearch; i < Tasks.Count; i++)
                {
                    try
                    {
                        if (frmMain.iSearch >= Tasks.Count)
                            frmMain.iSearch = 0;

                        if (strBy == "Project")
                        {
                            if (frmMain.Decryption(Tasks[i].ChildNodes[1].InnerText).ToLower().Contains(strSearch.ToLower()))
                            {
                                lstSchedule.Focus();
                                int iListView = 0;

                                if(i < 20)
                                    iPageNumber = 1;
                                else
                                    iPageNumber = i / 10;

                                PageChange();

                                if (iPageNumber == 1)
                                {
                                    iListView = i;
                                }
                                else if (iPageNumber > 1)
                                {
                                    iListView = i % 10;
                                }

                                lstSchedule.EnsureVisible(iListView);
                                lstSchedule.Items[iListView].Selected = true;
                                if (i == Tasks.Count - 1)
                                {
                                    frmMain.iSearch = 0;
                                    i = 0;
                                }
                                else
                                    frmMain.iSearch = i + 1;
                                break;
                            }
                            if (i == Tasks.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                                break;
                            }
                        }
                        else if (strBy == "Abstract")
                        {
                            if (frmMain.Decryption(Tasks[i].ChildNodes[5].InnerText).ToLower().Contains(strSearch.ToLower()))
                            {
                                lstSchedule.Focus();
                                int iListView = 0;

                                if (i < 20)
                                    iPageNumber = 1;
                                else
                                    iPageNumber = i / 10;

                                PageChange();

                                if (iPageNumber == 1)
                                {
                                    iListView = i;
                                }
                                else if (iPageNumber > 1)
                                {
                                    iListView = i % 10;
                                }

                                lstSchedule.EnsureVisible(iListView);
                                lstSchedule.Items[iListView].Selected = true;
                                if (i == Tasks.Count - 1)
                                {
                                    frmMain.iSearch = 0;
                                    i = 0;
                                }
                                else
                                    frmMain.iSearch = i + 1;
                                break;
                            }
                            if (i == Tasks.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                                break;
                            }
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void lstSchedule_DoubleClick(object sender, EventArgs e)
        {
            btnDetail_Click(sender, e);
        }

        private void PanelChart_Click(object sender, EventArgs e)
        {
            if (lstSchedule.Items.Count > 0)
            {
                int iListHeight = lstSchedule.GetItemRect(0).Height;

                Point point = PanelChart.PointToClient(Cursor.Position);
                for (int i = 1; i <= 20; i++)
                {
                    if (i - 1 >= lstSchedule.Items.Count)
                    {
                        iIndex = -1;
                        lstSchedule.SelectedItems.Clear();
                        PanelChart.Invalidate();
                        bListSelected = false;
                        //btnDetail.Enabled = false;
                        //btnNfP.Enabled = false;
                        //btnEdit.Enabled = false;
                        //btnDelete.Enabled = false;
                        break;
                    }
                    else
                    {
                        if (point.Y > iListHeight * (i - 1) && point.Y <= iListHeight * i)
                        {
                            frmMain.iPage = i - 1;
                            iID = i - 1;
                            iIndex = i - 1;
                            lstSchedule.Focus();
                            lstSchedule.EnsureVisible(i - 1);
                            lstSchedule.Items[i - 1].Selected = true;
                            bListSelected = true;
                            break;
                        }
                    }
                }
            }
        }

        private void PanelChart_DoubleClick(object sender, EventArgs e)
        {
            if(lstSchedule.SelectedItems.Count > 0)
                btnDetail_Click(sender, e);
        }
    }
}
