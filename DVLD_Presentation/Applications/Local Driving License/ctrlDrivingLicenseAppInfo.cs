
using System.ComponentModel;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness;
using DVLD_Presentation.People;
namespace DVLD_Presentation.Applications
{
    public partial class ctrlAppInfo : UserControl
    {
        private clsApplication _Application;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicensApp;
      
        private int LicenseID;

        private int _LocalDrivingLicenseAppID = -1;  

        private int _ApplicationID = -1;

        private int _UserID = -1;

        private int _TestTypeID = -1;
        

        public ctrlAppInfo()
        {
            InitializeComponent();
        }
        public void LoadApplicationInfo(int LocalDrivingLicenseAppID)
        {
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _LocalDrivingLicensApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseAppID);

            if (_LocalDrivingLicensApp != null)
            {
                _FillApplicationInfo();
            }
            else
            {
                MessageBox.Show("No Local Driving Licens Application with Local Driving Licens Application ID = " + _LocalDrivingLicenseAppID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            
            _Application = clsApplication.FindAppByID(_LocalDrivingLicensApp.ApplicationID);

        }
        private string _PassedTests ()
        {
            return clsLocalDrivingLicenseApplication.GetPassedTestCount(_LocalDrivingLicenseAppID).ToString() + "/3";
        }
        private void _FillApplicationInfo()
        {

            clsLicense _License = clsLicense.FindByApplicationID(_LocalDrivingLicensApp.ApplicationID);
            lblDLicenseAppID.Text = _LocalDrivingLicensApp.LocalDrivingLicenseApplicationID.ToString(); 
            lblAppliedForLicense.Text = _LocalDrivingLicensApp.LicenseClassInfo.ClassName.ToString();
            lblPassedTests.Text = _PassedTests();
            lblDLAppID.Text = _LocalDrivingLicensApp.ApplicationID.ToString();   
            lblStatus.Text = _LocalDrivingLicensApp.StatusText;
            lblFees.Text = _LocalDrivingLicensApp.AppPaidFees.ToString(); 
            lblType.Text = _LocalDrivingLicensApp.ApplicationTypeInfo.ApplicationTypeTitle.ToString();
            lblApplicant.Text = _LocalDrivingLicensApp.ApplicantFullName;
            lblDate.Text = _LocalDrivingLicensApp.ApplicationDate.ToShortDateString();    
            lblStatusDate.Text = _LocalDrivingLicensApp.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = _LocalDrivingLicensApp.CreatedByUserInfo.UserName;
            if(_License == null)
                lnklShowLicenseInfo.Enabled = false;
            else 
                lnklShowLicenseInfo.Enabled = true;
        }
        private void lnklShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLicense License = clsLicense.FindByApplicationID(_LocalDrivingLicensApp.ApplicationID);
           
            Form frm = new frmShowLicenseInfo(License.LicenseID);
            frm.ShowDialog();
        }
        private void lnklViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_Application != null)
            {
                Form frm = new frmShowPersonInfo(_Application.ApplicantPersonID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("this application is Null try Anther One ");
            }
        }

        private void ctrlAppInfo_Load(object sender, System.EventArgs e)
        {

        }
    }
}
