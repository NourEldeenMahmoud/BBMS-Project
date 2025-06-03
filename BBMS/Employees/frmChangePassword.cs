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
    public partial class frmChangePassword : Form
    {
        private int _EmployeeID = -1;
        private clsEmployee _Employee;
        public frmChangePassword(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID=EmployeeID;
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            
            if (_EmployeeID == -1)
            {
                _Employee = clsEmployee.Find(clsGlobal.LoggedInEmployee.EmployeeID);
                ctrlEmployeeCard1.LoadEmployee(clsGlobal.LoggedInEmployee.EmployeeID);

                
            }
            else
            {
                _Employee = clsEmployee.Find(_EmployeeID);
                if (_Employee == null)
                {
                    //Here we dont continue becuase the form is not valid
                    MessageBox.Show("Could not Find Employee with id = " + _EmployeeID,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();

                    return;
                }

            }
            _Employee.Mode = clsEmployee.enMode.Update;
            ctrlEmployeeCard1.LoadEmployee(_Employee.EmployeeID);

        }
        private void _ResetDefualtValues()
        {
            txtCurrentPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }
        private void guna2TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };

            if (_Employee.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNewPassword, "New Password cannot be blank");
            }
            else
            {
                errorProvider1.SetError(txtNewPassword, null);
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation does not match New Password!");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Employee.Password == txtCurrentPassword.Text)
            {
                DialogResult result = MessageBox.Show("Are You Sure You Want To Change Your Password ? ", "Sure ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _Employee.Mode = clsEmployee.enMode.Update;
                    _Employee.Password = txtNewPassword.Text;
                    if (_Employee.Save())
                    {
                        MessageBox.Show("Your Password Is Changed Succefully ", "Success ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Your Password Was Not Changed  ", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            else
            {
                MessageBox.Show("Wrong Password  ", "Failed ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

