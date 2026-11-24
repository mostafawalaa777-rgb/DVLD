namespace DVLD_Presentation.Applications
{
    partial class frmReplacementforDamagedOrLostLicenses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReplacementforDamagedOrLostLicenses));
            this.ctrlLicenseInfoWithFilter1 = new DVLD_Presentation.License.ctrlLicenseInfoWithFilter();
            this.label25 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblReplacementAppID = new System.Windows.Forms.Label();
            this.lblOldLicenseID = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblReplacedLicenseID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTitel = new System.Windows.Forms.Label();
            this.lnklShowNewLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.lnklShowLicenseHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnIssueReplacement = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.gbReplacementFFor = new System.Windows.Forms.GroupBox();
            this.rbLostLicense = new System.Windows.Forms.RadioButton();
            this.rbDamagedLicense = new System.Windows.Forms.RadioButton();
            this.gbApplicationInfo.SuspendLayout();
            this.gbReplacementFFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            this.ctrlLicenseInfoWithFilter1.BackColor = System.Drawing.Color.White;
            this.ctrlLicenseInfoWithFilter1.FilterEnabled = true;
            this.ctrlLicenseInfoWithFilter1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(16, 73);
            this.ctrlLicenseInfoWithFilter1.Margin = new System.Windows.Forms.Padding(2);
            this.ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            this.ctrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(1216, 397);
            this.ctrlLicenseInfoWithFilter1.TabIndex = 226;
            this.ctrlLicenseInfoWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlLicenseInfoWithFilter1_OnLicenseSelected);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(18, 36);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(182, 24);
            this.label25.TabIndex = 184;
            this.label25.Text = "L.R.Application ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationFees.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblApplicationFees.Location = new System.Drawing.Point(255, 117);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(55, 24);
            this.lblApplicationFees.TabIndex = 206;
            this.lblApplicationFees.Text = "[???]";
            this.lblApplicationFees.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.label25);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.label30);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.label27);
            this.gbApplicationInfo.Controls.Add(this.label13);
            this.gbApplicationInfo.Controls.Add(this.label24);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.label22);
            this.gbApplicationInfo.Controls.Add(this.lblReplacementAppID);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenseID);
            this.gbApplicationInfo.Controls.Add(this.lblAppDate);
            this.gbApplicationInfo.Controls.Add(this.label1);
            this.gbApplicationInfo.Controls.Add(this.lblReplacedLicenseID);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label4);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 475);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(1218, 167);
            this.gbApplicationInfo.TabIndex = 233;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "  Applications Info For License Replacement ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Image = ((System.Drawing.Image)(resources.GetObject("label11.Image")));
            this.label11.Location = new System.Drawing.Point(206, 109);
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
            this.label30.Location = new System.Drawing.Point(758, 29);
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
            this.label27.Location = new System.Drawing.Point(206, 31);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(28, 31);
            this.label27.TabIndex = 187;
            this.label27.Text = "  ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(27, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(173, 24);
            this.label13.TabIndex = 205;
            this.label13.Text = "Application Fees:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(32, 75);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(168, 24);
            this.label24.TabIndex = 185;
            this.label24.Text = "Application Date:";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.ForeColor = System.Drawing.Color.Black;
            this.lblCreatedBy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCreatedBy.Location = new System.Drawing.Point(814, 115);
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
            this.label22.Location = new System.Drawing.Point(599, 77);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(153, 24);
            this.label22.TabIndex = 188;
            this.label22.Text = "Old License ID:";
            // 
            // lblReplacementAppID
            // 
            this.lblReplacementAppID.AutoSize = true;
            this.lblReplacementAppID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacementAppID.ForeColor = System.Drawing.Color.Black;
            this.lblReplacementAppID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReplacementAppID.Location = new System.Drawing.Point(255, 31);
            this.lblReplacementAppID.Name = "lblReplacementAppID";
            this.lblReplacementAppID.Size = new System.Drawing.Size(55, 24);
            this.lblReplacementAppID.TabIndex = 189;
            this.lblReplacementAppID.Text = "[???]";
            this.lblReplacementAppID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOldLicenseID
            // 
            this.lblOldLicenseID.AutoSize = true;
            this.lblOldLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblOldLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOldLicenseID.Location = new System.Drawing.Point(814, 72);
            this.lblOldLicenseID.Name = "lblOldLicenseID";
            this.lblOldLicenseID.Size = new System.Drawing.Size(55, 24);
            this.lblOldLicenseID.TabIndex = 202;
            this.lblOldLicenseID.Text = "[???]";
            this.lblOldLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.ForeColor = System.Drawing.Color.Black;
            this.lblAppDate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAppDate.Location = new System.Drawing.Point(255, 74);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(55, 24);
            this.lblAppDate.TabIndex = 190;
            this.lblAppDate.Text = "[???]";
            this.lblAppDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(758, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 31);
            this.label1.TabIndex = 201;
            this.label1.Text = "  ";
            // 
            // lblReplacedLicenseID
            // 
            this.lblReplacedLicenseID.AutoSize = true;
            this.lblReplacedLicenseID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenseID.ForeColor = System.Drawing.Color.Black;
            this.lblReplacedLicenseID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReplacedLicenseID.Location = new System.Drawing.Point(814, 29);
            this.lblReplacedLicenseID.Name = "lblReplacedLicenseID";
            this.lblReplacedLicenseID.Size = new System.Drawing.Size(55, 24);
            this.lblReplacedLicenseID.TabIndex = 191;
            this.lblReplacedLicenseID.Text = "[???]";
            this.lblReplacedLicenseID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(634, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 24);
            this.label3.TabIndex = 200;
            this.label3.Text = "Created By:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
            this.label4.Location = new System.Drawing.Point(206, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 31);
            this.label4.TabIndex = 192;
            this.label4.Text = "  ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(543, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(209, 24);
            this.label7.TabIndex = 196;
            this.label7.Text = "Replaced License ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Image = ((System.Drawing.Image)(resources.GetObject("label9.Image")));
            this.label9.Location = new System.Drawing.Point(758, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 31);
            this.label9.TabIndex = 198;
            this.label9.Text = "  ";
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.BackColor = System.Drawing.Color.White;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitel.Location = new System.Drawing.Point(273, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(546, 48);
            this.lblTitel.TabIndex = 225;
            this.lblTitel.Text = "Renew License Application";
            // 
            // lnklShowNewLicenseInfo
            // 
            this.lnklShowNewLicenseInfo.AutoSize = true;
            this.lnklShowNewLicenseInfo.Enabled = false;
            this.lnklShowNewLicenseInfo.Font = new System.Drawing.Font("Old Antic Outline Shaded", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lnklShowNewLicenseInfo.LinkColor = System.Drawing.Color.MediumBlue;
            this.lnklShowNewLicenseInfo.Location = new System.Drawing.Point(314, 661);
            this.lnklShowNewLicenseInfo.Name = "lnklShowNewLicenseInfo";
            this.lnklShowNewLicenseInfo.Size = new System.Drawing.Size(232, 30);
            this.lnklShowNewLicenseInfo.TabIndex = 227;
            this.lnklShowNewLicenseInfo.TabStop = true;
            this.lnklShowNewLicenseInfo.Text = "Show New License Info";
            this.lnklShowNewLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklShowNewLicenseInfo_LinkClicked);
            // 
            // lnklShowLicenseHistory
            // 
            this.lnklShowLicenseHistory.AutoSize = true;
            this.lnklShowLicenseHistory.Font = new System.Drawing.Font("Old Antic Outline Shaded", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lnklShowLicenseHistory.LinkColor = System.Drawing.Color.MediumBlue;
            this.lnklShowLicenseHistory.Location = new System.Drawing.Point(46, 661);
            this.lnklShowLicenseHistory.Name = "lnklShowLicenseHistory";
            this.lnklShowLicenseHistory.Size = new System.Drawing.Size(217, 30);
            this.lnklShowLicenseHistory.TabIndex = 229;
            this.lnklShowLicenseHistory.TabStop = true;
            this.lnklShowLicenseHistory.Text = "Show License History";
            this.lnklShowLicenseHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklShowLicenseHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(849, 657);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(128, 36);
            this.btnClose.TabIndex = 231;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Image = ((System.Drawing.Image)(resources.GetObject("label8.Image")));
            this.label8.Location = new System.Drawing.Point(10, 660);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 31);
            this.label8.TabIndex = 230;
            this.label8.Text = "  ";
            // 
            // btnIssueReplacement
            // 
            this.btnIssueReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssueReplacement.Image = ((System.Drawing.Image)(resources.GetObject("btnIssueReplacement.Image")));
            this.btnIssueReplacement.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIssueReplacement.Location = new System.Drawing.Point(1000, 658);
            this.btnIssueReplacement.Name = "btnIssueReplacement";
            this.btnIssueReplacement.Size = new System.Drawing.Size(230, 35);
            this.btnIssueReplacement.TabIndex = 232;
            this.btnIssueReplacement.Text = "Issue Replacement";
            this.btnIssueReplacement.UseVisualStyleBackColor = true;
            this.btnIssueReplacement.Click += new System.EventHandler(this.btnIssueReplacement_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Image = ((System.Drawing.Image)(resources.GetObject("label26.Image")));
            this.label26.Location = new System.Drawing.Point(279, 660);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(28, 31);
            this.label26.TabIndex = 228;
            this.label26.Text = "  ";
            // 
            // gbReplacementFFor
            // 
            this.gbReplacementFFor.Controls.Add(this.rbLostLicense);
            this.gbReplacementFFor.Controls.Add(this.rbDamagedLicense);
            this.gbReplacementFFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbReplacementFFor.Location = new System.Drawing.Point(672, 88);
            this.gbReplacementFFor.Name = "gbReplacementFFor";
            this.gbReplacementFFor.Size = new System.Drawing.Size(283, 74);
            this.gbReplacementFFor.TabIndex = 234;
            this.gbReplacementFFor.TabStop = false;
            this.gbReplacementFFor.Text = "Replacement For:";
            // 
            // rbLostLicense
            // 
            this.rbLostLicense.AutoSize = true;
            this.rbLostLicense.Location = new System.Drawing.Point(18, 47);
            this.rbLostLicense.Name = "rbLostLicense";
            this.rbLostLicense.Size = new System.Drawing.Size(127, 24);
            this.rbLostLicense.TabIndex = 1;
            this.rbLostLicense.TabStop = true;
            this.rbLostLicense.Text = "Lost License";
            this.rbLostLicense.UseVisualStyleBackColor = true;
            this.rbLostLicense.CheckedChanged += new System.EventHandler(this.rbLostLicense_CheckedChanged);
            // 
            // rbDamagedLicense
            // 
            this.rbDamagedLicense.AutoSize = true;
            this.rbDamagedLicense.Location = new System.Drawing.Point(18, 21);
            this.rbDamagedLicense.Name = "rbDamagedLicense";
            this.rbDamagedLicense.Size = new System.Drawing.Size(166, 24);
            this.rbDamagedLicense.TabIndex = 0;
            this.rbDamagedLicense.TabStop = true;
            this.rbDamagedLicense.Text = "Damaged License";
            this.rbDamagedLicense.UseVisualStyleBackColor = true;
            this.rbDamagedLicense.CheckedChanged += new System.EventHandler(this.rbDamagedLicense_CheckedChanged);
            // 
            // frmReplacementforDamagedOrLostLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 717);
            this.Controls.Add(this.gbReplacementFFor);
            this.Controls.Add(this.ctrlLicenseInfoWithFilter1);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.lblTitel);
            this.Controls.Add(this.lnklShowNewLicenseInfo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lnklShowLicenseHistory);
            this.Controls.Add(this.btnIssueReplacement);
            this.Controls.Add(this.label26);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReplacementforDamagedOrLostLicenses";
            this.Text = "ReplacementforDamagedOrLostLicenses";
            this.Activated += new System.EventHandler(this.ReplacementforDamagedOrLostLicenses_Activated);
            this.Load += new System.EventHandler(this.ReplacementforDamagedOrLostLicenses_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.gbReplacementFFor.ResumeLayout(false);
            this.gbReplacementFFor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private License.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblReplacementAppID;
        private System.Windows.Forms.Label lblOldLicenseID;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReplacedLicenseID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.LinkLabel lnklShowNewLicenseInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel lnklShowLicenseHistory;
        private System.Windows.Forms.Button btnIssueReplacement;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.GroupBox gbReplacementFFor;
        private System.Windows.Forms.RadioButton rbLostLicense;
        private System.Windows.Forms.RadioButton rbDamagedLicense;
    }
}