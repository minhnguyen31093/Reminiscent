namespace Reminiscent
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tstxtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.tscboSearch = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbtnUp = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDown = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnRecurring = new System.Windows.Forms.ToolStripButton();
            this.tsbtnIdea = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSchedule = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAlarm = new System.Windows.Forms.ToolStripButton();
            this.tsbtnDictionary = new System.Windows.Forms.ToolStripButton();
            this.tsbtnFavorite = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSticky = new System.Windows.Forms.ToolStripButton();
            this.tsbtnAccount = new System.Windows.Forms.ToolStripButton();
            this.tsbtnOthers = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnRefesh = new System.Windows.Forms.ToolStripButton();
            this.tsbtnToday = new System.Windows.Forms.ToolStripButton();
            this.panelContent = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.cmsNotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(110)))), ((int)(((byte)(189)))));
            this.menuStrip1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("menuStrip1.BackgroundImage")));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(930, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.optionToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.importToolStripMenuItem.Text = "Import";
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.optionToolStripMenuItem.Text = "Option";
            this.optionToolStripMenuItem.Click += new System.EventHandler(this.optionToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
            this.panelMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelMenu.BackgroundImage")));
            this.panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelMenu.Controls.Add(this.toolStrip2);
            this.panelMenu.Controls.Add(this.toolStrip4);
            this.panelMenu.Controls.Add(this.toolStrip3);
            this.panelMenu.Controls.Add(this.toolStrip1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 24);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(930, 65);
            this.panelMenu.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstxtSearch,
            this.tscboSearch});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip2.Location = new System.Drawing.Point(752, -1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(110, 67);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "toolStrip2";
            this.toolStrip2.Paint += new System.Windows.Forms.PaintEventHandler(this.toolStrip2_Paint);
            // 
            // tstxtSearch
            // 
            this.tstxtSearch.Margin = new System.Windows.Forms.Padding(1, 7, 0, 0);
            this.tstxtSearch.Name = "tstxtSearch";
            this.tstxtSearch.Size = new System.Drawing.Size(106, 23);
            // 
            // tscboSearch
            // 
            this.tscboSearch.AutoSize = false;
            this.tscboSearch.BackColor = System.Drawing.SystemColors.Window;
            this.tscboSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscboSearch.Margin = new System.Windows.Forms.Padding(1, 7, 0, 0);
            this.tscboSearch.Name = "tscboSearch";
            this.tscboSearch.Size = new System.Drawing.Size(106, 23);
            this.tscboSearch.SelectedIndexChanged += new System.EventHandler(this.tscboSearch_SelectedIndexChanged);
            // 
            // toolStrip4
            // 
            this.toolStrip4.AutoSize = false;
            this.toolStrip4.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip4.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip4.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.tsbtnSearch});
            this.toolStrip4.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip4.Location = new System.Drawing.Point(746, -1);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(191, 67);
            this.toolStrip4.TabIndex = 7;
            this.toolStrip4.Text = "toolStrip2";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.AutoSize = false;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 64);
            // 
            // tsbtnSearch
            // 
            this.tsbtnSearch.AutoSize = false;
            this.tsbtnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsbtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSearch.Image")));
            this.tsbtnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSearch.Margin = new System.Windows.Forms.Padding(110, 1, 0, 2);
            this.tsbtnSearch.Name = "tsbtnSearch";
            this.tsbtnSearch.Size = new System.Drawing.Size(64, 64);
            this.tsbtnSearch.Text = "Search";
            this.tsbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSearch.Click += new System.EventHandler(this.tsbtnSearch_Click);
            // 
            // toolStrip3
            // 
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnUp,
            this.tsbtnDown});
            this.toolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.toolStrip3.Location = new System.Drawing.Point(715, -1);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(37, 67);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip4";
            // 
            // tsbtnUp
            // 
            this.tsbtnUp.AutoSize = false;
            this.tsbtnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnUp.Image")));
            this.tsbtnUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnUp.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.tsbtnUp.Name = "tsbtnUp";
            this.tsbtnUp.Size = new System.Drawing.Size(29, 29);
            this.tsbtnUp.Text = "Page Up";
            this.tsbtnUp.Click += new System.EventHandler(this.tsbtnUp_Click);
            // 
            // tsbtnDown
            // 
            this.tsbtnDown.AutoSize = false;
            this.tsbtnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDown.Image")));
            this.tsbtnDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDown.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            this.tsbtnDown.Name = "tsbtnDown";
            this.tsbtnDown.Size = new System.Drawing.Size(29, 29);
            this.tsbtnDown.Text = "Page Down";
            this.tsbtnDown.Click += new System.EventHandler(this.tsbtnDown_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnRecurring,
            this.tsbtnIdea,
            this.tsbtnSchedule,
            this.tsbtnAlarm,
            this.tsbtnDictionary,
            this.tsbtnFavorite,
            this.tsbtnSticky,
            this.tsbtnAccount,
            this.tsbtnOthers,
            this.toolStripSeparator5,
            this.tsbtnRefesh,
            this.tsbtnToday});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(721, 66);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip3";
            // 
            // tsbtnRecurring
            // 
            this.tsbtnRecurring.AutoSize = false;
            this.tsbtnRecurring.CheckOnClick = true;
            this.tsbtnRecurring.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnRecurring.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRecurring.Image")));
            this.tsbtnRecurring.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRecurring.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRecurring.Name = "tsbtnRecurring";
            this.tsbtnRecurring.Size = new System.Drawing.Size(64, 64);
            this.tsbtnRecurring.Text = "Recurring";
            this.tsbtnRecurring.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRecurring.CheckedChanged += new System.EventHandler(this.tsbtnRecurring_CheckedChanged);
            this.tsbtnRecurring.Click += new System.EventHandler(this.tsbtnRecurring_Click);
            // 
            // tsbtnIdea
            // 
            this.tsbtnIdea.AutoSize = false;
            this.tsbtnIdea.CheckOnClick = true;
            this.tsbtnIdea.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnIdea.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnIdea.Image")));
            this.tsbtnIdea.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnIdea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnIdea.Name = "tsbtnIdea";
            this.tsbtnIdea.Size = new System.Drawing.Size(64, 64);
            this.tsbtnIdea.Text = "Idea";
            this.tsbtnIdea.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnIdea.CheckedChanged += new System.EventHandler(this.tsbtnIdea_CheckedChanged);
            this.tsbtnIdea.Click += new System.EventHandler(this.tsbtnIdea_Click);
            // 
            // tsbtnSchedule
            // 
            this.tsbtnSchedule.AutoSize = false;
            this.tsbtnSchedule.CheckOnClick = true;
            this.tsbtnSchedule.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnSchedule.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSchedule.Image")));
            this.tsbtnSchedule.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSchedule.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSchedule.Name = "tsbtnSchedule";
            this.tsbtnSchedule.Size = new System.Drawing.Size(64, 64);
            this.tsbtnSchedule.Text = "Schedule";
            this.tsbtnSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSchedule.CheckedChanged += new System.EventHandler(this.tsbtnSchedule_CheckedChanged);
            this.tsbtnSchedule.Click += new System.EventHandler(this.tsbtnSchedule_Click);
            // 
            // tsbtnAlarm
            // 
            this.tsbtnAlarm.AutoSize = false;
            this.tsbtnAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tsbtnAlarm.CheckOnClick = true;
            this.tsbtnAlarm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnAlarm.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAlarm.Image")));
            this.tsbtnAlarm.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnAlarm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAlarm.Name = "tsbtnAlarm";
            this.tsbtnAlarm.Size = new System.Drawing.Size(64, 64);
            this.tsbtnAlarm.Text = "Clock";
            this.tsbtnAlarm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnAlarm.CheckedChanged += new System.EventHandler(this.tsbtnAlarm_CheckedChanged);
            this.tsbtnAlarm.Click += new System.EventHandler(this.tsbtnAlarm_Click);
            // 
            // tsbtnDictionary
            // 
            this.tsbtnDictionary.AutoSize = false;
            this.tsbtnDictionary.CheckOnClick = true;
            this.tsbtnDictionary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnDictionary.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnDictionary.Image")));
            this.tsbtnDictionary.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnDictionary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnDictionary.Name = "tsbtnDictionary";
            this.tsbtnDictionary.Size = new System.Drawing.Size(64, 64);
            this.tsbtnDictionary.Text = "Dictionary";
            this.tsbtnDictionary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnDictionary.CheckedChanged += new System.EventHandler(this.tsbtnDictionary_CheckedChanged);
            this.tsbtnDictionary.Click += new System.EventHandler(this.tsbtnDictionary_Click);
            // 
            // tsbtnFavorite
            // 
            this.tsbtnFavorite.AutoSize = false;
            this.tsbtnFavorite.CheckOnClick = true;
            this.tsbtnFavorite.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnFavorite.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFavorite.Image")));
            this.tsbtnFavorite.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnFavorite.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFavorite.Name = "tsbtnFavorite";
            this.tsbtnFavorite.Size = new System.Drawing.Size(64, 64);
            this.tsbtnFavorite.Text = "Favorite";
            this.tsbtnFavorite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnFavorite.CheckedChanged += new System.EventHandler(this.tsbtnFavorite_CheckedChanged);
            this.tsbtnFavorite.Click += new System.EventHandler(this.tsbtnFavorite_Click);
            // 
            // tsbtnSticky
            // 
            this.tsbtnSticky.AutoSize = false;
            this.tsbtnSticky.CheckOnClick = true;
            this.tsbtnSticky.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnSticky.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSticky.Image")));
            this.tsbtnSticky.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnSticky.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSticky.Name = "tsbtnSticky";
            this.tsbtnSticky.Size = new System.Drawing.Size(64, 64);
            this.tsbtnSticky.Text = "Sticky";
            this.tsbtnSticky.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnSticky.CheckedChanged += new System.EventHandler(this.tsbtnSticky_CheckedChanged);
            this.tsbtnSticky.Click += new System.EventHandler(this.tsbtnSticky_Click);
            // 
            // tsbtnAccount
            // 
            this.tsbtnAccount.AutoSize = false;
            this.tsbtnAccount.CheckOnClick = true;
            this.tsbtnAccount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnAccount.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAccount.Image")));
            this.tsbtnAccount.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnAccount.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAccount.Name = "tsbtnAccount";
            this.tsbtnAccount.Size = new System.Drawing.Size(64, 64);
            this.tsbtnAccount.Text = "Account";
            this.tsbtnAccount.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnAccount.CheckedChanged += new System.EventHandler(this.tsbtnAccount_CheckedChanged);
            this.tsbtnAccount.Click += new System.EventHandler(this.tsbtnAccount_Click);
            // 
            // tsbtnOthers
            // 
            this.tsbtnOthers.AutoSize = false;
            this.tsbtnOthers.CheckOnClick = true;
            this.tsbtnOthers.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnOthers.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnOthers.Image")));
            this.tsbtnOthers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnOthers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnOthers.Name = "tsbtnOthers";
            this.tsbtnOthers.Size = new System.Drawing.Size(64, 64);
            this.tsbtnOthers.Text = "Others";
            this.tsbtnOthers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnOthers.CheckedChanged += new System.EventHandler(this.tsbtnOthers_CheckedChanged);
            this.tsbtnOthers.Click += new System.EventHandler(this.tsbtnOthers_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.AutoSize = false;
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 64);
            // 
            // tsbtnRefesh
            // 
            this.tsbtnRefesh.AutoSize = false;
            this.tsbtnRefesh.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnRefesh.Image")));
            this.tsbtnRefesh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnRefesh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnRefesh.Name = "tsbtnRefesh";
            this.tsbtnRefesh.Size = new System.Drawing.Size(64, 64);
            this.tsbtnRefesh.Text = "Refresh";
            this.tsbtnRefesh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnRefesh.Click += new System.EventHandler(this.tsbtnRefesh_Click);
            // 
            // tsbtnToday
            // 
            this.tsbtnToday.AutoSize = false;
            this.tsbtnToday.Checked = true;
            this.tsbtnToday.CheckOnClick = true;
            this.tsbtnToday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbtnToday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tsbtnToday.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnToday.Image")));
            this.tsbtnToday.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbtnToday.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnToday.Name = "tsbtnToday";
            this.tsbtnToday.Size = new System.Drawing.Size(64, 64);
            this.tsbtnToday.Text = "Home";
            this.tsbtnToday.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbtnToday.CheckedChanged += new System.EventHandler(this.tsbtnToday_CheckedChanged);
            this.tsbtnToday.Click += new System.EventHandler(this.tsbtnToday_Click);
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
            this.panelContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelContent.BackgroundImage")));
            this.panelContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelContent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContent.Controls.Add(this.statusStrip);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 89);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(930, 500);
            this.panelContent.TabIndex = 5;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(231)))), ((int)(((byte)(248)))));
            this.statusStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 473);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip.Size = new System.Drawing.Size(926, 23);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusTime
            // 
            this.toolStripStatusTime.Image = ((System.Drawing.Image)(resources.GetObject("toolStripStatusTime.Image")));
            this.toolStripStatusTime.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusTime.Name = "toolStripStatusTime";
            this.toolStripStatusTime.Size = new System.Drawing.Size(18, 18);
            this.toolStripStatusTime.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // timerMain
            // 
            this.timerMain.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "My Recurring";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // cmsNotify
            // 
            this.cmsNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmOpen,
            this.toolStripSeparator4,
            this.tsmExit});
            this.cmsNotify.Name = "cmsNotify";
            this.cmsNotify.Size = new System.Drawing.Size(104, 54);
            // 
            // tsmOpen
            // 
            this.tsmOpen.Name = "tsmOpen";
            this.tsmOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmOpen.Text = "Open";
            this.tsmOpen.Click += new System.EventHandler(this.tsmOpen_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(100, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(103, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(175)))), ((int)(((byte)(218)))));
            this.ClientSize = new System.Drawing.Size(930, 589);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(946, 628);
            this.MinimumSize = new System.Drawing.Size(946, 628);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminiscent";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.cmsNotify.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusTime;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsNotify;
        private System.Windows.Forms.ToolStripMenuItem tsmOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnRecurring;
        private System.Windows.Forms.ToolStripButton tsbtnIdea;
        private System.Windows.Forms.ToolStripButton tsbtnSchedule;
        private System.Windows.Forms.ToolStripButton tsbtnAlarm;
        private System.Windows.Forms.ToolStripButton tsbtnDictionary;
        private System.Windows.Forms.ToolStripButton tsbtnFavorite;
        private System.Windows.Forms.ToolStripButton tsbtnSticky;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbtnUp;
        private System.Windows.Forms.ToolStripButton tsbtnDown;
        private System.Windows.Forms.ToolStripButton tsbtnRefesh;
        private System.Windows.Forms.ToolStripButton tsbtnToday;
        private System.Windows.Forms.ToolStripButton tsbtnAccount;
        private System.Windows.Forms.ToolStripButton tsbtnOthers;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripTextBox tstxtSearch;
        private System.Windows.Forms.ToolStripComboBox tscboSearch;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbtnSearch;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;


    }
}

