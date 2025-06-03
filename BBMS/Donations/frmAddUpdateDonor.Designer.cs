namespace BBMS.Donations
{
    partial class frmAddUpdateDonor
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
            this.MainPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.tcAddUpdateDonor = new Guna.UI2.WinForms.Guna2TabControl();
            this.tcPersonInfo = new System.Windows.Forms.TabPage();
            this.btnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnNext = new Guna.UI2.WinForms.Guna2GradientButton();
            this.tpDonorInfo = new System.Windows.Forms.TabPage();
            this.btnBack = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            this.btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMedicallyApproved = new Guna.UI2.WinForms.Guna2CustomCheckBox();
            this.chkDonatedBefore = new System.Windows.Forms.CheckBox();
            this.dtpLastDonation = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblWeight = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            this.txtMedicalRecord = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtHeight = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtWeight = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDonorID = new System.Windows.Forms.Label();
            this.lblDonorIDValue = new System.Windows.Forms.Label();
            this.lblLastDonationDate = new System.Windows.Forms.Label();
            this.lblMedicalRecord = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.ctrlPersonCardWithFilter1 = new BBMS.ctrlPersonCardWithFilter();
            this.MainPanel.SuspendLayout();
            this.tcAddUpdateDonor.SuspendLayout();
            this.tcPersonInfo.SuspendLayout();
            this.tpDonorInfo.SuspendLayout();
            this.guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.MainPanel.BorderColor = System.Drawing.Color.Black;
            this.MainPanel.BorderRadius = 500;
            this.MainPanel.Controls.Add(this.guna2ControlBox2);
            this.MainPanel.Controls.Add(this.guna2ControlBox1);
            this.MainPanel.Controls.Add(this.tcAddUpdateDonor);
            this.MainPanel.Controls.Add(this.lblTitle);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1030, 664);
            this.MainPanel.TabIndex = 4;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.BorderRadius = 10;
            this.guna2ControlBox2.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox2.Location = new System.Drawing.Point(888, 12);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(59, 38);
            this.guna2ControlBox2.TabIndex = 84;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BorderRadius = 10;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.IndianRed;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.White;
            this.guna2ControlBox1.Location = new System.Drawing.Point(953, 12);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(59, 38);
            this.guna2ControlBox1.TabIndex = 3;
            // 
            // tcAddUpdateDonor
            // 
            this.tcAddUpdateDonor.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tcAddUpdateDonor.Controls.Add(this.tcPersonInfo);
            this.tcAddUpdateDonor.Controls.Add(this.tpDonorInfo);
            this.tcAddUpdateDonor.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateDonor.ItemSize = new System.Drawing.Size(180, 295);
            this.tcAddUpdateDonor.Location = new System.Drawing.Point(15, 56);
            this.tcAddUpdateDonor.Name = "tcAddUpdateDonor";
            this.tcAddUpdateDonor.SelectedIndex = 0;
            this.tcAddUpdateDonor.Size = new System.Drawing.Size(1002, 596);
            this.tcAddUpdateDonor.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.tcAddUpdateDonor.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddUpdateDonor.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.tcAddUpdateDonor.TabButtonHoverState.ForeColor = System.Drawing.Color.White;
            this.tcAddUpdateDonor.TabButtonHoverState.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(52)))), ((int)(((byte)(70)))));
            this.tcAddUpdateDonor.TabButtonIdleState.BorderColor = System.Drawing.Color.White;
            this.tcAddUpdateDonor.TabButtonIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(60)))), ((int)(((byte)(99)))));
            this.tcAddUpdateDonor.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateDonor.TabButtonIdleState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(160)))), ((int)(((byte)(167)))));
            this.tcAddUpdateDonor.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.tcAddUpdateDonor.TabButtonSelectedState.BorderColor = System.Drawing.Color.White;
            this.tcAddUpdateDonor.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(104)))), ((int)(((byte)(151)))));
            this.tcAddUpdateDonor.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddUpdateDonor.TabButtonSelectedState.ForeColor = System.Drawing.Color.White;
            this.tcAddUpdateDonor.TabButtonSelectedState.InnerColor = System.Drawing.Color.Transparent;
            this.tcAddUpdateDonor.TabButtonSize = new System.Drawing.Size(180, 295);
            this.tcAddUpdateDonor.TabIndex = 1;
            this.tcAddUpdateDonor.TabMenuBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tcAddUpdateDonor.SelectedIndexChanged += new System.EventHandler(this.tcAddUpdateDonor_SelectedIndexChanged);
            // 
            // tcPersonInfo
            // 
            this.tcPersonInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tcPersonInfo.Controls.Add(this.btnClose);
            this.tcPersonInfo.Controls.Add(this.btnNext);
            this.tcPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tcPersonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcPersonInfo.Location = new System.Drawing.Point(184, 4);
            this.tcPersonInfo.Name = "tcPersonInfo";
            this.tcPersonInfo.Size = new System.Drawing.Size(814, 588);
            this.tcPersonInfo.TabIndex = 2;
            this.tcPersonInfo.Text = "Person Info";
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
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(3, 535);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(162, 47);
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
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(640, 535);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(162, 47);
            this.btnNext.TabIndex = 21;
            this.btnNext.Text = "Next";
            this.btnNext.UseTransparentBackground = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tpDonorInfo
            // 
            this.tpDonorInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.tpDonorInfo.Controls.Add(this.btnBack);
            this.tpDonorInfo.Controls.Add(this.btnCancel);
            this.tpDonorInfo.Controls.Add(this.btnSave);
            this.tpDonorInfo.Controls.Add(this.guna2GradientPanel1);
            this.tpDonorInfo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDonorInfo.Location = new System.Drawing.Point(184, 4);
            this.tpDonorInfo.Name = "tpDonorInfo";
            this.tpDonorInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpDonorInfo.Size = new System.Drawing.Size(814, 588);
            this.tpDonorInfo.TabIndex = 1;
            this.tpDonorInfo.Text = "Donor Info";
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
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(464, 535);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(162, 47);
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
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(6, 535);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(162, 47);
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
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(646, 535);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(162, 47);
            this.btnSave.TabIndex = 99;
            this.btnSave.Text = "Save";
            this.btnSave.UseTransparentBackground = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel1.BorderRadius = 25;
            this.guna2GradientPanel1.Controls.Add(this.label2);
            this.guna2GradientPanel1.Controls.Add(this.chkMedicallyApproved);
            this.guna2GradientPanel1.Controls.Add(this.chkDonatedBefore);
            this.guna2GradientPanel1.Controls.Add(this.dtpLastDonation);
            this.guna2GradientPanel1.Controls.Add(this.lblWeight);
            this.guna2GradientPanel1.Controls.Add(this.lblHeight);
            this.guna2GradientPanel1.Controls.Add(this.txtMedicalRecord);
            this.guna2GradientPanel1.Controls.Add(this.txtHeight);
            this.guna2GradientPanel1.Controls.Add(this.txtWeight);
            this.guna2GradientPanel1.Controls.Add(this.lblDonorID);
            this.guna2GradientPanel1.Controls.Add(this.lblDonorIDValue);
            this.guna2GradientPanel1.Controls.Add(this.lblLastDonationDate);
            this.guna2GradientPanel1.Controls.Add(this.lblMedicalRecord);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.IndianRed;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.ShadowDecoration.BorderRadius = 15;
            this.guna2GradientPanel1.ShadowDecoration.Depth = 25;
            this.guna2GradientPanel1.Size = new System.Drawing.Size(802, 529);
            this.guna2GradientPanel1.TabIndex = 41;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(99, 456);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 37);
            this.label2.TabIndex = 105;
            this.label2.Text = "Medically Approved :";
            // 
            // chkMedicallyApproved
            // 
            this.chkMedicallyApproved.BackColor = System.Drawing.Color.Transparent;
            this.chkMedicallyApproved.CheckedState.BorderColor = System.Drawing.Color.Black;
            this.chkMedicallyApproved.CheckedState.BorderRadius = 2;
            this.chkMedicallyApproved.CheckedState.BorderThickness = 2;
            this.chkMedicallyApproved.CheckedState.FillColor = System.Drawing.Color.White;
            this.chkMedicallyApproved.CheckMarkColor = System.Drawing.Color.Black;
            this.chkMedicallyApproved.Location = new System.Drawing.Point(392, 456);
            this.chkMedicallyApproved.Name = "chkMedicallyApproved";
            this.chkMedicallyApproved.Size = new System.Drawing.Size(49, 37);
            this.chkMedicallyApproved.TabIndex = 103;
            this.chkMedicallyApproved.Text = "guna2CustomCheckBox1";
            this.chkMedicallyApproved.UncheckedState.BorderColor = System.Drawing.Color.White;
            this.chkMedicallyApproved.UncheckedState.BorderRadius = 2;
            this.chkMedicallyApproved.UncheckedState.BorderThickness = 0;
            this.chkMedicallyApproved.UncheckedState.FillColor = System.Drawing.Color.White;
            // 
            // chkDonatedBefore
            // 
            this.chkDonatedBefore.AutoSize = true;
            this.chkDonatedBefore.CausesValidation = false;
            this.chkDonatedBefore.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDonatedBefore.ForeColor = System.Drawing.Color.White;
            this.chkDonatedBefore.Location = new System.Drawing.Point(392, 313);
            this.chkDonatedBefore.Name = "chkDonatedBefore";
            this.chkDonatedBefore.Size = new System.Drawing.Size(172, 29);
            this.chkDonatedBefore.TabIndex = 102;
            this.chkDonatedBefore.Text = "Donated Before";
            this.chkDonatedBefore.UseVisualStyleBackColor = true;
            this.chkDonatedBefore.CheckedChanged += new System.EventHandler(this.btnDonatedBefore_CheckedChanged);
            // 
            // dtpLastDonation
            // 
            this.dtpLastDonation.BackColor = System.Drawing.Color.Transparent;
            this.dtpLastDonation.BorderRadius = 10;
            this.dtpLastDonation.BorderThickness = 1;
            this.dtpLastDonation.Checked = true;
            this.dtpLastDonation.Enabled = false;
            this.dtpLastDonation.FillColor = System.Drawing.SystemColors.ControlLightLight;
            this.dtpLastDonation.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpLastDonation.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpLastDonation.Location = new System.Drawing.Point(392, 262);
            this.dtpLastDonation.MaxDate = new System.DateTime(2007, 12, 31, 0, 0, 0, 0);
            this.dtpLastDonation.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpLastDonation.Name = "dtpLastDonation";
            this.dtpLastDonation.ShadowDecoration.BorderRadius = 15;
            this.dtpLastDonation.ShadowDecoration.Depth = 25;
            this.dtpLastDonation.ShadowDecoration.Enabled = true;
            this.dtpLastDonation.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 3, 4, 7);
            this.dtpLastDonation.Size = new System.Drawing.Size(319, 45);
            this.dtpLastDonation.TabIndex = 101;
            this.dtpLastDonation.Value = new System.DateTime(2007, 12, 31, 0, 0, 0, 0);
            // 
            // lblWeight
            // 
            this.lblWeight.AutoSize = true;
            this.lblWeight.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.ForeColor = System.Drawing.Color.White;
            this.lblWeight.Location = new System.Drawing.Point(99, 112);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(124, 37);
            this.lblWeight.TabIndex = 100;
            this.lblWeight.Text = "Weight :";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeight.ForeColor = System.Drawing.Color.White;
            this.lblHeight.Location = new System.Drawing.Point(99, 187);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(119, 37);
            this.lblHeight.TabIndex = 99;
            this.lblHeight.Text = "Height :";
            // 
            // txtMedicalRecord
            // 
            this.txtMedicalRecord.Animated = true;
            this.txtMedicalRecord.BackColor = System.Drawing.Color.Transparent;
            this.txtMedicalRecord.BorderColor = System.Drawing.Color.Black;
            this.txtMedicalRecord.BorderRadius = 10;
            this.txtMedicalRecord.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMedicalRecord.DefaultText = "";
            this.txtMedicalRecord.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtMedicalRecord.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtMedicalRecord.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedicalRecord.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtMedicalRecord.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.txtMedicalRecord.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtMedicalRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMedicalRecord.ForeColor = System.Drawing.Color.Black;
            this.txtMedicalRecord.HoverState.BorderColor = System.Drawing.Color.MediumBlue;
            this.txtMedicalRecord.Location = new System.Drawing.Point(336, 353);
            this.txtMedicalRecord.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtMedicalRecord.Multiline = true;
            this.txtMedicalRecord.Name = "txtMedicalRecord";
            this.txtMedicalRecord.PlaceholderText = "";
            this.txtMedicalRecord.SelectedText = "";
            this.txtMedicalRecord.ShadowDecoration.BorderRadius = 15;
            this.txtMedicalRecord.ShadowDecoration.Depth = 25;
            this.txtMedicalRecord.ShadowDecoration.Enabled = true;
            this.txtMedicalRecord.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 3, 9);
            this.txtMedicalRecord.Size = new System.Drawing.Size(319, 83);
            this.txtMedicalRecord.TabIndex = 97;
            // 
            // txtHeight
            // 
            this.txtHeight.BackColor = System.Drawing.Color.Transparent;
            this.txtHeight.BorderColor = System.Drawing.Color.Black;
            this.txtHeight.BorderRadius = 10;
            this.txtHeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtHeight.DefaultText = "";
            this.txtHeight.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtHeight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtHeight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHeight.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtHeight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.txtHeight.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHeight.ForeColor = System.Drawing.Color.Black;
            this.txtHeight.HoverState.BorderColor = System.Drawing.Color.MediumBlue;
            this.txtHeight.Location = new System.Drawing.Point(230, 187);
            this.txtHeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.PlaceholderText = "";
            this.txtHeight.SelectedText = "";
            this.txtHeight.ShadowDecoration.BorderRadius = 15;
            this.txtHeight.ShadowDecoration.Depth = 25;
            this.txtHeight.ShadowDecoration.Enabled = true;
            this.txtHeight.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 3, 9);
            this.txtHeight.Size = new System.Drawing.Size(185, 36);
            this.txtHeight.TabIndex = 96;
            this.txtHeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtHeight_Validating);
            // 
            // txtWeight
            // 
            this.txtWeight.BackColor = System.Drawing.Color.Transparent;
            this.txtWeight.BorderColor = System.Drawing.Color.Black;
            this.txtWeight.BorderRadius = 10;
            this.txtWeight.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtWeight.DefaultText = "";
            this.txtWeight.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtWeight.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtWeight.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWeight.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtWeight.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.txtWeight.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWeight.ForeColor = System.Drawing.Color.Black;
            this.txtWeight.HoverState.BorderColor = System.Drawing.Color.MediumBlue;
            this.txtWeight.Location = new System.Drawing.Point(230, 113);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.PlaceholderText = "";
            this.txtWeight.SelectedText = "";
            this.txtWeight.ShadowDecoration.BorderRadius = 15;
            this.txtWeight.ShadowDecoration.Depth = 25;
            this.txtWeight.ShadowDecoration.Enabled = true;
            this.txtWeight.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 3, 9);
            this.txtWeight.Size = new System.Drawing.Size(185, 36);
            this.txtWeight.TabIndex = 95;
            this.txtWeight.Validating += new System.ComponentModel.CancelEventHandler(this.txtWeight_Validating);
            // 
            // lblDonorID
            // 
            this.lblDonorID.AutoSize = true;
            this.lblDonorID.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonorID.ForeColor = System.Drawing.Color.White;
            this.lblDonorID.Location = new System.Drawing.Point(99, 46);
            this.lblDonorID.Name = "lblDonorID";
            this.lblDonorID.Size = new System.Drawing.Size(148, 37);
            this.lblDonorID.TabIndex = 80;
            this.lblDonorID.Text = "Donor ID :";
            // 
            // lblDonorIDValue
            // 
            this.lblDonorIDValue.AutoSize = true;
            this.lblDonorIDValue.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonorIDValue.ForeColor = System.Drawing.Color.White;
            this.lblDonorIDValue.Location = new System.Drawing.Point(253, 46);
            this.lblDonorIDValue.Name = "lblDonorIDValue";
            this.lblDonorIDValue.Size = new System.Drawing.Size(41, 37);
            this.lblDonorIDValue.TabIndex = 88;
            this.lblDonorIDValue.Text = "??";
            // 
            // lblLastDonationDate
            // 
            this.lblLastDonationDate.AutoSize = true;
            this.lblLastDonationDate.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDonationDate.ForeColor = System.Drawing.Color.White;
            this.lblLastDonationDate.Location = new System.Drawing.Point(99, 262);
            this.lblLastDonationDate.Name = "lblLastDonationDate";
            this.lblLastDonationDate.Size = new System.Drawing.Size(278, 37);
            this.lblLastDonationDate.TabIndex = 81;
            this.lblLastDonationDate.Text = "Last Donation Date :";
            // 
            // lblMedicalRecord
            // 
            this.lblMedicalRecord.AutoSize = true;
            this.lblMedicalRecord.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalRecord.ForeColor = System.Drawing.Color.White;
            this.lblMedicalRecord.Location = new System.Drawing.Point(99, 353);
            this.lblMedicalRecord.Name = "lblMedicalRecord";
            this.lblMedicalRecord.Size = new System.Drawing.Size(230, 37);
            this.lblMedicalRecord.TabIndex = 82;
            this.lblMedicalRecord.Text = "Medical Record :";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(432, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(214, 50);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Add Donor";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 40;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.MainPanel;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ctrlPersonCardWithFilter1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.ForeColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(-6, 3);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(820, 526);
            this.ctrlPersonCardWithFilter1.TabIndex = 0;
            this.ctrlPersonCardWithFilter1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCardWithFilter1_OnPersonSelected);
            // 
            // frmAddUpdateDonor
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1029, 664);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAddUpdateDonor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmAddUpdateDonor";
            this.Load += new System.EventHandler(this.frmAddUpdateDonor_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.tcAddUpdateDonor.ResumeLayout(false);
            this.tcPersonInfo.ResumeLayout(false);
            this.tpDonorInfo.ResumeLayout(false);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel MainPanel;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2TabControl tcAddUpdateDonor;
        private System.Windows.Forms.TabPage tcPersonInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnClose;
        private Guna.UI2.WinForms.Guna2GradientButton btnNext;
        private ctrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tpDonorInfo;
        private Guna.UI2.WinForms.Guna2GradientButton btnBack;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtMedicalRecord;
        private Guna.UI2.WinForms.Guna2TextBox txtHeight;
        private Guna.UI2.WinForms.Guna2TextBox txtWeight;
        private System.Windows.Forms.Label lblDonorID;
        private System.Windows.Forms.Label lblDonorIDValue;
        private System.Windows.Forms.Label lblLastDonationDate;
        private System.Windows.Forms.Label lblMedicalRecord;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.Label lblHeight;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLastDonation;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CustomCheckBox chkMedicallyApproved;
        private System.Windows.Forms.CheckBox chkDonatedBefore;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}