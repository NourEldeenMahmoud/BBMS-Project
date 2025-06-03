using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsDonor
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int DonorID { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public DateTime? LastDonationDate { get; set; }
        public string MedicalRecord { get; set; }
        public bool CanDonate { get; set; }
        public int PersonID { get; set; }
        public clsPerson PersonData { get; set; }

        public clsDonor()
        {
            DonorID = -1;
            Height = 0;
            Weight = 0;
            LastDonationDate = DateTime.Now;
            MedicalRecord = "";
            CanDonate = false;
            PersonID = -1;
            PersonData= new clsPerson();
            Mode = enMode.AddNew;
        }

        public clsDonor(int DonorID, decimal Height, decimal Weight, DateTime? LastDonationDate, string MedicalRecord, bool CanDonate, int PersonID)
        {
            this.DonorID = DonorID;
            this.Height = Height;
            this.Weight = Weight;
            this.LastDonationDate = LastDonationDate;
            this.MedicalRecord = MedicalRecord;
            this.CanDonate = CanDonate;
            this.PersonID = PersonID;

            PersonData = clsPerson.Find(PersonID);

            Mode = enMode.Update;
        }

        private bool _AddNewDonor()
        {
            DonorID = clsDonorData.AddNewDonor(Height, Weight, LastDonationDate, MedicalRecord, CanDonate, PersonID);

            return DonorID != -1;
        }


        private bool _UpdateDonor()
        {
            return clsDonorData.UpdateDonor(DonorID, Height, Weight, LastDonationDate, MedicalRecord, CanDonate);
        }
        public static clsDonor Find(int DonorID)
        {

            decimal Height = 0;
            decimal Weight = 0;
            DateTime? LastDonationDate = DateTime.Now;
            string MedicalRecord = "";
            bool CanDonate = false;
            int PersonID = -1;


            bool IsFound = clsDonorData.GetDonorByID(DonorID, ref Height, ref Weight,ref LastDonationDate, ref MedicalRecord, ref CanDonate, ref PersonID);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsDonor(DonorID,  Height,  Weight,  LastDonationDate,  MedicalRecord, CanDonate,  PersonID);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDonor())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateDonor();
            }
            return false;
        }

        public static bool Delete(int DonorID)
        {
            return clsDonorData.DeleteDonor(DonorID);
        }
        public static DataTable GetAllDonors()
        {
            return clsDonorData.GetAllDonors();
        }
        public static DataTable GetAllValidDonors()
        {
            return clsDonorData.GetAllValidDonors();
        }
        public static bool IsDonorExist(int DonorID)
        {
            return clsDonorData.IsDonorExist(DonorID);
        }

        public static bool IsAbleToDonate(int DonorID)
        {
            return clsDonorData.CanDonate(DonorID);
        }
        public static bool IsDonorExistByPersonID(int PersonID)
        {
            return clsDonorData.IsDonorExistByPersonID(PersonID);
        }
    }
}
