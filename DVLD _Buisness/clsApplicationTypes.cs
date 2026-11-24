using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness.Users;
using DVLD_DataAccess;
using DVLD_DataAccess.Users;

namespace DVLD_Buisness
{
    public class clsApplicationType
    {
        enum enMode { AddNew = 0, Update = 1 }
        enMode _Mode = enMode.Update;
        public int ApplicationTypeID { get; set; }
        public string ApplicationTypeTitle { get; set; }
        public decimal  ApplicationFees { get; set; }

        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationFees = 0;
            _Mode = enMode.AddNew;
        }
        private clsApplicationType(int ID, string Title, decimal Fees)
        {
            this.ApplicationTypeID = ID;
            this.ApplicationTypeTitle = Title;
            this.ApplicationFees = Fees;
            _Mode = enMode.Update;
        }
        public static clsApplicationType FindByAppTypeID(int ID)
        {
            string Title = "";
            decimal Fees  = 0;
            bool IsFound = clsApplicationTypesData.GetAppTypeByID(ID, ref Title, ref Fees);
            if (IsFound)
            {
                return new clsApplicationType(ID, Title, Fees);
            }
            return null;
        }
        private bool _AddNewAppType()
        {
            this.ApplicationTypeID = clsApplicationTypesData.AddNewAppType(ApplicationTypeTitle, ApplicationFees);
            return (this.ApplicationTypeID != -1);
        } 
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }
        private bool _UpdateApplicationType()
        {
            return clsApplicationTypesData.UpdateApplicationType
                (
                this.ApplicationTypeID,
                this.ApplicationTypeTitle,
                this.ApplicationFees);
        }
        public static bool IsAppTypeIDExist(int ID)
        {
            return clsApplicationTypesData.IsAppTypeIDExist(ID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewAppType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplicationType();
            }
            return false;
        }
        public static bool DeletAppType(int ID)
        {
            return clsApplicationTypesData.DeleteApplicationType(ID);
        }
    }
}
