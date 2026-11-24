using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Presentation.Applications;
using DVLD_Presentation.Applications.RenewLocal_DrivingLicense;
using DVLD_Presentation.Detain;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.License;
using DVLD_Presentation.License.InternationalLicense;
using DVLD_Presentation.People;
using DVLD_Presentation.TestType;
using DVLD_Presentation.Users;

namespace DVLD_Presentation
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;
        public frmMain(frmLogin frm )
        {
            InitializeComponent();
            _frmLogin = frm;
        }
       
        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListPeople frm = new frmListPeople();
            frm.ShowDialog();
        }
        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           if( clsGlobal.CurrentUser == null)
           {
               Properties.Settings.Default.Username = "";
               Properties.Settings.Default.Password = "";
               Properties.Settings.Default.Save();
           }
           this.Hide();
           
        }
        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListUsers();
            frm.ShowDialog();
        }
        private void currentUserInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
            Form frm = new frmUserInfo(clsGlobal.CurrentUser.UserID) ;
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListApplicationsTypes();    
            frm.ShowDialog();
        }

        private void manageTestsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListTestType();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListLocalDrivingLicenseApps();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListLocalDrivingLicenseApps();
            frm.ShowDialog();
        }
        private void internationalToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Form frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListInternationalLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmRenewLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void replacementForLostOrDamagedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReplacementforDamagedOrLostLicenses();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frm = new frmReleaseDetainedLicenseApp();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
        
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicenseApp();
            frm.ShowDialog();
        }
    }
}
