using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;

namespace Reminiscent
{
    public partial class UC_Others : UserControl
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();
        int iFlagClick = 0;
        UC_CalcStandard ucCS = new UC_CalcStandard();
        UC_Scientific ucS = new UC_Scientific();
        UC_Converter ucC = new UC_Converter();
        int iPC1x = 203;
        int iPC2x = 309;
        int iFlagDot = 0;
        int iFlagNumber = 0;

        public UC_Others()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.D0) || keyData == (Keys.NumPad0))
            {
                btn0.PerformClick();
                return true;
            }

            if (keyData == (Keys.D1) || keyData == (Keys.NumPad1))
            {
                btn1.PerformClick();
                return true;
            }

            if (keyData == (Keys.D2) || keyData == (Keys.NumPad2))
            {
                btn2.PerformClick();
                return true;
            }

            if (keyData == (Keys.D3) || keyData == (Keys.NumPad3))
            {
                btn3.PerformClick();
                return true;
            }

            if (keyData == (Keys.D4) || keyData == (Keys.NumPad4))
            {
                btn4.PerformClick();
                return true;
            }

            if (keyData == (Keys.D5) || keyData == (Keys.NumPad5))
            {
                btn5.PerformClick();
                return true;
            }

            if (keyData == (Keys.D6) || keyData == (Keys.NumPad6))
            {
                btn6.PerformClick();
                return true;
            }

            if (keyData == (Keys.D7) || keyData == (Keys.NumPad7))
            {
                btn7.PerformClick();
                return true;
            }

            if (keyData == (Keys.D8) || keyData == (Keys.NumPad8))
            {
                btn8.PerformClick();
                return true;
            }

            if (keyData == (Keys.D9) || keyData == (Keys.NumPad9))
            {
                btn9.PerformClick();
                return true;
            }

            if (keyData == (Keys.Home))
            {
                btn9.PerformClick();
                return true;
            }

            if (keyData == (Keys.Delete))
            {
                btnCE.PerformClick();
                return true;
            }

            if (keyData == (Keys.Escape))
            {
                btnC.PerformClick();
                return true;
            }

            if (keyData == (Keys.Back))
            {
                btnDel.PerformClick();
                return true;
            }

            if (keyData == (Keys.Enter))
            {
                btnKq.PerformClick();
                return true;
            }

            if (keyData == (Keys.ShiftKey | Keys.Execute))
            {
                btnCong.PerformClick();
                return true;
            }

            if (keyData == (Keys.Subtract))
            {
                btnTru.PerformClick();
                return true;
            }

            if (keyData == (Keys.ShiftKey | Keys.D8))
            {
                btnNhan.PerformClick();
                return true;
            }

            if (keyData == (Keys.Decimal))
            {
                btnChia.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void UC_Others_Load(object sender, EventArgs e)
        {
            //UC_Calculator ucCalculator = new UC_Calculator();
            //tabPage1.Controls.Add(ucCalculator);

            UC_Game ucGame = new UC_Game();
            ucGame.Dock = DockStyle.Fill;
            tabPage2.Controls.Add(ucGame);

            iFlagClick = 1;
            //panel1.Controls.Add(ucCS);
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;

            lblStandard.ForeColor = Color.Black;
            lblStandard.Font = new Font(lblStandard.Font, FontStyle.Underline);

            lblScientific.ForeColor = Color.Silver;
            lblScientific.Font = new Font(lblStandard.Font, FontStyle.Regular);

            lblConverter.ForeColor = Color.Silver;
            lblConverter.Font = new Font(lblStandard.Font, FontStyle.Regular);

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

                    lblStandard.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblScientific.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblConverter.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
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
                    break;
                }
            }
            #endregion

            lblStandard_Click(sender, e);
        }

        #region Click
        private void lblStandard_Click(object sender, EventArgs e)
        {
            if (iFlagClick != 1)
            {
                iFlagClick = 1;
                panel1.Location = new Point(31, 60);
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
                //MoveP();

                lblStandard.ForeColor = Color.Black;
                lblStandard.Font = new Font(lblStandard.Font, FontStyle.Underline);

                lblScientific.ForeColor = Color.Silver;
                lblScientific.Font = new Font(lblStandard.Font, FontStyle.Regular);

                lblConverter.ForeColor = Color.Silver;
                lblConverter.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }

        private void lblScientific_Click(object sender, EventArgs e)
        {
            if (iFlagClick != 2)
            {
                iFlagClick = 2;
                panel2.Location = new Point(31, 60);
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;

                lblScientific.ForeColor = Color.Black;
                lblScientific.Font = new Font(lblStandard.Font, FontStyle.Underline);

                lblStandard.ForeColor = Color.Silver;
                lblStandard.Font = new Font(lblStandard.Font, FontStyle.Regular);

                lblConverter.ForeColor = Color.Silver;
                lblConverter.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }

        private void lblConverter_Click(object sender, EventArgs e)
        {
            if (iFlagClick != 3)
            {
                iFlagClick = 3;
                panel3.Location = new Point(31, 60);
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;

                lblConverter.ForeColor = Color.Black;
                lblConverter.Font = new Font(lblStandard.Font, FontStyle.Underline);

                lblStandard.ForeColor = Color.Silver;
                lblStandard.Font = new Font(lblStandard.Font, FontStyle.Regular);

                lblScientific.ForeColor = Color.Silver;
                lblScientific.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }
        #endregion

        #region Hover
        private void lblStandard_MouseMove(object sender, MouseEventArgs e)
        {
            if (iFlagClick != 1)
            {
                lblStandard.ForeColor = Color.Red;
                lblStandard.Font = new Font(lblStandard.Font, FontStyle.Underline);
            }
        }

        private void lblScientific_MouseMove(object sender, MouseEventArgs e)
        {
            if (iFlagClick != 2)
            {
                lblScientific.ForeColor = Color.Red;
                lblScientific.Font = new Font(lblStandard.Font, FontStyle.Underline);
            }
        }

        private void lblConverter_MouseMove(object sender, MouseEventArgs e)
        {
            if (iFlagClick != 3)
            {
                lblConverter.ForeColor = Color.Red;
                lblConverter.Font = new Font(lblStandard.Font, FontStyle.Underline);
            }
        }

        private void lblStandard_MouseLeave(object sender, EventArgs e)
        {
            if (iFlagClick != 1)
            {
                lblStandard.ForeColor = Color.Silver;
                lblStandard.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }

        private void lblScientific_MouseLeave(object sender, EventArgs e)
        {
            if (iFlagClick != 2)
            {
                lblScientific.ForeColor = Color.Silver;
                lblScientific.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }

        private void lblConverter_MouseLeave(object sender, EventArgs e)
        {
            if (iFlagClick != 3)
            {
                lblConverter.ForeColor = Color.Silver;
                lblConverter.Font = new Font(lblStandard.Font, FontStyle.Regular);
            }
        }
        #endregion

        void MoveP()
        {
            iPC1x = 203;
            iPC2x = 309;
            TimerMove.Start();
        }

        #region Nhấn nút số
        private void btnCham_Click(object sender, EventArgs e)
        {
            if (!lblCalc2.Text.Contains('.'))
            {
                iFlagDot = 1;
                lblCalc2.Text += ".";
                iFlagNumber = 0;
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "0";
            else
                lblCalc2.Text += "0";
            iFlagNumber = 0;
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "1";
            else
                lblCalc2.Text += "1";
            iFlagNumber = 0;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "2";
            else
                lblCalc2.Text += "2";
            iFlagNumber = 0;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "3";
            else
                lblCalc2.Text += "3";
            iFlagNumber = 0;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "4";
            else
                lblCalc2.Text += "4";
            iFlagNumber = 0;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "5";
            else
                lblCalc2.Text += "5";
            iFlagNumber = 0;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "6";
            else
                lblCalc2.Text += "6";
            iFlagNumber = 0;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "7";
            else
                lblCalc2.Text += "7";
            iFlagNumber = 0;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "8";
            else
                lblCalc2.Text += "8";
            iFlagNumber = 0;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text == "0" || iFlagNumber != 0)
                lblCalc2.Text = "9";
            else
                lblCalc2.Text += "9";
            iFlagNumber = 0;
        }
        #endregion

        #region Nhấn nút xóa
        private void btnCE_Click(object sender, EventArgs e)
        {
            lblCalc2.Text = "0";
            lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 48, FontStyle.Regular);
            iFlagDot = 0;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblCalc1.Text = "";
            lblCalc2.Text = "0";
            lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 48, FontStyle.Regular);
            iTinh = 0;
            iFlagDot = 0;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (lblCalc2.Text.Length > 0)
                lblCalc2.Text = lblCalc2.Text.Substring(0, lblCalc2.Text.Length - 1);
            if (!lblCalc2.Text.Contains('.'))
                iFlagDot = 0;
        }
        #endregion

        #region Nhấn nút phép tính
        private void btnCong_Click(object sender, EventArgs e)
        {
            if (iFlagNumber == 0)
            {
                lblCalc1.Text += lblCalc2.Text.Replace(",", "") + " + ";
                iFlagNumber = 1;
            }
            else
            {
                lblCalc1.Text = lblCalc1.Text.Substring(0, lblCalc1.Text.Length - 3) + " + ";
            }
            if (iFlagNumber != 5 && lblCalc1.Text != "")
                Tinh();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            if (iFlagNumber == 0)
            {
                lblCalc1.Text += lblCalc2.Text.Replace(",", "") + " - ";
                iFlagNumber = 2;
            }
            else
            {
                lblCalc1.Text = lblCalc1.Text.Substring(0, lblCalc1.Text.Length - 3) + " - ";
            }
            if (iFlagNumber != 5 && lblCalc1.Text != "")
                Tinh();
        }

        private void btnNhan_Click(object sender, EventArgs e)
        {
            if (iFlagNumber == 0)
            {
                lblCalc1.Text += lblCalc2.Text.Replace(",", "") + " * ";
                iFlagNumber = 3;
            }
            else
            {
                lblCalc1.Text = lblCalc1.Text.Substring(0, lblCalc1.Text.Length - 3) + " * ";
            }
            if (iFlagNumber != 5 && lblCalc1.Text != "")
                Tinh();
        }

        private void btnChia_Click(object sender, EventArgs e)
        {
            if (iFlagNumber == 0)
            {
                lblCalc1.Text += lblCalc2.Text.Replace(",", "") + " / ";
                iFlagNumber = 4;
            }
            else
            {
                lblCalc1.Text = lblCalc1.Text.Substring(0, lblCalc1.Text.Length - 3) + " / ";
            }
            if (iFlagNumber != 5 && lblCalc1.Text != "")
                Tinh();
        }
        #endregion

        #region Nhấn =
        private void btnKq_Click(object sender, EventArgs e)
        {
            lblCalc1.Text = "";
            iFlagNumber = iFlagTemp;
            Tinh();
            iFlagTemp = 0;
            iFlagNumber = 0;
        }
        #endregion

        #region Text Changed
        string strTemp = "";
        private void lblCalc2_TextChanged(object sender, EventArgs e)
        {
            if (lblCalc2.Text.Length > 3 && iFlagDot != 1)
            {
                //string[] strArrText = null;
                string strText = "";
                //if (lblCalc2.Text.Contains('.'))
                //{
                //    strArrText = lblCalc2.Text.Replace(",", "").Split('.');
                //    strText = strArrText[0];
                //}
                //else
                //{
                strText = lblCalc2.Text.Replace(",", "");
                //}

                if (strText.Length % 3 == 0)
                {
                    for (int i = 3; i < lblCalc2.Text.Length - 1; i += 4)
                    {
                        strText = strText.Insert(i, ",");
                    }
                }

                else
                {
                    if (strText.Length % 2 == 0)
                    {
                        for (int i = 1; i < lblCalc2.Text.Length; i += 4)
                        {
                            strText = strText.Insert(i, ",");
                        }
                    }

                    else if (strText.Length % 2 != 0)
                    {
                        for (int i = 2; i < lblCalc2.Text.Length; i += 4)
                        {
                            strText = strText.Insert(i, ",");
                        }
                    }
                }

                lblCalc2.Text = strText;
            }
            if (lblCalc2.Text.Length == 43)
                strTemp = lblCalc2.Text;
            if (lblCalc2.Text.Length > 43)
                lblCalc2.Text = strTemp;
            if (lblCalc2.Text.Length == 15)
                lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 32, FontStyle.Regular);
            else if (lblCalc2.Text.Length == 23)
                lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 24, FontStyle.Regular);
            else if (lblCalc2.Text.Length == 31)
                lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 18, FontStyle.Regular);
            else if (lblCalc2.Text.Length == 40)
                lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 16, FontStyle.Regular);
            else if (lblCalc2.Text.Length == 14)
                lblCalc2.Font = new Font(lblCalc2.Font.FontFamily, 48, FontStyle.Regular);
        }
        #endregion

        #region Mouse Down
        private void btnCham_MouseDown(object sender, MouseEventArgs e)
        {
            btnCham.ForeColor = Color.DimGray;
        }

        private void btn0_MouseDown(object sender, MouseEventArgs e)
        {
            btn0.ForeColor = Color.DimGray;
        }

        private void btn1_MouseDown(object sender, MouseEventArgs e)
        {
            btn1.ForeColor = Color.DimGray;
        }

        private void btn2_MouseDown(object sender, MouseEventArgs e)
        {
            btn2.ForeColor = Color.DimGray;
        }

        private void btn3_MouseDown(object sender, MouseEventArgs e)
        {
            btn3.ForeColor = Color.DimGray;
        }

        private void btn4_MouseDown(object sender, MouseEventArgs e)
        {
            btn4.ForeColor = Color.DimGray;
        }

        private void btn5_MouseDown(object sender, MouseEventArgs e)
        {
            btn5.ForeColor = Color.DimGray;
        }

        private void btn6_MouseDown(object sender, MouseEventArgs e)
        {
            btn6.ForeColor = Color.DimGray;
        }

        private void btn7_MouseDown(object sender, MouseEventArgs e)
        {
            btn7.ForeColor = Color.DimGray;
        }

        private void btn8_MouseDown(object sender, MouseEventArgs e)
        {
            btn8.ForeColor = Color.DimGray;
        }

        private void btn9_MouseDown(object sender, MouseEventArgs e)
        {
            btn9.ForeColor = Color.DimGray;
        }
        #endregion

        #region Mouse Up
        private void btnCham_MouseUp(object sender, MouseEventArgs e)
        {
            btnCham.ForeColor = Color.White;
        }

        private void btn0_MouseUp(object sender, MouseEventArgs e)
        {
            btn0.ForeColor = Color.White;
        }

        private void btn1_MouseUp(object sender, MouseEventArgs e)
        {
            btn1.ForeColor = Color.White;
        }

        private void btn2_MouseUp(object sender, MouseEventArgs e)
        {
            btn2.ForeColor = Color.White;
        }

        private void btn3_MouseUp(object sender, MouseEventArgs e)
        {
            btn3.ForeColor = Color.White;
        }

        private void btn4_MouseUp(object sender, MouseEventArgs e)
        {
            btn4.ForeColor = Color.White;
        }

        private void btn5_MouseUp(object sender, MouseEventArgs e)
        {
            btn5.ForeColor = Color.White;
        }

        private void btn6_MouseUp(object sender, MouseEventArgs e)
        {
            btn6.ForeColor = Color.White;
        }

        private void btn7_MouseUp(object sender, MouseEventArgs e)
        {
            btn7.ForeColor = Color.White;
        }

        private void btn8_MouseUp(object sender, MouseEventArgs e)
        {
            btn8.ForeColor = Color.White;
        }

        private void btn9_MouseUp(object sender, MouseEventArgs e)
        {
            btn9.ForeColor = Color.White;
        }
        #endregion

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            iPC1x -= 2;
            iPC2x -= 1;
            PanelCol1.Location = new Point(iPC1x, 129);
            PanelCol2.Location = new Point(iPC2x, 129);
            if (iPC1x == 183)
            {
                iPC1x += 2;
            }
            if (iPC2x == 289)
            {
                iPC1x = 183;
                TimerMove.Stop();
            }
        }

        int iTinh = 0;
        int iFlagTemp = 0;
        void Tinh()
        {
            string[] strCount = lblCalc1.Text.Split(' ');
            if (strCount.Length > 3)
            {
                //MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
                //sc.Language = "VBScript";
                //object result = sc.Eval(lblCalc1.Text);
                //iTinh = Convert.ToInt32(result);
                if (iFlagNumber == 1)
                    iTinh += Convert.ToInt32(lblCalc2.Text);
                else if (iFlagNumber == 2)
                    iTinh -= Convert.ToInt32(lblCalc2.Text);
                else if (iFlagNumber == 3)
                    iTinh *= Convert.ToInt32(lblCalc2.Text);
                else if (iFlagNumber == 4)
                    iTinh /= Convert.ToInt32(lblCalc2.Text);
                lblCalc2.Text = iTinh.ToString();
                iFlagTemp = iFlagNumber;
                iFlagNumber = 5;
            }
        }
    }
}
