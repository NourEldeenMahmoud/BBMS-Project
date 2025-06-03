using BBMS.Patients;
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
    public partial class frmManageTransfusions : Form
    {
        private DataTable _dtAllTransfusions = clsTransfusion.GetAllTransfusions();
        public frmManageTransfusions()
        {
            InitializeComponent();
        }
        private void frmManageTransfusions_Load(object sender, EventArgs e)
        {
            _RefreshTransfusionsList();
            dgvHeader();
        }
        private void _RefreshTransfusionsList()
        {
            _dtAllTransfusions = clsTransfusion.GetAllTransfusions();

            dgvListTransfusions.DataSource = _dtAllTransfusions;
            lblNumberOfRecords.Text = dgvListTransfusions.Rows.Count.ToString();
        }
        private void dgvHeader()
        {
            dgvListTransfusions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 17, FontStyle.Bold);
            dgvListTransfusions.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvListTransfusions.Columns[0].HeaderText = "Transfusion ID";
            dgvListTransfusions.Columns[0].Width = 80;

            dgvListTransfusions.Columns[1].HeaderText = "Patient Name";
            dgvListTransfusions.Columns[1].Width = 300;

            dgvListTransfusions.Columns[2].HeaderText = "Medical Condition";
            dgvListTransfusions.Columns[2].Width = 200;

            dgvListTransfusions.Columns[3].HeaderText = "Volume Requested";
            dgvListTransfusions.Columns[3].Width = 80;

            dgvListTransfusions.Columns[4].HeaderText = "Transfusion Status";
            dgvListTransfusions.Columns[4].Width = 220;




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
                case "Transfusion ID":
                    FilterColumn = "TransfusionID";
                    break;

                case "Patient Name":
                    FilterColumn = "PatientName";
                    break;

                case "Medical Condition":
                    FilterColumn = "MedicalCondition";
                    break;

                case "Requested Volume":
                    FilterColumn = "QuantityRequested";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllTransfusions.DefaultView.RowFilter = "";
                lblNumberOfRecords.Text = dgvListTransfusions.Rows.Count.ToString();
                return;
            }


            if (FilterColumn == "TransfusionID"|| FilterColumn == "QuantityRequested")
                //in this case we deal with integer not string.

                _dtAllTransfusions.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtSearch.Text.Trim());
            else
                _dtAllTransfusions.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtSearch.Text.Trim());

            lblNumberOfRecords.Text = _dtAllTransfusions.Rows.Count.ToString();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Transfusion ID" || cbFilterBy.Text == "Requested Volume")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      

        private void btnAddRequest_Click(object sender, EventArgs e)
        {
            frmAddUpdateTransfusionRequest AddRequest = new frmAddUpdateTransfusionRequest();
            AddRequest.ShowDialog();
            _RefreshTransfusionsList();
        }

        private void dgvListTransfusions_DoubleClick(object sender, EventArgs e)
        {
            int TransfusionID= (int)dgvListTransfusions.CurrentRow.Cells[0].Value;
            frmShowTransfusionDetails ShowTransfusionDetails = new frmShowTransfusionDetails(TransfusionID);
            ShowTransfusionDetails.ShowDialog();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            int TransfusionID = (int)dgvListTransfusions.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are You Sure You Want To Delete Transfusion Request With ID " + TransfusionID + " ?!", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsTransfusion.Delete(TransfusionID))
                {

                    MessageBox.Show("Transfusion Request With ID " + TransfusionID + " Is Deleted Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshTransfusionsList();

                }
                else
                {
                    MessageBox.Show("Transfusion Request With ID " + TransfusionID + " Is Not Deleted", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            _RefreshTransfusionsList();
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            int TransfusionID = (int)dgvListTransfusions.CurrentRow.Cells[0].Value;
            frmAddUpdateTransfusionRequest UpdateTransfusionRequest = new frmAddUpdateTransfusionRequest(TransfusionID);
            UpdateTransfusionRequest.ShowDialog();
            _RefreshTransfusionsList();
        }

        private void cmShow_Click(object sender, EventArgs e)
        {
            int TransfusionID = (int)dgvListTransfusions.CurrentRow.Cells[0].Value;
            frmShowTransfusionDetails ShowTransfusionDetails = new frmShowTransfusionDetails(TransfusionID);
            ShowTransfusionDetails.ShowDialog();
        }

        private void makeTransfusionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TransfusionID = (int)dgvListTransfusions.CurrentRow.Cells[0].Value;
            frmMakeTransfusion MakeTransfusion = new frmMakeTransfusion(TransfusionID);
            MakeTransfusion.ShowDialog();
            _RefreshTransfusionsList();
        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            int TransfusionID = (int)dgvListTransfusions.CurrentRow.Cells[0].Value;
            clsTransfusion Transfusion = clsTransfusion.Find(TransfusionID);
            if (Transfusion.TransfusionStatus == 1)
            {
                makeTransfusionToolStripMenuItem.Enabled = false;
                cmEdit.Enabled = false;
            }
            
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
