using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS.Transfusion
{
    public partial class frmShowTransfusionDetails : Form
    {
        private int _TransfusionID=-1;
        public frmShowTransfusionDetails(int TransufusionID)
        {
            InitializeComponent();
            _TransfusionID = TransufusionID;
        }

        private void frmShowTransfusionDetails_Load(object sender, EventArgs e)
        {
            if (_TransfusionID!=-1)
            {
                ctrlTransfusionRequestDetails1.LoadTransfusionInfo(_TransfusionID);
            }
            
        }
    }
}
