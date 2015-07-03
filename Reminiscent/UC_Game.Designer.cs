namespace Reminiscent
{
    partial class UC_Game
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Game));
            this.axSWF = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.btnMB = new System.Windows.Forms.Button();
            this.btnFB = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axSWF)).BeginInit();
            this.SuspendLayout();
            // 
            // axSWF
            // 
            this.axSWF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axSWF.Enabled = true;
            this.axSWF.Location = new System.Drawing.Point(0, 0);
            this.axSWF.Name = "axSWF";
            this.axSWF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSWF.OcxState")));
            this.axSWF.Size = new System.Drawing.Size(922, 447);
            this.axSWF.TabIndex = 0;
            // 
            // btnMB
            // 
            this.btnMB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMB.BackgroundImage")));
            this.btnMB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMB.Location = new System.Drawing.Point(34, 54);
            this.btnMB.Name = "btnMB";
            this.btnMB.Size = new System.Drawing.Size(75, 23);
            this.btnMB.TabIndex = 5;
            this.btnMB.Text = "Metal Ball";
            this.btnMB.UseVisualStyleBackColor = true;
            this.btnMB.Click += new System.EventHandler(this.btnMB_Click);
            this.btnMB.MouseLeave += new System.EventHandler(this.btnMB_MouseLeave);
            this.btnMB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnMB_MouseMove);
            // 
            // btnFB
            // 
            this.btnFB.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFB.BackgroundImage")));
            this.btnFB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFB.Location = new System.Drawing.Point(34, 25);
            this.btnFB.Name = "btnFB";
            this.btnFB.Size = new System.Drawing.Size(75, 23);
            this.btnFB.TabIndex = 4;
            this.btnFB.Text = "Flappy Bird";
            this.btnFB.UseVisualStyleBackColor = true;
            this.btnFB.Click += new System.EventHandler(this.btnFB_Click);
            this.btnFB.MouseLeave += new System.EventHandler(this.btnFB_MouseLeave);
            this.btnFB.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnFB_MouseMove);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(582, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(340, 447);
            this.label2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(340, 447);
            this.label1.TabIndex = 3;
            // 
            // UC_Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnMB);
            this.Controls.Add(this.btnFB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.axSWF);
            this.Name = "UC_Game";
            this.Size = new System.Drawing.Size(922, 447);
            this.Load += new System.EventHandler(this.UC_Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axSWF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxShockwaveFlashObjects.AxShockwaveFlash axSWF;
        private System.Windows.Forms.Button btnMB;
        private System.Windows.Forms.Button btnFB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}
