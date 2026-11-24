using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD_Buisness;
namespace DVLD_Presentation.License
{
    public partial class ctrlLicenseInfoWithFilter : UserControl
    {
        public event Action<int> OnLicenseSelected;
        private int _LicenseID = -1;
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
               gbFilter.Enabled = _FilterEnabled;
            }
        }
        public int LicenseID
        {
            get { return Convert.ToInt32(txtFilterValue.Text); }
        }
        public clsLicense SelectedLicenseInfo
        { get { return ctrlLicense_Info1.SelectedLicenseInfo; } }
        public void txtLicenseIDFocus()
        {
            txtFilterValue.Focus();
        }
        public ctrlLicenseInfoWithFilter()
        {
            InitializeComponent(); 
        } 
        public void LoadLicenseInfo(int LicenseID)
        {
            txtFilterValue.Text = LicenseID.ToString();
            ctrlLicense_Info1.LoadLicenseInfo(LicenseID);
            LicenseID = ctrlLicense_Info1.LicenseID;    
            if(OnLicenseSelected != null && FilterEnabled)
            {
                OnLicenseSelected(LicenseID);
            }
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFilterValue.Focus();
                return;
            }
            if (!int.TryParse(txtFilterValue.Text, out _LicenseID))
            {
                MessageBox.Show("Invalid License ID! Please enter a valid number.", "Invalid Input",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                txtFilterValue.Focus();
                txtFilterValue.SelectAll();
                return;
            }
                LoadLicenseInfo(LicenseID);
                OnLicenseSelected?.Invoke(LicenseID);
        }
        private void ctrlLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtFilterValue, null);
            }
        }
        private bool IsValidFilterValue()
        {
            if (string.IsNullOrWhiteSpace(txtFilterValue.Text))
            {
                errorProvider1.SetError(txtFilterValue, "This field is required!");
                txtFilterValue.Focus();
                return false;
            }

            errorProvider1.SetError(txtFilterValue, "");
            return true;
        }
    }
}
