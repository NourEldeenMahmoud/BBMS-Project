namespace BBMS.Controls
{
    partial class ctrlFindPatient
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnShowAllPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPatient = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindPatient = new Guna.UI2.WinForms.Guna2Button();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFindBy = new System.Windows.Forms.Label();
            this.ctrlPersonCardWithNoTitle1 = new BBMS.Controls.ctrlPersonCardWithNoTitle();
            this.guna2GradientPanel4 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.lblPatientID = new System.Windows.Forms.Label();
            this.lblBloodTypeValue = new System.Windows.Forms.Label();
            this.lblPatientIDValue = new System.Windows.Forms.Label();
            this.lblBloodType = new System.Windows.Forms.Label();
            this.lblMedicalCondition = new System.Windows.Forms.Label();
            this.lblMedicalConditionValue = new System.Windows.Forms.Label();
            this.SearchPanel.SuspendLayout();
            this.guna2GradientPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.Transparent;
            this.SearchPanel.BorderRadius = 15;
            this.SearchPanel.Controls.Add(this.btnShowAllPeople);
            this.SearchPanel.Controls.Add(this.btnAddPatient);
            this.SearchPanel.Controls.Add(this.btnFindPatient);
            this.SearchPanel.Controls.Add(this.txtSearch);
            this.SearchPanel.Controls.Add(this.lblFindBy);
            this.SearchPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.SearchPanel.FillColor2 = System.Drawing.Color.IndianRed;
            this.SearchPanel.Location = new System.Drawing.Point(3, 9);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.ShadowDecoration.BorderRadius = 15;
            this.SearchPanel.ShadowDecoration.Depth = 25;
            this.SearchPanel.Size = new System.Drawing.Size(802, 76);
            this.SearchPanel.TabIndex = 41;
            // 
            // btnShowAllPeople
            // 
            this.btnShowAllPeople.Animated = true;
            this.btnShowAllPeople.AutoRoundedCorners = true;
            this.btnShowAllPeople.BackgroundImage = global::BBMS.Properties.Resources.group;
            this.btnShowAllPeople.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnShowAllPeople.BorderColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.FillColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowAllPeople.ForeColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllPeople.Location = new System.Drawing.Point(708, 11);
            this.btnShowAllPeople.Name = "btnShowAllPeople";
            this.btnShowAllPeople.PressedColor = System.Drawing.Color.Transparent;
            this.btnShowAllPeople.Size = new System.Drawing.Size(58, 58);
            this.btnShowAllPeople.TabIndex = 60;
            this.btnShowAllPeople.Click += new System.EventHandler(this.btnShowAllPeople_Click);
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Animated = true;
            this.btnAddPatient.AutoRoundedCorners = true;
            this.btnAddPatient.BackgroundImage = global::BBMS.Properties.Resources.add;
            this.btnAddPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPatient.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPatient.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.Location = new System.Drawing.Point(625, 11);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.PressedColor = System.Drawing.Color.Transparent;
            this.btnAddPatient.Size = new System.Drawing.Size(58, 58);
            this.btnAddPatient.TabIndex = 42;
            this.btnAddPatient.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFindPatient
            // 
            this.btnFindPatient.Animated = true;
            this.btnFindPatient.AutoRoundedCorners = true;
            this.btnFindPatient.BackgroundImage = global::BBMS.Properties.Resources.search;
            this.btnFindPatient.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPatient.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.FillColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindPatient.ForeColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.Location = new System.Drawing.Point(526, 11);
            this.btnFindPatient.Name = "btnFindPatient";
            this.btnFindPatient.PressedColor = System.Drawing.Color.Transparent;
            this.btnFindPatient.Size = new System.Drawing.Size(58, 58);
            this.btnFindPatient.TabIndex = 41;
            this.btnFindPatient.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtSearch.BorderColor = System.Drawing.Color.Black;
            this.txtSearch.BorderRadius = 10;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.MediumBlue;
            this.txtSearch.Location = new System.Drawing.Point(262, 21);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "";
            this.txtSearch.SelectedText = "";
            this.txtSearch.ShadowDecoration.BorderRadius = 15;
            this.txtSearch.ShadowDecoration.Depth = 25;
            this.txtSearch.ShadowDecoration.Enabled = true;
            this.txtSearch.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 3, 9);
            this.txtSearch.Size = new System.Drawing.Size(215, 36);
            this.txtSearch.TabIndex = 48;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblFindBy
            // 
            this.lblFindBy.AutoSize = true;
            this.lblFindBy.BackColor = System.Drawing.Color.Transparent;
            this.lblFindBy.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindBy.ForeColor = System.Drawing.Color.White;
            this.lblFindBy.Location = new System.Drawing.Point(27, 21);
            this.lblFindBy.Name = "lblFindBy";
            this.lblFindBy.Size = new System.Drawing.Size(239, 32);
            this.lblFindBy.TabIndex = 34;
            this.lblFindBy.Text = "Find By Patient ID : ";
            // 
            // ctrlPersonCardWithNoTitle1
            // 
            this.ctrlPersonCardWithNoTitle1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithNoTitle1.Location = new System.Drawing.Point(0, 88);
            this.ctrlPersonCardWithNoTitle1.Name = "ctrlPersonCardWithNoTitle1";
            this.ctrlPersonCardWithNoTitle1.Size = new System.Drawing.Size(811, 431);
            this.ctrlPersonCardWithNoTitle1.TabIndex = 42;
            // 
            // guna2GradientPanel4
            // 
            this.guna2GradientPanel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel4.BorderRadius = 20;
            this.guna2GradientPanel4.Controls.Add(this.lblPatientID);
            this.guna2GradientPanel4.Controls.Add(this.lblBloodTypeValue);
            this.guna2GradientPanel4.Controls.Add(this.lblPatientIDValue);
            this.guna2GradientPanel4.Controls.Add(this.lblBloodType);
            this.guna2GradientPanel4.Controls.Add(this.lblMedicalCondition);
            this.guna2GradientPanel4.Controls.Add(this.lblMedicalConditionValue);
            this.guna2GradientPanel4.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel4.FillColor2 = System.Drawing.Color.IndianRed;
            this.guna2GradientPanel4.Location = new System.Drawing.Point(3, 523);
            this.guna2GradientPanel4.Name = "guna2GradientPanel4";
            this.guna2GradientPanel4.ShadowDecoration.BorderRadius = 15;
            this.guna2GradientPanel4.ShadowDecoration.Depth = 25;
            this.guna2GradientPanel4.Size = new System.Drawing.Size(802, 151);
            this.guna2GradientPanel4.TabIndex = 71;
            // 
            // lblPatientID
            // 
            this.lblPatientID.AutoSize = true;
            this.lblPatientID.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientID.ForeColor = System.Drawing.Color.White;
            this.lblPatientID.Location = new System.Drawing.Point(33, 22);
            this.lblPatientID.Name = "lblPatientID";
            this.lblPatientID.Size = new System.Drawing.Size(159, 37);
            this.lblPatientID.TabIndex = 60;
            this.lblPatientID.Text = "Patient ID :";
            // 
            // lblBloodTypeValue
            // 
            this.lblBloodTypeValue.AutoSize = true;
            this.lblBloodTypeValue.BackColor = System.Drawing.Color.Transparent;
            this.lblBloodTypeValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodTypeValue.ForeColor = System.Drawing.Color.White;
            this.lblBloodTypeValue.Location = new System.Drawing.Point(677, 27);
            this.lblBloodTypeValue.Name = "lblBloodTypeValue";
            this.lblBloodTypeValue.Size = new System.Drawing.Size(36, 32);
            this.lblBloodTypeValue.TabIndex = 67;
            this.lblBloodTypeValue.Text = "??";
            // 
            // lblPatientIDValue
            // 
            this.lblPatientIDValue.AutoSize = true;
            this.lblPatientIDValue.BackColor = System.Drawing.Color.Transparent;
            this.lblPatientIDValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientIDValue.ForeColor = System.Drawing.Color.White;
            this.lblPatientIDValue.Location = new System.Drawing.Point(188, 27);
            this.lblPatientIDValue.Name = "lblPatientIDValue";
            this.lblPatientIDValue.Size = new System.Drawing.Size(36, 32);
            this.lblPatientIDValue.TabIndex = 61;
            this.lblPatientIDValue.Text = "??";
            // 
            // lblBloodType
            // 
            this.lblBloodType.AutoSize = true;
            this.lblBloodType.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBloodType.ForeColor = System.Drawing.Color.White;
            this.lblBloodType.Location = new System.Drawing.Point(504, 22);
            this.lblBloodType.Name = "lblBloodType";
            this.lblBloodType.Size = new System.Drawing.Size(176, 37);
            this.lblBloodType.TabIndex = 62;
            this.lblBloodType.Text = "Blood Type :";
            // 
            // lblMedicalCondition
            // 
            this.lblMedicalCondition.AutoSize = true;
            this.lblMedicalCondition.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalCondition.ForeColor = System.Drawing.Color.White;
            this.lblMedicalCondition.Location = new System.Drawing.Point(33, 85);
            this.lblMedicalCondition.Name = "lblMedicalCondition";
            this.lblMedicalCondition.Size = new System.Drawing.Size(267, 37);
            this.lblMedicalCondition.TabIndex = 66;
            this.lblMedicalCondition.Text = "Medical Condition :";
            // 
            // lblMedicalConditionValue
            // 
            this.lblMedicalConditionValue.AutoSize = true;
            this.lblMedicalConditionValue.BackColor = System.Drawing.Color.Transparent;
            this.lblMedicalConditionValue.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMedicalConditionValue.ForeColor = System.Drawing.Color.White;
            this.lblMedicalConditionValue.Location = new System.Drawing.Point(296, 90);
            this.lblMedicalConditionValue.Name = "lblMedicalConditionValue";
            this.lblMedicalConditionValue.Size = new System.Drawing.Size(36, 32);
            this.lblMedicalConditionValue.TabIndex = 63;
            this.lblMedicalConditionValue.Text = "??";
            // 
            // ctrlFindPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.guna2GradientPanel4);
            this.Controls.Add(this.ctrlPersonCardWithNoTitle1);
            this.Controls.Add(this.SearchPanel);
            this.Name = "ctrlFindPatient";
            this.Size = new System.Drawing.Size(811, 694);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.guna2GradientPanel4.ResumeLayout(false);
            this.guna2GradientPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GradientPanel SearchPanel;
        private Guna.UI2.WinForms.Guna2Button btnShowAllPeople;
        private Guna.UI2.WinForms.Guna2Button btnAddPatient;
        private Guna.UI2.WinForms.Guna2Button btnFindPatient;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblFindBy;
        private ctrlPersonCardWithNoTitle ctrlPersonCardWithNoTitle1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel4;
        private System.Windows.Forms.Label lblPatientID;
        private System.Windows.Forms.Label lblBloodTypeValue;
        private System.Windows.Forms.Label lblPatientIDValue;
        private System.Windows.Forms.Label lblBloodType;
        private System.Windows.Forms.Label lblMedicalCondition;
        private System.Windows.Forms.Label lblMedicalConditionValue;
    }
}
