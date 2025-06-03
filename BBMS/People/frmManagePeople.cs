using BBMS_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class frmManagePeople : Form
    {
        private static DataTable dtAllPeople = clsPerson.GetAllPeople();
        private DataTable _dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo","Full Name",
                                                      "GenderCaption", "DateOfBirth", "CountryName","Phone", "Email");
        public frmManagePeople()
        {
            InitializeComponent();
        }
        private void _RefreshPeoplList()
        {
            dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo","Full Name",
                                                       "GenderCaption", "DateOfBirth", "CountryName","Phone", "Email");

            dgvListPeople.DataSource = _dtPeople;
            lblNumberOfRecords.Text = dgvListPeople.Rows.Count.ToString();
        }
        
        private void dgvHeader()
        {

            dgvListPeople.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListPeople.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cbFilterBy.SelectedIndex = 0;
            dgvListPeople.Columns[0].HeaderText = "Person ID";
            dgvListPeople.Columns[0].Width = 100;

            dgvListPeople.Columns[1].HeaderText = "National No.";
            dgvListPeople.Columns[1].Width = 120;


            dgvListPeople.Columns[2].HeaderText = "Full Name";
            dgvListPeople.Columns[2].Width = 350;

            dgvListPeople.Columns[3].HeaderText = "Gendor";
            dgvListPeople.Columns[3].Width = 120;

            dgvListPeople.Columns[4].HeaderText = "Date Of Birth";
            dgvListPeople.Columns[4].Width = 140;

            dgvListPeople.Columns[5].HeaderText = "Nationality";
            dgvListPeople.Columns[5].Width = 120;


            dgvListPeople.Columns[6].HeaderText = "Phone";
            dgvListPeople.Columns[6].Width = 120;


            dgvListPeople.Columns[7].HeaderText = "Email";
            dgvListPeople.Columns[7].Width = 170;
        }
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeoplList();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "Full Name";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "GenderCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = dgvListPeople.Rows.Count.ToString();
        
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAdd = new frmAddUpdatePerson();
            frmAdd.ShowDialog();
            _RefreshPeoplList();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cmShowDetails_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;

            frmPersonCardDetails frmPersonCardDetails = new frmPersonCardDetails(PersonID);
            frmPersonCardDetails.ShowDialog();
           

        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Person With ID " + PersonID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.Delete(PersonID))
                {

                    MessageBox.Show("Person With PersonID " + PersonID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeoplList();

                }
                else
                {
                    MessageBox.Show("Person With PersonID " + PersonID + " Was Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;
            frmAddUpdatePerson frmAddPerson = new frmAddUpdatePerson(PersonID);
            frmAddPerson.ShowDialog();
            _RefreshPeoplList();

        }

        private void dgvListPeople_DoubleClick(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells[0].Value;

            frmPersonCardDetails frmPersonCardDetails = new frmPersonCardDetails(PersonID);
            frmPersonCardDetails.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
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
