namespace DVLD_Presentation.Applications
{
    partial class frmShowPersonLicenseHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPersonLicenseHistory));
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbdriverLicense = new System.Windows.Forms.GroupBox();
            this.tcLicenseHistory = new System.Windows.Forms.TabControl();
            this.tbLocal = new System.Windows.Forms.TabPage();
            this.dgvLocalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.cntLocalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocalRecords = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.tbInternational = new System.Windows.Forms.TabPage();
            this.lblInternationalRecords = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvInternationalLicenseHistory = new System.Windows.Forms.DataGridView();
            this.cntInternationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD_Presentation.People.Controls.ctrlPersonCardWithFilter();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbdriverLicense.SuspendLayout();
            this.tcLicenseHistory.SuspendLayout();
            this.tbLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).BeginInit();
            this.cntLocalLicenseHistory.SuspendLayout();
            this.tbInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).BeginInit();
            this.cntInternationalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(643, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 39);
            this.label2.TabIndex = 23;
            this.label2.Text = " License History";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 198);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(227, 237);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // gbdriverLicense
            // 
            this.gbdriverLicense.Controls.Add(this.tcLicenseHistory);
            this.gbdriverLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbdriverLicense.Location = new System.Drawing.Point(16, 480);
            this.gbdriverLicense.Name = "gbdriverLicense";
            this.gbdriverLicense.Size = new System.Drawing.Size(1458, 353);
            this.gbdriverLicense.TabIndex = 26;
            this.gbdriverLicense.TabStop = false;
            this.gbdriverLicense.Text = "driver License";
            // 
            // tcLicenseHistory
            // 
            this.tcLicenseHistory.Controls.Add(this.tbLocal);
            this.tcLicenseHistory.Controls.Add(this.tbInternational);
            this.tcLicenseHistory.Location = new System.Drawing.Point(18, 34);
            this.tcLicenseHistory.Name = "tcLicenseHistory";
            this.tcLicenseHistory.SelectedIndex = 0;
            this.tcLicenseHistory.Size = new System.Drawing.Size(1425, 301);
            this.tcLicenseHistory.TabIndex = 0;
            // 
            // tbLocal
            // 
            this.tbLocal.BackColor = System.Drawing.Color.White;
            this.tbLocal.Controls.Add(this.dgvLocalLicenseHistory);
            this.tbLocal.Controls.Add(this.label1);
            this.tbLocal.Controls.Add(this.lblLocalRecords);
            this.tbLocal.Controls.Add(this.lable);
            this.tbLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLocal.Location = new System.Drawing.Point(4, 29);
            this.tbLocal.Name = "tbLocal";
            this.tbLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tbLocal.Size = new System.Drawing.Size(1417, 268);
            this.tbLocal.TabIndex = 0;
            this.tbLocal.Text = "Local";
            // 
            // dgvLocalLicenseHistory
            // 
            this.dgvLocalLicenseHistory.AllowUserToAddRows = false;
            this.dgvLocalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicenseHistory.ContextMenuStrip = this.cntLocalLicenseHistory;
            this.dgvLocalLicenseHistory.Location = new System.Drawing.Point(18, 49);
            this.dgvLocalLicenseHistory.Name = "dgvLocalLicenseHistory";
            this.dgvLocalLicenseHistory.RowHeadersWidth = 51;
            this.dgvLocalLicenseHistory.RowTemplate.Height = 24;
            this.dgvLocalLicenseHistory.Size = new System.Drawing.Size(1375, 166);
            this.dgvLocalLicenseHistory.TabIndex = 25;
            this.dgvLocalLicenseHistory.DoubleClick += new System.EventHandler(this.dgvLocalLicenseHistory_DoubleClick);
            // 
            // cntLocalLicenseHistory
            // 
            this.cntLocalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntLocalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cntLocalLicenseHistory.Name = "contextMenuStrip1";
            this.cntLocalLicenseHistory.Size = new System.Drawing.Size(205, 30);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseInfoToolStripMenuItem.Image")));
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info ";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(29, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = " Local License History:";
            // 
            // lblLocalRecords
            // 
            this.lblLocalRecords.AutoSize = true;
            this.lblLocalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalRecords.Location = new System.Drawing.Point(133, 232);
            this.lblLocalRecords.Name = "lblLocalRecords";
            this.lblLocalRecords.Size = new System.Drawing.Size(29, 20);
            this.lblLocalRecords.TabIndex = 29;
            this.lblLocalRecords.Text = "??";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable.Location = new System.Drawing.Point(14, 233);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(113, 20);
            this.lable.TabIndex = 28;
            this.lable.Text = "# Records:  ";
            // 
            // tbInternational
            // 
            this.tbInternational.BackColor = System.Drawing.Color.White;
            this.tbInternational.Controls.Add(this.lblInternationalRecords);
            this.tbInternational.Controls.Add(this.label5);
            this.tbInternational.Controls.Add(this.dgvInternationalLicenseHistory);
            this.tbInternational.Controls.Add(this.label3);
            this.tbInternational.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInternational.Location = new System.Drawing.Point(4, 29);
            this.tbInternational.Name = "tbInternational";
            this.tbInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tbInternational.Size = new System.Drawing.Size(1417, 268);
            this.tbInternational.TabIndex = 1;
            this.tbInternational.Text = "International";
            // 
            // lblInternationalRecords
            // 
            this.lblInternationalRecords.AutoSize = true;
            this.lblInternationalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalRecords.Location = new System.Drawing.Point(137, 234);
            this.lblInternationalRecords.Name = "lblInternationalRecords";
            this.lblInternationalRecords.Size = new System.Drawing.Size(29, 20);
            this.lblInternationalRecords.TabIndex = 31;
            this.lblInternationalRecords.Text = "??";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 30;
            this.label5.Text = "# Records:  ";
            // 
            // dgvInternationalLicenseHistory
            // 
            this.dgvInternationalLicenseHistory.AllowUserToAddRows = false;
            this.dgvInternationalLicenseHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternationalLicenseHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicenseHistory.ContextMenuStrip = this.cntInternationalLicenseHistory;
            this.dgvInternationalLicenseHistory.Location = new System.Drawing.Point(22, 46);
            this.dgvInternationalLicenseHistory.Name = "dgvInternationalLicenseHistory";
            this.dgvInternationalLicenseHistory.RowHeadersWidth = 51;
            this.dgvInternationalLicenseHistory.RowTemplate.Height = 24;
            this.dgvInternationalLicenseHistory.Size = new System.Drawing.Size(1370, 172);
            this.dgvInternationalLicenseHistory.TabIndex = 27;
            this.dgvInternationalLicenseHistory.DoubleClick += new System.EventHandler(this.dgvInternationalLicenseHistory_DoubleClick);
            // 
            // cntInternationalLicenseHistory
            // 
            this.cntInternationalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cntInternationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem1});
            this.cntInternationalLicenseHistory.Name = "contextMenuStrip2";
            this.cntInternationalLicenseHistory.Size = new System.Drawing.Size(205, 30);
            // 
            // showLicenseInfoToolStripMenuItem1
            // 
            this.showLicenseInfoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("showLicenseInfoToolStripMenuItem1.Image")));
            this.showLicenseInfoToolStripMenuItem1.Name = "showLicenseInfoToolStripMenuItem1";
            this.showLicenseInfoToolStripMenuItem1.Size = new System.Drawing.Size(204, 26);
            this.showLicenseInfoToolStripMenuItem1.Text = "Show License Info ";
            this.showLicenseInfoToolStripMenuItem1.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(26, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "International License History:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1338, 838);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 36);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(245, 60);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1229, 414);
            this.ctrlPersonCardWithFilter1.TabIndex = 24;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected_1);
            // 
            // frmShowPersonLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1486, 885);
            this.Controls.Add(this.gbdriverLicense);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.Controls.Add(this.label2);
            this.Name = "frmShowPersonLicenseHistory";
            this.Text = "frmLicenseHistory";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbdriverLicense.ResumeLayout(false);
            this.tcLicenseHistory.ResumeLayout(false);
            this.tbLocal.ResumeLayout(false);
            this.tbLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicenseHistory)).EndInit();
            this.cntLocalLicenseHistory.ResumeLayout(false);
            this.tbInternational.ResumeLayout(false);
            this.tbInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicenseHistory)).EndInit();
            this.cntInternationalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private People.Controls.ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox gbdriverLicense;
        private System.Windows.Forms.TabControl tcLicenseHistory;
        private System.Windows.Forms.TabPage tbLocal;
        private System.Windows.Forms.TabPage tbInternational;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblLocalRecords;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.DataGridView dgvLocalLicenseHistory;
        private System.Windows.Forms.DataGridView dgvInternationalLicenseHistory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalRecords;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cntLocalLicenseHistory;
        private System.Windows.Forms.ContextMenuStrip cntInternationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem1;
    }
}