using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Presentation.Users;

namespace DVLD_Presentation.Applications
{
    public partial class frmListApplicationsTypes : Form
    {
        private static DataTable _dtAllApplicationTypes;
        public frmListApplicationsTypes()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListApplicationsTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvListAppsTypes.DataSource = _dtAllApplicationTypes;
            lblRecords.Text = dgvListAppsTypes.Rows.Count.ToString();

            if (dgvListAppsTypes.Rows.Count > 0)
            {
                dgvListAppsTypes.Columns[0].HeaderText = "ID";
                dgvListAppsTypes.Columns[0].Width = 110;

                dgvListAppsTypes.Columns[1].HeaderText = "Title";
                dgvListAppsTypes.Columns[1].Width = 500;

                dgvListAppsTypes.Columns[2].HeaderText = "Fees";
                dgvListAppsTypes.Columns[2].Width = 120;
            }    
        }
        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppTypeID = (int)dgvListAppsTypes.CurrentRow.Cells["ApplicationTypeID"].Value;

            frmUpdateApplicationType frm = new frmUpdateApplicationType(AppTypeID);
            frm.ShowDialog();
            frmListApplicationsTypes_Load(null, null);
        }
        private void dgvListAppsTypes_DoubleClick(object sender, EventArgs e)
        {
            int AppTypeID = (int)dgvListAppsTypes.CurrentRow.Cells["ApplicationTypeID"].Value;

            frmUpdateApplicationType frm = new frmUpdateApplicationType(AppTypeID);
            frm.ShowDialog();
        }
    }
}
