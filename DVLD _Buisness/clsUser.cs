using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using BCrypt;
using static DVLD_Buisness.clsPerson;
using DVLD_DataAccess.Users;
    


namespace DVLD_Buisness.Users
{
    public class clsUser
    {
        clsUser _User;
        clsPerson _Person;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode _Mode = enMode.AddNew;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonInfo;

        public string UserName { get; set; }
        public string FullName
            {
                get { return _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName; }
            }

        public bool IsActive { get; set; }
        private string _PasswordHash;
        public string PasswordHash
        {
            get { return _PasswordHash; }
            set { _PasswordHash = value; }
        }
        public string Password { get; set; }

        public clsUser()
        {
            this.UserID = -1;
            this.PersonID = -1;
            this.UserName = "";
            this.Password = "";
            this.PasswordHash = "";
            this.IsActive = true;
            _Mode = enMode.AddNew;
        }
        private clsUser(int UserID, int PersonID, string UserName, bool IsActive, string PasswordHash )
        {
            this.UserID = UserID;
            this.PersonID = PersonID;
            this.PersonInfo = clsPerson.Find(PersonID);
            this.UserName = UserName;
            this.PasswordHash = PasswordHash;
            this.IsActive = IsActive;
            _Mode = enMode.Update;
        }
        public static clsUser FindByUserID(int UserID)
        {

            string UserName = "", PasswordHash = "";
            bool IsActive = false;
            int PersonID = -1; 

            bool IsFound = clsUserData.GetUserInfoByUserID(UserID, ref PersonID, ref UserName,
                    ref IsActive, ref PasswordHash);
            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, IsActive, PasswordHash);
            }
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            string PasswordHash = "", UserName = "";
            bool IsActive = true;
            int UserID = -1;

            bool IsFound = clsUserData.GetUserInfoByPersonID(PersonID, ref UserID, ref UserName, ref IsActive, ref PasswordHash);
            if(IsFound) 
            {
                return new clsUser(UserID, PersonID, UserName, IsActive, PasswordHash);
            }
            else 
                return null;
        }
        public static clsUser FindByUserName(string UserName)
        {
            int UserID = -1, PersonID = -1 ;
            string PasswordHash = "", Password = "";
            bool IsActive = true;

            bool IsFound = clsUserData.GetUserInfoByUserName(UserName, ref UserID, ref PersonID, ref IsActive, ref PasswordHash);
            if (IsFound)
            {
                return new clsUser(UserID, PersonID, UserName, IsActive, PasswordHash);
            }
            else return null;
        }
        private bool _AddNewUser()
        {
             PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            this.UserID = clsUserData.AddNewUser(PersonID, UserName, IsActive, PasswordHash);
            return (this.UserID != -1);
        }
        private bool _UpdateUser()
        { 
             PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            return clsUserData.UpdateUser(
                this.UserID,
                this.PersonID,
                this.UserName,
                this.IsActive,
                PasswordHash);
        }
        public bool Save()
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            switch (_Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {
                        _Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static bool DeletUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }
        public static bool IsUserExist(string Password, string UserName)
        {
            if (string.IsNullOrWhiteSpace(Password) ||
                         string.IsNullOrWhiteSpace(UserName))
            {
                return false;
            }

            string PasswordHash = clsUserData.GetPasswordHashByUserName(UserName);

            if(string.IsNullOrWhiteSpace(PasswordHash))
            {
                return false;

            }
            return BCrypt.Net.BCrypt.Verify(Password, PasswordHash);

        }
        public static bool isUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
        }
        public static bool IsUserExist(bool IsActive)
        {
            return clsUserData.IsUserExist(IsActive);
        }
        public bool ChangePassword(string Password)
        {
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(Password);

            return clsUserData.ChangePassword(UserID, PasswordHash);
        }
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, PasswordHash);
        }
    }
}
