       
using System;
using System.Data;
using DVLD_Buisness;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsInternationalLicense
    {
        public enum enMode
        {
            AddNew = 0,
            Update = 1
        }
        public enMode Mode = enMode.AddNew;

        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }
        public clsLicenseClass LicenseClass { get; set; }   
        public clsDriver Driver;

        // Private Constructor
        private clsInternationalLicense(
            int InternationalLicenseID,
            int ApplicationID,
            int DriverID,
            int IssuedUsingLocalLicenseID,
            DateTime IssueDate,
            DateTime ExpirationDate,
            bool IsActive,
            int CreatedByUserID,
            enMode Mode)
        {
            this.InternationalLicenseID = InternationalLicenseID;
            this.ApplicationID = ApplicationID;
            this.DriverID = DriverID;
            this.IssuedUsingLocalLicenseID = IssuedUsingLocalLicenseID;
            this.IssueDate = IssueDate;
            this.ExpirationDate = ExpirationDate;
            this.IsActive = IsActive;
            this.CreatedByUserID = CreatedByUserID;

            this.Mode = Mode;
        }

        // Add New Constructor
        public clsInternationalLicense()
        {
            InternationalLicenseID = -1;
            ApplicationID = -1;
            DriverID = -1;
            IssuedUsingLocalLicenseID = -1;
            IssueDate = DateTime.Now;
            ExpirationDate = DateTime.Now;
            IsActive = true;
            CreatedByUserID = -1;

            Mode = enMode.AddNew;
        }

        // Find By InternationalLicenseID
        public static clsInternationalLicense FindByInternationalLicenseID(int InternationalLicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;

            bool IsFound =
                clsInternationalLicenseData.GetInternationalLicenseInfoByID(
                    InternationalLicenseID,
                    ref ApplicationID,
                    ref DriverID,
                    ref IssuedUsingLocalLicenseID,
                    ref IssueDate,
                    ref ExpirationDate,
                    ref IsActive,
                    ref CreatedByUserID);

            if (IsFound)
            {
                return new clsInternationalLicense(
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID,
                    enMode.Update);
            }

            return null;
        }
        // Find By ApplicationID
        public static clsInternationalLicense FindByApplicationID(int ApplicationID)
        {
            int InternationalLicenseID = -1;
            int DriverID = -1;
            int IssuedUsingLocalLicenseID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;

            bool IsFound =
                clsInternationalLicenseData.GetInternationalLicenseInfoByApplicationID(
                    ApplicationID,
                    ref InternationalLicenseID,
                    ref DriverID,
                    ref IssuedUsingLocalLicenseID,
                    ref IssueDate,
                    ref ExpirationDate,
                    ref IsActive,
                    ref CreatedByUserID);

            if (IsFound)
            {
                return new clsInternationalLicense(
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    IssuedUsingLocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID,
                    enMode.Update);
            }

            return null;
        }
        // Find By LocalLicenseID
        public static clsInternationalLicense FindByLocalLicenseID(int LocalLicenseID)
        {
            int InternationalLicenseID = -1;
            int ApplicationID = -1;
            int DriverID = -1;
            DateTime IssueDate = DateTime.Now;
            DateTime ExpirationDate = DateTime.Now;
            bool IsActive = false;
            int CreatedByUserID = -1;

            bool IsFound =
                clsInternationalLicenseData.GetInternationalLicenseInfoByLocalLicenseID(
                    LocalLicenseID,
                    ref InternationalLicenseID,
                    ref ApplicationID,
                    ref DriverID,
                    ref IssueDate,
                    ref ExpirationDate,
                    ref IsActive,
                    ref CreatedByUserID);

            if (IsFound)
            {
                return new clsInternationalLicense(
                    InternationalLicenseID,
                    ApplicationID,
                    DriverID,
                    LocalLicenseID,
                    IssueDate,
                    ExpirationDate,
                    IsActive,
                    CreatedByUserID,
                    enMode.Update);
            }

            return null;
        }
        // Add New International License
        private bool _AddNewInternationalLicense()
        {
            this.InternationalLicenseID =
                clsInternationalLicenseData.AddNewInternationalLicense(
                    this.ApplicationID,
                    this.DriverID,
                    this.IssuedUsingLocalLicenseID,
                    this.IssueDate,
                    this.ExpirationDate,
                    this.IsActive,
                    this.CreatedByUserID);

            return (this.InternationalLicenseID != -1);
        }
        // Update International License
        private bool _UpdateInternationalLicense()
        {
            return clsInternationalLicenseData.UpdateInternationalLicense(
                this.InternationalLicenseID,
                this.ApplicationID,
                this.DriverID,
                this.IssuedUsingLocalLicenseID,
                this.IssueDate,
                this.ExpirationDate,
                this.IsActive,
                this.CreatedByUserID);
        }

        // Save
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewInternationalLicense())
                    {
                        Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateInternationalLicense();
            }

            return false;
        }

        // Get All International Licenses
        public static DataTable GetAllInternationalLicenses()
        {
            return clsInternationalLicenseData.GetAllInternationalLicenses();
        }

        public static DataTable GetAllBaseInternationalLicensesByPersonID(int PersonID)
        {
            return clsInternationalLicenseData.GetAllBaseInternationalLicensesByPersonID(PersonID);
        }
        
        // Delete International License
        public static bool DeleteInternationalLicense(int InternationalLicenseID)
        {
            return clsInternationalLicenseData.DeleteInternationalLicense(
                InternationalLicenseID);
        }


        // Check If International License Exists
        public static bool IsInternationalLicenseExist(int ApplicationID)
        {
            return clsInternationalLicenseData.IsInternationalLicenseExist(ApplicationID);
        }

        public static int GetActiveInternationalLicenseIDByDriverID(int DriverID)
        {
            return clsInternationalLicenseData.GetActiveInternationalLicenseByDriverID(DriverID);
        }
    }
}

