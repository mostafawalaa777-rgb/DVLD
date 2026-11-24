
using System;
using System.Data;
using DVLD_Buisness;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        private enum enMode{AddNew = 0, Update = 1}
        private enMode _Mode;

        public int DriverID { get;  set; }
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }
        public clsPerson PersonInfo { get; set; }

        // Constructor
        public clsDriver()
        {
            _Mode = enMode.AddNew;

            DriverID = -1;
            PersonID = -1;
            CreatedByUserID = -1;
            CreatedDate = DateTime.Now;
        }

        // Private Constructor
        private clsDriver(int DriverID, int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {

            this.DriverID = DriverID;
            this.PersonID = PersonID;
            this.CreatedByUserID = CreatedByUserID;
            this.CreatedDate = CreatedDate;
            this.PersonInfo = clsPerson.Find(PersonID);

            _Mode = enMode.Update;
        }

        // Find By DriverID
        public static clsDriver FindByDriverID(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = clsDriverData.GetDriverInfoByDriverID(
                DriverID,
                ref PersonID,
                ref CreatedByUserID,
                ref CreatedDate
            );

            if (IsFound)
            {
                return new clsDriver(
                    DriverID,
                    PersonID,
                    CreatedByUserID,
                    CreatedDate
                );
            }

            return null;
        }

        // Find By PersonID
        public static clsDriver FindByPersonID(int PersonID)
        {
            int DriverID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.Now;

            bool IsFound = clsDriverData.GetDriverInfoByPersonID(
                PersonID,
                ref DriverID,
                ref CreatedByUserID,
                ref CreatedDate
            );

            if (IsFound)
            {
                return new clsDriver(
                    DriverID,
                    PersonID,
                    CreatedByUserID,
                    CreatedDate
                );
            }

            return null;
        }

        // Add New Driver
        private bool _AddNewDriver()
        {
            this.DriverID = clsDriverData.AddNewDriver(
                this.PersonID,
                this.CreatedByUserID,
                this.CreatedDate
            );

            return (this.DriverID != -1);
        }

        // Update Driver
        private bool _UpdateDriver()
        {
            return clsDriverData.UpdateDriver(
                this.DriverID,
                this.PersonID,
                this.CreatedByUserID,
                this.CreatedDate
            );
        }

        // Save
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:

                    if (_AddNewDriver())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }

                    return false;

                case enMode.Update:

                    return _UpdateDriver();
            }

            return false;
        }

        // Delete
        public static bool DeleteDriver(int DriverID)
        {
            return clsDriverData.DeleteDriver(DriverID);
        }

        // Check If Driver Exists By PersonID
        public static bool IsDriverExist(int PersonID)
        {
            return clsDriverData.IsDriverExist(PersonID);
        }

        // Get All Drivers
        public static DataTable GetAllDrivers()
        {
            return clsDriverData.GetAllDrivers();
        }
    }
}
