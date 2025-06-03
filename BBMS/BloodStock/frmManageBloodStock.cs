using BBMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BBMS.BloodStock
{
    public partial class frmManageBloodStock : Form
    {
        public frmManageBloodStock()
        {
            InitializeComponent();
        }

        private static DataTable _dtBloodStock = clsBloodStock.GetAllUnits();
        private void _RefreshStockList()
        {
            _dtBloodStock = clsBloodStock.GetAllUnits();
            dgvListBloodStock.DataSource = _dtBloodStock;
            lblNumberOfRecords.Text = dgvListBloodStock.Rows.Count.ToString();
        }

        private void dgvHeader()
        {

            dgvListBloodStock.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListBloodStock.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
           
            dgvListBloodStock.Columns[0].HeaderText = "Blood Unit ID";
            dgvListBloodStock.Columns[0].Width = 80;

            dgvListBloodStock.Columns[1].HeaderText = "Donor Name";
            dgvListBloodStock.Columns[1].Width = 350;

            dgvListBloodStock.Columns[2].HeaderText = "Blood Type";
            dgvListBloodStock.Columns[2].Width = 150;

            dgvListBloodStock.Columns[3].HeaderText = "Expiration Date";
            dgvListBloodStock.Columns[3].Width = 130;

            dgvListBloodStock.Columns[4].HeaderText = "Test Status";
            dgvListBloodStock.Columns[4].Width = 130;
            
            dgvListBloodStock.Columns[5].HeaderText = "Current Status";
            dgvListBloodStock.Columns[5].Width = 170;

        }

        private void frmManageBloodStock_Load(object sender, EventArgs e)
        {
            _RefreshStockList();
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
                case "Blood Unit ID":
                    FilterColumn = "BloodUnitID";
                    break;

                case "Donor Name":
                    FilterColumn = "Full Name";
                    break;

                case "Blood Type":
                    FilterColumn = "BloodType";
                    break;

                case "Test Status":
                    FilterColumn = "TestStatus";
                    break;

                case "Current Status":
                    FilterColumn = "CurrentStatus";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtBloodStock.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListBloodStock.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BloodUnitID")
                //in this case we deal with integer not string.

                _dtBloodStock.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtBloodStock.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = dgvListBloodStock.Rows.Count.ToString();

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Blood Unit ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void cmShowBloodUnit_Click(object sender, EventArgs e)
        {
            int BloodUnitID = (int)dgvListBloodStock.CurrentRow.Cells[0].Value;
            frmShowBloodUnit ShowBloodUnit = new frmShowBloodUnit(BloodUnitID);
            ShowBloodUnit.ShowDialog();
        }

        private void cmTestBloodUnit_Click(object sender, EventArgs e)
        {
            int BloodUnitID = (int)dgvListBloodStock.CurrentRow.Cells[0].Value;
            frmTestBlood Test = new frmTestBlood(BloodUnitID);
            Test.ShowDialog();
            _RefreshStockList();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int BloodUnitID = (int)dgvListBloodStock.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Blood Unit With ID " + BloodUnitID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsBloodStock.Delete(BloodUnitID))
                {

                    MessageBox.Show("Person With Blood Unit " + BloodUnitID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshStockList();

                }
                else
                {
                    MessageBox.Show("Person With Blood Unit " + BloodUnitID + " Was Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            _RefreshStockList();
        }

        private void dgvListBloodStock_DoubleClick(object sender, EventArgs e)
        {
            int BloodUnitID = (int)dgvListBloodStock.CurrentRow.Cells[0].Value;
            frmShowBloodUnit ShowBloodUnit = new frmShowBloodUnit(BloodUnitID);
            ShowBloodUnit.ShowDialog();
        }

        private void cmBloodStockDetails_Opening(object sender, CancelEventArgs e)
        {
            int BloodUnitID = (int)dgvListBloodStock.CurrentRow.Cells[0].Value;
            if (clsBloodStock.IsBloodUnitTested(BloodUnitID))
            {
                cmTestBloodUnit.Enabled = false;
            }
            else
            {
                cmTestBloodUnit.Enabled = true;
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            frmAddBloodUnit AddBloodUnit = new frmAddBloodUnit();
            AddBloodUnit.ShowDialog();
            _RefreshStockList();
        }

        private void btnClose_Click(object sender, EventArgs e)
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
