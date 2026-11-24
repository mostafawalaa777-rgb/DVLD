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
using DVLD_Buisness;

namespace DVLD_Presentation.TestType
{
    public partial class frmListTestType : Form
    {
         private static DataTable _dtAllTests;

        public frmListTestType()
        {
            InitializeComponent();
         //   this.Load += frmListTestType_Load;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmListTestType_Load(object sender, EventArgs e)
        {
            _dtAllTests = clsTestType.GetAllTestTypes();
            dgvListTestsTypes.DataSource = _dtAllTests;

            lblRecords.Text = dgvListTestsTypes.Rows.Count.ToString();


            if (dgvListTestsTypes.Rows.Count > 0)
            {
               dgvListTestsTypes.Columns[0].HeaderText = "ID";
               dgvListTestsTypes.Columns[0].Width = 100;

               dgvListTestsTypes.Columns[1].HeaderText = "Title";
               dgvListTestsTypes.Columns[1].Width = 180;


                dgvListTestsTypes.Columns[2].HeaderText = "Description";
                dgvListTestsTypes.Columns[2].Width = 500;

                dgvListTestsTypes.Columns[3].HeaderText = "Fees";
                dgvListTestsTypes.Columns[3].Width = 100;

            }

        }
        private void dgvListTestsTypes_DoubleClick(object sender, EventArgs e)
        {

            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dgvListTestsTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestType_Load(null, null);
        }
        private void edetTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {       
            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dgvListTestsTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListTestType_Load(null, null);
        }
    }
}
