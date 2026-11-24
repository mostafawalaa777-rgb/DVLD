using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Presentation.Global_Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Presentation.Users
{
    public partial class frmLogin : Form
    {
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        clsUser _User;
        clsPerson _Person;
        private int _UserID;
        public string UserName
        {
            get { return txtUserName.Text; }
            set { txtUserName.Text = value; }
        }
        public string Password
        {
            get { return txtPassword.Text; }
            set { txtPassword.Text = value; }
        }
        public frmLogin()
        {
            InitializeComponent();
            _PrepareIcons();
        }
        private void _PrepareIcons()
        {

            Image smallImg2 = new Bitmap(Properties.Resources.key_person, new Size(32, 32));

            btnLogin.Image = smallImg2;
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        { 
            if (_LoginToSystem())
            {
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.Username = txtUserName.Text ;
                Properties.Settings.Default.RememberMe = chkbRememberMe.Checked;
                if (chkbRememberMe.Checked)
                {
                    Properties.Settings.Default.Save();
                }
                else 
                {
                    Properties.Settings.Default.Password = "";
                    Properties.Settings.Default.Username = "";
                    Properties.Settings.Default.Save();
                    txtPassword.Text = "";
                    txtUserName.Text = "";
                }
                clsGlobal.CurrentUser = _User;
                
                Form frm = new frmMain(this);
                frm.ShowDialog();   
            }
        }
        private bool _LoginToSystem()
        {  
            if (!string.IsNullOrEmpty(txtPassword.Text.Trim()) && !string.IsNullOrEmpty(txtUserName.Text.Trim()) )
            {
                if (!clsUser.IsUserExist(txtPassword.Text, txtUserName.Text))
                {
                    MessageBox.Show("Invalide UserName/password", "Wrong Credintails", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    _User = clsUser.FindByUserName(txtUserName.Text);
                    if (!_User.IsActive)
                    {
                        txtUserName.Focus();
                        MessageBox.Show("Your account is deActivated, please contact your admine", "Wrong Credintails", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    clsGlobal.CurrentUser = _User;
                }
            }     
            else
            {
                MessageBox.Show("This field is required!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
          
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            chkbRememberMe.Checked = Properties.Settings.Default.RememberMe;
            if (chkbRememberMe.Checked)
            {
                txtPassword.Text = Properties.Settings.Default.Password;
                txtUserName.Text = Properties.Settings.Default.Username;
            }
            else
            {
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Username = "";
                Properties.Settings.Default.Save();
            }
        }
    }
} 


      
    
