using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness.Users;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.Update;

        public enum enApplicationType
        {
            NewDrivingLicense = 1,
            RenewDrivingLicense = 2,
            ReplacementForLostDrivingLicense = 3,
            ReplacementForDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicense = 5,
            NewInternationalLicense = 6,
            RetakeTest = 7
        }
       public enum enApplicationStatus{New = 1, Cancelled = 2, Completed = 3 }
        public enApplicationStatus ApplicationStatus { set; get; }  

        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public clsPerson PersonInfo { get; set; }
        public string ApplicantFullName
        {
            get
            {
                return clsPerson.Find(ApplicantPersonID).FullName;
            }

        }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public clsApplicationType ApplicationTypeInfo;
        public string StatusText
        {
            get
            {
                switch(ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                        default:
                        return "UnKnown";
                }
            }
        }
        public DateTime LastStatusDate { get; set; }
        public decimal AppPaidFees { get; set; } 
        public int CreatedByUserID { get; set; }
        public clsUser CreatedByUserInfo;

        public clsApplication()
        { 
            this.ApplicationID = -1;
            this.ApplicantPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;

            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.AppPaidFees = 0;
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }
        public clsApplication(int AppID, int AppPersonID, DateTime AppDate,
          int AppTypeID, DateTime LastSDate, decimal Fees, int UserID, enApplicationStatus AppStatus)
        {
            this.ApplicationID = AppID;
            this.ApplicantPersonID = AppPersonID;
            this.PersonInfo = clsPerson.Find(ApplicantPersonID);
            this.ApplicationDate = AppDate;
            this.ApplicationTypeID = AppTypeID;
            this.ApplicationTypeInfo = clsApplicationType.FindByAppTypeID(AppTypeID);
            this.LastStatusDate = LastSDate;
            this.AppPaidFees = Fees;
            this.CreatedByUserID = UserID;
            this.CreatedByUserInfo = clsUser.FindByUserID(CreatedByUserID);
            this.ApplicationStatus = AppStatus;
            Mode = enMode.Update;
        }
        public static DataTable GetAllAplications()
        {
            return clsApplicationData.GetAllAplications();
        }
        private bool _AddNewApp()
        {
            this.ApplicationID = clsApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate
                , (int) ApplicationTypeID, (byte)ApplicationStatus, LastStatusDate, AppPaidFees, CreatedByUserID);
            return (this.ApplicationID != -1);
        }
        private bool _UpdateApp()
        {
            return clsApplicationData.UpdateApplication
                (
                    this.ApplicationID,
                    this.ApplicantPersonID,
                    this.ApplicationDate,
                   (int) this.ApplicationTypeID,
                    (byte)this.ApplicationStatus,
                    this.LastStatusDate,
                    this.AppPaidFees,
                    this.CreatedByUserID
                );
        }
        public  bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApp())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdateApp();
            }
            return false;
        }
        public static clsApplication FindAppByID(int ID)
        {
            int AppPersonID = -1, AppTypeID =  (int)enApplicationType.NewDrivingLicense , UserID = -1;
            DateTime AppDate = DateTime.Today, LastDate = DateTime.Today;
            byte AppStatus = (int)enApplicationStatus.New;
            decimal Fees = 0;

            bool IsFound = clsApplicationData.GetApplicationByID(ID, ref AppPersonID, ref AppDate, ref AppTypeID, ref LastDate, ref Fees, ref UserID, ref AppStatus);

            if (IsFound)
            {
                return new clsApplication(ID, AppPersonID, AppDate, AppTypeID, LastDate, Fees, UserID,
                    (enApplicationStatus)AppStatus);
            }
            return null;
        }
        public static bool IsAppTypeIDExist(int ID)
        {
            return clsApplicationData.IsAppIDExist(ID);
        }
        public static bool DeletApp(int ID)
        {
            return clsApplicationData.DeleteApplication(ID);
        }

    }
}
