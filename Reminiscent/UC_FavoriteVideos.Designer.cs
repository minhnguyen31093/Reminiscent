namespace Reminiscent
{
    partial class UC_FavoriteVideos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_FavoriteVideos));
            this.WMPVideoPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstVideo = new System.Windows.Forms.ListView();
            this.colIDVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocationVideo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VideoContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveVideo = new System.Windows.Forms.Button();
            this.btnAddVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WMPVideoPlayer)).BeginInit();
            this.VideoContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // WMPVideoPlayer
            // 
            this.WMPVideoPlayer.Enabled = true;
            this.WMPVideoPlayer.Location = new System.Drawing.Point(22, 22);
            this.WMPVideoPlayer.Name = "WMPVideoPlayer";
            this.WMPVideoPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMPVideoPlayer.OcxState")));
            this.WMPVideoPlayer.Size = new System.Drawing.Size(436, 358);
            this.WMPVideoPlayer.TabIndex = 0;
            // 
            // lstVideo
            // 
            this.lstVideo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIDVideo,
            this.colNameVideo,
            this.colLocationVideo});
            this.lstVideo.ContextMenuStrip = this.VideoContextMenu;
            this.lstVideo.FullRowSelect = true;
            this.lstVideo.GridLines = true;
            this.lstVideo.Location = new System.Drawing.Point(464, 22);
            this.lstVideo.MultiSelect = false;
            this.lstVideo.Name = "lstVideo";
            this.lstVideo.Size = new System.Drawing.Size(435, 358);
            this.lstVideo.TabIndex = 1;
            this.lstVideo.UseCompatibleStateImageBehavior = false;
            this.lstVideo.View = System.Windows.Forms.View.Details;
            this.lstVideo.SelectedIndexChanged += new System.EventHandler(this.lstVideo_SelectedIndexChanged);
            this.lstVideo.DoubleClick += new System.EventHandler(this.lstVideo_DoubleClick);
            // 
            // colIDVideo
            // 
            this.colIDVideo.Text = "ID";
            // 
            // colNameVideo
            // 
            this.colNameVideo.Text = "Name";
            this.colNameVideo.Width = 150;
            // 
            // colLocationVideo
            // 
            this.colLocationVideo.Text = "Location";
            this.colLocationVideo.Width = 221;
            // 
            // VideoContextMenu
            // 
            this.VideoContextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VideoContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem});
            this.VideoContextMenu.Name = "VideoContextMenu";
            this.VideoContextMenu.ShowImageMargin = false;
            this.VideoContextMenu.Size = new System.Drawing.Size(149, 104);
            // 
            // openFileLocationToolStripMenuItem
            // 
            this.openFileLocationToolStripMenuItem.Name = "openFileLocationToolStripMenuItem";
            this.openFileLocationToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.openFileLocationToolStripMenuItem.Text = "Open File Location";
            this.openFileLocationToolStripMenuItem.Click += new System.EventHandler(this.openFileLocationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(145, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
            // 
            // btnRemoveVideo
            // 
            this.btnRemoveVideo.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveVideo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveVideo.BackgroundImage")));
            this.btnRemoveVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveVideo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveVideo.Image")));
            this.btnRemoveVideo.Location = new System.Drawing.Point(568, 386);
            this.btnRemoveVideo.Name = "btnRemoveVideo";
            this.btnRemoveVideo.Size = new System.Drawing.Size(60, 50);
            this.btnRemoveVideo.TabIndex = 3;
            this.btnRemoveVideo.Text = "Remove";
            this.btnRemoveVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveVideo.UseVisualStyleBackColor = false;
            this.btnRemoveVideo.Click += new System.EventHandler(this.btnRemoveVideo_Click);
            this.btnRemoveVideo.MouseLeave += new System.EventHandler(this.btnRemoveVideo_MouseLeave);
            this.btnRemoveVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemoveVideo_MouseMove);
            // 
            // btnAddVideo
            // 
            this.btnAddVideo.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddVideo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddVideo.BackgroundImage")));
            this.btnAddVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddVideo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddVideo.Image = ((System.Drawing.Image)(resources.GetObject("btnAddVideo.Image")));
            this.btnAddVideo.Location = new System.Drawing.Point(276, 386);
            this.btnAddVideo.Name = "btnAddVideo";
            this.btnAddVideo.Size = new System.Drawing.Size(60, 50);
            this.btnAddVideo.TabIndex = 2;
            this.btnAddVideo.Text = "Add";
            this.btnAddVideo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddVideo.UseVisualStyleBackColor = false;
            this.btnAddVideo.Click += new System.EventHandler(this.btnAddVideo_Click);
            this.btnAddVideo.MouseLeave += new System.EventHandler(this.btnAddVideo_MouseLeave);
            this.btnAddVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAddVideo_MouseMove);
            // 
            // UC_FavoriteVideos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnRemoveVideo);
            this.Controls.Add(this.btnAddVideo);
            this.Controls.Add(this.lstVideo);
            this.Controls.Add(this.WMPVideoPlayer);
            this.Name = "UC_FavoriteVideos";
            this.Size = new System.Drawing.Size(922, 447);
            this.Load += new System.EventHandler(this.UC_FavoriteVideos_Load);
            this.Leave += new System.EventHandler(this.UC_FavoriteVideos_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.WMPVideoPlayer)).EndInit();
            this.VideoContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public AxWMPLib.AxWindowsMediaPlayer WMPVideoPlayer;
        internal System.Windows.Forms.ListView lstVideo;
        private System.Windows.Forms.ColumnHeader colIDVideo;
        private System.Windows.Forms.ColumnHeader colNameVideo;
        private System.Windows.Forms.ColumnHeader colLocationVideo;
        private System.Windows.Forms.Button btnRemoveVideo;
        private System.Windows.Forms.Button btnAddVideo;
        private System.Windows.Forms.ContextMenuStrip VideoContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
    }
}
