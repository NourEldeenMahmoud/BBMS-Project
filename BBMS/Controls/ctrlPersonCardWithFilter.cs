using BBMS.People;
using BBMS_Business;
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
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        // Define a custom event handler delegate with parameters
        public event Action<int> OnPersonSelected;
        // Create a protected method to raise the event with a parameter
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(PersonID); // Raise the event with the parameter
            }
        }


        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                SearchPanel.Enabled = _FilterEnabled;
            }
        }

       public int PersonID
       {
           get { return ctrlPersonCardWithNoTitle1.PersonID; }
       }
       
       public clsPerson SelectedPersonInfo
       {
            
           get { return ctrlPersonCardWithNoTitle1.SelectedPersonInfo; }

       }

        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }


        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (cbFilter.SelectedIndex == 0)
            {
                int.TryParse(txtSearch.Text.Trim(), out int PersonID );
                ctrlPersonCardWithNoTitle1.LoadPersonData(PersonID);
                
            }
            else
            {
                string _NationaNo = txtSearch.Text.Trim();
                ctrlPersonCardWithNoTitle1.LoadPersonData(_NationaNo);

            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                    OnPersonSelected(ctrlPersonCardWithNoTitle1.PersonID);

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
       {
            if (e.KeyChar == (char)13)
            {

                btnFindPerson.PerformClick();
            }
            if (cbFilter.SelectedItem == null)
            {
                e.Handled = true; // إلغاء الإدخال
            }
            if (cbFilter.SelectedIndex == 0)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // إلغاء الإدخال
                }
            }

        }
        public void LoadPerson(int PersonID)
        {
            cbFilter.Enabled = false;
            lblFindBy.Enabled = false;
            txtSearch.Enabled = false;
            btnAddPerson.Enabled = false;
            btnFindPerson.Enabled = false;
            ctrlPersonCardWithNoTitle1.LoadPersonData(PersonID);
            txtSearch.Text= PersonID.ToString();
        }
        public void LoadPerson(string NationalNo)
        {
            cbFilter.Enabled = false;
            lblFindBy.Enabled = false;
            txtSearch.Enabled = false;
            btnAddPerson.Enabled = false;
            btnFindPerson.Enabled = false;
            ctrlPersonCardWithNoTitle1.LoadPersonData(NationalNo);
            txtSearch.Text = NationalNo;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson1 = new frmAddUpdatePerson();
            frmAddUpdatePerson1.DataBack += DataBackEvent;
            frmAddUpdatePerson1.ShowDialog();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received

            cbFilter.SelectedIndex = 1;
            txtSearch.Text = PersonID.ToString();
            ctrlPersonCardWithNoTitle1.LoadPersonData(PersonID);
        }
        

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            txtSearch.Focus();
            
        }

        private void btnShowAllPeople_Click(object sender, EventArgs e)
        {
            frmShowAllPeople ShowAllPeople = new frmShowAllPeople();
            ShowAllPeople.ShowDialog();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
