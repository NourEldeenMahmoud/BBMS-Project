using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS.Properties;
using BBMS_Business;
using System.IO;
using Guna.UI2.WinForms;

namespace BBMS
{
    public partial class ctrlBloodUnitCard : UserControl
    {
        private clsBloodUnit _BloodUnit;
        private int _BloodUnitID = -1;

        public ctrlBloodUnitCard()
        {
            InitializeComponent();
        }

        public int BloodUnitID
        {
            get { return _BloodUnitID; }
        }

        public clsBloodUnit SelectedBloodUnitInfo
        {
            get { return _BloodUnit; }
        }

        public void LoadBloodUnitData(int BloodUnitID)
        {
            _BloodUnit = clsBloodUnit.Find(BloodUnitID);
            if (_BloodUnit != null)
            {
                _FillCard();
            }
            else
            {
                MessageBox.Show($"Unable to find blood unit with ID {BloodUnitID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetCard();
            }
        }

        private void _LoadBloodBagImage()
        {
            try
            {
                // Get blood type image based on blood type
                string bloodTypeImage = $"blood_bag_{_BloodUnit.BloodType.ToLower()}.png";
                pbBloodBagImage.Image = clsImageManager.GetBloodBagImage(bloodTypeImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading blood bag image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                pbBloodBagImage.Image = clsImageManager.DefaultBloodBagImage;
            }
        }

        private void _FillCard()
        {
            try
            {
                _BloodUnitID = _BloodUnit.BloodUnitID;
                lblBloodUnitIDValue.Text = _BloodUnit.BloodUnitID.ToString();
                lblBloodTypeValue.Text = _BloodUnit.BloodType;
                lblDonationDateValue.Text = _BloodUnit.DonationDate.ToShortDateString();
                lblExpiryDateValue.Text = _BloodUnit.ExpiryDate.ToShortDateString();
                lblStatusValue.Text = _BloodUnit.Status == 0 ? "Available" : "Used";
                lblDonorIDValue.Text = _BloodUnit.DonorID.ToString();
                _LoadBloodBagImage();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filling blood unit card: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetCard();
            }
        }

        private void _ResetCard()
        {
            _BloodUnitID = -1;
            lblBloodUnitIDValue.Text = "";
            lblBloodTypeValue.Text = "";
            lblDonationDateValue.Text = "";
            lblExpiryDateValue.Text = "";
            lblStatusValue.Text = "";
            lblDonorIDValue.Text = "";
            pbBloodBagImage.Image = clsImageManager.DefaultBloodBagImage;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (pbBloodBagImage.Image == null)
            {
                pbBloodBagImage.Image = clsImageManager.DefaultBloodBagImage;
            }
        }

        protected override void OnDispose(bool disposing)
        {
            if (disposing)
            {
                if (pbBloodBagImage.Image != null)
                {
                    pbBloodBagImage.Image.Dispose();
                }
            }
            base.OnDispose(disposing);
        }
    }
} 