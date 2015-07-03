namespace Reminiscent
{
    partial class frmOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOption));
            this.tabOption = new System.Windows.Forms.TabControl();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.radOnce = new System.Windows.Forms.RadioButton();
            this.radMonthly = new System.Windows.Forms.RadioButton();
            this.radWeekly = new System.Windows.Forms.RadioButton();
            this.radDaily = new System.Windows.Forms.RadioButton();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbxAfterWindowsStart = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAutorun = new System.Windows.Forms.CheckBox();
            this.ckbxStartup = new System.Windows.Forms.CheckBox();
            this.tabAppearance = new System.Windows.Forms.TabPage();
            this.cbxTOTD = new System.Windows.Forms.CheckBox();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnOK2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbxTheme = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxLanguage = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabAccount = new System.Windows.Forms.TabPage();
            this.txtNPass2 = new System.Windows.Forms.TextBox();
            this.txtNPass = new System.Windows.Forms.TextBox();
            this.txtCPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabOption.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.tabAppearance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOption
            // 
            this.tabOption.Controls.Add(this.tabSystem);
            this.tabOption.Controls.Add(this.tabAppearance);
            this.tabOption.Controls.Add(this.tabAccount);
            this.tabOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOption.Location = new System.Drawing.Point(0, 0);
            this.tabOption.Name = "tabOption";
            this.tabOption.SelectedIndex = 0;
            this.tabOption.Size = new System.Drawing.Size(373, 263);
            this.tabOption.TabIndex = 0;
            // 
            // tabSystem
            // 
            this.tabSystem.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabSystem.BackgroundImage")));
            this.tabSystem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabSystem.Controls.Add(this.dtpDate);
            this.tabSystem.Controls.Add(this.radOnce);
            this.tabSystem.Controls.Add(this.radMonthly);
            this.tabSystem.Controls.Add(this.radWeekly);
            this.tabSystem.Controls.Add(this.radDaily);
            this.tabSystem.Controls.Add(this.dtpTime);
            this.tabSystem.Controls.Add(this.btnCancel);
            this.tabSystem.Controls.Add(this.btnOK);
            this.tabSystem.Controls.Add(this.cbxAfterWindowsStart);
            this.tabSystem.Controls.Add(this.label3);
            this.tabSystem.Controls.Add(this.label2);
            this.tabSystem.Controls.Add(this.cbxAutorun);
            this.tabSystem.Controls.Add(this.ckbxStartup);
            this.tabSystem.Location = new System.Drawing.Point(4, 22);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Padding = new System.Windows.Forms.Padding(3);
            this.tabSystem.Size = new System.Drawing.Size(365, 237);
            this.tabSystem.TabIndex = 0;
            this.tabSystem.Text = "System";
            this.tabSystem.UseVisualStyleBackColor = true;
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "";
            this.dtpDate.Enabled = false;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(248, 118);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(84, 20);
            this.dtpDate.TabIndex = 4;
            this.dtpDate.Value = new System.DateTime(2014, 6, 24, 0, 0, 0, 0);
            // 
            // radOnce
            // 
            this.radOnce.AutoSize = true;
            this.radOnce.Enabled = false;
            this.radOnce.Location = new System.Drawing.Point(38, 146);
            this.radOnce.Name = "radOnce";
            this.radOnce.Size = new System.Drawing.Size(71, 17);
            this.radOnce.TabIndex = 5;
            this.radOnce.TabStop = true;
            this.radOnce.Text = "One Time";
            this.radOnce.UseVisualStyleBackColor = true;
            // 
            // radMonthly
            // 
            this.radMonthly.AutoSize = true;
            this.radMonthly.Enabled = false;
            this.radMonthly.Location = new System.Drawing.Point(278, 146);
            this.radMonthly.Name = "radMonthly";
            this.radMonthly.Size = new System.Drawing.Size(62, 17);
            this.radMonthly.TabIndex = 8;
            this.radMonthly.TabStop = true;
            this.radMonthly.Text = "Monthly";
            this.radMonthly.UseVisualStyleBackColor = true;
            // 
            // radWeekly
            // 
            this.radWeekly.AutoSize = true;
            this.radWeekly.Enabled = false;
            this.radWeekly.Location = new System.Drawing.Point(198, 146);
            this.radWeekly.Name = "radWeekly";
            this.radWeekly.Size = new System.Drawing.Size(61, 17);
            this.radWeekly.TabIndex = 7;
            this.radWeekly.TabStop = true;
            this.radWeekly.Text = "Weekly";
            this.radWeekly.UseVisualStyleBackColor = true;
            // 
            // radDaily
            // 
            this.radDaily.AutoSize = true;
            this.radDaily.Enabled = false;
            this.radDaily.Location = new System.Drawing.Point(118, 146);
            this.radDaily.Name = "radDaily";
            this.radDaily.Size = new System.Drawing.Size(48, 17);
            this.radDaily.TabIndex = 6;
            this.radDaily.TabStop = true;
            this.radDaily.Text = "Daily";
            this.radDaily.UseVisualStyleBackColor = true;
            // 
            // dtpTime
            // 
            this.dtpTime.Enabled = false;
            this.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpTime.Location = new System.Drawing.Point(158, 118);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(84, 20);
            this.dtpTime.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(211, 183);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseMove);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(79, 183);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 37);
            this.btnOK.TabIndex = 9;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // cbxAfterWindowsStart
            // 
            this.cbxAfterWindowsStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAfterWindowsStart.FormattingEnabled = true;
            this.cbxAfterWindowsStart.Location = new System.Drawing.Point(158, 56);
            this.cbxAfterWindowsStart.Name = "cbxAfterWindowsStart";
            this.cbxAfterWindowsStart.Size = new System.Drawing.Size(174, 21);
            this.cbxAfterWindowsStart.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "After windows start:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Reminiscent will run at: ";
            // 
            // cbxAutorun
            // 
            this.cbxAutorun.AutoSize = true;
            this.cbxAutorun.Location = new System.Drawing.Point(37, 95);
            this.cbxAutorun.Name = "cbxAutorun";
            this.cbxAutorun.Size = new System.Drawing.Size(154, 17);
            this.cbxAutorun.TabIndex = 2;
            this.cbxAutorun.Text = "Set time to run this program";
            this.cbxAutorun.UseVisualStyleBackColor = true;
            this.cbxAutorun.CheckedChanged += new System.EventHandler(this.cbxAutorun_CheckedChanged);
            // 
            // ckbxStartup
            // 
            this.ckbxStartup.AutoSize = true;
            this.ckbxStartup.Location = new System.Drawing.Point(37, 34);
            this.ckbxStartup.Name = "ckbxStartup";
            this.ckbxStartup.Size = new System.Drawing.Size(117, 17);
            this.ckbxStartup.TabIndex = 0;
            this.ckbxStartup.Text = "Start with Windows";
            this.ckbxStartup.UseVisualStyleBackColor = true;
            this.ckbxStartup.CheckedChanged += new System.EventHandler(this.ckbxStartup_CheckedChanged);
            // 
            // tabAppearance
            // 
            this.tabAppearance.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAppearance.BackgroundImage")));
            this.tabAppearance.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabAppearance.Controls.Add(this.cbxTOTD);
            this.tabAppearance.Controls.Add(this.btnCancel2);
            this.tabAppearance.Controls.Add(this.btnOK2);
            this.tabAppearance.Controls.Add(this.groupBox2);
            this.tabAppearance.Controls.Add(this.groupBox1);
            this.tabAppearance.Location = new System.Drawing.Point(4, 22);
            this.tabAppearance.Name = "tabAppearance";
            this.tabAppearance.Padding = new System.Windows.Forms.Padding(3);
            this.tabAppearance.Size = new System.Drawing.Size(365, 237);
            this.tabAppearance.TabIndex = 1;
            this.tabAppearance.Text = "Appearance";
            this.tabAppearance.UseVisualStyleBackColor = true;
            // 
            // cbxTOTD
            // 
            this.cbxTOTD.AutoSize = true;
            this.cbxTOTD.Location = new System.Drawing.Point(33, 146);
            this.cbxTOTD.Name = "cbxTOTD";
            this.cbxTOTD.Size = new System.Drawing.Size(126, 17);
            this.cbxTOTD.TabIndex = 2;
            this.cbxTOTD.Text = "Show task of the day";
            this.cbxTOTD.UseVisualStyleBackColor = true;
            this.cbxTOTD.CheckedChanged += new System.EventHandler(this.cbxTOTD_CheckedChanged);
            // 
            // btnCancel2
            // 
            this.btnCancel2.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel2.BackgroundImage")));
            this.btnCancel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel2.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel2.Image")));
            this.btnCancel2.Location = new System.Drawing.Point(211, 183);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(79, 37);
            this.btnCancel2.TabIndex = 4;
            this.btnCancel2.UseVisualStyleBackColor = false;
            this.btnCancel2.Click += new System.EventHandler(this.button1_Click);
            this.btnCancel2.MouseLeave += new System.EventHandler(this.btnCancel2_MouseLeave);
            this.btnCancel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCancel2_MouseMove);
            // 
            // btnOK2
            // 
            this.btnOK2.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK2.BackgroundImage")));
            this.btnOK2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK2.Image = ((System.Drawing.Image)(resources.GetObject("btnOK2.Image")));
            this.btnOK2.Location = new System.Drawing.Point(79, 183);
            this.btnOK2.Name = "btnOK2";
            this.btnOK2.Size = new System.Drawing.Size(79, 37);
            this.btnOK2.TabIndex = 3;
            this.btnOK2.UseVisualStyleBackColor = false;
            this.btnOK2.Click += new System.EventHandler(this.btnOK2_Click);
            this.btnOK2.MouseLeave += new System.EventHandler(this.btnOK2_MouseLeave);
            this.btnOK2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK2_MouseMove);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbxTheme);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(33, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(299, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Interface";
            // 
            // cbxTheme
            // 
            this.cbxTheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTheme.FormattingEnabled = true;
            this.cbxTheme.Location = new System.Drawing.Point(178, 16);
            this.cbxTheme.Name = "cbxTheme";
            this.cbxTheme.Size = new System.Drawing.Size(99, 21);
            this.cbxTheme.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Window Styles:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxLanguage);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(33, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 48);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // cbxLanguage
            // 
            this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxLanguage.FormattingEnabled = true;
            this.cbxLanguage.Location = new System.Drawing.Point(178, 16);
            this.cbxLanguage.Name = "cbxLanguage";
            this.cbxLanguage.Size = new System.Drawing.Size(99, 21);
            this.cbxLanguage.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Interface Language:";
            // 
            // tabAccount
            // 
            this.tabAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tabAccount.BackgroundImage")));
            this.tabAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabAccount.Controls.Add(this.txtNPass2);
            this.tabAccount.Controls.Add(this.txtNPass);
            this.tabAccount.Controls.Add(this.txtCPass);
            this.tabAccount.Controls.Add(this.label8);
            this.tabAccount.Controls.Add(this.label7);
            this.tabAccount.Controls.Add(this.label6);
            this.tabAccount.Controls.Add(this.button1);
            this.tabAccount.Controls.Add(this.button2);
            this.tabAccount.Location = new System.Drawing.Point(4, 22);
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Padding = new System.Windows.Forms.Padding(3);
            this.tabAccount.Size = new System.Drawing.Size(365, 237);
            this.tabAccount.TabIndex = 2;
            this.tabAccount.Text = "Account";
            this.tabAccount.UseVisualStyleBackColor = true;
            // 
            // txtNPass2
            // 
            this.txtNPass2.Location = new System.Drawing.Point(137, 129);
            this.txtNPass2.Name = "txtNPass2";
            this.txtNPass2.Size = new System.Drawing.Size(188, 20);
            this.txtNPass2.TabIndex = 2;
            this.txtNPass2.UseSystemPasswordChar = true;
            // 
            // txtNPass
            // 
            this.txtNPass.Location = new System.Drawing.Point(137, 80);
            this.txtNPass.Name = "txtNPass";
            this.txtNPass.Size = new System.Drawing.Size(188, 20);
            this.txtNPass.TabIndex = 1;
            this.txtNPass.UseSystemPasswordChar = true;
            // 
            // txtCPass
            // 
            this.txtCPass.Location = new System.Drawing.Point(137, 31);
            this.txtCPass.Name = "txtCPass";
            this.txtCPass.Size = new System.Drawing.Size(188, 20);
            this.txtCPass.TabIndex = 0;
            this.txtCPass.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 14;
            this.label8.Tag = "";
            this.label8.Text = "Confirm Password:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 13;
            this.label7.Tag = "";
            this.label7.Text = "New Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 12;
            this.label6.Tag = "";
            this.label6.Text = "Current Password:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(211, 183);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 37);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnCancel_Click);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button1_MouseMove);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(79, 183);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 37);
            this.button2.TabIndex = 3;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnOK_Click);
            this.button2.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.button2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.button2_MouseMove);
            // 
            // frmOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(373, 263);
            this.Controls.Add(this.tabOption);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOption";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Option";
            this.Load += new System.EventHandler(this.Option_Load);
            this.tabOption.ResumeLayout(false);
            this.tabSystem.ResumeLayout(false);
            this.tabSystem.PerformLayout();
            this.tabAppearance.ResumeLayout(false);
            this.tabAppearance.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabAccount.ResumeLayout(false);
            this.tabAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOption;
        private System.Windows.Forms.TabPage tabSystem;
        private System.Windows.Forms.TabPage tabAppearance;
        private System.Windows.Forms.CheckBox ckbxStartup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbxAutorun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbxAfterWindowsStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbxTheme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxLanguage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel2;
        private System.Windows.Forms.Button btnOK2;
        private System.Windows.Forms.CheckBox cbxTOTD;
        private System.Windows.Forms.TabPage tabAccount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNPass2;
        private System.Windows.Forms.TextBox txtNPass;
        private System.Windows.Forms.TextBox txtCPass;
        private System.Windows.Forms.DateTimePicker dtpTime;
        private System.Windows.Forms.RadioButton radMonthly;
        private System.Windows.Forms.RadioButton radWeekly;
        private System.Windows.Forms.RadioButton radDaily;
        private System.Windows.Forms.RadioButton radOnce;
        private System.Windows.Forms.DateTimePicker dtpDate;
    }
}