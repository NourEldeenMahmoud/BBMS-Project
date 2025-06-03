namespace BBMS
{
    partial class ctrlPersonCardWithFilter
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.SearchPanel = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.btnShowAllPeople = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPerson = new Guna.UI2.WinForms.Guna2Button();
            this.btnFindPerson = new Guna.UI2.WinForms.Guna2Button();
            this.cbFilter = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFindBy = new System.Windows.Forms.Label();
            this.ctrlPersonCardWithNoTitle1 = new BBMS.Controls.ctrlPersonCardWithNoTitle();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SearchPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SearchPanel
            // 
            this.SearchPanel.BackColor = System.Drawing.Color.Transparent;
            this.SearchPanel.BorderRadius = 15;
            this.SearchPanel.Controls.Add(this.btnShowAllPeople);
            this.SearchPanel.Controls.Add(this.btnAddPerson);
            this.SearchPanel.Controls.Add(this.btnFindPerson);
            this.SearchPanel.Controls.Add(this.cbFilter);
            this.SearchPanel.Controls.Add(this.txtSearch);
            this.SearchPanel.Controls.Add(this.lblFindBy);
            this.SearchPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.SearchPanel.FillColor2 = System.Drawing.Color.IndianRed;
            this.SearchPanel.Location = new System.Drawing.Point(8, 3);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.ShadowDecoration.BorderRadius = 15;
            this.SearchPanel.ShadowDecoration.Depth = 25;
            this.SearchPanel.Size = new System.Drawing.Size(802, 76);
            this.SearchPanel.TabIndex = 40;
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
            // btnAddPerson
            // 
            this.btnAddPerson.Animated = true;
            this.btnAddPerson.AutoRoundedCorners = true;
            this.btnAddPerson.BackgroundImage = global::BBMS.Properties.Resources.add;
            this.btnAddPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddPerson.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPerson.ForeColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.HoverState.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPerson.Location = new System.Drawing.Point(625, 11);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.PressedColor = System.Drawing.Color.Transparent;
            this.btnAddPerson.Size = new System.Drawing.Size(58, 58);
            this.btnAddPerson.TabIndex = 42;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnFindPerson
            // 
            this.btnFindPerson.Animated = true;
            this.btnFindPerson.AutoRoundedCorners = true;
            this.btnFindPerson.BackgroundImage = global::BBMS.Properties.Resources.search;
            this.btnFindPerson.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFindPerson.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.DisabledState.BorderColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.DisabledState.CustomBorderColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.DisabledState.FillColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.DisabledState.ForeColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.FillColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFindPerson.ForeColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.Location = new System.Drawing.Point(526, 11);
            this.btnFindPerson.Name = "btnFindPerson";
            this.btnFindPerson.PressedColor = System.Drawing.Color.Transparent;
            this.btnFindPerson.Size = new System.Drawing.Size(58, 58);
            this.btnFindPerson.TabIndex = 41;
            this.btnFindPerson.Click += new System.EventHandler(this.btnFindPerson_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.AutoRoundedCorners = true;
            this.cbFilter.BackColor = System.Drawing.Color.Transparent;
            this.cbFilter.BorderColor = System.Drawing.Color.Black;
            this.cbFilter.BorderRadius = 17;
            this.cbFilter.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFilter.DropDownHeight = 150;
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(182)))), ((int)(((byte)(205)))));
            this.cbFilter.FocusedColor = System.Drawing.Color.Empty;
            this.cbFilter.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.cbFilter.ForeColor = System.Drawing.Color.Black;
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.IntegralHeight = false;
            this.cbFilter.ItemHeight = 30;
            this.cbFilter.Items.AddRange(new object[] {
            "PersonID",
            "NationalNo"});
            this.cbFilter.Location = new System.Drawing.Point(128, 21);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.ShadowDecoration.BorderRadius = 15;
            this.cbFilter.ShadowDecoration.Enabled = true;
            this.cbFilter.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 4, 3, 7);
            this.cbFilter.Size = new System.Drawing.Size(147, 36);
            this.cbFilter.TabIndex = 59;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
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
            this.txtSearch.Location = new System.Drawing.Point(282, 21);
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
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // lblFindBy
            // 
            this.lblFindBy.AutoSize = true;
            this.lblFindBy.BackColor = System.Drawing.Color.Transparent;
            this.lblFindBy.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFindBy.ForeColor = System.Drawing.Color.White;
            this.lblFindBy.Location = new System.Drawing.Point(29, 25);
            this.lblFindBy.Name = "lblFindBy";
            this.lblFindBy.Size = new System.Drawing.Size(93, 25);
            this.lblFindBy.TabIndex = 34;
            this.lblFindBy.Text = "Find By : ";
            // 
            // ctrlPersonCardWithNoTitle1
            // 
            this.ctrlPersonCardWithNoTitle1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlPersonCardWithNoTitle1.Location = new System.Drawing.Point(3, 85);
            this.ctrlPersonCardWithNoTitle1.Name = "ctrlPersonCardWithNoTitle1";
            this.ctrlPersonCardWithNoTitle1.Size = new System.Drawing.Size(809, 431);
            this.ctrlPersonCardWithNoTitle1.TabIndex = 41;
            // 
            // ctrlPersonCardWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ctrlPersonCardWithNoTitle1);
            this.Controls.Add(this.SearchPanel);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "ctrlPersonCardWithFilter";
            this.Size = new System.Drawing.Size(829, 530);
            this.Load += new System.EventHandler(this.ctrlPersonCardWithFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private Guna.UI2.WinForms.Guna2GradientPanel SearchPanel;
        private Guna.UI2.WinForms.Guna2ComboBox cbFilter;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private System.Windows.Forms.Label lblFindBy;
        private Guna.UI2.WinForms.Guna2Button btnFindPerson;
        private Guna.UI2.WinForms.Guna2Button btnAddPerson;
        private Controls.ctrlPersonCardWithNoTitle ctrlPersonCardWithNoTitle1;
        private Guna.UI2.WinForms.Guna2Button btnShowAllPeople;
    }
}
