using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Runtime.InteropServices;//DllImportAttribute
using System.Reflection;

namespace Reminiscent
{
    public partial class frmTaskOfTheDay : Form
    {
        public frmTaskOfTheDay()
        {
            InitializeComponent();
        }
        //Moveable with Panel
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string strRecurringID = "";
        public static string strRecurringName = "";
        public static string strRecurringDes = "";
        public static string strRecurringDate = "";
        public static string strRecurringTime = "";
        public static string strRecurringRepeat = "";

        private void frmTaskOfTheDay_Load(object sender, EventArgs e)
        {
            //lblTitle.Text = "Task of the day: " + DateTime.Now.Date.ToShortDateString();

            this.Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Size.Width, 0);
            this.TopMost = true; // Giữ form nằm trên tất cả các cửa sổ

            panleTitle.BackColor = Color.FromArgb(248, 247, 182);

            btnClose.BackColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.BorderColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(248, 247, 182);
            btnClose.FlatAppearance.MouseDownBackColor = Color.FromArgb(248, 247, 182);
            LoadListView();

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
                    lblTitle.Text = frmMain.Decryption(node.SelectSingleNode("lbl").InnerText) + DateTime.Now.Date.ToShortDateString();

                    lvwTaskOfTheDay.Columns[0].Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    lvwTaskOfTheDay.Columns[1].Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    lvwTaskOfTheDay.Columns[3].Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);

                    refeshToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    onTopToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    closeToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item3").InnerText);
                    break;
                }
            }
            #endregion
        }

        //Remove Title and Control Box\\
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~0xC00000; //WS_CAPTION;  
                return cp;
            }
        }

        //Moveable with Panel\\
        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void LoadListView()
        {
            UC_Recurring.Sort();

            lvwTaskOfTheDay.Clear();

            ColumnHeader name = new ColumnHeader();
            name.Text = "Name";
            name.Width = 130;

            ColumnHeader des = new ColumnHeader();
            des.Text = "Description";
            des.Width = 300;

            ColumnHeader date = new ColumnHeader();
            date.Text = "Date";
            date.Width = 0;

            ColumnHeader time = new ColumnHeader();
            time.Text = "Time";
            time.Width = 66;

            ColumnHeader repeat = new ColumnHeader();
            repeat.Text = "Repeat";
            repeat.Width = 0;

            lvwTaskOfTheDay.Columns.Add(name);
            lvwTaskOfTheDay.Columns.Add(des);
            lvwTaskOfTheDay.Columns.Add(date);
            lvwTaskOfTheDay.Columns.Add(time);
            lvwTaskOfTheDay.Columns.Add(repeat);

            if (File.Exists(Application.StartupPath + "/Data/Recurring.xml"))
            {
                try
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(Application.StartupPath + "/Data/Recurring.xml");
                    XmlElement root = xmlDoc.DocumentElement;
                    XmlNodeList TaskList = root.GetElementsByTagName("TaskList");

                    string strRecurringDate = "";
                    int iDay, iMonth, iYear;

                    string strDateNow = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                    for (int i = 0; i < TaskList.Count; i++)
                    {
                        strRecurringDate = frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText);

                        iDay = int.Parse(strRecurringDate.Substring(0, strRecurringDate.IndexOf("/")));
                        iMonth = int.Parse(strRecurringDate.Substring(strRecurringDate.IndexOf("/") + 1, strRecurringDate.LastIndexOf("/") - 3));
                        iYear = int.Parse(strRecurringDate.Substring(strRecurringDate.LastIndexOf("/") + 1));

                        strRecurringDate = iDay.ToString() + "/" + iMonth.ToString() + "/" + iYear.ToString();

                        if (strRecurringDate == strDateNow)
                        {
                            if (TaskList[i].ChildNodes.Count > 4) // Nhiều công việc chung một thời điểm
                            {
                                for (int j = 3; j < TaskList[i].ChildNodes.Count; j++)
                                {
                                    ListViewItem lvi = new ListViewItem();

                                    lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                                    lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[0].InnerText); // Name
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[1].InnerText)); // Description
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                                    lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[j].ChildNodes[2].InnerText)); // Repeat

                                    lvwTaskOfTheDay.Items.Add(lvi);
                                }
                            }
                            else
                            {
                                ListViewItem lvi = new ListViewItem();

                                lvi.Tag = frmMain.Decryption(TaskList[i].ChildNodes[0].InnerText); // ID
                                lvi.Text = frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[0].InnerText); // Name
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[1].InnerText)); // Description
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[1].InnerText)); // Date
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[2].InnerText)); // Time
                                lvi.SubItems.Add(frmMain.Decryption(TaskList[i].ChildNodes[3].ChildNodes[2].InnerText)); // Repeat

                                lvwTaskOfTheDay.Items.Add(lvi);
                            }
                        }
                    }
                }
                catch
                {
                    File.Delete(Application.StartupPath + "/Data/Recurring.xml.bk");
                    File.Copy(Application.StartupPath + "/Data/Recurring.xml", Application.StartupPath + "/Data/Recurring.xml.bk");
                    File.Delete(Application.StartupPath + "/Data/Recurring.xml");
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Recurring.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    //Create XML
                    writer.WriteStartDocument();
                    //Create Root
                    writer.WriteStartElement("TaskList");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();

                    MessageBox.Show("Your Recurring database have been corrupted! \n\n It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //private void newToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    UC_Recurring.strTOTD = "Yes";
        //    frmNewRecurring nr = new frmNewRecurring();
        //    nr.ShowDialog();
        //    LoadListView();
        //}

        //private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    #region Xóa một nhắc nhở

        //    if (lvwTaskOfTheDay.SelectedItems.Count > 0)
        //    {
        //        foreach (ListViewItem lvi in lvwTaskOfTheDay.SelectedItems)
        //        {
        //            strRecurringID = lvi.Tag.ToString();
        //            strRecurringName = lvi.Text;
        //            strRecurringDes = lvi.SubItems[1].Text;
        //            strRecurringRepeat = lvi.SubItems[4].Text;
        //        }

        //        DialogResult dr = new DialogResult();
        //        dr = MessageBox.Show("Are you sure want to delete item '" + strRecurringName + "'", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        //        if (dr == DialogResult.Yes)
        //        {
        //            XmlDocument doc = new XmlDocument();
        //            doc.Load("Recurring.xml");

        //            foreach (XmlNode nodeTaskList in doc.SelectNodes("Recurring/TaskList"))
        //            {
        //                if (nodeTaskList.SelectSingleNode("ID").InnerText == strRecurringID)
        //                {
        //                    if (nodeTaskList.ChildNodes.Count > 4) // Nhiều công việc cùng một thời điểm
        //                    {
        //                        for (int i = 3; i < nodeTaskList.ChildNodes.Count; i++)
        //                        {
        //                            if (nodeTaskList.ChildNodes[i].ChildNodes[0].InnerText == strRecurringName && nodeTaskList.ChildNodes[i].ChildNodes[1].InnerText == strRecurringDes && nodeTaskList.ChildNodes[i].ChildNodes[2].InnerText == strRecurringRepeat)
        //                            {
        //                                nodeTaskList.ChildNodes[i].ParentNode.RemoveChild(nodeTaskList.ChildNodes[i]);
        //                                i--;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        nodeTaskList.ParentNode.RemoveChild(nodeTaskList);
        //                    }
        //                }
        //            }

        //            doc.Save("Recurring.xml");
        //            MessageBox.Show("Delete successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            LoadListView();
        //        }

        //    }
        //    else
        //        MessageBox.Show("No item selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    #endregion
        //}

        private void onTopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (onTopToolStripMenuItem.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadListView();
        }

        //private void editToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (lvwTaskOfTheDay.SelectedItems.Count > 0)
        //    {
        //        foreach (ListViewItem lvi in lvwTaskOfTheDay.SelectedItems)
        //        {
        //            strRecurringID = lvi.Tag.ToString();
        //            strRecurringName = lvi.Text;
        //            strRecurringDes = lvi.SubItems[1].Text;
        //            strRecurringDate = lvi.SubItems[2].Text;
        //            strRecurringTime = lvi.SubItems[3].Text;
        //            strRecurringRepeat = lvi.SubItems[4].Text;

        //            frmNewRecurring.strFlag = "Edit";
        //            frmNewRecurring er = new frmNewRecurring();
        //            er.ShowDialog();
        //            LoadListView();
        //        }

        //    }
        //    else
        //    {
        //        MessageBox.Show("No item selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void lvwTaskOfTheDay_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.LightGoldenrodYellow, e.Bounds);
            e.DrawText();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_MouseHover(object sender, EventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Closehover.png"));
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Close.png"));
        }

        private void btnClose_MouseDown(object sender, MouseEventArgs e)
        {
            btnClose.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.CloseClick.png"));
        }
    }
}
