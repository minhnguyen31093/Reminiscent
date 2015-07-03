namespace Reminiscent
{
    partial class UC_Sticky
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Sticky));
            this.lblStickyTitle = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstNote = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWidth = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colHeight = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocationX = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocationY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colColor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOnTop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colShow = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSaveAs = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtNote = new System.Windows.Forms.RichTextBox();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLX = new System.Windows.Forms.TextBox();
            this.txtLY = new System.Windows.Forms.TextBox();
            this.chkOnTop = new System.Windows.Forms.CheckBox();
            this.lblSize = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.lblOnTop = new System.Windows.Forms.Label();
            this.lblShow = new System.Windows.Forms.Label();
            this.chkShow = new System.Windows.Forms.CheckBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtNote = new System.Windows.Forms.DateTimePicker();
            this.dgvNote = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNote)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStickyTitle
            // 
            this.lblStickyTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStickyTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblStickyTitle.Location = new System.Drawing.Point(0, 21);
            this.lblStickyTitle.Name = "lblStickyTitle";
            this.lblStickyTitle.Size = new System.Drawing.Size(930, 37);
            this.lblStickyTitle.TabIndex = 0;
            this.lblStickyTitle.Text = "Sticky Note";
            this.lblStickyTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(195, 413);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(56, 56);
            this.btnNew.TabIndex = 11;
            this.btnNew.Text = "Refresh";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnNew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseMove);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.Control;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(23, 413);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 56);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseLeave += new System.EventHandler(this.btnSave_MouseLeave);
            this.btnSave.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseMove);
            // 
            // lstNote
            // 
            this.lstNote.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colDate,
            this.colNote,
            this.colWidth,
            this.colHeight,
            this.colLocationX,
            this.colLocationY,
            this.colColor,
            this.colOnTop,
            this.colShow});
            this.lstNote.FullRowSelect = true;
            this.lstNote.GridLines = true;
            this.lstNote.Location = new System.Drawing.Point(359, 72);
            this.lstNote.MultiSelect = false;
            this.lstNote.Name = "lstNote";
            this.lstNote.Size = new System.Drawing.Size(571, 399);
            this.lstNote.TabIndex = 21;
            this.lstNote.UseCompatibleStateImageBehavior = false;
            this.lstNote.View = System.Windows.Forms.View.Details;
            this.lstNote.SelectedIndexChanged += new System.EventHandler(this.lstNote_SelectedIndexChanged);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 0;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 80;
            // 
            // colNote
            // 
            this.colNote.Text = "Note";
            this.colNote.Width = 127;
            // 
            // colWidth
            // 
            this.colWidth.Text = "Width";
            this.colWidth.Width = 50;
            // 
            // colHeight
            // 
            this.colHeight.Text = "Height";
            this.colHeight.Width = 50;
            // 
            // colLocationX
            // 
            this.colLocationX.Text = "LocationX";
            // 
            // colLocationY
            // 
            this.colLocationY.Text = "LocationY";
            // 
            // colColor
            // 
            this.colColor.Text = "Color";
            this.colColor.Width = 50;
            // 
            // colOnTop
            // 
            this.colOnTop.Text = "OnTop";
            this.colOnTop.Width = 50;
            // 
            // colShow
            // 
            this.colShow.Text = "Show";
            this.colShow.Width = 40;
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveAs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.BackgroundImage")));
            this.btnSaveAs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveAs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.Location = new System.Drawing.Point(109, 413);
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(56, 56);
            this.btnSaveAs.TabIndex = 10;
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveAs.UseVisualStyleBackColor = false;
            this.btnSaveAs.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnSaveAs.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            this.btnSaveAs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEdit_MouseMove);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnDel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDel.BackgroundImage")));
            this.btnDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(281, 413);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(56, 56);
            this.btnDel.TabIndex = 12;
            this.btnDel.Text = "Delete";
            this.btnDel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            this.btnDel.MouseLeave += new System.EventHandler(this.btnDel_MouseLeave);
            this.btnDel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDel_MouseMove);
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.White;
            this.txtNote.Location = new System.Drawing.Point(0, 72);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(359, 142);
            this.txtNote.TabIndex = 0;
            this.txtNote.Text = "";
            // 
            // cboColor
            // 
            this.cboColor.BackColor = System.Drawing.Color.White;
            this.cboColor.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboColor.FormattingEnabled = true;
            this.cboColor.ItemHeight = 13;
            this.cboColor.Location = new System.Drawing.Point(122, 326);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(208, 21);
            this.cboColor.TabIndex = 13;
            // 
            // txtWidth
            // 
            this.txtWidth.BackColor = System.Drawing.Color.White;
            this.txtWidth.Location = new System.Drawing.Point(122, 264);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(90, 20);
            this.txtWidth.TabIndex = 2;
            this.txtWidth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWidth_KeyPress);
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.White;
            this.txtHeight.Location = new System.Drawing.Point(236, 264);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(94, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHeight_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(218, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "X";
            // 
            // txtLX
            // 
            this.txtLX.BackColor = System.Drawing.Color.White;
            this.txtLX.Location = new System.Drawing.Point(122, 295);
            this.txtLX.Name = "txtLX";
            this.txtLX.Size = new System.Drawing.Size(90, 20);
            this.txtLX.TabIndex = 4;
            this.txtLX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLX_KeyPress);
            // 
            // txtLY
            // 
            this.txtLY.BackColor = System.Drawing.Color.White;
            this.txtLY.Location = new System.Drawing.Point(236, 295);
            this.txtLY.Name = "txtLY";
            this.txtLY.Size = new System.Drawing.Size(94, 20);
            this.txtLY.TabIndex = 5;
            this.txtLY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLY_KeyPress);
            // 
            // chkOnTop
            // 
            this.chkOnTop.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkOnTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkOnTop.BackgroundImage")));
            this.chkOnTop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkOnTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkOnTop.Location = new System.Drawing.Point(122, 356);
            this.chkOnTop.Name = "chkOnTop";
            this.chkOnTop.Size = new System.Drawing.Size(208, 21);
            this.chkOnTop.TabIndex = 7;
            this.chkOnTop.Text = "OnTop";
            this.chkOnTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkOnTop.UseVisualStyleBackColor = true;
            this.chkOnTop.CheckedChanged += new System.EventHandler(this.chkOnTop_CheckedChanged);
            this.chkOnTop.MouseLeave += new System.EventHandler(this.chkOnTop_MouseLeave);
            this.chkOnTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkOnTop_MouseMove);
            // 
            // lblSize
            // 
            this.lblSize.AutoSize = true;
            this.lblSize.BackColor = System.Drawing.Color.Transparent;
            this.lblSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSize.Location = new System.Drawing.Point(32, 267);
            this.lblSize.Name = "lblSize";
            this.lblSize.Size = new System.Drawing.Size(31, 13);
            this.lblSize.TabIndex = 16;
            this.lblSize.Text = "Size";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.BackColor = System.Drawing.Color.Transparent;
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocation.Location = new System.Drawing.Point(32, 298);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(56, 13);
            this.lblLocation.TabIndex = 17;
            this.lblLocation.Text = "Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(220, 298);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = ",";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.BackColor = System.Drawing.Color.Transparent;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColor.Location = new System.Drawing.Point(32, 329);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(36, 13);
            this.lblColor.TabIndex = 18;
            this.lblColor.Text = "Color";
            // 
            // lblOnTop
            // 
            this.lblOnTop.AutoSize = true;
            this.lblOnTop.BackColor = System.Drawing.Color.Transparent;
            this.lblOnTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnTop.Location = new System.Drawing.Point(32, 360);
            this.lblOnTop.Name = "lblOnTop";
            this.lblOnTop.Size = new System.Drawing.Size(45, 13);
            this.lblOnTop.TabIndex = 19;
            this.lblOnTop.Text = "OnTop";
            // 
            // lblShow
            // 
            this.lblShow.AutoSize = true;
            this.lblShow.BackColor = System.Drawing.Color.Transparent;
            this.lblShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShow.Location = new System.Drawing.Point(32, 391);
            this.lblShow.Name = "lblShow";
            this.lblShow.Size = new System.Drawing.Size(38, 13);
            this.lblShow.TabIndex = 20;
            this.lblShow.Text = "Show";
            // 
            // chkShow
            // 
            this.chkShow.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkShow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkShow.BackgroundImage")));
            this.chkShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.chkShow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkShow.Location = new System.Drawing.Point(122, 387);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(208, 21);
            this.chkShow.TabIndex = 8;
            this.chkShow.Text = "Show";
            this.chkShow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkShow.UseVisualStyleBackColor = true;
            this.chkShow.CheckedChanged += new System.EventHandler(this.chkShow_CheckedChanged);
            this.chkShow.MouseLeave += new System.EventHandler(this.chkShow_MouseLeave);
            this.chkShow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chkShow_MouseMove);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(32, 236);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 15;
            this.lblDate.Text = "Date";
            // 
            // dtNote
            // 
            this.dtNote.CustomFormat = "dd/MM/yyyy";
            this.dtNote.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNote.Location = new System.Drawing.Point(122, 233);
            this.dtNote.Name = "dtNote";
            this.dtNote.Size = new System.Drawing.Size(208, 20);
            this.dtNote.TabIndex = 1;
            // 
            // dgvNote
            // 
            this.dgvNote.AllowUserToResizeColumns = false;
            this.dgvNote.AllowUserToResizeRows = false;
            this.dgvNote.BackgroundColor = System.Drawing.Color.White;
            this.dgvNote.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvNote.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvNote.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNote.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10});
            this.dgvNote.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvNote.Location = new System.Drawing.Point(359, 72);
            this.dgvNote.MultiSelect = false;
            this.dgvNote.Name = "dgvNote";
            this.dgvNote.ReadOnly = true;
            this.dgvNote.RowHeadersVisible = false;
            this.dgvNote.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNote.Size = new System.Drawing.Size(571, 398);
            this.dgvNote.TabIndex = 13;
            this.dgvNote.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNote_CellClick);
            this.dgvNote.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvNote_Paint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Visible = false;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Date";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Note";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 127;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Width";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column4.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Height";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 50;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "LocationX";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column6.Width = 60;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "LocationY";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column7.Width = 60;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Color";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "OnTop";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Show";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column10.Width = 40;
            // 
            // UC_Sticky
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.dgvNote);
            this.Controls.Add(this.dtNote);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblShow);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.lblOnTop);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLocation);
            this.Controls.Add(this.lblSize);
            this.Controls.Add(this.chkOnTop);
            this.Controls.Add(this.txtLX);
            this.Controls.Add(this.txtLY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.txtNote);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnSaveAs);
            this.Controls.Add(this.lstNote);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblStickyTitle);
            this.Name = "UC_Sticky";
            this.Size = new System.Drawing.Size(930, 473);
            this.Load += new System.EventHandler(this.UC_Sticky_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStickyTitle;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView lstNote;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.Button btnSaveAs;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.ColumnHeader colNote;
        private System.Windows.Forms.ColumnHeader colWidth;
        private System.Windows.Forms.ColumnHeader colHeight;
        private System.Windows.Forms.ColumnHeader colLocationX;
        private System.Windows.Forms.ColumnHeader colLocationY;
        private System.Windows.Forms.ColumnHeader colColor;
        private System.Windows.Forms.RichTextBox txtNote;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLX;
        private System.Windows.Forms.TextBox txtLY;
        private System.Windows.Forms.CheckBox chkOnTop;
        private System.Windows.Forms.Label lblSize;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.Label lblOnTop;
        private System.Windows.Forms.ColumnHeader colOnTop;
        private System.Windows.Forms.Label lblShow;
        private System.Windows.Forms.CheckBox chkShow;
        private System.Windows.Forms.ColumnHeader colShow;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtNote;
        private System.Windows.Forms.DataGridView dgvNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}
