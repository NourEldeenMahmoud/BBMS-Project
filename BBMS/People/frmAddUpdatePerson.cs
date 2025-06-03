using BBMS.Properties;
using BBMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender,int PersonID);
        public event DataBackEventHandler DataBack;
        int _PersonID = -1;
        clsPerson _Person;

        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;//for update

        }

        public frmAddUpdatePerson()
        {
            InitializeComponent();//for add

        }

        public void _UpperHeader()
        {

            if (_PersonID == -1)
            {
                lblTitle.Text = "Add Person";
            }
            else
            {
                lblTitle.Text = "Edit Person";
            }


        }

        private void _FillCountries()
        {
        
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow Row in dtCountries.Rows)
            {
                cbCountries.Items.Add(Row["CountryName"]);
            }

        }

        private void _FillPerson()
        {
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();

            if (rbMale.Checked)
                _Person.Gendar = 0;
            else
                _Person.Gendar = 1;

            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Address = rtxtAddress.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cbCountries.Text).ID;

            if (pbPersonImage.ImageLocation != null)
            {
                string imageName = Path.GetFileName(pbPersonImage.ImageLocation);
                _Person.ImagePath = imageName;
            }
            else
                _Person.ImagePath = "";


        }

        private void _LoadPerson()
        {
           
            lblPersonIDValue.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;

            if (_Person.Gendar == 0)
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            txtEmail.Text = _Person.Email;
            rtxtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            cbCountries.SelectedIndex = _Person.NationalityCountryID - 1;
            txtPhone.Text = _Person.Phone;


            _LoadPersonImage();
           
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
                    pbPersonImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private bool _MovePersonImage()
        {


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                if (pbPersonImage.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();//المكان الاساسي للصوره

                    if (clsGlobal.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {

            _UpperHeader();
            _FillCountries();
            cbCountries.SelectedIndex=cbCountries.FindString("Egypt") ;
            if (_PersonID == -1)
            {
                _Person = new clsPerson();
                _Person.Mode = clsPerson.enMode.AddNew;
            }
            else
            {
                _Person = clsPerson.Find(_PersonID);
                _Person.Mode = clsPerson.enMode.Update;
                _LoadPerson();
            }

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            guna2DragControl1.TargetControl = this;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!_MovePersonImage())
                return;

            
                _FillPerson();


            if (_Person.Save())
            {
                MessageBox.Show("Person Saved Succefully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this,_Person.PersonID);
                lblPersonIDValue.Text = _Person.PersonID.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Person Was not Saved Succefully", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void llblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                string selectedFilePath = openFileDialog1.FileName;
                pbPersonImage.ImageLocation = selectedFilePath;
                
                llblRemove.Visible = true;
               
            }
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {

            // First: set AutoValidate property of your Form to EnableAllowFocusChange in designer 
            Guna.UI2.WinForms.Guna2TextBox Temp = (Guna.UI2.WinForms.Guna2TextBox)sender;
            if (string.IsNullOrEmpty(Temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(Temp, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(Temp, null);
            }

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
            
            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string EmailFormat = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "");
            }
            else if (!Regex.IsMatch(txtEmail.Text, EmailFormat))
            {
                errorProvider1.SetError(txtEmail, "Email Format is Incorrect !!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }

        private void llblRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (rbMale.Checked )
            {
                pbPersonImage.Image = Resources.man;
            }
            else
            {
                pbPersonImage.Image = Resources.woman;
            }
            llblRemove.Visible = false;

        }

        private void rbFemale_Click(object sender, EventArgs e)
        {

            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.woman;
        }

        private void rbMale_Click(object sender, EventArgs e)
        {
           if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.man;
        }

        private void rtxtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(rtxtAddress.Text.ToString()))
            {
                errorProvider1.SetError(rtxtAddress, " Address  Is Required !!");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(rtxtAddress, "");
            }
        }

        
    }
}
