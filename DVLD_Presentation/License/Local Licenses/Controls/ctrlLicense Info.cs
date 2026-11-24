
using System.IO;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.Properties;

namespace DVLD_Presentation.Applications.AppControls
{
    public partial class ctrlLicense_Info : UserControl
    {
        //public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;

        private clsLicense License;
        //public clsDriver Driver;
        public clsPerson PersonInfo;
        //public clsLicenseClass LicenseClasse;
        private int _LicenseID = -1;
        public int LicenseID 
        {
            get { return _LicenseID; }
        }
        public clsLicense SelectedLicenseInfo
        { get { return License; } }

        public ctrlLicense_Info()
        {
            InitializeComponent();
        }
        public ctrlLicense_Info(int LicenseID)
        {
            InitializeComponent();
            _LicenseID = LicenseID;
        }
        public void LoadLicenseInfo(int LicenseID)
        {

            _LicenseID = LicenseID;
            License = clsLicense.FindByLicenseID (LicenseID);

            if (License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }
            _FillLicenseInfo();
        } 
        private void _LoadDriverImage()
        {
            if (License.DriverInfo.PersonInfo.Gendor == 0)
                pbDriver.Image = Resources.Male_512;
            else
                pbDriver.Image = Resources.Male_512;

            string ImagePath = License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbDriver.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillLicenseInfo()
        {

            lblLicenseID.Text = License.LicenseID.ToString();
            lblIsActive.Text = License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = License.IsDetained ? "Yes" : "No";
            lblLicenseClass.Text = License.LicenseClassInfo.ClassName;
            lblDriverName.Text = License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = License.DriverInfo. PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();
            pbGender.Image = License.DriverInfo.PersonInfo.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;
            lblDriverID.Text =License.DriverID.ToString(); 
            lblIssueDate.Text = License.IssueDate.ToShortDateString();
            lblExpirationDate.Text = License.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = License.IssueReasonText;
            lblNotes.Text = License.Notes == "" ?"No Notes" : License.Notes;

            _LoadDriverImage();
        }
    }
}
