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

namespace BBMS.People
{
    public partial class frmShowAllPeople : Form
    {
        public frmShowAllPeople()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllPeople = clsPerson.ShowAllPeople();

        private void _RefreshPeoplList()
        {
            _dtAllPeople = clsPerson.ShowAllPeople();
            
            dgvListPeople.DataSource = _dtAllPeople;
            lblNumberOfRecords.Text = dgvListPeople.Rows.Count.ToString();
        }

        private void dgvHeader()
        {

            dgvListPeople.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListPeople.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cbFilterBy.SelectedIndex = 0;
            dgvListPeople.Columns[0].HeaderText = "Person ID";
            dgvListPeople.Columns[0].Width = 90;

            dgvListPeople.Columns[1].HeaderText = "National No.";
            dgvListPeople.Columns[1].Width = 100;


            dgvListPeople.Columns[2].HeaderText = "Full Name";
            dgvListPeople.Columns[2].Width = 300;

            dgvListPeople.Columns[3].HeaderText = "Gender";
            dgvListPeople.Columns[3].Width = 90;

            dgvListPeople.Columns[4].HeaderText = "Phone";
            dgvListPeople.Columns[4].Width = 120;


            dgvListPeople.Columns[5].HeaderText = "Nationality";
            dgvListPeople.Columns[5].Width = 150;

        }
        private void frmShowAllPeople_Load(object sender, EventArgs e)
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

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "Full Name";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gender":
                    FilterColumn = "Gender";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllPeople.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListPeople.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "PersonID")
                //in this case we deal with integer not string.

                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtAllPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

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

        
    }
}
