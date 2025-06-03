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
    public partial class frmShowDonor : Form
    {
        private int _DonorID = -1;
        public frmShowDonor(int DonorID)
        {
            InitializeComponent();
            _DonorID = DonorID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowDonor_Load(object sender, EventArgs e)
        {
            ctrlDonorCard1.LoadDonor(_DonorID);
            ctrlDonorCard1.TextTitle.Text = "Donor Card";
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
