using System;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.Applications;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.License.InternationalLicense;

namespace DVLD_Presentation
{
    public partial class frmAddInternationalLicense : Form
    {
        private int _InternationalLicenseID = -1;
      
      
        public frmAddInternationalLicense()
        {
            InitializeComponent();
        }
      
        private void ctrlLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {

            int SelectedLicenseID = obj;
            lblLocalLicenseID.Text = SelectedLicenseID.ToString();
            lnklShowLicenseHistory.Enabled = (SelectedLicenseID != -1);

            if (SelectedLicenseID == -1)
                return;



            //check the license class, person could not issue international license without having
            //normal license of class 3.

            var SelectedLicense = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (SelectedLicense == null)
            {
                MessageBox.Show("SelectedLicense is null");
                return;
            }

            if (SelectedLicense.LicenseClassInfo == null)
            {
                MessageBox.Show("LicenseClassInfo is null");
                return;
            }

            if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseClassID != 3)
            {
                MessageBox.Show("Selected License should be Class 3, select another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //ToDo: Make sure the license is not Detained .
            if (ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License is already Detained, Choose another one."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.IsActive)
            {
                MessageBox.Show("Selected License is DeActive, Choose another one."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //check if person already have an active international license
            int ActiveInternaionalLicenseID = clsInternationalLicense.GetActiveInternationalLicenseIDByDriverID(ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID);

            if (ActiveInternaionalLicenseID != -1)
            {
                MessageBox.Show("Person already have an active international license with ID = " + ActiveInternaionalLicenseID.ToString(), "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lnklShowLicenseHistory.Enabled = true;
                _InternationalLicenseID = ActiveInternaionalLicenseID;
                btnIssue.Enabled = false;
                return;
            }

            btnIssue.Enabled = true;

        }
        private void frmAddInternationalLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = lblAppDate.Text;
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();//add one year.
            lblFees.Text = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees.ToString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to issue the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID ;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.NewInternationalLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.AppPaidFees = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.NewInternationalLicense).ApplicationFees;
            Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!Application.Save())
            {
                return;
            }

            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            //those are the information for the base application, because it inhirts from application, they are part of the sub class.

            InternationalLicense.ApplicationID = Application.ApplicationID;
            InternationalLicense.DriverID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverID;
            InternationalLicense.IssuedUsingLocalLicenseID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID;
            InternationalLicense.IssueDate = DateTime.Now;
            InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            InternationalLicense.IsActive = true;
            InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!InternationalLicense.Save())
            {
                MessageBox.Show("Faild to Issue International License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            lblIntLAppID.Text = InternationalLicense.ApplicationID.ToString();
            _InternationalLicenseID = InternationalLicense.InternationalLicenseID;
            lblIntLLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            MessageBox.Show("International License Issued Successfully with ID=" + InternationalLicense.InternationalLicenseID.ToString(), "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            btnIssue.Enabled = false;
            ctrlLicenseInfoWithFilter1.FilterEnabled = false;
            lnklShowLicenseInfo.Enabled = true;
        }
        private void lnklShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = ctrlLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID;
            clsPerson Person = clsPerson.Find(PersonID);
            if (Person == null)
                MessageBox.Show("Person is null");
            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
        private void lnklShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalDriverInfo frm = new frmShowInternationalDriverInfo(_InternationalLicenseID);
            frm.ShowDialog();
        }
        private void frmAddInternationalLicense_Activated(object sender, EventArgs e)
        {
            ctrlLicenseInfoWithFilter1.txtLicenseIDFocus();
        }  
    }
       
}
    

