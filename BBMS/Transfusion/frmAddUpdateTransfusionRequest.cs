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

namespace BBMS.Patients
{
    public partial class frmAddUpdateTransfusionRequest : Form
    {

        private int _PatientID = -1;

        private int _TransfusionID = -1;

        private bool _frmPatient = false;

        private clsPatient _Patient;

        private clsTransfusion _Transfusion;

        public frmAddUpdateTransfusionRequest(int PateintID,bool frmPatient)
        {
            InitializeComponent();
            _PatientID = PateintID;
            _frmPatient = frmPatient;
        }
        public frmAddUpdateTransfusionRequest(int TransfusionID)
        {
            InitializeComponent();
            _TransfusionID = TransfusionID;
        }

        public frmAddUpdateTransfusionRequest()
        {
            InitializeComponent();
        }

        private void _Header()
        {
            if (_TransfusionID == -1)
            {
                lblTitle.Text = "Request Transfusion";
            }
            else
            {
                lblTitle.Text = "Update Request";
            }

        }

        private void _LoadTransfusionData()
        {
            lblBloodTypeValue.Text = _Patient.BloodType;
            lblMedicalConditionValue.Text = _Patient.MedicalCondition;
            lblRequestDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            if (_Transfusion.Mode == clsTransfusion.enMode.Update)
            {
                txtVolumeRequested.Text = _Transfusion.QuantityRequested.ToString();
            }

        }

        private void _FillTransfusionData()
        {
            
            _Transfusion.PatientID= _Patient.PatientID;
            _Transfusion.PatientData = _Patient;
            _Transfusion.TransfusionDate = null;
            _Transfusion.QuantityRequested = int.Parse(txtVolumeRequested.Text);
            _Transfusion.TransfusionStatus = 0;
            _Transfusion.TransfusionRequestDate = DateTime.Now;

        }

        private void frmRequestTrasnfusion_Load(object sender, EventArgs e)
        {
            _Header();

            if (_frmPatient)
            {
                if (clsTransfusion.DoesPatientHasActiveRequest(_PatientID))
                {
                    _Transfusion = clsTransfusion.FindByPatientID(_PatientID);
                    _Patient = _Transfusion.PatientData;
                    _Transfusion.Mode = clsTransfusion.enMode.Update;
                    ctrlFindPatient1.LoadPatient(_Transfusion.PatientID);
                    _LoadTransfusionData();
                }
                else
                {
                    _Transfusion = new clsTransfusion();
                    _Transfusion.Mode = clsTransfusion.enMode.AddNew;
                    _Patient = clsPatient.Find(_PatientID);
                    ctrlFindPatient1.LoadPatient(_PatientID);
                    _LoadTransfusionData();
                }
            }
            else
            {
                if (_TransfusionID==-1)
                {
                    _Transfusion = new clsTransfusion();
                    _Transfusion.Mode = clsTransfusion.enMode.AddNew;
                    tpRequestInfo.Enabled = false;
                }
                else
                {
                    _Transfusion = clsTransfusion.Find(_TransfusionID);
                    _Transfusion.Mode = clsTransfusion.enMode.Update;
                    ctrlFindPatient1.LoadPatient(_Transfusion.PatientID);
                    _Patient= _Transfusion.PatientData;
                    _LoadTransfusionData();
                }
            }
        }

        private void txtVolumeRequested_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtVolumeRequested.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtVolumeRequested, "Height cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtVolumeRequested, null);
            }
        }

        private void txtVolumeRequested_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            _FillTransfusionData();
            if (_Transfusion.Save())
            {
                MessageBox.Show("Transfusion Request Is Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTransfusionIDValue.Text=_Transfusion.TransfusionID.ToString();
                _Transfusion.Mode = clsTransfusion.enMode.Update;
                _Header();
            }
            else
            {
                MessageBox.Show("Error: Transfusion Request Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPatientCard ShowPatientCard = new frmShowPatientCard(_PatientID);
            ShowPatientCard.ShowDialog();
        }

        private void ctrlFindPatient1_OnPatientSelected(int obj)
        {
            if (ctrlFindPatient1.PatientID != -1)
            {
                if (clsTransfusion.DoesPatientHasActiveRequest(ctrlFindPatient1.PatientID))
                {

                    MessageBox.Show("Selected Patient already has an Active Transfusion Request.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFindPatient1.Focus();

                }

                else
                {
                    tpRequestInfo.Enabled = true;
                    btnNext.Enabled = true;
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
         

            if (ctrlFindPatient1.PatientID != -1)
            {
                if (clsTransfusion.DoesPatientHasActiveRequest(ctrlFindPatient1.PatientID)&&_Transfusion.Mode != clsTransfusion.enMode.Update)
                {

                    tpRequestInfo.Enabled = false;
                    ctrlFindPatient1.Focus();
                }

                else
                {
                    _PatientID = ctrlFindPatient1.PatientID;
                    _Patient = ctrlFindPatient1.PatientInfo;
                    _LoadTransfusionData();
                    tpRequestInfo.Enabled = true;
                }
            }
            tcAddUpdateRequest.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddUpdateRequest.SelectedIndex = 0;
        }

        private void tcAddUpdateRequest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddUpdateRequest.SelectedIndex==1)
            {
                btnNext_Click(this, EventArgs.Empty);
            }
          
        }
    }
}
