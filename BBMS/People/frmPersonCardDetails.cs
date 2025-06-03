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
    public partial class frmPersonCardDetails : Form
    {
        private int _PersonID;
        public frmPersonCardDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }
        

       

        private void frmPersonCardDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonCard1.LoadPersonData(_PersonID);
        }

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
