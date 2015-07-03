using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Reminiscent
{
    public partial class frmIntro : Form
    {
        Assembly myAssembly = Assembly.GetExecutingAssembly();

        public frmIntro()
        {
            InitializeComponent();
        }

        public static int iTime = 0;
        double dPlayTime = 1;
        private void frmIntro_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.4 + dPlayTime / 100;
            IntroTimer.Start();
            PlayTime.Start();
        }

        private void IntroTimer_Tick(object sender, EventArgs e)
        {
            iTime++;
        }

        private void PlayTime_Tick(object sender, EventArgs e)
        {
            this.Opacity = 0.4 + dPlayTime / 100;
            lblIntro.Image = new Bitmap(myAssembly.GetManifestResourceStream("Reminiscent.Resources.Intro.Intro_59.png"));
            if (dPlayTime == 60)
                PlayTime.Stop();
            dPlayTime += 1;
        }
    }
}
