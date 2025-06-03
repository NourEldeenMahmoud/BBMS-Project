namespace BBMS.Transfusion
{
    partial class frmMakeTransfusion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox3 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblMatchFound = new System.Windows.Forms.Label();
            this.guna2ControlBox4 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.tcFindMatch = new Guna.UI2.WinForms.Guna2TabControl();
            this.tpBloodUnitInfo = new System.Windows.Forms.TabPage();
            this.NotFoundPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.WaitingPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.guna2CircleProgressBar2 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblFindTitle = new System.Windows.Forms.Label();
            this.btnChooseManullay = new Guna.UI2.WinForms.Guna2GradientButton();
            this.ctrlBloodUnitInfo1 = new BBMS.Controls.ctrlBloodUnitInfo();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tpTransfusionInfo = new System.Windows.Forms.TabPage();
            this.guna2GradientPanel2 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.llblPatientInfo = new System.Windows.Forms.LinkLabel();
            this.lblPtientInfo = new System.Windows.Forms.Label();
            this.lblTransfusionDateValue = new System.Windows.Forms.Label();
            this.lblTransfusionDate = new System.Windows.Forms.Label();
            this.lblRequestedVolumeValue = new System.Windows.Forms.Label();
            this.lblRequestedVolume = new System.Windows.Forms.Label();
            this.lblNurseIDValue = new System.Windows.Forms.Label();
            this.lblNurseID = new System.Windows.Forms.Label();
            this.lblTransfusionID = new System.Windows.Forms.Label();
            this.lblTransfusionIDValue = new System.Windows.Forms.Label();
            this.dgvListNurses = new Guna.UI2.WinForms.Guna2DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2ContextMenuStrip1 = new Guna.UI2.WinForms.Guna2ContextMenuStrip();
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.MainPanel.SuspendLayout();
            this.tcFindMatch.SuspendLayout();
            this.tpBloodUnitInfo.SuspendLayout();
            this.NotFoundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.WaitingPanel.SuspendLayout();
            this.guna2CircleProgressBar2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            this.tpTransfusionInfo.SuspendLayout();
            this.guna2GradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNurses)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.MainPanel.BorderColor = System.Drawing.Color.Black;
            this.MainPanel.BorderRadius = 500;
            this.MainPanel.Controls.Add(this.guna2ControlBox3);
            this.MainPanel.Controls.Add(this.lblMatchFound);
            this.MainPanel.Controls.Add(this.guna2ControlBox4);
            this.MainPanel.Controls.Add(this.tcFindMatch);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1155, 776);
            this.MainPanel.TabIndex = 46;
            // 
            // guna2ControlBox3
            // 
            this.guna2ControlBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox3.BorderRadius = 10;
            this.guna2ControlBox3.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox3.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ControlBox3.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox3.Location = new System.Drawing.Point(1013, 12);
            this.guna2ControlBox3.Name = "guna2ControlBox3";
            this.guna2ControlBox3.Size = new System.Drawing.Size(59, 38);
            this.guna2ControlBox3.TabIndex = 84;
            // 
            // lblMatchFound
            // 
            this.lblMatchFound.AutoSize = true;
            this.lblMatchFound.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatchFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.lblMatchFound.Location = new System.Drawing.Point(422, 2);
            this.lblMatchFound.Name = "lblMatchFound";
            this.lblMatchFound.Size = new System.Drawing.Size(415, 65);
            this.lblMatchFound.TabIndex = 125;
            this.lblMatchFound.Text = "Finding A Match ";
            this.lblMatchFound.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // guna2ControlBox4
            // 
            this.guna2ControlBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox4.BorderRadius = 10;
            this.guna2ControlBox4.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ControlBox4.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox4.Location = new System.Drawing.Point(1078, 12);
            this.guna2ControlBox4.Name = "guna2ControlBox4";
            this.guna2ControlBox4.Size = new System.Drawing.Size(59, 38);
            this.guna2ControlBox4.TabIndex = 3;
            // 
            // tcFindMatch
            // 
            this.tcFindMatch.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcFindMatch.Controls.Add(this.tpBloodUnitInfo);
            this.tcFindMatch.Controls.Add(this.tpTransfusionInfo);
            this.tcFindMatch.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcFindMatch.ItemSize = new System.Drawing.Size(180, 337);
            this.tcFindMatch.Location = new System.Drawing.Point(15, 70);
            this.tcFindMatch.Name = "tcFindMatch";
            this.tcFindMatch.SelectedIndex = 0;
            this.tcFindMatch.Size = new System.Drawing.Size(1122, 680);
            this.tcFindMatch.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcFindMatch.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcFindMatch.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcFindMatch.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcFindMatch.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcFindMatch.TabButtonIdleState.BorderColor = System.Drawing.Color.White;
            this.tcFindMatch.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(60)))), ((int)(((byte)(99)))));
            this.tcFindMatch.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcFindMatch.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcFindMatch.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tcFindMatch.TabButtonSelectedState.BorderColor = System.Drawing.Color.White;
            this.tcFindMatch.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.tcFindMatch.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcFindMatch.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcFindMatch.TabButtonSelectedState.InnerColor = System.Drawing.Color.Transparent;
            this.tcFindMatch.TabButtonSize = new System.Drawing.Size(180, 337);
            this.tcFindMatch.TabIndex = 1;
            this.tcFindMatch.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            // 
            // tpBloodUnitInfo
            // 
            this.tpBloodUnitInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tpBloodUnitInfo.Controls.Add(this.NotFoundPanel);
            this.tpBloodUnitInfo.Controls.Add(this.WaitingPanel);
            this.tpBloodUnitInfo.Controls.Add(this.btnChooseManullay);
            this.tpBloodUnitInfo.Controls.Add(this.ctrlBloodUnitInfo1);
            this.tpBloodUnitInfo.Controls.Add(this.btnClose);
            this.tpBloodUnitInfo.Controls.Add(this.btnNext);
            this.tpBloodUnitInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpBloodUnitInfo.Location = new System.Drawing.Point(184, 4);
            this.tpBloodUnitInfo.Name = "tpBloodUnitInfo";
            this.tpBloodUnitInfo.Size = new System.Drawing.Size(934, 672);
            this.tpBloodUnitInfo.TabIndex = 2;
            this.tpBloodUnitInfo.Text = "Blood Match";
            // 
            // NotFoundPanel
            // 
            this.NotFoundPanel.Controls.Add(this.label1);
            this.NotFoundPanel.Controls.Add(this.guna2PictureBox1);
            this.NotFoundPanel.Location = new System.Drawing.Point(9, 0);
            this.NotFoundPanel.Name = "NotFoundPanel";
            this.NotFoundPanel.Size = new System.Drawing.Size(920, 602);
            this.NotFoundPanel.TabIndex = 127;
            this.NotFoundPanel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 412);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(595, 61);
            this.label1.TabIndex = 28;
            this.label1.Text = "There\'s No Match Found !! ";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::BBMS.Properties.Resources.BagNotFound;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(274, 56);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(429, 353);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 0;
            this.guna2PictureBox1.TabStop = false;
            // 
            // WaitingPanel
            // 
            this.WaitingPanel.Controls.Add(this.guna2CircleProgressBar2);
            this.WaitingPanel.Controls.Add(this.lblFindTitle);
            this.WaitingPanel.Location = new System.Drawing.Point(12, 0);
            this.WaitingPanel.Name = "WaitingPanel";
            this.WaitingPanel.Size = new System.Drawing.Size(920, 602);
            this.WaitingPanel.TabIndex = 126;
            // 
            // guna2CircleProgressBar2
            // 
            this.guna2CircleProgressBar2.Animated = true;
            this.guna2CircleProgressBar2.AnimationSpeed = 1F;
            this.guna2CircleProgressBar2.Controls.Add(this.guna2PictureBox2);
            this.guna2CircleProgressBar2.FillColor = System.Drawing.Color.Transparent;
            this.guna2CircleProgressBar2.FillThickness = 50;
            this.guna2CircleProgressBar2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.guna2CircleProgressBar2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleProgressBar2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2CircleProgressBar2.Location = new System.Drawing.Point(309, 113);
            this.guna2CircleProgressBar2.Minimum = 0;
            this.guna2CircleProgressBar2.Name = "guna2CircleProgressBar2";
            this.guna2CircleProgressBar2.ProgressColor = System.Drawing.Color.LightCoral;
            this.guna2CircleProgressBar2.ProgressColor2 = System.Drawing.Color.Firebrick;
            this.guna2CircleProgressBar2.ProgressEndCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2CircleProgressBar2.ProgressStartCap = System.Drawing.Drawing2D.LineCap.Round;
            this.guna2CircleProgressBar2.ProgressThickness = 30;
            this.guna2CircleProgressBar2.ShadowDecoration.BorderRadius = 20;
            this.guna2CircleProgressBar2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleProgressBar2.Size = new System.Drawing.Size(296, 296);
            this.guna2CircleProgressBar2.TabIndex = 28;
            this.guna2CircleProgressBar2.Text = "guna2CircleProgressBar2";
            this.guna2CircleProgressBar2.Value = 75;
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::BBMS.Properties.Resources.magnifier__1_;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(20, 55);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(250, 175);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox2.TabIndex = 23;
            this.guna2PictureBox2.TabStop = false;
            // 
            // lblFindTitle
            // 
            this.lblFindTitle.AutoSize = true;
            this.lblFindTitle.Font = new System.Drawing.Font("Segoe UI", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindTitle.Location = new System.Drawing.Point(120, 429);
            this.lblFindTitle.Name = "lblFindTitle";
            this.lblFindTitle.Size = new System.Drawing.Size(692, 61);
            this.lblFindTitle.TabIndex = 27;
            this.lblFindTitle.Text = "Searching For A Blood Match ...";
            // 
            // btnChooseManullay
            // 
            this.btnChooseManullay.Animated = true;
            this.btnChooseManullay.BackColor = System.Drawing.Color.Transparent;
            this.btnChooseManullay.BorderRadius = 15;
            this.btnChooseManullay.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChooseManullay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseManullay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChooseManullay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChooseManullay.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChooseManullay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChooseManullay.FillColor = System.Drawing.Color.IndianRed;
            this.btnChooseManullay.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnChooseManullay.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseManullay.ForeColor = System.Drawing.Color.White;
            this.btnChooseManullay.Location = new System.Drawing.Point(492, 608);
            this.btnChooseManullay.Name = "btnChooseManullay";
            this.btnChooseManullay.Size = new System.Drawing.Size(237, 56);
            this.btnChooseManullay.TabIndex = 124;
            this.btnChooseManullay.Text = "Choose Manually";
            this.btnChooseManullay.UseTransparentBackground = true;
            this.btnChooseManullay.Visible = false;
            this.btnChooseManullay.Click += new System.EventHandler(this.btnChooseManullay_Click);
            // 
            // ctrlBloodUnitInfo1
            // 
            this.ctrlBloodUnitInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlBloodUnitInfo1.Location = new System.Drawing.Point(12, -4);
            this.ctrlBloodUnitInfo1.Name = "ctrlBloodUnitInfo1";
            this.ctrlBloodUnitInfo1.Size = new System.Drawing.Size(908, 602);
            this.ctrlBloodUnitInfo1.TabIndex = 121;
            this.ctrlBloodUnitInfo1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Animated = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderRadius = 15;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.IndianRed;
            this.btnClose.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(12, 608);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 56);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Cancel";
            this.btnClose.UseTransparentBackground = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNext
            // 
            this.btnNext.Animated = true;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.BorderRadius = 15;
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.IndianRed;
            this.btnNext.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(758, 608);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(162, 56);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Visible = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpTransfusionInfo
            // 
            this.tpTransfusionInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tpTransfusionInfo.Controls.Add(this.guna2GradientPanel2);
            this.tpTransfusionInfo.Controls.Add(this.dgvListNurses);
            this.tpTransfusionInfo.Controls.Add(this.label10);
            this.tpTransfusionInfo.Controls.Add(this.label9);
            this.tpTransfusionInfo.Controls.Add(this.btnBack);
            this.tpTransfusionInfo.Controls.Add(this.btnCancel);
            this.tpTransfusionInfo.Controls.Add(this.btnSave);
            this.tpTransfusionInfo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTransfusionInfo.Location = new System.Drawing.Point(184, 4);
            this.tpTransfusionInfo.Name = "tpTransfusionInfo";
            this.tpTransfusionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpTransfusionInfo.Size = new System.Drawing.Size(934, 672);
            this.tpTransfusionInfo.TabIndex = 1;
            this.tpTransfusionInfo.Text = "Transufsion Info";
            // 
            // guna2GradientPanel2
            // 
            this.guna2GradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel2.BorderRadius = 25;
            this.guna2GradientPanel2.Controls.Add(this.llblPatientInfo);
            this.guna2GradientPanel2.Controls.Add(this.lblPtientInfo);
            this.guna2GradientPanel2.Controls.Add(this.lblTransfusionDateValue);
            this.guna2GradientPanel2.Controls.Add(this.lblTransfusionDate);
            this.guna2GradientPanel2.Controls.Add(this.lblRequestedVolumeValue);
            this.guna2GradientPanel2.Controls.Add(this.lblRequestedVolume);
            this.guna2GradientPanel2.Controls.Add(this.lblNurseIDValue);
            this.guna2GradientPanel2.Controls.Add(this.lblNurseID);
            this.guna2GradientPanel2.Controls.Add(this.lblTransfusionID);
            this.guna2GradientPanel2.Controls.Add(this.lblTransfusionIDValue);
            this.guna2GradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel2.FillColor2 = System.Drawing.Color.IndianRed;
            this.guna2GradientPanel2.Location = new System.Drawing.Point(6, 3);
            this.guna2GradientPanel2.Name = "guna2GradientPanel2";
            this.guna2GradientPanel2.ShadowDecoration.BorderRadius = 15;
            this.guna2GradientPanel2.ShadowDecoration.Depth = 25;
            this.guna2GradientPanel2.Size = new System.Drawing.Size(910, 258);
            this.guna2GradientPanel2.TabIndex = 117;
            // 
            // llblPatientInfo
            // 
            this.llblPatientInfo.ActiveLinkColor = System.Drawing.Color.White;
            this.llblPatientInfo.AutoSize = true;
            this.llblPatientInfo.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblPatientInfo.LinkColor = System.Drawing.Color.Black;
            this.llblPatientInfo.Location = new System.Drawing.Point(232, 186);
            this.llblPatientInfo.Name = "llblPatientInfo";
            this.llblPatientInfo.Size = new System.Drawing.Size(175, 37);
            this.llblPatientInfo.TabIndex = 142;
            this.llblPatientInfo.TabStop = true;
            this.llblPatientInfo.Text = "Patient Info";
            this.llblPatientInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblPatientInfo_LinkClicked);
            // 
            // lblPtientInfo
            // 
            this.lblPtientInfo.AutoSize = true;
            this.lblPtientInfo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPtientInfo.ForeColor = System.Drawing.Color.White;
            this.lblPtientInfo.Location = new System.Drawing.Point(20, 180);
            this.lblPtientInfo.Name = "lblPtientInfo";
            this.lblPtientInfo.Size = new System.Drawing.Size(213, 45);
            this.lblPtientInfo.TabIndex = 141;
            this.lblPtientInfo.Text = "Patient Info :";
            // 
            // lblTransfusionDateValue
            // 
            this.lblTransfusionDateValue.AutoSize = true;
            this.lblTransfusionDateValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTransfusionDateValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfusionDateValue.ForeColor = System.Drawing.Color.White;
            this.lblTransfusionDateValue.Location = new System.Drawing.Point(698, 46);
            this.lblTransfusionDateValue.Name = "lblTransfusionDateValue";
            this.lblTransfusionDateValue.Size = new System.Drawing.Size(36, 32);
            this.lblTransfusionDateValue.TabIndex = 128;
            this.lblTransfusionDateValue.Text = "??";
            // 
            // lblTransfusionDate
            // 
            this.lblTransfusionDate.AutoSize = true;
            this.lblTransfusionDate.BackColor = System.Drawing.Color.Transparent;
            this.lblTransfusionDate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfusionDate.ForeColor = System.Drawing.Color.White;
            this.lblTransfusionDate.Location = new System.Drawing.Point(455, 41);
            this.lblTransfusionDate.Name = "lblTransfusionDate";
            this.lblTransfusionDate.Size = new System.Drawing.Size(246, 37);
            this.lblTransfusionDate.TabIndex = 127;
            this.lblTransfusionDate.Text = "Transfusion Date :";
            // 
            // lblRequestedVolumeValue
            // 
            this.lblRequestedVolumeValue.AutoSize = true;
            this.lblRequestedVolumeValue.BackColor = System.Drawing.Color.Transparent;
            this.lblRequestedVolumeValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedVolumeValue.ForeColor = System.Drawing.Color.White;
            this.lblRequestedVolumeValue.Location = new System.Drawing.Point(286, 109);
            this.lblRequestedVolumeValue.Name = "lblRequestedVolumeValue";
            this.lblRequestedVolumeValue.Size = new System.Drawing.Size(36, 32);
            this.lblRequestedVolumeValue.TabIndex = 126;
            this.lblRequestedVolumeValue.Text = "??";
            // 
            // lblRequestedVolume
            // 
            this.lblRequestedVolume.AutoSize = true;
            this.lblRequestedVolume.BackColor = System.Drawing.Color.Transparent;
            this.lblRequestedVolume.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequestedVolume.ForeColor = System.Drawing.Color.White;
            this.lblRequestedVolume.Location = new System.Drawing.Point(19, 105);
            this.lblRequestedVolume.Name = "lblRequestedVolume";
            this.lblRequestedVolume.Size = new System.Drawing.Size(270, 37);
            this.lblRequestedVolume.TabIndex = 125;
            this.lblRequestedVolume.Text = "Requested Volume :";
            // 
            // lblNurseIDValue
            // 
            this.lblNurseIDValue.AutoSize = true;
            this.lblNurseIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblNurseIDValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurseIDValue.ForeColor = System.Drawing.Color.White;
            this.lblNurseIDValue.Location = new System.Drawing.Point(592, 130);
            this.lblNurseIDValue.Name = "lblNurseIDValue";
            this.lblNurseIDValue.Size = new System.Drawing.Size(36, 32);
            this.lblNurseIDValue.TabIndex = 123;
            this.lblNurseIDValue.Text = "??";
            // 
            // lblNurseID
            // 
            this.lblNurseID.AutoSize = true;
            this.lblNurseID.BackColor = System.Drawing.Color.Transparent;
            this.lblNurseID.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNurseID.ForeColor = System.Drawing.Color.White;
            this.lblNurseID.Location = new System.Drawing.Point(455, 125);
            this.lblNurseID.Name = "lblNurseID";
            this.lblNurseID.Size = new System.Drawing.Size(142, 37);
            this.lblNurseID.TabIndex = 122;
            this.lblNurseID.Text = "Nurse ID :";
            // 
            // lblTransfusionID
            // 
            this.lblTransfusionID.AutoSize = true;
            this.lblTransfusionID.BackColor = System.Drawing.Color.Transparent;
            this.lblTransfusionID.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfusionID.ForeColor = System.Drawing.Color.White;
            this.lblTransfusionID.Location = new System.Drawing.Point(19, 37);
            this.lblTransfusionID.Name = "lblTransfusionID";
            this.lblTransfusionID.Size = new System.Drawing.Size(214, 37);
            this.lblTransfusionID.TabIndex = 114;
            this.lblTransfusionID.Text = "Transfusion ID :";
            // 
            // lblTransfusionIDValue
            // 
            this.lblTransfusionIDValue.AutoSize = true;
            this.lblTransfusionIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTransfusionIDValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransfusionIDValue.ForeColor = System.Drawing.Color.White;
            this.lblTransfusionIDValue.Location = new System.Drawing.Point(231, 41);
            this.lblTransfusionIDValue.Name = "lblTransfusionIDValue";
            this.lblTransfusionIDValue.Size = new System.Drawing.Size(36, 32);
            this.lblTransfusionIDValue.TabIndex = 115;
            this.lblTransfusionIDValue.Text = "??";
            // 
            // dgvListNurses
            // 
            this.dgvListNurses.AllowUserToAddRows = false;
            this.dgvListNurses.AllowUserToDeleteRows = false;
            this.dgvListNurses.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(213)))), ((int)(((byte)(226)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvListNurses.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListNurses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvListNurses.BackgroundColor = System.Drawing.Color.Snow;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(70)))), ((int)(((byte)(99)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListNurses.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListNurses.ColumnHeadersHeight = 46;
            this.dgvListNurses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListNurses.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListNurses.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListNurses.Location = new System.Drawing.Point(6, 324);
            this.dgvListNurses.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListNurses.Name = "dgvListNurses";
            this.dgvListNurses.ReadOnly = true;
            this.dgvListNurses.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListNurses.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListNurses.RowHeadersVisible = false;
            this.dgvListNurses.RowHeadersWidth = 51;
            this.dgvListNurses.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.dgvListNurses.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListNurses.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(213)))), ((int)(((byte)(226)))));
            this.dgvListNurses.RowTemplate.Height = 35;
            this.dgvListNurses.Size = new System.Drawing.Size(911, 269);
            this.dgvListNurses.TabIndex = 114;
            this.dgvListNurses.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListNurses.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvListNurses.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvListNurses.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvListNurses.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvListNurses.ThemeStyle.BackColor = System.Drawing.Color.Snow;
            this.dgvListNurses.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListNurses.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvListNurses.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvListNurses.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListNurses.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvListNurses.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvListNurses.ThemeStyle.HeaderStyle.Height = 46;
            this.dgvListNurses.ThemeStyle.ReadOnly = true;
            this.dgvListNurses.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvListNurses.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvListNurses.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListNurses.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListNurses.ThemeStyle.RowsStyle.Height = 35;
            this.dgvListNurses.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvListNurses.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvListNurses.DoubleClick += new System.EventHandler(this.dgvListNurses_DoubleClick);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(3, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(600, 58);
            this.label10.TabIndex = 115;
            this.label10.Text = "Choose A Nurse for Blood Transfusion";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(595, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 45);
            this.label9.TabIndex = 116;
            this.label9.Text = ":";
            // 
            // btnBack
            // 
            this.btnBack.Animated = true;
            this.btnBack.BackColor = System.Drawing.Color.Transparent;
            this.btnBack.BorderRadius = 15;
            this.btnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBack.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBack.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBack.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBack.FillColor = System.Drawing.Color.IndianRed;
            this.btnBack.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(563, 610);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(162, 56);
            this.btnBack.TabIndex = 101;
            this.btnBack.Text = "Back";
            this.btnBack.UseTransparentBackground = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Animated = true;
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.BorderRadius = 15;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.IndianRed;
            this.btnCancel.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 610);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 56);
            this.btnCancel.TabIndex = 100;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseTransparentBackground = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Animated = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BorderRadius = 15;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.IndianRed;
            this.btnSave.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(754, 610);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 56);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2ContextMenuStrip1
            // 
            this.guna2ContextMenuStrip1.Name = "guna2ContextMenuStrip1";
            this.guna2ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.guna2ContextMenuStrip1.RenderStyle.ArrowColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.BorderColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.ColorTable = null;
            this.guna2ContextMenuStrip1.RenderStyle.RoundedEdges = true;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionArrowColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2ContextMenuStrip1.RenderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.guna2ContextMenuStrip1.RenderStyle.SeparatorColor = System.Drawing.Color.Gainsboro;
            this.guna2ContextMenuStrip1.RenderStyle.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.guna2ContextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.MainPanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmMakeTransfusion
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1155, 774);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMakeTransfusion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmMakeTransfusion";
            this.Load += new System.EventHandler(this.frmMakeTransfusion_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.tcFindMatch.ResumeLayout(false);
            this.tpBloodUnitInfo.ResumeLayout(false);
            this.NotFoundPanel.ResumeLayout(false);
            this.NotFoundPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.WaitingPanel.ResumeLayout(false);
            this.WaitingPanel.PerformLayout();
            this.guna2CircleProgressBar2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            this.tpTransfusionInfo.ResumeLayout(false);
            this.tpTransfusionInfo.PerformLayout();
            this.guna2GradientPanel2.ResumeLayout(false);
            this.guna2GradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListNurses)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox4;
        private Guna.UI2.WinForms.Guna2TabControl tcFindMatch;
        private System.Windows.Forms.TabPage tpBloodUnitInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private System.Windows.Forms.TabPage tpTransfusionInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnBack;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Controls.ctrlBloodUnitInfo ctrlBloodUnitInfo1;
        private Guna.UI2.WinForms.Guna2GradientButton btnChooseManullay;
        private System.Windows.Forms.Label lblMatchFound;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2GradientPanel WaitingPanel;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private System.Windows.Forms.Label lblFindTitle;
        private Guna.UI2.WinForms.Guna2DataGridView dgvListNurses;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel2;
        private System.Windows.Forms.Label lblNurseIDValue;
        private System.Windows.Forms.Label lblNurseID;
        private System.Windows.Forms.Label lblTransfusionID;
        private System.Windows.Forms.Label lblTransfusionIDValue;
        private System.Windows.Forms.Label lblTransfusionDateValue;
        private System.Windows.Forms.Label lblTransfusionDate;
        private System.Windows.Forms.Label lblRequestedVolumeValue;
        private System.Windows.Forms.Label lblRequestedVolume;
        private System.Windows.Forms.LinkLabel llblPatientInfo;
        private System.Windows.Forms.Label lblPtientInfo;
        private Guna.UI2.WinForms.Guna2ContextMenuStrip guna2ContextMenuStrip1;
        private Guna.UI2.WinForms.Guna2GradientPanel NotFoundPanel;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}