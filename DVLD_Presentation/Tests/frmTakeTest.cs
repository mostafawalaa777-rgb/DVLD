using System;

using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
namespace DVLD_Presentation.Applications
{
    public partial class frmTakeTest : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        private clsTestAppointment _testAppointment;
        private int _TestAppointmentID = -1;
        
        private clsTestType.enTestType _TestTypeID;

        private clsTests _Test;
        private int _TestID = -1;

        private clsLocalDrivingLicenseApplication _localDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmTakeTest(int TestAppointmentID)
        {
            InitializeComponent();

            _TestAppointmentID = TestAppointmentID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        gbtaketestInfo.Text = "Vision Test";
                        this.Text = "Vision Test";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        gbtaketestInfo.Text = "Written Test";
                        this.Text = "Written Test";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        gbtaketestInfo.Text = "Street Test";
                        this.Text = "Street Test";
                        break;
                    }
            }
        }
        public void LoadInfo(int TestAppointmentID)
        {
            _TestAppointmentID = TestAppointmentID;
            _testAppointment = clsTestAppointment.FindTestAPPointmentByID(TestAppointmentID);

            if (_testAppointment == null)
            {
                MessageBox.Show("Error: No  Appointment ID = " + _TestAppointmentID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _TestAppointmentID = -1;
                return;
            }
            _TestTypeID = _testAppointment.TestTypeID;


                if (_TestID != -1)
            _Test = clsTests.FindTestByTestAppointmentID(_TestAppointmentID);
            if (_Test != null)
            {
                _TestID = _Test.TestID;

                if (_Test.TestResult)
                    rbPase.Checked = true;
                else
                    rbFail.Checked = true;

                rtxtbNotes.Text = _Test.Notes;
                lblUserMessage.Visible = true;
                rbFail.Enabled = false;
                rbPase.Enabled = false;
            }
            else
            {
                _TestID = -1;
                _Test = new clsTests();
            }


            _LocalDrivingLicenseApplicationID = _testAppointment.LocalDrivingLicenseApplicationID;
            _localDrivingLicenseApplication =
                            clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_localDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lblDLAppID.Text = _localDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _localDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _localDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = clsTests.GetFailedTestCount(_LocalDrivingLicenseApplicationID, (int)_TestTypeID).ToString();

            lbldtDate.Text = _testAppointment.AppointmentDate.ToString();
            lblTestID.Text = (_TestID == -1) ? "Not Taken Yet" : _TestID.ToString();
            lblFees.Text = _testAppointment.PaidFees.ToString();
        }
        private void frmTakeTest_Load(object sender, EventArgs e)
        {

            _testAppointment = clsTestAppointment.FindTestAPPointmentByID(_TestAppointmentID);
            LoadInfo(_TestAppointmentID);
            _LoadTestTypeImageAndTitle();

            if (_testAppointment.IsLocked == false)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;

            if (_TestAppointmentID == -1)
            {
                btnSave.Enabled = false;
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Are you sure you want to save? After that you cannot change the Pass/Fail result.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            _Test = new clsTests();
            _Test.TestAppointmentID = _TestAppointmentID;
            _Test.TestResult = rbPase.Checked;
            _Test.Notes = rtxtbNotes.Text.Trim();
            _Test.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if(rbPase.Checked )
            {
                 _testAppointment.IsLocked = true;
                rbFail.Enabled = false;
                rbPase.Enabled = false;
                btnSave.Enabled = false;
                
            }
            if (_Test.Save())
            {
                _TestID = _Test.TestID;
                _Mode = enMode.Update;
                _testAppointment.IsLocked = true;

                MessageBox.Show("Data Saved Successfully.",
                    "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Close();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
    

