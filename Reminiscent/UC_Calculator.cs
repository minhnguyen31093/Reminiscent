using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Reminiscent
{
    public partial class UC_Calculator : UserControl
    {
        public UC_Calculator()
        {
            InitializeComponent();
        }

        int iFlagClick = 0;
        UC_CalcStandard ucCS = new UC_CalcStandard();
        UC_Scientific ucS = new UC_Scientific();
        UC_Converter ucC = new UC_Converter();

        public UC_Calculator(UC_CalcStandard ucCalcStandard)
            : this()
        {
            this.ucCS = ucCalcStandard;
        }

        private void UC_Calculator_Load(object sender, EventArgs e)
        {
            iFlagClick = 1;
            panel1.Controls.Add(ucCS);

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
                    lblStandard.Text = frmMain.Decryption(node.SelectSingleNode("lbl1").InnerText);
                    lblScientific.Text = frmMain.Decryption(node.SelectSingleNode("lbl2").InnerText);
                    lblConverter.Text = frmMain.Decryption(node.SelectSingleNode("lbl3").InnerText);
                    break;
                }
            }
            #endregion
        }

        #region Click
        private void lblStandard_Click(object sender, EventArgs e)
        {
            if (iFlagClick != 1)
            {
                iFlagClick = 1;
                panel1.Controls.Clear();
                panel1.Controls.Add(ucCS);
                //panel1.Visible = true;
                //panel2.Visible = false;
                //panel3.Visible = false;
                ucCS.Move();

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
                panel1.Controls.Clear();
                panel1.Controls.Add(ucS);
                //panel1.Visible = false;
                //panel2.Visible = true;
                //panel3.Visible = false;

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
                panel1.Controls.Clear();
                panel1.Controls.Add(ucC);
                //panel1.Visible = false;
                //panel2.Visible = false;
                //panel3.Visible = true;

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
    }
}
