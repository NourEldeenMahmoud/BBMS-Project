using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS.Patients
{
    public partial class frmShowPatientCard : Form
    {
        private int _PatientID = -1;
        public frmShowPatientCard(int PatientID)
        {
            InitializeComponent();
            _PatientID=PatientID;
        }

       
        private void frmShowPatientCard_Load(object sender, EventArgs e)
        {
            if (_PatientID!=-1)
            {
                ctrlPatientCard1.LoadPatientCard(_PatientID);
            }
        }
    }
}
