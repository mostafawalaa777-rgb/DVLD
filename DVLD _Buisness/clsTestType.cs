using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Buisness
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode _Mode = enMode.AddNew;

        public enum enTestType { VisionTest = 1, WrittenTest  = 2 , StreetTest = 3}
       // public enTestType _TestType = enTestType.VisionTest;

        public clsTestType.enTestType TestTypeID { get; set; }
        public string TestTypeTitle { get; set; }
        public string TestTypeDescription { get; set; }
        public float TestTypeFees { get; set; }
        public clsTestType()
        {
            this.TestTypeID = 0;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;
            _Mode = enMode.AddNew;
        }
        private clsTestType(int ID, string Title, string Description, float Fees)
        {
            this.TestTypeID = (enTestType) ID;
            this.TestTypeTitle = Title;
            this.TestTypeDescription = Description;
            this.TestTypeFees = Fees;
            _Mode = enMode.Update;
        }
        public  static DataTable GetAllTestTypes ()
        {
            return clsTestTypeData.GetAllTestTypes();
        }
        private bool _AddNewTestType()
        {
          
            int TestTypeID = clsTestTypeData.AddNewTestType(this.TestTypeTitle, this.TestTypeDescription,this.TestTypeFees);
            if (TestTypeID != -1)
            {
                this.TestTypeID = (enTestType)TestTypeID;
                return true;
            }
            return false;
        }
        public static clsTestType FindByTestTypeID(clsTestType.enTestType TestTypeID)
        {
            string Title = "", Description = "";
            float Fees = 0;
            bool IsFound =  clsTestTypeData.GetTestTypeByID((int)TestTypeID, ref Title, ref Description, ref Fees);
            if(IsFound)
            {
                return new clsTestType((int) TestTypeID, Title, Description, Fees );
            }
            return null;
        }
        private bool _UpdateTestType()
        {
            return clsTestTypeData.UpdateTestType
                (
                  (int)  this.TestTypeID,
                    this.TestTypeTitle,
                    this.TestTypeDescription,
                    this.TestTypeFees
                );
        }
        public static bool IsTestTypeIDExist(int ID)
        {
            return clsTestTypeData.IsTestTypeIDExist(ID);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateTestType();
            }
            return false;
        }
        public static bool DeleteTestType(int ID)
        {
            return clsTestTypeData.DeleteTestType(ID);
        }
    }
}
