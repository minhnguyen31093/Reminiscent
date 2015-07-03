using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reminiscent
{
    public partial class frmShowRecurring2 : Form
    {
        public frmShowRecurring2()
        {
            InitializeComponent();
        }

        private void frmShowRecurring2_Load(object sender, EventArgs e)
        {
            lblContent.Text = "";
            this.Location = new Point(0, 0);
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);

            btnOK.Location = new Point(10, Screen.PrimaryScreen.Bounds.Height - 90);
            btnOK.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 20, 81);

            string[] strName = classShowRecurring.strRecurringName.Split('+');
            string[] strDes = classShowRecurring.strRecurringDes.Split('+');

            if (strName.Length > 1)
                for (int i = 0; i < strName.Length; i++)
                {
                    lblContent.Text = lblContent.Text + "Task " + (i + 1) + " : " + strName[i].Trim().ToString() + "\n" + strDes[i].Trim().ToString() + "\n\n";
                }
            else
                lblContent.Text = "Task: " + strName[0].ToString() + "\n" + strDes[0].ToString();

            panelTitle.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 25, 152);
            panelContent.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 25, Screen.PrimaryScreen.Bounds.Height - 275);

            lblTitle.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - lblTitle.Size.Width / 2, panelTitle.Size.Height / 4);
            pictureBox2.Location = new Point(panelTitle.Size.Width - 150, panelTitle.Size.Height - 140);

            this.TopMost = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_MouseHover(object sender, EventArgs e)
        {
            //btnOK.ForeColor = Color.Yellow;
            //btnOK.FlatAppearance.BorderColor = Color.Yellow;
        }

        private void btnOK_MouseLeave(object sender, EventArgs e)
        {
            btnOK.ForeColor = Color.LightGray;
            btnOK.FlatAppearance.BorderColor = Color.FromArgb(224, 224, 224);
        }
    }
}
