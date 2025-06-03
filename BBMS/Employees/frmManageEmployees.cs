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

namespace BBMS.Employees
{
    public partial class frmManageEmployees : Form
    {
        private DataTable _dtEmployees = clsEmployee.GetAllEmployees();
        public frmManageEmployees()
        {
            InitializeComponent();
        }
        private void _RefreshEmployeesList()
        {
            _dtEmployees = clsEmployee.GetAllEmployees();

            dgvListEmployees.DataSource = _dtEmployees;
            lblNumberOfRecords.Text = dgvListEmployees.Rows.Count.ToString();
        }
        private void dgvHeader()
        {
            dgvListEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListEmployees.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            cbFilterBy.SelectedIndex = 0;
            dgvListEmployees.Columns[0].HeaderText = "Employee ID";
            dgvListEmployees.Columns[0].Width = 100;

            dgvListEmployees.Columns[1].HeaderText = "Full Name";
            dgvListEmployees.Columns[1].Width = 350;


            dgvListEmployees.Columns[2].HeaderText = "National No";
            dgvListEmployees.Columns[2].Width = 100;

            dgvListEmployees.Columns[3].HeaderText = "Role";
            dgvListEmployees.Columns[3].Width = 100;

            dgvListEmployees.Columns[4].HeaderText = "System Access";
            dgvListEmployees.Columns[4].Width = 100;



        }
        private void frmManageEmployees_Load(object sender, EventArgs e)
        { 
            _RefreshEmployeesList();
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
                case "Employee ID":
                    FilterColumn = "EmployeeID";
                    break;

                case "Full Name":
                    FilterColumn = "Full Name";
                    break;

                case "Role":
                    FilterColumn = "Role";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "System Access":
                    FilterColumn = "CanLogin";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtEmployees.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListEmployees.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "EmployeeID")
                //in this case we deal with integer not string.

                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtEmployees.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = _dtEmployees.Rows.Count.ToString();
        }
        
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Employee ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            frmAddUpdateEmployee frmAddUpdateEmployee = new frmAddUpdateEmployee();
            frmAddUpdateEmployee.ShowDialog();
            _RefreshEmployeesList();
        }

        private void dgvListEmployees_DoubleClick(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmShowEmployee frmShowEmployee = new frmShowEmployee(EmployeeID);
            frmShowEmployee.ShowDialog();
            _RefreshEmployeesList();
        }

        private void cmShowEmployee_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmShowEmployee frmShowEmployee = new frmShowEmployee(EmployeeID);
            frmShowEmployee.ShowDialog();
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmAddUpdateEmployee frmAddUpdateEmployee = new frmAddUpdateEmployee(EmployeeID);
            frmAddUpdateEmployee.ShowDialog();
            _RefreshEmployeesList();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Employee With ID " + EmployeeID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsEmployee.Delete(EmployeeID))
                {

                    MessageBox.Show("Employee With ID " + EmployeeID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshEmployeesList();

                }
                else
                {
                    MessageBox.Show("Employee With ID " + EmployeeID + " Was Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void cmChangePassword_Click(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmChangePassword frmChangePassword = new frmChangePassword(EmployeeID);
            frmChangePassword.ShowDialog();
            _RefreshEmployeesList();
        }

        private void dgvListEmployees_DoubleClick_1(object sender, EventArgs e)
        {
            int EmployeeID = (int)dgvListEmployees.CurrentRow.Cells[0].Value;
            frmShowEmployee frmShowEmployee = new frmShowEmployee(EmployeeID);
            frmShowEmployee.ShowDialog();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].WindowState = FormWindowState.Maximized;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].WindowState = FormWindowState.Normal;
        }
    }
}
