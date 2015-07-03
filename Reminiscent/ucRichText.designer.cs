namespace Gift
{
    partial class ucRichText
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucRichText));
            ExtendedRichTextBox.CharStyle charStyle1 = new ExtendedRichTextBox.CharStyle();
            ExtendedRichTextBox.ParaLineSpacing paraLineSpacing1 = new ExtendedRichTextBox.ParaLineSpacing();
            ExtendedRichTextBox.ParaListStyle paraListStyle1 = new ExtendedRichTextBox.ParaListStyle();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.cmsRightMouse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConvert = new System.Windows.Forms.ToolStripMenuItem();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddPicture = new System.Windows.Forms.ToolStripButton();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.btnHighLightColor = new System.Windows.Forms.ToolStripButton();
            this.rtxShow = new ExtendedRichTextBox();
            this.tlpMain.SuspendLayout();
            this.cmsRightMouse.SuspendLayout();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.rtxShow, 0, 1);
            this.tlpMain.Controls.Add(this.tlsTool, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(620, 430);
            this.tlpMain.TabIndex = 1;
            // 
            // cmsRightMouse
            // 
            this.cmsRightMouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCopy,
            this.mnuCut,
            this.mnuPaste,
            this.mnuConvert});
            this.cmsRightMouse.Name = "cmsRightMouse";
            this.cmsRightMouse.Size = new System.Drawing.Size(178, 92);
            // 
            // mnuCopy
            // 
            this.mnuCopy.Image = global::Reminiscent.Properties.Resources.btnCopy;
            this.mnuCopy.Name = "mnuCopy";
            this.mnuCopy.Size = new System.Drawing.Size(177, 22);
            this.mnuCopy.Text = "Copy";
            this.mnuCopy.Click += new System.EventHandler(this.mnuCopy_Click);
            // 
            // mnuCut
            // 
            this.mnuCut.Image = global::Reminiscent.Properties.Resources.btnCut;
            this.mnuCut.Name = "mnuCut";
            this.mnuCut.Size = new System.Drawing.Size(177, 22);
            this.mnuCut.Text = "Cut";
            this.mnuCut.Click += new System.EventHandler(this.mnuCut_Click);
            // 
            // mnuPaste
            // 
            this.mnuPaste.Image = global::Reminiscent.Properties.Resources.btnPaste;
            this.mnuPaste.Name = "mnuPaste";
            this.mnuPaste.Size = new System.Drawing.Size(177, 22);
            this.mnuPaste.Text = "Paste";
            this.mnuPaste.Click += new System.EventHandler(this.mnuPaste_Click);
            // 
            // mnuConvert
            // 
            this.mnuConvert.Name = "mnuConvert";
            this.mnuConvert.Size = new System.Drawing.Size(177, 22);
            this.mnuConvert.Text = "Convert to Rtf code";
            this.mnuConvert.Click += new System.EventHandler(this.mnuConvert_Click);
            // 
            // tlsTool
            // 
            this.tlsTool.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tlsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBold,
            this.btnItalic,
            this.btnUnderline,
            this.toolStripSeparator1,
            this.btnAlignLeft,
            this.btnAlignCenter,
            this.btnAlignRight,
            this.toolStripSeparator2,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator3,
            this.btnAddPicture,
            this.btnColor,
            this.btnHighLightColor});
            this.tlsTool.Location = new System.Drawing.Point(0, 0);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(620, 25);
            this.tlsTool.TabIndex = 1;
            this.tlsTool.Text = "toolStrip1";
            // 
            // btnBold
            // 
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnBold.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBold.Image = ((System.Drawing.Image)(resources.GetObject("btnBold.Image")));
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(23, 22);
            this.btnBold.Text = "B";
            this.btnBold.Click += new System.EventHandler(this.btnBold_Click);
            // 
            // btnItalic
            // 
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnItalic.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnItalic.Image = ((System.Drawing.Image)(resources.GetObject("btnItalic.Image")));
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(23, 22);
            this.btnItalic.Text = "I";
            this.btnItalic.Click += new System.EventHandler(this.btnItalic_Click);
            // 
            // btnUnderline
            // 
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUnderline.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("btnUnderline.Image")));
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(23, 22);
            this.btnUnderline.Text = "U";
            this.btnUnderline.Click += new System.EventHandler(this.btnUnderline_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft.Image = global::Reminiscent.Properties.Resources.btnAlignLeft;
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.btnAlignLeft.Text = "toolStripButton1";
            this.btnAlignLeft.Click += new System.EventHandler(this.btnLeftAlign_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = global::Reminiscent.Properties.Resources.btnAlignCenter;
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.btnAlignCenter.Text = "toolStripButton1";
            this.btnAlignCenter.Click += new System.EventHandler(this.btnCenterAlign_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = global::Reminiscent.Properties.Resources.btnAlignRight;
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(23, 22);
            this.btnAlignRight.Text = "toolStripButton1";
            this.btnAlignRight.Click += new System.EventHandler(this.btnRightAlign_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "toolStripButton1";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "toolStripButton1";
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddPicture
            // 
            this.btnAddPicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddPicture.Image = global::Reminiscent.Properties.Resources.mnuInsertPicture;
            this.btnAddPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(23, 22);
            this.btnAddPicture.Text = "toolStripButton1";
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor.Image = global::Reminiscent.Properties.Resources.mnuTextColor;
            this.btnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(23, 22);
            this.btnColor.Text = "toolStripButton1";
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnHighLightColor
            // 
            this.btnHighLightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHighLightColor.Image = global::Reminiscent.Properties.Resources.mnuHighlightColor;
            this.btnHighLightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHighLightColor.Name = "btnHighLightColor";
            this.btnHighLightColor.Size = new System.Drawing.Size(23, 22);
            this.btnHighLightColor.Text = "toolStripButton1";
            this.btnHighLightColor.Click += new System.EventHandler(this.btnHighLightColor_Click);
            // 
            // rtxShow
            // 
            this.rtxShow.BackColor = System.Drawing.Color.Honeydew;
            this.rtxShow.ContextMenuStrip = this.cmsRightMouse;
            this.rtxShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxShow.Location = new System.Drawing.Point(3, 30);
            this.rtxShow.Name = "rtxShow";
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.rtxShow.SelectionCharStyle = charStyle1;
            this.rtxShow.SelectionFont2 = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.rtxShow.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            this.rtxShow.SelectionListType = paraListStyle1;
            this.rtxShow.SelectionOffsetType = ExtendedRichTextBox.OffsetType.None;
            this.rtxShow.SelectionSpaceAfter = 0;
            this.rtxShow.SelectionSpaceBefore = 0;
            this.rtxShow.Size = new System.Drawing.Size(614, 397);
            this.rtxShow.TabIndex = 2;
            this.rtxShow.Text = "";
            // 
            // ucRichText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ContextMenuStrip = this.cmsRightMouse;
            this.Controls.Add(this.tlpMain);
            this.Name = "ucRichText";
            this.Size = new System.Drawing.Size(620, 430);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.cmsRightMouse.ResumeLayout(false);
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.ContextMenuStrip cmsRightMouse;
        private System.Windows.Forms.ToolStripMenuItem mnuCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuCut;
        private System.Windows.Forms.ToolStripMenuItem mnuPaste;
        private System.Windows.Forms.ToolStripMenuItem mnuConvert;
        private ExtendedRichTextBox rtxShow;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAddPicture;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnHighLightColor;
    }
}
