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
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _Person;
        private int _PersonID = -1;
        private string _Imagepath = "";
        public ctrlPersonCard()
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
        public Label TitleText
        {
            get { return lblTitle; }
        }
        public Guna2Separator Sep
        {
            get { return guna2Separator1; }
        }
        public Guna2ControlBox ControlBoxClose
        {
            get { return guna2ControlBox1; }
        }
        public Guna2ControlBox ControlBoxMini
        {
            get { return guna2ControlBox2; }
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
                MessageBox.Show("Inable To Find Person With Person ID " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetCard();
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
                _ResetCard();
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
            _Imagepath = ImagePath;
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
            _PersonID=_Person.PersonID;
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
        private void _ResetCard()
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

        private void llblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frmAddUpdatePerson frmUpdatePerson = new frmAddUpdatePerson(_Person.PersonID);
            frmUpdatePerson.ShowDialog();
            LoadPersonData(_PersonID);
            
        }

        
    }
}
