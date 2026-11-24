using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness.Users;
using DVLD_Presentation.Global_Classes;

namespace DVLD_Presentation.Users
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvListUsers.DataSource = _dtAllUsers;

            cbbFilterUsers.SelectedIndex = 0;
            lblRecords.Text = dgvListUsers.Rows.Count.ToString();

            if (dgvListUsers.Rows.Count > 0)
            {
                dgvListUsers.Columns[0].HeaderText = "User ID";
                dgvListUsers.Columns[0].Width = 110;

                dgvListUsers.Columns[1].HeaderText = "Person ID";
                dgvListUsers.Columns[1].Width = 120;

                dgvListUsers.Columns[2].HeaderText = "FullName";
                dgvListUsers.Columns[2].Width = 350;

                dgvListUsers.Columns[3].HeaderText = "User Name";
                dgvListUsers.Columns[3].Width = 120;

                dgvListUsers.Columns[4].HeaderText = "Is Active";
                dgvListUsers.Columns[4].Width = 120;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtbSearsh_TextChanged(object sender, EventArgs e)
        {
            clsUser user = new clsUser();
            string FilterColumn = "";

            switch (cbbFilterUsers.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "User Name":
                    FilterColumn = "UserName";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";

                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (FilterColumn == "IsActive")
            {
                txtbSearsh.Visible = false;
                cbIsActive.Visible = true;
            }

            else if (txtbSearsh.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecords.Text = dgvListUsers.Rows.Count.ToString();
                return;
            }

            else if (FilterColumn == "UserID" || FilterColumn == "PersonID")
                _dtAllUsers.DefaultView.RowFilter =
                    string.Format("[{0}] = {1} ", FilterColumn, txtbSearsh.Text.Trim());

            else
                _dtAllUsers.DefaultView.RowFilter =
                    string.Format("[{0}] LIKE '%{1}%'", FilterColumn, txtbSearsh.Text.Trim());
            

            lblRecords.Text = dgvListUsers.Rows.Count.ToString(); 
        }
        private void cbbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool IsNone = (cbbFilterUsers.Text == "None");
            bool IsIsActive = (cbbFilterUsers.Text == "Is Active");

            txtbSearsh.Visible = !IsNone && !IsIsActive;

            cbIsActive.Visible = IsIsActive;
            cbIsActive.SelectedIndex = 0;
            txtbSearsh.Clear();
        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch (cbIsActive.Text)
            {
                case "All":
                    _dtAllUsers.DefaultView.RowFilter ="";
                    break;

                case "Yes":
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = 1";
                    break;

                case "No":
                    _dtAllUsers.DefaultView.RowFilter = "[IsActive] = 0";
                    break;
            }

            lblRecords.Text = dgvListUsers.Rows.Count.ToString();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmUserInfo((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateNewUser((int)dgvListUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

            frmListUsers_Load(null, null);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateNewUser((int)dgvListUsers.CurrentRow.Cells["UserID"].Value);
            frm.ShowDialog();
            frmListUsers_Load(null, null);
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form frm = new frmAddUpdateNewUser();
            frm.ShowDialog();
            frmListUsers_Load(null, null);
        }
        private void txtbSearsh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbbFilterUsers.Text == "User ID" || cbbFilterUsers.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        private void dgvListUsers_DoubleClick(object sender, EventArgs e)
        {
            int UserID = ((int)dgvListUsers.CurrentRow.Cells[0].Value);
            Form frm = new frmUserInfo(UserID);
            frm.ShowDialog();
        }  
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = ((int)dgvListUsers.CurrentRow.Cells[0].Value);

            if (UserID == clsGlobal.CurrentUser.UserID)
            {
                MessageBox.Show("You cannot delet your own account while you are logged in to the system!", "Action Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           else if ( MessageBox.Show("Are you sure you want to delete User [" + dgvListUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
           {
                if (clsUser.DeletUser(UserID))
                {
                    MessageBox.Show("User Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("User was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
            frmListUsers_Load(null, null);
        }
        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Form frm = new frmChangePassword((int)dgvListUsers.CurrentRow.Cells["UserID"].Value);
             frm.ShowDialog();
        }
    }
}
