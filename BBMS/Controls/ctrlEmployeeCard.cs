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

namespace BBMS.Controls
{
    public partial class ctrlEmployeeCard : UserControl
    {
        clsEmployee _Employee;
        private int _EmployeeID = -1;
        public int EmployeeID
        {
            get { return _EmployeeID; }
        }
 
        public Label TextTitle
        {
            get { return ctrlPersonCard1.TitleText; }
        }
        public Guna2ControlBox ControlBoxClose
        {
            get { return ctrlPersonCard1.ControlBoxClose; }
        }
        public Guna2ControlBox ControlBoxMini
        {
            get { return ctrlPersonCard1.ControlBoxMini; }
        }
        public Guna2Separator Sep
        {
            get { return ctrlPersonCard1.Sep; }
        }
        public ctrlEmployeeCard()
        {
            InitializeComponent();
        }
        private void _FillEmployeeCard()
        {
            
            lblUserIDValue.Text = _Employee.EmployeeID.ToString();
            lblUserNameValue.Text = _Employee.UserName;
            lblRoleValue.Text = _Employee.Role;
            if (_Employee.CanLogin)
            {
                lblCanLoginValue.Text = "Yes";
            }
            else
            {
                lblCanLoginValue.Text = "No";
            }

        }
        public void LoadEmployee(int EmployeeID)
        {
            _EmployeeID = EmployeeID;
            _Employee = clsEmployee.Find(EmployeeID);
            if (_Employee != null)
            {
                _FillEmployeeCard();
                ctrlPersonCard1.LoadPersonData(_Employee.PersonID);
                ctrlPersonCard1.TitleText.Text = "Employee Card";
                ctrlPersonCard1.Sep.Visible = false;
            }
            else
            {
                MessageBox.Show("Inable To Find User With UserID " + EmployeeID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
    }
}
