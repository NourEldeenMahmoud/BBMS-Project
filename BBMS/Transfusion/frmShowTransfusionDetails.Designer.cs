namespace BBMS.Transfusion
{
    partial class frmShowTransfusionDetails
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
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.ctrlTransfusionRequestDetails1 = new BBMS.Controls.ctrlTransfusionRequestDetails();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 50;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // ctrlTransfusionRequestDetails1
            // 
            this.ctrlTransfusionRequestDetails1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlTransfusionRequestDetails1.Location = new System.Drawing.Point(2, 4);
            this.ctrlTransfusionRequestDetails1.Name = "ctrlTransfusionRequestDetails1";
            this.ctrlTransfusionRequestDetails1.Size = new System.Drawing.Size(785, 807);
            this.ctrlTransfusionRequestDetails1.TabIndex = 0;
            // 
            // frmShowTransfusionDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(793, 815);
            this.Controls.Add(this.ctrlTransfusionRequestDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowTransfusionDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowTransfusionDetails";
            this.Load += new System.EventHandler(this.frmShowTransfusionDetails_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlTransfusionRequestDetails ctrlTransfusionRequestDetails1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}