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
    public partial class frmShowBloodUnit : Form
    {
        private int _BloodUnitID=-1;
        public frmShowBloodUnit(int BloodUnitID)
        {
            InitializeComponent();
            _BloodUnitID = BloodUnitID;
        }

        private void frmShowBloodUnit_Load(object sender, EventArgs e)
        {
            ctrlBloodUnitInfo1.LoadUnitInfo(_BloodUnitID);
        }
    }
}
