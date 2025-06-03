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
    public partial class ctrlPatientCard : UserControl
    {
        private int _PatientID = -1;
        private clsPatient _Patient;
        public ctrlPatientCard()
        {
            InitializeComponent();
        }
        public int PatientID
        {
            get { return _PatientID; }
        }
        public clsPatient PatientInfo
        {
            get { return _Patient; }
        }
        private void _FillPatient()
        {
            ctrlPersonCard1.LoadPersonData(_Patient.PersonID);
            lblPatientIDValue.Text = _Patient.PatientID.ToString();
            lblBloodTypeValue.Text = _Patient.BloodType;
            lblMedicalConditionValue.Text = _Patient.MedicalCondition;


        }
        public void LoadPatientCard(int PatientID)
        {
            _PatientID = PatientID;

            _Patient = clsPatient.Find(_PatientID);
            if (_Patient != null)
            {
                ctrlPersonCard1.TitleText.Text = "Patient Card";
                _FillPatient();

            }
            else
            {
                MessageBox.Show("Inable To Find Person With Person ID " + _PatientID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
        }
        private void ctrlPatientCard_Load(object sender, EventArgs e)
        {
         
        }
    }
}
