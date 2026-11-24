using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.Global_Classes;

namespace DVLD_Presentation.License
{
    public partial class frmIssueDriverLicenseForTheFirstTime : Form
    {
        private int _LocalDrivingLicenseAppID = -1;
        private int _PersonID = -1;
        public clsLocalDrivingLicenseApplication LocalDLApp;
        public frmIssueDriverLicenseForTheFirstTime()
        {
            InitializeComponent();
        }
        public frmIssueDriverLicenseForTheFirstTime(int LocalDrivingLicenseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            clsLicense License = clsLicense.FindByApplicationID(LocalDLApp.ApplicationID);
            int LicenseID = LocalDLApp.IssueLicense(rtxtbNotes.Text, clsGlobal.CurrentUser.UserID);
            if (LicenseID != -1)
            {
                rtxtbNotes.Text = LocalDLApp.License.Notes;

                MessageBox.Show("License Issued Successfully With License Id" + LicenseID, "Successed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
                MessageBox.Show("Error: License was not Issued.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmIssueDriverLicenseForTheFirstTime_Load(object sender, EventArgs e)
        {
            rtxtbNotes.Focus();
            LocalDLApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);

            if (LocalDLApp == null)
            {
                MessageBox.Show(" Error: Local Driving License Application was not found.",
                                          "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if (clsLocalDrivingLicenseApplication.GetPassedTestCount(_LocalDrivingLicenseAppID) != 3)
            {
                MessageBox.Show("Cannot issue the license. The applicant must successfully pass all three required tests first.",
                      "Tests Not Completed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            int LicenseID = clsLicense.GetActiveLicenseIDByPersonIDAndClassID(LocalDLApp.ApplicantPersonID, LocalDLApp.LicenseClassID);
            if (LicenseID != -1)
            {
                MessageBox.Show("Cannot issue a new license because the applicant already has an active license of this class.",
                                         "License Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            ctrlAppInfo1.LoadApplicationInfo(_LocalDrivingLicenseAppID);
        }
    }
}

