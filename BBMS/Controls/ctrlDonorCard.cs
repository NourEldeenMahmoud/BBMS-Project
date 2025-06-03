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
    public partial class ctrlDonorCard : UserControl
    {
        clsDonor _Donor;
        private int _DonorID = -1;
        public int DonorID
        {
            get { return _DonorID; }
        }
        public clsDonor DonorData
        {
            get { return _Donor; }
        }
        public int PersonID
        {
            get { return ctrlPersonCard2.PersonID; }
        }
        public Label TextTitle
        {
            get { return ctrlPersonCard2.TitleText; }
        }
        public Guna2ControlBox ControlBoxClose
        {
            get { return ctrlPersonCard2.ControlBoxClose; }
        }
        public Guna2ControlBox ControlBoxCloseMini
        {
            get { return ctrlPersonCard2.ControlBoxMini; }
        }
        public Guna2Separator Sep
        {
            get { return ctrlPersonCard2.Sep; }
        }
        public ctrlDonorCard()
        {
            InitializeComponent();
        }
        private void _FillDonorCard()
        {

            lblDonorIDValue.Text = _Donor.DonorID.ToString();
            string BloodType = clsBloodStock.GetDonorBloodType(_Donor.DonorID);
            lblBloodTypeValue.Text = string.IsNullOrEmpty(BloodType) ?"Not Tested Yet": BloodType;
            lblHeightValue.Text = _Donor.Height.ToString();
            lblWeightValue.Text = _Donor.Weight.ToString();
            if (_Donor.MedicalRecord != null )
            {
                lblMedicalRecoredValue.Text = _Donor.MedicalRecord;
            }
            else
            {
                lblMedicalRecord.Text = "None";
            }
            
            if (_Donor.CanDonate)
            {
                lblCanDonateValue.Text = "Yes";
            }
            else
            {
                lblCanDonateValue.Text = "No";
            }
            lblLastDonation.Text = _Donor.LastDonationDate?.ToString("dd/MM/yyyy") ?? "None";


        }
        public void LoadDonor(int DonorID)
        {
            
            _DonorID = DonorID;
            _Donor = clsDonor.Find(DonorID);
            if (_Donor != null)
            {
                
                ctrlPersonCard2.LoadPersonData(_Donor.PersonID);

                _FillDonorCard();
            }
            else
            {
                MessageBox.Show("Inable To Find Donor With Donor " + DonorID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
