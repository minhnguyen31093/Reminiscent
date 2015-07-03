namespace Reminiscent
{
    partial class UC_Account
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Account));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnSaveRE = new System.Windows.Forms.Button();
            this.btnDelRE = new System.Windows.Forms.Button();
            this.btnEditRE = new System.Windows.Forms.Button();
            this.btnNewRE = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtRE = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblReceipts = new System.Windows.Forms.Label();
            this.txtSummaryE = new System.Windows.Forms.TextBox();
            this.txtSummaryT = new System.Windows.Forms.TextBox();
            this.btnDrawChart = new System.Windows.Forms.Button();
            this.radDay = new System.Windows.Forms.RadioButton();
            this.btnCalcRE = new System.Windows.Forms.Button();
            this.txtSummaryR = new System.Windows.Forms.TextBox();
            this.dtCalc = new System.Windows.Forms.DateTimePicker();
            this.radYear = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radWeek = new System.Windows.Forms.RadioButton();
            this.lblSummary = new System.Windows.Forms.Label();
            this.dgvRE = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(930, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "Receipts and Expense";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblType);
            this.panel1.Controls.Add(this.cboType);
            this.panel1.Controls.Add(this.btnSaveRE);
            this.panel1.Controls.Add(this.btnDelRE);
            this.panel1.Controls.Add(this.btnEditRE);
            this.panel1.Controls.Add(this.btnNewRE);
            this.panel1.Controls.Add(this.lblDate);
            this.panel1.Controls.Add(this.txtAmount);
            this.panel1.Controls.Add(this.dtRE);
            this.panel1.Controls.Add(this.lblAmount);
            this.panel1.Controls.Add(this.lblReason);
            this.panel1.Controls.Add(this.txtReason);
            this.panel1.Controls.Add(this.lblID);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Location = new System.Drawing.Point(22, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(268, 218);
            this.panel1.TabIndex = 34;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(11, 42);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(35, 13);
            this.lblType.TabIndex = 48;
            this.lblType.Text = "Type";
            // 
            // cboType
            // 
            this.cboType.BackColor = System.Drawing.Color.White;
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(72, 39);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(181, 21);
            this.cboType.TabIndex = 1;
            // 
            // btnSaveRE
            // 
            this.btnSaveRE.BackColor = System.Drawing.SystemColors.Control;
            this.btnSaveRE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveRE.BackgroundImage")));
            this.btnSaveRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveRE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveRE.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveRE.Image")));
            this.btnSaveRE.Location = new System.Drawing.Point(14, 158);
            this.btnSaveRE.Name = "btnSaveRE";
            this.btnSaveRE.Size = new System.Drawing.Size(56, 50);
            this.btnSaveRE.TabIndex = 5;
            this.btnSaveRE.Text = "Save";
            this.btnSaveRE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaveRE.UseVisualStyleBackColor = false;
            this.btnSaveRE.Click += new System.EventHandler(this.btnSaveRE_Click);
            this.btnSaveRE.MouseLeave += new System.EventHandler(this.btnSaveRE_MouseLeave);
            this.btnSaveRE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnSaveRE_MouseMove);
            // 
            // btnDelRE
            // 
            this.btnDelRE.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelRE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelRE.BackgroundImage")));
            this.btnDelRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelRE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelRE.Image = ((System.Drawing.Image)(resources.GetObject("btnDelRE.Image")));
            this.btnDelRE.Location = new System.Drawing.Point(197, 158);
            this.btnDelRE.Name = "btnDelRE";
            this.btnDelRE.Size = new System.Drawing.Size(56, 50);
            this.btnDelRE.TabIndex = 8;
            this.btnDelRE.Text = "Delete";
            this.btnDelRE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelRE.UseVisualStyleBackColor = false;
            this.btnDelRE.Click += new System.EventHandler(this.btnDelRE_Click);
            this.btnDelRE.MouseLeave += new System.EventHandler(this.btnDelRE_MouseLeave);
            this.btnDelRE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDelRE_MouseMove);
            // 
            // btnEditRE
            // 
            this.btnEditRE.BackColor = System.Drawing.SystemColors.Control;
            this.btnEditRE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditRE.BackgroundImage")));
            this.btnEditRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditRE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditRE.Image = ((System.Drawing.Image)(resources.GetObject("btnEditRE.Image")));
            this.btnEditRE.Location = new System.Drawing.Point(75, 158);
            this.btnEditRE.Name = "btnEditRE";
            this.btnEditRE.Size = new System.Drawing.Size(56, 50);
            this.btnEditRE.TabIndex = 6;
            this.btnEditRE.Text = "Save As";
            this.btnEditRE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditRE.UseVisualStyleBackColor = false;
            this.btnEditRE.Click += new System.EventHandler(this.btnEditRE_Click);
            this.btnEditRE.MouseLeave += new System.EventHandler(this.btnEditRE_MouseLeave);
            this.btnEditRE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEditRE_MouseMove);
            // 
            // btnNewRE
            // 
            this.btnNewRE.BackColor = System.Drawing.SystemColors.Control;
            this.btnNewRE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewRE.BackgroundImage")));
            this.btnNewRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewRE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewRE.Image = ((System.Drawing.Image)(resources.GetObject("btnNewRE.Image")));
            this.btnNewRE.Location = new System.Drawing.Point(136, 158);
            this.btnNewRE.Name = "btnNewRE";
            this.btnNewRE.Size = new System.Drawing.Size(56, 50);
            this.btnNewRE.TabIndex = 7;
            this.btnNewRE.Text = "Refresh";
            this.btnNewRE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNewRE.UseVisualStyleBackColor = false;
            this.btnNewRE.Click += new System.EventHandler(this.btnNewRE_Click);
            this.btnNewRE.MouseLeave += new System.EventHandler(this.btnNewRE_MouseLeave);
            this.btnNewRE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNewRE_MouseMove);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(11, 101);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 41;
            this.lblDate.Text = "Date";
            // 
            // txtAmount
            // 
            this.txtAmount.BackColor = System.Drawing.Color.White;
            this.txtAmount.Location = new System.Drawing.Point(72, 69);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(181, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // dtRE
            // 
            this.dtRE.CustomFormat = "dd/MM/yyyy";
            this.dtRE.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRE.Location = new System.Drawing.Point(72, 98);
            this.dtRE.Name = "dtRE";
            this.dtRE.Size = new System.Drawing.Size(181, 20);
            this.dtRE.TabIndex = 3;
            this.dtRE.Value = new System.DateTime(2014, 4, 12, 17, 9, 52, 0);
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(11, 72);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(49, 13);
            this.lblAmount.TabIndex = 38;
            this.lblAmount.Text = "Amount";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.BackColor = System.Drawing.Color.Transparent;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(11, 130);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 37;
            this.lblReason.Text = "Reason";
            // 
            // txtReason
            // 
            this.txtReason.BackColor = System.Drawing.Color.White;
            this.txtReason.Location = new System.Drawing.Point(72, 127);
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(181, 20);
            this.txtReason.TabIndex = 4;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.Location = new System.Drawing.Point(11, 13);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(20, 13);
            this.lblID.TabIndex = 35;
            this.lblID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(72, 10);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(181, 20);
            this.txtID.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblExpense);
            this.panel2.Controls.Add(this.lblReceipts);
            this.panel2.Controls.Add(this.txtSummaryE);
            this.panel2.Controls.Add(this.txtSummaryT);
            this.panel2.Controls.Add(this.btnDrawChart);
            this.panel2.Controls.Add(this.radDay);
            this.panel2.Controls.Add(this.btnCalcRE);
            this.panel2.Controls.Add(this.txtSummaryR);
            this.panel2.Controls.Add(this.dtCalc);
            this.panel2.Controls.Add(this.radYear);
            this.panel2.Controls.Add(this.radMonth);
            this.panel2.Controls.Add(this.radWeek);
            this.panel2.Location = new System.Drawing.Point(22, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 152);
            this.panel2.TabIndex = 48;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(11, 127);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 13);
            this.lblTotal.TabIndex = 50;
            this.lblTotal.Text = "Total";
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.BackColor = System.Drawing.Color.Transparent;
            this.lblExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpense.Location = new System.Drawing.Point(11, 101);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.Size = new System.Drawing.Size(55, 13);
            this.lblExpense.TabIndex = 49;
            this.lblExpense.Text = "Expense";
            // 
            // lblReceipts
            // 
            this.lblReceipts.AutoSize = true;
            this.lblReceipts.BackColor = System.Drawing.Color.Transparent;
            this.lblReceipts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceipts.Location = new System.Drawing.Point(11, 75);
            this.lblReceipts.Name = "lblReceipts";
            this.lblReceipts.Size = new System.Drawing.Size(57, 13);
            this.lblReceipts.TabIndex = 48;
            this.lblReceipts.Text = "Receipts";
            // 
            // txtSummaryE
            // 
            this.txtSummaryE.BackColor = System.Drawing.Color.White;
            this.txtSummaryE.Location = new System.Drawing.Point(72, 98);
            this.txtSummaryE.Name = "txtSummaryE";
            this.txtSummaryE.Size = new System.Drawing.Size(109, 20);
            this.txtSummaryE.TabIndex = 15;
            // 
            // txtSummaryT
            // 
            this.txtSummaryT.BackColor = System.Drawing.Color.White;
            this.txtSummaryT.Location = new System.Drawing.Point(72, 124);
            this.txtSummaryT.Name = "txtSummaryT";
            this.txtSummaryT.Size = new System.Drawing.Size(109, 20);
            this.txtSummaryT.TabIndex = 16;
            // 
            // btnDrawChart
            // 
            this.btnDrawChart.BackColor = System.Drawing.SystemColors.Control;
            this.btnDrawChart.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDrawChart.BackgroundImage")));
            this.btnDrawChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDrawChart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDrawChart.Location = new System.Drawing.Point(187, 98);
            this.btnDrawChart.Name = "btnDrawChart";
            this.btnDrawChart.Size = new System.Drawing.Size(66, 46);
            this.btnDrawChart.TabIndex = 18;
            this.btnDrawChart.Text = "Draw Chart";
            this.btnDrawChart.UseVisualStyleBackColor = false;
            this.btnDrawChart.Click += new System.EventHandler(this.btnDrawChart_Click);
            this.btnDrawChart.MouseLeave += new System.EventHandler(this.btnDrawChart_MouseLeave);
            this.btnDrawChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDrawChart_MouseMove);
            // 
            // radDay
            // 
            this.radDay.AutoSize = true;
            this.radDay.BackColor = System.Drawing.Color.Transparent;
            this.radDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDay.Location = new System.Drawing.Point(11, 22);
            this.radDay.Name = "radDay";
            this.radDay.Size = new System.Drawing.Size(47, 17);
            this.radDay.TabIndex = 9;
            this.radDay.TabStop = true;
            this.radDay.Text = "Day";
            this.radDay.UseVisualStyleBackColor = false;
            this.radDay.CheckedChanged += new System.EventHandler(this.radDay_CheckedChanged);
            this.radDay.Click += new System.EventHandler(this.radDay_Click);
            // 
            // btnCalcRE
            // 
            this.btnCalcRE.BackColor = System.Drawing.SystemColors.Control;
            this.btnCalcRE.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCalcRE.BackgroundImage")));
            this.btnCalcRE.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCalcRE.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCalcRE.Location = new System.Drawing.Point(187, 46);
            this.btnCalcRE.Name = "btnCalcRE";
            this.btnCalcRE.Size = new System.Drawing.Size(66, 46);
            this.btnCalcRE.TabIndex = 17;
            this.btnCalcRE.Text = "Calculate";
            this.btnCalcRE.UseVisualStyleBackColor = false;
            this.btnCalcRE.Click += new System.EventHandler(this.btnCalcRE_Click);
            this.btnCalcRE.MouseLeave += new System.EventHandler(this.btnCalcRE_MouseLeave);
            this.btnCalcRE.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnCalcRE_MouseMove);
            // 
            // txtSummaryR
            // 
            this.txtSummaryR.BackColor = System.Drawing.Color.White;
            this.txtSummaryR.Location = new System.Drawing.Point(72, 72);
            this.txtSummaryR.Name = "txtSummaryR";
            this.txtSummaryR.Size = new System.Drawing.Size(109, 20);
            this.txtSummaryR.TabIndex = 14;
            this.txtSummaryR.TextChanged += new System.EventHandler(this.txtSummary_TextChanged);
            // 
            // dtCalc
            // 
            this.dtCalc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCalc.Location = new System.Drawing.Point(14, 46);
            this.dtCalc.Name = "dtCalc";
            this.dtCalc.Size = new System.Drawing.Size(167, 20);
            this.dtCalc.TabIndex = 13;
            this.dtCalc.ValueChanged += new System.EventHandler(this.dtCalc_ValueChanged);
            // 
            // radYear
            // 
            this.radYear.AutoSize = true;
            this.radYear.BackColor = System.Drawing.Color.Transparent;
            this.radYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radYear.Location = new System.Drawing.Point(206, 22);
            this.radYear.Name = "radYear";
            this.radYear.Size = new System.Drawing.Size(51, 17);
            this.radYear.TabIndex = 12;
            this.radYear.TabStop = true;
            this.radYear.Text = "Year";
            this.radYear.UseVisualStyleBackColor = false;
            this.radYear.CheckedChanged += new System.EventHandler(this.radYear_CheckedChanged);
            this.radYear.Click += new System.EventHandler(this.radYear_Click);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.BackColor = System.Drawing.Color.Transparent;
            this.radMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonth.Location = new System.Drawing.Point(137, 22);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(60, 17);
            this.radMonth.TabIndex = 11;
            this.radMonth.TabStop = true;
            this.radMonth.Text = "Month";
            this.radMonth.UseVisualStyleBackColor = false;
            this.radMonth.CheckedChanged += new System.EventHandler(this.radMonth_CheckedChanged);
            this.radMonth.Click += new System.EventHandler(this.radMonth_Click);
            // 
            // radWeek
            // 
            this.radWeek.AutoSize = true;
            this.radWeek.BackColor = System.Drawing.Color.Transparent;
            this.radWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radWeek.Location = new System.Drawing.Point(69, 22);
            this.radWeek.Name = "radWeek";
            this.radWeek.Size = new System.Drawing.Size(58, 17);
            this.radWeek.TabIndex = 10;
            this.radWeek.TabStop = true;
            this.radWeek.Text = "Week";
            this.radWeek.UseVisualStyleBackColor = false;
            this.radWeek.CheckedChanged += new System.EventHandler(this.radWeek_CheckedChanged);
            this.radWeek.Click += new System.EventHandler(this.radWeek_Click);
            // 
            // lblSummary
            // 
            this.lblSummary.AutoSize = true;
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(35, 300);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(57, 13);
            this.lblSummary.TabIndex = 49;
            this.lblSummary.Text = "Summary";
            // 
            // dgvRE
            // 
            this.dgvRE.AllowUserToResizeColumns = false;
            this.dgvRE.AllowUserToResizeRows = false;
            this.dgvRE.BackgroundColor = System.Drawing.Color.White;
            this.dgvRE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvRE.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvRE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRE.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvRE.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvRE.Location = new System.Drawing.Point(296, 71);
            this.dgvRE.MultiSelect = false;
            this.dgvRE.Name = "dgvRE";
            this.dgvRE.ReadOnly = true;
            this.dgvRE.RowHeadersVisible = false;
            this.dgvRE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRE.Size = new System.Drawing.Size(609, 383);
            this.dgvRE.TabIndex = 19;
            this.dgvRE.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRE_CellClick);
            this.dgvRE.Paint += new System.Windows.Forms.PaintEventHandler(this.dgvRE_Paint);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Type";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Amount";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            dataGridViewCellStyle1.NullValue = null;
            this.Column4.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column4.HeaderText = "Date";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Reason";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.Width = 240;
            // 
            // UC_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvRE);
            this.Controls.Add(this.panel2);
            this.Name = "UC_Account";
            this.Size = new System.Drawing.Size(930, 473);
            this.Load += new System.EventHandler(this.UC_Account_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveRE;
        private System.Windows.Forms.Button btnDelRE;
        private System.Windows.Forms.Button btnEditRE;
        private System.Windows.Forms.Button btnNewRE;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.DateTimePicker dtRE;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDrawChart;
        private System.Windows.Forms.RadioButton radDay;
        private System.Windows.Forms.Button btnCalcRE;
        private System.Windows.Forms.TextBox txtSummaryR;
        private System.Windows.Forms.DateTimePicker dtCalc;
        private System.Windows.Forms.RadioButton radYear;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radWeek;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.DataGridView dgvRE;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.TextBox txtSummaryE;
        private System.Windows.Forms.TextBox txtSummaryT;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblReceipts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}
