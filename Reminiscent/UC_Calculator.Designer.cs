namespace Reminiscent
{
    partial class UC_Calculator
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
            this.lblStandard = new System.Windows.Forms.Label();
            this.lblScientific = new System.Windows.Forms.Label();
            this.lblConverter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblStandard
            // 
            this.lblStandard.BackColor = System.Drawing.Color.Transparent;
            this.lblStandard.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStandard.Location = new System.Drawing.Point(129, 4);
            this.lblStandard.Name = "lblStandard";
            this.lblStandard.Size = new System.Drawing.Size(200, 40);
            this.lblStandard.TabIndex = 1;
            this.lblStandard.Text = "Standard";
            this.lblStandard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStandard.Click += new System.EventHandler(this.lblStandard_Click);
            this.lblStandard.MouseLeave += new System.EventHandler(this.lblStandard_MouseLeave);
            this.lblStandard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblStandard_MouseMove);
            // 
            // lblScientific
            // 
            this.lblScientific.BackColor = System.Drawing.Color.Transparent;
            this.lblScientific.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScientific.Location = new System.Drawing.Point(361, 4);
            this.lblScientific.Name = "lblScientific";
            this.lblScientific.Size = new System.Drawing.Size(200, 40);
            this.lblScientific.TabIndex = 2;
            this.lblScientific.Text = "Scientific";
            this.lblScientific.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScientific.Click += new System.EventHandler(this.lblScientific_Click);
            this.lblScientific.MouseLeave += new System.EventHandler(this.lblScientific_MouseLeave);
            this.lblScientific.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblScientific_MouseMove);
            // 
            // lblConverter
            // 
            this.lblConverter.BackColor = System.Drawing.Color.Transparent;
            this.lblConverter.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConverter.Location = new System.Drawing.Point(593, 4);
            this.lblConverter.Name = "lblConverter";
            this.lblConverter.Size = new System.Drawing.Size(200, 40);
            this.lblConverter.TabIndex = 3;
            this.lblConverter.Text = "Converter";
            this.lblConverter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblConverter.Click += new System.EventHandler(this.lblConverter_Click);
            this.lblConverter.MouseLeave += new System.EventHandler(this.lblConverter_MouseLeave);
            this.lblConverter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblConverter_MouseMove);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(31, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(860, 370);
            this.panel1.TabIndex = 4;
            // 
            // UC_Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblConverter);
            this.Controls.Add(this.lblScientific);
            this.Controls.Add(this.lblStandard);
            this.Name = "UC_Calculator";
            this.Size = new System.Drawing.Size(922, 447);
            this.Load += new System.EventHandler(this.UC_Calculator_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStandard;
        private System.Windows.Forms.Label lblScientific;
        private System.Windows.Forms.Label lblConverter;
        private System.Windows.Forms.Panel panel1;

    }
}
