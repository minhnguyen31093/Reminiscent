using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;
using System.Reflection;

namespace Reminiscent
{
    public partial class NewAlarm : Form
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string strAlarmID = "";

        public NewAlarm()
        {
            InitializeComponent();
        }

        //Form load
        private void NewAlarm_Load(object sender, EventArgs e)
        {
            cboSongs.DropDownStyle = ComboBoxStyle.DropDownList;

            txtRepeat.Text = "Never";
            txtRepeat.Enabled = false;

            txtSong.Text = "";
            txtSong.Enabled = false;

            #region Add Song Items
            cboSongs.Items.Add("None");
            if (Directory.Exists("AlarmMusic"))
            {
                foreach (string strfilename in Directory.GetFiles("AlarmMusic/", "*.mp3").Select(Path.GetFileNameWithoutExtension))
                {
                    if(strfilename != "")
                        cboSongs.Items.Add(strfilename);
                }
            }
            cboSongs.SelectedIndex = 0;
            #endregion

            #region Mode
            if (UC_Clock.strUCMode == "New")
            {
                this.Text = "New Alarm";
                strAlarmID = UC_Clock.strUCAlarmID;
                txtAlarmName.Text = "Alarm";
            }

            if (UC_Clock.strUCMode == "Edit")
            {
                this.Text = "Edit Alarm";
                strAlarmID = UC_Clock.strUCAlarmID;
                txtAlarmName.Text = UC_Clock.strUCAlarmName;
                HoursUD.Value = Convert.ToInt32(UC_Clock.strUCTime.Substring(0, UC_Clock.strUCTime.IndexOf(':')));
                MinutesUD.Value = Convert.ToInt32(UC_Clock.strUCTime.Substring(UC_Clock.strUCTime.LastIndexOf(':') + 1));
                cboSongs.Text = UC_Clock.strUCSong;
                txtRepeat.Text = UC_Clock.strUCRepeat;
                if (UC_Clock.strUCSnooze == "On")
                {
                    chkSnooze.Checked = true;
                }

                string[] strDays = txtRepeat.Text.Split(' ');
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
            }
            #endregion

            chkSnooze_CheckedChanged(sender, e);
        }

        //Form close
        private void NewAlarm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.close();
        }

        //Select song
        private void cboSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);

            if(cboSongs.SelectedIndex >= 1)
            {
                txtSong.Text = "";
                btnPickSong.Enabled = false;
                Player.close();
                Player.URL = "AlarmMusic/" + cboSongs.Text + ".mp3";
                Player.controls.play();
            }

            else
            {
                btnPickSong.Enabled = true;
                Player.close();
            }
        }
        
        //Player Error
        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {

            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            MessageBox.Show("Cannot play media file.");
            this.Close();
        }

        //Button\\
        //Choose your own song
        private void btnPickSong_Click(object sender, EventArgs e)
        {
            openFileDialog.CheckFileExists = true;
            openFileDialog.AddExtension = true;
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cboSongs.SelectedIndex = -1;
                Player.close();
                if (File.Exists("AlarmMusic/" + openFileDialog.SafeFileName))
                {
                    cboSongs.Text = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.IndexOf(".mp3"));
                    Player.URL = "AlarmMusic/" + cboSongs.Text + ".mp3";
                }
                else
                {
                    File.Copy(openFileDialog.FileName, "AlarmMusic/" + openFileDialog.SafeFileName);
                    txtSong.Text = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.IndexOf(".mp3"));
                    Player.URL = "AlarmMusic/" + txtSong.Text + ".mp3";
                }
                Player.controls.play();
            }
            else
            {
                MessageBox.Show("Can not open file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Save
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean bDuplicateTime = false;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("Alarm.xml");
                XmlElement root = xmlDoc.DocumentElement;
                XmlNodeList AlarmList = root.GetElementsByTagName("Alarm");
                for (int i = 0; i < AlarmList.Count; i++)
                {
                    if (HoursUD.Value + ":" + MinutesUD.Value == frmMain.Decryption(AlarmList[i].ChildNodes[3].InnerText)
                        && strAlarmID != frmMain.Decryption(AlarmList[i].ChildNodes[0].InnerText))
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

                    //Create Alarm.xml if file not exists\\
                    if (!File.Exists("Alarm.xml"))
                    {
                        XmlTextWriter writer = new XmlTextWriter("Alarm.xml", Encoding.UTF8);
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
                    if (UC_Clock.strUCMode == "New")
                    {
                        if (txtAlarmName.Text != "")
                        {
                            
                            XmlDocument xd = new XmlDocument();
                            xd.Load("Alarm.xml");

                            XmlNode nodeAlarmName = xd.CreateNode(XmlNodeType.Element, "Alarm", null);

                            XmlNode nodeID = xd.CreateElement("ID");
                            nodeID.InnerText = strAlarmID;

                            XmlNode nodeName = xd.CreateElement("Name");
                            nodeName.InnerText = txtAlarmName.Text;

                            XmlNode nodeDate = xd.CreateElement("Date");
                            nodeDate.InnerText = strDate;

                            XmlNode nodeTime = xd.CreateElement("Time");
                            nodeTime.InnerText = strHours + ":" + strMinutes;

                            XmlNode nodeSong = xd.CreateElement("Song");
                            nodeSong.InnerText = strSong;

                            XmlNode nodeRepeat = xd.CreateElement("Repeat");
                            nodeRepeat.InnerText = txtRepeat.Text;

                            XmlNode nodeSnooze = xd.CreateElement("Snooze");
                            nodeSnooze.InnerText = chkSnooze.Text;

                            nodeID.InnerText = frmMain.Encryption(nodeID.InnerText);
                            nodeName.InnerText = frmMain.Encryption(nodeName.InnerText);
                            nodeDate.InnerText = frmMain.Encryption(nodeDate.InnerText);
                            nodeTime.InnerText = frmMain.Encryption(nodeTime.InnerText);
                            nodeSong.InnerText = frmMain.Encryption(nodeSong.InnerText);
                            nodeRepeat.InnerText = frmMain.Encryption(nodeRepeat.InnerText);
                            nodeSnooze.InnerText = frmMain.Encryption(nodeSnooze.InnerText);

                            nodeAlarmName.AppendChild(nodeID);
                            nodeAlarmName.AppendChild(nodeName);
                            nodeAlarmName.AppendChild(nodeDate);
                            nodeAlarmName.AppendChild(nodeTime);
                            nodeAlarmName.AppendChild(nodeSong);
                            nodeAlarmName.AppendChild(nodeRepeat);
                            nodeAlarmName.AppendChild(nodeSnooze);

                            xd.DocumentElement.AppendChild(nodeAlarmName);
                            xd.Save("Alarm.xml");

                            Player.close();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please enter Alarm Name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    #endregion

                    #region Edit
                    //Edit alarm\\
                    if (UC_Clock.strUCMode == "Edit")
                    {
                        XmlDocument doc = new XmlDocument();
                        //Load Alarm.xml
                        doc.Load("Alarm.xml");

                        //Search in Root/Node
                        foreach (XmlNode node in doc.SelectNodes("AlarmList/Alarm"))
                        {
                            //If Element ID = Selected ID then remove it
                            if (frmMain.Decryption(node.SelectSingleNode("ID").InnerText) == UC_Clock.strUCAlarmID)
                            {
                                node.SelectSingleNode("Name").InnerText = frmMain.Encryption(txtAlarmName.Text);
                                node.SelectSingleNode("Date").InnerText = frmMain.Encryption(strDate);
                                node.SelectSingleNode("Time").InnerText = frmMain.Encryption(strHours + ":" + strMinutes);
                                node.SelectSingleNode("Song").InnerText = frmMain.Encryption(strSong);
                                node.SelectSingleNode("Repeat").InnerText = frmMain.Encryption(txtRepeat.Text);
                                node.SelectSingleNode("Snooze").InnerText = frmMain.Encryption(chkSnooze.Text);
                            }
                        }

                        //Save XML
                        doc.Save("Alarm.xml");

                        //Close Player and Form
                        Player.close();
                        this.Close();
                    }
                    #endregion

                    XElement xeroot = XElement.Load("Alarm.xml");
                    var orderedtabs = xeroot.Elements("Alarm")
                                          .OrderBy(xtab => (string)xtab.Element("Time"))
                                          .ToArray();
                    xeroot.RemoveAll();
                    foreach (XElement tab in orderedtabs)
                        xeroot.Add(tab);
                    xeroot.Save("Alarm.xml");

                    frmMain.strAlarmScan = "Yes";
                    classShowAlarm.dDelayTime = -1;
                }

                else
                {
                    MessageBox.Show("Duplicate Time!\r\nPlease Edit or Delete it first.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Save Fail!", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Exit
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Player.close();
            if (txtSong.Text != "")
            {
                File.Delete("AlarmMusic/" + txtSong.Text + ".mp3");
            }
            this.Close();
        }

        //Mouse Hover
        private void btnOK_MouseHover(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCancel_MouseHover(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnPickSong_MouseHover(object sender, EventArgs e)
        {
            btnPickSong.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnPickSong_MouseLeave(object sender, EventArgs e)
        {
            btnPickSong.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        //Check Days
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
            CheckDays();
        }

        private void chkTue_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }

        private void chkWed_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }

        private void chkThu_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }

        private void chkFri_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }

        private void chkSat_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }

        private void chkSun_CheckedChanged(object sender, EventArgs e)
        {
            CheckDays();
        }


        //Snooze\\
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

        private void chkSnooze_MouseHover(object sender, EventArgs e)
        {
            chkSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
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
    }
}
