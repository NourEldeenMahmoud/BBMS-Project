
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS_Business;
using System.Windows.Forms.DataVisualization.Charting;

namespace BBMS
{
    public partial class frmDashboard : Form
    {
        private Dictionary<string, int> _BloodTypes = new Dictionary<string, int>();
        private Dictionary<string, int> StatusPercentage = new Dictionary<string, int>();
        private Dictionary<string, int> DailyReport = new Dictionary<string, int>();
        private Dictionary<string, int> MostWanted = new Dictionary<string, int>();
        private Dictionary<string, int> DonorsToPateints = new Dictionary<string, int>();

        public frmDashboard()
        {
            InitializeComponent();
        }
        private void _BloodTypesCount()
        {
            clsDashboard.GetBloodTypesCount(_BloodTypes);
            APlus.Text = _BloodTypes.ContainsKey("A+") ? _BloodTypes["A+"].ToString() : "0";
            BPlus.Text = _BloodTypes.ContainsKey("B+") ? _BloodTypes["B+"].ToString() : "0";
            OPlus.Text = _BloodTypes.ContainsKey("O+") ? _BloodTypes["O+"].ToString() : "0";
            ABPlus.Text = _BloodTypes.ContainsKey("AB+") ? _BloodTypes["AB+"].ToString() : "0";
            AMinus.Text = _BloodTypes.ContainsKey("A-") ? _BloodTypes["A-"].ToString() : "0";
            BMinus.Text = _BloodTypes.ContainsKey("B-") ? _BloodTypes["B-"].ToString() : "0";
            OMinus.Text = _BloodTypes.ContainsKey("O-") ? _BloodTypes["O-"].ToString() : "0";
            ABMinus.Text = _BloodTypes.ContainsKey("AB-") ? _BloodTypes["AB-"].ToString() : "0";

        }
        private void _UpdateNumbers()
        {
            if (clsDashboard.GetDailyReport(DailyReport))
            {
                lblDonationsToday.Text = DailyReport.ContainsKey("Donations") ? DailyReport["Donations"].ToString() : "0";
                lblRequestsToday.Text = DailyReport.ContainsKey("Requests") ? DailyReport["Requests"].ToString() : "0";
                lblUnitsTransfused.Text = DailyReport.ContainsKey("Units Transfused") ? DailyReport["Units Transfused"].ToString() : "0";
                lblUnitsExpired.Text = DailyReport.ContainsKey("Expired") ? DailyReport["Expired"].ToString() : "0";
                lblPendingRequests.Text = DailyReport.ContainsKey("Pending Reqeusts") ? DailyReport["Pending Reqeusts"].ToString() : "0";
            }
            
            lblNumberOfRequests.Text = clsDashboard.NumberOfRequests().ToString();
            lblNumberOfBloodUnits.Text = clsDashboard.NumberOfUnits().ToString();

        }
        private void _GetStatusPercentage()
        {
            clsDashboard.GetStatusPercentage(StatusPercentage);
            
            StatusPercentageChart.Series.Clear();
            Series series = new Series("Status Percentage");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.IndianRed;

            foreach (var item in StatusPercentage)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            StatusPercentageChart.Series.Add(series);

            // X Axis
            StatusPercentageChart.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);


            // Y Axis
            StatusPercentageChart.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            //Top Column fonts
            series.LabelForeColor = Color.Black;
            series.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            // تنسيق المحاور والخلفية
            StatusPercentageChart.ChartAreas[0].BackColor = Color.White;
            StatusPercentageChart.BackColor = Color.Transparent;
            StatusPercentageChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            StatusPercentageChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            StatusPercentageChart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            StatusPercentageChart.ChartAreas[0].AxisY.Enabled = AxisEnabled.True;
            StatusPercentageChart.Legends.Clear(); // إزالة Series1 من الأعلى
        }
        private void _PieChart()
        {

            clsDashboard.GetDonorsToPatientRatio(DonorsToPateints);

            DonorsToPatientsChart.Series.Clear();
            Series series = new Series
            {
                Name = "Donors To Pateints Ratio",
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                LabelForeColor = Color.Black
            };

            foreach (var item in DonorsToPateints)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            DonorsToPatientsChart.Series.Add(series);

            // إعدادات عامة للشكل
            DonorsToPatientsChart.Titles.Clear();
            DonorsToPatientsChart.Titles.Add("Donors To Pateints Ratio");
            DonorsToPatientsChart.Titles[0].Font = new Font("Segoe UI", 20, FontStyle.Bold);
            DonorsToPatientsChart.Titles[0].ForeColor = Color.Black;

            DonorsToPatientsChart.BackColor = Color.Transparent;
            DonorsToPatientsChart.ChartAreas[0].BackColor = Color.White;
        }

        private void _BarChart()
        {
            clsDashboard.GetMostWantedBloodType(MostWanted);

            TopBloodTypesChart.Series.Clear();
            TopBloodTypesChart.Titles.Clear();
            TopBloodTypesChart.ChartAreas.Clear();

            // إعداد الرسم البياني
            ChartArea chartArea = new ChartArea();
            chartArea.BackColor = Color.White;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            chartArea.AxisY.Interval = 1;
            TopBloodTypesChart.ChartAreas.Add(chartArea);

            // إعداد السلسلة
            Series series = new Series("Top Requested Blood Types");
            series.ChartType = SeriesChartType.Bar; // Horizontal bar
            series.Color = Color.IndianRed;
            series.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            series.LabelForeColor = Color.Black;
            series.IsValueShownAsLabel = false;
            series["BarLabelStyle"] = "Right"; // يخلي الأرقام على يمين العمود
            series["LabelStyle"] = "Outside";  // يظهر الليبل خارج العمود

            // إضافة البيانات
            foreach (var item in MostWanted)
            {
                int index = series.Points.AddXY(item.Key, item.Value);
                // ضمان أن النص ظاهر وواضح
                series.Points[index].Label = item.Value.ToString();
            }

            TopBloodTypesChart.Series.Add(series);
            chartArea.AxisY.Enabled = AxisEnabled.False;
            // عنوان الرسم
            Title chartTitle = new Title("Top 3 Blood Types in Demand");
            chartTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            chartTitle.ForeColor = Color.Black;
            TopBloodTypesChart.Titles.Add(chartTitle);

            // إزالة أي خلفية من التشارت نفسه
            TopBloodTypesChart.BackColor = Color.Transparent;
        }
        private void frmDashboard_Load(object sender, EventArgs e)
        {
            _BloodTypesCount();
            _GetStatusPercentage();
            _UpdateNumbers();
            _PieChart();
            _BarChart();
        }

        private void lblNumberOfEmployees_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].WindowState = FormWindowState.Maximized;

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Application.OpenForms[0].WindowState = FormWindowState.Normal;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].WindowState = FormWindowState.Maximized;
        }
    }
}
