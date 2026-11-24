using System;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Global_Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Presentation.Applications.RenewLocal_DrivingLicense
{
    public partial class frmRenewLocalDrivingLicense : Form
    {
        private int _NewLicenseID = -1;
        public frmRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }
        private void frmRenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.Focus();
            lblAppDate.Text = DateTime.Now.ToShortDateString(); 
            lblIssueDate.Text = lblAppDate.Text;

            lblExpirationDate.Text = "???";
            lblApplicationFees.Text = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;

        }
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lnklShowLicenseHistory.Enabled = (SelectedLicenseID != -1);
            if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo == null)
            {
                ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
                return;
            }
           
            int DefaultValidityLength = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.DefaultValidityLength;
            lblExpirationDate.Text = DateTime.Now.AddYears(DefaultValidityLength).ToShortDateString();
            lblLicenseFees.Text = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassInfo.ClassFees.ToString();
            lblTotalFees.Text   = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblLicenseFees.Text)).ToString();
            rtxtbNotes.Text     = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.Notes;

            //check the license is not Expired.
            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Selected License is not yet expiared, it will expire on: " +ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.ExpirationDate.ToShortDateString()
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
             //ToDo: Make sure the license is not Detained Already
            if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is Detained, Choose another one."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //check the license is not Active.
            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;
        }
        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Renew the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense =
                ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.RenewLicense(rtxtbNotes.Text.Trim(),
                clsGlobal.CurrentUser.UserID);

            if (NewLicense == null)
            {
                MessageBox.Show("Faild to Renew the License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 

                return;
            }

            lblRenewLAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;
            lblRenewedLicenseID.Text = _NewLicenseID.ToString();
            MessageBox.Show("Licensed Renewed Successfully with ID=" + _NewLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRenew.Enabled = false;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            lnklShowNewLicenseInfo.Enabled = true;

        }
        private void frmRenewLocalDrivingLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
        }
        private void lnklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowPersonLicenseHistory(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        private void lnklShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}


