using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Globalization;
using System.Xml;
using System.Xml.Linq;
using System.Collections;
using System.IO;
using System.Reflection;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using OAuthProtocol;
using Dropbox.Api;
using System.Diagnostics;
using System.Threading;

namespace Reminiscent
{
    public partial class frmMain : Form
    {
        public static string strStartupPath = Application.StartupPath;
        frmIntro fIntro = new frmIntro();

        int flagRefresh = 0;

        Assembly myAssembly = Assembly.GetExecutingAssembly();
        public static string strRecurringID = "";
        public static string strRecurringName = "";
        public static string strRecurringDes = "";
        public static string strRecurringDate = "";
        public static string strRecurringTime = "";
        public static string strRecurringRepeat = "";
        
        public static string strRefeshUC = "No";
        public static string strAlarmScan = "Yes";

        public static int iPage = 0;
        public static int iMaxPage = 0;
        public static int iSearch = 0;
        public static int iTabChanged = 0;

        public static string strLanguage = "English";
        public static string strTheme = "Blue";

        public static string strDropBoxConnected = "No";

        UC_Recurring ucRecurring;
        UC_Idea ucIdea;
        UC_Schedule ucSchedule;
        UC_Clock ucAlarm;
        UC_Dictionary ucDictionary;
        UC_Favorite ucFavorite;
        //UC_FavoriteAudios ucFavoriteAudios;
        //UC_FavoriteVideos ucFavoriteVideos;
        UC_Sticky ucSticky;
        UC_Others ucOthers;
        UC_Account ucAccount;
        UC_Home ucHome;

        public frmMain()
        {
            InitializeComponent();
        }

        #region Kế thừa UC Recurring
        public frmMain(UC_Recurring ucRecurringLoad)
            : this()
        {
            this.ucRecurring = ucRecurringLoad;
        }
        #endregion

        #region Kế thừa UC Schedule
        public frmMain(UC_Schedule ucSchedulekLoad)
            : this()
        {
            this.ucSchedule = ucSchedulekLoad;
        }
        #endregion

        #region Kế thừa UC Clock
        public frmMain(UC_Clock ucClockLoad)
            : this()
        {
            this.ucAlarm = ucClockLoad;
        }
        #endregion

        #region Kế thừa UC Favorite
        public frmMain(UC_Favorite ucFavoriteLoad)
            : this()
        {
            this.ucFavorite = ucFavoriteLoad;
        }
        #endregion

        #region Kế thừa UC Favorite Audios
        //public frmMain(UC_FavoriteAudios ucFAudios)
        //    : this()
        //{
        //    this.ucFavoriteAudios = ucFAudios;
        //}
        #endregion

        #region Kế thừa UC Favorite Videos
        //public frmMain(UC_FavoriteVideos ucFVideos)
        //    : this()
        //{
        //    this.ucFavoriteVideos = ucFVideos;
        //}
        #endregion

        #region Kế thừa UC Sticky
        public frmMain(UC_Sticky ucStickyLoad)
            : this()
        {
            this.ucSticky = ucStickyLoad;
        }
        #endregion

        #region Kế thừa UC Account
        public frmMain(UC_Account ucAccountLoad)
            : this()
        {
            this.ucAccount = ucAccountLoad;
        }
        #endregion

        private const string ConsumerKey = "grfw90l3j74dw3a";
        private const string ConsumerSecret = "ivwxdm5jb5h1e7q";
        private static OAuthToken accessToken = null;

        public static OAuthToken GetAccessToken()
        {
            var oauth = new OAuth();
            var requestToken = oauth.GetRequestToken(new Uri(DropboxRestApi.BaseUri), ConsumerKey, ConsumerSecret);
            var authorizeUri = oauth.GetAuthorizeUri(new Uri(DropboxRestApi.AuthorizeBaseUri), requestToken);
            Process.Start(authorizeUri.AbsoluteUri);
            Thread.Sleep(5000); // Leave some time for the authorization step to complete
            return oauth.GetAccessToken(new Uri(DropboxRestApi.BaseUri), ConsumerKey, ConsumerSecret, requestToken);
        }

        public static void Upload()
        {
            if (strDropBoxConnected == "Yes")
            {
                try
                {
                    //var accessToken = GetAccessToken();            
                    var api = new DropboxApi(ConsumerKey, ConsumerSecret, accessToken);
                    var file = api.UploadFile("dropbox", "StickyNote.xml", Application.StartupPath + "/Data/StickyNote.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Upload StickyNote failed!");
                }
            }
        }

        public static void Download()
        {
            if (strDropBoxConnected == "Yes")
            {
                try
                {
                    //var accessToken = GetAccessToken();
                    var api = new DropboxApi(ConsumerKey, ConsumerSecret, accessToken);
                    var file = api.DownloadFile("dropbox", "StickyNote.xml");
                    file.Save(Application.StartupPath + "/Data/StickyNote.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Download StickyNote failed!");
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Do you want to reconnect to Dropbox?", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Connect();
                }
            }
        }

        public static void Connect()
        {
            try
            {
                strDropBoxConnected = "Yes";
                accessToken = GetAccessToken();
            }
            catch (Exception ex)
            {
                strDropBoxConnected = "No";
                MessageBox.Show("Connecting DropBox failed!");
            }
        }

        #region Page Load
        private void frmMain_Load(object sender, EventArgs e)
        {
            Connect();
            Download();

            //this.WindowState = FormWindowState.Minimized;
            ////this.Hide();
            //fIntro.Show();  

            #region Chế độ hiển thị khi khởi động chương trình

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Application.StartupPath + "/Config.xml");

                XmlElement ele = doc.DocumentElement;
                XmlNodeList TaskList = ele.GetElementsByTagName("DS_Config");

                notifyIcon.Visible = false;

                for (int i = 0; i < TaskList.Count; i++)
                {
                    strLanguage = Decryption(TaskList[i].ChildNodes[2].InnerText);
                    strTheme = Decryption(TaskList[i].ChildNodes[3].InnerText);
                    if (Decryption(TaskList[i].ChildNodes[0].InnerText) == "True" && Decryption(TaskList[i].ChildNodes[1].InnerText) == "Mini")
                    {
                        this.WindowState = FormWindowState.Minimized;
                        this.ShowInTaskbar = false;
                        notifyIcon.Visible = true;
                    }
                    else
                    {
                        notifyIcon.Visible = false;
                    }

                    if (Decryption(TaskList[i].ChildNodes[5].InnerText) == "Yes")
                    {
                        frmTaskOfTheDay totd = new frmTaskOfTheDay();
                        totd.Show();
                    }
                }
            }
            catch
            {
                //if (File.Exists(Application.StartupPath + "/Config.xml"))
                //{
                //    File.Delete("Config.xml.bk");
                //    File.Copy(Application.StartupPath + "/Config.xml", "Config.xml.bk");
                //    File.Delete(Application.StartupPath + "/Config.xml");
                //}

                //XmlTextWriter writer = new XmlTextWriter(Application.StartupPath + "/Config.xml", Encoding.UTF8);
                //writer.Formatting = Formatting.Indented;
                ////Create XML
                //writer.WriteStartDocument();
                ////Create Root
                //writer.WriteStartElement("Config");
                //writer.WriteEndElement();
                //writer.WriteEndDocument();
                //writer.Flush();
                //writer.Close();

                if (File.Exists(Application.StartupPath + "/Config.xml"))
                {
                    File.Delete(Application.StartupPath + "/Config.xml");
                }

                using (FileStream fileStream = File.Create(Application.StartupPath + "/Config.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Config.xml").CopyTo(fileStream);
                }

                MessageBox.Show("Your config database have been corrupted! \n\n It have been backup and created a new one.", "Warring", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            #endregion

            timerMain.Start();

            classShowSticky.Load();

            #region Language

            if (!Directory.Exists(Application.StartupPath + "/Language"))
            {
                Directory.CreateDirectory(Application.StartupPath + "/Language");
            }
            if (!File.Exists(Application.StartupPath + "/Language/Language-English.xml"))
            {
                using (FileStream fileStream = File.Create(Application.StartupPath + "/Language/Language-English.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Language-English.xml").CopyTo(fileStream);
                }
            }
            if (!File.Exists(Application.StartupPath + "/Language/Language-Vietnamese.xml"))
            {
                using (FileStream fileStream = File.Create(Application.StartupPath + "/Language/Language-Vietnamese.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Language-Vietnamese.xml").CopyTo(fileStream);
                }
            }
            
            XmlDocument xmlDocLng = new XmlDocument();
            if (strLanguage == "English")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-English.xml");
            }
            else if (strLanguage == "Vietnamese")
            {
                xmlDocLng.Load(Application.StartupPath + "/Language/Language-Vietnamese.xml");
            }

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                try
                {
                    if (Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                    {
                        //MenuStrip
                        fileToolStripMenuItem.Text = Decryption(node.SelectSingleNode("MenuStrip").SelectSingleNode("Item1").SelectSingleNode("ItemName").InnerText);
                        importToolStripMenuItem.Text = Decryption(node.SelectSingleNode("MenuStrip").SelectSingleNode("Item1").SelectSingleNode("Child1").InnerText);
                        exportToolStripMenuItem.Text = Decryption(node.SelectSingleNode("MenuStrip").SelectSingleNode("Item1").SelectSingleNode("Child2").InnerText);
                        optionToolStripMenuItem.Text = Decryption(node.SelectSingleNode("MenuStrip").SelectSingleNode("Item1").SelectSingleNode("Child3").InnerText);
                        exitToolStripMenuItem.Text = Decryption(node.SelectSingleNode("MenuStrip").SelectSingleNode("Item1").SelectSingleNode("Child4").InnerText);

                        //ToolStrip
                        tsbtnRecurring.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn1").InnerText);
                        tsbtnIdea.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn2").InnerText);
                        tsbtnSchedule.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn3").InnerText);
                        tsbtnAlarm.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn4").InnerText);
                        tsbtnDictionary.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn5").InnerText);
                        tsbtnFavorite.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn6").InnerText);
                        tsbtnSticky.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn7").InnerText);
                        tsbtnAccount.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn8").InnerText);
                        tsbtnOthers.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn9").InnerText);
                        tsbtnRefesh.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn10").InnerText);
                        tsbtnToday.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn11").InnerText);
                        tsbtnSearch.Text = Decryption(node.SelectSingleNode("ToolStrip").SelectSingleNode("btn12").InnerText);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex + " " + node.SelectSingleNode("Name").InnerText);
                }
            }

            #endregion

            #region Theme
            if (!Directory.Exists(Application.StartupPath + "/Theme"))
            {
                Directory.CreateDirectory(Application.StartupPath + "/Theme");
            }
            if (!File.Exists(Application.StartupPath + "/Theme/Theme-Blue.xml"))
            {
                using (FileStream fileStream = File.Create(Application.StartupPath + "/Theme/Theme-Blue.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Theme-Blue.xml").CopyTo(fileStream);
                }
            }
            if (!File.Exists(Application.StartupPath + "/Theme/Theme-White.xml"))
            {
                using (FileStream fileStream = File.Create(Application.StartupPath + "/Theme/Theme-White.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Theme-White.xml").CopyTo(fileStream);
                }
            }
            if (!File.Exists(Application.StartupPath + "/Theme/Theme-Simple.xml"))
            {
                using (FileStream fileStream = File.Create(Application.StartupPath + "/Theme/Theme-Simple.xml"))
                {
                    myAssembly.GetManifestResourceStream("Reminiscent.Resources.XML.Theme-Simple.xml").CopyTo(fileStream);
                }
            }

            XmlDocument xmlDocTheme = new XmlDocument();
            if (strTheme == "Blue")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Blue.xml");
            }
            else if (strTheme == "White")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-White.xml");
            }
            else if (strTheme == "Simple")
            {
                xmlDocTheme.Load(Application.StartupPath + "/Theme/Theme-Simple.xml");
            }

            foreach (XmlNode node in xmlDocTheme.SelectNodes("Theme/Style"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == strTheme)
                {
                    int ibc11 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc11").InnerText));
                    int ibc12 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc12").InnerText));
                    int ibc13 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc13").InnerText));

                    int ibc21 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc21").InnerText));
                    int ibc22 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc22").InnerText));
                    int ibc23 = Convert.ToInt32(frmMain.Decryption(node.SelectSingleNode("bc23").InnerText));

                    menuStrip1.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
                    menuStrip1.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg4").InnerText)));

                    panelMenu.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
                    panelMenu.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg3").InnerText)));

                    panelContent.BackColor = Color.FromArgb(ibc11, ibc12, ibc13);
                    panelContent.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg1").InnerText)));

                    statusStrip.BackColor = Color.FromArgb(ibc21, ibc22, ibc23);
                    break;
                }
            }
            #endregion

            ucRecurring = new UC_Recurring();
            ucIdea = new UC_Idea();
            ucSchedule = new UC_Schedule();
            ucAlarm = new UC_Clock();
            ucDictionary = new UC_Dictionary();
            ucFavorite = new UC_Favorite();
            //ucFavoriteAudios = new UC_FavoriteAudios();
            //ucFavoriteVideos = new UC_FavoriteVideos();
            ucSticky = new UC_Sticky();
            ucOthers = new UC_Others();
            //ucAccount = new UC_Account();
            ucHome = new UC_Home();

            ucRecurring.Dock = DockStyle.Fill;
            ucIdea.Dock = DockStyle.Fill;
            ucAlarm.Dock = DockStyle.Fill;
            ucDictionary.Dock = DockStyle.Fill;
            ucFavorite.Dock = DockStyle.Fill;
            ucSticky.Dock = DockStyle.Fill;
            ucOthers.Dock = DockStyle.Fill;
            //ucAccount.Dock = DockStyle.Fill;
            ucHome.Dock = DockStyle.Fill;

            //tsbtnAccount_Click(sender, e);
            tsbtnAlarm_Click(sender, e);
            tsbtnDictionary_Click(sender, e);
            tsbtnFavorite_Click(sender, e);
            tsbtnIdea_Click(sender, e);
            tsbtnOthers_Click(sender, e);
            tsbtnRecurring_Click(sender, e);
            tsbtnSchedule_Click(sender, e);
            tsbtnSticky_Click(sender, e);
            tsbtnToday_Click(sender, e);

            Calendar frmCalendar = new Calendar();
            frmCalendar.Show();
        }
        #endregion

        #region Main Timer
        private void timer_Tick(object sender, EventArgs e)
        {
            //if (frmIntro.iTime == 7)
            //{
            //    fIntro.Close();
            //    this.WindowState = FormWindowState.Normal;
            //    //this.Show();
            //}

            timerMain.Interval = 1000;
            toolStripStatusTime.Text = DateTime.Now.ToLongDateString() + " - " + DateTime.Now.ToLongTimeString();

            if (File.Exists(Application.StartupPath + "/Data/Recurring.xml"))
            {
                #region Kiểm tra công việc, hiện thông báo nhắc nhở (code xịn)

                classShowRecurring.Load();

                if (classShowRecurring.dDelayTime == 0)
                {
                    classShowRecurring.Save();
                }

                if (classShowRecurring.dDelayTime > 0)
                {
                    classShowRecurring.dDelayTime--;
                }

                if (classShowRecurring.strTimeMain == "Stop")
                {
                    timerMain.Stop();
                }

                if (classShowRecurring.strTimeMain == "Start")
                {
                    timerMain.Start();
                }

                if (classShowRecurring.strRefresh == "Yes")
                {
                    this.ucRecurring.LoadListView();
                    classShowRecurring.strRefresh = "No";
                }
                #endregion
            }

            #region Alarm

            #region Checked???
            if (DateTime.Now.Hour == 0)
            {
                strAlarmScan = "Yes";
            }
            #endregion

            if (File.Exists(Application.StartupPath + "/Data/Alarm.xml") && classShowAlarm.dDelayTime == -1 && strAlarmScan == "Yes")
            {
                classShowAlarm.Load();
                strAlarmScan = "No";
            }

            if (classShowAlarm.dDelayTime == 0)
            {
                classShowAlarm.Save();
                strAlarmScan = "Yes";
            }

            if (classShowAlarm.dDelayTime > 0)
            {
                classShowAlarm.dDelayTime--;
            }

            if (classShowAlarm.strTimer == "stop")
            {
                timerMain.Stop();
            }

            if (classShowAlarm.strTimer == "start")
            {
                timerMain.Start();
            }

            if (classShowAlarm.strHideAll == "Yes")
            {
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Text != "ShowAlarm"){
                        frm.WindowState = FormWindowState.Minimized;
                    }
                }
                classShowAlarm.strHideAll = "No";
            }
            #endregion

            if (strRefeshUC == "Yes")
            {
                if (flagRefresh == 3)
                    this.ucSchedule.LoadListView();
                else if (flagRefresh == 7)
                    this.ucSticky.LoadListView();
                strRefeshUC = "No";
            }

            if (iTabChanged == 1)
            {
                FavoriteTabChanged();
                iTabChanged = 0;
            }
        }
        #endregion

        #region Tool strip button

        #region Recurring

        private void tsbtnRecurring_Click(object sender, EventArgs e)
        {
            tscboSearch.Items.Clear();
            tscboSearch.Items.Add("Search by Name");
            tscboSearch.Items.Add("Search by Date");
            tscboSearch.Items.Add("Search by Time");

            iSearch = 0;

            ucRecurring = new UC_Recurring();
            flagRefresh = 1;

            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucRecurring);
            }
            else
            {
                panelContent.Controls.Add(ucRecurring);
            }
            UC_Recurring.Sort();
        }
        #endregion

        #region Idea
        private void tsbtnIdea_Click(object sender, EventArgs e)
        {
            iSearch = 0;

            tscboSearch.Items.Clear();
            tscboSearch.Items.Add("Search by Name");
            tscboSearch.Items.Add("Search by Date");
            tscboSearch.Items.Add("Search by Description");

            flagRefresh = 2;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucIdea);
            }
            else
            {
                panelContent.Controls.Add(ucIdea);
            }

        }
        #endregion

        #region Schedule
        private void tsbtnSchedule_Click(object sender, EventArgs e)
        {
            iPage = 0;
            iSearch = 0;
            flagRefresh = 3;
            tscboSearch.Items.Clear();

            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucSchedule);
            }
            else
            {
                panelContent.Controls.Add(ucSchedule);
            }

            tscboSearch.Items.Clear();
            tscboSearch.Items.Add("Search by Project");
            tscboSearch.Items.Add("Search by Abstract");
        }
        #endregion

        #region Clock
        private void tsbtnAlarm_Click(object sender, EventArgs e)
        {
            iPage = 0;
            iSearch = 0;
            //ucAlarm = new UC_Clock();
            flagRefresh = 4;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucAlarm);
            }
            else
            {
                panelContent.Controls.Add(ucAlarm);
            }

            tscboSearch.Items.Clear();
            tscboSearch.Items.Add("Search by Name");
            tscboSearch.Items.Add("Search by Time");
            tscboSearch.Items.Add("Search by Repeat");
        }
        #endregion

        #region Dictionary
        private void tsbtnDictionary_Click(object sender, EventArgs e)
        {
            iSearch = 0;
            flagRefresh = 5;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucDictionary);
            }
            else
            {
                panelContent.Controls.Add(ucDictionary);
            }
            tscboSearch.Items.Clear();
        }
        #endregion

        #region Favorite
        private void tsbtnFavorite_Click(object sender, EventArgs e)
        {
            iSearch = 0;
            if (flagRefresh != 6)
            {
                if (panelContent.Controls.Count > 1)
                {
                    panelContent.Controls.RemoveAt(1);
                    panelContent.Controls.Add(ucFavorite);
                }
                else
                {
                    panelContent.Controls.Add(ucFavorite);
                }
            }
            flagRefresh = 6;
            FavoriteTabChanged();
        }

        void FavoriteTabChanged()
        {
            iPage = 0;
            tscboSearch.Items.Clear();
            if (flagRefresh == 6 && UC_Favorite.iTabindex == 0)
            {
                tscboSearch.Items.Add("Search by Date");
                tscboSearch.Items.Add("Search by Text");
            }
            else if (flagRefresh == 6 && 
                (UC_Favorite.iTabindex == 1 || 
                UC_Favorite.iTabindex == 2 ||
                UC_Favorite.iTabindex == 3 || 
                UC_Favorite.iTabindex == 5))
            {
                tscboSearch.Items.Add("Search by Name");
                tscboSearch.Items.Add("Search by Location");
            }
            else if (flagRefresh == 6 && UC_Favorite.iTabindex == 4)
            {
                tscboSearch.Items.Add("Search by Name");
                tscboSearch.Items.Add("Search by Type");
                tscboSearch.Items.Add("Search by Size");
                tscboSearch.Items.Add("Search by Location");
            }
            else if (flagRefresh == 6 && UC_Favorite.iTabindex == 6)
            {
                tscboSearch.Items.Add("Search by Title");
                tscboSearch.Items.Add("Search by Address");
            }
        }
        #endregion

        #region Sticky
        private void tsbtnSticky_Click(object sender, EventArgs e)
        {
            iPage = 0;
            iSearch = 0;
            flagRefresh = 7;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucSticky);
            }
            else
            {
                panelContent.Controls.Add(ucSticky);
            }

            tscboSearch.Items.Clear();
            tscboSearch.Items.Add("Search by Date");
            tscboSearch.Items.Add("Search by Note");
        }
        #endregion

        #region Account
        public static bool bLogIn = false;
        private void tsbtnAccount_Click(object sender, EventArgs e)
        {
            ConfirmPassword cf = new ConfirmPassword();
            cf.ShowDialog();

            if (bLogIn == true)
            {
                ucAccount = new UC_Account();
                ucAccount.Dock = DockStyle.Fill;
                iPage = 0;
                iSearch = 0;
                flagRefresh = 8;
                if (panelContent.Controls.Count > 1)
                {
                    panelContent.Controls.RemoveAt(1);
                    panelContent.Controls.Add(ucAccount);
                }
                else
                {
                    panelContent.Controls.Add(ucAccount);
                }
                tscboSearch.Items.Clear();
                tscboSearch.Items.Add("Search by Type");
                tscboSearch.Items.Add("Search by Amount");
                tscboSearch.Items.Add("Search by Date");
                tscboSearch.Items.Add("Search by Reason");
            }
        }
        #endregion

        #region Others
        private void tsbtnOthers_Click(object sender, EventArgs e)
        {
            iSearch = 0;
            flagRefresh = 9;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucOthers);
            }
            else
            {
                panelContent.Controls.Add(ucOthers);
            }
            tscboSearch.Items.Clear();
        }
        #endregion

        #region Refesh
        private void tsbtnRefesh_Click(object sender, EventArgs e)
        {
            UC_Recurring.Sort();

            if (panelContent.Controls.Count > 1 && flagRefresh != 7)
                panelContent.Controls.RemoveAt(1); // 1 = UC_HienTai ; 0 = Status Strip

            if (flagRefresh == 1)
            {
                ucRecurring = new UC_Recurring();
                panelContent.Controls.Add(ucRecurring);
            }

            if (flagRefresh == 2)
            {
                panelContent.Controls.Add(ucIdea);
            }

            if (flagRefresh == 3)
            {
                this.ucSchedule.LoadListView();
            }

            if (flagRefresh == 4)
            {
                ucAlarm = new UC_Clock();
                panelContent.Controls.Add(ucAlarm);
            }

            if (flagRefresh == 5)
            {
                panelContent.Controls.Add(ucDictionary);
            }

            if (flagRefresh == 6)
            {
                panelContent.Controls.Add(ucFavorite);
            }

            if (flagRefresh == 7)
            {
                Download();
                this.ucSticky.LoadListView();
            }

            if (flagRefresh == 8)
            {
                tsbtnAccount_Click(sender, e);
            }

            if (flagRefresh == 9)
            {
                
            }
        }
        #endregion

        #region Home
        private void tsbtnToday_Click(object sender, EventArgs e)
        {
            flagRefresh = 10;
            if (panelContent.Controls.Count > 1)
            {
                panelContent.Controls.RemoveAt(1);
                panelContent.Controls.Add(ucHome);
            }
            else
            {
                panelContent.Controls.Add(ucHome);
            }
            tscboSearch.Items.Clear();
        }
        #endregion

        #region Up
        private void tsbtnUp_Click(object sender, EventArgs e)
        {
            if (flagRefresh == 3)//Schedule
            {
                ucSchedule.PageUp();
            }

            if (flagRefresh == 4)//Alarm
            {
                this.ucAlarm.PgUp();
                if (iPage > 0)
                    iPage -= 40;
                else
                    iPage = 0;
            }

            if (flagRefresh == 6)//Favorite
            {
                if (UC_Favorite.iTabindex == 0)
                {
                    this.ucFavorite.PgUp0();
                    if (iPage > 0)
                        iPage -= 8;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 1)
                {
                    this.ucFavorite.PgUp1();
                    if (iPage > 0)
                        iPage -= 40;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 2)
                {
                    this.ucFavorite.PgUp2();
                    if (iPage > 0)
                        iPage -= 32;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 3)
                {
                    this.ucFavorite.PgUp3();
                    if (iPage > 0)
                        iPage -= 40;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 4)
                {
                    this.ucFavorite.PgUp4();
                    if (iPage > 0)
                        iPage -= 40;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 5)
                {
                    this.ucFavorite.PgUp5();
                    if (iPage > 0)
                        iPage -= 40;
                    else
                        iPage = 0;
                }
                else if (UC_Favorite.iTabindex == 6)
                {
                    this.ucFavorite.PgUp6();
                    if (iPage > 0)
                        iPage -= 8;
                    else
                        iPage = 0;
                }
            }

            if (flagRefresh == 7)//Sticky Notes
            {
                this.ucSticky.PgUp();
                if(iPage > 0)
                    iPage -= 44;
                else
                    iPage = 0;
            }

            if (flagRefresh == 8)//Account
            {
                this.ucAccount.PgUp();
                if (iPage > 0)
                    iPage -= 16;
                else
                    iPage = 0;
            }
        }
        #endregion

        #region Down
        private void tsbtnDown_Click(object sender, EventArgs e)
        {
            if (flagRefresh == 3)//Schedule
            {
                ucSchedule.PageDown();
            }

            if (flagRefresh == 4)//Alarm
            {
                if (iPage == 0)
                    iPage += 40;
                this.ucAlarm.PgDn();
                if (iPage < iMaxPage)
                    iPage += 40;
                else
                    iPage = iMaxPage;
            }

            if (flagRefresh == 6)//Favorite
            {
                if (UC_Favorite.iTabindex == 0)
                {
                    if (iPage == 0)
                        iPage += 8;
                    this.ucFavorite.PgDn0();
                    if (iPage < iMaxPage)
                        iPage += 8;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 1)
                {
                    if (iPage == 0)
                        iPage += 40;
                    this.ucFavorite.PgDn1();
                    if (iPage < iMaxPage)
                        iPage += 40;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 2)
                {
                    if (iPage == 0)
                        iPage += 32;
                    this.ucFavorite.PgDn2();
                    if (iPage < iMaxPage)
                        iPage += 32;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 3)
                {
                    if (iPage == 0)
                        iPage += 40;
                    this.ucFavorite.PgDn3();
                    if (iPage < iMaxPage)
                        iPage += 40;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 4)
                {
                    if (iPage == 0)
                        iPage += 40;
                    this.ucFavorite.PgDn4();
                    if (iPage < iMaxPage)
                        iPage += 40;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 5)
                {
                    if (iPage == 0)
                        iPage += 40;
                    this.ucFavorite.PgDn5();
                    if (iPage < iMaxPage)
                        iPage += 40;
                    else
                        iPage = iMaxPage;
                }
                else if (UC_Favorite.iTabindex == 6)
                {
                    if (iPage == 0)
                        iPage += 8;
                    this.ucFavorite.PgDn6();
                    if (iPage < iMaxPage)
                        iPage += 8;
                    else
                        iPage = iMaxPage;
                }
            }

            if (flagRefresh == 7)//Sticky Notes
            {
                if (iPage == 0)
                    iPage += 44;
                this.ucSticky.PgDn();
                if (iPage < iMaxPage)
                    iPage += 44;
                else
                    iPage = iMaxPage;
            }

            if (flagRefresh == 8)//Account
            {
                if (iPage == 0)
                    iPage += 16;
                this.ucAccount.PgDn();
                if (iPage < iMaxPage)
                    iPage += 16;
                else
                    iPage = iMaxPage;
            }
        }
        #endregion

        #region Select Search
        private void tscboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tscboSearch.SelectedIndex > -1)
                iSearch = 0;
        }
        #endregion

        #region Search
        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            if (tstxtSearch.Text != "" && tscboSearch.SelectedIndex != -1)
            {
                if (flagRefresh == 1) // Recurring
                {
                    this.ucRecurring.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }

                if (flagRefresh == 2) // Idea
                {
                    this.ucIdea.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }

                if (flagRefresh == 3)//Schedule
                {
                    this.ucSchedule.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }

                if (flagRefresh == 4)//Alarm
                {
                    this.ucAlarm.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }

                if (flagRefresh == 6)//Favorite
                {
                    if (UC_Favorite.iTabindex == 0)
                    {
                        this.ucFavorite.Search0(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 1)
                    {
                        this.ucFavorite.Search1(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 2)
                    {
                        this.ucFavorite.Search2(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 3)
                    {
                        this.ucFavorite.Search3(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 4)
                    {
                        this.ucFavorite.Search4(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 5)
                    {
                        this.ucFavorite.Search5(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                    else if (UC_Favorite.iTabindex == 6)
                    {
                        this.ucFavorite.Search6(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                    }
                }
                
                if (flagRefresh == 7)//Sticky Notes
                {
                    this.ucSticky.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }

                if (flagRefresh == 8)//Account
                {
                    this.ucAccount.Search(tstxtSearch.Text, tscboSearch.Text.Substring(tscboSearch.Text.LastIndexOf(' ') + 1));
                }
            }
        }
        #endregion

        #endregion

        #region Menu--------------------------------------------------------------------------------------------
        private void stickyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStickyNote sn = new frmStickyNote();
            sn.Show();
        }

        private void recurringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewRecurring nr = new frmNewRecurring();
            nr.ShowDialog();
        }

        private void optionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hiện form Option
            frmOption op = new frmOption();
            op.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Tray
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon.BalloonTipText = "Program still working. Click icon in system tray to open!";
                notifyIcon.BalloonTipTitle = "My Recurring";
                notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(7000);
                this.Hide();
            }
            else
            {
                notifyIcon.Visible = false;
                this.ShowInTaskbar = true;
            }
        }
        
        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            tsmOpen_Click(sender, e);
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            tsmOpen_Click(sender, e);
        }
        #endregion

        private void tsmOpen_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            //System.Threading.Thread.Sleep(1);
            //this.TopMost = false;
        }

        private void tsmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private int GetMaxDay(int iMonth, int iYear) //Lấy ngày cuối cùng của tháng
        {
            int iDay = DateTime.DaysInMonth(iYear, iMonth);
            return iDay;
        }

        #region CheckedChanged
        private void tsbtnRecurring_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnRecurring.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;

                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnRecurring.Checked = true;
            }
        }

        private void tsbtnIdea_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnIdea.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnIdea.Checked = true;
            }
        }

        private void tsbtnSchedule_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnSchedule.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnSchedule.Checked = true;
            }
        }

        private void tsbtnAlarm_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnAlarm.Checked)
            {
                tsbtnAccount.Checked = false;
                
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnAlarm.Checked = true;
            }
        }

        private void tsbtnDictionary_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnDictionary.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnDictionary.Checked = true;
            }
        }

        private void tsbtnFavorite_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnFavorite.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnFavorite.Checked = true;
            }
        }

        private void tsbtnSticky_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnSticky.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;

                tsbtnToday.Checked = false;

                tsbtnSticky.Checked = true;
            }
        }

        private void tsbtnAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnAccount.Checked)
            {
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnAccount.Checked = true;
            }
        }

        private void tsbtnOthers_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnOthers.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;

                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;
                tsbtnToday.Checked = false;

                tsbtnOthers.Checked = true;
            }
        }

        private void tsbtnToday_CheckedChanged(object sender, EventArgs e)
        {
            if (tsbtnToday.Checked)
            {
                tsbtnAccount.Checked = false;
                tsbtnAlarm.Checked = false;
                tsbtnDictionary.Checked = false;
                tsbtnFavorite.Checked = false;
                tsbtnIdea.Checked = false;
                tsbtnOthers.Checked = false;
                tsbtnRecurring.Checked = false;
                tsbtnSchedule.Checked = false;
                tsbtnSticky.Checked = false;

                tsbtnToday.Checked = true;
            }
        }
        #endregion

        private void toolStrip2_Paint(object sender, PaintEventArgs e)
        {
            Color cbBorderColor = Color.Black;
            Pen cbBorderPen = new Pen(SystemColors.Window);
            Rectangle rcbo = new Rectangle(
            tscboSearch.ComboBox.Location.X - 1,
            tscboSearch.ComboBox.Location.Y - 1,
            tscboSearch.ComboBox.Size.Width + 1,
            tscboSearch.ComboBox.Size.Height + 1);

            Rectangle rtxt = new Rectangle(
            tstxtSearch.TextBox.Location.X - 1,
            tstxtSearch.TextBox.Location.Y - 1,
            tstxtSearch.TextBox.Size.Width + 1,
            tstxtSearch.TextBox.Size.Height + 1);
            
            cbBorderPen.Color = cbBorderColor;
            e.Graphics.DrawRectangle(cbBorderPen, rcbo);
            e.Graphics.DrawRectangle(cbBorderPen, rtxt);
        }

        #region Set hotkey to button\\
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F3))
            {
                tsbtnSearch.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        #endregion

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExport Ex = new frmExport();
            Ex.ShowDialog();
        }

        #region Import

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofd.Filter = "Zip File|*.zip";
            ofd.Title = "Import file zip";
            ofd.FileName = "";
            ofd.ShowDialog();

            string strFileName = "";
            strFileName = ofd.FileName;

            if (strFileName != "")
                ExtractZipFile(strFileName, "Null", Application.StartupPath + "/Data");
        }

        public void ExtractZipFile(string archiveFilenameIn, string password, string outFolder)
        {
            ZipFile zf = null;
            try
            {
                FileStream fs = File.OpenRead(archiveFilenameIn);
                zf = new ZipFile(fs);
                if (!String.IsNullOrEmpty(password))
                {
                    zf.Password = password;     // AES encrypted entries are handled automatically
                }
                foreach (ZipEntry zipEntry in zf)
                {
                    if (!zipEntry.IsFile)
                    {
                        continue;           // Ignore directories
                    }
                    String entryFileName = zipEntry.Name;
                    // to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
                    // Optionally match entrynames against a selection list here to skip as desired.
                    // The unpacked length is available in the zipEntry.Size property.

                    byte[] buffer = new byte[4096];     // 4K is optimum
                    Stream zipStream = zf.GetInputStream(zipEntry);

                    // Manipulate the output filename here as desired.
                    String fullZipToPath = Path.Combine(outFolder, entryFileName);
                    string directoryName = Path.GetDirectoryName(fullZipToPath);
                    if (directoryName.Length > 0)
                        Directory.CreateDirectory(directoryName);

                    // Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
                    // of the file, but does not waste memory.
                    // The "using" will close the stream even if an exception occurs.
                    using (FileStream streamWriter = File.Create(fullZipToPath))
                    {
                        StreamUtils.Copy(zipStream, streamWriter, buffer);
                    }
                }
            }
            finally
            {
                if (zf != null)
                {
                    zf.IsStreamOwner = true; // Makes close also shut the underlying stream
                    zf.Close(); // Ensure we release resources
                }
            }
        }

        #endregion

        #region Mã hóa + giải mã

        public static string Encryption(string strSource)
        {
            var bytes = System.Text.Encoding.Unicode.GetBytes(strSource);
            var base64 = System.Convert.ToBase64String(bytes);
            return base64;
        }

        public static string Decryption(string strSource)
        {
            var bytes = System.Convert.FromBase64String(strSource);
            var strChuoi = System.Text.UnicodeEncoding.Unicode.GetString(bytes);
            return strChuoi;
        }

        #endregion
    }
}
