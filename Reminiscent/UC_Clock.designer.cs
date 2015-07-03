namespace Reminiscent
{
    partial class UC_Clock
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Clock));
            this.AlarmContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playAlarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopAlarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblgb = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblAlarmTitle = new System.Windows.Forms.Label();
            this.lstAlarm = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRepeat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSnooze = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.MinutesUD = new System.Windows.Forms.NumericUpDown();
            this.HoursUD = new System.Windows.Forms.NumericUpDown();
            this.lblSnooze = new System.Windows.Forms.Label();
            this.chkSnooze = new System.Windows.Forms.CheckBox();
            this.txtSong = new System.Windows.Forms.TextBox();
            this.btnPickSong = new System.Windows.Forms.Button();
            this.txtRepeat = new System.Windows.Forms.TextBox();
            this.chkSun = new System.Windows.Forms.CheckBox();
            this.chkMon = new System.Windows.Forms.CheckBox();
            this.cboSongs = new System.Windows.Forms.ComboBox();
            this.chkSat = new System.Windows.Forms.CheckBox();
            this.lblSong = new System.Windows.Forms.Label();
            this.chkTue = new System.Windows.Forms.CheckBox();
            this.lbldot = new System.Windows.Forms.Label();
            this.chkFri = new System.Windows.Forms.CheckBox();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.chkWed = new System.Windows.Forms.CheckBox();
            this.lblTimeAlarm = new System.Windows.Forms.Label();
            this.chkThu = new System.Windows.Forms.CheckBox();
            this.txtAlarmName = new System.Windows.Forms.TextBox();
            this.lblAlarmName = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstStopwatch = new System.Windows.Forms.ListView();
            this.colLapTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListHeight = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblLap = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblMinute = new System.Windows.Forms.Label();
            this.nMinute = new System.Windows.Forms.NumericUpDown();
            this.lblHour = new System.Windows.Forms.Label();
            this.nHour = new System.Windows.Forms.NumericUpDown();
            this.radSleep = new System.Windows.Forms.RadioButton();
            this.radLock = new System.Windows.Forms.RadioButton();
            this.radHibernate = new System.Windows.Forms.RadioButton();
            this.radLogoff = new System.Windows.Forms.RadioButton();
            this.radRestart = new System.Windows.Forms.RadioButton();
            this.radShutDown = new System.Windows.Forms.RadioButton();
            this.btnTimerStart = new System.Windows.Forms.Button();
            this.StopwatchTimer = new System.Windows.Forms.Timer(this.components);
            this.LapTimer = new System.Windows.Forms.Timer(this.components);
            this.AlarmContextMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursUD)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinute)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).BeginInit();
            this.SuspendLayout();
            // 
            // AlarmContextMenu
            // 
            this.AlarmContextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AlarmContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.playAlarmToolStripMenuItem,
            this.stopAlarmToolStripMenuItem});
            this.AlarmContextMenu.Name = "AlarmContextMenu";
            this.AlarmContextMenu.ShowImageMargin = false;
            this.AlarmContextMenu.Size = new System.Drawing.Size(109, 114);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.deleteToolStripMenuItem.Text = "&Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // playAlarmToolStripMenuItem
            // 
            this.playAlarmToolStripMenuItem.Name = "playAlarmToolStripMenuItem";
            this.playAlarmToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.playAlarmToolStripMenuItem.Text = "&Play Alarm";
            this.playAlarmToolStripMenuItem.Click += new System.EventHandler(this.playAlarmToolStripMenuItem_Click);
            // 
            // stopAlarmToolStripMenuItem
            // 
            this.stopAlarmToolStripMenuItem.Name = "stopAlarmToolStripMenuItem";
            this.stopAlarmToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.stopAlarmToolStripMenuItem.Text = "&Stop Alarm";
            this.stopAlarmToolStripMenuItem.Click += new System.EventHandler(this.stopAlarmToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 473);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage1.Controls.Add(this.lblgb);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.btnDel);
            this.tabPage1.Controls.Add(this.btnSaveAs);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Controls.Add(this.lblAlarmTitle);
            this.tabPage1.Controls.Add(this.lstAlarm);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(922, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Alarm";
            // 
            // lblgb
            // 
            this.lblgb.AutoSize = true;
            this.lblgb.BackColor = System.Drawing.Color.Transparent;
            this.lblgb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblgb.Location = new System.Drawing.Point(29, 53);
            this.lblgb.Name = "lblgb";
            this.lblgb.Size = new System.Drawing.Size(38, 13);
            this.lblgb.TabIndex = 22;
            this.lblgb.Text = "Alarm";
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(45, 379);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 56);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseMove);
            // 
            // btnDel
            // 
            this.btnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDel.BackgroundImage")));
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(468, 378);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 56);
            this.btnDel.TabIndex = 18;
            this.btnDel.Text = "Delete";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            this.btnDel.MouseLeave += new System.EventHandler(this.btnDel_MouseLeave);
            this.btnDel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDel_MouseMove);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.BackgroundImage")));
            this.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.Location = new System.Drawing.Point(186, 378);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(56, 56);
            this.btnSaveAs.TabIndex = 16;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            this.btnSaveAs.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            this.btnSaveAs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEdit_MouseMove);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(327, 379);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 56);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            this.btnRefresh.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnRefresh.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseMove);
            // 
            // lblAlarmTitle
            // 
            this.lblAlarmTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAlarmTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblAlarmTitle.Location = new System.Drawing.Point(-4, 11);
            this.lblAlarmTitle.Name = "lblAlarmTitle";
            this.lblAlarmTitle.Size = new System.Drawing.Size(930, 37);
            this.lblAlarmTitle.TabIndex = 16;
            this.lblAlarmTitle.Text = "List Alarm";
            this.lblAlarmTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstAlarm
            // 
            this.lstAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDate,
            this.colTime,
            this.colSong,
            this.colRepeat,
            this.colSnooze,
            this.colID});
            this.lstAlarm.ContextMenuStrip = this.AlarmContextMenu;
            this.lstAlarm.FullRowSelect = true;
            this.lstAlarm.GridLines = true;
            this.lstAlarm.Location = new System.Drawing.Point(574, 59);
            this.lstAlarm.MultiSelect = false;
            this.lstAlarm.Name = "lstAlarm";
            this.lstAlarm.Size = new System.Drawing.Size(342, 369);
            this.lstAlarm.TabIndex = 15;
            this.lstAlarm.UseCompatibleStateImageBehavior = false;
            this.lstAlarm.View = System.Windows.Forms.View.Details;
            this.lstAlarm.SelectedIndexChanged += new System.EventHandler(this.lstAlarm_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 40;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 0;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.Width = 40;
            // 
            // colSong
            // 
            this.colSong.Text = "Song";
            this.colSong.Width = 88;
            // 
            // colRepeat
            // 
            this.colRepeat.Text = "Repeat";
            this.colRepeat.Width = 120;
            // 
            // colSnooze
            // 
            this.colSnooze.Text = "Snooze";
            this.colSnooze.Width = 50;
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.MinutesUD);
            this.panel2.Controls.Add(this.HoursUD);
            this.panel2.Controls.Add(this.lblSnooze);
            this.panel2.Controls.Add(this.chkSnooze);
            this.panel2.Controls.Add(this.txtSong);
            this.panel2.Controls.Add(this.btnPickSong);
            this.panel2.Controls.Add(this.txtRepeat);
            this.panel2.Controls.Add(this.chkSun);
            this.panel2.Controls.Add(this.chkMon);
            this.panel2.Controls.Add(this.cboSongs);
            this.panel2.Controls.Add(this.chkSat);
            this.panel2.Controls.Add(this.lblSong);
            this.panel2.Controls.Add(this.chkTue);
            this.panel2.Controls.Add(this.lbldot);
            this.panel2.Controls.Add(this.chkFri);
            this.panel2.Controls.Add(this.lblRepeat);
            this.panel2.Controls.Add(this.chkWed);
            this.panel2.Controls.Add(this.lblTimeAlarm);
            this.panel2.Controls.Add(this.chkThu);
            this.panel2.Controls.Add(this.txtAlarmName);
            this.panel2.Controls.Add(this.lblAlarmName);
            this.panel2.Location = new System.Drawing.Point(6, 53);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(562, 309);
            this.panel2.TabIndex = 23;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // MinutesUD
            // 
            this.MinutesUD.BackColor = System.Drawing.Color.White;
            this.MinutesUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinutesUD.Location = new System.Drawing.Point(197, 80);
            this.MinutesUD.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MinutesUD.Name = "MinutesUD";
            this.MinutesUD.Size = new System.Drawing.Size(75, 20);
            this.MinutesUD.TabIndex = 2;
            this.MinutesUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // HoursUD
            // 
            this.HoursUD.BackColor = System.Drawing.Color.White;
            this.HoursUD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoursUD.Location = new System.Drawing.Point(96, 80);
            this.HoursUD.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.HoursUD.Name = "HoursUD";
            this.HoursUD.Size = new System.Drawing.Size(75, 20);
            this.HoursUD.TabIndex = 1;
            this.HoursUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSnooze
            // 
            this.lblSnooze.AutoSize = true;
            this.lblSnooze.BackColor = System.Drawing.Color.Transparent;
            this.lblSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSnooze.Location = new System.Drawing.Point(23, 269);
            this.lblSnooze.Name = "lblSnooze";
            this.lblSnooze.Size = new System.Drawing.Size(53, 13);
            this.lblSnooze.TabIndex = 79;
            this.lblSnooze.Text = "Snooze:";
            // 
            // chkSnooze
            // 
            this.chkSnooze.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSnooze.BackColor = System.Drawing.SystemColors.Control;
            this.chkSnooze.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkSnooze.BackgroundImage")));
            this.chkSnooze.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSnooze.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSnooze.ForeColor = System.Drawing.Color.White;
            this.chkSnooze.Location = new System.Drawing.Point(96, 263);
            this.chkSnooze.Name = "chkSnooze";
            this.chkSnooze.Size = new System.Drawing.Size(176, 24);
            this.chkSnooze.TabIndex = 7;
            this.chkSnooze.Text = "Snooze";
            this.chkSnooze.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSnooze.UseVisualStyleBackColor = false;
            this.chkSnooze.CheckedChanged += new System.EventHandler(this.chkSnooze_CheckedChanged);
            this.chkSnooze.MouseLeave += new System.EventHandler(this.chkSnooze_MouseLeave);
            this.chkSnooze.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkSnooze_MouseMove);
            // 
            // txtSong
            // 
            this.txtSong.BackColor = System.Drawing.Color.White;
            this.txtSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSong.Location = new System.Drawing.Point(26, 217);
            this.txtSong.MaxLength = 32;
            this.txtSong.Name = "txtSong";
            this.txtSong.Size = new System.Drawing.Size(160, 20);
            this.txtSong.TabIndex = 5;
            // 
            // btnPickSong
            // 
            this.btnPickSong.BackColor = System.Drawing.SystemColors.Control;
            this.btnPickSong.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPickSong.BackgroundImage")));
            this.btnPickSong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPickSong.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPickSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickSong.Location = new System.Drawing.Point(197, 215);
            this.btnPickSong.Name = "btnPickSong";
            this.btnPickSong.Size = new System.Drawing.Size(75, 23);
            this.btnPickSong.TabIndex = 6;
            this.btnPickSong.Text = "Pick a song";
            this.btnPickSong.UseVisualStyleBackColor = false;
            this.btnPickSong.Click += new System.EventHandler(this.btnPickSong_Click);
            this.btnPickSong.MouseLeave += new System.EventHandler(this.btnPickSong_MouseLeave);
            this.btnPickSong.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnPickSong_MouseMove);
            // 
            // txtRepeat
            // 
            this.txtRepeat.BackColor = System.Drawing.Color.White;
            this.txtRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeat.Location = new System.Drawing.Point(96, 124);
            this.txtRepeat.MaxLength = 32;
            this.txtRepeat.Name = "txtRepeat";
            this.txtRepeat.Size = new System.Drawing.Size(176, 20);
            this.txtRepeat.TabIndex = 3;
            // 
            // chkSun
            // 
            this.chkSun.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSun.BackColor = System.Drawing.SystemColors.Control;
            this.chkSun.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkSun.BackgroundImage")));
            this.chkSun.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSun.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSun.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSun.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSun.Location = new System.Drawing.Point(299, 263);
            this.chkSun.Name = "chkSun";
            this.chkSun.Size = new System.Drawing.Size(241, 23);
            this.chkSun.TabIndex = 14;
            this.chkSun.Text = "Every Sunday";
            this.chkSun.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkSun.UseVisualStyleBackColor = false;
            this.chkSun.CheckedChanged += new System.EventHandler(this.chkSun_CheckedChanged);
            // 
            // chkMon
            // 
            this.chkMon.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMon.BackColor = System.Drawing.SystemColors.Control;
            this.chkMon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkMon.BackgroundImage")));
            this.chkMon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkMon.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkMon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMon.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMon.Location = new System.Drawing.Point(299, 35);
            this.chkMon.Name = "chkMon";
            this.chkMon.Size = new System.Drawing.Size(241, 23);
            this.chkMon.TabIndex = 8;
            this.chkMon.Text = "Every Monday";
            this.chkMon.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkMon.UseVisualStyleBackColor = false;
            this.chkMon.CheckedChanged += new System.EventHandler(this.chkMon_CheckedChanged);
            // 
            // cboSongs
            // 
            this.cboSongs.BackColor = System.Drawing.Color.White;
            this.cboSongs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSongs.FormattingEnabled = true;
            this.cboSongs.Location = new System.Drawing.Point(96, 170);
            this.cboSongs.Name = "cboSongs";
            this.cboSongs.Size = new System.Drawing.Size(176, 21);
            this.cboSongs.TabIndex = 4;
            this.cboSongs.SelectedIndexChanged += new System.EventHandler(this.cboSongs_SelectedIndexChanged);
            // 
            // chkSat
            // 
            this.chkSat.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSat.BackColor = System.Drawing.SystemColors.Control;
            this.chkSat.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkSat.BackgroundImage")));
            this.chkSat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkSat.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkSat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSat.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSat.Location = new System.Drawing.Point(299, 225);
            this.chkSat.Name = "chkSat";
            this.chkSat.Size = new System.Drawing.Size(241, 23);
            this.chkSat.TabIndex = 13;
            this.chkSat.Text = "Every Saturday";
            this.chkSat.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkSat.UseVisualStyleBackColor = false;
            this.chkSat.CheckedChanged += new System.EventHandler(this.chkSat_CheckedChanged);
            // 
            // lblSong
            // 
            this.lblSong.AutoSize = true;
            this.lblSong.BackColor = System.Drawing.Color.Transparent;
            this.lblSong.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSong.Location = new System.Drawing.Point(23, 172);
            this.lblSong.Name = "lblSong";
            this.lblSong.Size = new System.Drawing.Size(40, 13);
            this.lblSong.TabIndex = 66;
            this.lblSong.Text = "Song:";
            // 
            // chkTue
            // 
            this.chkTue.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkTue.BackColor = System.Drawing.SystemColors.Control;
            this.chkTue.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkTue.BackgroundImage")));
            this.chkTue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkTue.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkTue.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkTue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTue.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTue.Location = new System.Drawing.Point(299, 73);
            this.chkTue.Name = "chkTue";
            this.chkTue.Size = new System.Drawing.Size(241, 23);
            this.chkTue.TabIndex = 9;
            this.chkTue.Text = "Every Tuesday";
            this.chkTue.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkTue.UseVisualStyleBackColor = false;
            this.chkTue.CheckedChanged += new System.EventHandler(this.chkTue_CheckedChanged);
            // 
            // lbldot
            // 
            this.lbldot.AutoSize = true;
            this.lbldot.BackColor = System.Drawing.Color.Transparent;
            this.lbldot.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldot.Location = new System.Drawing.Point(175, 76);
            this.lbldot.Name = "lbldot";
            this.lbldot.Size = new System.Drawing.Size(18, 26);
            this.lbldot.TabIndex = 65;
            this.lbldot.Text = ":";
            // 
            // chkFri
            // 
            this.chkFri.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkFri.BackColor = System.Drawing.SystemColors.Control;
            this.chkFri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkFri.BackgroundImage")));
            this.chkFri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkFri.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkFri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkFri.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFri.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkFri.Location = new System.Drawing.Point(299, 187);
            this.chkFri.Name = "chkFri";
            this.chkFri.Size = new System.Drawing.Size(241, 23);
            this.chkFri.TabIndex = 12;
            this.chkFri.Text = "Every Friday";
            this.chkFri.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkFri.UseVisualStyleBackColor = false;
            this.chkFri.CheckedChanged += new System.EventHandler(this.chkFri_CheckedChanged);
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.BackColor = System.Drawing.Color.Transparent;
            this.lblRepeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeat.Location = new System.Drawing.Point(23, 127);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(52, 13);
            this.lblRepeat.TabIndex = 64;
            this.lblRepeat.Text = "Repeat:";
            // 
            // chkWed
            // 
            this.chkWed.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkWed.BackColor = System.Drawing.SystemColors.Control;
            this.chkWed.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkWed.BackgroundImage")));
            this.chkWed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkWed.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkWed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkWed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWed.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWed.Location = new System.Drawing.Point(299, 111);
            this.chkWed.Name = "chkWed";
            this.chkWed.Size = new System.Drawing.Size(241, 23);
            this.chkWed.TabIndex = 10;
            this.chkWed.Text = "Every Wednesday";
            this.chkWed.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkWed.UseVisualStyleBackColor = false;
            this.chkWed.CheckedChanged += new System.EventHandler(this.chkWed_CheckedChanged);
            // 
            // lblTimeAlarm
            // 
            this.lblTimeAlarm.AutoSize = true;
            this.lblTimeAlarm.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeAlarm.Location = new System.Drawing.Point(23, 82);
            this.lblTimeAlarm.Name = "lblTimeAlarm";
            this.lblTimeAlarm.Size = new System.Drawing.Size(38, 13);
            this.lblTimeAlarm.TabIndex = 63;
            this.lblTimeAlarm.Text = "Time:";
            // 
            // chkThu
            // 
            this.chkThu.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkThu.BackColor = System.Drawing.SystemColors.Control;
            this.chkThu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkThu.BackgroundImage")));
            this.chkThu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkThu.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chkThu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkThu.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkThu.Location = new System.Drawing.Point(299, 149);
            this.chkThu.Name = "chkThu";
            this.chkThu.Size = new System.Drawing.Size(241, 23);
            this.chkThu.TabIndex = 11;
            this.chkThu.Text = "Every Thursday";
            this.chkThu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.chkThu.UseVisualStyleBackColor = false;
            this.chkThu.CheckedChanged += new System.EventHandler(this.chkThu_CheckedChanged);
            // 
            // txtAlarmName
            // 
            this.txtAlarmName.BackColor = System.Drawing.Color.White;
            this.txtAlarmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlarmName.Location = new System.Drawing.Point(96, 34);
            this.txtAlarmName.MaxLength = 32;
            this.txtAlarmName.Name = "txtAlarmName";
            this.txtAlarmName.Size = new System.Drawing.Size(176, 20);
            this.txtAlarmName.TabIndex = 0;
            // 
            // lblAlarmName
            // 
            this.lblAlarmName.AutoSize = true;
            this.lblAlarmName.BackColor = System.Drawing.Color.Transparent;
            this.lblAlarmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAlarmName.Location = new System.Drawing.Point(23, 37);
            this.lblAlarmName.Name = "lblAlarmName";
            this.lblAlarmName.Size = new System.Drawing.Size(78, 13);
            this.lblAlarmName.TabIndex = 61;
            this.lblAlarmName.Text = "Alarm Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage2.Controls.Add(this.lstStopwatch);
            this.tabPage2.Controls.Add(this.panel1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(922, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Stopwatch";
            // 
            // lstStopwatch
            // 
            this.lstStopwatch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lstStopwatch.BackgroundImage")));
            this.lstStopwatch.BackgroundImageTiled = true;
            this.lstStopwatch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStopwatch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLapTime});
            this.lstStopwatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstStopwatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstStopwatch.FullRowSelect = true;
            this.lstStopwatch.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstStopwatch.Location = new System.Drawing.Point(3, 207);
            this.lstStopwatch.Name = "lstStopwatch";
            this.lstStopwatch.Size = new System.Drawing.Size(916, 237);
            this.lstStopwatch.SmallImageList = this.ListHeight;
            this.lstStopwatch.TabIndex = 2;
            this.lstStopwatch.UseCompatibleStateImageBehavior = false;
            this.lstStopwatch.View = System.Windows.Forms.View.Details;
            // 
            // colLapTime
            // 
            this.colLapTime.Width = 549;
            // 
            // ListHeight
            // 
            this.ListHeight.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ListHeight.ImageSize = new System.Drawing.Size(1, 46);
            this.ListHeight.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.lblLap);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 204);
            this.panel1.TabIndex = 1;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReset.BackgroundImage")));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(522, 148);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(79, 37);
            this.btnReset.TabIndex = 19;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            this.btnReset.MouseLeave += new System.EventHandler(this.btnReset_MouseLeave);
            this.btnReset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnReset_MouseMove);
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStart.BackgroundImage")));
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(314, 148);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(79, 37);
            this.btnStart.TabIndex = 18;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            this.btnStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseMove);
            // 
            // lblLap
            // 
            this.lblLap.BackColor = System.Drawing.Color.Transparent;
            this.lblLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLap.ForeColor = System.Drawing.Color.Silver;
            this.lblLap.Location = new System.Drawing.Point(478, -3);
            this.lblLap.Name = "lblLap";
            this.lblLap.Size = new System.Drawing.Size(255, 50);
            this.lblLap.TabIndex = 1;
            this.lblLap.Text = "00:00,0";
            this.lblLap.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(180, 38);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(557, 100);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "00:00,0";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tabPage3.Controls.Add(this.lblMinute);
            this.tabPage3.Controls.Add(this.nMinute);
            this.tabPage3.Controls.Add(this.lblHour);
            this.tabPage3.Controls.Add(this.nHour);
            this.tabPage3.Controls.Add(this.radSleep);
            this.tabPage3.Controls.Add(this.radLock);
            this.tabPage3.Controls.Add(this.radHibernate);
            this.tabPage3.Controls.Add(this.radLogoff);
            this.tabPage3.Controls.Add(this.radRestart);
            this.tabPage3.Controls.Add(this.radShutDown);
            this.tabPage3.Controls.Add(this.btnTimerStart);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(922, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Timer";
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.BackColor = System.Drawing.Color.Transparent;
            this.lblMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinute.Location = new System.Drawing.Point(635, 81);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(139, 46);
            this.lblMinute.TabIndex = 28;
            this.lblMinute.Text = "Minute";
            // 
            // nMinute
            // 
            this.nMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nMinute.Location = new System.Drawing.Point(509, 67);
            this.nMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nMinute.Name = "nMinute";
            this.nMinute.Size = new System.Drawing.Size(120, 68);
            this.nMinute.TabIndex = 27;
            this.nMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblHour
            // 
            this.lblHour.AutoSize = true;
            this.lblHour.BackColor = System.Drawing.Color.Transparent;
            this.lblHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHour.Location = new System.Drawing.Point(270, 81);
            this.lblHour.Name = "lblHour";
            this.lblHour.Size = new System.Drawing.Size(107, 46);
            this.lblHour.TabIndex = 26;
            this.lblHour.Text = "Hour";
            // 
            // nHour
            // 
            this.nHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nHour.Location = new System.Drawing.Point(144, 67);
            this.nHour.Maximum = new decimal(new int[] {
            72,
            0,
            0,
            0});
            this.nHour.Name = "nHour";
            this.nHour.Size = new System.Drawing.Size(120, 68);
            this.nHour.TabIndex = 25;
            this.nHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // radSleep
            // 
            this.radSleep.Appearance = System.Windows.Forms.Appearance.Button;
            this.radSleep.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radSleep.BackgroundImage")));
            this.radSleep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radSleep.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radSleep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radSleep.ForeColor = System.Drawing.Color.White;
            this.radSleep.Location = new System.Drawing.Point(776, 209);
            this.radSleep.Name = "radSleep";
            this.radSleep.Size = new System.Drawing.Size(70, 70);
            this.radSleep.TabIndex = 24;
            this.radSleep.TabStop = true;
            this.radSleep.Text = "Sleep";
            this.radSleep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radSleep.UseVisualStyleBackColor = true;
            this.radSleep.CheckedChanged += new System.EventHandler(this.radSleep_CheckedChanged);
            this.radSleep.MouseLeave += new System.EventHandler(this.radSleep_MouseLeave);
            this.radSleep.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radSleep_MouseMove);
            // 
            // radLock
            // 
            this.radLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radLock.BackgroundImage")));
            this.radLock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radLock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLock.ForeColor = System.Drawing.Color.White;
            this.radLock.Location = new System.Drawing.Point(636, 209);
            this.radLock.Name = "radLock";
            this.radLock.Size = new System.Drawing.Size(70, 70);
            this.radLock.TabIndex = 23;
            this.radLock.TabStop = true;
            this.radLock.Text = "Lock";
            this.radLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLock.UseVisualStyleBackColor = true;
            this.radLock.CheckedChanged += new System.EventHandler(this.radLock_CheckedChanged);
            this.radLock.MouseLeave += new System.EventHandler(this.radLock_MouseLeave);
            this.radLock.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radLock_MouseMove);
            // 
            // radHibernate
            // 
            this.radHibernate.Appearance = System.Windows.Forms.Appearance.Button;
            this.radHibernate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radHibernate.BackgroundImage")));
            this.radHibernate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radHibernate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radHibernate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHibernate.ForeColor = System.Drawing.Color.White;
            this.radHibernate.Location = new System.Drawing.Point(496, 209);
            this.radHibernate.Name = "radHibernate";
            this.radHibernate.Size = new System.Drawing.Size(70, 70);
            this.radHibernate.TabIndex = 22;
            this.radHibernate.TabStop = true;
            this.radHibernate.Text = "Hibernate";
            this.radHibernate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radHibernate.UseVisualStyleBackColor = true;
            this.radHibernate.CheckedChanged += new System.EventHandler(this.radHibernate_CheckedChanged);
            this.radHibernate.MouseLeave += new System.EventHandler(this.radHibernate_MouseLeave);
            this.radHibernate.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radHibernate_MouseMove);
            // 
            // radLogoff
            // 
            this.radLogoff.Appearance = System.Windows.Forms.Appearance.Button;
            this.radLogoff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radLogoff.BackgroundImage")));
            this.radLogoff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radLogoff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radLogoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLogoff.ForeColor = System.Drawing.Color.White;
            this.radLogoff.Location = new System.Drawing.Point(356, 209);
            this.radLogoff.Name = "radLogoff";
            this.radLogoff.Size = new System.Drawing.Size(70, 70);
            this.radLogoff.TabIndex = 22;
            this.radLogoff.TabStop = true;
            this.radLogoff.Text = "Log off";
            this.radLogoff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLogoff.UseVisualStyleBackColor = true;
            this.radLogoff.CheckedChanged += new System.EventHandler(this.radLogoff_CheckedChanged);
            this.radLogoff.MouseLeave += new System.EventHandler(this.radLogoff_MouseLeave);
            this.radLogoff.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radLogoff_MouseMove);
            // 
            // radRestart
            // 
            this.radRestart.Appearance = System.Windows.Forms.Appearance.Button;
            this.radRestart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radRestart.BackgroundImage")));
            this.radRestart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radRestart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRestart.ForeColor = System.Drawing.Color.White;
            this.radRestart.Location = new System.Drawing.Point(216, 209);
            this.radRestart.Name = "radRestart";
            this.radRestart.Size = new System.Drawing.Size(70, 70);
            this.radRestart.TabIndex = 21;
            this.radRestart.TabStop = true;
            this.radRestart.Text = "Restart";
            this.radRestart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radRestart.UseVisualStyleBackColor = true;
            this.radRestart.CheckedChanged += new System.EventHandler(this.radRestart_CheckedChanged);
            this.radRestart.MouseLeave += new System.EventHandler(this.radRestart_MouseLeave);
            this.radRestart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radRestart_MouseMove);
            // 
            // radShutDown
            // 
            this.radShutDown.Appearance = System.Windows.Forms.Appearance.Button;
            this.radShutDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radShutDown.BackgroundImage")));
            this.radShutDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.radShutDown.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.radShutDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radShutDown.ForeColor = System.Drawing.Color.White;
            this.radShutDown.Location = new System.Drawing.Point(76, 209);
            this.radShutDown.Name = "radShutDown";
            this.radShutDown.Size = new System.Drawing.Size(70, 70);
            this.radShutDown.TabIndex = 20;
            this.radShutDown.TabStop = true;
            this.radShutDown.Text = "Shut Down";
            this.radShutDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.radShutDown.UseVisualStyleBackColor = true;
            this.radShutDown.CheckedChanged += new System.EventHandler(this.radShutDown_CheckedChanged);
            this.radShutDown.MouseLeave += new System.EventHandler(this.radShutDown_MouseLeave);
            this.radShutDown.MouseMove += new System.Windows.Forms.MouseEventHandler(this.radShutDown_MouseMove);
            // 
            // btnTimerStart
            // 
            this.btnTimerStart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTimerStart.BackgroundImage")));
            this.btnTimerStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTimerStart.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnTimerStart.FlatAppearance.BorderSize = 2;
            this.btnTimerStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Black;
            this.btnTimerStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnTimerStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTimerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimerStart.ForeColor = System.Drawing.Color.White;
            this.btnTimerStart.Location = new System.Drawing.Point(76, 311);
            this.btnTimerStart.Name = "btnTimerStart";
            this.btnTimerStart.Size = new System.Drawing.Size(770, 100);
            this.btnTimerStart.TabIndex = 19;
            this.btnTimerStart.Text = "Start";
            this.btnTimerStart.UseVisualStyleBackColor = true;
            this.btnTimerStart.Click += new System.EventHandler(this.btnTimerStart_Click);
            this.btnTimerStart.MouseLeave += new System.EventHandler(this.btnTimerStart_MouseLeave);
            this.btnTimerStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnTimerStart_MouseMove);
            // 
            // StopwatchTimer
            // 
            this.StopwatchTimer.Interval = 94;
            this.StopwatchTimer.Tick += new System.EventHandler(this.StopwatchTimer_Tick);
            // 
            // LapTimer
            // 
            this.LapTimer.Interval = 94;
            this.LapTimer.Tick += new System.EventHandler(this.LapTimer_Tick);
            // 
            // UC_Clock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.tabControl1);
            this.Name = "UC_Clock";
            this.Size = new System.Drawing.Size(930, 473);
            this.Load += new System.EventHandler(this.UC_Alarm_Load);
            this.AlarmContextMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HoursUD)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nMinute)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip AlarmContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem playAlarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopAlarmToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblAlarmTitle;
        private System.Windows.Forms.ListView lstAlarm;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.ColumnHeader colSong;
        private System.Windows.Forms.ColumnHeader colRepeat;
        private System.Windows.Forms.ColumnHeader colSnooze;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblLap;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListView lstStopwatch;
        private System.Windows.Forms.ColumnHeader colLapTime;
        private System.Windows.Forms.ImageList ListHeight;
        private System.Windows.Forms.Button btnTimerStart;
        private System.Windows.Forms.RadioButton radShutDown;
        private System.Windows.Forms.RadioButton radSleep;
        private System.Windows.Forms.RadioButton radLock;
        private System.Windows.Forms.RadioButton radHibernate;
        private System.Windows.Forms.RadioButton radLogoff;
        private System.Windows.Forms.RadioButton radRestart;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.NumericUpDown nMinute;
        private System.Windows.Forms.Label lblHour;
        private System.Windows.Forms.NumericUpDown nHour;
        private System.Windows.Forms.Timer StopwatchTimer;
        private System.Windows.Forms.Timer LapTimer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblgb;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown MinutesUD;
        private System.Windows.Forms.NumericUpDown HoursUD;
        private System.Windows.Forms.Label lblSnooze;
        private System.Windows.Forms.CheckBox chkSnooze;
        private System.Windows.Forms.TextBox txtSong;
        private System.Windows.Forms.Button btnPickSong;
        private System.Windows.Forms.TextBox txtRepeat;
        private System.Windows.Forms.CheckBox chkSun;
        private System.Windows.Forms.CheckBox chkMon;
        private System.Windows.Forms.ComboBox cboSongs;
        private System.Windows.Forms.CheckBox chkSat;
        private System.Windows.Forms.Label lblSong;
        private System.Windows.Forms.CheckBox chkTue;
        private System.Windows.Forms.Label lbldot;
        private System.Windows.Forms.CheckBox chkFri;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.CheckBox chkWed;
        private System.Windows.Forms.Label lblTimeAlarm;
        private System.Windows.Forms.CheckBox chkThu;
        private System.Windows.Forms.TextBox txtAlarmName;
        private System.Windows.Forms.Label lblAlarmName;
    }
}
