using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_Presentation.Applications;
using DVLD_Presentation.People;

namespace DVLD_Presentation.License.InternationalLicense
{
    public partial class frmListInternationalLicense : Form
    {
        private DataTable _dtAllInternationalLicense;
        public frmListInternationalLicense()
        {
            InitializeComponent();
            _dtAllInternationalLicense = new DataTable();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddInternationalLicense();
            frm.ShowDialog();
        }
        private void _LoadInternationalLicenseHistory()
        {
            _dtAllInternationalLicense = clsInternationalLicense.GetAllInternationalLicenses();
            dgvInternationalLicenseApps.DataSource = _dtAllInternationalLicense;
            lblRecords.Text = dgvInternationalLicenseApps.Rows.Count.ToString();

            if (dgvInternationalLicenseApps.Rows.Count > 0)
            {
                dgvInternationalLicenseApps.Columns[0].HeaderText = "Int.License ID";
                dgvInternationalLicenseApps.Columns[0].Width = 150;

                dgvInternationalLicenseApps.Columns[1].HeaderText = "Application ID";
                dgvInternationalLicenseApps.Columns[1].Width = 150;

                dgvInternationalLicenseApps.Columns[2].HeaderText = "Driver ID";
                dgvInternationalLicenseApps.Columns[2].Width = 150;

                dgvInternationalLicenseApps.Columns[3].HeaderText = "L.License ID";
                dgvInternationalLicenseApps.Columns[3].Width = 150;

                dgvInternationalLicenseApps.Columns[4].HeaderText = "Issue Date";
                dgvInternationalLicenseApps.Columns[4].Width = 170;

                dgvInternationalLicenseApps.Columns[5].HeaderText = "Expiration Date";
                dgvInternationalLicenseApps.Columns[5].Width = 170;

                dgvInternationalLicenseApps.Columns[6].HeaderText = "Is Active";
                dgvInternationalLicenseApps.Columns[6].Width = 110;
            }
        }

        private void frmListInternationalLicense_Load(object sender, EventArgs e)
        {
            cbbFilter.SelectedIndex = 0;
            _LoadInternationalLicenseHistory();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dgvInternationalLicenseApps.CurrentRow.Cells["ApplicationID"].Value;
            clsApplication  Application = clsApplication.FindAppByID(ApplicationID);
            Form frm = new frmShowPersonInfo(Application.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvInternationalLicenseApps.CurrentRow.Cells[3].Value;
            Form frm = new  frmShowLicenseInfo (LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = (int)dgvInternationalLicenseApps.CurrentRow.Cells["ApplicationID"].Value;
            clsApplication Application = clsApplication.FindAppByID(ApplicationID);
            Form frm = new frmShowPersonLicenseHistory(Application.PersonInfo.PersonID);
            frm.ShowDialog();
        }

        private void txtbSearsh_TextChanged(object sender, EventArgs e)
        {
            clsInternationalLicense InternationalLicense = new clsInternationalLicense();
            string FilterColumn = "";
            switch (cbbFilter.Text)
            {
                case "International License ID":
                    FilterColumn = "InternationalLicenseID";
                    break;

                case "Application ID":
                    FilterColumn = "ApplicationID";
                    break;

                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Local License ID":
                    FilterColumn = "LocalLicenseID";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None"; // لما بفتح الفورم بيظهر التيكست و 2 كومبوبوكش ومش بيكون none ديفولت لي ؟

                    break;
            }

            if (FilterColumn == "IsActive")
            {
                txtbSearsh.Visible = false;
                cbIsActive.Visible = true;
            }
            else if (txtbSearsh.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllInternationalLicense.DefaultView.RowFilter = "";
            }

            else if (FilterColumn == "InternationalLicenseID" || FilterColumn == "ApplicationID"
                || FilterColumn == "LocalLicenseID" || FilterColumn == "DriverID")
                
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] = {1} ", FilterColumn, txtbSearsh.Text.Trim());

            else
                _dtAllInternationalLicense.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtbSearsh.Text.Trim());

            lblRecords.Text = dgvInternationalLicenseApps.Rows.Count.ToString();
        }

        private void cbbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsNone = (cbbFilter.Text == "None");
            bool IsIsActive = (cbbFilter.Text == "Is Active");

            txtbSearsh.Visible = !IsNone && !IsIsActive;

            cbIsActive.Visible = IsIsActive;
            cbIsActive.SelectedIndex = 0;
            txtbSearsh.Clear();
            _dtAllInternationalLicense.DefaultView.RowFilter = "";
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsActive.Text)
            {
                case "All":
                    _dtAllInternationalLicense.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtAllInternationalLicense.DefaultView.RowFilter = "[IsActive] = 1";
                    break;

                case "No":
                    _dtAllInternationalLicense.DefaultView.RowFilter = "[IsActive] = 0";
                    break;
            }

            lblRecords.Text = dgvInternationalLicenseApps.Rows.Count.ToString();

        }

        private void txtbSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilter.Text == "International License ID" ||
                cbbFilter.Text == "Application ID" ||
                cbbFilter.Text == "Driver ID" ||
                cbbFilter.Text == "Local License ID")
            { 
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
