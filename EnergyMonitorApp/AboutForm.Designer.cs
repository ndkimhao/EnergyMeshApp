namespace EnergyMonitorApp
{
	partial class AboutForm
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
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.btnOK = new DevComponents.DotNetBar.ButtonX();
			this.SuspendLayout();
			// 
			// labelX1
			// 
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.labelX1.Location = new System.Drawing.Point(12, 12);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(345, 82);
			this.labelX1.TabIndex = 0;
			this.labelX1.Text = "Nguyễn Dương Kim Hảo\r\nTP.HCM @ 2015";
			// 
			// btnOK
			// 
			this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnOK.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnOK.Location = new System.Drawing.Point(115, 109);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(124, 36);
			this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// AboutForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 157);
			this.ControlBox = false;
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.labelX1);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Tác giả";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutForm_KeyDown);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.ButtonX btnOK;
	}
}