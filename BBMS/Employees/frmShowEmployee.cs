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
    public partial class frmShowEmployee : Form
    {
        private int _EmployeeID ;
        public frmShowEmployee(int EmployeeID)
        {
            InitializeComponent();
            _EmployeeID = EmployeeID;
        }

        private void frmShowEmployee_Load(object sender, EventArgs e)
        {
            ctrlEmployeeCard1.LoadEmployee(_EmployeeID);
        }

        private void ctrlEmployeeCard1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
