namespace Reminiscent
{
    partial class frmStickyNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStickyNote));
            this.NoteContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.blueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.purpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.TitleContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNew = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.NotePanel = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.NewToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.lblSize = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.NoteContextMenu.SuspendLayout();
            this.TitleContextMenu.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.NotePanel.SuspendLayout();
            this.PanelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // NoteContextMenu
            // 
            resources.ApplyResources(this.NoteContextMenu, "NoteContextMenu");
            this.NoteContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.toolStripSeparator1,
            this.selectAllToolStripMenuItem,
            this.toolStripSeparator2,
            this.blueToolStripMenuItem,
            this.pinkToolStripMenuItem,
            this.greenToolStripMenuItem,
            this.purpleToolStripMenuItem,
            this.whiteToolStripMenuItem,
            this.yellowToolStripMenuItem});
            this.NoteContextMenu.Name = "NoteContextMenu";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            resources.ApplyResources(this.cutToolStripMenuItem, "cutToolStripMenuItem");
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            resources.ApplyResources(this.copyToolStripMenuItem, "copyToolStripMenuItem");
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            resources.ApplyResources(this.pasteToolStripMenuItem, "pasteToolStripMenuItem");
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            resources.ApplyResources(this.deleteToolStripMenuItem, "deleteToolStripMenuItem");
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            resources.ApplyResources(this.selectAllToolStripMenuItem, "selectAllToolStripMenuItem");
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // blueToolStripMenuItem
            // 
            resources.ApplyResources(this.blueToolStripMenuItem, "blueToolStripMenuItem");
            this.blueToolStripMenuItem.Name = "blueToolStripMenuItem";
            this.blueToolStripMenuItem.Click += new System.EventHandler(this.blueToolStripMenuItem_Click);
            // 
            // pinkToolStripMenuItem
            // 
            resources.ApplyResources(this.pinkToolStripMenuItem, "pinkToolStripMenuItem");
            this.pinkToolStripMenuItem.Name = "pinkToolStripMenuItem";
            this.pinkToolStripMenuItem.Click += new System.EventHandler(this.pinkToolStripMenuItem_Click);
            // 
            // greenToolStripMenuItem
            // 
            resources.ApplyResources(this.greenToolStripMenuItem, "greenToolStripMenuItem");
            this.greenToolStripMenuItem.Name = "greenToolStripMenuItem";
            this.greenToolStripMenuItem.Click += new System.EventHandler(this.greenToolStripMenuItem_Click);
            // 
            // purpleToolStripMenuItem
            // 
            resources.ApplyResources(this.purpleToolStripMenuItem, "purpleToolStripMenuItem");
            this.purpleToolStripMenuItem.Name = "purpleToolStripMenuItem";
            this.purpleToolStripMenuItem.Click += new System.EventHandler(this.purpleToolStripMenuItem_Click);
            // 
            // whiteToolStripMenuItem
            // 
            resources.ApplyResources(this.whiteToolStripMenuItem, "whiteToolStripMenuItem");
            this.whiteToolStripMenuItem.Name = "whiteToolStripMenuItem";
            this.whiteToolStripMenuItem.Click += new System.EventHandler(this.whiteToolStripMenuItem_Click);
            // 
            // yellowToolStripMenuItem
            // 
            resources.ApplyResources(this.yellowToolStripMenuItem, "yellowToolStripMenuItem");
            this.yellowToolStripMenuItem.Name = "yellowToolStripMenuItem";
            this.yellowToolStripMenuItem.Click += new System.EventHandler(this.yellowToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.ContextMenuStrip = this.TitleContextMenu;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.Name = "btnClose";
            this.NewToolTip.SetToolTip(this.btnClose, resources.GetString("btnClose.ToolTip"));
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseDown);
            this.btnClose.MouseLeave += new System.EventHandler(this.btnClose_MouseLeave);
            this.btnClose.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnClose_MouseMove);
            // 
            // TitleContextMenu
            // 
            resources.ApplyResources(this.TitleContextMenu, "TitleContextMenu");
            this.TitleContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.onTopToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.TitleContextMenu.Name = "TitleContextMenu";
            this.TitleContextMenu.ShowCheckMargin = true;
            this.TitleContextMenu.ShowImageMargin = false;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            resources.ApplyResources(this.newToolStripMenuItem, "newToolStripMenuItem");
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // onTopToolStripMenuItem
            // 
            this.onTopToolStripMenuItem.CheckOnClick = true;
            this.onTopToolStripMenuItem.Name = "onTopToolStripMenuItem";
            resources.ApplyResources(this.onTopToolStripMenuItem, "onTopToolStripMenuItem");
            this.onTopToolStripMenuItem.Click += new System.EventHandler(this.onTopToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // btnNew
            // 
            resources.ApplyResources(this.btnNew, "btnNew");
            this.btnNew.ContextMenuStrip = this.TitleContextMenu;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.Name = "btnNew";
            this.NewToolTip.SetToolTip(this.btnNew, resources.GetString("btnNew.ToolTip"));
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseDown);
            this.btnNew.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnNew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseMove);
            // 
            // TitlePanel
            // 
            this.TitlePanel.ContextMenuStrip = this.TitleContextMenu;
            this.TitlePanel.Controls.Add(this.btnNew);
            this.TitlePanel.Controls.Add(this.btnClose);
            resources.ApplyResources(this.TitlePanel, "TitlePanel");
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseDown);
            this.TitlePanel.MouseLeave += new System.EventHandler(this.TitlePanel_MouseLeave);
            this.TitlePanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitlePanel_MouseMove);
            // 
            // NotePanel
            // 
            this.NotePanel.ContextMenuStrip = this.NoteContextMenu;
            this.NotePanel.Controls.Add(this.txtNote);
            resources.ApplyResources(this.NotePanel, "NotePanel");
            this.NotePanel.Name = "NotePanel";
            // 
            // txtNote
            // 
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.ContextMenuStrip = this.NoteContextMenu;
            resources.ApplyResources(this.txtNote, "txtNote");
            this.txtNote.Name = "txtNote";
            this.txtNote.SelectionChanged += new System.EventHandler(this.txtNote_SelectionChanged);
            this.txtNote.TextChanged += new System.EventHandler(this.txtNote_TextChanged);
            // 
            // PanelBottom
            // 
            this.PanelBottom.ContextMenuStrip = this.NoteContextMenu;
            this.PanelBottom.Controls.Add(this.lblSize);
            resources.ApplyResources(this.PanelBottom, "PanelBottom");
            this.PanelBottom.Name = "PanelBottom";
            // 
            // lblSize
            // 
            this.lblSize.ContextMenuStrip = this.NoteContextMenu;
            resources.ApplyResources(this.lblSize, "lblSize");
            this.lblSize.Name = "lblSize";
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // frmStickyNote
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.NoteContextMenu;
            this.Controls.Add(this.NotePanel);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.TitlePanel);
            this.MaximizeBox = false;
            this.Name = "frmStickyNote";
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.frmStickyNote_Activated);
            this.Deactivate += new System.EventHandler(this.frmStickyNote_Deactivate);
            this.Load += new System.EventHandler(this.StickyNote_Load);
            this.ResizeEnd += new System.EventHandler(this.frmStickyNote_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.frmStickyNote_LocationChanged);
            this.NoteContextMenu.ResumeLayout(false);
            this.TitleContextMenu.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.NotePanel.ResumeLayout(false);
            this.PanelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip NoteContextMenu;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Panel NotePanel;
        private System.Windows.Forms.ToolTip NewToolTip;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem blueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem purpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yellowToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip TitleContextMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onTopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel PanelBottom;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.Timer Timer;
    }
}