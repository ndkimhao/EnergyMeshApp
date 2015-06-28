namespace EnergyMonitorApp
{
	partial class MainMenuControl
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
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.btnUpdateData = new DevComponents.DotNetBar.ButtonX();
			this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
			this.SuspendLayout();
			// 
			// labelX1
			// 
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelX1.Location = new System.Drawing.Point(3, 3);
			this.labelX1.Name = "labelX1";
			this.labelX1.Size = new System.Drawing.Size(422, 71);
			this.labelX1.TabIndex = 3;
			this.labelX1.Text = "<font size=\"23\"><b>Energy Monitor</b></font><br/>\r\n<i><font size=\"13\">Hệ thống qu" +
    "ản lý điện năng thụ trong nhà</font></i>";
			// 
			// btnUpdateData
			// 
			this.btnUpdateData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnUpdateData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnUpdateData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnUpdateData.Location = new System.Drawing.Point(30, 94);
			this.btnUpdateData.Name = "btnUpdateData";
			this.btnUpdateData.Size = new System.Drawing.Size(375, 140);
			this.btnUpdateData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnUpdateData.Symbol = "";
			this.btnUpdateData.SymbolSize = 60F;
			this.btnUpdateData.TabIndex = 4;
			this.btnUpdateData.Text = "<p><b><font size=\"22\">  Nhận dữ liệu mới</font></b></p>\r\n<p><i>&nbsp;&nbsp;&nbsp;" +
    "&nbsp;&nbsp;  Tải dữ &nbsp;liệu từ mạch chủ về máy tính</i>\r\n</p>";
			// 
			// buttonX2
			// 
			this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.buttonX2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.buttonX2.Location = new System.Drawing.Point(30, 268);
			this.buttonX2.Name = "buttonX2";
			this.buttonX2.Size = new System.Drawing.Size(375, 140);
			this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.buttonX2.Symbol = "";
			this.buttonX2.SymbolSize = 60F;
			this.buttonX2.TabIndex = 5;
			this.buttonX2.Text = "<p><b><font size=\"22\">  Nhập dữ liệu</font></b></p>\r\n<p><i>&nbsp;&nbsp;&nbsp;&nbs" +
    "p;&nbsp;  Nhập dữ &nbsp;liệu theo khối vào từng thiết bị</i>\r\n</p>";
			// 
			// MainMenuControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.buttonX2);
			this.Controls.Add(this.btnUpdateData);
			this.Controls.Add(this.labelX1);
			this.Name = "MainMenuControl";
			this.Size = new System.Drawing.Size(453, 470);
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.ButtonX btnUpdateData;
		private DevComponents.DotNetBar.ButtonX buttonX2;
	}
}
