using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public  class clsDonation
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int DonationID { get; set; }
        public DateTime DonationDate { get; set; }
        public decimal BloodVolume { get; set; }
        public int DonorID { get; set; }
        public int NurseID { get; set; }
        public clsDonor DonorData { get; set; }
        public clsEmployee NurseData { get; set; }
        public clsDonation()
        {
            DonationID = -1;
            DonationDate = DateTime.Now;
            BloodVolume = -1;
            NurseID = -1;
            DonorID = -1;
            DonorData = new clsDonor();
            NurseData = new clsEmployee();

            Mode = enMode.AddNew;
        }
        public clsDonation(int DonationID, DateTime DonationDate, decimal BloodVolume, int DonorID, int NurseID)
        {
            this.DonationID = DonationID;
            this.DonationDate = DonationDate;
            this.BloodVolume = BloodVolume;
            this.DonorID = DonorID;
            this.NurseID = NurseID;
            DonorData = clsDonor.Find(DonorID);
            NurseData = clsEmployee.Find(NurseID);

        }
        private bool _AddNewDonation()
        {
            this.DonationID = clsDonationData.AddNewDonation(this.DonationDate, BloodVolume, this.DonorID, this.NurseID);

            return this.DonationID != -1;
        }
        public static clsDonation Find(int DonationID)
        {
            DateTime DonationDate = DateTime.Now;
            decimal BloodVolume = -1;
            int DonorID = -1;
            int NurseID = -1;

            bool isFound = clsDonationData.GetDonationByID(DonationID, ref DonationDate,ref BloodVolume, ref DonorID, ref NurseID);
            if (isFound)
            {
                return new clsDonation(DonationID, DonationDate, BloodVolume, DonorID, NurseID);
            }
            else
            {
                return null;
            }
        }
        public bool Save()
        {

            this.DonorData.LastDonationDate = DateTime.Now;
            this.DonorData.DonorID = this.DonorID;
            this.DonorData.Mode = clsDonor.enMode.Update;
            if (!this.DonorData.Save())
            {
                return false;
            }
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDonation())
                    {
                       // Mode = enMode.Update;
                       
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                    //case enMode.Update:
                    //    return _UpdateDonation();
            }
            return false;
        }
        public static bool Delete(int DonationID)
        {
            return clsDonationData.DeleteDonation(DonationID);
        }
        public static DataTable GetAllDonations()
        {
            return clsDonationData.GetAllDonations();
        }
        public static bool IsDonationExist(int DonationID)
        {
            return clsDonationData.IsDonationExist(DonationID);
        }
        public static DataTable GetAllNurses()
        {
            return clsDonationData.GetAllNurses();
        }
    }
}
