namespace DVLD_Presentation.Applications
{
    partial class frmListTestAppointments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListTestAppointments));
            this.lblDiscribtion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblRecords = new System.Windows.Forms.Label();
            this.lable1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddTestAppointment = new System.Windows.Forms.Button();
            this.pbTestAppointment = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvTestAppointmentsList = new System.Windows.Forms.DataGridView();
            this.ctrlAppInfo1 = new DVLD_Presentation.Applications.ctrlAppInfo();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointment)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentsList)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDiscribtion
            // 
            this.lblDiscribtion.AutoSize = true;
            this.lblDiscribtion.BackColor = System.Drawing.Color.White;
            this.lblDiscribtion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscribtion.ForeColor = System.Drawing.Color.Red;
            this.lblDiscribtion.Location = new System.Drawing.Point(373, 135);
            this.lblDiscribtion.Name = "lblDiscribtion";
            this.lblDiscribtion.Size = new System.Drawing.Size(355, 36);
            this.lblDiscribtion.TabIndex = 23;
            this.lblDiscribtion.Text = "Vision Test Appointments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 576);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Appointments:";
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecords.Location = new System.Drawing.Point(137, 827);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(29, 20);
            this.lblRecords.TabIndex = 29;
            this.lblRecords.Text = "??";
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable1.Location = new System.Drawing.Point(15, 827);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(113, 20);
            this.lable1.TabIndex = 28;
            this.lable1.Text = "# Records:  ";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(889, 814);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(136, 41);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddTestAppointment
            // 
            this.btnAddTestAppointment.BackColor = System.Drawing.Color.White;
            this.btnAddTestAppointment.Image = ((System.Drawing.Image)(resources.GetObject("btnAddTestAppointment.Image")));
            this.btnAddTestAppointment.Location = new System.Drawing.Point(971, 560);
            this.btnAddTestAppointment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddTestAppointment.Name = "btnAddTestAppointment";
            this.btnAddTestAppointment.Size = new System.Drawing.Size(55, 47);
            this.btnAddTestAppointment.TabIndex = 26;
            this.btnAddTestAppointment.UseVisualStyleBackColor = false;
            this.btnAddTestAppointment.Click += new System.EventHandler(this.btnAddTestAppointment_Click_1);
            // 
            // pbTestAppointment
            // 
            this.pbTestAppointment.Image = ((System.Drawing.Image)(resources.GetObject("pbTestAppointment.Image")));
            this.pbTestAppointment.Location = new System.Drawing.Point(452, 9);
            this.pbTestAppointment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbTestAppointment.Name = "pbTestAppointment";
            this.pbTestAppointment.Size = new System.Drawing.Size(165, 132);
            this.pbTestAppointment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointment.TabIndex = 1;
            this.pbTestAppointment.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(211, 80);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // dgvTestAppointmentsList
            // 
            this.dgvTestAppointmentsList.AllowUserToAddRows = false;
            this.dgvTestAppointmentsList.BackgroundColor = System.Drawing.Color.White;
            this.dgvTestAppointmentsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestAppointmentsList.Location = new System.Drawing.Point(12, 612);
            this.dgvTestAppointmentsList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTestAppointmentsList.Name = "dgvTestAppointmentsList";
            this.dgvTestAppointmentsList.RowHeadersWidth = 51;
            this.dgvTestAppointmentsList.RowTemplate.Height = 24;
            this.dgvTestAppointmentsList.Size = new System.Drawing.Size(1013, 197);
            this.dgvTestAppointmentsList.TabIndex = 31;
            // 
            // ctrlAppInfo1
            // 
            this.ctrlAppInfo1.Location = new System.Drawing.Point(12, 174);
            this.ctrlAppInfo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ctrlAppInfo1.Name = "ctrlAppInfo1";
            this.ctrlAppInfo1.Size = new System.Drawing.Size(1013, 378);
            this.ctrlAppInfo1.TabIndex = 32;
            // 
            // frmListTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1040, 859);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.ctrlAppInfo1);
            this.Controls.Add(this.dgvTestAppointmentsList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecords);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.btnAddTestAppointment);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDiscribtion);
            this.Controls.Add(this.pbTestAppointment);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmListTestAppointments";
            this.Text = "Vision Test Appointments";
            this.Load += new System.EventHandler(this.frmVisionTestAppointments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointment)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestAppointmentsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbTestAppointment;
        private System.Windows.Forms.Label lblDiscribtion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAddTestAppointment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvTestAppointmentsList;
        private ctrlAppInfo ctrlAppInfo1;
    }
}