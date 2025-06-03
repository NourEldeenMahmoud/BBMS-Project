using BBMS.BloodStock;
using BBMS.Donations;
using BBMS.Employees;
using BBMS.Patients;
using BBMS.Transfusion;
using BBMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BBMS
{
    public partial class frmHome : Form
    {
        frmLogin _frmLogin;
        public frmHome(frmLogin frmLogin)
        {
            InitializeComponent();
             _frmLogin= frmLogin;
        }

        public frmHome()
        {
            InitializeComponent();
           
        }

        private void LoadFormInPanel(Form frm)
        {
            MainPanel.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(frm);
            frm.Show();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblUserName.Text=clsGlobal.LoggedInEmployee.UserName;
            clsBloodStock.UpdateExpiredUnits();
            LoadFormInPanel(new frmDashboard());
        }

        private void btnPeople_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManagePeople());
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManageEmployees());
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
             clsGlobal.LoggedInEmployee = null;
            _frmLogin.Show();
            this.Close();
        }

        private void btnDonation_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManageDonors());
        }

        private void btnBloodStock_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManageBloodStock());
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManagePatients());
        }

        private void btnTransfusion_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManageTransfusions());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmDashboard());
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            LoadFormInPanel(new frmManagePeople());

        }
    }
}
