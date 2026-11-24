using System;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Presentation.Global_Classes;
using DVLD_Presentation.Properties;
using static DVLD_Buisness.clsTestType;

namespace DVLD_Presentation.Applications.AppControls
{
    public partial class frmScheduleTest : Form
    {
        private enMode _Mode;
        public enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FirstTimeSchedule;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;
       
        private clsTestAppointment TestAppointment;
        private int _TestAppointmentID = -1;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int TestAppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _TestAppointmentID = TestAppointmentID;
        }
        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestType.Image = Resources.Vision_512;
                        lbltitel.Text = "Vision Test";
                        this.Text = "Vision Test";
                        gbRetakeTestInfo.Text = "Vision Test";
                        
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestType.Image = Resources.Written_Test_512;
                        lbltitel.Text = "Written Test";
                        this.Text = "Written Test";

                        gbRetakeTestInfo.Text = "Written Test";
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestType.Image = Resources.driving_test_512;
                        lbltitel.Text = "Street Test";
                        this.Text = "Street Test";

                        gbRetakeTestInfo.Text = "Street Test";
                        break;
                    }
            }
        }
        private bool _LoadTestAppointmentData()
        {
            if (TestAppointment == null)
            {
                MessageBox.Show("Error: No Appointment license whith ID =" + _TestAppointmentID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lblFees.Text = TestAppointment.PaidFees.ToString();
            if (DateTime.Compare(DateTime.Now, TestAppointment.AppointmentDate) < 0)
            {
                dtDate.MinDate = DateTime.Now;
            }
            else
            {
                dtDate.MinDate = TestAppointment.AppointmentDate;
            }

            if (TestAppointment.RetakeTestApplicationID == -1)
            {
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";

                gbRetakeTestInfo.Enabled = false;
            }
            else
            {
                lblRAppFees.Text = TestAppointment.RetakeTestAppInfo.AppPaidFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lbltitel.Text = "Schedule Retake Test";
                lblRTestAppID.Text = TestAppointment.RetakeTestApplicationID.ToString();
            }
            dtDate.Value = TestAppointment.AppointmentDate;

            return true;
        }
        public void LoadInfo()
        {
            if (_TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
                TestAppointment = new clsTestAppointment();
            }
            else
            {
                _Mode = enMode.Update;
                TestAppointment = clsTestAppointment.FindTestAPPointmentByID(_TestAppointmentID);
                if (TestAppointment == null)
                {
                    MessageBox.Show("Test Appointment was not found.");
                    btnSave.Enabled = false;
                    return;
                }
            }
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No local driving license application whith ID =" + _LocalDrivingLicenseApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (clsLocalDrivingLicenseApplication.DoesAttendTestType(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
                lblRAppFees.Text = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees.ToString();
                gbRetakeTestInfo.Enabled = true;
                lbltitel.Text = "Schedule Retake Test";
                lblRTestAppID.Text = "0";
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchedule;
                gbRetakeTestInfo.Enabled = false;
                lblRAppFees.Text = "0";
                lbltitel.Text = "Schedule Test";
                lblRTestAppID.Text = "N/A";
            }

            lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblDClass.Text = _LocalDrivingLicenseApplication.LicenseClassInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblTrial.Text = clsTests.GetFailedTestCount(_LocalDrivingLicenseApplicationID, (int)_TestTypeID).ToString(); ;

            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.FindByTestTypeID(_TestTypeID).TestTypeFees.ToString();
                dtDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";

            }
            else
            {
                if (!_LoadTestAppointmentData())
                    return;
            }


            lBLTotalFees.Text = (Convert.ToSingle(lblFees.Text)
                                +
                                Convert.ToSingle(lblRAppFees.Text)).ToString();

            if (!_HandelActiveTestAppointmentConstraint())
                return;
            if (!_HandelAppointmentLockedConstraint())
                return;
            if (!_HandlePrviousTestConstraint())
                return;
        }
        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();
            LoadInfo();
        }
        private bool _HandelActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsLocalDrivingLicenseApplication.DoesThereAnActiveScheduledTest(_LocalDrivingLicenseApplicationID, (int)_TestTypeID))
            {
                lblDiscription.Text = "Person already have an active appointment for this test";
                btnSave.Enabled = false;
                dtDate.Enabled = false;
                return false;
            }
            return true;
        }
        private bool _HandelAppointmentLockedConstraint()
        {
            if (TestAppointment.IsLocked)
            {
                lblDiscription.Visible = true;
                lblDiscription.Enabled = true;
                lblDiscription.Text = "Person already sat for the test, appointment loacked.";
                dtDate.Enabled = false;
                btnSave.Enabled = false;
                gbRetakeTestInfo.Enabled = true;
                gbRetakeTestInfo.Text = "Retake Test Info";
                return false;
            }
            else
                lblDiscription.Visible = false;
            return true;
        }
        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID) 
            {
                case clsTestType.enTestType.WrittenTest:
                    if (!clsTests.DoesPassTestType(_LocalDrivingLicenseApplicationID,
                        (int)clsTestType.enTestType.VisionTest))
                    {
                        lblDiscription.Text = "Cannot schedule, Vision Test should be passed first.";
                        break;
                    }
                    return true;

                case clsTestType.enTestType.StreetTest:
                    if (!clsTests.DoesPassTestType(_LocalDrivingLicenseApplicationID,
                        (int)clsTestType.enTestType.WrittenTest))
                    {
                        lblDiscription.Text = "Cannot schedule, Written Test should be passed first.";
                        break;
                    }
                    return true;

                default:
                    lblDiscription.Visible = false;
                    return true;
            }

            lblDiscription.Visible = true;
            dtDate.Enabled = false;
            btnSave.Enabled = false;

            return false;
        }
        private bool _HandelRetakeTestApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplication Application = new clsApplication();
                Application.ApplicantPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
                Application.ApplicationDate = DateTime.Now;
                Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RetakeTest;
                Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed; 
                Application.LastStatusDate = DateTime.Now;
                Application.AppPaidFees = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.RetakeTest).ApplicationFees;
                Application.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!Application.Save())
                {
                    TestAppointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                TestAppointment.RetakeTestApplicationID = Application.ApplicationID;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandelRetakeTestApplication())
                return;

            if (_Mode == enMode.AddNew)
            {
                TestAppointment.TestTypeID = _TestTypeID;
                TestAppointment.LocalDrivingLicenseApplicationID = _LocalDrivingLicenseApplicationID;
                TestAppointment.PaidFees = Convert.ToSingle(lblFees.Text);
                TestAppointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            }
            TestAppointment.AppointmentDate = dtDate.Value;

            if (TestAppointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                return;
            }
            MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
    

