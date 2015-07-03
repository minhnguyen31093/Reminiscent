namespace Reminiscent
{
    partial class UC_Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Schedule));
            this.lstSchedule = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAbstract = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPercent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNfP = new System.Windows.Forms.Button();
            this.PanelChart = new System.Windows.Forms.Panel();
            this.lblPage = new System.Windows.Forms.Label();
            this.lblNext = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblPre = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstSchedule
            // 
            this.lstSchedule.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colProject,
            this.colAbstract,
            this.colPercent});
            this.lstSchedule.FullRowSelect = true;
            this.lstSchedule.GridLines = true;
            this.lstSchedule.Location = new System.Drawing.Point(3, 3);
            this.lstSchedule.MultiSelect = false;
            this.lstSchedule.Name = "lstSchedule";
            this.lstSchedule.Size = new System.Drawing.Size(922, 368);
            this.lstSchedule.TabIndex = 0;
            this.lstSchedule.UseCompatibleStateImageBehavior = false;
            this.lstSchedule.View = System.Windows.Forms.View.Details;
            this.lstSchedule.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.lstSchedule_ColumnWidthChanging);
            this.lstSchedule.SelectedIndexChanged += new System.EventHandler(this.lstSchedule_SelectedIndexChanged);
            this.lstSchedule.DoubleClick += new System.EventHandler(this.lstSchedule_DoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "ID";
            this.colID.Width = 40;
            // 
            // colProject
            // 
            this.colProject.Text = "Project";
            this.colProject.Width = 118;
            // 
            // colAbstract
            // 
            this.colAbstract.Text = "Abstract";
            this.colAbstract.Width = 360;
            // 
            // colPercent
            // 
            this.colPercent.Text = "Percentage of work";
            this.colPercent.Width = 400;
            // 
            // btnDetail
            // 
            this.btnDetail.BackColor = System.Drawing.SystemColors.Control;
            this.btnDetail.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDetail.BackgroundImage")));
            this.btnDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnDetail.Image")));
            this.btnDetail.Location = new System.Drawing.Point(74, 413);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(103, 50);
            this.btnDetail.TabIndex = 1;
            this.btnDetail.Text = "Detail";
            this.btnDetail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDetail.UseVisualStyleBackColor = false;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            this.btnDetail.MouseLeave += new System.EventHandler(this.btnDetail_MouseLeave);
            this.btnDetail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDetail_MouseMove);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.SystemColors.Control;
            this.btnNew.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNew.BackgroundImage")));
            this.btnNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNew.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.Image")));
            this.btnNew.Location = new System.Drawing.Point(414, 413);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(103, 50);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New";
            this.btnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            this.btnNew.MouseLeave += new System.EventHandler(this.btnNew_MouseLeave);
            this.btnNew.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNew_MouseMove);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.SystemColors.Control;
            this.btnEdit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEdit.BackgroundImage")));
            this.btnEdit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(584, 413);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(103, 50);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnEdit.MouseLeave += new System.EventHandler(this.btnEdit_MouseLeave);
            this.btnEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnEdit_MouseMove);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(754, 413);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 50);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            this.btnDelete.MouseLeave += new System.EventHandler(this.btnDelete_MouseLeave);
            this.btnDelete.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnDelete_MouseMove);
            // 
            // btnNfP
            // 
            this.btnNfP.BackColor = System.Drawing.SystemColors.Control;
            this.btnNfP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNfP.BackgroundImage")));
            this.btnNfP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNfP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNfP.Image = ((System.Drawing.Image)(resources.GetObject("btnNfP.Image")));
            this.btnNfP.Location = new System.Drawing.Point(244, 413);
            this.btnNfP.Name = "btnNfP";
            this.btnNfP.Size = new System.Drawing.Size(103, 50);
            this.btnNfP.TabIndex = 2;
            this.btnNfP.Text = "New from previous";
            this.btnNfP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNfP.UseVisualStyleBackColor = false;
            this.btnNfP.Click += new System.EventHandler(this.btnNfP_Click);
            this.btnNfP.MouseLeave += new System.EventHandler(this.btnNfP_MouseLeave);
            this.btnNfP.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnNfP_MouseMove);
            // 
            // PanelChart
            // 
            this.PanelChart.BackColor = System.Drawing.Color.White;
            this.PanelChart.Location = new System.Drawing.Point(524, 28);
            this.PanelChart.Name = "PanelChart";
            this.PanelChart.Size = new System.Drawing.Size(400, 340);
            this.PanelChart.TabIndex = 37;
            this.PanelChart.Click += new System.EventHandler(this.PanelChart_Click);
            this.PanelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelChart_Paint);
            this.PanelChart.DoubleClick += new System.EventHandler(this.PanelChart_DoubleClick);
            // 
            // lblPage
            // 
            this.lblPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPage.Location = new System.Drawing.Point(3, 378);
            this.lblPage.Name = "lblPage";
            this.lblPage.Size = new System.Drawing.Size(922, 28);
            this.lblPage.TabIndex = 38;
            this.lblPage.Text = "Page";
            this.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNext
            // 
            this.lblNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNext.Location = new System.Drawing.Point(531, 378);
            this.lblNext.Name = "lblNext";
            this.lblNext.Size = new System.Drawing.Size(28, 28);
            this.lblNext.TabIndex = 39;
            this.lblNext.Text = ">";
            this.lblNext.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNext.Click += new System.EventHandler(this.lblNext_Click);
            this.lblNext.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblNext_MouseDown);
            this.lblNext.MouseLeave += new System.EventHandler(this.lblNext_MouseLeave);
            this.lblNext.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblNext_MouseMove);
            this.lblNext.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblNext_MouseUp);
            // 
            // lblEnd
            // 
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(565, 378);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(32, 28);
            this.lblEnd.TabIndex = 40;
            this.lblEnd.Text = ">I";
            this.lblEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblEnd.Click += new System.EventHandler(this.lblEnd_Click);
            this.lblEnd.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblEnd_MouseDown);
            this.lblEnd.MouseLeave += new System.EventHandler(this.lblEnd_MouseLeave);
            this.lblEnd.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblEnd_MouseMove);
            this.lblEnd.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblEnd_MouseUp);
            // 
            // lblPre
            // 
            this.lblPre.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPre.Location = new System.Drawing.Point(371, 378);
            this.lblPre.Name = "lblPre";
            this.lblPre.Size = new System.Drawing.Size(28, 28);
            this.lblPre.TabIndex = 41;
            this.lblPre.Text = "<";
            this.lblPre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPre.Click += new System.EventHandler(this.lblPre_Click);
            this.lblPre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblPre_MouseDown);
            this.lblPre.MouseLeave += new System.EventHandler(this.lblPre_MouseLeave);
            this.lblPre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblPre_MouseMove);
            this.lblPre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblPre_MouseUp);
            // 
            // lblStart
            // 
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStart.Location = new System.Drawing.Point(333, 378);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(32, 28);
            this.lblStart.TabIndex = 42;
            this.lblStart.Text = "I<";
            this.lblStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStart.Click += new System.EventHandler(this.lblStart_Click);
            this.lblStart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblStart_MouseDown);
            this.lblStart.MouseLeave += new System.EventHandler(this.lblStart_MouseLeave);
            this.lblStart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblStart_MouseMove);
            this.lblStart.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblStart_MouseUp);
            // 
            // UC_Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.lblPre);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblNext);
            this.Controls.Add(this.lblPage);
            this.Controls.Add(this.PanelChart);
            this.Controls.Add(this.btnNfP);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.lstSchedule);
            this.Name = "UC_Schedule";
            this.Size = new System.Drawing.Size(930, 473);
            this.Load += new System.EventHandler(this.UC_Schedule_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lstSchedule;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colProject;
        private System.Windows.Forms.ColumnHeader colAbstract;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNfP;
        private System.Windows.Forms.ColumnHeader colPercent;
        private System.Windows.Forms.Panel PanelChart;
        private System.Windows.Forms.Label lblPage;
        private System.Windows.Forms.Label lblNext;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblPre;
        private System.Windows.Forms.Label lblStart;
    }
}
