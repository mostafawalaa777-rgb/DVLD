
using DVLD_Buisness;
using DVLD_Presentation.Global_Classes;
using System;

using System.Windows.Forms;
using static DVLD_Buisness.clsLicense;
namespace DVLD_Presentation.Applications
{
    public partial class frmReplacementforDamagedOrLostLicenses : Form
    {
        private int _NewLicenseID = -1;
        private int _GetApplicationTypeID()
        {
            if (rbDamagedLicense.Checked)
                return ((int)clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense);
            else
               return ((int)clsApplication.enApplicationType.ReplacementForLostDrivingLicense);
        }
        private enIssueReason _GetIssueReason()
        {
            //this will decide which reason to issue a replacement for

            if (rbDamagedLicense.Checked)

                return enIssueReason.ReplacementForDamaged;
            else
                return enIssueReason.ReplacementForLost;
        }
        public frmReplacementforDamagedOrLostLicenses()
        {
            InitializeComponent();
        }

        private void ReplacementforDamagedOrLostLicenses_Load(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.Focus();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            rbDamagedLicense.Checked = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            int SelectedLicenseID = obj;

            lblOldLicenseID.Text = SelectedLicenseID.ToString();
            lnklShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo == null)
            {
                return;
            }

            //dont Allow a replacement if is not Active.
            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is Not Active, choose an active license."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssueReplacement.Enabled = false;
                return;
                //ToDo: Make sure the license is not Detained Already
                if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
                {
                    MessageBox.Show("Selected License is  Detained, Choose another one."
                        , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }   
            }
                btnIssueReplacement.Enabled = true;
        }
        

        private void ReplacementforDamagedOrLostLicenses_Activated(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Replace the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            clsLicense NewLicense = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo
                    .Replacement(_GetIssueReason(), clsGlobal.CurrentUser.UserID);
            
            if (NewLicense == null)
            {
                MessageBox.Show("Failed to Replace the License", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblReplacementAppID.Text = NewLicense.ApplicationID.ToString();
            _NewLicenseID = NewLicense.LicenseID;

            lblReplacedLicenseID.Text = _NewLicenseID.ToString();

            MessageBox.Show("Licensed Replaced Successfully with ID=" + _NewLicenseID.ToString(), "License Replacedment", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnIssueReplacement.Enabled = false;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            lnklShowNewLicenseInfo.Enabled = true;
            gbReplacementFFor.Enabled = false;

        }

        private void lnklShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form frm = new frmShowLicenseInfo(_NewLicenseID);
            frm.ShowDialog();
        }

        private void lnklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Form frm = new frmShowPersonLicenseHistory(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void rbDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement For Damaged License";
            this.Text = lblTitel.Text;
            lblApplicationFees.Text = clsApplicationType.FindByAppTypeID(_GetApplicationTypeID()).ApplicationFees.ToString();
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblTitel.Text = "Replacement For Lost License";
            this.Text = lblTitel.Text;
            lblApplicationFees.Text = clsApplicationType.FindByAppTypeID(_GetApplicationTypeID()).ApplicationFees.ToString();
        }
    }
}
