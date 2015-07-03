using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Reflection;
using System.Globalization;

namespace Reminiscent
{
    public partial class UC_Clock : UserControl
    {
        public static string strUCAlarmID = "";
        public static string strUCAlarmName = "";
        public static string strUCDate = "";
        public static string strUCTime = "";
        public static string strUCSong = "";
        public static string strUCRepeat = "";
        public static string strUCSnooze = "";
        public static string strUCMode = "";
        int iMinute = 0;
        int iSecond = 0;
        int iMillisecond = 0;
        int iLapMinute = 0;
        int iLapSecond = 0;
        int iLapMillisecond = 0;
        int iLap = 1;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        public UC_Clock()
        {
            InitializeComponent();
        }

        #region Form load
        private void UC_Alarm_Load(object sender, EventArgs e)
        {
            //tab1
            cboSongs.DropDownStyle = ComboBoxStyle.DropDownList;

            txtAlarmName.ReadOnly = true;
            HoursUD.ReadOnly = true;
            MinutesUD.ReadOnly = true;
            chkMon.Enabled = false;
            chkTue.Enabled = false;
            chkWed.Enabled = false;
            chkThu.Enabled = false;
            chkFri.Enabled = false;
            chkSat.Enabled = false;
            chkSun.Enabled = false;
            cboSongs.Enabled = false;
            btnPickSong.Enabled = false;
            chkSnooze.Enabled = false;

            txtRepeat.Text = "Never";
            txtRepeat.ReadOnly = true;

            txtSong.Text = "";
            txtSong.ReadOnly = true;

            //btnSaveAs.Enabled = false;
            //btnDel.Enabled = false;
            //btnSave.Enabled = false;

            #region Add Song Items
            cboSongs.Items.Add("None");
            if (Directory.Exists(Application.StartupPath + "/Data/AlarmMusic"))
            {
                foreach (string strfilename in Directory.GetFiles(Application.StartupPath + "/Data/AlarmMusic/", "*.mp3").Select(Path.GetFileNameWithoutExtension))
                {
                    if (strfilename != "")
                        cboSongs.Items.Add(strfilename);
                }
            }
            cboSongs.SelectedIndex = 0;
            #endregion

            chkSnooze_CheckedChanged(sender, e);

            Sort();
            LoadListView();


            //tab2
            btnStart.Text = "Start";
            btnReset.Text = "Reset";
            btnReset.Enabled = false;
            
            
            //tab3
            radShutDown.Checked = false;
            radRestart.Checked = false;
            radLogoff.Checked = false;
            radHibernate.Checked = false;
            radLock.Checked = false;
            radSleep.Checked = false;

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
                    tabPage1.Text = frmMain.Decryption(node.SelectSingleNode("tab1").InnerText);
                    tabPage2.Text = frmMain.Decryption(node.SelectSingleNode("tab2").InnerText);
                    tabPage3.Text = frmMain.Decryption(node.SelectSingleNode("tab3").InnerText);

                    lblgb.Text = frmMain.Decryption(node.SelectSingleNode("gb1").InnerText);

                    lblAlarmTitle.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblAlarmName.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblTimeAlarm.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    lblRepeat.Text = frmMain.Decryption(node.SelectSingleNode("lbl4").InnerText);
                    lblSong.Text = frmMain.Decryption(node.SelectSingleNode("lbl5").InnerText);
                    lblSnooze.Text = frmMain.Decryption(node.SelectSingleNode("lbl6").InnerText);
                    lblHour.Text = frmMain.Decryption(node.SelectSingleNode("lbl7").InnerText);
                    lblMinute.Text = frmMain.Decryption(node.SelectSingleNode("lbl8").InnerText);

                    colID.Text = frmMain.Decryption(node.SelectSingleNode("col1").InnerText);
                    colName.Text = frmMain.Decryption(node.SelectSingleNode("col2").InnerText);
                    colDate.Text = frmMain.Decryption(node.SelectSingleNode("col3").InnerText);
                    colTime.Text = frmMain.Decryption(node.SelectSingleNode("col4").InnerText);
                    colSong.Text = frmMain.Decryption(node.SelectSingleNode("col5").InnerText);
                    colRepeat.Text = frmMain.Decryption(node.SelectSingleNode("col6").InnerText);
                    colSnooze.Text = frmMain.Decryption(node.SelectSingleNode("col7").InnerText);

                    chkMon.Text = frmMain.Decryption(node.SelectSingleNode("chk1").InnerText);
                    chkTue.Text = frmMain.Decryption(node.SelectSingleNode("chk2").InnerText);
                    chkWed.Text = frmMain.Decryption(node.SelectSingleNode("chk3").InnerText);
                    chkThu.Text = frmMain.Decryption(node.SelectSingleNode("chk4").InnerText);
                    chkFri.Text = frmMain.Decryption(node.SelectSingleNode("chk5").InnerText);
                    chkSat.Text = frmMain.Decryption(node.SelectSingleNode("chk6").InnerText);
                    chkSun.Text = frmMain.Decryption(node.SelectSingleNode("chk7").InnerText);

                    radShutDown.Text = frmMain.Decryption(node.SelectSingleNode("rad1").InnerText);
                    radRestart.Text = frmMain.Decryption(node.SelectSingleNode("rad2").InnerText);
                    radLogoff.Text = frmMain.Decryption(node.SelectSingleNode("rad3").InnerText);
                    radHibernate.Text = frmMain.Decryption(node.SelectSingleNode("rad4").InnerText);
                    radLock.Text = frmMain.Decryption(node.SelectSingleNode("rad5").InnerText);
                    radSleep.Text = frmMain.Decryption(node.SelectSingleNode("rad6").InnerText);

                    btnPickSong.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnRefresh.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    btnSaveAs.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    btnDel.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    btnSave.Text = frmMain.Decryption(node.SelectSingleNode("btn5").InnerText);
                    btnTimerStart.Text = frmMain.Decryption(node.SelectSingleNode("btn6").InnerText);

                    newToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    editToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("btn3").InnerText);
                    deleteToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("btn4").InnerText);
                    playAlarmToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item1").InnerText);
                    stopAlarmToolStripMenuItem.Text = frmMain.Decryption(node.SelectSingleNode("item2").InnerText);
                    break;
                }
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
                    int ibc11 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc11").InnerText));
                    int ibc12 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc12").InnerText));
                    int ibc13 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc13").InnerText));
                    this.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
                    tabPage1.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    tabPage3.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));
                    break;
                }
            }
            #endregion
        }
        #endregion

        internal void PgUp()
        {
            if (lstAlarm.Items.Count > 0)
            {
                if (frmMain.iPage < 44)
                {
                    lstAlarm.Focus();
                    lstAlarm.EnsureVisible(0);
                    lstAlarm.Items[0].Selected = true;
                    frmMain.iPage = 0;
                }
                else
                {
                    lstAlarm.Focus();
                    lstAlarm.EnsureVisible(frmMain.iPage);
                    lstAlarm.Items[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void PgDn()
        {
            if (lstAlarm.Items.Count > 0)
            {
                if (frmMain.iPage > lstAlarm.Items.Count - 1)
                {
                    lstAlarm.Focus();
                    lstAlarm.EnsureVisible(lstAlarm.Items.Count - 1);
                    lstAlarm.Items[lstAlarm.Items.Count - 1].Selected = true;
                    frmMain.iPage = lstAlarm.Items.Count - 1;
                }
                else
                {
                    lstAlarm.Focus();
                    lstAlarm.EnsureVisible(frmMain.iPage);
                    lstAlarm.Items[frmMain.iPage].Selected = true;
                }
            }
        }

        internal void Search(string strSearch, string strBy)
        {
            if (lstAlarm.Items.Count > 0)
            {
                if (frmMain.iSearch == lstAlarm.Items.Count)
                    frmMain.iSearch = 0;

                for (int i = frmMain.iSearch; i < lstAlarm.Items.Count; i++)
                {
                    if (strBy == "Name")
                    {
                        if (lstAlarm.Items[i].SubItems[0].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstAlarm.Focus();
                            lstAlarm.EnsureVisible(i);
                            lstAlarm.Items[i].Selected = true;
                            if (i == lstAlarm.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstAlarm.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Time")
                    {
                        if (lstAlarm.Items[i].SubItems[2].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstAlarm.Focus();
                            lstAlarm.EnsureVisible(i);
                            lstAlarm.Items[i].Selected = true;
                            if (i == lstAlarm.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstAlarm.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                    else if (strBy == "Repeat")
                    {
                        if (lstAlarm.Items[i].SubItems[4].Text.ToLower().Contains(strSearch.ToLower()))
                        {
                            lstAlarm.Focus();
                            lstAlarm.EnsureVisible(i);
                            lstAlarm.Items[i].Selected = true;
                            if (i == lstAlarm.Items.Count - 1)
                            {
                                frmMain.iSearch = 0;
                                i = 0;
                            }
                            else
                                frmMain.iSearch = i + 1;
                            break;
                        }
                        if (i == lstAlarm.Items.Count - 1)
                        {
                            frmMain.iSearch = 0;
                            i = 0;
                            break;
                        }
                    }
                }
            }
        }

        #region Sort xml by time
        public static void Sort()
        {
            if (File.Exists(Application.StartupPath + "/Data/Alarm.xml"))
            {
                XElement root = XElement.Load(Application.StartupPath + "/Data/Alarm.xml");
                var orderedtabs = root.Elements("Alarm")
                                      .OrderBy(xtab => frmMain.Decryption(xtab.Element("Time").Value.ToString()))
                                      .ToArray();
                root.RemoveAll();
                foreach (XElement tab in orderedtabs)
                    root.Add(tab);
                root.Save(Application.StartupPath + "/Data/Alarm.xml");
            }
        }
        #endregion

        #region Load list alarm
        private void LoadListView()
        {
            lstAlarm.Items.Clear();
            if (File.Exists(Application.StartupPath + "/Data/Alarm.xml"))
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Alarm.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList AlarmList = root.GetElementsByTagName("Alarm");
                for (int i = 0; i < AlarmList.Count; i++)
                {
                    try
                    {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = frmMain.Decryption(AlarmList[i].ChildNodes[1].InnerText);
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[2].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[3].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[4].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[5].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[6].InnerText));
                    lvi.SubItems.Add(frmMain.Decryption(AlarmList[i].ChildNodes[0].InnerText));
                    lstAlarm.Items.Add(lvi);
                    }
                    catch
                    {
                        File.Delete("Alarm.xml.bk");
                        File.Copy(Application.StartupPath + "/Data/Alarm.xml", "Alarm.xml.bk");
                        File.Delete(Application.StartupPath + "/Data/Alarm.xml");
                        XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Alarm.xml", Encoding.UTF8);
                        writer.Formatting = Formatting.Indented;
                        //Create XML
                        writer.WriteStartDocument();
                        //Create Root
                        writer.WriteStartElement("AlarmList");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                        writer.Close();
                        MessageBox.Show("Your Alarm database have been corrupted!\r\n"
                        + "It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        break;
                    }
                }
            }
        }
        #endregion

        #region New Alarm
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtAlarmName.ReadOnly = false;
            HoursUD.ReadOnly = false;
            MinutesUD.ReadOnly = false;
            chkMon.Enabled = true;
            chkTue.Enabled = true;
            chkWed.Enabled = true;
            chkThu.Enabled = true;
            chkFri.Enabled = true;
            chkSat.Enabled = true;
            chkSun.Enabled = true;
            cboSongs.Enabled = true;
            btnPickSong.Enabled = true;
            chkSnooze.Enabled = true;

            Player.close();
            strUCMode = "New";
            txtAlarmName.Text = "Alarm";
            HoursUD.Value = 0;
            MinutesUD.Value = 0;
            chkMon.Checked = false;
            chkTue.Checked = false;
            chkWed.Checked = false;
            chkThu.Checked = false;
            chkFri.Checked = false;
            chkSat.Checked = false;
            chkSun.Checked = false;
            cboSongs.SelectedIndex = 0;
            chkSnooze.Checked = false;

            int iMax = 0;
            foreach (ListViewItem lvi in lstAlarm.Items)
            {
                if (iMax < Convert.ToInt32(lvi.SubItems[6].Text))
                    iMax = Convert.ToInt32(lvi.SubItems[6].Text);
            }
            strUCAlarmID = (iMax + 1).ToString();
        }
        #endregion

        #region Edit Alarm
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.close();
            //Create Alarm.xml if file not exists\\
            if (!File.Exists(Application.StartupPath + "/Data/Alarm.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Alarm.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                //Create XML
                writer.WriteStartDocument();
                //Create Root
                writer.WriteStartElement("AlarmList");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }

            Boolean bDuplicateTime = false;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(Application.StartupPath + "/Data/Alarm.xml");
            XmlElement root = xmlDoc.DocumentElement;
            XmlNodeList AlarmList = root.GetElementsByTagName("Alarm");
            for (int i = 0; i < AlarmList.Count; i++)
            {
                string strHour = "";
                string strMinute = "";

                if (HoursUD.Value < 10)
                    strHour = "0" + HoursUD.Value.ToString();
                else
                    strHour = HoursUD.Value.ToString();

                if (MinutesUD.Value < 10)
                    strMinute = "0" + MinutesUD.Value.ToString();
                else
                    strMinute = MinutesUD.Value.ToString();

                if (strHour + ":" + strMinute == frmMain.Decryption(AlarmList[i].ChildNodes[3].InnerText)
                    && strUCAlarmID != frmMain.Decryption(AlarmList[i].ChildNodes[0].InnerText))
                {
                    bDuplicateTime = true;
                }
            }

            if (bDuplicateTime == false)
            {
                string strSong = "";

                if (cboSongs.SelectedIndex >= 1)
                {
                    strSong = cboSongs.Text;
                }
                else
                    strSong = txtSong.Text;

                string strDay = DateTime.Now.Day.ToString();
                string strMonth = DateTime.Now.Month.ToString();
                string strYear = DateTime.Now.Year.ToString();
                if (txtRepeat.Text == "Never")
                    strDay = (Convert.ToInt32(strDay) + 1).ToString();
                if (Convert.ToInt32(strDay) < 10)
                    strDay = "0" + strDay;
                if (Convert.ToInt32(strMonth) < 10)
                    strMonth = "0" + strMonth;

                string strDate = strDay + "/" + strMonth + "/" + strYear;
                string strHours = HoursUD.Value.ToString();
                string strMinutes = MinutesUD.Value.ToString();

                if (HoursUD.Value < 10)
                {
                    strHours = "0" + HoursUD.Value;
                }

                if (MinutesUD.Value < 10)
                {
                    strMinutes = "0" + MinutesUD.Value;
                }

                #region New
                if (strUCMode == "Edit")
                {
                    if (txtAlarmName.Text != "")
                    {
                        int iMax = 0;
                        foreach (ListViewItem lvi in lstAlarm.Items)
                        {
                            if (iMax < Convert.ToInt32(lvi.SubItems[6].Text))
                                iMax = Convert.ToInt32(lvi.SubItems[6].Text);
                        }
                        strUCAlarmID = (iMax + 1).ToString();

                        XmlDocument xd = new XmlDocument();
                        xd.Load(Application.StartupPath + "/Data/Alarm.xml");

                        XmlNode nodeAlarmName = xd.CreateNode(XmlNodeType.Element, "Alarm", null);

                        XmlNode nodeID = xd.CreateElement("ID");
                        nodeID.InnerText = frmMain.Encryption(strUCAlarmID);

                        XmlNode nodeName = xd.CreateElement("Name");
                        nodeName.InnerText = frmMain.Encryption(txtAlarmName.Text);

                        XmlNode nodeDate = xd.CreateElement("Date");
                        nodeDate.InnerText = frmMain.Encryption(strDate);

                        XmlNode nodeTime = xd.CreateElement("Time");
                        nodeTime.InnerText = frmMain.Encryption(strHours + ":" + strMinutes);

                        XmlNode nodeSong = xd.CreateElement("Song");
                        nodeSong.InnerText = frmMain.Encryption(strSong);

                        XmlNode nodeRepeat = xd.CreateElement("Repeat");
                        nodeRepeat.InnerText = frmMain.Encryption(txtRepeat.Text);

                        XmlNode nodeSnooze = xd.CreateElement("Snooze");
                        nodeSnooze.InnerText = frmMain.Encryption(chkSnooze.Text);

                        nodeAlarmName.AppendChild(nodeID);
                        nodeAlarmName.AppendChild(nodeName);
                        nodeAlarmName.AppendChild(nodeDate);
                        nodeAlarmName.AppendChild(nodeTime);
                        nodeAlarmName.AppendChild(nodeSong);
                        nodeAlarmName.AppendChild(nodeRepeat);
                        nodeAlarmName.AppendChild(nodeSnooze);

                        xd.DocumentElement.AppendChild(nodeAlarmName);
                        xd.Save(Application.StartupPath + "/Data/Alarm.xml");
                    }
                    else
                    {
                        MessageBox.Show("Please enter Alarm Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Duplicate Time!\r\nPlease Edit or Delete it first.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            frmMain.strAlarmScan = "Yes";
            classShowAlarm.dDelayTime = -1;
            strUCMode = "";
            txtAlarmName.ReadOnly = true;
            HoursUD.ReadOnly = true;
            MinutesUD.ReadOnly = true;
            chkMon.Enabled = false;
            chkTue.Enabled = false;
            chkWed.Enabled = false;
            chkThu.Enabled = false;
            chkFri.Enabled = false;
            chkSat.Enabled = false;
            chkSun.Enabled = false;
            cboSongs.Enabled = false;
            btnPickSong.Enabled = false;
            chkSnooze.Enabled = false;
            LoadListView();
        }
        #endregion

        #region Delete Alarm
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.close();
            txtAlarmName.ReadOnly = true;
            HoursUD.ReadOnly = true;
            MinutesUD.ReadOnly = true;
            chkMon.Enabled = false;
            chkTue.Enabled = false;
            chkWed.Enabled = false;
            chkThu.Enabled = false;
            chkFri.Enabled = false;
            chkSat.Enabled = false;
            chkSun.Enabled = false;
            cboSongs.Enabled = false;
            btnPickSong.Enabled = false;
            chkSnooze.Enabled = false;
            #region Delete
            if (strUCMode == "Edit")
            {
                if (lstAlarm.SelectedItems.Count > 0)
                {
                    DialogResult dr = new DialogResult();
                    dr = MessageBox.Show("Are you sure to Delete?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dr == DialogResult.Yes)
                    {
                        if (File.Exists(Application.StartupPath + "/Data/Alarm.xml"))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(Application.StartupPath + "/Data/Alarm.xml");

                            foreach (XmlNode node in doc.SelectNodes("AlarmList/Alarm"))
                            {
                                if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == strUCAlarmID)
                                {
                                    node.ParentNode.RemoveChild(node);
                                }

                            }
                            doc.Save(Application.StartupPath + "/Data/Alarm.xml");
                            Sort();
                            LoadListView();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No item selected!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
        }
        #endregion

        #region Play Alarm
        //private Timer volumetimer;
        private void playAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string strSongName = "";
            foreach (ListViewItem lvi in lstAlarm.SelectedItems)
            {
                strSongName = lvi.SubItems[3].Text;
            }

            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.close();
            if (strSongName != null)
            {
                Player.URL = Application.StartupPath + "/Data/AlarmMusic/" + strSongName + ".mp3";
                Player.controls.play();
                //Player.settings.volume = 0;
                //volumetimer = new Timer();
                //volumetimer.Interval = 3000;
                //volumetimer.Tick += voltime;
                //volumetimer.Start();
            }
        }
        #endregion

        #region Stop Alarm
        private void stopAlarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Player.controls.pause();
        }
        #endregion

        #region Trash
        //void voltime(object sender, EventArgs e)
        //{
        //    Player.settings.volume++;
        //    if (Player.settings.volume == 80)
        //    {
        //        volumetimer.Stop();
        //    }
        //}
        #endregion

        #region PLayer
        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                //Player.controls.play();    
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            //MessageBox.Show("Cannot play media file.");
        }
        #endregion

        #region Button Click
        private void btnPickSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cboSongs.SelectedIndex = -1;
                Player.close();
                if (File.Exists(Application.StartupPath + "/Data/AlarmMusic/" + openFileDialog.SafeFileName))
                {
                    cboSongs.Text = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.IndexOf(".mp3"));
                    Player.URL = Application.StartupPath + "/Data/AlarmMusic/" + cboSongs.Text + ".mp3";
                }
                else
                {
                    File.Copy(openFileDialog.FileName, Application.StartupPath + "/Data/AlarmMusic/" + openFileDialog.SafeFileName);
                    txtSong.Text = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.IndexOf(".mp3"));
                    Player.URL = Application.StartupPath + "/Data/AlarmMusic/" + txtSong.Text + ".mp3";
                }
                Player.controls.play();
            }
            else
            {
                MessageBox.Show("Can not open file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Player.close();
            try
            {
                //Create Alarm.xml if file not exists\\
                if (!File.Exists(Application.StartupPath + "/Data/Alarm.xml"))
                {
                    XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Data/Alarm.xml", Encoding.UTF8);
                    writer.Formatting = Formatting.Indented;
                    //Create XML
                    writer.WriteStartDocument();
                    //Create Root
                    writer.WriteStartElement("AlarmList");
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }

                Boolean bDuplicateTime = false;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Data/Alarm.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList AlarmList = root.GetElementsByTagName("Alarm");
                for (int i = 0; i < AlarmList.Count; i++)
                {
                    string strHour = "";
                    string strMinute = "";

                    if(HoursUD.Value < 10)
                        strHour = "0" + HoursUD.Value.ToString();
                    else
                        strHour = HoursUD.Value.ToString();

                    if(MinutesUD.Value < 10)
                        strMinute = "0" + MinutesUD.Value.ToString();
                    else
                        strMinute = MinutesUD.Value.ToString();

                    if (strHour + ":" + strMinute == frmMain.Decryption(AlarmList[i].ChildNodes[3].InnerText)
                        && strUCAlarmID != frmMain.Decryption(AlarmList[i].ChildNodes[0].InnerText))
                    {
                        bDuplicateTime = true;
                    }
                }

                if (bDuplicateTime == false)
                {
                    string strSong = "";

                    if (cboSongs.SelectedIndex >= 1)
                    {
                        strSong = cboSongs.Text;
                    }
                    else
                        strSong = txtSong.Text;

                    string strDay = DateTime.Now.Day.ToString();
                    string strMonth = DateTime.Now.Month.ToString();
                    string strYear = DateTime.Now.Year.ToString();
                    if (txtRepeat.Text == "Never")
                        strDay = (Convert.ToInt32(strDay) + 1).ToString();
                    if (Convert.ToInt32(strDay) < 10)
                        strDay = "0" + strDay;
                    if (Convert.ToInt32(strMonth) < 10)
                        strMonth = "0" + strMonth;

                    string strDate = strDay + "/" + strMonth + "/" + strYear;
                    string strHours = HoursUD.Value.ToString();
                    string strMinutes = MinutesUD.Value.ToString();

                    if (HoursUD.Value < 10)
                    {
                        strHours = "0" + HoursUD.Value;
                    }

                    if (MinutesUD.Value < 10)
                    {
                        strMinutes = "0" + MinutesUD.Value;
                    }

                    #region New
                    if (strUCMode == "New")
                    {
                        if (txtAlarmName.Text.Trim() != "")
                        {

                            XmlDocument xd = new XmlDocument();
                            xd.Load(Application.StartupPath + "/Data/Alarm.xml");

                            XmlNode nodeAlarmName = xd.CreateNode(XmlNodeType.Element, "Alarm", null);

                            XmlNode nodeID = xd.CreateElement("ID");
                            nodeID.InnerText = frmMain.Encryption(strUCAlarmID);

                            XmlNode nodeName = xd.CreateElement("Name");
                            nodeName.InnerText = frmMain.Encryption(txtAlarmName.Text);

                            XmlNode nodeDate = xd.CreateElement("Date");
                            nodeDate.InnerText = frmMain.Encryption(strDate);

                            XmlNode nodeTime = xd.CreateElement("Time");
                            nodeTime.InnerText = frmMain.Encryption(strHours + ":" + strMinutes);

                            XmlNode nodeSong = xd.CreateElement("Song");
                            if (strSong != "")
                                nodeSong.InnerText = frmMain.Encryption(strSong);
                            else
                                nodeSong.InnerText = "";

                            XmlNode nodeRepeat = xd.CreateElement("Repeat");
                            nodeRepeat.InnerText = frmMain.Encryption(txtRepeat.Text);

                            XmlNode nodeSnooze = xd.CreateElement("Snooze");
                            nodeSnooze.InnerText = frmMain.Encryption(chkSnooze.Text);

                            nodeAlarmName.AppendChild(nodeID);
                            nodeAlarmName.AppendChild(nodeName);
                            nodeAlarmName.AppendChild(nodeDate);
                            nodeAlarmName.AppendChild(nodeTime);
                            nodeAlarmName.AppendChild(nodeSong);
                            nodeAlarmName.AppendChild(nodeRepeat);
                            nodeAlarmName.AppendChild(nodeSnooze);

                            xd.DocumentElement.AppendChild(nodeAlarmName);
                            xd.Save(Application.StartupPath + "/Data/Alarm.xml");
                        }
                        else
                        {
                            MessageBox.Show("Please enter Alarm Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    #region Edit
                    //Edit alarm\\
                    if (strUCMode == "Edit")
                    {
                        if (txtAlarmName.Text.Trim() != "")
                        {
                            XmlDocument doc = new XmlDocument();
                            //Load Alarm.xml
                            doc.Load(Application.StartupPath + "/Data/Alarm.xml");

                            //Search in Root/Node
                            foreach (XmlNode node in doc.SelectNodes("AlarmList/Alarm"))
                            {
                                //If Element ID = Selected ID then remove it
                                if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == strUCAlarmID)
                                {
                                    node.SelectSingleNode("Name").InnerText = frmMain.Encryption(txtAlarmName.Text);
                                    node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDate);
                                    node.SelectSingleNode("Time").InnerText = frmMain.Encryption(strHours + ":" + strMinutes);
                                    if (strSong != "")
                                        node.SelectSingleNode("Song").InnerText = frmMain.Encryption(strSong);
                                    else
                                        node.SelectSingleNode("Song").InnerText = "";

                                    node.SelectSingleNode("Repeat").InnerText = frmMain.Encryption(txtRepeat.Text);
                                    node.SelectSingleNode("Snooze").InnerText = frmMain.Encryption(chkSnooze.Text);
                                }
                            }

                            //Save XML
                            doc.Save(Application.StartupPath + "/Data/Alarm.xml");
                        }
                        else
                            MessageBox.Show("Please enter Alarm Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    #endregion

                    Sort();

                    frmMain.strAlarmScan = "Yes";
                    classShowAlarm.dDelayTime = -1;
                }

                else
                {
                    MessageBox.Show("Duplicate Time!\r\nPlease Edit or Delete it first.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                strUCMode = "";
                txtAlarmName.ReadOnly = true;
                HoursUD.ReadOnly =  true;
                MinutesUD.ReadOnly =  true;
                chkMon.Enabled = false;
                chkTue.Enabled = false;
                chkWed.Enabled = false;
                chkThu.Enabled = false;
                chkFri.Enabled = false;
                chkSat.Enabled = false;
                chkSun.Enabled = false;
                cboSongs.Enabled = false;
                btnPickSong.Enabled = false;
                chkSnooze.Enabled = false;
                LoadListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Save Fail!" + ex, "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBox.Show("Save Fail!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Check Days
        private void CheckDays()
        {
            txtRepeat.Text = "";

            if (chkMon.Checked && chkTue.Checked && chkWed.Checked && chkThu.Checked
                && chkFri.Checked && chkSat.Checked && chkSun.Checked)
            {
                txtRepeat.Text = "Every day";
            }

            else if (chkMon.Checked && chkTue.Checked && chkWed.Checked && chkThu.Checked
                && chkFri.Checked && !chkSat.Checked && !chkSun.Checked)
            {
                txtRepeat.Text = "Weekdays";
            }

            else if (!chkMon.Checked && !chkTue.Checked && !chkWed.Checked && !chkThu.Checked
            && !chkFri.Checked && chkSat.Checked && chkSun.Checked)
            {
                txtRepeat.Text = "Weekends";
            }

            else if (!chkMon.Checked && !chkTue.Checked && !chkWed.Checked && !chkThu.Checked
                && !chkFri.Checked && !chkSat.Checked && !chkSun.Checked)
            {
                txtRepeat.Text = "Never";
            }
            else
            {
                if (chkMon.Checked)
                {
                    txtRepeat.Text += "Mon ";
                }

                if (chkTue.Checked)
                {
                    txtRepeat.Text += "Tue ";
                }

                if (chkWed.Checked)
                {
                    txtRepeat.Text += "Wed ";
                }

                if (chkThu.Checked)
                {
                    txtRepeat.Text += "Thu ";
                }

                if (chkFri.Checked)
                {
                    txtRepeat.Text += "Fri ";
                }

                if (chkSat.Checked)
                {
                    txtRepeat.Text += "Sat ";
                }

                if (chkSun.Checked)
                {
                    txtRepeat.Text += "Sun";
                }
            }

            txtRepeat.Text = txtRepeat.Text.Trim();
        }

        private void chkMon_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMon.Checked)
            {
                chkMon.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkMon.Image = null;
            }
            CheckDays();
        }

        private void chkTue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTue.Checked)
            {
                chkTue.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkTue.Image = null;
            }
            CheckDays();
        }

        private void chkWed_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWed.Checked)
            {
                chkWed.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkWed.Image = null;
            }
            CheckDays();
        }

        private void chkThu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkThu.Checked)
            {
                chkThu.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkThu.Image = null;
            }
            CheckDays();
        }

        private void chkFri_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFri.Checked)
            {
                chkFri.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkFri.Image = null;
            }
            CheckDays();
        }

        private void chkSat_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSat.Checked)
            {
                chkSat.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkSat.Image = null;
            }
            CheckDays();
        }

        private void chkSun_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSun.Checked)
            {
                chkSun.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Checked-icon.png"));
            }
            else
            {
                chkSun.Image = null;
            }
            CheckDays();
        }

        private void chkSnooze_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSnooze.Checked)
            {
                chkSnooze.Text = "On";
                chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkSnooze.Text = "Off";
                chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }
        #endregion

        #region Hover
        //Move
        private void btnNew_MouseMove(object sender, MouseEventArgs e)
        {
            btnRefresh.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
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

        private void chkSnooze_MouseMove(object sender, MouseEventArgs e)
        {
            chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnPickSong_MouseMove(object sender, MouseEventArgs e)
        {
            btnPickSong.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        //Leave
        private void btnPickSong_MouseLeave(object sender, EventArgs e)
        {
            btnPickSong.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void chkSnooze_MouseLeave(object sender, EventArgs e)
        {
            if (chkSnooze.Checked)
            {
                chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnChecked.png"));
            }
            else
            {
                chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnUnchecked.png"));
            }
        }

        private void btnNew_MouseLeave(object sender, EventArgs e)
        {
            btnRefresh.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
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
        #endregion

        #region Selected Index Changed
        private void cboSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);

            if (cboSongs.Enabled)
            {
                if (cboSongs.SelectedIndex >= 1)
                {
                    txtSong.Text = "";
                    btnPickSong.Enabled = false;
                    Player.close();
                    Player.URL = Application.StartupPath + "/Data/AlarmMusic/" + cboSongs.Text + ".mp3";
                    Player.controls.play();
                }

                else
                {
                    btnPickSong.Enabled = true;
                    Player.close();
                }
            }
        }

        private void lstAlarm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAlarm.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lstAlarm.SelectedItems)
                {
                    strUCAlarmName = lvi.SubItems[0].Text;
                    strUCDate = lvi.SubItems[1].Text;
                    strUCTime = lvi.SubItems[2].Text;
                    strUCSong = lvi.SubItems[3].Text;
                    strUCRepeat = lvi.SubItems[4].Text;
                    strUCSnooze = lvi.SubItems[5].Text;
                    strUCAlarmID = lvi.SubItems[6].Text;
                    break;
                }

                chkMon.Checked = false; chkTue.Checked = false; chkWed.Checked = false; chkThu.Checked = false;
                chkFri.Checked = false; chkSat.Checked = false; chkSun.Checked = false;
                string[] strDays = strUCRepeat.Split(' ');
                foreach (string strCD in strDays)
                {
                    if (strCD == "Mon")
                        chkMon.Checked = true;
                    else if (strCD == "Tue")
                        chkTue.Checked = true;
                    else if (strCD == "Wed")
                        chkWed.Checked = true;
                    else if (strCD == "Thu")
                        chkThu.Checked = true;
                    else if (strCD == "Fri")
                        chkFri.Checked = true;
                    else if (strCD == "Sat")
                        chkSat.Checked = true;
                    else if (strCD == "Sun")
                        chkSun.Checked = true;
                    else if (strCD == "Every")
                    {
                        chkMon.Checked = true; chkTue.Checked = true; chkWed.Checked = true; chkThu.Checked = true;
                        chkFri.Checked = true; chkSat.Checked = true; chkSun.Checked = true;
                    }
                    else if (strCD == "Weekdays")
                    {
                        chkMon.Checked = true; chkTue.Checked = true; chkWed.Checked = true;
                        chkThu.Checked = true; chkFri.Checked = true;
                    }
                    else if (strCD == "Weekends")
                    {
                        chkSat.Checked = true; chkSun.Checked = true;
                    }
                }

                //lblgb.Text = "Edit Alarm";
                txtAlarmName.Text = strUCAlarmName;
                HoursUD.Value = Convert.ToInt32(strUCTime.Substring(0, strUCTime.IndexOf(':')));
                MinutesUD.Value = Convert.ToInt32(strUCTime.Substring(strUCTime.LastIndexOf(':') + 1));
                if (strUCSong != "")
                {
                    cboSongs.Text = strUCSong;
                }
                else
                {
                    cboSongs.Text = "None";
                }
                txtRepeat.Text = strUCRepeat;

                if (strUCSnooze == "On")
                {
                    chkSnooze.Checked = true;
                }
                else
                {
                    chkSnooze.Checked = false;
                }

                txtAlarmName.ReadOnly = false;
                HoursUD.ReadOnly = false;
                MinutesUD.ReadOnly = false;
                chkMon.Enabled = true;
                chkTue.Enabled = true;
                chkWed.Enabled = true;
                chkThu.Enabled = true;
                chkFri.Enabled = true;
                chkSat.Enabled = true;
                chkSun.Enabled = true;
                cboSongs.Enabled = true;
                btnPickSong.Enabled = true;
                chkSnooze.Enabled = true;

                Player.close();
                strUCMode = "Edit";
            }
        }
        #endregion

        private void lstAlarm_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.Cancel = true;
            e.NewWidth = lstAlarm.Columns[e.ColumnIndex].Width;
        }

        //Tab 2 ------------------------------------------------------------------------------------------------------------------
        #region Button Click
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                btnStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Stop.png"));
                btnStart.Text = "Stop";
                btnReset.Text = "Lap";
                btnReset.Enabled = true;
                StopwatchTimer.Start();
                LapTimer.Start();
            }

            else if (btnStart.Text == "Stop")
            {
                btnStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Start.png"));
                btnStart.Text = "Start";
                btnReset.Text = "Reset";
                StopwatchTimer.Stop();
                LapTimer.Stop();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (btnReset.Text == "Reset")
            {
                btnReset.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Reset.png"));
                lstStopwatch.Items.Clear();
                btnReset.Enabled = false;
                iMinute = 0;
                iSecond = 0;
                iMillisecond = 0;
                iLapMinute = 0;
                iLapSecond = 0;
                iLapMillisecond = 0;
                lblTime.Text = "00:00,0";
                lblLap.Text = "00:00,0";
            }

            else if (btnReset.Text == "Lap")
            {
                btnReset.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Reset.png"));
                lstStopwatch.Items.Add("Lap " + iLap + ": " + lblLap.Text);
                lstStopwatch.EnsureVisible(lstStopwatch.Items.Count - 1);
                iLapMinute = 0;
                iLapSecond = 0;
                iLapMillisecond = 0;
                iLap++;
            }
        }
        #endregion

        #region Timer
        private void StopwatchTimer_Tick(object sender, EventArgs e)
        {
            if (iMillisecond == 9)
            {
                iMillisecond = 0;
                if (iSecond == 59)
                {
                    iSecond = 0;
                    if (iMinute == 59)
                    {
                        iMinute = 0;
                    }
                    else
                    {
                        iMinute++;
                    }
                }
                else
                {
                    iSecond++;
                }
            }

            else
            {
                iMillisecond++;
            }

            if (iMinute < 10)
                lblTime.Text = "0" + iMinute + ":";
            else
                lblTime.Text = iMinute + ":";

            if (iSecond < 10)
                lblTime.Text += "0" + iSecond + "," + iMillisecond;
            else
                lblTime.Text += iSecond + "," + iMillisecond;
        }

        private void LapTimer_Tick(object sender, EventArgs e)
        {
            if (iLapMillisecond == 9)
            {
                iLapMillisecond = 0;
                if (iLapSecond == 59)
                {
                    iLapSecond = 0;
                    if (iLapMinute == 59)
                    {
                        iLapMinute = 0;
                    }
                    else
                    {
                        iLapMinute++;
                    }
                }
                else
                {
                    iLapSecond++;
                }
            }

            else
            {
                iLapMillisecond++;
            }

            if (iLapMinute < 10)
                lblLap.Text = "0" + iLapMinute + ":";
            else
                lblLap.Text = iLapMinute + ":";

            if (iLapSecond < 10)
                lblLap.Text += "0" + iLapSecond + "," + iLapMillisecond;
            else
                lblLap.Text += iLapSecond + "," + iLapMillisecond;
        }
        #endregion

        #region Hover
        //Move
        private void btnStart_MouseMove(object sender, MouseEventArgs e)
        {
            btnStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.StartHover.png"));
        }

        private void btnReset_MouseMove(object sender, MouseEventArgs e)
        {
            btnReset.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.StartHover.png"));
        }

        //Leave
        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                btnStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Start.png"));
            }

            if (btnStart.Text == "Stop")
            {
                btnStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Stop.png"));
            }
        }

        private void btnReset_MouseLeave(object sender, EventArgs e)
        {
            if (btnReset.Enabled)
                btnReset.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Reset.png"));
        }
        #endregion

        //Tab 3 ------------------------------------------------------------------------------------------------------------------
        #region Start
        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            if (frmShowTurnOff.strMode != "")
            {
                foreach (Form frm in Application.OpenForms)
                {
                    frm.WindowState = FormWindowState.Minimized;
                }

                frmShowTurnOff.iHour = Convert.ToInt32(nHour.Value);
                frmShowTurnOff.iMinute = Convert.ToInt32(nMinute.Value);
                frmShowTurnOff.iSecond = 0;
                frmShowTurnOff sto = new frmShowTurnOff();
                sto.Show();
                radShutDown.Checked = false;
                radRestart.Checked = false;
                radLogoff.Checked = false;
                radHibernate.Checked = false;
                radLock.Checked = false;
                radSleep.Checked = false;
            }
            else
            {
                MessageBox.Show("Please select one mode!", "Warrning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Checked
        private void radShutDown_CheckedChanged(object sender, EventArgs e)
        {
            if (radShutDown.Checked)
            {
                frmShowTurnOff.strMode = "ShutDown";
                radShutDown.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radShutDown.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radRestart_CheckedChanged(object sender, EventArgs e)
        {
            if (radRestart.Checked)
            {
                frmShowTurnOff.strMode = "Restart";
                radRestart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radRestart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radLogoff_CheckedChanged(object sender, EventArgs e)
        {
            if (radLogoff.Checked)
            {
                frmShowTurnOff.strMode = "Logoff";
                radLogoff.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radLogoff.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radHibernate_CheckedChanged(object sender, EventArgs e)
        {
            if (radHibernate.Checked)
            {
                frmShowTurnOff.strMode = "Hibernate";
                radHibernate.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radHibernate.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radLock_CheckedChanged(object sender, EventArgs e)
        {
            if (radLock.Checked)
            {
                frmShowTurnOff.strMode = "Lock";
                radLock.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radLock.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radSleep_CheckedChanged(object sender, EventArgs e)
        {
            if (radSleep.Checked)
            {
                frmShowTurnOff.strMode = "Sleep";
                radSleep.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radSleep.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }
        #endregion

        #region Hover
        //Move
        private void radShutDown_MouseMove(object sender, MouseEventArgs e)
        {
            radShutDown.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void radRestart_MouseMove(object sender, MouseEventArgs e)
        {
            radRestart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void radLogoff_MouseMove(object sender, MouseEventArgs e)
        {
            radLogoff.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void radHibernate_MouseMove(object sender, MouseEventArgs e)
        {
            radHibernate.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void radLock_MouseMove(object sender, MouseEventArgs e)
        {
            radLock.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void radSleep_MouseMove(object sender, MouseEventArgs e)
        {
            radSleep.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void btnTimerStart_MouseMove(object sender, MouseEventArgs e)
        {
            btnTimerStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.StartHover.png"));
        }

        //Leave
        private void btnTimerStart_MouseLeave(object sender, EventArgs e)
        {
            btnTimerStart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Start.png"));
        }

        private void radShutDown_MouseLeave(object sender, EventArgs e)
        {
            if (radShutDown.Checked)
            {
                radShutDown.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radShutDown.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radRestart_MouseLeave(object sender, EventArgs e)
        {
            if (radRestart.Checked)
            {
                radRestart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radRestart.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radLogoff_MouseLeave(object sender, EventArgs e)
        {
            if (radLogoff.Checked)
            {
                radLogoff.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radLogoff.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radHibernate_MouseLeave(object sender, EventArgs e)
        {
            if (radHibernate.Checked)
            {
                radHibernate.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radHibernate.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radLock_MouseLeave(object sender, EventArgs e)
        {
            if (radLock.Checked)
            {
                radLock.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radLock.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }

        private void radSleep_MouseLeave(object sender, EventArgs e)
        {
            if (radSleep.Checked)
            {
                radSleep.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
            }

            else
            {
                radSleep.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
            }
        }
        #endregion

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Graphics gfx = e.Graphics;
            Pen p = new Pen(Color.Black, 1);
            gfx.DrawLine(p, 0, 6, 0, e.ClipRectangle.Height - 1);   //Trái
            gfx.DrawLine(p, 0, 6, 6, 6);                           //Trên-Trái
            gfx.DrawLine(p, 0, 6, e.ClipRectangle.Width - 1, 6);   //Trên-Phải
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, 6, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1);       //Phải
            gfx.DrawLine(p, e.ClipRectangle.Width - 1, e.ClipRectangle.Height - 1, 0, e.ClipRectangle.Height - 1);      //Dưới
        }
    }
}
