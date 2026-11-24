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
using DVLD_Presentation.People.Controls;
using DVLD_Presentation.TestType;
using DVLD_Presentation.Users;

namespace DVLD_Presentation.Applications
{
    
    public partial class frmLocalDrivingLicenseApplicationInfo : Form
    {
        private int _ID = -1;
        public frmLocalDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
                
        }
        public frmLocalDrivingLicenseApplicationInfo(int ID)
        {
            InitializeComponent();
            ctrlAppInfo1.LoadApplicationInfo(ID);
        }

        private void ViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =  clsLocalDrivingLicenseApplication.FindByApplicationID(_ID);

            int PersonID = LocalDrivingLicenseApplication.ApplicantPersonID;

            Form frm = new People.frmShowPersonInfo(PersonID);     
            frm.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
    }
}
