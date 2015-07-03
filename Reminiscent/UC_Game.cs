using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Reminiscent
{
    public partial class UC_Game : UserControl
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        public UC_Game()
        {
            InitializeComponent();
        }

        private void UC_Game_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            axSWF.Visible = false;
            //axSWF.Location = new Point(922, 445);
        }

        private void btnFB_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            axSWF.Visible = true;
            axSWF.Movie = Environment.CurrentDirectory.ToString() + "/Data/Game/FlappyBird.swf";
            //axSWF.Location = new Point(344, 0);
            //axSWF.Size = new Size(234, 445);
            axSWF.Play();
        }

        private void btnMB_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            axSWF.Visible = true;
            axSWF.Movie = Environment.CurrentDirectory.ToString() + "/Data/Game/MetalBall.swf";
            //axSWF.Location = new Point(156, 0);
            //axSWF.Size = new Size(611, 445);
            axSWF.Play();
        }

        private void btnFB_MouseMove(object sender, MouseEventArgs e)
        {
            btnFB.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnMB_MouseMove(object sender, MouseEventArgs e)
        {
            btnMB.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnHover.png"));
        }

        private void btnFB_MouseLeave(object sender, EventArgs e)
        {
            btnFB.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }

        private void btnMB_MouseLeave(object sender, EventArgs e)
        {
            btnMB.BackgroundImage = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.btnBG.png"));
        }
    }
}
