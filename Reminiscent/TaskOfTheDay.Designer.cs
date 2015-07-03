namespace Reminiscent
{
    partial class frmTaskOfTheDay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskOfTheDay));
            this.cmsTaskOfTheDay = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panleTitle = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.PanelListView = new System.Windows.Forms.Panel();
            this.lvwTaskOfTheDay = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsTaskOfTheDay.SuspendLayout();
            this.panleTitle.SuspendLayout();
            this.PanelListView.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsTaskOfTheDay
            // 
            this.cmsTaskOfTheDay.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refeshToolStripMenuItem,
            this.onTopToolStripMenuItem,
            this.toolStripSeparator1,
            this.closeToolStripMenuItem});
            this.cmsTaskOfTheDay.Name = "cmsTaskOfTheDay";
            this.cmsTaskOfTheDay.Size = new System.Drawing.Size(153, 98);
            // 
            // refeshToolStripMenuItem
            // 
            this.refeshToolStripMenuItem.Name = "refeshToolStripMenuItem";
            this.refeshToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.refeshToolStripMenuItem.Text = "Refresh";
            this.refeshToolStripMenuItem.Click += new System.EventHandler(this.refeshToolStripMenuItem_Click);
            // 
            // onTopToolStripMenuItem
            // 
            this.onTopToolStripMenuItem.Checked = true;
            this.onTopToolStripMenuItem.CheckOnClick = true;
            this.onTopToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onTopToolStripMenuItem.Name = "onTopToolStripMenuItem";
            this.onTopToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.onTopToolStripMenuItem.Text = "On Top";
            this.onTopToolStripMenuItem.Click += new System.EventHandler(this.onTopToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click_1);
            // 
            // panleTitle
            // 
            this.panleTitle.Controls.Add(this.lblTitle);
            this.panleTitle.Controls.Add(this.btnClose);
            this.panleTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panleTitle.Location = new System.Drawing.Point(0, 0);
            this.panleTitle.Name = "panleTitle";
            this.panleTitle.Size = new System.Drawing.Size(494, 26);
            this.panleTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(468, 26);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Task of the day";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            // 
            // btnClose
            // 
            this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(468, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 26);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseHover += new System.EventHandler(this.btnClose_MouseHover);
            // 
            // PanelListView
            // 
            this.PanelListView.Controls.Add(this.lvwTaskOfTheDay);
            this.PanelListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelListView.Location = new System.Drawing.Point(0, 26);
            this.PanelListView.Name = "PanelListView";
            this.PanelListView.Size = new System.Drawing.Size(494, 405);
            this.PanelListView.TabIndex = 2;
            // 
            // lvwTaskOfTheDay
            // 
            this.lvwTaskOfTheDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvwTaskOfTheDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwTaskOfTheDay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colDes,
            this.colTime});
            this.lvwTaskOfTheDay.ContextMenuStrip = this.cmsTaskOfTheDay;
            this.lvwTaskOfTheDay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwTaskOfTheDay.FullRowSelect = true;
            this.lvwTaskOfTheDay.GridLines = true;
            this.lvwTaskOfTheDay.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwTaskOfTheDay.Location = new System.Drawing.Point(0, 0);
            this.lvwTaskOfTheDay.Name = "lvwTaskOfTheDay";
            this.lvwTaskOfTheDay.Size = new System.Drawing.Size(494, 405);
            this.lvwTaskOfTheDay.TabIndex = 1;
            this.lvwTaskOfTheDay.UseCompatibleStateImageBehavior = false;
            this.lvwTaskOfTheDay.View = System.Windows.Forms.View.Details;
            this.lvwTaskOfTheDay.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvwTaskOfTheDay_DrawColumnHeader);
            // 
            // colName
            // 
            this.colName.Text = "Task Name";
            this.colName.Width = 130;
            // 
            // colDes
            // 
            this.colDes.Text = "Description";
            this.colDes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDes.Width = 300;
            // 
            // colTime
            // 
            this.colTime.Text = "Time";
            this.colTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmTaskOfTheDay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(494, 431);
            this.Controls.Add(this.PanelListView);
            this.Controls.Add(this.panleTitle);
            this.MaximumSize = new System.Drawing.Size(510, 470);
            this.Name = "frmTaskOfTheDay";
            this.ShowInTaskbar = false;
            this.Text = "Task Of The Day";
            this.Load += new System.EventHandler(this.frmTaskOfTheDay_Load);
            this.cmsTaskOfTheDay.ResumeLayout(false);
            this.panleTitle.ResumeLayout(false);
            this.PanelListView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmsTaskOfTheDay;
        private System.Windows.Forms.ToolStripMenuItem onTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshToolStripMenuItem;
        private System.Windows.Forms.Panel panleTitle;
        private System.Windows.Forms.Panel PanelListView;
        private System.Windows.Forms.ListView lvwTaskOfTheDay;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDes;
        private System.Windows.Forms.ColumnHeader colTime;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
    }
}