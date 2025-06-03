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
    public partial class frmShowAllPatients : Form
    {

        private DataTable _dtAllPatients = clsPatient.GetAllPatients();

        public frmShowAllPatients()
        {
            InitializeComponent();
        }

        private void frrmShowAllPatients_Load(object sender, EventArgs e)
        {
            _RefreshDonorsList();
            dgvHeader();
        }

        private void _RefreshDonorsList()
        {
            _dtAllPatients = clsPatient.GetAllPatients();

            dgvListPatients.DataSource = _dtAllPatients;
            lblNumberOfRecords.Text = dgvListPatients.Rows.Count.ToString();
        }

        private void dgvHeader()
        {
            dgvListPatients.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListPatients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvListPatients.Columns[0].HeaderText = "Patient ID";
            dgvListPatients.Columns[0].Width = 80;

            dgvListPatients.Columns[1].HeaderText = "Patient Name";
            dgvListPatients.Columns[1].Width = 300;

            dgvListPatients.Columns[2].HeaderText = "Blood Type";
            dgvListPatients.Columns[2].Width = 80;

            dgvListPatients.Columns[3].HeaderText = "National No";
            dgvListPatients.Columns[3].Width = 80;

            dgvListPatients.Columns[4].HeaderText = "Medical Condition";
            dgvListPatients.Columns[4].Width = 300;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilterBy.Text != "None");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Patient ID":
                    FilterColumn = "PatientID";
                    break;

                case "Patient Name":
                    FilterColumn = "Full Name";
                    break;

                case "Blood Type":
                    FilterColumn = "BloodType";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;


                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPatients.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListPatients.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PatientID")
                //in this case we deal with integer not string.

                _dtAllPatients.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtAllPatients.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = _dtAllPatients.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Patient ID" || cbFilterBy.Text == "Requested Quantity")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            int PatientID = (int)dgvListPatients.CurrentRow.Cells[0].Value;
            frmAddUpdatePatient AddUpdatePatient = new frmAddUpdatePatient(PatientID);
            AddUpdatePatient.ShowDialog();
            _RefreshDonorsList();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int PatientID = (int)dgvListPatients.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Patient With ID " + PatientID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPatient.Delete(PatientID))
                {

                    MessageBox.Show("Patient With ID " + PatientID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDonorsList();

                }
                else
                {
                    MessageBox.Show("Patient With ID " + PatientID + " Is Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void dgvListPatients_DoubleClick(object sender, EventArgs e)
        {
            int PatientID = (int)dgvListPatients.CurrentRow.Cells[0].Value;
            frmShowPatientCard ShowPatientCard = new frmShowPatientCard(PatientID);
            ShowPatientCard.ShowDialog();
        }

        private void cmShowDetails_Click(object sender, EventArgs e)
        {
            int PatientID = (int)dgvListPatients.CurrentRow.Cells[0].Value;
            frmShowPatientCard ShowPatientCard = new frmShowPatientCard(PatientID);
            ShowPatientCard.ShowDialog();
        }

    }
}
