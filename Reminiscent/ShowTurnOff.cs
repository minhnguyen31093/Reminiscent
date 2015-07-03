using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml;

namespace Reminiscent
{
    public partial class frmShowTurnOff : Form
    {
        private Timer timer;
        private Timer timer2;
        private int startPosX;
        private int startPosY;
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        public static int iHour = 0;
        public static int iMinute = 0;
        public static int iSecond = 0;
        public static string strMode = "";
        [DllImport("user32")]
        public static extern void LockWorkStation();

        public frmShowTurnOff()
        {
            InitializeComponent();
            TopMost = true;
            // Pop doesn't need to be shown in task bar
            ShowInTaskbar = false;
            // Create and run timer for animation
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += timer_Tick;

            timer2 = new Timer();
            timer2.Interval = 10;
            timer2.Tick += timer_Tick2;
        }

        private void ShowRecurring_Load(object sender, EventArgs e)
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
                    btnAbort.Text = frmMain.Decryption(node.SelectSingleNode("btn").InnerText);
                    break;
                }
            }
            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            // Di chuyển form ra khỏi màn hình
            startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;
            startPosY = Screen.PrimaryScreen.WorkingArea.Height;
            SetDesktopLocation(startPosX, startPosY);
            base.OnLoad(e);
            // Begin animation
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY -= 5;
            //If window is fully visible stop the timer
            if (startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
            {
                timer.Stop();
                CountDown.Start();
                //System.Threading.Thread.Sleep(10000); // Chờ trong 10s
                //timer2.Start(); // Bắt đầu chạy ra khỏi màn hình.
            }
            else
                SetDesktopLocation(startPosX, startPosY);
        }

        //Mouse Hover, Down
        private void btnAbort_MouseDown(object sender, MouseEventArgs e)
        {
            btnAbort.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadChecked.png"));
        }

        private void btnAbort_MouseUp(object sender, MouseEventArgs e)
        {
            btnAbort.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
        }

        private void btnAbort_MouseHover(object sender, EventArgs e)
        {
            btnAbort.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadHover.png"));
        }

        private void btnAbort_MouseLeave(object sender, EventArgs e)
        {
            btnAbort.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.RadUnchecked.png"));
        }

        private void btnAbort_Click(object sender, EventArgs e)
        {
            timer2.Start();
            strMode = "";
        }

        //CountDown
        private void CountDown_Tick(object sender, EventArgs e)
        {
            if (iHour > 0 || iMinute > 0 || iSecond > 0)
            {
                if (iSecond == 0)
                {
                    iSecond = 59;

                    if (iMinute == 0)
                    {
                        iMinute = 59;

                        if (iHour == 0)
                        {
                            iHour = 23;
                        }

                        else
                        {
                            iHour--;
                        }
                    }

                    else
                    {
                        iMinute--;
                    }
                }

                else
                {
                    iSecond--;
                }

                string strTime = "";

                if (iHour < 10)
                    strTime = "0" + iHour.ToString() + ":";
                else
                    strTime = iHour.ToString() + ":";

                if (iMinute < 10)
                    strTime += "0" + iMinute.ToString() + ":";
                else
                    strTime += iMinute.ToString() + ":";

                if (iSecond < 10)
                    strTime += "0" + iSecond.ToString();
                else
                    strTime += iSecond.ToString();

                lblTime.Text = strTime;
            }

            else
            {
                CountDown.Stop();
                timer2.Start();
            }
        }

        void timer_Tick2(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            startPosY += 5;
            //If window is fully invisible close
            if (startPosY > Screen.PrimaryScreen.WorkingArea.Height)
            {
                if (strMode == "ShutDown")
                {
                    strMode = "";
                    Process.Start("shutdown", "/s /t 0");
                }

                if (strMode == "Restart")
                {
                    strMode = "";
                    Process.Start("shutdown", "/r /t 0");
                }

                if (strMode == "Logoff")
                {
                    strMode = "";
                    Process.Start("shutdown", "/l");
                }

                if (strMode == "Hibernate")
                {
                    strMode = "";
                    Application.SetSuspendState(PowerState.Hibernate, true, true);
                }

                if (strMode == "Lock")
                {
                    strMode = "";
                    LockWorkStation();
                }

                if (strMode == "Sleep")
                {
                    strMode = "";
                    Application.SetSuspendState(PowerState.Suspend, true, true);
                }

                timer2.Stop();
                this.Close();
            }
            else
            {
                SetDesktopLocation(startPosX, startPosY);
            }
        }
   }
}
