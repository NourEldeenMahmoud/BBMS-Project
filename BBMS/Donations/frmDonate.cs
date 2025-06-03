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

namespace BBMS.Donations
{
    public partial class frmDonate : Form
    {
        private DataTable _dtNurses = clsDonation.GetAllNurses();
        private int _DonorID = -1;
        private int _NurseID = -1;
        private clsDonation _Donation;
        private clsBloodStock _BloodUnit;
        public frmDonate()
        {
            InitializeComponent();
        }
        public frmDonate(int DonorID)
        {
            InitializeComponent();
            _DonorID = DonorID;
        }

        private void _RefreshNursesList()
        {
            _dtNurses = clsDonation.GetAllNurses();
            dgvListNurses.DataSource = _dtNurses;

        }

        private void _dgvHeader()
        {
          
            dgvListNurses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvListNurses.Columns[0].HeaderText = "Employee ID";
            dgvListNurses.Columns[0].Width = 100;

            dgvListNurses.Columns[1].HeaderText = "Full Name";
            dgvListNurses.Columns[1].Width = 350;

            dgvListNurses.Columns[2].HeaderText = "National No";
            dgvListNurses.Columns[2].Width = 100;
            dgvListNurses.Columns[3].HeaderText = "Role";
            dgvListNurses.Columns[3].Width = 100;




        }

        private void frmDonate_Load(object sender, EventArgs e)
        {

            if (!clsDonor.IsAbleToDonate(_DonorID))
            {
                MessageBox.Show("Selected Donor Cannot Donate, choose another one.", "Select another Donor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            _RefreshNursesList();
            _dgvHeader();
            _Donation = new clsDonation();
            _BloodUnit = new clsBloodStock();
            ctrlDonorCard1.Sep.Visible=false;
            ctrlDonorCard1.ControlBoxClose.Visible = false;
            ctrlDonorCard1.ControlBoxCloseMini.Visible = false;
            ctrlDonorCard1.TextTitle.Text = "";

            if (_DonorID != -1)
            {
                _Donation.DonorData = clsDonor.Find(_DonorID);
                ctrlDonorCard1.LoadDonor(_DonorID);
                _LoadDonation();
            }
            else
            {
                MessageBox.Show("Donor With ID" + _DonorID + "Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                tpDonationInfo.Enabled=false;
                btnNext.Enabled=false;
            }


        }

        private void _FillDonation()
        {
            _Donation.DonationDate= DateTime.Now;
            _Donation.BloodVolume= Convert.ToDecimal(txtBloodVolume.Text.Trim());
            _Donation.DonorID = _DonorID;
            _Donation.NurseID = _NurseID;
            

        }
        private void _FillUnit()
        {
            _BloodUnit.BloodType = "Not Yet Determined";
            _BloodUnit.ExpirationDate= DateTime.Now.AddMonths(3);
            _BloodUnit.TestStatus=clsBloodStock.enTestStatus.NotTestedYet;
            _BloodUnit.CurrentStatus=clsBloodStock.enCurrentStatus.Pending;
            _BloodUnit.DonationID = _Donation.DonationID;


        }

        private void _LoadDonation()
        {

            lblDonorIDValue.Text = _DonorID.ToString();
            lblDonorNameValue.Text = _Donation.DonorData.PersonData.FullName();
            lblDonatinoDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void btnNext_Click(object sender, EventArgs e)
        {

                if (_DonorID!=-1)
                {
                    if (!clsDonor.IsAbleToDonate(_DonorID))
                    {
                    
                        MessageBox.Show("Selected Donor Cannot Donate, choose another one.", "Select another Donor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tpDonationInfo.Enabled = false;
                        btnNext.Enabled = false;
                    }
                    else
                    {
                    
                        tcAddDonation.SelectedIndex = 1;
                    }
                }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_NurseID==-1)
            {
                MessageBox.Show("You Need To Choose A Nurse , Choose By Clicking The Nurse", "Choose",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return ;
            }
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            if (!clsDonor.IsAbleToDonate(_DonorID))
            {
                MessageBox.Show("Selected Donor Cannot Donate, choose another one.", "Select another Donor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillDonation();
            if (_Donation.Save())
            {
                _FillUnit();
                if (_BloodUnit.Save())
                {
                    lblDonationIDValue.Text = _Donation.DonationID.ToString();
                    lblNurseIDValue.Text = _Donation.NurseID.ToString();
                    MessageBox.Show("Donation Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnDonate.Enabled = false;
                }
               
            }
            else
            {
                MessageBox.Show("Error: Donation Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddDonation.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvListNurses_DoubleClick(object sender, EventArgs e)
        {
             _NurseID = (int)dgvListNurses.CurrentRow.Cells[0].Value;
            
            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _NurseID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Donation.NurseID = _NurseID;
                btnDonate.Enabled = true;
            }


        }

        private void chooseNurseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NurseID = (int)dgvListNurses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _NurseID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
               
                _Donation.NurseID = _NurseID;
                btnDonate.Enabled = true;

            }
        }

        private void tcAddDonation_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tcAddDonation.SelectedIndex == 1)
            {
                    if (!clsDonor.IsAbleToDonate(_DonorID))
                    {

                     
                        tpDonationInfo.Enabled = false;
                        btnNext.Enabled = false;
                    }
                    else
                    {

                        tcAddDonation.SelectedIndex = 1;
                    }
            }
        }

        private void txtBloodVolume_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtBloodVolume.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtBloodVolume, "Height cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtBloodVolume, null);
            }
        }

        private void txtBloodVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
