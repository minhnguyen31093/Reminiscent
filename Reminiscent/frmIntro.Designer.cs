namespace Reminiscent
{
    partial class frmIntro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblIntro = new System.Windows.Forms.Label();
            this.IntroTimer = new System.Windows.Forms.Timer(this.components);
            this.PlayTime = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblIntro
            // 
            this.lblIntro.Location = new System.Drawing.Point(44, 44);
            this.lblIntro.Name = "lblIntro";
            this.lblIntro.Size = new System.Drawing.Size(512, 512);
            this.lblIntro.TabIndex = 0;
            // 
            // IntroTimer
            // 
            this.IntroTimer.Interval = 1000;
            this.IntroTimer.Tick += new System.EventHandler(this.IntroTimer_Tick);
            // 
            // PlayTime
            // 
            this.PlayTime.Interval = 50;
            this.PlayTime.Tick += new System.EventHandler(this.PlayTime_Tick);
            // 
            // frmIntro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Controls.Add(this.lblIntro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmIntro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Intro";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Gainsboro;
            this.Load += new System.EventHandler(this.frmIntro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblIntro;
        private System.Windows.Forms.Timer IntroTimer;
        private System.Windows.Forms.Timer PlayTime;
    }
}