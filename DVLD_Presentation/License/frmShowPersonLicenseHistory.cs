using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.License.InternationalLicense;

namespace DVLD_Presentation.Applications
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private  DataTable _dtAllLocalLicenseHestory;
        private  DataTable _dtAllInternationalLicenseHestory;
        public int _PersonID = -1;
        public int _DriverID = -1; 
        public frmShowPersonLicenseHistory()
        {
            InitializeComponent();
            _dtAllLocalLicenseHestory = new DataTable();
            _dtAllInternationalLicenseHestory = new DataTable();
        }
        public frmShowPersonLicenseHistory(int PersonID) : this() 
        {
            _PersonID = PersonID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadLocalLicenseHistory()
        {           
            _dtAllLocalLicenseHestory = clsLicense.GetAllLicensesBasicInfoByPersonID(_PersonID);
            dgvLocalLicenseHistory.DataSource = _dtAllLocalLicenseHestory;
            lblLocalRecords.Text = dgvLocalLicenseHistory.Rows.Count.ToString();

            if (dgvLocalLicenseHistory.Rows.Count > 0)
            {
                dgvLocalLicenseHistory.Columns[0].HeaderText = "Lic.ID";
                dgvLocalLicenseHistory.Columns[0].Width = 110;

                dgvLocalLicenseHistory.Columns[1].HeaderText = "AppID";
                dgvLocalLicenseHistory.Columns[1].Width = 110;

                dgvLocalLicenseHistory.Columns[2].HeaderText = "Class Name";
                dgvLocalLicenseHistory.Columns[2].Width = 260;

                dgvLocalLicenseHistory.Columns[3].HeaderText = "Issue Date";
                dgvLocalLicenseHistory.Columns[3].Width = 200;

                dgvLocalLicenseHistory.Columns[4].HeaderText = "Expiration Date";
                dgvLocalLicenseHistory.Columns[4].Width = 200;

                dgvLocalLicenseHistory.Columns[5].HeaderText = "Is Active";
                dgvLocalLicenseHistory.Columns[5].Width = 110;
            }
        }
        private void _LoadInternationalLicenseHistory()
        {
            _dtAllInternationalLicenseHestory = clsInternationalLicense.GetAllBaseInternationalLicensesByPersonID(_PersonID);
            dgvInternationalLicenseHistory.DataSource = _dtAllInternationalLicenseHestory;
            lblInternationalRecords.Text = dgvInternationalLicenseHistory.Rows.Count.ToString();

            if (dgvInternationalLicenseHistory.Rows.Count > 0)
            {
                dgvInternationalLicenseHistory.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenseHistory.Columns[0].Width = 190;

                dgvInternationalLicenseHistory.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseHistory.Columns[1].Width = 190;

                dgvInternationalLicenseHistory.Columns[2].HeaderText = "L.License ID";
                dgvInternationalLicenseHistory.Columns[2].Width = 190;

                dgvInternationalLicenseHistory.Columns[3].HeaderText = "Issue Date";
                dgvInternationalLicenseHistory.Columns[3].Width = 190;

                dgvInternationalLicenseHistory.Columns[4].HeaderText = "Expiration Date";
                dgvInternationalLicenseHistory.Columns[4].Width = 190;

                dgvInternationalLicenseHistory.Columns[5].HeaderText = "Is Active";
                dgvInternationalLicenseHistory.Columns[5].Width = 190;
            }
        }
        private void LoadInfoByPersonID(int PersonID)
        {
            clsDriver Driver = clsDriver.FindByPersonID(PersonID);
            if (Driver == null)
            {
                MessageBox.Show("There is no driver Link with Person id = " + PersonID);
                return;    
            }

            _DriverID = Driver.DriverID;
            _LoadLocalLicenseHistory();
            _LoadInternationalLicenseHistory();
        }
        private void frmLicenseHistory_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);
                ctrlPersonCardWithFilter1.FilterEnabled = false;
                LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ctrlPersonCardWithFilter1.FilterEnabled = true;
                ctrlPersonCardWithFilter1.FilterFocus();    
            }
        }
        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value;

            if (LicenseID == -1)
            { MessageBox.Show("This Person Is not have any Licenses");
                return;
            }
            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           int InternationalID = (int)  dgvInternationalLicenseHistory.CurrentRow.Cells [0].Value;
            if (InternationalID == -1)
            { 
                MessageBox.Show("This Person Is not have any Internationl Licenses");
                return;
            }
            Form frm = new frmShowInternationalDriverInfo(InternationalID);
            frm.ShowDialog();
        }
        private void ctrlPersonCardWithFilter1_OnPersonSelected_1(int obj)
        {
            _PersonID = obj;
            if (_PersonID == -1)
            {
                dgvLocalLicenseHistory.DataSource = null;
                dgvInternationalLicenseHistory.DataSource = null;

                lblLocalRecords.Text = "0";
                lblInternationalRecords.Text = "0";
            }
            else
                LoadInfoByPersonID(_PersonID);

        }

        private void dgvLocalLicenseHistory_DoubleClick(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvLocalLicenseHistory.CurrentRow.Cells[0].Value;

            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void dgvInternationalLicenseHistory_DoubleClick(object sender, EventArgs e)
        {
            int InternationalID = (int)dgvInternationalLicenseHistory.CurrentRow.Cells[0].Value;
            Form frm = new frmShowInternationalDriverInfo(InternationalID);
            frm.ShowDialog();
        }
    }
}

