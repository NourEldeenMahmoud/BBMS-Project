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

namespace BBMS.Transfusion
{
    public partial class frmChooseManually : Form
    {
        private List<string> _MatchList;
        private int _BloodUnitID=-1;
        private DataTable _dtUnits;

        public delegate void DataBackEventHandler(object sender, int BloodUnitID);
        public event DataBackEventHandler DataBack;


        public frmChooseManually(List<string> MatchList)
        {
            InitializeComponent();
            _MatchList = MatchList;
        }
        private void _RefreshUnitsList()
        {
            _dtUnits = clsBloodStock.GetAllCompatibleUnits(_MatchList);

            dgvListUnits.DataSource = _dtUnits;
            lblNumberOfRecords.Text = dgvListUnits.Rows.Count.ToString();

        }
        private void _dgvHeader()
        {
            dgvListUnits.Columns[0].HeaderText = "Blood Unit ID";
            dgvListUnits.Columns[0].Width = 80;

            dgvListUnits.Columns[1].HeaderText = "Donor Name";
            dgvListUnits.Columns[1].Width = 350;

            dgvListUnits.Columns[2].HeaderText = "Blood Type";
            dgvListUnits.Columns[2].Width = 150;

            dgvListUnits.Columns[3].HeaderText = "Expiration Date";
            dgvListUnits.Columns[3].Width = 130;

            dgvListUnits.Columns[4].HeaderText = "Test Status";
            dgvListUnits.Columns[4].Width = 130;

            dgvListUnits.Columns[5].HeaderText = "Current Status";
            dgvListUnits.Columns[5].Width = 130;
        }

        private void frmChooseManually_Load(object sender, EventArgs e)
        {
            _RefreshUnitsList();
            _dgvHeader();
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
                _dtUnits.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListUnits.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "BloodUnitID")
                //in this case we deal with integer not string.

                _dtUnits.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtUnits.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = dgvListUnits.Rows.Count.ToString();

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFilterBy.Text == "Blood Unit ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void dgvListUnits_DoubleClick(object sender, EventArgs e)
        {
            _BloodUnitID = (int)dgvListUnits.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _BloodUnitID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                DataBack?.Invoke(this, _BloodUnitID);
                this.Close();
            }

        }
    }
}
