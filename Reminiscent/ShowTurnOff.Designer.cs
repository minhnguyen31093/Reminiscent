namespace Reminiscent
{
    partial class frmShowTurnOff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowTurnOff));
            this.lblTime = new System.Windows.Forms.Label();
            this.btnAbort = new System.Windows.Forms.Button();
            this.CountDown = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTime.ForeColor = System.Drawing.Color.Red;
            this.lblTime.Location = new System.Drawing.Point(0, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(276, 70);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00:00:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAbort
            // 
            this.btnAbort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbort.BackgroundImage")));
            this.btnAbort.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbort.FlatAppearance.BorderSize = 0;
            this.btnAbort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.Location = new System.Drawing.Point(82, 78);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(113, 51);
            this.btnAbort.TabIndex = 1;
            this.btnAbort.Text = "Abort!!";
            this.btnAbort.UseVisualStyleBackColor = true;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            this.btnAbort.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAbort_MouseDown);
            this.btnAbort.MouseLeave += new System.EventHandler(this.btnAbort_MouseLeave);
            this.btnAbort.MouseHover += new System.EventHandler(this.btnAbort_MouseHover);
            this.btnAbort.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnAbort_MouseUp);
            // 
            // CountDown
            // 
            this.CountDown.Interval = 1000;
            this.CountDown.Tick += new System.EventHandler(this.CountDown_Tick);
            // 
            // frmShowTurnOff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(276, 136);
            this.Controls.Add(this.btnAbort);
            this.Controls.Add(this.lblTime);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowTurnOff";
            this.Text = "ShowTurnOff";
            this.Load += new System.EventHandler(this.ShowRecurring_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.Timer CountDown;
    }
}