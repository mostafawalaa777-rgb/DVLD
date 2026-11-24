using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Applications.AppControls;
using DVLD_Presentation.Properties;

namespace DVLD_Presentation.Applications
{
    public partial class frmListTestAppointments : Form
    { 
        private DataTable _dtAllTestAppointmentsList;

        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApp;
        private int _LocalDrivingLicenseAppID = -1;

        private clsTestAppointment TestAppointment;
        private clsTests _Tests;

        private clsTestType.enTestType _TestTypeID;

        public frmListTestAppointments()
        {
            InitializeComponent();
        }
        public frmListTestAppointments(int LocalDrivingLicenseAppID, clsTestType.enTestType TestTypeID)
        {
             InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _TestTypeID =  TestTypeID;
        }

        private void _LoadTestTypeImageAndTitle()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        pbTestAppointment.Image = Resources.Vision_512;
                        lblDiscribtion.Text = "Vision Test Appointment";
                        this.Text = "Vision Test Appointment";
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        pbTestAppointment.Image = Resources.Written_Test_512;
                        lblDiscribtion.Text = "Written Test Appointment";
                        this.Text = "Written Test Appointment";

                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        pbTestAppointment.Image = Resources.Street_Test_32;
                        lblDiscribtion.Text = "Street Test Appointment";
                        this.Text = "Street Test Appointment";

                        break;
                    }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlAppInfo1.LoadApplicationInfo(_LocalDrivingLicenseAppID);
            _LoadTestTypeImageAndTitle();
            _dtAllTestAppointmentsList = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseAppID, _TestTypeID );
            dgvTestAppointmentsList.DataSource = _dtAllTestAppointmentsList;
            lblRecords.Text = dgvTestAppointmentsList.Rows.Count.ToString();

            if (dgvTestAppointmentsList.Rows.Count > 0)
            {
                dgvTestAppointmentsList.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointmentsList.Columns[0].Width = 120;

                dgvTestAppointmentsList.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointmentsList.Columns[1].Width = 150;

                dgvTestAppointmentsList.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointmentsList.Columns[2].Width = 120;

                dgvTestAppointmentsList.Columns[3].HeaderText = "Is Locked";
                dgvTestAppointmentsList.Columns[3].Width = 120;
            }
        }
        private void btnAddTestAppointment_Click_1(object sender, EventArgs e)
        {
            _LocalDrivingLicenseApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseAppID);
            if (clsLocalDrivingLicenseApplication.DoesThereAnActiveScheduledTest(_LocalDrivingLicenseAppID, (int)_TestTypeID))
            {
                MessageBox.Show("Person already have an active appointment for this test  , you cannot add new apppointment .", "Not Allawed",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTests _LastTest = _LocalDrivingLicenseApp.GetLastTestPerTestType(_TestTypeID);
            if (_LastTest != null && _LastTest.TestResult)
            {
                MessageBox.Show("This Person already pass this test before , you can only retake  .", "Not Allawed",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm = new frmScheduleTest (_LocalDrivingLicenseAppID, _TestTypeID);
            frm.ShowDialog();
            frmVisionTestAppointments_Load(null, null);
        }        
        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = ((int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value);
            if (_Tests == null)
            {
                Form frm = new frmTakeTest(TestAppointmentID);
                frm.ShowDialog();
                frmVisionTestAppointments_Load(null, null);
            }
            
            //frmVisionTestAppointments_Load(null,null);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestAppointmentID = ((int)dgvTestAppointmentsList.CurrentRow.Cells[0].Value);

                Form frm = new frmScheduleTest(_LocalDrivingLicenseAppID, _TestTypeID, TestAppointmentID);
                frm.ShowDialog();
                frmVisionTestAppointments_Load(null, null);
        }
        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            takeTestToolStripMenuItem.Enabled = !(bool)dgvTestAppointmentsList.CurrentRow.Cells["IsLocked"].Value;
        }
    }
}

