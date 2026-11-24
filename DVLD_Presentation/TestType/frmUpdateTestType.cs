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
using DVLD_Presentation.People;

namespace DVLD_Presentation.TestType
{
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private clsTestType _TestType;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;


        public frmUpdateTestType(clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _TestTypeID = TestTypeID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbTestTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbTestTitle.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbTestTitle, "Title cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbTestTitle, null);
            }
        }

        private void txtbDiscription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtbDiscription.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbDiscription, "Title cannot be empty!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtbDiscription, null);
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

            if (!clsValidatoin.IsNumber(txtbFees.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtbFees, "Invalid Number.");
            }
            else
            {
                errorProvider1.SetError(txtbFees, null);
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                  "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            _TestType.TestTypeTitle = txtbTestTitle.Text.Trim();
            _TestType.TestTypeDescription = txtbDiscription.Text.Trim();
            _TestType.TestTypeFees = Convert.ToSingle(txtbFees.Text.Trim());

            if ( _TestType.Save())
           {
               
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            this.Close();
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.FindByTestTypeID(_TestTypeID);

            if( _TestType != null ) 
            {
                lblTestTypeID.Text = ((int)_TestTypeID).ToString();   
                txtbTestTitle.Text = _TestType.TestTypeTitle;
                txtbDiscription.Text = _TestType.TestTypeDescription;
                txtbFees.Text = _TestType.TestTypeFees.ToString();
            }
            else

            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
