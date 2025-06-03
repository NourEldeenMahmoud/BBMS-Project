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
    public partial class frmAddUpdateDonor : Form
    {
        int _DonorID = -1;
        clsDonor _Donor;
        public frmAddUpdateDonor()
        {
            InitializeComponent();
        }
        public frmAddUpdateDonor(int DonorID)
        {
            InitializeComponent();
            _DonorID = DonorID;
        }
        private void _Header()
        {
            if (_DonorID == -1)
            {
                lblTitle.Text = "Add Donor";
            }
            else
            {
                lblTitle.Text = "Update Donor";
            }

        }

        private void _FillDonor()
        {
            _Donor.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Donor.Height =Convert.ToDecimal( txtHeight.Text);
            _Donor.Weight = Convert.ToDecimal(txtWeight.Text);
            if (!dtpLastDonation.Enabled)
            {
                _Donor.LastDonationDate = null;
            }
            else
            {
                _Donor.LastDonationDate = dtpLastDonation.Value;
            }
           _Donor.MedicalRecord = txtMedicalRecord.Text;
            _Donor.CanDonate = chkMedicallyApproved.Checked;
        }
        private void _LoadDonor()
        {
            if (_Donor.Mode == clsDonor.enMode.Update)
            {
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            ctrlPersonCardWithFilter1.LoadPerson(_Donor.PersonID);
            lblDonorIDValue.Text = _Donor.DonorID.ToString();
            txtHeight.Text = _Donor.Height.ToString();
            txtWeight.Text = _Donor.Weight.ToString();
            if (_Donor.LastDonationDate==null)
            {
                chkDonatedBefore.Checked = false;
                dtpLastDonation.Enabled = false;

            }
            chkMedicallyApproved.Checked = _Donor.CanDonate;
            txtMedicalRecord.Text = _Donor.MedicalRecord.ToString();

        }
        private void frmAddUpdateDonor_Load(object sender, EventArgs e)
        {
           
            dtpLastDonation.MaxDate = DateTime.Now;
            dtpLastDonation.MinDate = DateTime.Now.AddYears(-5);
            dtpLastDonation.Value = DateTime.Now.AddHours(-1);
           
            
            _Header();
            if (_DonorID == -1)
            {
                _Donor = new clsDonor();
                _Donor.Mode = clsDonor.enMode.AddNew;
                tpDonorInfo.Enabled = false;
            }
            else
            {
                _Donor = clsDonor.Find(_DonorID);

                if (_Donor != null)
                {
                    _Donor.Mode = clsDonor.enMode.Update;
                    _LoadDonor();
                }
                else
                {
                    MessageBox.Show("Donor With ID" + _DonorID + "Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }

            }

        }
      
        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsDonor.IsDonorExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
            
                    MessageBox.Show("Selected Person Already IS A Donor, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.Focus();
                }
            
                else
                {
                    tpDonorInfo.Enabled = true;
                    btnNext.Enabled = true;
                }
            }


        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Donor.Mode==clsDonor.enMode.Update)
            {
                tpDonorInfo.Enabled = true;
                tcAddUpdateDonor.SelectedIndex = 1;
            }
            else
            {
                if (ctrlPersonCardWithFilter1.PersonID != -1)
                {
                    if (clsDonor.IsDonorExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                    {
                        ctrlPersonCardWithFilter1.Focus();
                        tpDonorInfo.Enabled = false;
                    }
                    else
                    {
                        tpDonorInfo.Enabled = true;
                    }
                }

                tcAddUpdateDonor.SelectedIndex = 1;
            }
          

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillDonor();
            if (_Donor.Save())
            {
                lblDonorIDValue.Text = _Donor.DonorID.ToString();
                //change form mode to update.
                _Donor.Mode = clsDonor.enMode.Update;
                _Header();
                this.Text = "Update Donor";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddUpdateDonor.SelectedIndex = 0;
            tpDonorInfo.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnDonatedBefore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDonatedBefore.Checked)
            {
                dtpLastDonation.Enabled = true;
            }
            else
            {
                dtpLastDonation.Enabled = false;
            }
           
        }

        private void txtWeight_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtWeight.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtWeight, "Weight cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtWeight, null);
            }
        }

        private void txtHeight_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHeight.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtHeight, "Height cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtHeight, null);
            }
        }

        private void tcAddUpdateDonor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddUpdateDonor.SelectedIndex==1)
            {
                btnNext_Click(this, EventArgs.Empty);
            }
        }
    }
}
