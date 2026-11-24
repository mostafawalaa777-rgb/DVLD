using System;
using System.IO;

using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.Properties;

namespace DVLD_Presentation.License.InternationalLicense
{
    public partial class frmShowInternationalDriverInfo : Form
    {
        
        public clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication;

        //public clsLicense License;
        public clsInternationalLicense InternationalLicense;
        public clsDriver Driver;
        public clsPerson PersonInfo;
        public clsLicenseClass LicenseClasse;
        private int _LicenseID = -1;
        private int _InternationalLicenseID = -1;
        public int LicenseID
        {
            get { return _LicenseID; }
        }
        public frmShowInternationalDriverInfo()
        {
            InitializeComponent();
        }
        public frmShowInternationalDriverInfo(int InternationalLicenseID)
        {
            InitializeComponent();
            _InternationalLicenseID  = InternationalLicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ResetInternationalLicenseInfo()
        {
            lblDriverName.Text = "[????]";
            lblIntLicenseID.Text = "[????]";
            lblLicenseID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGendor.Text = "[????]";
            lblIssueDate.Text = "[????]";
            lblApplicationID.Text = "[????]";
            lblIsActive.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblDriverID.Text = "[????]";
            lblExpirationDate.Text = "[????]";
           
            pbDriver.Image = Resources.Male_512;
        }
        private void _LoadDriverImage()
        {
            if (PersonInfo.Gendor == 0)
                pbDriver.Image = Resources.Male_512;
            else
                pbDriver.Image = Resources.Male_512;

            string ImagePath = PersonInfo.ImagePath;
            if (ImagePath != "")
            {
                if (File.Exists(ImagePath))
                    pbDriver.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _FillInternationalLicenseInfo()
        {
            clsLicense License = clsLicense.FindByLicenseID(InternationalLicense.IssuedUsingLocalLicenseID);
            if (License == null)
            {
                MessageBox.Show("Local License not found.");
                return;
            }
            lblDriverName.Text = PersonInfo.FullName;
            lblIntLicenseID.Text = InternationalLicense.InternationalLicenseID.ToString();
            lblLicenseID.Text = License.LicenseID.ToString();
            lblNationalNo.Text = PersonInfo.NationalNo;
            lblGendor.Text = PersonInfo.Gendor == 0 ? "Male" : "Female";
            pbGender.Image = PersonInfo.Gendor == 0 ? Resources.Man_32 : Resources.Woman_32;

            lblIssueDate.Text = InternationalLicense.IssueDate.ToShortDateString();
            lblApplicationID.Text = InternationalLicense.ApplicationID.ToString();
            lblIsActive.Text = InternationalLicense.IsActive ? "Yes" : "No";
            lblDateOfBirth.Text = PersonInfo.DateOfBirth.ToShortDateString();
            lblDriverID.Text = Driver.DriverID.ToString();
            lblExpirationDate.Text = InternationalLicense.ExpirationDate.ToShortDateString();

            _LoadDriverImage();
        }

        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            InternationalLicense = clsInternationalLicense.FindByInternationalLicenseID(InternationalLicenseID);
            if (InternationalLicense == null)
            {
                ResetInternationalLicenseInfo();
                MessageBox.Show("No International License with InternationalLicenseID = " + _InternationalLicenseID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Load Driver
            Driver = clsDriver.FindByDriverID(InternationalLicense.DriverID);
            if (Driver == null)
            {
                MessageBox.Show("Driver information not found.");
                return;
            }

            // Load Person
            PersonInfo = clsPerson.Find(Driver.PersonID);
            if (PersonInfo == null)
            {
                MessageBox.Show("Person information not found.");
                return;
            }

            // Load Local License
            clsLicense License = clsLicense.FindByLicenseID(InternationalLicense.IssuedUsingLocalLicenseID);
            if (License == null)
            {
                MessageBox.Show("Local License information not found.");
                return;
            }

            // Load License Class
            LicenseClasse = clsLicenseClass.Find(License.LicenseClassID);
            if (LicenseClasse == null)
            {
                MessageBox.Show("License Classe information not found.");
                return;
            }
            _FillInternationalLicenseInfo();
        }

        private void frmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            LoadInternationalLicenseInfo(_InternationalLicenseID);
        }
    }
}
