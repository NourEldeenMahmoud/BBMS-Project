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

namespace BBMS.Employees
{
    public partial class frmAddUpdateEmployee : Form
    {
        int _EmployeeID=-1;
        clsEmployee _Employee;
        public frmAddUpdateEmployee()
        {
            InitializeComponent();
        }
        public frmAddUpdateEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
        }
        private void _Header()
        {
            if (_EmployeeID == -1)
            {
                lblTitle.Text = "Add User";
            }
            else
            {
                lblTitle.Text = "Update User";
            }

        }
        private void _FillUser()
        {
            _Employee.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _Employee.Role = cbRole.Text;
            _Employee.UserName = txtUserName.Text;
            _Employee.Password = txtPassword.Text;
            _Employee.CanLogin = chkCanLogin.Checked;
        }
        private void _LoadUserData()
        {
            if (_Employee.Mode==clsEmployee.enMode.Update)
            {
                
                ctrlPersonCardWithFilter1.FilterEnabled = false;
            }
            ctrlPersonCardWithFilter1.LoadPerson(_Employee.PersonID);          
            lblEmployeeIDValue.Text = _Employee.EmployeeID.ToString();
            txtUserName.Text = _Employee.UserName;
            txtPassword.Text = _Employee.Password;
            txtConfirmPassword.Text = _Employee.Password;
            chkCanLogin.Checked = _Employee.CanLogin;
            cbRole.SelectedIndex = cbRole.FindString(_Employee.Role);

        }
        private void frmAddUpdateEmployee_Load(object sender, EventArgs e)
        { 
            _Header();
            if (_EmployeeID == -1)
            {
                _Employee = new clsEmployee();
                _Employee.Mode = clsEmployee.enMode.AddNew;
                tpEmployee.Enabled = false;
            }
            else
            {
                _Employee = clsEmployee.Find(_EmployeeID);

                if (_Employee!=null)
                {
                    _Employee.Mode = clsEmployee.enMode.Update;
                    _LoadUserData();
                }
                else
                {
                    MessageBox.Show("Employee With ID"+ _EmployeeID+"Is Not Found","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    this.Close();
                }
               
            }

        }
        private void tpUserInfo_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            


            if (_Employee.Mode == clsEmployee.enMode.AddNew)
            {

                if (clsEmployee.IsEmployeeExist(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "username is used by another Employee");
                }
                else
                {
                    errorProvider1.SetError(txtUserName, null);
                };
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_Employee.UserName != txtUserName.Text.Trim())
                {
                    if (clsEmployee.IsEmployeeExist(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "username is used by another Employee");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(txtUserName, null);
                    };
                }
            }
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            if (ctrlPersonCardWithFilter1.PersonID!=-1)
            {
                if (clsEmployee.IsEmployeeExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
            
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.Focus();
                }
            
                else
                {
                    tpEmployee.Enabled = true;
                    btnNext.Enabled = true;
                }
            }
            
          
        }

       
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsEmployee.IsEmployeeExistByPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    tpEmployee.Enabled = false;
                    ctrlPersonCardWithFilter1.Focus();
                }
          
                else
                {
                    tpEmployee.Enabled = true;
                   
                }
                tcAddUpdateEmployee.SelectedIndex = 1;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not Valid!, put the mouse over the red icon(s) to see the erro","Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillUser();
            if (_Employee.Save())
            {
                lblEmployeeID.Text = _Employee.EmployeeID.ToString();
                //change form mode to update.
                _Employee.Mode = clsEmployee.enMode.Update;
                _Header();
                this.Text = "Update User";

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
            tcAddUpdateEmployee.SelectedIndex = 0;
            tpEmployee.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tcAddUpdateEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddUpdateEmployee.SelectedIndex==1)
            {
                btnNext_Click(this, EventArgs.Empty);
            }
            
        }
    }
}
