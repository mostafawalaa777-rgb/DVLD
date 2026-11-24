namespace DVLD_Presentation.Applications
{
    partial class frmReleaseDetainedLicenseApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReleaseDetainedLicenseApp));
            this.label25 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.ctrlLicenseInfoWithFilter1 = new DVLD_Presentation.License.ctrlLicenseInfoWithFilter();
            this.label24 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lnklShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lnklShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRelease = new System.Windows.Forms.Button();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(91, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(100, 24);
            this.label25.TabIndex = 184;
            this.label25.Text = "Detain ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationFees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplicationFees.Location = new System.Drawing.Point(242, 112);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(55, 24);
            this.lblApplicationFees.TabIndex = 206;
            this.lblApplicationFees.Text = "[???]";
            this.lblApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(18, 112);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 24);
            this.label13.TabIndex = 205;
            this.label13.Text = "Application Fees:";
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            this.ctrlLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlLicenseInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(12, 73);
            this.ctrlLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            this.ctrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(1214, 396);
            this.ctrlLicenseInfoWithFilter1.TabIndex = 236;
            this.ctrlLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(68, 72);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 24);
            this.label24.TabIndex = 185;
            this.label24.Text = "Detain Date:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCreatedBy.Location = new System.Drawing.Point(805, 70);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(55, 24);
            this.lblCreatedBy.TabIndex = 204;
            this.lblCreatedBy.Text = "[???]";
            this.lblCreatedBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(592, 141);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(145, 24);
            this.label22.TabIndex = 188;
            this.label22.Text = "Application ID:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainID.ForeColor = System.Drawing.Color.Black;
            this.lblDetainID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetainID.Location = new System.Drawing.Point(242, 30);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(55, 24);
            this.lblDetainID.TabIndex = 189;
            this.lblDetainID.Text = "[???]";
            this.lblDetainID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplicationID.Location = new System.Drawing.Point(805, 148);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(55, 24);
            this.lblApplicationID.TabIndex = 202;
            this.lblApplicationID.Text = "[???]";
            this.lblApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.BackColor = System.Drawing.Color.White;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitel.Location = new System.Drawing.Point(282, 13);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(647, 58);
            this.lblTitel.TabIndex = 235;
            this.lblTitel.Text = "Release Detained License ";
            // 
            // lnklShowLicenseInfo
            // 
            this.lnklShowLicenseInfo.AutoSize = true;
            this.lnklShowLicenseInfo.Enabled = false;
            this.lnklShowLicenseInfo.Font = new System.Drawing.Font("Old Antic Outline Shaded", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lnklShowLicenseInfo.LinkColor = System.Drawing.Color.MediumBlue;
            this.lnklShowLicenseInfo.Location = new System.Drawing.Point(321, 697);
            this.lnklShowLicenseInfo.Name = "lnklShowLicenseInfo";
            this.lnklShowLicenseInfo.Size = new System.Drawing.Size(185, 30);
            this.lnklShowLicenseInfo.TabIndex = 237;
            this.lnklShowLicenseInfo.TabStop = true;
            this.lnklShowLicenseInfo.Text = "Show License Info";
            this.lnklShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklShowNewLicenseInfo_LinkClicked);
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.ForeColor = System.Drawing.Color.Black;
            this.lblDetainDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDetainDate.Location = new System.Drawing.Point(242, 71);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(55, 24);
            this.lblDetainDate.TabIndex = 190;
            this.lblDetainDate.Text = "[???]";
            this.lblDetainDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLicenseID.Location = new System.Drawing.Point(805, 31);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(55, 24);
            this.lblLicenseID.TabIndex = 191;
            this.lblLicenseID.Text = "[???]";
            this.lblLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(627, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 200;
            this.label3.Text = "Created By:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(625, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 24);
            this.label7.TabIndex = 196;
            this.label7.Text = " License ID:";
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.label5);
            this.gbApplicationInfo.Controls.Add(this.lblFineFees);
            this.gbApplicationInfo.Controls.Add(this.label12);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Controls.Add(this.lblTotalFees);
            this.gbApplicationInfo.Controls.Add(this.label6);
            this.gbApplicationInfo.Controls.Add(this.label25);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.label30);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.label27);
            this.gbApplicationInfo.Controls.Add(this.label13);
            this.gbApplicationInfo.Controls.Add(this.label24);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.label22);
            this.gbApplicationInfo.Controls.Add(this.lblDetainID);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationID);
            this.gbApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbApplicationInfo.Controls.Add(this.label1);
            this.gbApplicationInfo.Controls.Add(this.lblLicenseID);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 483);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(1214, 204);
            this.gbApplicationInfo.TabIndex = 243;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Detain Info ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(760, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 31);
            this.label9.TabIndex = 214;
            this.label9.Text = "  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(760, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 31);
            this.label5.TabIndex = 213;
            this.label5.Text = "  ";
            // 
            // lblFineFees
            // 
            this.lblFineFees.AutoSize = true;
            this.lblFineFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFineFees.ForeColor = System.Drawing.Color.Black;
            this.lblFineFees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblFineFees.Location = new System.Drawing.Point(805, 109);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(55, 24);
            this.lblFineFees.TabIndex = 212;
            this.lblFineFees.Text = "[$$$]";
            this.lblFineFees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(630, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(111, 24);
            this.label12.TabIndex = 211;
            this.label12.Text = "Fine Fees:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
            this.label2.Location = new System.Drawing.Point(197, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 31);
            this.label2.TabIndex = 210;
            this.label2.Text = "  ";
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFees.ForeColor = System.Drawing.Color.Black;
            this.lblTotalFees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTotalFees.Location = new System.Drawing.Point(242, 153);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(55, 24);
            this.lblTotalFees.TabIndex = 209;
            this.lblTotalFees.Text = "[???]";
            this.lblTotalFees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(76, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 24);
            this.label6.TabIndex = 208;
            this.label6.Text = "Total Fees:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(197, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(28, 31);
            this.label11.TabIndex = 207;
            this.label11.Text = "  ";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Image = ((System.Drawing.Image)(resources.GetObject("label30.Image")));
            this.label30.Location = new System.Drawing.Point(760, 31);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(28, 31);
            this.label30.TabIndex = 186;
            this.label30.Text = "  ";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Image = ((System.Drawing.Image)(resources.GetObject("label27.Image")));
            this.label27.Location = new System.Drawing.Point(197, 25);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 31);
            this.label27.TabIndex = 187;
            this.label27.Text = "  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(760, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 31);
            this.label1.TabIndex = 201;
            this.label1.Text = "  ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(197, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 31);
            this.label4.TabIndex = 192;
            this.label4.Text = "  ";
            // 
            // lnklShowLicenseHistory
            // 
            this.lnklShowLicenseHistory.AutoSize = true;
            this.lnklShowLicenseHistory.Font = new System.Drawing.Font("Old Antic Outline Shaded", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lnklShowLicenseHistory.LinkColor = System.Drawing.Color.MediumBlue;
            this.lnklShowLicenseHistory.Location = new System.Drawing.Point(53, 697);
            this.lnklShowLicenseHistory.Name = "lnklShowLicenseHistory";
            this.lnklShowLicenseHistory.Size = new System.Drawing.Size(217, 30);
            this.lnklShowLicenseHistory.TabIndex = 239;
            this.lnklShowLicenseHistory.TabStop = true;
            this.lnklShowLicenseHistory.Text = "Show License History";
            this.lnklShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklShowLicenseHistory_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(17, 697);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 31);
            this.label8.TabIndex = 240;
            this.label8.Text = "  ";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Image = ((System.Drawing.Image)(resources.GetObject("label26.Image")));
            this.label26.Location = new System.Drawing.Point(286, 697);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 31);
            this.label26.TabIndex = 238;
            this.label26.Text = "  ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(920, 699);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(146, 36);
            this.btnClose.TabIndex = 241;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRelease
            // 
            this.btnRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnRelease.Image")));
            this.btnRelease.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRelease.Location = new System.Drawing.Point(1082, 700);
            this.btnRelease.Name = "btnRelease";
            this.btnRelease.Size = new System.Drawing.Size(144, 35);
            this.btnRelease.TabIndex = 242;
            this.btnRelease.Text = "Release";
            this.btnRelease.UseVisualStyleBackColor = true;
            this.btnRelease.Click += new System.EventHandler(this.btnRelease_Click);
            // 
            // frmReleaseDetainedLicenseApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1249, 758);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ctrlLicenseInfoWithFilter1);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lnklShowLicenseInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lnklShowLicenseHistory);
            this.Controls.Add(this.btnRelease);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseDetainedLicenseApp";
            this.Text = "frmDetain_ReleaseLicenses";
            this.Validated += new System.EventHandler(this.frmDetain_ReleaseLicenses_Validated);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label13;
        private License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.LinkLabel lnklShowLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.LinkLabel lnklShowLicenseHistory;
        private System.Windows.Forms.Button btnRelease;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
    }
}