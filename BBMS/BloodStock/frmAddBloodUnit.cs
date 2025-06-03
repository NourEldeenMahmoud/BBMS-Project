using BBMS.Donations;
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

namespace BBMS
{
    public partial class frmAddBloodUnit : Form
    {
        private DataTable _dtNurses = clsDonation.GetAllNurses();
        private DataTable _dtAllValidDonors = clsDonor.GetAllValidDonors();
        private int _DonorID = -1;
        private int _NurseID = -1;
        private clsDonation _Donation;
        private clsBloodStock _BloodUnit;
        private clsDonor _Donor;
        public frmAddBloodUnit()
        {
            InitializeComponent();
        }
        private void frmAddBloodUnit_Load(object sender, EventArgs e)
        {
            _RefreshDonorsList();
            _dgvDonorsHeader();
            _RefreshNursesList();
            _dgvNursesHeader();

            _Donation = new clsDonation();
            _BloodUnit = new clsBloodStock();

        }
        private void _RefreshNursesList()
        {
            _dtNurses = clsDonation.GetAllNurses();
            dgvListNurses.DataSource = _dtNurses;

        }

        private void _dgvNursesHeader()
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
        private void _RefreshDonorsList()
        {
            _dtAllValidDonors = _dtAllValidDonors = clsDonor.GetAllValidDonors();
            dgvValidDonors.DataSource = _dtAllValidDonors;

        }

        private void _dgvDonorsHeader()
        {
            if (dgvValidDonors.Rows.Count>0)
            {
                dgvValidDonors.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dgvValidDonors.Columns[0].HeaderText = "Donor ID";
                dgvValidDonors.Columns[0].Width = 100;

                dgvValidDonors.Columns[1].HeaderText = "Full Name";
                dgvValidDonors.Columns[1].Width = 350;

                dgvValidDonors.Columns[2].HeaderText = "height";
                dgvValidDonors.Columns[2].Width = 100;

                dgvValidDonors.Columns[2].HeaderText = "Weight";
                dgvValidDonors.Columns[2].Width = 100;

                dgvValidDonors.Columns[3].HeaderText = "Qualified Donor";
                dgvValidDonors.Columns[3].Width = 100;
            }
            




        }

        private void _FillDonation()
        {
            _Donation.DonationDate = DateTime.Now;
            _Donation.BloodVolume = Convert.ToDecimal(txtBloodVolume.Text.Trim());
            _Donation.DonorID = _DonorID;
            _Donation.NurseID = _NurseID;


        }
        private void _FillUnit()
        {
            _BloodUnit.BloodType = "Not Yet Determined";
            _BloodUnit.ExpirationDate = DateTime.Now.AddMonths(3);
            _BloodUnit.TestStatus = clsBloodStock.enTestStatus.NotTestedYet;
            _BloodUnit.CurrentStatus = clsBloodStock.enCurrentStatus.Pending;
            _BloodUnit.DonationID = _Donation.DonationID;


        }
        private void _LoadDonorDetails()
        {

            lblDonorIDValue.Text = _Donor.DonorID.ToString();
            string BloodType = clsBloodStock.GetDonorBloodType(_Donor.DonorID);
            lblBloodTypeValue.Text = string.IsNullOrEmpty(BloodType) ? "Not Tested Yet" : BloodType;
            lblHeightValue.Text = _Donor.Height.ToString();
            lblWeightValue.Text = _Donor.Weight.ToString();
            if (_Donor.MedicalRecord != null)
            {
                lblMedicalRecoredValue.Text = _Donor.MedicalRecord;
            }
            else
            {
                lblMedicalRecord.Text = "None";
            }

            if (_Donor.CanDonate)
            {
                lblCanDonateValue.Text = "Yes";
            }
            else
            {
                lblCanDonateValue.Text = "No";
            }
            lblLastDonation.Text = _Donor.LastDonationDate?.ToString("dd/MM/yyyy") ?? "None";
        }
        private void _LoadDonation()
        {

            lblDonorIDValue.Text = _DonorID.ToString();
            lblDonorNameValue.Text = _Donation.DonorData.PersonData.FullName();
            lblDonatinoDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (_DonorID != -1)
            {
                if (!clsDonor.IsAbleToDonate(_DonorID))
                {

                    MessageBox.Show("Selected Donor Cannot Donate, choose another one.", "Select another Donor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tpDonationInfo.Enabled = false;

                }
                else
                {
                    btnNext.Enabled = true;
                    tcAddDonation.SelectedIndex = 1;
                    _LoadDonation();
                }
            }
            else
            {
                MessageBox.Show("Please Select A Donor.", "Select A Donor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tpDonationInfo.Enabled = false;
            }

        }

        private void btnDonate_Click(object sender, EventArgs e)
        {
            if (_NurseID == -1)
            {
                MessageBox.Show("You Need To Choose A Nurse , Choose By Clicking The Nurse", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_DonorID == -1)
            {
                MessageBox.Show("You Need To Choose A Donor , Choose By Clicking The Nurse", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!this.ValidateChildren())
            {
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

        private void cmChooseNurse_Click(object sender, EventArgs e)
        {
            _NurseID = (int)dgvListNurses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _NurseID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {

                _Donation.NurseID = _NurseID;
                btnDonate.Enabled = true;

            }
        }

        private void cmChooseDonor_Click(object sender, EventArgs e)
        {
            _DonorID = (int)dgvValidDonors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Donor With ID " + _DonorID + " To Donate Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Donor = clsDonor.Find(_DonorID);
                if (_Donor != null)
                {
                    _Donation.DonorID = _DonorID;
                    _Donation.DonorData = _Donor;
                    _LoadDonorDetails();
                    btnNext.Enabled = true;
                }

            }
        }

        private void tcAddDonation_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tpDonationInfo)
            {
                if (_DonorID != 1)
                {
                    if (!clsDonor.IsAbleToDonate(_DonorID))
                    {


                        tpDonationInfo.Enabled = false;
                        btnNext.Enabled = false;
                    }
                    else
                    {
                        _LoadDonation();
                        btnNext.Enabled = true;
                        tcAddDonation.SelectedIndex = 1;
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvValidDonors_DoubleClick(object sender, EventArgs e)
        {
            _DonorID = (int)dgvValidDonors.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Donor With ID " + _DonorID + " To Donate Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Donor = clsDonor.Find(_DonorID);
                if (_Donor!=null)
                {
                    _Donation.DonorID = _DonorID;
                    _Donation.DonorData = _Donor;
                    _LoadDonorDetails();
                    btnNext.Enabled = true;
                }
            }
        }

        private void btnAddUnit_Click(object sender, EventArgs e)
        {
            frmAddUpdateDonor AddUpdateDonor = new frmAddUpdateDonor();
            AddUpdateDonor.ShowDialog();
        }
    }
}
