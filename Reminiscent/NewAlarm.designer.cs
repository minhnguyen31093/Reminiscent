namespace Reminiscent
{
    partial class NewAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewAlarm));
            this.txtAlarmName = new System.Windows.Forms.TextBox();
            this.lblAlarmName = new System.Windows.Forms.Label();
            this.lbldot = new System.Windows.Forms.Label();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.cboSongs = new System.Windows.Forms.ComboBox();
            this.lblSong = new System.Windows.Forms.Label();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.chkThu = new System.Windows.Forms.CheckBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.btnPickSong = new System.Windows.Forms.Button();
            this.txtSong = new System.Windows.Forms.TextBox();
            this.SaveSongDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnBG = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkSnooze = new System.Windows.Forms.CheckBox();
            this.lblSnooze = new System.Windows.Forms.Label();
            this.HoursUD = new System.Windows.Forms.NumericUpDown();
            this.MinutesUD = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.HoursUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUD)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAlarmName
            // 
            this.txtAlarmName.Location = new System.Drawing.Point(116, 43);
            this.txtAlarmName.MaxLength = 32;
            this.txtAlarmName.Name = "txtAlarmName";
            this.txtAlarmName.Size = new System.Drawing.Size(176, 20);
            this.txtAlarmName.TabIndex = 7;
            // 
            // lblAlarmName
            // 
            this.lblAlarmName.AutoSize = true;
            this.lblAlarmName.BackColor = System.Drawing.Color.Transparent;
            this.lblAlarmName.Location = new System.Drawing.Point(48, 46);
            this.lblAlarmName.Name = "lblAlarmName";
            this.lblAlarmName.Size = new System.Drawing.Size(67, 13);
            this.lblAlarmName.TabIndex = 6;
            this.lblAlarmName.Text = "Alarm Name:";
            // 
            // lbldot
            // 
            this.lbldot.AutoSize = true;
            this.lbldot.BackColor = System.Drawing.Color.Transparent;
            this.lbldot.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldot.Location = new System.Drawing.Point(195, 76);
            this.lbldot.Name = "lbldot";
            this.lbldot.Size = new System.Drawing.Size(18, 26);
            this.lbldot.TabIndex = 18;
            this.lbldot.Text = ":";
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeat.Location = new System.Drawing.Point(48, 178);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(45, 13);
            this.lblRepeat.TabIndex = 13;
            this.lblRepeat.Text = "Repeat:";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Location = new System.Drawing.Point(48, 84);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(33, 13);
            this.lblTime.TabIndex = 12;
            this.lblTime.Text = "Time:";
            // 
            // cboSongs
            // 
            this.cboSongs.FormattingEnabled = true;
            this.cboSongs.Location = new System.Drawing.Point(116, 213);
            this.cboSongs.Name = "cboSongs";
            this.cboSongs.Size = new System.Drawing.Size(176, 21);
            this.cboSongs.TabIndex = 20;
            this.cboSongs.SelectedIndexChanged += new System.EventHandler(this.cboSongs_SelectedIndexChanged);
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.BackColor = System.Drawing.Color.Transparent;
            this.lblSong.Location = new System.Drawing.Point(48, 216);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(35, 13);
            this.lblSong.TabIndex = 19;
            this.lblSong.Text = "Song:";
            // 
            // chkMon
            // 
            this.chkMon.AutoSize = true;
            this.chkMon.BackColor = System.Drawing.Color.Transparent;
            this.chkMon.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkMon.Location = new System.Drawing.Point(51, 122);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(32, 31);
            this.chkMon.TabIndex = 23;
            this.chkMon.Text = "Mon";
            this.chkMon.UseVisualStyleBackColor = false;
            this.chkMon.CheckedChanged += new System.EventHandler(this.chkMon_CheckedChanged);
            // 
            // chkTue
            // 
            this.chkTue.AutoSize = true;
            this.chkTue.BackColor = System.Drawing.Color.Transparent;
            this.chkTue.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkTue.Location = new System.Drawing.Point(89, 122);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(30, 31);
            this.chkTue.TabIndex = 24;
            this.chkTue.Text = "Tue";
            this.chkTue.UseVisualStyleBackColor = false;
            this.chkTue.CheckedChanged += new System.EventHandler(this.chkTue_CheckedChanged);
            // 
            // chkWed
            // 
            this.chkWed.AutoSize = true;
            this.chkWed.BackColor = System.Drawing.Color.Transparent;
            this.chkWed.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkWed.Location = new System.Drawing.Point(125, 122);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(34, 31);
            this.chkWed.TabIndex = 25;
            this.chkWed.Text = "Wed";
            this.chkWed.UseVisualStyleBackColor = false;
            this.chkWed.CheckedChanged += new System.EventHandler(this.chkWed_CheckedChanged);
            // 
            // chkThu
            // 
            this.chkThu.AutoSize = true;
            this.chkThu.BackColor = System.Drawing.Color.Transparent;
            this.chkThu.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkThu.Location = new System.Drawing.Point(165, 122);
            this.chkThu.Name = "chkThu";
            this.chkThu.Size = new System.Drawing.Size(30, 31);
            this.chkThu.TabIndex = 26;
            this.chkThu.Text = "Thu";
            this.chkThu.UseVisualStyleBackColor = false;
            this.chkThu.CheckedChanged += new System.EventHandler(this.chkThu_CheckedChanged);
            // 
            // chkSun
            // 
            this.chkSun.AutoSize = true;
            this.chkSun.BackColor = System.Drawing.Color.Transparent;
            this.chkSun.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSun.Location = new System.Drawing.Point(262, 122);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(30, 31);
            this.chkSun.TabIndex = 29;
            this.chkSun.Text = "Sun";
            this.chkSun.UseVisualStyleBackColor = false;
            this.chkSun.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkSat
            // 
            this.chkSat.AutoSize = true;
            this.chkSat.BackColor = System.Drawing.Color.Transparent;
            this.chkSat.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSat.Location = new System.Drawing.Point(229, 122);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(27, 31);
            this.chkSat.TabIndex = 28;
            this.chkSat.Text = "Sat";
            this.chkSat.UseVisualStyleBackColor = false;
            this.chkSat.CheckedChanged += new System.EventHandler(this.chkSat_CheckedChanged);
            // 
            // chkFri
            // 
            this.chkFri.AutoSize = true;
            this.chkFri.BackColor = System.Drawing.Color.Transparent;
            this.chkFri.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkFri.Location = new System.Drawing.Point(201, 122);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(22, 31);
            this.chkFri.TabIndex = 27;
            this.chkFri.Text = "Fri";
            this.chkFri.UseVisualStyleBackColor = false;
            this.chkFri.CheckedChanged += new System.EventHandler(this.chkFri_CheckedChanged);
            // 
            // txtRepeat
            // 
            this.txtRepeat.Location = new System.Drawing.Point(116, 175);
            this.txtRepeat.MaxLength = 32;
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(176, 20);
            this.txtRepeat.TabIndex = 30;
            // 
            // btnPickSong
            // 
            this.btnPickSong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPickSong.BackgroundImage")));
            this.btnPickSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPickSong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPickSong.Location = new System.Drawing.Point(217, 252);
            this.btnPickSong.Name = "btnPickSong";
            this.btnPickSong.Size = new System.Drawing.Size(75, 23);
            this.btnPickSong.TabIndex = 32;
            this.btnPickSong.Text = "Pick a song";
            this.btnPickSong.UseVisualStyleBackColor = true;
            this.btnPickSong.Click += new System.EventHandler(this.btnPickSong_Click);
            this.btnPickSong.MouseLeave += new System.EventHandler(this.btnPickSong_MouseLeave);
            this.btnPickSong.MouseHover += new System.EventHandler(this.btnPickSong_MouseHover);
            // 
            // txtSong
            // 
            this.txtSong.Location = new System.Drawing.Point(51, 254);
            this.txtSong.MaxLength = 32;
            this.txtSong.Name = "txtSong";
            this.txtSong.Size = new System.Drawing.Size(160, 20);
            this.txtSong.TabIndex = 33;
            // 
            // SaveSongDialog
            // 
            this.SaveSongDialog.CheckFileExists = true;
            this.SaveSongDialog.DefaultExt = "mp3";
            this.SaveSongDialog.Filter = "MP3 files (*.mp3)|*.mp3";
            this.SaveSongDialog.Title = "Pick a song";
            // 
            // btnBG
            // 
            this.btnBG.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("btnBG.ImageStream")));
            this.btnBG.TransparentColor = System.Drawing.Color.Transparent;
            this.btnBG.Images.SetKeyName(0, "btnBG.png");
            this.btnBG.Images.SetKeyName(1, "btnHover.png");
            this.btnBG.Images.SetKeyName(2, "btnChecked.png");
            this.btnBG.Images.SetKeyName(3, "btnUnchecked.png");
            // 
            // btnCancel
            // 
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(200, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseLeave += new System.EventHandler(this.btnCancel_MouseLeave);
            this.btnCancel.MouseHover += new System.EventHandler(this.btnCancel_MouseHover);
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(62, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 37);
            this.btnOK.TabIndex = 34;
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseHover += new System.EventHandler(this.btnOK_MouseHover);
            // 
            // chkSnooze
            // 
            this.chkSnooze.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSnooze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkSnooze.BackgroundImage")));
            this.chkSnooze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSnooze.Location = new System.Drawing.Point(116, 293);
            this.chkSnooze.Name = "chkSnooze";
            this.chkSnooze.Size = new System.Drawing.Size(176, 24);
            this.chkSnooze.TabIndex = 36;
            this.chkSnooze.Text = "Snooze";
            this.chkSnooze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSnooze.UseVisualStyleBackColor = true;
            this.chkSnooze.CheckedChanged += new System.EventHandler(this.chkSnooze_CheckedChanged);
            this.chkSnooze.MouseLeave += new System.EventHandler(this.chkSnooze_MouseLeave);
            this.chkSnooze.MouseHover += new System.EventHandler(this.chkSnooze_MouseHover);
            // 
            // lblSnooze
            // 
            this.lblSnooze.AutoSize = true;
            this.lblSnooze.BackColor = System.Drawing.Color.Transparent;
            this.lblSnooze.Location = new System.Drawing.Point(48, 299);
            this.lblSnooze.Name = "lblSnooze";
            this.lblSnooze.Size = new System.Drawing.Size(46, 13);
            this.lblSnooze.TabIndex = 37;
            this.lblSnooze.Text = "Snooze:";
            // 
            // HoursUD
            // 
            this.HoursUD.Location = new System.Drawing.Point(116, 81);
            this.HoursUD.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.HoursUD.Name = "HoursUD";
            this.HoursUD.Size = new System.Drawing.Size(75, 20);
            this.HoursUD.TabIndex = 38;
            this.HoursUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MinutesUD
            // 
            this.MinutesUD.Location = new System.Drawing.Point(217, 81);
            this.MinutesUD.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MinutesUD.Name = "MinutesUD";
            this.MinutesUD.Size = new System.Drawing.Size(75, 20);
            this.MinutesUD.TabIndex = 39;
            this.MinutesUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // NewAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(340, 420);
            this.Controls.Add(this.MinutesUD);
            this.Controls.Add(this.HoursUD);
            this.Controls.Add(this.lblSnooze);
            this.Controls.Add(this.chkSnooze);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtSong);
            this.Controls.Add(this.btnPickSong);
            this.Controls.Add(this.txtRepeat);
            this.Controls.Add(this.chkSun);
            this.Controls.Add(this.chkSat);
            this.Controls.Add(this.chkFri);
            this.Controls.Add(this.chkThu);
            this.Controls.Add(this.chkWed);
            this.Controls.Add(this.chkTue);
            this.Controls.Add(this.chkMon);
            this.Controls.Add(this.cboSongs);
            this.Controls.Add(this.lblSong);
            this.Controls.Add(this.lbldot);
            this.Controls.Add(this.lblRepeat);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.txtAlarmName);
            this.Controls.Add(this.lblAlarmName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAlarm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewAlarm_FormClosing);
            this.Load += new System.EventHandler(this.NewAlarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.HoursUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAlarmName;
        private System.Windows.Forms.Label lblAlarmName;
        private System.Windows.Forms.Label lbldot;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ComboBox cboSongs;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.Button btnPickSong;
        private System.Windows.Forms.TextBox txtSong;
        private System.Windows.Forms.SaveFileDialog SaveSongDialog;
        private System.Windows.Forms.ImageList btnBG;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkSnooze;
        private System.Windows.Forms.Label lblSnooze;
        private System.Windows.Forms.NumericUpDown HoursUD;
        private System.Windows.Forms.NumericUpDown MinutesUD;
    }
}