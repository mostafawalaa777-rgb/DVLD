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

namespace DVLD_Presentation.Applications
{
    public partial class frmUpdateApplicationType : Form
    {
        clsApplicationType _ApplicationTypes;

      
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _AppTypeID = -1;
        public frmUpdateApplicationType(int AppTypeID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _AppTypeID = AppTypeID;

        }
        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
            lblApplicationID.Text = _AppTypeID.ToString();
            _ApplicationTypes = clsApplicationType.FindByAppTypeID(_AppTypeID);

            if (_ApplicationTypes != null)
            {
                txtbApplicationTitle.Text = _ApplicationTypes.ApplicationTypeTitle;
                txtbFees.Text = _ApplicationTypes.ApplicationFees.ToString();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _ApplicationTypes.ApplicationTypeTitle = txtbApplicationTitle.Text.Trim();
            _ApplicationTypes.ApplicationFees = Convert.ToDecimal(txtbFees.Text.Trim());

            if(_ApplicationTypes.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }      
        private void txtbApplicationTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbApplicationTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbApplicationTitle, "Title cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbApplicationTitle, null);
            }
        }
        private void txtbFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbFees, "Title cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbFees, null);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
