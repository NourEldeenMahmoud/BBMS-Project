using BBMS_Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsTransfusion
    {

        public enum enMode { AddNew = 1, Update = 2 }
        public enMode Mode = enMode.AddNew;

        public int TransfusionID { get; set; }
        public DateTime? TransfusionDate { get; set; }
        public DateTime TransfusionRequestDate { get; set; }
        public int QuantityRequested { get; set; }
        public byte TransfusionStatus { get; set; }
        public int PatientID { get; set; }
        public int BloodUnitID { get; set; }
        public int PerformedBy { get; set; }

        public clsPatient PatientData { get; set; }
        public clsBloodStock BloodUnitData { get; set; }
        public clsEmployee EmployeeData { get; set; }


        public clsTransfusion()
        {
            TransfusionID = -1;
            TransfusionDate = DateTime.Now;
            TransfusionRequestDate = DateTime.Now;
            QuantityRequested = 0;
            TransfusionStatus = 0;
            PatientID = -1;
            BloodUnitID = -1;
            PerformedBy = -1;

            PatientData = new clsPatient();
            EmployeeData = new clsEmployee();
            BloodUnitData = new clsBloodStock();

            Mode = enMode.AddNew;
        }

        public clsTransfusion(int transfusionID,DateTime TransfusionRequestDate, DateTime? transfusionDate, int quantityRequested, byte transfusionStatus, int patientID, int bloodUnitID, int performedBy)
        {
            this.TransfusionID = transfusionID;
            this.TransfusionDate = transfusionDate;
            this.TransfusionRequestDate = TransfusionRequestDate;
            this.QuantityRequested = quantityRequested;
            this.TransfusionStatus = transfusionStatus;
            this.PatientID = patientID;
            this.BloodUnitID = bloodUnitID;
            this.PerformedBy = performedBy;
           
            this.PatientData = clsPatient.Find(PatientID);
            this.EmployeeData = clsEmployee.Find(PerformedBy);
            this.BloodUnitData = clsBloodStock.Find(BloodUnitID);
           
            this.Mode = enMode.Update;
        }


        private bool _AddNewTransfusion()
        {
            TransfusionID = clsTransfusionData.AddNewTransfusion(TransfusionRequestDate, TransfusionDate, QuantityRequested, TransfusionStatus, PatientID, BloodUnitID, PerformedBy);
            return TransfusionID != -1;
        }
        private bool _UpdateTransfusion()
        {
            return clsTransfusionData.UpdateTransfusion(TransfusionID, TransfusionRequestDate, TransfusionDate, QuantityRequested, TransfusionStatus, PatientID, BloodUnitID, PerformedBy);
        }


        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTransfusion())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTransfusion();
            }
            return false;
        }

        public static bool Delete(int TransfusionID)
        {
            return clsTransfusionData.DeleteTransfusion(TransfusionID);
        }
        public static DataTable GetAllTransfusions()
        {
            return clsTransfusionData.GetAllTransfusions();
        }
        public static bool IsTransfusionExist(int TransfusionID)
        {
            return clsTransfusionData.IsTransfusionExist(TransfusionID);
        }
        public static bool DoesPatientHasActiveRequest(int PatientID)
        {
            return clsTransfusionData.DoesPatientHasActiveRequest(PatientID);
        }
        public static clsTransfusion Find(int TransfusionID)
        {
            DateTime? transfusionDate = DateTime.Now;
            DateTime TransfusionRequestDate = DateTime.Now;
            int quantityRequested = 0;
            byte transfusionStatus = 0;
            int patientID = -1;
            int bloodUnitID = -1;
            int performedBy = -1;

            bool IsFound = clsTransfusionData.GetTransfusionByID(TransfusionID,ref TransfusionRequestDate, ref transfusionDate, ref quantityRequested, ref transfusionStatus, ref patientID, ref bloodUnitID, ref performedBy);

            if (IsFound)
            {
                return new clsTransfusion(TransfusionID, TransfusionRequestDate, transfusionDate, quantityRequested, transfusionStatus, patientID, bloodUnitID, performedBy);
            }
            else
            {
                return null;
            }
        }
        public static clsTransfusion FindByPatientID(int PatientID)
        {
            DateTime? transfusionDate = DateTime.Now;
            DateTime TransfusionRequestDate = DateTime.Now;
            int quantityRequested = 0;
            byte transfusionStatus = 0;
            int TransfusionID = -1;
            int bloodUnitID = -1;
            int performedBy = -1;

            bool IsFound = clsTransfusionData.GetTransfusionByPatientID(ref TransfusionID, ref TransfusionRequestDate, ref transfusionDate, ref quantityRequested, ref transfusionStatus,  PatientID, ref bloodUnitID, ref performedBy);

            if (IsFound)
            {

                return new clsTransfusion(TransfusionID, TransfusionRequestDate, transfusionDate, quantityRequested, transfusionStatus, PatientID, bloodUnitID, performedBy);

            }
            else
            {
                return null;
            }
        }
    }
}
