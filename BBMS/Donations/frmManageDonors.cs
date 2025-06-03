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

namespace BBMS.Donations
{
    public partial class frmManageDonors : Form
    {
        public frmManageDonors()
        {
            InitializeComponent();
        }
        private DataTable _dtDonors = clsDonor.GetAllDonors();

        private void _RefreshDonorsList()
        {
            _dtDonors = clsDonor.GetAllDonors();

            dgvListDonors.DataSource = _dtDonors;
            lblNumberOfRecords.Text = dgvListDonors.Rows.Count.ToString();
        }
        private void dgvHeader()
        {
            dgvListDonors.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListDonors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cbFilterBy.SelectedIndex = 0;
            dgvListDonors.Columns[0].HeaderText = "Donor ID";
            dgvListDonors.Columns[0].Width = 100;

            dgvListDonors.Columns[1].HeaderText = "Full Name";
            dgvListDonors.Columns[1].Width = 300;


            dgvListDonors.Columns[2].HeaderText = "National No";
            dgvListDonors.Columns[2].Width = 100;


            dgvListDonors.Columns[3].HeaderText = "Weight";
            dgvListDonors.Columns[3].Width = 100;

            dgvListDonors.Columns[4].HeaderText = "Approved Medically";
            dgvListDonors.Columns[4].Width = 200;



        }
        private void frmManageDonors_Load(object sender, EventArgs e)
        {
            _RefreshDonorsList();
            dgvHeader();
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
                case "Donor ID":
                    FilterColumn = "DonorID";
                    break;

                case "Full Name":
                    FilterColumn = "Full Name";
                    break;

                case "Weight":
                    FilterColumn = "Weight";
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
                _dtDonors.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListDonors.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "DonorID"|| FilterColumn == "Weight")
                //in this case we deal with integer not string.

                _dtDonors.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtDonors.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = _dtDonors.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Donor ID"||cbFilterBy.Text == "Height"|| cbFilterBy.Text == "Weight")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddDonor_Click(object sender, EventArgs e)
        {
            frmAddUpdateDonor frmAddUpdateDonor = new frmAddUpdateDonor();
            frmAddUpdateDonor.ShowDialog();
            _RefreshDonorsList();
        }

        private void dgvListDonors_DoubleClick(object sender, EventArgs e)
        {
            int DonorID = (int)dgvListDonors.CurrentRow.Cells[0].Value;
            frmShowDonor frmShowDonor = new frmShowDonor(DonorID);
            frmShowDonor.ShowDialog();
            _RefreshDonorsList();
        }

        private void cmShowDonor_Click(object sender, EventArgs e)
        {
            int DonorID = (int)dgvListDonors.CurrentRow.Cells[0].Value;
            frmShowDonor frmShowDonor = new frmShowDonor(DonorID);
            frmShowDonor.ShowDialog();
            _RefreshDonorsList();
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            int DonorID = (int)dgvListDonors.CurrentRow.Cells[0].Value;
            frmAddUpdateDonor frmAddUpdateDonor = new frmAddUpdateDonor(DonorID);
            frmAddUpdateDonor.ShowDialog();
            _RefreshDonorsList();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int DonorID = (int)dgvListDonors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Donor With ID " + DonorID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsDonor.Delete(DonorID))
                {

                    MessageBox.Show("Donor With Donor " + DonorID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshDonorsList();

                }
                else
                {
                    MessageBox.Show("Donor With Donor " + DonorID + " Was Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cmDonate_Click(object sender, EventArgs e)
        {
            int DonorID = (int)dgvListDonors.CurrentRow.Cells[0].Value;
            frmDonate Donate = new frmDonate(DonorID);
            Donate.ShowDialog();
            _RefreshDonorsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].WindowState = FormWindowState.Maximized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[2].WindowState = FormWindowState.Normal;
        }
    }
}
