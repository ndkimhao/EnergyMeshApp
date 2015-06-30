namespace EnergyMonitorApp
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
			this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
			this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
			this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
			this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
			this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
			this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.gridDevice = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.colID = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colDeviceType = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colAction = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.progUpdateData = new DevComponents.DotNetBar.Controls.CircularProgress();
			this.txtDiffTime = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.txtLog = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.lbFileList = new DevComponents.DotNetBar.ListBoxAdv();
			this.txtLogUpdateTime = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.btnUpdateData = new DevComponents.DotNetBar.ButtonX();
			this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
			this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.statusBar = new DevComponents.DotNetBar.Bar();
			this.lblStatus = new DevComponents.DotNetBar.LabelItem();
			this.btnAuthor = new DevComponents.DotNetBar.ButtonItem();
			this.deviceImageList = new System.Windows.Forms.ImageList(this.components);
			this.deviceImageListCombo = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
			this.superTabControl1.SuspendLayout();
			this.superTabControlPanel2.SuspendLayout();
			this.superTabControlPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.statusBar)).BeginInit();
			this.SuspendLayout();
			// 
			// styleManager
			// 
			this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2013;
			this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.WhiteSmoke, System.Drawing.Color.Gray);
			// 
			// tabItem1
			// 
			this.tabItem1.Name = "tabItem1";
			this.tabItem1.Text = "";
			// 
			// tabControlPanel1
			// 
			this.tabControlPanel1.DisabledBackColor = System.Drawing.Color.Empty;
			this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel1.Location = new System.Drawing.Point(0, 26);
			this.tabControlPanel1.Name = "tabControlPanel1";
			this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel1.Size = new System.Drawing.Size(256, 126);
			this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
			this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
			this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
			this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
			this.tabControlPanel1.Style.GradientAngle = 90;
			this.tabControlPanel1.TabIndex = 1;
			this.tabControlPanel1.TabItem = this.tabItem1;
			// 
			// tabItem3
			// 
			this.tabItem3.Name = "tabItem3";
			this.tabItem3.Text = "";
			// 
			// tabControlPanel3
			// 
			this.tabControlPanel3.DisabledBackColor = System.Drawing.Color.Empty;
			this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel3.Location = new System.Drawing.Point(0, 26);
			this.tabControlPanel3.Name = "tabControlPanel3";
			this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel3.Size = new System.Drawing.Size(256, 126);
			this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(179)))), ((int)(((byte)(231)))));
			this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
			this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
			this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(97)))), ((int)(((byte)(156)))));
			this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
			this.tabControlPanel3.Style.GradientAngle = 90;
			this.tabControlPanel3.TabIndex = 2;
			this.tabControlPanel3.TabItem = this.tabItem3;
			// 
			// superTabControl1
			// 
			this.superTabControl1.BackColor = System.Drawing.Color.WhiteSmoke;
			// 
			// 
			// 
			// 
			// 
			// 
			this.superTabControl1.ControlBox.CloseBox.Name = "";
			// 
			// 
			// 
			this.superTabControl1.ControlBox.MenuBox.Name = "";
			this.superTabControl1.ControlBox.Name = "";
			this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
			this.superTabControl1.Controls.Add(this.superTabControlPanel2);
			this.superTabControl1.Controls.Add(this.superTabControlPanel1);
			this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.superTabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.ForeColor = System.Drawing.Color.Black;
			this.superTabControl1.Location = new System.Drawing.Point(0, 0);
			this.superTabControl1.Name = "superTabControl1";
			this.superTabControl1.ReorderTabsEnabled = true;
			this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.SelectedTabIndex = 0;
			this.superTabControl1.Size = new System.Drawing.Size(764, 461);
			this.superTabControl1.TabFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.TabIndex = 0;
			this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2,
            this.superTabItem1});
			this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
			this.superTabControl1.Text = "superTabControl1";
			// 
			// superTabControlPanel2
			// 
			this.superTabControlPanel2.Controls.Add(this.gridDevice);
			this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel2.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel2.Name = "superTabControlPanel2";
			this.superTabControlPanel2.Size = new System.Drawing.Size(764, 425);
			this.superTabControlPanel2.TabIndex = 0;
			this.superTabControlPanel2.TabItem = this.superTabItem2;
			// 
			// gridDevice
			// 
			this.gridDevice.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gridDevice.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.gridDevice.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridDevice.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridDevice.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.gridDevice.ForeColor = System.Drawing.Color.Black;
			this.gridDevice.Location = new System.Drawing.Point(0, 3);
			this.gridDevice.Name = "gridDevice";
			// 
			// 
			// 
			this.gridDevice.PrimaryGrid.AllowRowHeaderResize = true;
			this.gridDevice.PrimaryGrid.AllowRowInsert = true;
			this.gridDevice.PrimaryGrid.AllowRowResize = true;
			this.gridDevice.PrimaryGrid.Columns.Add(this.colID);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colDeviceType);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colName);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colAction);
			this.gridDevice.PrimaryGrid.DefaultRowHeight = 75;
			this.gridDevice.PrimaryGrid.MultiSelect = false;
			this.gridDevice.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
			this.gridDevice.PrimaryGrid.ShowInsertRow = true;
			this.gridDevice.Size = new System.Drawing.Size(761, 422);
			this.gridDevice.TabIndex = 0;
			this.gridDevice.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.gridDevice_CellDoubleClick);
			this.gridDevice.CloseEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCloseEditEventArgs>(this.gridDevice_CloseEdit);
			this.gridDevice.RowAdded += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowAddedEventArgs>(this.gridDevice_RowAdded);
			this.gridDevice.RowSetDefaultValues += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowSetDefaultValuesEventArgs>(this.gridDevice_RowSetDefaultValues);
			// 
			// colID
			// 
			this.colID.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colID.Name = "ID";
			this.colID.Width = 50;
			// 
			// colDeviceType
			// 
			this.colDeviceType.Name = "Loại";
			this.colDeviceType.Width = 150;
			// 
			// colName
			// 
			this.colName.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
			this.colName.Name = "Tên thiết bị";
			// 
			// colAction
			// 
			this.colAction.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
			this.colAction.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridRadialMenuEditControl);
			this.colAction.FillWeight = 75;
			this.colAction.Name = "H.Đ";
			this.colAction.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
			// 
			// superTabItem2
			// 
			this.superTabItem2.AttachedControl = this.superTabControlPanel2;
			this.superTabItem2.GlobalItem = false;
			this.superTabItem2.Name = "superTabItem2";
			this.superTabItem2.Text = "Quản lý thiết bị";
			// 
			// superTabControlPanel1
			// 
			this.superTabControlPanel1.Controls.Add(this.progUpdateData);
			this.superTabControlPanel1.Controls.Add(this.txtDiffTime);
			this.superTabControlPanel1.Controls.Add(this.labelX2);
			this.superTabControlPanel1.Controls.Add(this.txtLog);
			this.superTabControlPanel1.Controls.Add(this.lbFileList);
			this.superTabControlPanel1.Controls.Add(this.txtLogUpdateTime);
			this.superTabControlPanel1.Controls.Add(this.labelX1);
			this.superTabControlPanel1.Controls.Add(this.btnUpdateData);
			this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel1.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel1.Name = "superTabControlPanel1";
			this.superTabControlPanel1.Size = new System.Drawing.Size(764, 425);
			this.superTabControlPanel1.TabIndex = 1;
			this.superTabControlPanel1.TabItem = this.superTabItem1;
			// 
			// progUpdateData
			// 
			this.progUpdateData.BackColor = System.Drawing.Color.WhiteSmoke;
			// 
			// 
			// 
			this.progUpdateData.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.progUpdateData.Location = new System.Drawing.Point(256, 142);
			this.progUpdateData.Name = "progUpdateData";
			this.progUpdateData.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke;
			this.progUpdateData.Size = new System.Drawing.Size(209, 209);
			this.progUpdateData.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
			this.progUpdateData.TabIndex = 9;
			// 
			// txtDiffTime
			// 
			this.txtDiffTime.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.txtDiffTime.Border.Class = "TextBoxBorder";
			this.txtDiffTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtDiffTime.DisabledBackColor = System.Drawing.Color.White;
			this.txtDiffTime.ForeColor = System.Drawing.Color.Black;
			this.txtDiffTime.Location = new System.Drawing.Point(256, 110);
			this.txtDiffTime.Name = "txtDiffTime";
			this.txtDiffTime.PreventEnterBeep = true;
			this.txtDiffTime.ReadOnly = true;
			this.txtDiffTime.Size = new System.Drawing.Size(209, 26);
			this.txtDiffTime.TabIndex = 8;
			// 
			// labelX2
			// 
			this.labelX2.BackColor = System.Drawing.Color.WhiteSmoke;
			// 
			// 
			// 
			this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX2.ForeColor = System.Drawing.Color.Black;
			this.labelX2.Location = new System.Drawing.Point(256, 80);
			this.labelX2.Name = "labelX2";
			this.labelX2.SingleLineColor = System.Drawing.SystemColors.ControlLight;
			this.labelX2.Size = new System.Drawing.Size(209, 23);
			this.labelX2.TabIndex = 7;
			this.labelX2.Text = "Thời gian trễ:";
			// 
			// txtLog
			// 
			this.txtLog.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.txtLog.Border.Class = "TextBoxBorder";
			this.txtLog.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtLog.DisabledBackColor = System.Drawing.Color.White;
			this.txtLog.ForeColor = System.Drawing.Color.Black;
			this.txtLog.Location = new System.Drawing.Point(498, 19);
			this.txtLog.Multiline = true;
			this.txtLog.Name = "txtLog";
			this.txtLog.PreventEnterBeep = true;
			this.txtLog.Size = new System.Drawing.Size(236, 373);
			this.txtLog.TabIndex = 5;
			// 
			// lbFileList
			// 
			this.lbFileList.AutoScroll = true;
			this.lbFileList.BackColor = System.Drawing.Color.WhiteSmoke;
			// 
			// 
			// 
			this.lbFileList.BackgroundStyle.Class = "ListBoxAdv";
			this.lbFileList.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lbFileList.CheckStateMember = null;
			this.lbFileList.ContainerControlProcessDialogKey = true;
			this.lbFileList.DragDropSupport = true;
			this.lbFileList.ForeColor = System.Drawing.Color.Black;
			this.lbFileList.Location = new System.Drawing.Point(12, 122);
			this.lbFileList.Name = "lbFileList";
			this.lbFileList.Size = new System.Drawing.Size(226, 289);
			this.lbFileList.TabIndex = 4;
			// 
			// txtLogUpdateTime
			// 
			this.txtLogUpdateTime.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.txtLogUpdateTime.Border.Class = "TextBoxBorder";
			this.txtLogUpdateTime.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.txtLogUpdateTime.DisabledBackColor = System.Drawing.Color.White;
			this.txtLogUpdateTime.ForeColor = System.Drawing.Color.Black;
			this.txtLogUpdateTime.Location = new System.Drawing.Point(256, 48);
			this.txtLogUpdateTime.Name = "txtLogUpdateTime";
			this.txtLogUpdateTime.PreventEnterBeep = true;
			this.txtLogUpdateTime.ReadOnly = true;
			this.txtLogUpdateTime.Size = new System.Drawing.Size(209, 26);
			this.txtLogUpdateTime.TabIndex = 2;
			// 
			// labelX1
			// 
			this.labelX1.BackColor = System.Drawing.Color.WhiteSmoke;
			// 
			// 
			// 
			this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX1.ForeColor = System.Drawing.Color.Black;
			this.labelX1.Location = new System.Drawing.Point(256, 18);
			this.labelX1.Name = "labelX1";
			this.labelX1.SingleLineColor = System.Drawing.SystemColors.ControlLight;
			this.labelX1.Size = new System.Drawing.Size(209, 23);
			this.labelX1.TabIndex = 1;
			this.labelX1.Text = "Dữ liệu được cập nhật đến:";
			// 
			// btnUpdateData
			// 
			this.btnUpdateData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnUpdateData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnUpdateData.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnUpdateData.Location = new System.Drawing.Point(12, 18);
			this.btnUpdateData.Name = "btnUpdateData";
			this.btnUpdateData.Size = new System.Drawing.Size(226, 98);
			this.btnUpdateData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnUpdateData.Symbol = "";
			this.btnUpdateData.SymbolSize = 40F;
			this.btnUpdateData.TabIndex = 0;
			this.btnUpdateData.Text = " Cập nhật";
			this.btnUpdateData.Click += new System.EventHandler(this.btnUpdateData_Click);
			// 
			// superTabItem1
			// 
			this.superTabItem1.AttachedControl = this.superTabControlPanel1;
			this.superTabItem1.GlobalItem = false;
			this.superTabItem1.Name = "superTabItem1";
			this.superTabItem1.Text = "Cập nhật dữ liệu";
			// 
			// gridColumn1
			// 
			this.gridColumn1.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.gridColumn1.Name = "ID";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Name = "Tên";
			// 
			// gridColumn3
			// 
			this.gridColumn3.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridImageEditControl);
			this.gridColumn3.Name = "Ảnh";
			// 
			// statusBar
			// 
			this.statusBar.AntiAlias = true;
			this.statusBar.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
			this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.statusBar.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.lblStatus,
            this.btnAuthor});
			this.statusBar.Location = new System.Drawing.Point(0, 460);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(764, 26);
			this.statusBar.Stretch = true;
			this.statusBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.statusBar.TabIndex = 7;
			this.statusBar.TabStop = false;
			this.statusBar.Text = "bar1";
			// 
			// lblStatus
			// 
			this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Stretch = true;
			this.lblStatus.Text = "Trạng thái phần mềm";
			// 
			// btnAuthor
			// 
			this.btnAuthor.Name = "btnAuthor";
			this.btnAuthor.Text = "Kim Hảo @ 2015";
			this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
			// 
			// deviceImageList
			// 
			this.deviceImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("deviceImageList.ImageStream")));
			this.deviceImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.deviceImageList.Images.SetKeyName(0, "air_conditioner.jpg");
			this.deviceImageList.Images.SetKeyName(1, "electric_socket.jpg");
			this.deviceImageList.Images.SetKeyName(2, "fan.jpg");
			this.deviceImageList.Images.SetKeyName(3, "washing_machine.jpg");
			this.deviceImageList.Images.SetKeyName(4, "water_heater.jpg");
			// 
			// deviceImageListCombo
			// 
			this.deviceImageListCombo.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("deviceImageListCombo.ImageStream")));
			this.deviceImageListCombo.TransparentColor = System.Drawing.Color.Transparent;
			this.deviceImageListCombo.Images.SetKeyName(0, "air_conditioner.jpg");
			this.deviceImageListCombo.Images.SetKeyName(1, "electric_socket.jpg");
			this.deviceImageListCombo.Images.SetKeyName(2, "fan.jpg");
			this.deviceImageListCombo.Images.SetKeyName(3, "washing_machine.jpg");
			this.deviceImageListCombo.Images.SetKeyName(4, "water_heater.jpg");
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(764, 486);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.superTabControl1);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "Energy Monitor @ KH - 2015";
			((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
			this.superTabControl1.ResumeLayout(false);
			this.superTabControlPanel2.ResumeLayout(false);
			this.superTabControlPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.statusBar)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevComponents.DotNetBar.StyleManager styleManager;
		private DevComponents.DotNetBar.TabItem tabItem1;
		private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
		private DevComponents.DotNetBar.TabItem tabItem3;
		private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
		private DevComponents.DotNetBar.SuperTabControl superTabControl1;
		private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
		private DevComponents.DotNetBar.SuperTabItem superTabItem1;
		private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
		private DevComponents.DotNetBar.SuperTabItem superTabItem2;
		private DevComponents.DotNetBar.ButtonX btnUpdateData;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.Controls.TextBoxX txtLogUpdateTime;
		private DevComponents.DotNetBar.ListBoxAdv lbFileList;
		private DevComponents.DotNetBar.Controls.TextBoxX txtLog;
		private DevComponents.DotNetBar.Bar statusBar;
		private DevComponents.DotNetBar.LabelItem lblStatus;
		private DevComponents.DotNetBar.ButtonItem btnAuthor;
		private DevComponents.DotNetBar.Controls.TextBoxX txtDiffTime;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.Controls.CircularProgress progUpdateData;
		private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
		private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
		private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
		private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridDevice;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colID;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colDeviceType;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colName;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colAction;
		private System.Windows.Forms.ImageList deviceImageList;
		private System.Windows.Forms.ImageList deviceImageListCombo;
	}
}