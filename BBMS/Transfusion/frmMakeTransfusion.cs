using BBMS.Controls;
using BBMS.Patients;
using BBMS_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace BBMS.Transfusion
{
    public partial class frmMakeTransfusion : Form
    {
        
        private int _TransfusionID = -1;
        private int _NurseID = -1;
        private int _BloodUnitID = -1;
        private int _PatientID = -1;

        private bool _frmPatient=false;

        private DataTable _dtAllNurses;
        private clsTransfusion _Transfusion;
        private clsBloodStock _BloodUnit;
        private Timer _timer;

        public frmMakeTransfusion(int TransfusionID)
        {
            InitializeComponent();
            _TransfusionID = TransfusionID;
        }
        public frmMakeTransfusion(int PatientID,bool frmPatient)
        {
            InitializeComponent();
            _PatientID = PatientID;
            _frmPatient = frmPatient;
        }
        private void frmMakeTransfusion_Load(object sender, EventArgs e)
        {
             
            if (_frmPatient)
            {
                _Transfusion = clsTransfusion.FindByPatientID(_PatientID);
            }
            else
            {
                _Transfusion = clsTransfusion.Find(_TransfusionID);
            }


            if (_Transfusion==null)
            {
                MessageBox.Show("There's No Transfusion Request With ID "+ _TransfusionID , "No Match ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }

            _LoadDonation();
            _HandleVisibilty();
            _RefreshNursesList();
            _dgvHeader();
        }

        private List<string> _GetBloodMatchList()
        {
            string BloodType = _Transfusion.PatientData.BloodType;
            List<string>MatchingList = new List<string>();
            switch (BloodType)
            {
                case "O-":
                    MatchingList.Add("O-");
                    break;

                case "O+":
                    MatchingList.AddRange(new[] { "O-", "O+" });
                    break;

                case "A-":
                    MatchingList.AddRange(new[] { "A-", "O-" });
                    break;

                case "A+":
                    MatchingList.AddRange(new[] { "O-", "O+", "A-", "A+" });
                    break;

                case "B-":
                    MatchingList.AddRange(new[] { "O-", "B-" });
                    break;

                case "B+":
                    MatchingList.AddRange(new[] { "O-", "O+", "B-", "B+" });
                    break;

                case "AB-":
                    MatchingList.AddRange(new[] { "O-", "A-", "B-", "AB-" });
                    break;

                case "AB+":
                    MatchingList.AddRange(new[] { "O-", "O+", "A-", "A+", "B-", "B+", "AB-", "AB+" });
                    break;

                default:
                    return new List<string>();
            }
            return MatchingList;
        }

        private void _RefreshNursesList()
        {
            _dtAllNurses = clsDonation.GetAllNurses();
            dgvListNurses.DataSource = _dtAllNurses;

        }

        private void _LoadDonation()
        {
            lblTransfusionIDValue.Text = _Transfusion.TransfusionID.ToString();
            lblTransfusionDateValue.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblRequestedVolumeValue.Text= _Transfusion.QuantityRequested.ToString()+" ml";


        }

        private void _dgvHeader()
        {

            dgvListNurses.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvListNurses.Columns[0].HeaderText = "Employee ID";
            dgvListNurses.Columns[0].Width = 100;

            dgvListNurses.Columns[1].HeaderText = "Full Name";
            dgvListNurses.Columns[1].Width = 350;

            dgvListNurses.Columns[2].HeaderText = "National No";
            dgvListNurses.Columns[2].Width = 100;
            dgvListNurses.Columns[3].HeaderText = "Role";
            dgvListNurses.Columns[3].Width = 100;

        }

        private void _HandleVisibilty()
        { 
            _timer = new Timer();
            _timer.Interval = 2500; 
            _timer.Tick += Timer_Tick;
            _timer.Start();
            ctrlBloodUnitInfo1.ControlBoxClose.Visible = false;
            ctrlBloodUnitInfo1.ControlBoxMini.Visible = false;
        }

        private void _GetMatchingBloodType()
        {
            
            _BloodUnit = clsBloodStock.FindBloodMatch(_GetBloodMatchList());
            if (_BloodUnit == null)
            {
                //MessageBox.Show("There's No Blood Match For This Transfusion", "No Match ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NotFoundPanel.Visible = true;
                tpTransfusionInfo.Enabled = false;
                btnChooseManullay.Enabled = false;
                btnSave.Enabled = false;
              

            }
            else
            {
                ctrlBloodUnitInfo1.Title.Location = new Point(156, 27);
                btnChooseManullay.Visible = true;
                btnNext.Visible = true;
                ctrlBloodUnitInfo1.Visible = true;
                ctrlBloodUnitInfo1.LoadUnitInfo(_BloodUnit.BloodUnitID);
                ctrlBloodUnitInfo1.Title.Text = "A Blood Match Is Found !!";
            }
            
        }

        private void _FillTransfusion()
        {
            _Transfusion.TransfusionDate= DateTime.Now;
            _Transfusion.TransfusionStatus = 1;
            _Transfusion.BloodUnitID=_BloodUnit.BloodUnitID;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _timer.Stop();
            _timer.Dispose();

            WaitingPanel.Visible = false;
            _GetMatchingBloodType();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcFindMatch.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_NurseID == -1)
            {
                MessageBox.Show("You Need To Choose A Nurse , Choose By Clicking The Nurse", "Choose", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillTransfusion();
            if (_Transfusion.Save())
            {
                _Transfusion.BloodUnitData = _BloodUnit;
                _Transfusion.BloodUnitData.CurrentStatus = clsBloodStock.enCurrentStatus.Transfused;
                 if (_Transfusion.BloodUnitData.Save())
                 {
                    lblNurseIDValue.Text = _Transfusion.PerformedBy.ToString();
                    MessageBox.Show("Donation Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Error: Donation Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void llblPatientInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPatientCard ShowPatient = new frmShowPatientCard(_Transfusion.PatientID);
            ShowPatient.ShowDialog();
        }

        private void dgvListNurses_DoubleClick(object sender, EventArgs e)
        {
            _NurseID = (int)dgvListNurses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _NurseID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Transfusion.PerformedBy = _NurseID;
                lblNurseIDValue.Text = _NurseID.ToString();
                btnSave.Enabled = true;
            }   

        }

        private void DataBackEvent(object sender, int BloodUnitID)
        {
            // Handle the data received
            _BloodUnitID = BloodUnitID;
            _BloodUnit = clsBloodStock.Find(_BloodUnitID);
            if (_BloodUnit!=null)
            {
                ctrlBloodUnitInfo1.LoadUnitInfo(_BloodUnitID);
            }
           
        }

        private void chooseNurseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _NurseID = (int)dgvListNurses.CurrentRow.Cells[0].Value;

            if (MessageBox.Show("Are you sure you want the Nurse With ID " + _NurseID + " To Draw The Blood ? ", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Transfusion.PerformedBy = _NurseID;
                btnSave.Enabled = true;

            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tcFindMatch.SelectedIndex=1;
        }

        private void btnChooseManullay_Click(object sender, EventArgs e)
        {
            List<string> MatchingList =_GetBloodMatchList();
            frmChooseManually ChooseManually = new frmChooseManually(MatchingList);
            ChooseManually.DataBack += DataBackEvent;
            ChooseManually.ShowDialog();
        }
    }
}
