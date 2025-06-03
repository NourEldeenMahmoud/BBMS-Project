using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsEmployee
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;
        public int EmployeeID { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool CanLogin { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonData { get; set; }


        public clsEmployee()
        {
            EmployeeID = -1;
            Role = "";
            Password = "";
            UserName = "";
            CanLogin = false;
            PersonID = -1;
            PersonData = new clsPerson();
            Mode = enMode.AddNew;
        }

        public clsEmployee(int EmployeeID, string Role, string Password, string UserName, bool CanLogin, int PersonID)
        {
            this.EmployeeID = EmployeeID;
            this.Role = Role;
            this.Password = Password;
            this.UserName = UserName;
            this.CanLogin = CanLogin;
            this.PersonID = PersonID;
            this.PersonData = clsPerson.Find(PersonID);
            Mode = enMode.Update;
        }

        private bool _AddNewEmployee()
        {
            this.EmployeeID = clsEmployeeData.AddNewEmployee( this.Role, this.Password, this.UserName, this.CanLogin,this.PersonID);
            return this.EmployeeID != -1;
        }
        private bool _UpdateEmployee()
        {
            return clsEmployeeData.UpdateEmployee(this.EmployeeID,this.Role, this.Password, this.UserName, this.CanLogin,this.PersonID);

        }
        public static clsEmployee Find(int EmployeeID)
        {

            string Role = "";
            string Password = "";
            string UserName = "";
            bool CanLogin = false;
            int PersonID = -1;


            bool IsFound = clsEmployeeData.GetEmployeeDataByID(EmployeeID, ref Role, ref Password, ref UserName, ref CanLogin, ref PersonID);
            if (IsFound)
            {
                return new clsEmployee(EmployeeID, Role, Password, UserName, CanLogin, PersonID);
            }
            else
            {
                return null;
            }
        }
        public static clsEmployee FindByUserNameAndPassword(string UserName, string Password)
        {
            int EmployeeID = -1;    
            string Role = "";

            bool CanLogin = false;
            int PersonID = -1;


            bool IsFound = clsEmployeeData.GetUserInfoByUsernameAndPassword(ref EmployeeID, ref Role,  Password,  UserName, ref CanLogin, ref PersonID);
            if (IsFound)
            {
                return new clsEmployee(EmployeeID, Role, Password, UserName, CanLogin, PersonID);
            }
            else
            {
                return null;
            }
        }

        public static bool Delete(int EmployeeID)
        {
            return clsEmployeeData.DeleteEmployee(EmployeeID);
        }
        public static DataTable GetAllEmployees()
        {
            return clsEmployeeData.GetAllEmployees();
        }
        public static bool IsEmployeeExist(int EmployeeID)
        {
            return clsEmployeeData.IsEmployeeExist(EmployeeID);
        }
        public static bool IsEmployeeExistByPersonID(int PersonID)
        {
            return clsEmployeeData.IsEmployeeExistByPersonID(PersonID);
        }
        public static bool IsEmployeeExist(string UserName)
        {
            return clsEmployeeData.IsEmployeeExist(UserName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewEmployee())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateEmployee();
            }
            return false;

        }
    }
}
