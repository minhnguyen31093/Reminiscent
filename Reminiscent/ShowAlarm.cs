using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;
using CoreAudioApi;
using System.Xml;
using System.Xml.Linq;

namespace Reminiscent
{
    public partial class ShowAlarm : Form
    {
        private MMDevice device;
        int iVolume = 100;
        string strMute = "No";
        public ShowAlarm()
        {
            InitializeComponent();
            MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
            device = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eRender, ERole.eMultimedia);
            iVolume = (int)(device.AudioEndpointVolume.MasterVolumeLevelScalar * 100); ;
        }

        int iXPos = 0;
        int iYPos = 0;
        int iIC = 0;
        int iSnoozeTime = 60;
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        private Timer volumetimer;
        WMPLib.WindowsMediaPlayer Player = new WMPLib.WindowsMediaPlayer();

        private void frmShowAlarm_Load(object sender, EventArgs e)
        {
            if (device.AudioEndpointVolume.Mute == true)
            {
                device.AudioEndpointVolume.Mute = false;
                strMute = "Yes";
            }
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)100 / 100.0f);
            classShowAlarm.dDelayTime = -1;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.BackColor = Color.Silver;
            this.TransparencyKey = Color.Silver;

            //this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            //this.TransparencyKey = Color.FromKnownColor(KnownColor.Control);
            //this.Update();

            iXPos = -20;
            iYPos = lblTime.Size.Height/2 - 20;
            lblBird.Location = new System.Drawing.Point(iXPos, iYPos);

            lblYellow1.Location = new System.Drawing.Point(panel1.Size.Width / 2 - btnSnooze.Size.Width * 2, lblTime.Size.Height / 5);
            lblYellow2.Location = new System.Drawing.Point(panel1.Size.Width / 2 + btnSnooze.Size.Width * 2 - 20, lblTime.Size.Height / 5);

            if (classShowAlarm.strSnooze == "On")
            {
                btnSnooze.Show();
                btnSnooze.Location = new System.Drawing.Point(panel1.Size.Width / 2 - btnSnooze.Size.Width - 20, panel1.Size.Height / 2 - 100);
                btnClose.Location = new System.Drawing.Point(panel1.Size.Width / 2 + 20, panel1.Size.Height / 2 - 100);
            }

            else
            {
                btnSnooze.Hide();
                btnClose.Location = new System.Drawing.Point(panel1.Size.Width / 2 - btnClose.Size.Width / 2, panel1.Size.Height / 2 - 100);
            }

            lblRed1.Location = new System.Drawing.Point(panel1.Size.Width / 2 - btnSnooze.Size.Width * 2, panel1.Size.Height / 2 - 100);
            lblRed2.Location = new System.Drawing.Point(panel1.Size.Width / 2 + btnSnooze.Size.Width * 2 - 20, panel1.Size.Height / 2 - 100);

            lblTime.Text = classShowAlarm.strTime;

            if (classShowAlarm.strTime != DateTime.Now.Hour + ":" + DateTime.Now.Minute)
            {
                string strHour = DateTime.Now.Hour.ToString();
                string strMinute = DateTime.Now.Minute.ToString();
                if (Convert.ToInt32(strHour) < 10)
                    strHour = "0" + strHour;
                if (Convert.ToInt32(strMinute) < 10)
                    strMinute = "0" + strMinute;
                lblTime.Text = strHour + ":" + strMinute;
            }

            timer1.Start();
            TimerBird.Start();

            string strSongName = classShowAlarm.strSong;
            Player.PlayStateChange +=
                new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(Player_PlayStateChange);
            Player.MediaError +=
                new WMPLib._WMPOCXEvents_MediaErrorEventHandler(Player_MediaError);
            Player.URL = Application.StartupPath + "/Data/AlarmMusic/" + strSongName + ".mp3";
            Player.controls.play();
            Player.settings.volume = 0;
            volumetimer = new Timer();
            volumetimer.Interval = 500;
            volumetimer.Tick += voltime;
            volumetimer.Start();

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
                    btnSnooze.Text = frmMain.Decryption(node.SelectSingleNode("btn1").InnerText);
                    btnClose.Text = frmMain.Decryption(node.SelectSingleNode("btn2").InnerText);
                    break;
                }
            }
            #endregion
        }

        private void btnSnooze_Click(object sender, EventArgs e)
        {
            iSnoozeTime = 60;
            Player.close();
            timer1.Stop();
            TimerBird.Stop();
            this.Hide();
            TimerDelay.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            XElement xeroot = XElement.Load(Application.StartupPath + "/Data/Alarm.xml");
            var orderedtabs = xeroot.Elements("Alarm")
                                  .OrderBy(xtab => (string)xtab.Element("Time"))
                                  .ToArray();
            xeroot.RemoveAll();
            foreach (XElement tab in orderedtabs)
                xeroot.Add(tab);
            xeroot.Save(Application.StartupPath + "/Data/Alarm.xml");

            if (strMute == "Yes")
            {
                device.AudioEndpointVolume.Mute = true;
            }
            device.AudioEndpointVolume.MasterVolumeLevelScalar = ((float)iVolume / 100.0f);
            volumetimer.Stop();
            Player.close();
            frmMain.strAlarmScan = "Yes";
            classShowAlarm.dDelayTime = -1;
            this.Close();
        }

        private void btnSnooze_MouseMove(object sender, MouseEventArgs e)
        {
            //btnSnooze.BackgroundImage = Image.FromFile("Resources/btnHover.png");
            //btnSnooze.BackgroundImage = btnBG.Images[1];
            btnSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnClose_MouseMove(object sender, MouseEventArgs e)
        {
            //btnClose.BackgroundImage = Image.FromFile("Resources/btnHover.png");
            //btnClose.BackgroundImage = btnBG.Images[1];
            btnClose.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnSnooze_MouseLeave(object sender, EventArgs e)
        {
            //btnSnooze.BackgroundImage = Image.FromFile("Resources/btnBG.png");
            //btnSnooze.BackgroundImage = btnBG.Images[0];
            btnSnooze.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            //btnClose.BackgroundImage = Image.FromFile("Resources/btnBG.png");
            //btnClose.BackgroundImage = btnBG.Images[0];
            btnClose.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        { 
            if (lblTime.ForeColor == Color.Black)
            {
                lblTime.ForeColor = Color.Red;
            }
            else
            {
                lblTime.ForeColor = Color.Black;
            }          
        }

        private void TimerBird_Tick(object sender, EventArgs e)
        {
            iXPos += 3;
            if (iXPos > lblTime.Size.Width + 20)
                iXPos = -20;

            if (iXPos > lblTime.Size.Width / 4 - 120)
            {
                if (iYPos == lblTime.Size.Height / 2 + 100)
                    iYPos += 0;
                else
                    iYPos += 1;
            }

            if (iXPos > lblTime.Size.Width * 3 / 4 - 240)
            {
                if (iYPos == lblTime.Size.Height / 2 - 20)
                    iYPos -= 0;
                else
                    iYPos -= 2;
            }

            lblBird.Location = new System.Drawing.Point(iXPos, iYPos);

            //lblBird.Image = Image.FromFile("Resources/Light/Light_" + iIC + ".png");
            //lblRed1.Image = Image.FromFile("Resources/Light/ScaleLightRed_" + iIC + ".png");
            //lblRed2.Image = Image.FromFile("Resources/Light/ScaleLightRed_" + iIC + ".png");
            //lblYellow1.Image = Image.FromFile("Resources/Light/ScaleLightYellow_" + iIC + ".png");
            //lblYellow2.Image = Image.FromFile("Resources/Light/ScaleLightYellow_" + iIC + ".png");

            //lblBird.Image = ListLightBlue.Images[iIC];
            //lblRed1.Image = ListLightRed.Images[iIC];
            //lblRed2.Image = ListLightRed.Images[iIC];
            //lblYellow1.Image = ListLightYellow.Images[iIC];
            //lblYellow2.Image = ListLightYellow.Images[iIC];

            lblBird.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Light.Light_" + iIC + ".png"));
            lblRed1.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Light.ScaleLightRed_" + iIC + ".png"));
            lblRed2.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Light.ScaleLightRed_" + iIC + ".png"));
            lblYellow1.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Light.ScaleLightYellow_" + iIC + ".png"));
            lblYellow2.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Light.ScaleLightYellow_" + iIC + ".png"));

            iIC++;
            if (iIC == 24)
                iIC = 0;
        }

        void voltime(object sender, EventArgs e)
        {
            Player.settings.volume += 2;
            if (Player.settings.volume == 100)
            {
                volumetimer.Stop();
            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPLib.WMPPlayState)NewState == WMPLib.WMPPlayState.wmppsStopped)
            {
                Player.controls.play();
            }
        }

        private void Player_MediaError(object pMediaObject)
        {
            //MessageBox.Show("Cannot play media file.");
        }

        private void TimerDelay_Tick(object sender, EventArgs e)
        {
            if (iSnoozeTime > 0)
            {
                iSnoozeTime--;
            }

            if (iSnoozeTime == 0)
            {
                TimerDelay.Stop();
                timer1.Start();
                TimerBird.Start();
                volumetimer.Start();
                Player.settings.volume = 0;
                lblTime.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
                Player.controls.play();
                classShowAlarm.strHideAll = "Yes";
                this.Show();
            }
        }
    }
}
