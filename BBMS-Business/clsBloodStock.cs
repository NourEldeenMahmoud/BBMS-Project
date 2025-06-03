using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsBloodStock
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enum enCurrentStatus { Pending = 0, Disposed = 1, Qualified = 2, Transfused = 3,Expired =4 }
        public enum enTestStatus { NotTestedYet = 0, Rejected = 1, Accepted=2 }
        public enMode Mode = enMode.AddNew;



        public int BloodUnitID { get; set; }
        public string BloodType { get; set; }
        public DateTime ExpirationDate { get; set; }
        public enTestStatus TestStatus { get; set; }
        public byte TestStatusValue
        {
            get { return (byte) TestStatus; }
        }
        public string Notes { get; set; }
        public enCurrentStatus CurrentStatus { get; set; }
        public byte CurrentStatusValue
        {
            get { return (byte)CurrentStatus; }
        }
        public int DonationID { get; set; }
        public clsDonation DonationData { get; set; }

        public clsBloodStock()
        {
            BloodUnitID = -1;
            BloodType = "";
            ExpirationDate = DateTime.Now;
            TestStatus = enTestStatus.NotTestedYet;
            Notes = "";
            CurrentStatus = enCurrentStatus.Pending;
            DonationID = -1;

            DonationData = new clsDonation();
            Mode = enMode.AddNew;
        }

        public clsBloodStock(int BloodUnitID, string BloodType, DateTime ExpirationDate, byte TestStatus, string Notes, byte CurrentStatus, int DonationID)
        {
           
            this.BloodUnitID = BloodUnitID;
            this.BloodType = BloodType;
            this.ExpirationDate = ExpirationDate;
            this.TestStatus = (enTestStatus)TestStatus;
            this.Notes = Notes;
            this.CurrentStatus = (enCurrentStatus)CurrentStatus;
            this.DonationID = DonationID;
            this.DonationData =  clsDonation.Find(DonationID);

            Mode = enMode.Update;
        }
        public static clsBloodStock Find(int BloodUnitID)
        {

            
            string BloodType = "";
            DateTime ExpirationDate = DateTime.Now;
            byte TestStatus = 0;
            string Notes = "";
            byte CurrentStatus = 0;
            int DonationID = -1;


            bool IsFound = clsBloodStockData.GetBloodUnitByID(BloodUnitID, ref BloodType, ref ExpirationDate, ref TestStatus, ref Notes, ref CurrentStatus, ref DonationID);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBloodStock(BloodUnitID, BloodType, ExpirationDate, TestStatus, Notes, CurrentStatus, DonationID);
            else
                return null;
        }
        public static clsBloodStock FindBloodMatch(List<string> MatchList)
        {

            int BloodUnitID = -1;
            string BloodType = "";
            DateTime ExpirationDate = DateTime.Now;
            byte TestStatus = 0;
            string Notes = "";
            byte CurrentStatus = 0;
            int DonationID = -1;


            bool IsFound = clsBloodStockData.GetMatchingBloodUnit(MatchList, ref BloodUnitID, ref BloodType, ref ExpirationDate, ref TestStatus, ref Notes, ref CurrentStatus, ref DonationID);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsBloodStock(BloodUnitID, BloodType, ExpirationDate, TestStatus, Notes, CurrentStatus, DonationID);
            else
                return null;
        }
        private bool _AddBloodUnit()
        {
            this.BloodUnitID = clsBloodStockData.AddBloodUnit(this.BloodType, this.ExpirationDate, this.TestStatusValue, this.Notes, this.CurrentStatusValue, this.DonationID);

            return this.BloodUnitID != -1;
        }

        private bool _UpdateBloodUnit()
        {
            return clsBloodStockData.UpdateBloodUnit(this.BloodUnitID, this.BloodType, this.ExpirationDate, this.TestStatusValue, this.Notes, this.CurrentStatusValue, this.DonationID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddBloodUnit())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateBloodUnit();
            }
            return false;
        }

        public static bool Delete(int BloodUnitID)
        {
            return clsBloodStockData.DeleteBloodUnit(BloodUnitID);
        }
        public static DataTable GetAllUnits()
        {
            return clsBloodStockData.GetAllUnits();
        }
        public static DataTable GetAllCompatibleUnits(List<string> MatchList)
        {
            return clsBloodStockData.GetAllCompatibleUnits(MatchList);
        }
        public static bool IsBloodUnitExist(int BloodUnitID)
        {
            return clsBloodStockData.IsBloodUnitExist(BloodUnitID);
        }
        public static bool IsBloodUnitTested(int BloodUnitID)
        {
            return clsBloodStockData.IsUnitTested(BloodUnitID);
        }
        public static bool UpdateExpiredUnits()
        {
            return clsBloodStockData.UpdateExpiredUnits();
        }
        public static string GetCurrentStatusText(enCurrentStatus CurrentStatus)
        {

            switch (CurrentStatus)
            {
                case enCurrentStatus.Pending:
                    return "Pending";
                case enCurrentStatus.Qualified:
                    return "Qualified";
                case enCurrentStatus.Disposed:
                    return "Disposed";
                case enCurrentStatus.Expired:
                    return "Expired";
                default:
                    return "Pending";
            }
        }
        public static string GetTestStatusText(enTestStatus TestStatus)
        {

            switch (TestStatus)
            {
                case enTestStatus.NotTestedYet:
                    return "Not Tested Yet";
                case enTestStatus.Accepted:
                    return "Accepted";
                case enTestStatus.Rejected:
                    return "Rejected";
                default:
                    return "Not Tested Yet";
            }
        }
        public static string GetDonorBloodType(int DonorID)
        {
            return clsBloodStockData.GetDonorBloodType(DonorID);
        }



    }
}
