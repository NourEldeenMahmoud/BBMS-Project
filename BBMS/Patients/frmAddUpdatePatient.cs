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
    public partial class frmAddUpdatePatient : Form
    {
        private int _PatientID = -1;
        private clsPatient _Patient;
        public delegate void DataBackEventHandler(object sender, int PatientID);
        public event DataBackEventHandler DataBack;

        public frmAddUpdatePatient()
        {
            InitializeComponent();
        }

        public frmAddUpdatePatient(int PatientID)
        {
            InitializeComponent();
            _PatientID = PatientID;
        }

        private void frmAddUpdatePatient_Load(object sender, EventArgs e)
        {
            _Header();
            if (_PatientID == -1)
            {
                _Patient = new clsPatient();
                _Patient.Mode = clsPatient.enMode.AddNew;
                tpPatientInfo.Enabled = false;
            }
            else
            {
                _Patient = clsPatient.Find(_PatientID);

                if (_Patient != null)
                {
                    _Patient.Mode = clsPatient.enMode.Update;
                    _LoadPatient();
                }
                else
                {
                    MessageBox.Show("Patient With ID" + _PatientID + "Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }
        }

        private void _Header()
        {
            if (_PatientID == -1)
            {
                lblTitle.Text = "Add Pateint";
            }
            else
            {
                lblTitle.Text = "Update Patient";
            }

        }

        private void _FillPatient()
        {
            _Patient.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Patient.BloodType = cbBloodType.SelectedItem.ToString();

            _Patient.MedicalCondition = txtMedicalCondition.Text;
        }

        private void _LoadPatient()
        {
            if (_Patient.Mode == clsPatient.enMode.Update)
            {
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            ctrlPersonCardWithFilter1.LoadPerson(_Patient.PersonID);
            lblPatientIDValue.Text = _Patient.PatientID.ToString();
            cbBloodType.SelectedIndex= cbBloodType.FindString(_Patient.BloodType.Trim());
            
            txtMedicalCondition.Text = _Patient.MedicalCondition;

        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsPatient.IsPatientExist(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person Is Already A Patient, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.Focus();
                    tpPatientInfo.Enabled = false;
                }

                else
                {
                    tpPatientInfo.Enabled = true;
                    btnNext.Enabled = true;
                    
                }
            }
            tpPatientInfo.Enabled = false;

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Patient.Mode == clsPatient.enMode.Update)
            {
                tpPatientInfo.Enabled = true;
                tcAddUpdatePatient.SelectedIndex = 1;
            }
            else
            {
                if (ctrlPersonCardWithFilter1.PersonID != -1)
                {
                    if (clsPatient.IsPatientExist(ctrlPersonCardWithFilter1.PersonID))
                    {

                        tpPatientInfo.Enabled = false;
                        ctrlPersonCardWithFilter1.Focus();
                    }

                    else
                    {
                        tpPatientInfo.Enabled = true;
                        tcAddUpdatePatient.SelectedIndex = 1;
                    }
                }
                tcAddUpdatePatient.SelectedIndex = 1;
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
               
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillPatient();
            if (_Patient.Save())
            {
                lblPatientIDValue.Text = _Patient.PatientID.ToString();
                DataBack?.Invoke(this, _Patient.PatientID);
                _Patient.Mode = clsPatient.enMode.Update;
                _Header();
                this.Text = "Update Patient";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddUpdatePatient.SelectedIndex = 0;
            tpPatientInfo.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbBloodType_Validating(object sender, CancelEventArgs e)
        {
            if (cbBloodType.SelectedIndex == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbBloodType, "Choose The Blood Type");
            }
            else
            {
                errorProvider1.SetError(cbBloodType, null);

            }
        }

        private void txtMedicalCondition_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMedicalCondition.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtMedicalCondition, "Field Is Missing");
            }
            else
            {
                errorProvider1.SetError(txtMedicalCondition, null);

            }
        }

        private void tcAddUpdatePatient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddUpdatePatient.SelectedIndex==1)
            {
                btnNext_Click(this, EventArgs.Empty);
            }
           
        }
    }
}
