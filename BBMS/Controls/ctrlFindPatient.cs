using BBMS.Patients;
using BBMS.People;
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
    public partial class ctrlFindPatient : UserControl
    {
        private int _PatientID=-1;
        private clsPatient _Patient;
        public ctrlFindPatient()
        {
            InitializeComponent();
        }
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPatientSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PatientID)
        {
            Action<int> handler = OnPatientSelected;
            if (handler != null)
            {
                handler(PatientID); // Raise the event with the parameter
            }
        }


        private bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                SearchPanel.Enabled = _FilterEnabled;
            }
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
            ctrlPersonCardWithNoTitle1.LoadPersonData(_Patient.PersonID);
            lblPatientIDValue.Text = _Patient.PatientID.ToString();
            lblBloodTypeValue.Text = _Patient.BloodType;
            lblMedicalConditionValue.Text = _Patient.MedicalCondition;
        }

        private void LoadPatientCard(int PatientID)
        {
            
            
            _Patient = clsPatient.Find(PatientID);
            if (_Patient != null)
            {
                _FillPatient();
                _PatientID = PatientID;

            }
            else
            {
                MessageBox.Show("Inable To Find Patient With Patient ID " + PatientID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnFindPerson_Click(object sender, EventArgs e)
        {
                int.TryParse(txtSearch.Text.Trim(), out int PatientID);
                LoadPatientCard(PatientID);

            if (OnPatientSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPatientSelected(PatientID);
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // إلغاء الإدخال
            }
        }

        public void LoadPatient(int PatientID)
        {
            lblFindBy.Enabled = false;
            txtSearch.Enabled = false;
            btnAddPatient.Enabled = false;
            btnFindPatient.Enabled = false;
            btnShowAllPeople.Enabled = false;
            LoadPatientCard(PatientID);
            txtSearch.Text = _PatientID.ToString();
        }
    
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePatient AddPatient = new frmAddUpdatePatient();
            AddPatient.DataBack += DataBackEvent;
            AddPatient.ShowDialog();
        }

        private void DataBackEvent(object sender, int PatientID)
        {
            // Handle the data received

            txtSearch.Text = PatientID.ToString();
            LoadPatientCard(PatientID);
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            txtSearch.Focus();
        }

        private void btnShowAllPeople_Click(object sender, EventArgs e)
        {
           frmShowAllPatients frmShowAllPatients = new frmShowAllPatients();
            frmShowAllPatients.ShowDialog();
        }

    }
}
