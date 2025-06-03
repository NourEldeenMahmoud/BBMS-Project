using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsPatient
    {
        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int PatientID { get; set; }
        public string BloodType { get; set; }
        public string MedicalCondition { get; set; }
        public int PersonID { get; set; }

        public clsPerson PersonData { get; set; }

        public clsPatient()
        {
            this.PersonID = -1;
            this.BloodType = "";
            this.MedicalCondition = "";
            this.PersonID = -1;

            PersonData = new clsPerson();
            Mode = enMode.AddNew;
        }

        public clsPatient(int patientID, string bloodType, string medicalCondition, int personID)
        {
            PatientID = patientID;
            BloodType = bloodType;
            MedicalCondition = medicalCondition;
            PersonID = personID;

            this.PersonData = clsPerson.Find(PersonID);
            Mode = enMode.Update;
        }

        private bool _AddNewPatient()
        {
            this.PatientID = clsPatientData.AddNewPatient(this.BloodType, this.MedicalCondition, this.PersonID);
            return this.PatientID != -1;
        }
        private bool _UpdatePatient()
        {
            return clsPatientData.UpdatePatient(this.PatientID, this.BloodType, this.MedicalCondition, this.PersonID);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPatient())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePatient();
            }
            return false;
        }

        public static bool Delete(int PatientID)
        {
            return clsPatientData.DeletePatient(PatientID);
        }
        public static DataTable GetAllPatients()
        {
            return clsPatientData.GetAllPatients();
        }
        public static bool IsPatientExist(int PersonID)
        {
            return clsPatientData.IsPatientExist(PersonID);
        }

        public static clsPatient Find(int PatientID)
        {
            string BloodType = "";
            string MedicalCondition = "";
            int PersonID = -1;

            bool IsFound = clsPatientData.GetPatientByID(PatientID, ref BloodType, ref MedicalCondition, ref PersonID);

            if (IsFound)
            {
                return new clsPatient(PatientID, BloodType, MedicalCondition, PersonID);
            }
            else
            {
                return null;
            }
        }

    }
}
