namespace Reminiscent
{
    partial class ShowAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowAlarm));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.TimerBird = new System.Windows.Forms.Timer(this.components);
            this.lblTime = new System.Windows.Forms.Label();
            this.lblBird = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblRed2 = new System.Windows.Forms.Label();
            this.lblRed1 = new System.Windows.Forms.Label();
            this.btnSnooze = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.TimerDelay = new System.Windows.Forms.Timer(this.components);
            this.lblYellow2 = new System.Windows.Forms.Label();
            this.lblYellow1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // TimerBird
            // 
            this.TimerBird.Interval = 1;
            this.TimerBird.Tick += new System.EventHandler(this.TimerBird_Tick);
            // 
            // lblTime
            // 
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 80F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(0, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(1264, 384);
            this.lblTime.TabIndex = 11;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBird
            // 
            this.lblBird.BackColor = System.Drawing.Color.Transparent;
            this.lblBird.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBird.Image = ((System.Drawing.Image)(resources.GetObject("lblBird.Image")));
            this.lblBird.Location = new System.Drawing.Point(12, 99);
            this.lblBird.Name = "lblBird";
            this.lblBird.Size = new System.Drawing.Size(64, 64);
            this.lblBird.TabIndex = 12;
            this.lblBird.Text = "   ";
            this.lblBird.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRed2);
            this.panel1.Controls.Add(this.lblRed1);
            this.panel1.Controls.Add(this.btnSnooze);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 384);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1264, 297);
            this.panel1.TabIndex = 13;
            // 
            // lblRed2
            // 
            this.lblRed2.BackColor = System.Drawing.Color.Transparent;
            this.lblRed2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed2.Image = ((System.Drawing.Image)(resources.GetObject("lblRed2.Image")));
            this.lblRed2.Location = new System.Drawing.Point(1058, 104);
            this.lblRed2.Name = "lblRed2";
            this.lblRed2.Size = new System.Drawing.Size(64, 64);
            this.lblRed2.TabIndex = 14;
            this.lblRed2.Text = "   ";
            this.lblRed2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRed1
            // 
            this.lblRed1.BackColor = System.Drawing.Color.Transparent;
            this.lblRed1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRed1.Image = ((System.Drawing.Image)(resources.GetObject("lblRed1.Image")));
            this.lblRed1.Location = new System.Drawing.Point(139, 104);
            this.lblRed1.Name = "lblRed1";
            this.lblRed1.Size = new System.Drawing.Size(64, 64);
            this.lblRed1.TabIndex = 13;
            this.lblRed1.Text = "   ";
            this.lblRed1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSnooze
            // 
            this.btnSnooze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSnooze.BackgroundImage")));
            this.btnSnooze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnooze.Location = new System.Drawing.Point(357, 137);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(272, 150);
            this.btnSnooze.TabIndex = 11;
            this.btnSnooze.Text = "Snooze";
            this.btnSnooze.UseVisualStyleBackColor = true;
            this.btnSnooze.Click += new System.EventHandler(this.btnSnooze_Click);
            this.btnSnooze.MouseLeave += new System.EventHandler(this.btnSnooze_MouseLeave);
            this.btnSnooze.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSnooze_MouseMove);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(635, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(272, 150);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseMove);
            // 
            // TimerDelay
            // 
            this.TimerDelay.Interval = 1000;
            this.TimerDelay.Tick += new System.EventHandler(this.TimerDelay_Tick);
            // 
            // lblYellow2
            // 
            this.lblYellow2.BackColor = System.Drawing.Color.Transparent;
            this.lblYellow2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYellow2.Image = ((System.Drawing.Image)(resources.GetObject("lblYellow2.Image")));
            this.lblYellow2.Location = new System.Drawing.Point(1065, 42);
            this.lblYellow2.Name = "lblYellow2";
            this.lblYellow2.Size = new System.Drawing.Size(64, 64);
            this.lblYellow2.TabIndex = 16;
            this.lblYellow2.Text = "   ";
            this.lblYellow2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYellow1
            // 
            this.lblYellow1.BackColor = System.Drawing.Color.Transparent;
            this.lblYellow1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYellow1.Image = ((System.Drawing.Image)(resources.GetObject("lblYellow1.Image")));
            this.lblYellow1.Location = new System.Drawing.Point(146, 42);
            this.lblYellow1.Name = "lblYellow1";
            this.lblYellow1.Size = new System.Drawing.Size(64, 64);
            this.lblYellow1.TabIndex = 15;
            this.lblYellow1.Text = "   ";
            this.lblYellow1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ShowAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.lblYellow2);
            this.Controls.Add(this.lblYellow1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblBird);
            this.Controls.Add(this.lblTime);
            this.Name = "ShowAlarm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ShowAlarm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmShowAlarm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer TimerBird;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblBird;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer TimerDelay;
        private System.Windows.Forms.Label lblRed2;
        private System.Windows.Forms.Label lblRed1;
        private System.Windows.Forms.Label lblYellow2;
        private System.Windows.Forms.Label lblYellow1;

    }
}