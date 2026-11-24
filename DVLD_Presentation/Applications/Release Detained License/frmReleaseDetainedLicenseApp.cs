using System;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Global_Classes;

namespace DVLD_Presentation.Applications
{
    public partial class frmReleaseDetainedLicenseApp : Form
    {
        private int _SelectedLicenseID = -1;
        public frmReleaseDetainedLicenseApp()
        {
            InitializeComponent();
        }
        public frmReleaseDetainedLicenseApp(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ctrlLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lnklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();
            lnklShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)
            {
                return;
            }

            if(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo == null)
            {
                return;
            }

            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is not Detained, Choose another one."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
                btnRelease.Enabled = false;
                return;
            }

           

            lblApplicationFees.Text = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

            //lblCreatedBy.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserID.ToString();
            
            lblDetainID.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            lblDetainDate.Text = clsFormat.DateToShort(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = ((
                                       ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees 
                                       + 
                                        clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees).ToString());

            btnRelease.Enabled = true;
        }
        private void frmDetain_ReleaseLicenses_Validated(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void lnklShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            int ApplicationID = -1;

            bool IsReleased = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseLicenses(clsGlobal.CurrentUser.UserID, ref ApplicationID);
            lblApplicationID.Text = ApplicationID.ToString();


            if ( !IsReleased)
            {
                MessageBox.Show("Faild to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnRelease.Enabled = false;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            lnklShowLicenseInfo.Enabled = true;
        }
    }
}
