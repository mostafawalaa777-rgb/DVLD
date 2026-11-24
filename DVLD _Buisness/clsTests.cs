using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness.Users;
using DVLD_Buisness;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTests
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.Update;

        public int TestID { get; set; }
        public int TestAppointmentID { get; set; }
        public clsTestAppointment TestAppointmentInfo { set; get; }

        public bool TestResult { get; set; }
        public string Notes { get; set; }
        public int CreatedByUserID { get; set; }


        // Compositions
        public clsTestAppointment appointment;
        public clsUser CreatedByUserInfo;
        public clsTestAppointment TestAppointment;
        public clsTests()
        {
            this.TestID = -1;
            this.TestAppointmentID = -1;
            this.TestResult = true;
            this.Notes  = "";
            this.CreatedByUserID = -1;
            Mode = enMode.AddNew;
        }


        public clsTests(int TestID, int TestAppointmentID,
           bool TestResult, string Notes, int CreatedByUserID)
        {
            this.TestID = TestID;
            this.TestAppointmentID = TestAppointmentID;
            this.TestAppointmentInfo = clsTestAppointment.FindTestAPPointmentByID(TestAppointmentID);

            this.TestResult = TestResult;
            this.Notes = Notes;
            this.CreatedByUserID = CreatedByUserID;
            Mode = enMode.Update;
        }
        public static clsTests GetTestByTestID(int TestID)
        {
            int TestAppointmentID = -1, CreatedByUserID = -1;
            bool TestResult = true;
            string Notes = "";

            bool IsFound = clsTestsData.GetTestByTestID( TestID, ref TestAppointmentID,
           ref  TestResult , ref Notes, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsTests(TestID,  TestAppointmentID,
            TestResult,  Notes,  CreatedByUserID);
            }
            return null;
        }

        public static clsTests FindTestByTestAppointmentID(int TestAppointmentID)
        {
            int TestID  = -1, CreatedByUserID = -1;
            bool TestResult = true;
            string Notes = "";

            bool IsFound = clsTestsData.GetTestByTestAppointmentID(TestAppointmentID, ref TestID ,
           ref TestResult, ref Notes, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsTests(  TestID, TestAppointmentID ,
                    TestResult, Notes, CreatedByUserID);
            }
            return null;
        }

        public static clsTests FindTestByLocalDrivingLicenseApplicationIDAndTestTypeID(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            int CreatedByUserID = -1, TestID = -1, TestAppointmentID = -1; ;
            bool TestResult = true;
            string Notes = "";

            bool IsFound = clsTestsData.GetTestByLocalDrivingLicenseApplicationIDAndTestTypeID(LocalDrivingLicenseApplicationID , TestTypeID, ref TestID ,
            ref TestAppointmentID, ref TestResult, ref Notes, ref CreatedByUserID);

            if (IsFound)
            {
                return new clsTests(TestID, TestAppointmentID, TestResult, Notes, CreatedByUserID);
            }
            return null;
        }

        public static DataTable GetAllTests(int TestID, int TestAppointmentID,
           bool TestResult, string Notes, int CreatedByUserID)
        {
            return clsTestsData.GetAllTests( TestID,  TestAppointmentID,
            TestResult,  Notes,  CreatedByUserID);
        }
        private bool _AddNewTest()
        {
            this.TestID = clsTestsData.AddNewTest( TestAppointmentID,
            TestResult, Notes, CreatedByUserID);

            return (this.TestID != -1);
        }
        private bool _UpdateTest()
        {
            return clsTestsData.UpdateTest
                (
            this.TestID,
            this.TestAppointmentID,
            this.TestResult,
            this.Notes,
            this.CreatedByUserID
           );
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:

                    if (_AddNewTest())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;
                case enMode.Update:
                    return _UpdateTest();
            }
            return false;
        }
        public static bool DeleteTest(int TestID)
        {
            return clsTestsData.DeleteTest(TestID);
        }
        public static int GetPassedTestCount(int LocalDrivingLicenseApplicationID)
        {
            return clsTestsData.GetPassedTestCount( LocalDrivingLicenseApplicationID);
        }
        public static byte GetFailedTestCount(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestsData.GetFailedTestCount(LocalDrivingLicenseApplicationID, TestTypeID);
        }
        public static bool GetLastTestResult(int LocalDrivingLicenseApplicationID,int TestTypeID)
        {
            return clsTestsData.GetLastTestResult(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsTestsData.DoesPassedTestType(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static clsTests FindLastTestPerPersonAndLicenseClass
           (int PersonID, int LicenseClassID, clsTestType.enTestType TestTypeID)
        {
            int TestID = -1;
            int TestAppointmentID = -1;
            bool TestResult = false; string Notes = ""; int CreatedByUserID = -1;

            if (clsTestsData.GetLastTestByPersonAndTestTypeAndLicenseClass
                (PersonID, LicenseClassID, (int)TestTypeID, ref TestID,
            ref TestAppointmentID, ref TestResult,
            ref Notes, ref CreatedByUserID))

                return new clsTests(TestID,
                        TestAppointmentID, TestResult,
                        Notes, CreatedByUserID);
            else
                return null;
        }

        public static bool PassedAllTests(int LocalDrivingLicenseApplicationID)
        {
            return GetPassedTestCount(LocalDrivingLicenseApplicationID) == 3;
        }


    }
}
