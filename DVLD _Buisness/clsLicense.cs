using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness;
using DVLD_Business;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsLicense
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }
        public enIssueReason _IssueReason { set; get; }

        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }

        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public clsDriver DriverInfo { set; get; }
        public clsDetain DetainedInfo
        {
            get
            {
                return clsDetain.FindByLicenseID(LicenseID);
            }
        }
        public bool IsDetained
        {
            get { return clsDetain.IsLicenseDetained(this.LicenseID); }
        }

        public string IssueReasonText
        {
            get
            {
                switch (_IssueReason)
                {
                    case enIssueReason.FirstTime:
                        return "First Time";

                    case enIssueReason.Renew:
                        return "Renew";

                    case enIssueReason.ReplacementForDamaged:
                        return "Replacement For Damaged";

                    case enIssueReason.ReplacementForLost:
                        return "Replacement For Lost";

                    default:
                        return "Unknown";
                }
            }

        }

        public enIssueReason IssueReasonValue
        {
            get { return _IssueReason; }
            set { _IssueReason = value; }
        }

        public int CreatedByUserID { get; set; }
        public clsLicenseClass LicenseClassInfo { get; set; }


        // Constructor: New License
        public clsLicense()
        {
            _Mode = enMode.AddNew;

            LicenseID = -1;
            this.ApplicationID = -1;
            this.DriverID = -1;
            this.LicenseClassID = -1;
            this.Notes = "";
            _IssueReason = enIssueReason.FirstTime;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.MinValue;
            PaidFees = 0;
            IsActive = true;
            CreatedByUserID = -1;
        }

        // Constructor: Existing License
        private clsLicense(int LicenseID, int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpirationDate,
                            string Notes, decimal PaidFees, bool IsActive, enIssueReason IssueReason, int CreatedByUserID)
        {
            _Mode = enMode.Update;

            this.LicenseID = LicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.LicenseClassID = LicenseClassID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.Notes = Notes;
            this.PaidFees = PaidFees;
            this.IsActive = IsActive;
            _IssueReason = IssueReason;
            this.CreatedByUserID = CreatedByUserID;
            DriverInfo = clsDriver.FindByDriverID(this.DriverID);
            this.LicenseClassInfo = clsLicenseClass.Find(this.LicenseClassID);
        }
        private bool _AddNewLicense()
        {

            this.LicenseID = clsLicensesData.AddNewLicense(this.ApplicationID, this.DriverID, this.LicenseClassID,
              this.IssueDate, this.ExpirationDate, this.Notes, this.PaidFees,
              this.IsActive, (byte)this.IssueReasonValue, this.CreatedByUserID);


            return (this.LicenseID != -1);
        }

        // Update Existing License
        private bool _UpdateLicense()
        {
            return clsLicensesData.UpdateLicense(LicenseID, ApplicationID, DriverID, LicenseClassID, IssueDate, ExpirationDate,
                                                    Notes, PaidFees, IsActive, (byte)_IssueReason, CreatedByUserID);
        }

        // Save
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicense())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;


                case enMode.Update:
                    return _UpdateLicense();
            }
            return false;
        }

        // Find License By ID
        public static clsLicense FindByLicenseID(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool IsFound = clsLicensesData.GetLicenseInfoByLicenseID(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass, ref IssueDate,
                                                                        ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (!IsFound)
                return null;

            return new clsLicense(
                LicenseID,
                ApplicationID,
                DriverID,
                LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (enIssueReason)IssueReason
,
                CreatedByUserID);
        }

        public static clsLicense FindByApplicationID(int ApplicationID)
        {
            int LicenseID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            byte IssueReason = 0;
            int CreatedByUserID = -1;

            bool IsFound = clsLicensesData.GetLicenseInfoByApplicationID(ApplicationID, ref LicenseID, ref DriverID, ref LicenseClass, ref IssueDate,
                                              ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);

            if (!IsFound)
                return null;

            return new clsLicense(
                LicenseID,
                ApplicationID,
                DriverID,
                LicenseClass,
                IssueDate,
                ExpirationDate,
                Notes,
                PaidFees,
                IsActive,
                (enIssueReason)IssueReason,
                CreatedByUserID);
        }

        // Get All Licenses
        public static DataTable GetAllLicenses()
        {
            return clsLicensesData.GetAllLicenses();
        }

        public static DataTable GetAllLicensesBasicInfoByPersonID(int PersonID)
        {
            return clsLicensesData.GetAllLicensesBasicInfoByPersonID(PersonID);
        }

        // Get Active License By Person And Class
        public static int GetActiveLicenseIDByPersonIDAndClassID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonIDAndClassID(PersonID, LicenseClassID);
        }

        public static int IsLicenseExistByPersonID(int PersonID, int LicenseClassID)
        {
            return clsLicensesData.GetActiveLicenseIDByPersonIDAndClassID(PersonID, LicenseClassID);
        }
        public clsLicense RenewLicense(string Notes, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;
            Application.ApplicationTypeID = (int)clsApplication.enApplicationType.RenewDrivingLicense;
            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.AppPaidFees = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.RenewDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

            NewLicense.ExpirationDate = DateTime.Now.AddYears(DefaultValidityLength);
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = this.LicenseClassInfo.ClassFees;
            NewLicense.IsActive = true;
            NewLicense.IssueReasonValue = clsLicense.enIssueReason.Renew;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())  
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();

            return NewLicense;
        


        }

        public clsLicense Replacement(enIssueReason IssueReason, int CreatedByUserID)
        {

            //First Create Applicaiton 
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = (IssueReason == enIssueReason.ReplacementForDamaged) ?
               (int)clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense :
               (int)clsApplication.enApplicationType.ReplacementForLostDrivingLicense;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.AppPaidFees = clsApplicationType.FindByAppTypeID(Application.ApplicationTypeID).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                return null;
            }

            clsLicense NewLicense = new clsLicense();

            NewLicense.ApplicationID = Application.ApplicationID;
            NewLicense.DriverID = this.DriverID;
            NewLicense.LicenseClassID = this.LicenseClassID;
            NewLicense.IssueDate = DateTime.Now;
            int DefaultValidityLength = this.LicenseClassInfo.DefaultValidityLength;

            NewLicense.ExpirationDate = this.ExpirationDate;
            NewLicense.Notes = Notes;
            NewLicense.PaidFees = 0;
            NewLicense.IsActive = true;
            NewLicense.IssueReasonValue = IssueReason;
            NewLicense.CreatedByUserID = CreatedByUserID;


            if (!NewLicense.Save())  
            {
                return null;
            }

            //we need to deactivate the old License.
            DeactivateCurrentLicense();
            return NewLicense;
        }
        public int Detain( decimal FineFees, int CreatedByUserID)
        {   
            

            clsDetain detainedLicense = new clsDetain();
            detainedLicense.LicenseID = this.LicenseID;
            detainedLicense.DetainDate = DateTime.Now;
            detainedLicense.FineFees = Convert.ToDecimal(FineFees);
            detainedLicense.CreatedByUserID = CreatedByUserID;

            if (!detainedLicense.Save())
            {

                return -1;
            }

            return detainedLicense.DetainID;

        }

        public bool ReleaseLicenses( int ReleasedByUserID, ref int ApplicationID)
        {

            // Second: Create Release Application
            clsApplication Application = new clsApplication();

            Application.ApplicantPersonID = this.DriverInfo.PersonID;
            Application.ApplicationDate = DateTime.Now;

            Application.ApplicationTypeID = 
               (int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense ;

            Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
            Application.LastStatusDate = DateTime.Now;
            Application.AppPaidFees = clsApplicationType.FindByAppTypeID((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicense).ApplicationFees;
            Application.CreatedByUserID = CreatedByUserID;

            if (!Application.Save())
            {
                ApplicationID = -1;
                return false;
            }
                ApplicationID = Application.ApplicationID;
             return this.DetainedInfo.ReleaseDatainedLicense(ReleasedByUserID, Application.ApplicationID);
        }

        public bool IsLicenseExpired()
        {
            return (this.ExpirationDate < DateTime.Now);
        }
        public bool DeactivateCurrentLicense()
        {
            return (clsLicensesData.DeactivateLicense(this.LicenseID));
        }

        public static bool ActivateLicense(int LicenseID)
        {
            return clsLicensesData.ActivateLicense(LicenseID);
        }
    }
}

