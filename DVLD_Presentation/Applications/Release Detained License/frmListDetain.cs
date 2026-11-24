using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Business;
using DVLD_Presentation.Applications;
using DVLD_Presentation.License;
using DVLD_Presentation.People;

namespace DVLD_Presentation.Detain
{
    public partial class frmListDetainedLicenses : Form
    {
        private static DataTable _dtAllDetainedLicenses;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _dtAllDetainedLicenses = clsDetain.GetAllDetains();
            dgvListDetainedLicenses.DataSource = _dtAllDetainedLicenses;
           
        
        cbbFilterDetainedLicenses.SelectedIndex = 0;
            lblRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();

            dgvListDetainedLicenses.Columns[0].HeaderText = "D.ID";
            dgvListDetainedLicenses.Columns[0].Width = 110;

            dgvListDetainedLicenses.Columns[1].HeaderText = "L.ID";
            dgvListDetainedLicenses.Columns[1].Width = 110;

            dgvListDetainedLicenses.Columns[2].HeaderText = "D.Date";
            dgvListDetainedLicenses.Columns[2].Width = 180;

            dgvListDetainedLicenses.Columns[3].HeaderText = "Is Released";
            dgvListDetainedLicenses.Columns[3].Width = 150;

            dgvListDetainedLicenses.Columns[4].HeaderText = "Fine Fees";
            dgvListDetainedLicenses.Columns[4].Width = 150;

            dgvListDetainedLicenses.Columns[5].HeaderText = "Release Date";
            dgvListDetainedLicenses.Columns[5].Width = 180;

            dgvListDetainedLicenses.Columns[6].HeaderText = "N.NO";
            dgvListDetainedLicenses.Columns[6].Width = 110;

            dgvListDetainedLicenses.Columns[7].HeaderText = "Full Name";
            dgvListDetainedLicenses.Columns[7].Width = 200;

            dgvListDetainedLicenses.Columns[8].HeaderText = "Release App.ID";
            dgvListDetainedLicenses.Columns[8].Width = 150;
            txtbSearsh.Focus();
        }
        private void txtbSearsh_TextChanged(object sender, EventArgs e)
        {

            clsDetain detain = new clsDetain();
            string FilterColumn = "";
                        
            switch (cbbFilterDetainedLicenses.Text)
            {
                case "DetainID":
                    FilterColumn = "DetainID";
                    break;

                case "Is Released":
                    FilterColumn = "IsReleased";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Release Application ID":
                    FilterColumn = "ReleaseApplicationID";

                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
            if (FilterColumn == "IsReleased")
            {
                txtbSearsh.Visible = false;
                cbIsReleased.Visible = true;
                cbIsReleased.Focus();   
            }
            else if (txtbSearsh.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDetainedLicenses.DefaultView.RowFilter = "";
                lblRecords.Text = _dtAllDetainedLicenses.Rows.Count.ToString();
                return;
            }
            else if (FilterColumn == "DetainID" || FilterColumn == "ReleaseApplicationID")
                _dtAllDetainedLicenses.DefaultView.RowFilter =
                    string.Format("[{0}] = {1} ", FilterColumn, txtbSearsh.Text.Trim());
            else
                _dtAllDetainedLicenses.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbSearsh.Text.Trim());

            lblRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();
        }
        private void cbbFilterDetainedLicenses_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsNone = (cbbFilterDetainedLicenses.Text == "None");
            bool IsIsReleased = (cbbFilterDetainedLicenses.Text == "Is Released");

            txtbSearsh.Visible = !IsNone && !IsIsReleased;

            cbIsReleased.Visible = IsIsReleased;
            cbIsReleased.SelectedIndex = 0;
            txtbSearsh.Clear();
        }
        private void cbIsReleased_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbIsReleased.Text)
            {
                case "All":
                    _dtAllDetainedLicenses.DefaultView.RowFilter = "";
                    break;

                case "Yes":
                    _dtAllDetainedLicenses.DefaultView.RowFilter = "[IsReleased] = 1";
                    break;

                case "No":
                    _dtAllDetainedLicenses.DefaultView.RowFilter = "[IsReleased] = 0";
                    break;
            }

            lblRecords.Text = dgvListDetainedLicenses.Rows.Count.ToString();
        }
        private void txtbSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilterDetainedLicenses.Text == "DetainID" || cbbFilterDetainedLicenses.Text == "Release Application ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          int licenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;

            clsLicense license = clsLicense.FindByLicenseID(licenseID);
            Form frm = new frmShowPersonInfo( license.DriverInfo.PersonID);
            frm.ShowDialog();
        }
        
        private void btnDetainedLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmDetainLicense();
            frm.ShowDialog();
        }
        private void btnReleasDetainedLicense_Click(object sender, EventArgs e)
        {
            Form frm = new frmReleaseDetainedLicenseApp();
            frm.ShowDialog();
        }
       
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            releaseDetainedLicenseىToolStripMenuItem.Enabled = !(bool)dgvListDetainedLicenses.CurrentRow.Cells[3].Value;
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;

            Form frm = new frmReleaseDetainedLicenseApp(licenseID);
            frm.ShowDialog();
            frmListDetainedLicenses_Load(null, null);

        }

        private void dgvListDetainedLicenses_DoubleClick(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void ShowLicenseDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int LicenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            Form frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void ShowPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = (int)dgvListDetainedLicenses.CurrentRow.Cells[1].Value;
            clsLicense license = clsLicense.FindByLicenseID(licenseID);
            Form frm = new frmShowPersonLicenseHistory(license.DriverInfo.PersonID);
            frm.ShowDialog();
        }
    }
}