using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using Microsoft.Win32;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace Reminiscent
{
    public partial class frmOption : Form
    {
        public frmOption()
        {
            InitializeComponent();
        }

        Assembly myAssembly = Assembly.GetExecutingAssembly();
        public static int iFlagStartup;
        string strOriginalLanguage = "";
        string strOriginalTheme = "";

        string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern; // Lấy định dạng của hệ thống

        private void Option_Load(object sender, EventArgs e)
        {
            #region Language

            XmlDocument xmlDocLng = new XmlDocument();
            if (frmMain.strLanguage == "English")
            {
                cbxAfterWindowsStart.Items.Add("Stay minimized");
                cbxAfterWindowsStart.Items.Add("Always show main window");

                xmlDocLng.Load(Application.StartupPath + "/Language/Language-English.xml");
            }
            else if (frmMain.strLanguage == "Vietnamese")
            {
                cbxAfterWindowsStart.Items.Add("Thu nhỏ vào hệ thống");
                cbxAfterWindowsStart.Items.Add("Hiển thị trên màn hình chính");

                xmlDocLng.Load(Application.StartupPath + "/Language/Language-Vietnamese.xml");
            }

            foreach (XmlNode node in xmlDocLng.SelectNodes("Language/Form"))
            {
                if (frmMain.Decryption(node.SelectSingleNode("Name").InnerText) == this.Name)
                {
                    this.Text = frmMain.Decryption(node.SelectSingleNode("Text").InnerText);

                    tabSystem.Text = frmMain.Decryption(node.SelectSingleNode("tab1").InnerText);
                    tabAppearance.Text = frmMain.Decryption(node.SelectSingleNode("tab2").InnerText);
                    tabAccount.Text = frmMain.Decryption(node.SelectSingleNode("tab3").InnerText);

                    ckbxStartup.Text = frmMain.Decryption(node.SelectSingleNode("chk1").InnerText);
                    cbxAutorun.Text = frmMain.Decryption(node.SelectSingleNode("chk2").InnerText);

                    label2.Text = frmMain.Decryption(node.SelectSingleNode("des2").InnerText);

                    groupBox1.Text = frmMain.Decryption(node.SelectSingleNode("gb1").InnerText);
                    groupBox2.Text = frmMain.Decryption(node.SelectSingleNode("gb2").InnerText);

                    label3.Text = frmMain.Decryption(node.SelectSingleNode("cbo1").InnerText);
                    label4.Text = frmMain.Decryption(node.SelectSingleNode("cbo2").InnerText);
                    label5.Text = frmMain.Decryption(node.SelectSingleNode("cbo3").InnerText);

                    label6.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    label7.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    label8.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);

                    radDaily.Text = frmMain.Decryption(node.SelectSingleNode("radDaily").InnerText);
                    radWeekly.Text = frmMain.Decryption(node.SelectSingleNode("radWeekly").InnerText);
                    radMonthly.Text = frmMain.Decryption(node.SelectSingleNode("radMonthly").InnerText);
                    radOnce.Text = frmMain.Decryption(node.SelectSingleNode("radOneTime").InnerText);
                    cbxTOTD.Text = frmMain.Decryption(node.SelectSingleNode("totd").InnerText);

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
                    tabSystem.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg5").InnerText)));
                    tabAppearance.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg5").InnerText)));
                    tabAccount.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream(frmMain.Decryption(node.SelectSingleNode("bg5").InnerText)));
                    break;
                }
            }
            #endregion

            cbxLanguage.Items.Add("English");
            cbxLanguage.Items.Add("Vietnamese");

            cbxTheme.Items.Add("Simple");
            cbxTheme.Items.Add("Blue");
            cbxTheme.Items.Add("White");

            if (ckbxStartup.Checked)
                cbxAfterWindowsStart.Enabled = true;
            else
                cbxAfterWindowsStart.Enabled = false;

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Config.xml");
                XmlElement root = xmlDoc.DocumentElement;

                string strStartup = frmMain.Decryption(root.ChildNodes[0].ChildNodes[0].InnerText);
                string strAfterStart = frmMain.Decryption(root.ChildNodes[0].ChildNodes[1].InnerText);
                string strLanguage = frmMain.Decryption(root.ChildNodes[0].ChildNodes[2].InnerText);
                string strTheme = frmMain.Decryption(root.ChildNodes[0].ChildNodes[3].InnerText);
                string strUpdate = frmMain.Decryption(root.ChildNodes[0].ChildNodes[4].InnerText);
                string strTOTD = frmMain.Decryption(root.ChildNodes[0].ChildNodes[5].InnerText);
                string strRepeat = frmMain.Decryption(root.ChildNodes[0].ChildNodes[7].InnerText);
                string strTime = frmMain.Decryption(root.ChildNodes[0].ChildNodes[8].InnerText);
                string strDate = frmMain.Decryption(root.ChildNodes[0].ChildNodes[9].InnerText);

                dtpTime.Text = strTime;
                //dtpDate.Value = DateTime.ParseExact(strDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                dtpDate.Value = DateTime.Now;

                if (strRepeat == "Daily")
                    radDaily.Checked = true;
                else
                    if (strRepeat == "Weekly")
                        radWeekly.Checked = true;
                    else
                        if (strRepeat == "Monthly")
                            radMonthly.Checked = true;
                        else
                            if (strRepeat == "One Time")
                                radOnce.Checked = true;

                if (strTOTD == "Yes")
                    cbxTOTD.Checked = true;
                else
                    cbxTOTD.Checked = false;

                if (strStartup == "True")
                    ckbxStartup.Checked = true;
                else
                    ckbxStartup.Checked = false;

                if (strUpdate == "True")
                    cbxAutorun.Checked = true;
                else
                    cbxAutorun.Checked = false;

                if (strAfterStart == "Mini")
                    cbxAfterWindowsStart.SelectedIndex = 0;
                else if (strAfterStart == "Full")
                    cbxAfterWindowsStart.SelectedIndex = 1;

                if (strLanguage == "English")
                {
                    cbxLanguage.SelectedIndex = 0;
                    frmMain.strLanguage = "English";
                }
                else if (strLanguage == "Vietnamese")
                {
                    cbxLanguage.SelectedIndex = 1;
                    frmMain.strLanguage = "Vietnamese";
                }

                if (strTheme == "Simple")
                {
                    cbxTheme.SelectedIndex = 0;
                    frmMain.strTheme = "Simple";
                }
                else if (strTheme == "Blue")
                {
                    cbxTheme.SelectedIndex = 1;
                    frmMain.strTheme = "Blue";
                }
                else if (strTheme == "White")
                {
                    cbxTheme.SelectedIndex = 2;
                    frmMain.strTheme = "White";
                }
            }
            catch
            {
            
            }

            strOriginalLanguage = cbxLanguage.Text;
            strOriginalTheme = cbxTheme.Text;
        }

        private string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();
            
            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        private string GetSHA512HashData(string data)
        {
            //create new instance of md5
            SHA512 sha1 = SHA512.Create();
            
            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        private bool ValidateSHA1HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetSHA512HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strStartup = "False";
            string strAfterStart = "Full";
            string strUpdate = "False";
            string strLanguage = "English";
            string strTheme = "Simple";
            string strTOTD = "Yes";
            string strRepeat = "";
            string strPass = "";
            string strTime = GetTime(dtpTime.Value);
            string strDate = GetDay(dtpDate.Value);

            bool berror = false;

            if (cbxAutorun.Checked == true && radDaily.Checked == false && radWeekly.Checked == false && radMonthly.Checked == false && radOnce.Checked == false)
                MessageBox.Show("You must select the repeat time!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (radDaily.Checked)
                    strRepeat = "Daily";
                else
                    if (radWeekly.Checked)
                        strRepeat = "Weekly";
                    else
                        if (radMonthly.Checked)
                            strRepeat = "Monthly";
                        else
                            if (radOnce.Checked)
                                strRepeat = "One Time";

                #region Hẹn giờ mở chương trình

                #region Xóa schedule task cũ

                ProcessStartInfo end = new ProcessStartInfo();

                end.Arguments = "/delete /tn AutoStartReminiscent /f";

                // Đường dẫn đầy đủ của ứng dụng
                end.FileName = @"C:\Windows\System32\schtasks.exe";

                // Quy định kiểu hiển thị của ứng dụng
                end.WindowStyle = ProcessWindowStyle.Hidden;
                end.CreateNoWindow = true;

                // Đợi ứng dụng thoát mới xử lý tiếp chương trình
                using (Process procAutoStart = Process.Start(end))
                {
                    procAutoStart.WaitForExit();
                }

                #endregion

                if (cbxAutorun.Checked)
                {
                    #region Tạo schedule task mới

                    string strArg = "";

                    // Lấy đường dẫn phần mềm Reminiscent đang chạy
                    string strTemp = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location.ToString() + "\"";

                    if (radOnce.Checked)
                        strArg = @"/create /sc once /tn AutoStartReminiscent /tr " + strTemp + " /st " + GetTime(dtpTime.Value) + " /sd " + GetDay(dtpDate.Value) + " /rl highest";
                    else
                        if (radDaily.Checked)
                            strArg = @"/create /sc daily /tn AutoStartReminiscent /tr " + strTemp + " /st " + GetTime(dtpTime.Value) + " /sd " + GetDay(dtpDate.Value) + " /rl highest";
                        else
                            if (radMonthly.Checked)
                                strArg = @"/create /sc monthly /tn AutoStartReminiscent /tr " + strTemp + " /st " + GetTime(dtpTime.Value) + " /sd " + GetDay(dtpDate.Value) + " /rl highest";
                            else
                                if (radWeekly.Checked)
                                    strArg = @"/create /sc weekly /tn AutoStartReminiscent /tr " + strTemp + " /st " + GetTime(dtpTime.Value) + " /sd " + GetDay(dtpDate.Value) + " /rl highest";
                    // Khởi tạo
                    ProcessStartInfo startAuto = new ProcessStartInfo();

                    startAuto.Arguments = strArg;

                    // Đường dẫn đầy đủ của ứng dụng
                    startAuto.FileName = Environment.SystemDirectory + "\\schtasks.exe";

                    // Quy định kiểu hiển thị của ứng dụng
                    startAuto.WindowStyle = ProcessWindowStyle.Hidden;
                    startAuto.CreateNoWindow = true;

                    // Đợi ứng dụng thoát mới xử lý tiếp chương trình
                    using (Process procAuto = Process.Start(startAuto))
                    {
                        procAuto.WaitForExit();
                    }

                    #endregion
                }

                #endregion

                if (cbxTOTD.Checked)
                {
                    strTOTD = "Yes";
                }
                else
                {
                    strTOTD = "No";
                }

                if (ckbxStartup.Checked == true)
                {
                    strStartup = "True";

                    #region Khởi động cùng windows

                    //RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

                    #region Xóa task cũ

                    ProcessStartInfo end2 = new ProcessStartInfo();

                    end2.Arguments = "/delete /tn LogonReminiscent /f";

                    // Đường dẫn đầy đủ của ứng dụng
                    end2.FileName = @"C:\Windows\System32\schtasks.exe";

                    // Quy định kiểu hiển thị của ứng dụng
                    end2.WindowStyle = ProcessWindowStyle.Hidden;
                    end2.CreateNoWindow = true;

                    // Đợi ứng dụng thoát mới xử lý tiếp chương trình
                    using (Process procDelLogOn = Process.Start(end2))
                    {
                        procDelLogOn.WaitForExit();
                    }
                    //rkApp.DeleteValue("Reminiscent", false);

                    #endregion

                    #region Tạo task mới

                    if (ckbxStartup.Checked)
                    {
                        string strTemp = "\"" + System.Reflection.Assembly.GetExecutingAssembly().Location.ToString() + "\"";

                        string strArg = @"/create /tn LogonReminiscent /tr " + strTemp + " /sc onlogon /rl highest";
                        ProcessStartInfo startLogOn = new ProcessStartInfo();

                        startLogOn.Arguments = strArg;

                        // Đường dẫn đầy đủ của ứng dụng
                        startLogOn.FileName = Environment.SystemDirectory + "\\schtasks.exe";

                        // Quy định kiểu hiển thị của ứng dụng
                        startLogOn.WindowStyle = ProcessWindowStyle.Hidden;
                        startLogOn.CreateNoWindow = true;

                        // Đợi ứng dụng thoát mới xử lý tiếp chương trình
                        using (Process procLogOn = Process.Start(startLogOn))
                        {
                            procLogOn.WaitForExit();
                        }

                        //rkApp.SetValue("Reminiscent", Application.ExecutablePath.ToString());
                    }

                    #endregion

                    #endregion
                }
                if (cbxAfterWindowsStart.SelectedIndex == 0)
                    strAfterStart = "Mini";
                if (cbxAutorun.Checked == true)
                    strUpdate = "True";
                if (cbxLanguage.SelectedIndex == 1)
                    strLanguage = "Vietnamese";
                if (cbxTheme.SelectedIndex == 1)
                    strTheme = "Blue";
                else if (cbxTheme.SelectedIndex == 2)
                    strTheme = "White";

                if (cbxAfterWindowsStart.SelectedIndex == 0)
                    iFlagStartup = 1;
                else
                    iFlagStartup = 0;

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(Application.StartupPath + "/Config.xml");
                XmlElement root = xmlDoc.DocumentElement;

                strPass = root.ChildNodes[0].SelectSingleNode("Password").InnerText;
                if (txtCPass.Text != "")
                {
                    if (ValidateSHA1HashData(txtCPass.Text, strPass) == true)
                    {
                        berror = false;
                        if (txtNPass.Text != "")
                        {
                            if (txtNPass.Text == txtNPass2.Text)
                            {
                                strPass = GetSHA512HashData(txtNPass.Text);
                            }
                            else
                            {
                                berror = true;
                                MessageBox.Show("Confirm Password not match with New Password!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            berror = true;
                            MessageBox.Show("New Password can't be empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        berror = true;
                        MessageBox.Show("Wrong Password!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    berror = false;
                }

                #region Ghi vào tập tin Config.xml

                XmlTextWriter xtw = new XmlTextWriter(Application.StartupPath + "/Config.xml", null);
                xtw.Formatting = Formatting.Indented;

                xtw.WriteStartDocument();

                xtw.WriteStartElement("Config");
                xtw.WriteStartElement("DS_Config");
                xtw.WriteElementString("Startup", frmMain.Encryption(strStartup));
                xtw.WriteElementString("AfterStart", frmMain.Encryption(strAfterStart));
                xtw.WriteElementString("Language", frmMain.Encryption(strLanguage));
                xtw.WriteElementString("Theme", frmMain.Encryption(strTheme));
                xtw.WriteElementString("Update", frmMain.Encryption(strUpdate));
                xtw.WriteElementString("TOTD", frmMain.Encryption(strTOTD));
                xtw.WriteElementString("Password", strPass);
                xtw.WriteElementString("Repeat", frmMain.Encryption(strRepeat));
                xtw.WriteElementString("Time", frmMain.Encryption(strTime));
                xtw.WriteElementString("Date", frmMain.Encryption(strDate));
                xtw.WriteEndDocument();

                xtw.Flush();
                xtw.Close();

                #endregion

                if (strOriginalLanguage != cbxLanguage.Text || strOriginalTheme != cbxTheme.Text && berror == false)
                {
                    MessageBox.Show("Application need restart to change Language or Theme!", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();
                }
                if (berror == false)
                    this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void btnOK2_Click(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void ckbxStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbxStartup.Checked)
                cbxAfterWindowsStart.Enabled = true;
            else
                cbxAfterWindowsStart.Enabled = false;
        }

        private void btnOK_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCancel_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnOK2_MouseMove(object sender, MouseEventArgs e)
        {
            btnOK2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnCancel2_MouseMove(object sender, MouseEventArgs e)
        {
            btnCancel2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnOK2_MouseLeave(object sender, EventArgs e)
        {
            btnOK2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnCancel2_MouseLeave(object sender, EventArgs e)
        {
            btnCancel2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void cbxTOTD_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTOTD.Checked)
            {
                frmTaskOfTheDay totd = new frmTaskOfTheDay();
                totd.Show();
            }
            else
            {
                for (int fcount = 0; fcount <= Application.OpenForms.Count + 1; fcount++)
                {
                    foreach (Form frm in Application.OpenForms)
                    {
                        if (frm.Name == "frmTaskOfTheDay")
                        {
                            frm.Close();
                            break;
                        }
                    }
                }
            }
        }

        private void cbxAutorun_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxAutorun.Checked == true)
            {
                dtpTime.Enabled = true;
                dtpDate.Enabled = true;
                radDaily.Enabled = true;
                radWeekly.Enabled = true;
                radMonthly.Enabled = true;
                radOnce.Enabled = true;
            }
            else
            {
                dtpTime.Enabled = false;
                dtpDate.Enabled = false;
                radDaily.Enabled = false;
                radWeekly.Enabled = false;
                radMonthly.Enabled = false;
                radOnce.Enabled = false;

                radDaily.Checked = false;
                radWeekly.Checked = false;
                radMonthly.Checked = false;
                radOnce.Checked = false;
            }
        }

        private string GetDay(DateTime dt)
        {
            DateTime datetime;

            string strDay, strMonth, strYear, strTotal;

            datetime = dt;

            strDay = datetime.Day.ToString();
            strMonth = datetime.Month.ToString();
            strYear = datetime.Year.ToString();

            if (int.Parse(strDay) < 10)
                strDay = "0" + strDay;

            if (int.Parse(strMonth) < 10)
                strMonth = "0" + strMonth;

            if (sysUIFormat.Substring(0,1).ToLower() == "d")
                strTotal = strDay + "/" + strMonth + "/" + strYear;
            else
                strTotal = strMonth + "/" + strDay + "/" + strYear;

            return strTotal;
        }

        private string GetTime(DateTime dt)
        {
            string strHour, strMinute, strTime;

            if (dt.Hour < 10)
                strHour = "0" + dt.Hour;
            else
                strHour = dt.Hour.ToString();

            if (dt.Minute < 10)
                strMinute = "0" + dt.Minute;
            else
                strMinute = dt.Minute.ToString();

            strTime = strHour + ":" + strMinute;

            return strTime;
        }
    }
}
