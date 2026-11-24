using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Business;
using DVLD_Presentation.Applications;
using DVLD_Presentation.License;
using DVLD_Presentation.People;

namespace DVLD_Presentation
{
    public partial class frmListDrivers : Form
    {
        private static DataTable _dtAllDrivers;

        public int LocalDLAppID = -1;
        public int _DriverID = -1;
        public int _PersonID = -1;
        public frmListDrivers()
        {
            InitializeComponent();
        }
        private void Drivers_Load(object sender, EventArgs e)
        {
            _dtAllDrivers = clsDriver.GetAllDrivers();
            dgvListDrivers.DataSource = _dtAllDrivers;
            lblRecords.Text = dgvListDrivers.Rows.Count.ToString();
            cbbFilterDrivers.SelectedIndex = 0;

            dgvListDrivers.Columns[0].HeaderText = "Driver ID";
            dgvListDrivers.Columns[0].Width = 110;

            dgvListDrivers.Columns[1].HeaderText = "Person ID";
            dgvListDrivers.Columns[1].Width = 110;

            dgvListDrivers.Columns[2].HeaderText = "National No";
            dgvListDrivers.Columns[2].Width = 110;

            dgvListDrivers.Columns[3].HeaderText = "Full Name";
            dgvListDrivers.Columns[3].Width = 310;

            dgvListDrivers.Columns[4].HeaderText = "Date";
            dgvListDrivers.Columns[4].Width = 170;

            dgvListDrivers.Columns[5].HeaderText = "Active Licenses";
            dgvListDrivers.Columns[5].Width = 150;
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtbSearsh_TextChanged(object sender, EventArgs e)
        {
            clsDriver Driver = new clsDriver();
            string FilterColumn = "";

            switch (cbbFilterDrivers.Text)
            {
                case "Driver ID":
                    FilterColumn = "DriverID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }
 
            if (txtbSearsh.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllDrivers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListDrivers.Rows.Count.ToString();
                return;
            }

            else if (FilterColumn == "DriverID" || FilterColumn == "PersonID")
                _dtAllDrivers.DefaultView.RowFilter =
                    string.Format("[{0}] = {1} ", FilterColumn, txtbSearsh.Text.Trim());

            else
                _dtAllDrivers.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbSearsh.Text.Trim());


            lblRecords.Text = dgvListDrivers.Rows.Count.ToString();
        }
        private void txtbSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbFilterDrivers.Text == "Driver ID" || cbbFilterDrivers.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void cbbFilterDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsNone = (cbbFilterDrivers.Text == "None");
            txtbSearsh.Visible = !IsNone ;
            txtbSearsh.Clear();
        }
        private void showPersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID  = (int)dgvListDrivers.CurrentRow.Cells["PersonID"].Value;
            clsDriver driver = clsDriver.FindByPersonID(PersonID);
            Form frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListDrivers.CurrentRow.Cells["PersonID"].Value;

            Form frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }
    }
}

