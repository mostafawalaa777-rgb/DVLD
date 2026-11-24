using System;

using System.Data;

using DVLD_Buisness;
using DVLD_Business;
using DVLD_DataAccess;
namespace DVLD_Buisness
{
    public class clsLocalDrivingLicenseApplication : clsApplication
    {
        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementForDamaged = 3, ReplacementForLost = 4 }
        public enIssueReason _IssueReason;

        public enum enMode { AddNew = 0, Update = 1 };
        private enMode _Mode;

        public int LocalDrivingLicenseApplicationID { get; set; }
        public int PassedTests { get; set; }
        public int LicenseClassID { get; set; }
        public clsLicense License { get;  set; }

        public clsLicenseClass LicenseClassInfo;
       
        public clsDriver Driver;
        public string PersonFullName
        {
            get
            {
                return base.PersonInfo.FullName;
            }
        }
        public int Age()
        {
            clsPerson Person = clsPerson.Find(this.ApplicantPersonID);

            if(Person == null)
            {

            }
            int age = DateTime.Today.Year - Person.DateOfBirth.Year;
            if (Person.DateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
        public clsLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationID = -1;
            this.LicenseClassID = -1;
            _Mode = enMode.AddNew;
        }
        public clsLocalDrivingLicenseApplication(int LDLAppID, int ApplicationID, int LicenseClassID, int AppPersonID, DateTime AppDate,
          int AppTypeID, DateTime LastSDate, decimal Fees, int UserID, enApplicationStatus AppStatus) : base(ApplicationID, AppPersonID, AppDate, AppTypeID,
           LastSDate, Fees, UserID, AppStatus)
        {
            this.LocalDrivingLicenseApplicationID = LDLAppID;
            this.ApplicationID = ApplicationID;
            this.ApplicantPersonID = AppPersonID;
            this.ApplicationDate = AppDate;
            this.ApplicationTypeID = (int)AppTypeID;
            this.LastStatusDate = LastSDate;
            this.AppPaidFees = Fees;
            this.CreatedByUserID = UserID;
            this.ApplicationStatus = AppStatus;
            this.LicenseClassID = LicenseClassID;
            this.LicenseClassInfo = clsLicenseClass.Find(LicenseClassID);
            _Mode = enMode.Update;
        }

        public static DataTable GetAllLocalDrivingLicenseApps()
        {
            return clsLocalDrivingLicenseApplicationData.GetAllLocalDrivingLicenseApplications();
        }
        private bool _AddNewLocalDrivingLicenseApps()
        {
            if (base.Save())
            {
                this.LocalDrivingLicenseApplicationID = clsLocalDrivingLicenseApplicationData.AddNewLocalDrivingLicenseApplication(this.ApplicationID, LicenseClassID);
            }
            return (this.LocalDrivingLicenseApplicationID != -1);
        }
        private bool _UpdateLocalDrivingLicenseApps()
        {
            if (base.Save())
            {
                return clsLocalDrivingLicenseApplicationData.UpdateLocalDrivingLicenseApplication(this.LocalDrivingLicenseApplicationID, this.ApplicationID, this.LicenseClassID);
            }
            return false;
        }
        public new bool Save()
        {

            base.Mode = (clsApplication.enMode)Mode;
            if (!base.Save())
            {
                return false;
            }

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApps())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    return false;
                case enMode.Update:

                    return _UpdateLocalDrivingLicenseApps();
            }
            return false;
        }
        public static clsLocalDrivingLicenseApplication FindByLocalDrivingAppLicenseID(int LocalDrivingAppLicenseID)
        {
            int ApplicationID = -1, LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByID(LocalDrivingAppLicenseID, ref ApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication App = clsApplication.FindAppByID(ApplicationID);
                if (App != null)
                {
                    return new clsLocalDrivingLicenseApplication(LocalDrivingAppLicenseID, ApplicationID, LicenseClassID, App.ApplicantPersonID,
                                                                   App.ApplicationDate, (int)App.ApplicationTypeID, App.LastStatusDate,
                                                                   App.AppPaidFees, App.CreatedByUserID, App.ApplicationStatus);
                }
            }
            return null;
        }
        public static clsLocalDrivingLicenseApplication FindByApplicationID(int ApplicationID)
        {

            int LocalDrivingLicenseApplicationID = -1, LicenseClassID = -1;
            bool IsFound = clsLocalDrivingLicenseApplicationData.GetLocalDrivingLicenseApplicationInfoByApplicationID(ApplicationID, ref LocalDrivingLicenseApplicationID, ref LicenseClassID);

            if (IsFound)
            {
                clsApplication App = clsApplication.FindAppByID(ApplicationID);
                if (App != null)
                {
                    return new clsLocalDrivingLicenseApplication(LocalDrivingLicenseApplicationID, ApplicationID, LicenseClassID, App.ApplicantPersonID,
                                                                   App.ApplicationDate, (int)App.ApplicationTypeID, App.LastStatusDate,
                                                                   App.AppPaidFees, App.CreatedByUserID, App.ApplicationStatus);
                }
            }
            return null;
        }
        public static bool DeletLocalDrivingLicenseApp(int ID)
        {
            return clsLocalDrivingLicenseApplicationData.DeleteLocalDrivingLicenseApplication(ID);
        }
        public static bool DoesPersonHaveActiveApplication(int PersonID, int LicenseClassID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesPersonHaveActiveApplication(PersonID, LicenseClassID); ;
        }
        public static int GetPassedTestCount(int LocalDrivingAppLicenseID)
        {
            return clsLocalDrivingLicenseApplicationData.GetPassedTestCount(LocalDrivingAppLicenseID);
        }
        public clsTests GetLastTestPerTestType(clsTestType.enTestType TestTypeID)
        {
            return clsTests.FindLastTestPerPersonAndLicenseClass(this.ApplicantPersonID, this.LicenseClassID, TestTypeID);
        }

        public static bool DoesThereAnActiveScheduledTest(int LocalDrivingAppLicenseID, int TestTyppeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesThereAnActiveScheduledTest(LocalDrivingAppLicenseID, TestTyppeID);
        }
        public static bool DoesAttendTestType(int LocalDrivingAppLicenseID, int TestTyppeID)
        {
            return clsLocalDrivingLicenseApplicationData.DoesAttendTestType(LocalDrivingAppLicenseID, TestTyppeID);
        }
        public int IssueLicense(string Notes, int CreatedByUserID)
        {
            int DriverID = -1;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByApplicationID(this.ApplicationID);
            clsDriver Driver = clsDriver.FindByPersonID(this.ApplicantPersonID);
            if (Driver == null)
            {
                Driver = new clsDriver();

                Driver.PersonID = this.ApplicantPersonID;
                Driver.CreatedByUserID = CreatedByUserID;

                if (Driver.Save())
                    DriverID = Driver.DriverID;
                else
                    return  -1;

            }
            else 
                 DriverID = Driver.DriverID; 

            if (License == null)
            {
                License = new clsLicense();
                License.ApplicationID = this.ApplicationID;
                License.DriverID = DriverID;
                License.LicenseClassID = this.LicenseClassID;
                License.Notes = Notes;
                License.PaidFees = this.LicenseClassInfo.ClassFees;
                License.IssueReasonValue = clsLicense.enIssueReason.FirstTime;
                License.CreatedByUserID = CreatedByUserID;
                License.IssueDate = DateTime.Now;
                License.ExpirationDate = License.IssueDate.AddYears(this.LicenseClassInfo.DefaultValidityLength);
                License.IsActive = true;
            }
            if (License.Save())
            {
                this.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                this.Save();
                return License.LicenseID;
            }
            else
                return -1;
        }  
    }
}

