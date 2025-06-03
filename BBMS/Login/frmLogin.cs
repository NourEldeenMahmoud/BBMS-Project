using BBMS_Business;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private bool LoadLoginData()
        {

            try
            {
                using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\BBMS_User"))
                {
                    if (Key == null)
                    {
                        return false;
                    }
                    string UserNameValue = Key.GetValue("UserName", null) as string;
                    string PasswordValue = Key.GetValue("Password", null) as string;
                    txtUserName.Text = UserNameValue;
                    txtPassword.Text = PasswordValue;
                    chkRemember.Checked = true;
                }


            }
            catch (Exception)
            {
                return false;
            }
            return true;



        }

        private bool RememberMeCheck()
        {
            if (!chkRemember.Checked)
            {
                try
                {
                    using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\BBMS_User", true))
                    {
                        if (Key == null)
                        {
                            return false;
                        }
                        if (Key.GetValue("UserName") != null)
                            Key.DeleteValue("UserName");

                        if (Key.GetValue("Password") != null)
                            Key.DeleteValue("Password");
                        chkRemember.Checked = false;
                        txtPassword.Clear();
                        txtUserName.Clear();
                    }

                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }

            string UserNameValue = txtUserName.Text.Trim();
            string PasswordValue = txtPassword.Text.Trim();

            try
            {
                using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\BBMS_User"))
                {
                    if (Key == null)
                    {
                        return false;
                    }
                    Key.SetValue("UserName", UserNameValue, RegistryValueKind.String);
                    Key.SetValue("Password", PasswordValue, RegistryValueKind.String);
                }


            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            LoadLoginData();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            clsEmployee Employee = clsEmployee.FindByUserNameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim()); ;
            
                if (Employee==null)
                {
                    MessageBox.Show("Invalid Username Or Password. Please try again  ", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                }
                else if (Employee.CanLogin == false)
                {
                    MessageBox.Show("You have no access to the system  !! Contact The Admin ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    RememberMeCheck();
                    clsGlobal.LoggedInEmployee = Employee;
                    this.Hide();
                    frmHome frm = new frmHome(this);
                    frm.ShowDialog();
                }
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar == false)
            {
                txtPassword.UseSystemPasswordChar = true;
                btnShow.BackgroundImage = Properties.Resources.show;

            }
            else
            {
                txtPassword.UseSystemPasswordChar = false;
                btnShow.BackgroundImage = Properties.Resources.hide;
            }
        }
     
    }
}
