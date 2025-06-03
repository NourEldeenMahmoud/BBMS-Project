using BBMS.Properties;
using BBMS_Business;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS.Controls
{
    public partial class ctrlPersonCardWithNoTitle : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;

        public ctrlPersonCardWithNoTitle()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }

        public Form PersonCardctrl
        {
            get { return this.FindForm(); }
        }

        public void LoadPersonData(int PersonID)
        {

            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
            {
                _FillCard();

            }
            else
            {
                MessageBox.Show("Inable To Find Person With Person ID " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadPersonData(string NationalNo)
        {

            _Person = clsPerson.Find(NationalNo);
            if (_Person != null)
            {
                _FillCard();
            }
            else
            {
                MessageBox.Show("Inable To Find Person With NationalNo " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetCard();
            }
        }

        private void _LoadPersonImage()
        {
            if (_Person.Gendar == 0)
                pbPersonImage.Image = Resources.man;
            else
                pbPersonImage.Image = Resources.woman;

            string ImageName = _Person.ImagePath;

            string destinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonImages");
            string ImagePath = Path.Combine(destinationFolder, ImageName);
            if (ImageName != "")
            {

                if (File.Exists(ImagePath))
                {
                    pbPersonImage.Image = null;
                    pbPersonImage.ImageLocation = null;
                    pbPersonImage.ImageLocation = ImagePath;
                }
                   
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void _FillCard()
        {

            llblEditPerson.Enabled = true;
            _PersonID = _Person.PersonID;
            lblPersonIDValue.Text = _Person.PersonID.ToString();
            lblNameValue.Text = _Person.FullName();
            lblNationalNoValue.Text = _Person.NationalNo;
            lblGenderValue.Text = _Person.Gendar == 0 ? "Male" : "Female";
            lblEmailValue.Text = _Person.Email;
            lblAddressValue.Text = _Person.Address;
            lblDateOfBirthValue.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountryValue.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblPhoneValue.Text = _Person.Phone;
            _LoadPersonImage();
        }

        public void ResetCard()
        {
            lblPersonIDValue.Text = "[--??--]";
            lblNameValue.Text = "[--??--]";
            lblNationalNoValue.Text = "[--??--]";
            lblGenderValue.Text = "[--??--]";
            lblEmailValue.Text = "[--??--]";
            lblAddressValue.Text = "[--??--]";
            lblDateOfBirthValue.Text = "[--??--]";
            lblCountryValue.Text = "[--??--]";
            lblPhoneValue.Text = "[--??--]";
            pbPersonImage.Image = Properties.Resources.man;
        }

        private void llblEditPerson_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmAddUpdatePerson frmUpdatePerson = new frmAddUpdatePerson(_Person.PersonID);
            frmUpdatePerson.ShowDialog();
            LoadPersonData(_PersonID);
        }

    }
}
