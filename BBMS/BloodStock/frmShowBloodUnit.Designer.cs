namespace BBMS.BloodStock
{
    partial class frmShowBloodUnit
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
            this.guna2GradientPanel5 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.ctrlBloodUnitInfo1 = new BBMS.Controls.ctrlBloodUnitInfo();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.guna2GradientPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2GradientPanel5
            // 
            this.guna2GradientPanel5.BackColor = System.Drawing.Color.Transparent;
            this.guna2GradientPanel5.BorderRadius = 15;
            this.guna2GradientPanel5.Controls.Add(this.ctrlBloodUnitInfo1);
            this.guna2GradientPanel5.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(84)))), ((int)(((byte)(138)))));
            this.guna2GradientPanel5.FillColor2 = System.Drawing.Color.IndianRed;
            this.guna2GradientPanel5.Location = new System.Drawing.Point(6, 6);
            this.guna2GradientPanel5.Name = "guna2GradientPanel5";
            this.guna2GradientPanel5.ShadowDecoration.BorderRadius = 15;
            this.guna2GradientPanel5.ShadowDecoration.Depth = 25;
            this.guna2GradientPanel5.Size = new System.Drawing.Size(902, 590);
            this.guna2GradientPanel5.TabIndex = 80;
            // 
            // ctrlBloodUnitInfo1
            // 
            this.ctrlBloodUnitInfo1.BackColor = System.Drawing.Color.Transparent;
            this.ctrlBloodUnitInfo1.Location = new System.Drawing.Point(-3, -3);
            this.ctrlBloodUnitInfo1.Name = "ctrlBloodUnitInfo1";
            this.ctrlBloodUnitInfo1.Size = new System.Drawing.Size(902, 590);
            this.ctrlBloodUnitInfo1.TabIndex = 2;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 40;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2DragControl1
            // 
            this.guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2DragControl1.TargetControl = this.ctrlBloodUnitInfo1;
            this.guna2DragControl1.UseTransparentDrag = true;
            // 
            // frmShowBloodUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(918, 604);
            this.Controls.Add(this.guna2GradientPanel5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowBloodUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmShowBloodUnit";
            this.Load += new System.EventHandler(this.frmShowBloodUnit_Load);
            this.guna2GradientPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel5;
        private Controls.ctrlBloodUnitInfo ctrlBloodUnitInfo1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}