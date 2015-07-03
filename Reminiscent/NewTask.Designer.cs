namespace Reminiscent
{
    partial class NewTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTask));
            ExtendedRichTextBox.CharStyle charStyle1 = new ExtendedRichTextBox.CharStyle();
            ExtendedRichTextBox.ParaLineSpacing paraLineSpacing1 = new ExtendedRichTextBox.ParaLineSpacing();
            ExtendedRichTextBox.ParaListStyle paraListStyle1 = new ExtendedRichTextBox.ParaListStyle();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblPPP = new System.Windows.Forms.Label();
            this.lblPA = new System.Windows.Forms.Label();
            this.nPPP = new System.Windows.Forms.NumericUpDown();
            this.nPA = new System.Windows.Forms.NumericUpDown();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblDes = new System.Windows.Forms.Label();
            this.tlsTool = new System.Windows.Forms.ToolStrip();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cboFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.btnRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddPicture = new System.Windows.Forms.ToolStripButton();
            this.btnColor = new System.Windows.Forms.ToolStripButton();
            this.btnHighLightColor = new System.Windows.Forms.ToolStripButton();
            this.txtTaskDes = new ExtendedRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nPPP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPA)).BeginInit();
            this.tlsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTaskName
            // 
            this.txtTaskName.BackColor = System.Drawing.Color.White;
            this.txtTaskName.Location = new System.Drawing.Point(12, 31);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(450, 20);
            this.txtTaskName.TabIndex = 31;
            // 
            // lblTaskName
            // 
            this.lblTaskName.BackColor = System.Drawing.Color.Transparent;
            this.lblTaskName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTaskName.Location = new System.Drawing.Point(12, 7);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(450, 21);
            this.lblTaskName.TabIndex = 30;
            this.lblTaskName.Text = "Task Name";
            this.lblTaskName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPPP
            // 
            this.lblPPP.AutoSize = true;
            this.lblPPP.BackColor = System.Drawing.Color.Transparent;
            this.lblPPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPPP.Location = new System.Drawing.Point(12, 61);
            this.lblPPP.Name = "lblPPP";
            this.lblPPP.Size = new System.Drawing.Size(117, 13);
            this.lblPPP.TabIndex = 32;
            this.lblPPP.Text = "Percent per Project";
            // 
            // lblPA
            // 
            this.lblPA.AutoSize = true;
            this.lblPA.BackColor = System.Drawing.Color.Transparent;
            this.lblPA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPA.Location = new System.Drawing.Point(263, 61);
            this.lblPA.Name = "lblPA";
            this.lblPA.Size = new System.Drawing.Size(133, 13);
            this.lblPA.TabIndex = 33;
            this.lblPA.Text = "Percent Accomplished";
            // 
            // nPPP
            // 
            this.nPPP.BackColor = System.Drawing.Color.White;
            this.nPPP.Location = new System.Drawing.Point(151, 59);
            this.nPPP.Name = "nPPP";
            this.nPPP.Size = new System.Drawing.Size(60, 20);
            this.nPPP.TabIndex = 34;
            // 
            // nPA
            // 
            this.nPA.BackColor = System.Drawing.Color.White;
            this.nPA.Location = new System.Drawing.Point(402, 59);
            this.nPA.Name = "nPA";
            this.nPA.Size = new System.Drawing.Size(60, 20);
            this.nPA.TabIndex = 35;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(280, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 80;
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
            this.btnOK.Location = new System.Drawing.Point(116, 285);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(79, 37);
            this.btnOK.TabIndex = 79;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.MouseLeave += new System.EventHandler(this.btnOK_MouseLeave);
            this.btnOK.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnOK_MouseMove);
            // 
            // lblDes
            // 
            this.lblDes.AutoSize = true;
            this.lblDes.BackColor = System.Drawing.Color.Transparent;
            this.lblDes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDes.Location = new System.Drawing.Point(12, 85);
            this.lblDes.Name = "lblDes";
            this.lblDes.Size = new System.Drawing.Size(71, 13);
            this.lblDes.TabIndex = 82;
            this.lblDes.Text = "Description";
            // 
            // tlsTool
            // 
            this.tlsTool.AutoSize = false;
            this.tlsTool.Dock = System.Windows.Forms.DockStyle.None;
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
            this.cboFontSize,
            this.toolStripSeparator4,
            this.btnUndo,
            this.btnRedo,
            this.toolStripSeparator3,
            this.btnAddPicture,
            this.btnColor,
            this.btnHighLightColor});
            this.tlsTool.Location = new System.Drawing.Point(15, 102);
            this.tlsTool.Name = "tlsTool";
            this.tlsTool.Size = new System.Drawing.Size(447, 25);
            this.tlsTool.TabIndex = 84;
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
            this.btnAlignLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignLeft.Image")));
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(23, 22);
            this.btnAlignLeft.Text = "Align Left";
            this.btnAlignLeft.Click += new System.EventHandler(this.btnLeftAlign_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignCenter.Image")));
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(23, 22);
            this.btnAlignCenter.Text = "Align Center";
            this.btnAlignCenter.Click += new System.EventHandler(this.btnCenterAlign_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = ((System.Drawing.Image)(resources.GetObject("btnAlignRight.Image")));
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(23, 22);
            this.btnAlignRight.Text = "Align Right";
            this.btnAlignRight.Click += new System.EventHandler(this.btnRightAlign_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // cboFontSize
            // 
            this.cboFontSize.AutoSize = false;
            this.cboFontSize.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
            this.cboFontSize.Name = "cboFontSize";
            this.cboFontSize.Size = new System.Drawing.Size(35, 23);
            this.cboFontSize.Text = "8";
            this.cboFontSize.SelectedIndexChanged += new System.EventHandler(this.cboFontSize_SelectedIndexChanged);
            this.cboFontSize.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboFontSize_KeyDown);
            this.cboFontSize.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cboFontSize_KeyUp);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Image = ((System.Drawing.Image)(resources.GetObject("btnUndo.Image")));
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(23, 22);
            this.btnUndo.Text = "Undo";
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRedo
            // 
            this.btnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRedo.Image = ((System.Drawing.Image)(resources.GetObject("btnRedo.Image")));
            this.btnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(23, 22);
            this.btnRedo.Text = "Redo";
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
            this.btnAddPicture.Image = ((System.Drawing.Image)(resources.GetObject("btnAddPicture.Image")));
            this.btnAddPicture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddPicture.Name = "btnAddPicture";
            this.btnAddPicture.Size = new System.Drawing.Size(23, 22);
            this.btnAddPicture.Text = "Add Picture";
            this.btnAddPicture.Click += new System.EventHandler(this.btnAddPicture_Click);
            // 
            // btnColor
            // 
            this.btnColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(23, 22);
            this.btnColor.Text = "Text Color";
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnHighLightColor
            // 
            this.btnHighLightColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnHighLightColor.Image = ((System.Drawing.Image)(resources.GetObject("btnHighLightColor.Image")));
            this.btnHighLightColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHighLightColor.Name = "btnHighLightColor";
            this.btnHighLightColor.Size = new System.Drawing.Size(23, 22);
            this.btnHighLightColor.Text = "HighLight Color";
            this.btnHighLightColor.Click += new System.EventHandler(this.btnHighLightColor_Click);
            // 
            // txtTaskDes
            // 
            this.txtTaskDes.BackColor = System.Drawing.Color.White;
            this.txtTaskDes.Location = new System.Drawing.Point(12, 130);
            this.txtTaskDes.Name = "txtTaskDes";
            charStyle1.Bold = false;
            charStyle1.Italic = false;
            charStyle1.Link = false;
            charStyle1.Strikeout = false;
            charStyle1.Underline = false;
            this.txtTaskDes.SelectionCharStyle = charStyle1;
            this.txtTaskDes.SelectionFont2 = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Inch);
            paraLineSpacing1.ExactSpacing = 0;
            paraLineSpacing1.SpacingStyle = ExtendedRichTextBox.ParaLineSpacing.LineSpacingStyle.Unknown;
            this.txtTaskDes.SelectionLineSpacing = paraLineSpacing1;
            paraListStyle1.BulletCharCode = ((short)(0));
            paraListStyle1.NumberingStart = ((short)(0));
            paraListStyle1.Style = ExtendedRichTextBox.ParaListStyle.ListStyle.NumberAndParenthesis;
            paraListStyle1.Type = ExtendedRichTextBox.ParaListStyle.ListType.None;
            this.txtTaskDes.SelectionListType = paraListStyle1;
            this.txtTaskDes.SelectionOffsetType = ExtendedRichTextBox.OffsetType.None;
            this.txtTaskDes.SelectionSpaceAfter = 0;
            this.txtTaskDes.SelectionSpaceBefore = 0;
            this.txtTaskDes.Size = new System.Drawing.Size(450, 146);
            this.txtTaskDes.TabIndex = 85;
            this.txtTaskDes.Text = "";
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(474, 331);
            this.Controls.Add(this.txtTaskDes);
            this.Controls.Add(this.tlsTool);
            this.Controls.Add(this.lblDes);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.nPA);
            this.Controls.Add(this.nPPP);
            this.Controls.Add(this.lblPA);
            this.Controls.Add(this.lblPPP);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "NewTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Task";
            this.Load += new System.EventHandler(this.NewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nPPP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPA)).EndInit();
            this.tlsTool.ResumeLayout(false);
            this.tlsTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblPPP;
        private System.Windows.Forms.Label lblPA;
        private System.Windows.Forms.NumericUpDown nPPP;
        private System.Windows.Forms.NumericUpDown nPA;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblDes;
        private System.Windows.Forms.ToolStrip tlsTool;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripComboBox cboFontSize;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripButton btnRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnAddPicture;
        private System.Windows.Forms.ToolStripButton btnColor;
        private System.Windows.Forms.ToolStripButton btnHighLightColor;
        private ExtendedRichTextBox txtTaskDes;
    }
}