namespace Reminiscent
{
    partial class UC_FavoriteAudios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_FavoriteAudios));
            this.WMPAudioPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.lstAudio = new System.Windows.Forms.ListView();
            this.colIDAudio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNameAudio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocationAudio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AudioContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFileLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRemoveAudio = new System.Windows.Forms.Button();
            this.btnAddAudio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.WMPAudioPlayer)).BeginInit();
            this.AudioContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // WMPAudioPlayer
            // 
            this.WMPAudioPlayer.Enabled = true;
            this.WMPAudioPlayer.Location = new System.Drawing.Point(22, 22);
            this.WMPAudioPlayer.Name = "WMPAudioPlayer";
            this.WMPAudioPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("WMPAudioPlayer.OcxState")));
            this.WMPAudioPlayer.Size = new System.Drawing.Size(877, 45);
            this.WMPAudioPlayer.TabIndex = 0;
            // 
            // lstAudio
            // 
            this.lstAudio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIDAudio,
            this.colNameAudio,
            this.colLocationAudio});
            this.lstAudio.ContextMenuStrip = this.AudioContextMenu;
            this.lstAudio.FullRowSelect = true;
            this.lstAudio.GridLines = true;
            this.lstAudio.Location = new System.Drawing.Point(22, 79);
            this.lstAudio.MultiSelect = false;
            this.lstAudio.Name = "lstAudio";
            this.lstAudio.Size = new System.Drawing.Size(877, 301);
            this.lstAudio.TabIndex = 1;
            this.lstAudio.UseCompatibleStateImageBehavior = false;
            this.lstAudio.View = System.Windows.Forms.View.Details;
            this.lstAudio.SelectedIndexChanged += new System.EventHandler(this.lstAudio_SelectedIndexChanged);
            this.lstAudio.DoubleClick += new System.EventHandler(this.lstAudio_DoubleClick);
            // 
            // colIDAudio
            // 
            this.colIDAudio.Text = "ID";
            // 
            // colNameAudio
            // 
            this.colNameAudio.Text = "Name";
            this.colNameAudio.Width = 250;
            // 
            // colLocationAudio
            // 
            this.colLocationAudio.Text = "Location";
            this.colLocationAudio.Width = 563;
            // 
            // AudioContextMenu
            // 
            this.AudioContextMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AudioContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileLocationToolStripMenuItem,
            this.toolStripSeparator1,
            this.copyToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator2,
            this.propertiesToolStripMenuItem});
            this.AudioContextMenu.Name = "AudioContextMenu";
            this.AudioContextMenu.ShowImageMargin = false;
            this.AudioContextMenu.Size = new System.Drawing.Size(149, 104);
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
            // btnRemoveAudio
            // 
            this.btnRemoveAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnRemoveAudio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRemoveAudio.BackgroundImage")));
            this.btnRemoveAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRemoveAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemoveAudio.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAudio.Image")));
            this.btnRemoveAudio.Location = new System.Drawing.Point(568, 386);
            this.btnRemoveAudio.Name = "btnRemoveAudio";
            this.btnRemoveAudio.Size = new System.Drawing.Size(60, 50);
            this.btnRemoveAudio.TabIndex = 3;
            this.btnRemoveAudio.Text = "Remove";
            this.btnRemoveAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnRemoveAudio.UseVisualStyleBackColor = false;
            this.btnRemoveAudio.Click += new System.EventHandler(this.btnRemoveAudio_Click);
            this.btnRemoveAudio.MouseLeave += new System.EventHandler(this.btnRemoveAudio_MouseLeave);
            this.btnRemoveAudio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnRemoveAudio_MouseMove);
            // 
            // btnAddAudio
            // 
            this.btnAddAudio.BackColor = System.Drawing.SystemColors.Control;
            this.btnAddAudio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAddAudio.BackgroundImage")));
            this.btnAddAudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAddAudio.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAddAudio.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAudio.Image")));
            this.btnAddAudio.Location = new System.Drawing.Point(276, 386);
            this.btnAddAudio.Name = "btnAddAudio";
            this.btnAddAudio.Size = new System.Drawing.Size(60, 50);
            this.btnAddAudio.TabIndex = 2;
            this.btnAddAudio.Text = "Add";
            this.btnAddAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddAudio.UseVisualStyleBackColor = false;
            this.btnAddAudio.Click += new System.EventHandler(this.btnAddAudio_Click);
            this.btnAddAudio.MouseLeave += new System.EventHandler(this.btnAddAudio_MouseLeave);
            this.btnAddAudio.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnAddAudio_MouseMove);
            // 
            // UC_FavoriteAudios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.btnRemoveAudio);
            this.Controls.Add(this.btnAddAudio);
            this.Controls.Add(this.lstAudio);
            this.Controls.Add(this.WMPAudioPlayer);
            this.Name = "UC_FavoriteAudios";
            this.Size = new System.Drawing.Size(922, 447);
            this.Load += new System.EventHandler(this.UC_FavoriteAudios_Load);
            this.Leave += new System.EventHandler(this.UC_FavoriteAudios_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.WMPAudioPlayer)).EndInit();
            this.AudioContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxWMPLib.AxWindowsMediaPlayer WMPAudioPlayer;
        internal System.Windows.Forms.ListView lstAudio;
        private System.Windows.Forms.ColumnHeader colIDAudio;
        private System.Windows.Forms.ColumnHeader colNameAudio;
        private System.Windows.Forms.ColumnHeader colLocationAudio;
        private System.Windows.Forms.Button btnRemoveAudio;
        private System.Windows.Forms.Button btnAddAudio;
        private System.Windows.Forms.ContextMenuStrip AudioContextMenu;
        private System.Windows.Forms.ToolStripMenuItem openFileLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
    }
}
