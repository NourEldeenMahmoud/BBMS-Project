using BBMS.BloodStock;
using BBMS.Employees;
using BBMS.Patients;
using BBMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS.Controls
{
    public partial class ctrlTransfusionRequestDetails : UserControl
    {
        private int _TransfusionID = -1;
        private clsTransfusion _Transfusion;
        public ctrlTransfusionRequestDetails()
        {
            InitializeComponent();
        }
        private void FillTransfusionInfo()
        {
            lblTransfusionIDValue.Text = _Transfusion.TransfusionID.ToString();
            lblTransfusionDateValue.Text = _Transfusion.TransfusionDate.HasValue ? _Transfusion.TransfusionDate.Value.ToString("dd/MM/yyyy"): "None";
            lblVolumeRequestedValue.Text = _Transfusion.QuantityRequested.ToString()+" ml";
            if (_Transfusion.TransfusionStatus == 0)
            {
                lblTransfusionStatusValue.Text = "Pending";
            }
            else
            {
                lblTransfusionStatusValue.Text = "Complete";
            }
           
        }
        public void LoadTransfusionInfo(int TransfusionID)
        {
            _TransfusionID = TransfusionID;
            _Transfusion = clsTransfusion.Find(TransfusionID);
            if (_Transfusion != null)
            {
                FillTransfusionInfo();
            }
            else
            {
                MessageBox.Show("Inable To Find Transfusion Request With Transfusion ID " + TransfusionID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void llblPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPatientCard ShowPatientCard = new frmShowPatientCard(_Transfusion.PatientID);
            ShowPatientCard.ShowDialog();
        }

        private void llblBloodUnitInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Transfusion.TransfusionStatus == 1)
            {
                frmShowBloodUnit ShowBloodUnit = new frmShowBloodUnit(_Transfusion.BloodUnitID);
                ShowBloodUnit.ShowDialog();
            }
        }

        private void llblNurseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_Transfusion.TransfusionStatus == 1)
            {
                frmShowEmployee frmShowEmployee = new frmShowEmployee(_Transfusion.PerformedBy);
                frmShowEmployee.ShowDialog();
            }

        }

    }
}
