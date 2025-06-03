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

namespace BBMS.BloodStock
{
    public partial class frmTestBlood : Form
    {
        private int _BloodUnitID = -1;
        private clsBloodStock _BloodUnit;
        public frmTestBlood(int BloodUnitID)
        {
            InitializeComponent();
            _BloodUnitID = BloodUnitID;
        }
        public frmTestBlood()
        {
            InitializeComponent();
            
        }
        private string _GetSelectedRadioResult(Control container)
        {
            // we give the function the name of the panel , it returns wheather if its positive or negative
            var selected = container.Controls
                .OfType<Guna2CustomRadioButton>()
                .FirstOrDefault(r => r.Checked);

            return selected?.Name ;
        }

        private bool _GetTestResults()
        {
            //returns true if the test has no issues
            string ResultNotes = "";
            bool Result = true;
            if (_GetSelectedRadioResult(HCVPanel)=="rbPositiveHCV")
            {
                ResultNotes += string.IsNullOrEmpty(ResultNotes) ? "HCV : Positive" : " --- HCV : Positive";
                Result = false;
            }
            if (_GetSelectedRadioResult(HBVPenel) == "rbPositiveHBV")
            {
                ResultNotes += string.IsNullOrEmpty(ResultNotes) ? "HBV : Positive" : " --- HBV : Positive";
                Result = false;
            }
            if (_GetSelectedRadioResult(HIVPanel) == "rbPositiveHIV")
            {
                ResultNotes += string.IsNullOrEmpty(ResultNotes) ? "HIV : Positive" : " --- HIV : Positive";
                Result = false;
            }
            if (_GetSelectedRadioResult(SyphilisPanel) == "rbPositiveSyphilis")
            {
                ResultNotes += string.IsNullOrEmpty(ResultNotes) ? "Syphilis : Positive" : "--- Syphilis : Positive";
                Result = false;
            }

            if (string.IsNullOrEmpty(ResultNotes))
            {
                ResultNotes = "All Tests Are Negative, Blood Unit Approved";
                Result = true;
            }

            if (string.IsNullOrEmpty(txtNotes.Text))
            {
                _BloodUnit.Notes = ResultNotes;
            }
            else
            {
                _BloodUnit.Notes = txtNotes.Text + " --- " + ResultNotes;
            }

            return Result;

        }//Approved=>true


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lbl_Click(object sender, EventArgs e)
        {
            Label clickedLabel = sender as Label;

            if (clickedLabel == null) return;

            string labelName = clickedLabel.Name;

            string radioButtonName = labelName.Replace("lbl", "rb");

            Control parentControl = clickedLabel.Parent;

            if (parentControl != null)
            {
                Control[] foundControls = parentControl.Controls.Find(radioButtonName, true);

                if (foundControls.Length > 0 && foundControls[0] is Guna2CustomRadioButton rb)
                {
                    rb.Checked = true;
                }
            }
        }

        private void _TestBloodUnit()
        {
            _BloodUnit.BloodType = cbBloodType.SelectedItem.ToString();
            _BloodUnit.TestStatus = _GetTestResults() ? clsBloodStock.enTestStatus.Accepted : clsBloodStock.enTestStatus.Rejected;
            if (_BloodUnit.TestStatus== clsBloodStock.enTestStatus.Accepted && _BloodUnit.ExpirationDate>DateTime.Now)
            {
                _BloodUnit.CurrentStatus = clsBloodStock.enCurrentStatus.Qualified;
            }
            else
            {
                _BloodUnit.CurrentStatus = clsBloodStock.enCurrentStatus.Disposed;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            if (!ValidateAllPanels())
            {
                MessageBox.Show("Some fileds are not Valid !", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
          
            DialogResult result = MessageBox.Show("Are you sure the blood test data is correct before saving ?", "Are You Sure ?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result==DialogResult.OK)
            {
                _TestBloodUnit();
                if (_BloodUnit.Save())
                {
                    txtNotes.Text = _BloodUnit.Notes.ToString();
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   
            }
          
        }

        private void frmTestBlood_Load(object sender, EventArgs e)
        {

            if (clsBloodStock.IsBloodUnitTested(_BloodUnitID))
            {
                MessageBox.Show("Blood Unit With ID" + _BloodUnitID + "Is Already Tested", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            _BloodUnit = clsBloodStock.Find(_BloodUnitID);

            if (_BloodUnit != null)
            {
                _BloodUnit.Mode = clsBloodStock.enMode.Update;
                
            }
            else
            {
                MessageBox.Show("Blood Unit With ID" + _BloodUnitID + "Is Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            }

        private void cbBloodType_Validating(object sender, CancelEventArgs e)
        {
            if (cbBloodType.SelectedIndex==0)
            {
                e.Cancel = true;
                errorProvider1.SetError(cbBloodType, "Choose The Blood Type");
            }
            else
            {
                errorProvider1.SetError(cbBloodType, null);

            }
        }

        private void llblBloodUnitInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowBloodUnit ShowBloodUnit = new frmShowBloodUnit(_BloodUnitID);
            ShowBloodUnit.ShowDialog();
        }
        private bool ValidateAllPanels()
        {
            List<Panel> panels = new List<Panel> { HCVPanel, HBVPenel, HIVPanel, SyphilisPanel };

            foreach (var panel in panels)
            {
                bool isChecked = false;

                foreach (Control control in panel.Controls)
                {
                    if (control is Guna2CustomRadioButton radioButton && radioButton.Checked)
                    {
                        isChecked = true;
                        break;
                    }
                }

                if (!isChecked)
                {
                    return false;
                }
            }

            return true;
        }

     
    }
    
}
