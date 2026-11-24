using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness;
using DVLD_Buisness.Users;
using DVLD_Presentation.Global_Classes;

namespace DVLD_Presentation.Applications
{
    public partial class frmNewLocalDrivingLicenseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;
        private  clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        private int _LocalDrivingLicenseApplicationID = -1;                   
        public frmNewLocalDrivingLicenseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;   
        }  
        public frmNewLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillLicenseClassesInComoboBox()
        {
            DataTable LicenseClasesTable = clsLicenseClass.GetAllLicenseClasses();
            cbLicenseClass.DataSource = LicenseClasesTable;
            cbLicenseClass.DisplayMember = "ClassName";
            cbLicenseClass.ValueMember = "LicenseClassID";
        }
        private void _ResetDefualtValues()
        {
            _FillLicenseClassesInComoboBox();

            if (_Mode == enMode.AddNew)
            {
                this.Text = "New Local Driving License Application";
                lblTitle.Text = "New Local Driving License Application";

                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                ctrlPersonCardWithFilter1.FilterFocus();
                tcApplicationInfo.Enabled = false;

               cbLicenseClass.SelectedIndex = 2;

                lblAppFees.Text = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationFees.ToString();
                lblAppDate.Text   = DateTime.Now.ToShortDateString();
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            }

            else
            {
                this.Text = "Update Local Driving License Application";
                lblTitle.Text = "Update Local Driving License Application";
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
            }
        }
        private void LoadData()
        {
            ctrlPersonCardWithFilter1.FilterEnabled = false; 
            _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            if(_LocalDrivingLicenseApplication == null )
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, " Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }
            lblDLAppID.Text = _LocalDrivingLicenseApplicationID.ToString(); 
            lblAppDate.Text =  _LocalDrivingLicenseApplication.ApplicationDate.ToLongDateString();
            cbLicenseClass.SelectedValue = _LocalDrivingLicenseApplication.LicenseClassID;
            lblAppFees.Text = _LocalDrivingLicenseApplication.AppPaidFees.ToString();
            lblCreatedBy.Text =clsUser.FindByUserID( _LocalDrivingLicenseApplication.CreatedByUserID).UserName;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tcApplicationInfo"];
                return;
            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tcApplicationInfo.Enabled = true;
                tcApplication.SelectedTab = tcApplication.TabPages["tcApplicationInfo"];
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
               
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = clsLicenseClass.Find(cbLicenseClass.Text).LicenseClassID;  

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, " Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            _LocalDrivingLicenseApplication.ApplicantPersonID =
                 ctrlPersonCardWithFilter1.PersonID;

            _LocalDrivingLicenseApplication.LicenseClassID = 
                Convert.ToInt32( cbLicenseClass.SelectedValue);

            _LocalDrivingLicenseApplication.ApplicationDate =
                Convert.ToDateTime( lblAppDate.Text);  

            _LocalDrivingLicenseApplication.AppPaidFees =
                Convert.ToDecimal( lblAppFees.Text);  

            _LocalDrivingLicenseApplication.CreatedByUserID = 
                clsGlobal.CurrentUser.UserID; 

            _LocalDrivingLicenseApplication.ApplicationStatus = 
                clsApplication.enApplicationStatus.New;

            _LocalDrivingLicenseApplication.ApplicationTypeID =
               (int)clsApplication.enApplicationType.NewDrivingLicense;

            if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID) != -1)
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalDrivingLicenseApplication.DoesPersonHaveActiveApplication(_LocalDrivingLicenseApplication.ApplicantPersonID, _LocalDrivingLicenseApplication.LicenseClassID))
            {
                MessageBox.Show(@"Choose Another license class, the selected person Already have an active application for the selected class with id " + _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID ,"Not Allawed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            

            
            int age = _LocalDrivingLicenseApplication.Age();
            if (age < 18)
            {
                MessageBox.Show("Applicant must be at least 18 years old.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            
                return;
            }
        
            if (_LocalDrivingLicenseApplication.Save())
            {
                lblDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

               
                _Mode = enMode.Update;

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void frmNewLocalDrivingLicenseApplication_Load(object sender, EventArgs e)
        {  
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
                LoadData();
        }
        private void frmNewLocalDrivingLicenseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }

   
}

