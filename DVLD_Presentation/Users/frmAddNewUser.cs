using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Presentation.People;
using DVLD_Presentation.People.Controls;
using DVLD_Presentation.Users.Controls;

namespace DVLD_Presentation.Users
{
    public partial class frmAddUpdateNewUser : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private int _UserID = -1;

        clsUser _User;

        public frmAddUpdateNewUser()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateNewUser(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;
        }
        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New User ";
                this.Text = "Add New User ";
                _User = new clsUser();
                tcLoginInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                lblMode.Text = "Update User ";
                this.Text = "Update User ";
                tcLoginInfo.Enabled = true;
                btnSave.Enabled = true ;
            }
            txtPassword.Text = "[???]";
            txtUserName.Text = "[???]";
            txtConfirmPassword.Text = "[???]";
            chkbIsActive.Checked = true;
        }   
        private void LoadData()
        {

            _User = clsUser.FindByUserID(_UserID);

            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblUserID.Text = _UserID.ToString();
            txtPassword.Text = _User.PasswordHash;
            txtConfirmPassword.Text = _User.PasswordHash;
            txtUserName.Text = _User.UserName;
            chkbIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if(_Mode == enMode.Update)
                LoadData();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNext_Click_1(object sender, EventArgs e)
        {
            {
            if (_Mode == enMode.Update)
                btnSave.Enabled = true;
                tcLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tcLoginInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsUser.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();

                }
                else
                {
                    btnSave.Enabled = true;
                    tcLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tcLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }
        }      
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_User == null )
            {
                MessageBox.Show("there is an error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkbIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                _Mode = enMode.Update;
                lblMode.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel= true;
                errorProvider1.SetError(txtUserName, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
            }
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "This field is required!");
            }
            else if (txtConfirmPassword.Text != txtPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password confirm does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

     
    }
}
