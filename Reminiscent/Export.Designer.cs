namespace Reminiscent
{
    partial class frmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExport));
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.cbxRecurring = new System.Windows.Forms.CheckBox();
            this.cbxIdea = new System.Windows.Forms.CheckBox();
            this.cbxSchedule = new System.Windows.Forms.CheckBox();
            this.cbxClock = new System.Windows.Forms.CheckBox();
            this.cbxDictionary = new System.Windows.Forms.CheckBox();
            this.cbxSticky = new System.Windows.Forms.CheckBox();
            this.cbxFavorite = new System.Windows.Forms.CheckBox();
            this.cbxAccount = new System.Windows.Forms.CheckBox();
            this.cbxSelectAll = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxRecurring
            // 
            this.cbxRecurring.AutoSize = true;
            this.cbxRecurring.BackColor = System.Drawing.Color.Transparent;
            this.cbxRecurring.Location = new System.Drawing.Point(6, 37);
            this.cbxRecurring.Name = "cbxRecurring";
            this.cbxRecurring.Size = new System.Drawing.Size(72, 17);
            this.cbxRecurring.TabIndex = 2;
            this.cbxRecurring.Text = "Recurring";
            this.cbxRecurring.UseVisualStyleBackColor = false;
            // 
            // cbxIdea
            // 
            this.cbxIdea.AutoSize = true;
            this.cbxIdea.BackColor = System.Drawing.Color.Transparent;
            this.cbxIdea.Location = new System.Drawing.Point(90, 14);
            this.cbxIdea.Name = "cbxIdea";
            this.cbxIdea.Size = new System.Drawing.Size(47, 17);
            this.cbxIdea.TabIndex = 4;
            this.cbxIdea.Text = "Idea";
            this.cbxIdea.UseVisualStyleBackColor = false;
            // 
            // cbxSchedule
            // 
            this.cbxSchedule.AutoSize = true;
            this.cbxSchedule.BackColor = System.Drawing.Color.Transparent;
            this.cbxSchedule.Location = new System.Drawing.Point(168, 14);
            this.cbxSchedule.Name = "cbxSchedule";
            this.cbxSchedule.Size = new System.Drawing.Size(71, 17);
            this.cbxSchedule.TabIndex = 7;
            this.cbxSchedule.Text = "Schedule";
            this.cbxSchedule.UseVisualStyleBackColor = false;
            // 
            // cbxClock
            // 
            this.cbxClock.AutoSize = true;
            this.cbxClock.BackColor = System.Drawing.Color.Transparent;
            this.cbxClock.Location = new System.Drawing.Point(168, 37);
            this.cbxClock.Name = "cbxClock";
            this.cbxClock.Size = new System.Drawing.Size(53, 17);
            this.cbxClock.TabIndex = 8;
            this.cbxClock.Text = "Clock";
            this.cbxClock.UseVisualStyleBackColor = false;
            // 
            // cbxDictionary
            // 
            this.cbxDictionary.AutoSize = true;
            this.cbxDictionary.BackColor = System.Drawing.Color.Transparent;
            this.cbxDictionary.Location = new System.Drawing.Point(6, 60);
            this.cbxDictionary.Name = "cbxDictionary";
            this.cbxDictionary.Size = new System.Drawing.Size(73, 17);
            this.cbxDictionary.TabIndex = 3;
            this.cbxDictionary.Text = "Dictionary";
            this.cbxDictionary.UseVisualStyleBackColor = false;
            // 
            // cbxSticky
            // 
            this.cbxSticky.AutoSize = true;
            this.cbxSticky.BackColor = System.Drawing.Color.Transparent;
            this.cbxSticky.Location = new System.Drawing.Point(90, 60);
            this.cbxSticky.Name = "cbxSticky";
            this.cbxSticky.Size = new System.Drawing.Size(55, 17);
            this.cbxSticky.TabIndex = 6;
            this.cbxSticky.Text = "Sticky";
            this.cbxSticky.UseVisualStyleBackColor = false;
            // 
            // cbxFavorite
            // 
            this.cbxFavorite.AutoSize = true;
            this.cbxFavorite.BackColor = System.Drawing.Color.Transparent;
            this.cbxFavorite.Location = new System.Drawing.Point(90, 37);
            this.cbxFavorite.Name = "cbxFavorite";
            this.cbxFavorite.Size = new System.Drawing.Size(64, 17);
            this.cbxFavorite.TabIndex = 5;
            this.cbxFavorite.Text = "Favorite";
            this.cbxFavorite.UseVisualStyleBackColor = false;
            // 
            // cbxAccount
            // 
            this.cbxAccount.AutoSize = true;
            this.cbxAccount.BackColor = System.Drawing.Color.Transparent;
            this.cbxAccount.Location = new System.Drawing.Point(168, 60);
            this.cbxAccount.Name = "cbxAccount";
            this.cbxAccount.Size = new System.Drawing.Size(66, 17);
            this.cbxAccount.TabIndex = 9;
            this.cbxAccount.Text = "Account";
            this.cbxAccount.UseVisualStyleBackColor = false;
            // 
            // cbxSelectAll
            // 
            this.cbxSelectAll.AutoSize = true;
            this.cbxSelectAll.BackColor = System.Drawing.Color.Transparent;
            this.cbxSelectAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSelectAll.Location = new System.Drawing.Point(6, 14);
            this.cbxSelectAll.Name = "cbxSelectAll";
            this.cbxSelectAll.Size = new System.Drawing.Size(80, 17);
            this.cbxSelectAll.TabIndex = 1;
            this.cbxSelectAll.Text = "Select All";
            this.cbxSelectAll.UseVisualStyleBackColor = false;
            this.cbxSelectAll.CheckedChanged += new System.EventHandler(this.cbxSelectAll_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cbxSelectAll);
            this.groupBox1.Controls.Add(this.cbxAccount);
            this.groupBox1.Controls.Add(this.cbxFavorite);
            this.groupBox1.Controls.Add(this.cbxSticky);
            this.groupBox1.Controls.Add(this.cbxDictionary);
            this.groupBox1.Controls.Add(this.cbxClock);
            this.groupBox1.Controls.Add(this.cbxSchedule);
            this.groupBox1.Controls.Add(this.cbxIdea);
            this.groupBox1.Controls.Add(this.cbxRecurring);
            this.groupBox1.Location = new System.Drawing.Point(25, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExport.BackgroundImage")));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.Location = new System.Drawing.Point(41, 115);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(81, 26);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(165, 115);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 26);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(294, 155);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnExport);
            this.DoubleBuffered = true;
            this.Name = "frmExport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export";
            this.Load += new System.EventHandler(this.frmExport_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog sfdExport;
        private System.Windows.Forms.CheckBox cbxRecurring;
        private System.Windows.Forms.CheckBox cbxIdea;
        private System.Windows.Forms.CheckBox cbxSchedule;
        private System.Windows.Forms.CheckBox cbxClock;
        private System.Windows.Forms.CheckBox cbxDictionary;
        private System.Windows.Forms.CheckBox cbxSticky;
        private System.Windows.Forms.CheckBox cbxFavorite;
        private System.Windows.Forms.CheckBox cbxAccount;
        private System.Windows.Forms.CheckBox cbxSelectAll;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}