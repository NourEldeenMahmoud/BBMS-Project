using BBMS_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS.Controls
{
    public partial class ctrlBloodUnitInfo : UserControl
    {
        private int _BloodUnitID = -1;
        private clsBloodStock _BloodUnit;
        public ctrlBloodUnitInfo()
        {
            InitializeComponent();
        }
        public int BloodUnitID
        { get { return _BloodUnitID; } }
        public clsBloodStock BloodUnit
        { get { return _BloodUnit; } }

        public Guna2ControlBox ControlBoxClose
        {
            get { return guna2ControlBox1; }
        }
        public Guna2ControlBox ControlBoxMini
        {
            get { return guna2ControlBox2; }
        }
        public Label Title
        {
            get { return lblTitle; }
        }
        private void _BloodUnitImage()
        {
            switch (_BloodUnit.BloodType)
            {
                case "Not Yet Determined":
                    pbBloodType.Image = Properties.Resources.general_blood_bag;
                    break;

                case "A+":
                    pbBloodType.Image = Properties.Resources.A_plus;
                    break;

                case "A-":
                    pbBloodType.Image = Properties.Resources.A_minus;
                    break;

                case "B+":
                    pbBloodType.Image = Properties.Resources.B_plus;
                    break;

                case "B-":
                    pbBloodType.Image = Properties.Resources.B_minus;
                    break;

                case "AB+":
                    pbBloodType.Image = Properties.Resources.AB_plus;
                    break;

                case "AB-":
                    pbBloodType.Image = Properties.Resources.AB_minus;
                    break;

                case "O+":
                    pbBloodType.Image = Properties.Resources.O_plus;
                    break;

                case "O-":
                    pbBloodType.Image = Properties.Resources.O_minus;
                    break;

                default:
                    break;
            }
        }
        private void _LoadBloodUnitInfo()
        {
            _BloodUnitImage();
            lblBloodUnitIDValue.Text = _BloodUnit.BloodUnitID.ToString();
            lblBloodTypeValue.Text = _BloodUnit.BloodType;
            lblDonorNameValue.Text = _BloodUnit.DonationData.DonorData.PersonData.FullName();
            lblExpirationDateValue.Text = _BloodUnit.ExpirationDate.ToString("dd/MM/yyyy");
            lblNotesValue.Text =string.IsNullOrEmpty( _BloodUnit.Notes)?"None": _BloodUnit.Notes;
            lblVolumeValue.Text = _BloodUnit.DonationData.BloodVolume.ToString() + " ml";
            lblBloodUnitStatusValue.Text = clsBloodStock.GetCurrentStatusText(_BloodUnit.CurrentStatus);
            lblTestResultValue.Text = clsBloodStock.GetTestStatusText(_BloodUnit.TestStatus);
            
        }
        public void LoadUnitInfo(int BloodUnitID)
        {
            _BloodUnitID=BloodUnitID;
            _BloodUnit = clsBloodStock.Find(_BloodUnitID);
            if (_BloodUnit != null)
            {
                _LoadBloodUnitInfo();

            }
        }
        private void ctrlBlooUnitInfo_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
