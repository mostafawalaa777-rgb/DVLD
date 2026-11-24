using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.License;
using DVLD_Business;

namespace DVLD_Presentation.Applications
{
    public partial class frmListLocalDrivingLicenseApps : Form
    {
       // public enum enTestType { VisionTest = 1, WrittenTest = 2, StreetTest = 3 }


        public clsDriver Driver;
        public clsLicenseClass LicenseClass;
        public clsLicense License;

        private static DataTable _dtAllLocalDrivingLicenseApps;
        private int _LocalDrivingLicenseApplicationID = -1;
        public frmListLocalDrivingLicenseApps()
        {
            InitializeComponent();
        }
        public frmListLocalDrivingLicenseApps(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListLocalDrivingLicenseApps_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicenseApps = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApps();

            dgvListLocalDrivingLicenseApps.DataSource = _dtAllLocalDrivingLicenseApps;
            cbbFilter.SelectedIndex = 1;
            lblRecords.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();

            if (dgvListLocalDrivingLicenseApps.Rows.Count > 0)
            {
                dgvListLocalDrivingLicenseApps.Columns[0].HeaderText = "L.D.L.AppID";
                dgvListLocalDrivingLicenseApps.Columns[0].Width = 110;

                dgvListLocalDrivingLicenseApps.Columns[1].HeaderText = "Driving Class";
                dgvListLocalDrivingLicenseApps.Columns[1].Width = 270;

                dgvListLocalDrivingLicenseApps.Columns[2].HeaderText = "National No";
                dgvListLocalDrivingLicenseApps.Columns[2].Width = 110;

                dgvListLocalDrivingLicenseApps.Columns[3].HeaderText = "Full Name";
                dgvListLocalDrivingLicenseApps.Columns[3].Width = 290;

                dgvListLocalDrivingLicenseApps.Columns[4].HeaderText = "Application Date";
                dgvListLocalDrivingLicenseApps.Columns[4].Width = 150;

                dgvListLocalDrivingLicenseApps.Columns[5].HeaderText = "Passed Tests";
                dgvListLocalDrivingLicenseApps.Columns[5].Width = 120;

                dgvListLocalDrivingLicenseApps.Columns[6].HeaderText = "Status";
                dgvListLocalDrivingLicenseApps.Columns[6].Width = 100;
            }
            cbbFilter.SelectedIndex = 0;
        }
        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbSearsh.Visible = !(cbbFilter.Text == "None");
            txtbSearsh.Clear();
        }
        private void txtbSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilter.Text == "L.D.L.AppID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void txtbSearsh_TextChanged(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApp = new clsLocalDrivingLicenseApplication();
            string FilterColumn = "";

            switch (cbbFilter.Text)
            {
                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if ((txtbSearsh.Text.Trim() == "") || (FilterColumn == "None"))
            {
                _dtAllLocalDrivingLicenseApps.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();

            }
            else if (FilterColumn == "LocalDrivingLicenseApplicationID")
            {

                _dtAllLocalDrivingLicenseApps.DefaultView.RowFilter =
                   string.Format("[{0}] = {1}", FilterColumn, txtbSearsh.Text.Trim());
            }
            else
            {
                _dtAllLocalDrivingLicenseApps.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbSearsh.Text.Trim());
            }
            lblRecords.Text = dgvListLocalDrivingLicenseApps.Rows.Count.ToString();

        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frm = new frmNewLocalDrivingLicenseApplication();
            frm.ShowDialog();
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void dgvListLocalDrivingLicenseApps_DoubleClick(object sender, EventArgs e)
        {
            int LocalDrivinngLicenseApplicationID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            Form frm = new frmNewLocalDrivingLicenseApplication(LocalDrivinngLicenseApplicationID);
            frm.ShowDialog();
        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinngLicenseApplicationID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);

            if (MessageBox.Show("Are you sure you want to delete Local Driving License Application  [" + dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsLocalDrivingLicenseApplication.DeletLocalDrivingLicenseApp(LocalDrivinngLicenseApplicationID))
                {
                    MessageBox.Show("Local Driving License Application Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Local Driving License Application was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void cancelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int LDLAppID = Convert.ToInt32(dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplication LocalApp =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);

            if (LocalApp == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }
            clsApplication App = clsApplication.FindAppByID(LocalApp.ApplicationID);
            if (App == null)
            {
                MessageBox.Show("Application not found.");
                return;
            }
            if (MessageBox.Show("Are you sure you want to Cancel Local Driving License Application  [" + dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value + "]", "Confirm Cancel", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                App.ApplicationStatus = clsApplication.enApplicationStatus.Cancelled;
                App.ApplicationDate = DateTime.Now;

                if (App.Save())
                {
                    MessageBox.Show("Application Cancelled Successfully");

                    // Refresh الـ DataGridView
                    frmListLocalDrivingLicenseApps_Load(null, null);
                }
            }
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinngLicenseApplicationID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);

            Form frm = new frmNewLocalDrivingLicenseApplication(LocalDrivinngLicenseApplicationID);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinngLicenseApplicationID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            Form frm = new frmLocalDrivingLicenseApplicationInfo(LocalDrivinngLicenseApplicationID);
            frm.ShowDialog();
        }
        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);

            clsLicense License = clsLicense.FindByApplicationID(LocalApp.ApplicationID);

            Form frm = new frmShowLicenseInfo(License.LicenseID);
            frm.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);
           
            Form frm = new frmShowPersonLicenseHistory(LocalApp.PersonInfo.PersonID);
            frm.ShowDialog();
        }
        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

            int LDLAppID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);

            clsLocalDrivingLicenseApplication LocalApp = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(LDLAppID);
            int PersonID = LocalApp.ApplicantPersonID;
            int LicenseClassID = LocalApp.LicenseClassID;


            bool IsNew = LocalApp.ApplicationStatus == clsApplication.enApplicationStatus.New;
            int PassedTests = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells["PassedTestCount"].Value);
            bool PassedVisionTest = clsTests.DoesPassTestType(LDLAppID, (int)clsTestType.enTestType.VisionTest);
            bool PassedWrittenTest = clsTests.DoesPassTestType(LDLAppID, (int)clsTestType.enTestType.WrittenTest);
            bool PassedStreetTest = clsTests.DoesPassTestType(LDLAppID, (int)clsTestType.enTestType.StreetTest);

            //Application options
            toolStripMenuItem2.Enabled = IsNew && PassedTests < 3;
            deleteApplicationToolStripMenuItem.Enabled = IsNew;
            editApplicationToolStripMenuItem.Enabled = IsNew;
            cancelToolStripMenuItem.Enabled = IsNew;

            //License options

            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = IsNew && PassedTests == 3;
            showLicenseToolStripMenuItem.Enabled =  clsLicense.GetActiveLicenseIDByPersonIDAndClassID(PersonID, LicenseClassID) != -1;

            // schedule test options
            scheduleVisionTestToolStripMenuItem.Enabled = !PassedVisionTest;
            scheduleWrittenTestToolStripMenuItem.Enabled = PassedVisionTest && !PassedWrittenTest;
            scheduleStreetTestToolStripMenuItem.Enabled = PassedVisionTest && PassedWrittenTest && !PassedStreetTest;
        }
        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            Form frm = new frmListTestAppointments(ID, clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            Form frm = new frmListTestAppointments(ID, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);
            Form frm = new frmListTestAppointments(ID, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicenseApps_Load(null, null);
        }
        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivinngLicenseApplicationID = ((int)dgvListLocalDrivingLicenseApps.CurrentRow.Cells[0].Value);

            Form frm = new frmIssueDriverLicenseForTheFirstTime(LocalDrivinngLicenseApplicationID);
            frm.ShowDialog();
        }
    }
}

           
           
        
    