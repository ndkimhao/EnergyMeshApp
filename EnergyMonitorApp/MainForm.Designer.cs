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
			DevComponents.DotNetBar.SuperGrid.Style.Padding padding1 = new DevComponents.DotNetBar.SuperGrid.Style.Padding();
			DevComponents.DotNetBar.SuperGrid.Style.Background background1 = new DevComponents.DotNetBar.SuperGrid.Style.Background();
			this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
			this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
			this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
			this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
			this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
			this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
			this.superTabControlPanel4 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.cbStatisticPieChart = new DevComponents.DotNetBar.Controls.CheckBoxX();
			this.graphStatistic = new ZedGraph.ZedGraphControl();
			this.txtStatisticPower = new System.Windows.Forms.TextBox();
			this.labelX10 = new DevComponents.DotNetBar.LabelX();
			this.cbStatisticType = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.labelX11 = new DevComponents.DotNetBar.LabelX();
			this.progDeviceStatistic = new DevComponents.DotNetBar.Controls.CircularProgress();
			this.btnUpdateStatistic = new DevComponents.DotNetBar.ButtonX();
			this.labelX12 = new DevComponents.DotNetBar.LabelX();
			this.dtStatisticEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX13 = new DevComponents.DotNetBar.LabelX();
			this.dtStatisticBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.cbDeviceStatistic = new EnergyMonitorApp.DeviceComboBox();
			this.deviceImageList = new System.Windows.Forms.ImageList(this.components);
			this.tabDeviceStatistic = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.gridDevice = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.colDeviceID = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colDeviceType = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colDeviceName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colDeviceAction = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.progUpdateData = new DevComponents.DotNetBar.Controls.CircularProgress();
			this.txtDiffTime = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX2 = new DevComponents.DotNetBar.LabelX();
			this.lbFileList = new DevComponents.DotNetBar.ListBoxAdv();
			this.txtLogUpdateTime = new DevComponents.DotNetBar.Controls.TextBoxX();
			this.labelX1 = new DevComponents.DotNetBar.LabelX();
			this.btnUpdateData = new DevComponents.DotNetBar.ButtonX();
			this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabControlPanel5 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.graphEnvironment = new ZedGraph.ZedGraphControl();
			this.txtAverageTemperature = new System.Windows.Forms.TextBox();
			this.labelX7 = new DevComponents.DotNetBar.LabelX();
			this.btnUpdateEvironment = new DevComponents.DotNetBar.ButtonX();
			this.labelX8 = new DevComponents.DotNetBar.LabelX();
			this.dtEnvironmentEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX9 = new DevComponents.DotNetBar.LabelX();
			this.dtEnvironmentBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.tabEnvironment = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.txtDeviceHistoryPower = new System.Windows.Forms.TextBox();
			this.labelX6 = new DevComponents.DotNetBar.LabelX();
			this.cbHistoryY2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
			this.labelX5 = new DevComponents.DotNetBar.LabelX();
			this.progDeviceHistory = new DevComponents.DotNetBar.Controls.CircularProgress();
			this.graphHistory = new ZedGraph.ZedGraphControl();
			this.btnUpdateHistory = new DevComponents.DotNetBar.ButtonX();
			this.labelX4 = new DevComponents.DotNetBar.LabelX();
			this.dtHistoryEnd = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.labelX3 = new DevComponents.DotNetBar.LabelX();
			this.dtHistoryBegin = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
			this.cbDeviceHistory = new EnergyMonitorApp.DeviceComboBox();
			this.tabDeviceHistory = new DevComponents.DotNetBar.SuperTabItem();
			this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
			this.gridBlocks = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
			this.colBlockID = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colBlockKwh = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colBlockDate = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colBlockChart = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colBlockDevice = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.colBlockImport = new DevComponents.DotNetBar.SuperGrid.GridColumn();
			this.tabBlockManager = new DevComponents.DotNetBar.SuperTabItem();
			this.statusBar = new DevComponents.DotNetBar.Bar();
			this.lblStatus = new DevComponents.DotNetBar.LabelItem();
			this.btnAuthor = new DevComponents.DotNetBar.ButtonItem();
			this.cbTheme = new DevComponents.DotNetBar.ComboBoxItem();
			this.cpCanvasColor = new DevComponents.DotNetBar.ColorPickerDropDown();
			this.cpBaseColor = new DevComponents.DotNetBar.ColorPickerDropDown();
			this.deviceImageListCombo = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
			this.superTabControl1.SuspendLayout();
			this.superTabControlPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtStatisticEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStatisticBegin)).BeginInit();
			this.superTabControlPanel1.SuspendLayout();
			this.superTabControlPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtEnvironmentEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEnvironmentBegin)).BeginInit();
			this.superTabControlPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtHistoryEnd)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtHistoryBegin)).BeginInit();
			this.superTabControlPanel2.SuspendLayout();
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
			this.superTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
			this.superTabControl1.Controls.Add(this.superTabControlPanel1);
			this.superTabControl1.Controls.Add(this.superTabControlPanel4);
			this.superTabControl1.Controls.Add(this.superTabControlPanel5);
			this.superTabControl1.Controls.Add(this.superTabControlPanel3);
			this.superTabControl1.Controls.Add(this.superTabControlPanel2);
			this.superTabControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.ForeColor = System.Drawing.Color.Black;
			this.superTabControl1.Location = new System.Drawing.Point(0, 0);
			this.superTabControl1.Name = "superTabControl1";
			this.superTabControl1.ReorderTabsEnabled = true;
			this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.SelectedTabIndex = 0;
			this.superTabControl1.Size = new System.Drawing.Size(1090, 686);
			this.superTabControl1.TabFont = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.superTabControl1.TabIndex = 0;
			this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1,
            this.tabBlockManager,
            this.tabDeviceHistory,
            this.tabDeviceStatistic,
            this.tabEnvironment});
			this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.Office2010BackstageBlue;
			this.superTabControl1.Text = "superTabControl1";
			// 
			// superTabControlPanel4
			// 
			this.superTabControlPanel4.Controls.Add(this.cbStatisticPieChart);
			this.superTabControlPanel4.Controls.Add(this.graphStatistic);
			this.superTabControlPanel4.Controls.Add(this.txtStatisticPower);
			this.superTabControlPanel4.Controls.Add(this.labelX10);
			this.superTabControlPanel4.Controls.Add(this.cbStatisticType);
			this.superTabControlPanel4.Controls.Add(this.labelX11);
			this.superTabControlPanel4.Controls.Add(this.progDeviceStatistic);
			this.superTabControlPanel4.Controls.Add(this.btnUpdateStatistic);
			this.superTabControlPanel4.Controls.Add(this.labelX12);
			this.superTabControlPanel4.Controls.Add(this.dtStatisticEnd);
			this.superTabControlPanel4.Controls.Add(this.labelX13);
			this.superTabControlPanel4.Controls.Add(this.dtStatisticBegin);
			this.superTabControlPanel4.Controls.Add(this.cbDeviceStatistic);
			this.superTabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel4.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel4.Name = "superTabControlPanel4";
			this.superTabControlPanel4.Size = new System.Drawing.Size(1090, 650);
			this.superTabControlPanel4.TabIndex = 0;
			this.superTabControlPanel4.TabItem = this.tabDeviceStatistic;
			// 
			// cbStatisticPieChart
			// 
			this.cbStatisticPieChart.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.cbStatisticPieChart.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.cbStatisticPieChart.Location = new System.Drawing.Point(13, 292);
			this.cbStatisticPieChart.Name = "cbStatisticPieChart";
			this.cbStatisticPieChart.Size = new System.Drawing.Size(206, 23);
			this.cbStatisticPieChart.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.cbStatisticPieChart.TabIndex = 27;
			this.cbStatisticPieChart.Text = "Biểu đồ quạt";
			// 
			// graphStatistic
			// 
			this.graphStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.graphStatistic.BackColor = System.Drawing.Color.WhiteSmoke;
			this.graphStatistic.ForeColor = System.Drawing.Color.Black;
			this.graphStatistic.Location = new System.Drawing.Point(228, 0);
			this.graphStatistic.Margin = new System.Windows.Forms.Padding(4);
			this.graphStatistic.Name = "graphStatistic";
			this.graphStatistic.ScrollGrace = 0D;
			this.graphStatistic.ScrollMaxX = 0D;
			this.graphStatistic.ScrollMaxY = 0D;
			this.graphStatistic.ScrollMaxY2 = 0D;
			this.graphStatistic.ScrollMinX = 0D;
			this.graphStatistic.ScrollMinY = 0D;
			this.graphStatistic.ScrollMinY2 = 0D;
			this.graphStatistic.Size = new System.Drawing.Size(862, 650);
			this.graphStatistic.TabIndex = 26;
			// 
			// txtStatisticPower
			// 
			this.txtStatisticPower.BackColor = System.Drawing.Color.White;
			this.txtStatisticPower.ForeColor = System.Drawing.Color.Black;
			this.txtStatisticPower.Location = new System.Drawing.Point(12, 368);
			this.txtStatisticPower.Name = "txtStatisticPower";
			this.txtStatisticPower.ReadOnly = true;
			this.txtStatisticPower.Size = new System.Drawing.Size(208, 26);
			this.txtStatisticPower.TabIndex = 25;
			// 
			// labelX10
			// 
			this.labelX10.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX10.ForeColor = System.Drawing.Color.Black;
			this.labelX10.Location = new System.Drawing.Point(11, 338);
			this.labelX10.Name = "labelX10";
			this.labelX10.Size = new System.Drawing.Size(208, 23);
			this.labelX10.TabIndex = 24;
			this.labelX10.Text = "Tiêu thụ:";
			// 
			// cbStatisticType
			// 
			this.cbStatisticType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbStatisticType.ForeColor = System.Drawing.Color.Black;
			this.cbStatisticType.FormattingEnabled = true;
			this.cbStatisticType.Items.AddRange(new object[] {
            "Giờ trong ngày (0h-23h)",
            "Thứ trong tuần (thứ 2-CN)",
            "Ngày trong tháng (ngày 1-30)",
            "Tháng trong năm (tháng 1-12)"});
			this.cbStatisticType.Location = new System.Drawing.Point(12, 258);
			this.cbStatisticType.Name = "cbStatisticType";
			this.cbStatisticType.Size = new System.Drawing.Size(207, 27);
			this.cbStatisticType.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.cbStatisticType.TabIndex = 23;
			// 
			// labelX11
			// 
			this.labelX11.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX11.ForeColor = System.Drawing.Color.Black;
			this.labelX11.Location = new System.Drawing.Point(12, 228);
			this.labelX11.Name = "labelX11";
			this.labelX11.Size = new System.Drawing.Size(208, 23);
			this.labelX11.TabIndex = 22;
			this.labelX11.Text = "Thống kê theo:";
			// 
			// progDeviceStatistic
			// 
			this.progDeviceStatistic.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.progDeviceStatistic.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.progDeviceStatistic.Location = new System.Drawing.Point(65, 526);
			this.progDeviceStatistic.Name = "progDeviceStatistic";
			this.progDeviceStatistic.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke;
			this.progDeviceStatistic.Size = new System.Drawing.Size(100, 100);
			this.progDeviceStatistic.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
			this.progDeviceStatistic.TabIndex = 21;
			// 
			// btnUpdateStatistic
			// 
			this.btnUpdateStatistic.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnUpdateStatistic.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnUpdateStatistic.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnUpdateStatistic.Location = new System.Drawing.Point(11, 422);
			this.btnUpdateStatistic.Name = "btnUpdateStatistic";
			this.btnUpdateStatistic.Size = new System.Drawing.Size(208, 98);
			this.btnUpdateStatistic.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnUpdateStatistic.Symbol = "";
			this.btnUpdateStatistic.SymbolSize = 35F;
			this.btnUpdateStatistic.TabIndex = 20;
			this.btnUpdateStatistic.Text = " Thống kê";
			this.btnUpdateStatistic.Click += new System.EventHandler(this.btnUpdateStatistic_Click);
			// 
			// labelX12
			// 
			this.labelX12.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX12.ForeColor = System.Drawing.Color.Black;
			this.labelX12.Location = new System.Drawing.Point(12, 158);
			this.labelX12.Name = "labelX12";
			this.labelX12.Size = new System.Drawing.Size(208, 23);
			this.labelX12.TabIndex = 19;
			this.labelX12.Text = "Thời gian kết thúc:";
			// 
			// dtStatisticEnd
			// 
			this.dtStatisticEnd.AutoOffFreeTextEntry = true;
			this.dtStatisticEnd.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtStatisticEnd.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtStatisticEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtStatisticEnd.ButtonDropDown.Visible = true;
			this.dtStatisticEnd.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtStatisticEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtStatisticEnd.ForeColor = System.Drawing.Color.Black;
			this.dtStatisticEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtStatisticEnd.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtStatisticEnd.IsPopupCalendarOpen = false;
			this.dtStatisticEnd.Location = new System.Drawing.Point(11, 187);
			// 
			// 
			// 
			this.dtStatisticEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtStatisticEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtStatisticEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticEnd.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtStatisticEnd.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtStatisticEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtStatisticEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtStatisticEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtStatisticEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtStatisticEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtStatisticEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtStatisticEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtStatisticEnd.Name = "dtStatisticEnd";
			this.dtStatisticEnd.Size = new System.Drawing.Size(209, 26);
			this.dtStatisticEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtStatisticEnd.TabIndex = 18;
			this.dtStatisticEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtStatisticEnd.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// labelX13
			// 
			this.labelX13.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX13.ForeColor = System.Drawing.Color.Black;
			this.labelX13.Location = new System.Drawing.Point(12, 91);
			this.labelX13.Name = "labelX13";
			this.labelX13.Size = new System.Drawing.Size(208, 23);
			this.labelX13.TabIndex = 17;
			this.labelX13.Text = "Thời gian bắt đầu:";
			// 
			// dtStatisticBegin
			// 
			this.dtStatisticBegin.AutoOffFreeTextEntry = true;
			this.dtStatisticBegin.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtStatisticBegin.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtStatisticBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtStatisticBegin.ButtonDropDown.Visible = true;
			this.dtStatisticBegin.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtStatisticBegin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtStatisticBegin.ForeColor = System.Drawing.Color.Black;
			this.dtStatisticBegin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtStatisticBegin.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtStatisticBegin.IsPopupCalendarOpen = false;
			this.dtStatisticBegin.Location = new System.Drawing.Point(12, 120);
			// 
			// 
			// 
			this.dtStatisticBegin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtStatisticBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtStatisticBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticBegin.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtStatisticBegin.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtStatisticBegin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtStatisticBegin.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtStatisticBegin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtStatisticBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtStatisticBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtStatisticBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtStatisticBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtStatisticBegin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtStatisticBegin.Name = "dtStatisticBegin";
			this.dtStatisticBegin.Size = new System.Drawing.Size(209, 26);
			this.dtStatisticBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtStatisticBegin.TabIndex = 16;
			this.dtStatisticBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtStatisticBegin.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// cbDeviceStatistic
			// 
			this.cbDeviceStatistic.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cbDeviceStatistic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbDeviceStatistic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDeviceStatistic.ForeColor = System.Drawing.Color.Black;
			this.cbDeviceStatistic.FormattingEnabled = true;
			this.cbDeviceStatistic.ImageList = this.deviceImageList;
			this.cbDeviceStatistic.ItemHeight = 64;
			this.cbDeviceStatistic.Location = new System.Drawing.Point(12, 15);
			this.cbDeviceStatistic.Name = "cbDeviceStatistic";
			this.cbDeviceStatistic.Size = new System.Drawing.Size(209, 70);
			this.cbDeviceStatistic.TabIndex = 15;
			this.cbDeviceStatistic.SelectedIndexChanged += new System.EventHandler(this.cbDeviceStatistic_SelectedIndexChanged);
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
			this.deviceImageList.Images.SetKeyName(5, "line.jpg");
			this.deviceImageList.Images.SetKeyName(6, "other.jpg");
			// 
			// tabDeviceStatistic
			// 
			this.tabDeviceStatistic.AttachedControl = this.superTabControlPanel4;
			this.tabDeviceStatistic.Enabled = false;
			this.tabDeviceStatistic.GlobalItem = false;
			this.tabDeviceStatistic.Name = "tabDeviceStatistic";
			this.tabDeviceStatistic.Text = "Thống kê thiết bị";
			// 
			// superTabControlPanel1
			// 
			this.superTabControlPanel1.Controls.Add(this.gridDevice);
			this.superTabControlPanel1.Controls.Add(this.progUpdateData);
			this.superTabControlPanel1.Controls.Add(this.txtDiffTime);
			this.superTabControlPanel1.Controls.Add(this.labelX2);
			this.superTabControlPanel1.Controls.Add(this.lbFileList);
			this.superTabControlPanel1.Controls.Add(this.txtLogUpdateTime);
			this.superTabControlPanel1.Controls.Add(this.labelX1);
			this.superTabControlPanel1.Controls.Add(this.btnUpdateData);
			this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel1.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel1.Name = "superTabControlPanel1";
			this.superTabControlPanel1.Size = new System.Drawing.Size(1090, 650);
			this.superTabControlPanel1.TabIndex = 1;
			this.superTabControlPanel1.TabItem = this.superTabItem1;
			// 
			// gridDevice
			// 
			this.gridDevice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridDevice.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gridDevice.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.gridDevice.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridDevice.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridDevice.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.gridDevice.ForeColor = System.Drawing.Color.Black;
			this.gridDevice.Location = new System.Drawing.Point(488, 0);
			this.gridDevice.Name = "gridDevice";
			// 
			// 
			// 
			this.gridDevice.PrimaryGrid.AllowRowHeaderResize = true;
			this.gridDevice.PrimaryGrid.AllowRowInsert = true;
			this.gridDevice.PrimaryGrid.AllowRowResize = true;
			this.gridDevice.PrimaryGrid.Columns.Add(this.colDeviceID);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colDeviceType);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colDeviceName);
			this.gridDevice.PrimaryGrid.Columns.Add(this.colDeviceAction);
			this.gridDevice.PrimaryGrid.DefaultRowHeight = 75;
			this.gridDevice.PrimaryGrid.MultiSelect = false;
			this.gridDevice.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
			this.gridDevice.PrimaryGrid.ShowInsertRow = true;
			this.gridDevice.Size = new System.Drawing.Size(599, 650);
			this.gridDevice.TabIndex = 10;
			this.gridDevice.CellDoubleClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellDoubleClickEventArgs>(this.gridDevice_CellDoubleClick);
			this.gridDevice.CloseEdit += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCloseEditEventArgs>(this.gridDevice_CloseEdit);
			this.gridDevice.RowAdded += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowAddedEventArgs>(this.gridDevice_RowAdded);
			this.gridDevice.RowSetDefaultValues += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridRowSetDefaultValuesEventArgs>(this.gridDevice_RowSetDefaultValues);
			// 
			// colDeviceID
			// 
			this.colDeviceID.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colDeviceID.Name = "ID";
			this.colDeviceID.Width = 50;
			// 
			// colDeviceType
			// 
			this.colDeviceType.Name = "Loại";
			this.colDeviceType.Width = 150;
			// 
			// colDeviceName
			// 
			this.colDeviceName.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
			this.colDeviceName.Name = "Tên thiết bị";
			// 
			// colDeviceAction
			// 
			this.colDeviceAction.ColumnSortMode = DevComponents.DotNetBar.SuperGrid.ColumnSortMode.None;
			this.colDeviceAction.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridRadialMenuEditControl);
			this.colDeviceAction.FillWeight = 75;
			this.colDeviceAction.Name = "H.Đ";
			this.colDeviceAction.SortIndicator = DevComponents.DotNetBar.SuperGrid.SortIndicator.None;
			// 
			// progUpdateData
			// 
			this.progUpdateData.BackColor = System.Drawing.Color.Transparent;
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
			this.labelX2.BackColor = System.Drawing.Color.Transparent;
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
			// lbFileList
			// 
			this.lbFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
			this.lbFileList.Size = new System.Drawing.Size(226, 514);
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
			this.labelX1.BackColor = System.Drawing.Color.Transparent;
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
			// superTabControlPanel5
			// 
			this.superTabControlPanel5.Controls.Add(this.graphEnvironment);
			this.superTabControlPanel5.Controls.Add(this.txtAverageTemperature);
			this.superTabControlPanel5.Controls.Add(this.labelX7);
			this.superTabControlPanel5.Controls.Add(this.btnUpdateEvironment);
			this.superTabControlPanel5.Controls.Add(this.labelX8);
			this.superTabControlPanel5.Controls.Add(this.dtEnvironmentEnd);
			this.superTabControlPanel5.Controls.Add(this.labelX9);
			this.superTabControlPanel5.Controls.Add(this.dtEnvironmentBegin);
			this.superTabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel5.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel5.Name = "superTabControlPanel5";
			this.superTabControlPanel5.Size = new System.Drawing.Size(1090, 650);
			this.superTabControlPanel5.TabIndex = 0;
			this.superTabControlPanel5.TabItem = this.tabEnvironment;
			// 
			// graphEnvironment
			// 
			this.graphEnvironment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.graphEnvironment.BackColor = System.Drawing.Color.WhiteSmoke;
			this.graphEnvironment.ForeColor = System.Drawing.Color.Black;
			this.graphEnvironment.Location = new System.Drawing.Point(229, 0);
			this.graphEnvironment.Margin = new System.Windows.Forms.Padding(4);
			this.graphEnvironment.Name = "graphEnvironment";
			this.graphEnvironment.ScrollGrace = 0D;
			this.graphEnvironment.ScrollMaxX = 0D;
			this.graphEnvironment.ScrollMaxY = 0D;
			this.graphEnvironment.ScrollMaxY2 = 0D;
			this.graphEnvironment.ScrollMinX = 0D;
			this.graphEnvironment.ScrollMinY = 0D;
			this.graphEnvironment.ScrollMinY2 = 0D;
			this.graphEnvironment.Size = new System.Drawing.Size(861, 650);
			this.graphEnvironment.TabIndex = 22;
			// 
			// txtAverageTemperature
			// 
			this.txtAverageTemperature.BackColor = System.Drawing.Color.White;
			this.txtAverageTemperature.ForeColor = System.Drawing.Color.Black;
			this.txtAverageTemperature.Location = new System.Drawing.Point(13, 207);
			this.txtAverageTemperature.Name = "txtAverageTemperature";
			this.txtAverageTemperature.ReadOnly = true;
			this.txtAverageTemperature.Size = new System.Drawing.Size(208, 26);
			this.txtAverageTemperature.TabIndex = 21;
			// 
			// labelX7
			// 
			this.labelX7.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX7.ForeColor = System.Drawing.Color.Black;
			this.labelX7.Location = new System.Drawing.Point(12, 177);
			this.labelX7.Name = "labelX7";
			this.labelX7.Size = new System.Drawing.Size(208, 23);
			this.labelX7.TabIndex = 20;
			this.labelX7.Text = "Nhiệt độ trung bình:";
			// 
			// btnUpdateEvironment
			// 
			this.btnUpdateEvironment.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnUpdateEvironment.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnUpdateEvironment.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnUpdateEvironment.Location = new System.Drawing.Point(12, 287);
			this.btnUpdateEvironment.Name = "btnUpdateEvironment";
			this.btnUpdateEvironment.Size = new System.Drawing.Size(208, 98);
			this.btnUpdateEvironment.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnUpdateEvironment.Symbol = "";
			this.btnUpdateEvironment.SymbolSize = 35F;
			this.btnUpdateEvironment.TabIndex = 19;
			this.btnUpdateEvironment.Text = " Thống kê";
			this.btnUpdateEvironment.Click += new System.EventHandler(this.btnUpdateEvironment_Click);
			// 
			// labelX8
			// 
			this.labelX8.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX8.ForeColor = System.Drawing.Color.Black;
			this.labelX8.Location = new System.Drawing.Point(9, 92);
			this.labelX8.Name = "labelX8";
			this.labelX8.Size = new System.Drawing.Size(208, 23);
			this.labelX8.TabIndex = 18;
			this.labelX8.Text = "Thời gian kết thúc:";
			// 
			// dtEnvironmentEnd
			// 
			this.dtEnvironmentEnd.AutoOffFreeTextEntry = true;
			this.dtEnvironmentEnd.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtEnvironmentEnd.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtEnvironmentEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtEnvironmentEnd.ButtonDropDown.Visible = true;
			this.dtEnvironmentEnd.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtEnvironmentEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtEnvironmentEnd.ForeColor = System.Drawing.Color.Black;
			this.dtEnvironmentEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtEnvironmentEnd.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtEnvironmentEnd.IsPopupCalendarOpen = false;
			this.dtEnvironmentEnd.Location = new System.Drawing.Point(13, 121);
			// 
			// 
			// 
			this.dtEnvironmentEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtEnvironmentEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtEnvironmentEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentEnd.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtEnvironmentEnd.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtEnvironmentEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtEnvironmentEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtEnvironmentEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtEnvironmentEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtEnvironmentEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtEnvironmentEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtEnvironmentEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtEnvironmentEnd.Name = "dtEnvironmentEnd";
			this.dtEnvironmentEnd.Size = new System.Drawing.Size(209, 26);
			this.dtEnvironmentEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtEnvironmentEnd.TabIndex = 17;
			this.dtEnvironmentEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtEnvironmentEnd.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// labelX9
			// 
			this.labelX9.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX9.ForeColor = System.Drawing.Color.Black;
			this.labelX9.Location = new System.Drawing.Point(9, 25);
			this.labelX9.Name = "labelX9";
			this.labelX9.Size = new System.Drawing.Size(208, 23);
			this.labelX9.TabIndex = 16;
			this.labelX9.Text = "Thời gian bắt đầu:";
			// 
			// dtEnvironmentBegin
			// 
			this.dtEnvironmentBegin.AutoOffFreeTextEntry = true;
			this.dtEnvironmentBegin.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtEnvironmentBegin.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtEnvironmentBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtEnvironmentBegin.ButtonDropDown.Visible = true;
			this.dtEnvironmentBegin.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtEnvironmentBegin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtEnvironmentBegin.ForeColor = System.Drawing.Color.Black;
			this.dtEnvironmentBegin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtEnvironmentBegin.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtEnvironmentBegin.IsPopupCalendarOpen = false;
			this.dtEnvironmentBegin.Location = new System.Drawing.Point(12, 54);
			// 
			// 
			// 
			this.dtEnvironmentBegin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtEnvironmentBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtEnvironmentBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentBegin.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtEnvironmentBegin.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtEnvironmentBegin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtEnvironmentBegin.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtEnvironmentBegin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtEnvironmentBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtEnvironmentBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtEnvironmentBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtEnvironmentBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtEnvironmentBegin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtEnvironmentBegin.Name = "dtEnvironmentBegin";
			this.dtEnvironmentBegin.Size = new System.Drawing.Size(209, 26);
			this.dtEnvironmentBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtEnvironmentBegin.TabIndex = 15;
			this.dtEnvironmentBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtEnvironmentBegin.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// tabEnvironment
			// 
			this.tabEnvironment.AttachedControl = this.superTabControlPanel5;
			this.tabEnvironment.Enabled = false;
			this.tabEnvironment.GlobalItem = false;
			this.tabEnvironment.Name = "tabEnvironment";
			this.tabEnvironment.Text = "Môi trường";
			// 
			// superTabControlPanel3
			// 
			this.superTabControlPanel3.Controls.Add(this.txtDeviceHistoryPower);
			this.superTabControlPanel3.Controls.Add(this.labelX6);
			this.superTabControlPanel3.Controls.Add(this.cbHistoryY2);
			this.superTabControlPanel3.Controls.Add(this.labelX5);
			this.superTabControlPanel3.Controls.Add(this.progDeviceHistory);
			this.superTabControlPanel3.Controls.Add(this.graphHistory);
			this.superTabControlPanel3.Controls.Add(this.btnUpdateHistory);
			this.superTabControlPanel3.Controls.Add(this.labelX4);
			this.superTabControlPanel3.Controls.Add(this.dtHistoryEnd);
			this.superTabControlPanel3.Controls.Add(this.labelX3);
			this.superTabControlPanel3.Controls.Add(this.dtHistoryBegin);
			this.superTabControlPanel3.Controls.Add(this.cbDeviceHistory);
			this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel3.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel3.Name = "superTabControlPanel3";
			this.superTabControlPanel3.Size = new System.Drawing.Size(1090, 650);
			this.superTabControlPanel3.TabIndex = 0;
			this.superTabControlPanel3.TabItem = this.tabDeviceHistory;
			// 
			// txtDeviceHistoryPower
			// 
			this.txtDeviceHistoryPower.BackColor = System.Drawing.Color.White;
			this.txtDeviceHistoryPower.ForeColor = System.Drawing.Color.Black;
			this.txtDeviceHistoryPower.Location = new System.Drawing.Point(10, 345);
			this.txtDeviceHistoryPower.Name = "txtDeviceHistoryPower";
			this.txtDeviceHistoryPower.ReadOnly = true;
			this.txtDeviceHistoryPower.Size = new System.Drawing.Size(208, 26);
			this.txtDeviceHistoryPower.TabIndex = 14;
			// 
			// labelX6
			// 
			this.labelX6.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX6.ForeColor = System.Drawing.Color.Black;
			this.labelX6.Location = new System.Drawing.Point(9, 315);
			this.labelX6.Name = "labelX6";
			this.labelX6.Size = new System.Drawing.Size(208, 23);
			this.labelX6.TabIndex = 13;
			this.labelX6.Text = "Tiêu thụ:";
			// 
			// cbHistoryY2
			// 
			this.cbHistoryY2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbHistoryY2.ForeColor = System.Drawing.Color.Black;
			this.cbHistoryY2.FormattingEnabled = true;
			this.cbHistoryY2.Items.AddRange(new object[] {
            "Dòng điện (I)",
            "Điện áp (V)",
            "Công suất biểu kiến (S)"});
			this.cbHistoryY2.Location = new System.Drawing.Point(10, 261);
			this.cbHistoryY2.Name = "cbHistoryY2";
			this.cbHistoryY2.Size = new System.Drawing.Size(207, 27);
			this.cbHistoryY2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.cbHistoryY2.TabIndex = 12;
			// 
			// labelX5
			// 
			this.labelX5.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX5.ForeColor = System.Drawing.Color.Black;
			this.labelX5.Location = new System.Drawing.Point(10, 231);
			this.labelX5.Name = "labelX5";
			this.labelX5.Size = new System.Drawing.Size(208, 23);
			this.labelX5.TabIndex = 11;
			this.labelX5.Text = "Dữ liệu phụ:";
			// 
			// progDeviceHistory
			// 
			this.progDeviceHistory.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.progDeviceHistory.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.progDeviceHistory.Location = new System.Drawing.Point(63, 529);
			this.progDeviceHistory.Name = "progDeviceHistory";
			this.progDeviceHistory.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke;
			this.progDeviceHistory.Size = new System.Drawing.Size(100, 100);
			this.progDeviceHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
			this.progDeviceHistory.TabIndex = 10;
			// 
			// graphHistory
			// 
			this.graphHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.graphHistory.BackColor = System.Drawing.Color.WhiteSmoke;
			this.graphHistory.ForeColor = System.Drawing.Color.Black;
			this.graphHistory.Location = new System.Drawing.Point(228, 0);
			this.graphHistory.Margin = new System.Windows.Forms.Padding(4);
			this.graphHistory.Name = "graphHistory";
			this.graphHistory.ScrollGrace = 0D;
			this.graphHistory.ScrollMaxX = 0D;
			this.graphHistory.ScrollMaxY = 0D;
			this.graphHistory.ScrollMaxY2 = 0D;
			this.graphHistory.ScrollMinX = 0D;
			this.graphHistory.ScrollMinY = 0D;
			this.graphHistory.ScrollMinY2 = 0D;
			this.graphHistory.Size = new System.Drawing.Size(862, 650);
			this.graphHistory.TabIndex = 9;
			// 
			// btnUpdateHistory
			// 
			this.btnUpdateHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnUpdateHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
			this.btnUpdateHistory.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.btnUpdateHistory.Location = new System.Drawing.Point(9, 425);
			this.btnUpdateHistory.Name = "btnUpdateHistory";
			this.btnUpdateHistory.Size = new System.Drawing.Size(208, 98);
			this.btnUpdateHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.btnUpdateHistory.Symbol = "";
			this.btnUpdateHistory.SymbolSize = 35F;
			this.btnUpdateHistory.TabIndex = 8;
			this.btnUpdateHistory.Text = " Thống kê";
			this.btnUpdateHistory.Click += new System.EventHandler(this.btnUpdateHistory_Click);
			// 
			// labelX4
			// 
			this.labelX4.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX4.ForeColor = System.Drawing.Color.Black;
			this.labelX4.Location = new System.Drawing.Point(10, 161);
			this.labelX4.Name = "labelX4";
			this.labelX4.Size = new System.Drawing.Size(208, 23);
			this.labelX4.TabIndex = 7;
			this.labelX4.Text = "Thời gian kết thúc:";
			// 
			// dtHistoryEnd
			// 
			this.dtHistoryEnd.AutoOffFreeTextEntry = true;
			this.dtHistoryEnd.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtHistoryEnd.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtHistoryEnd.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryEnd.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtHistoryEnd.ButtonDropDown.Visible = true;
			this.dtHistoryEnd.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtHistoryEnd.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtHistoryEnd.ForeColor = System.Drawing.Color.Black;
			this.dtHistoryEnd.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtHistoryEnd.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtHistoryEnd.IsPopupCalendarOpen = false;
			this.dtHistoryEnd.Location = new System.Drawing.Point(9, 190);
			// 
			// 
			// 
			this.dtHistoryEnd.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtHistoryEnd.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryEnd.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtHistoryEnd.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryEnd.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtHistoryEnd.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtHistoryEnd.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtHistoryEnd.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtHistoryEnd.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtHistoryEnd.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtHistoryEnd.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtHistoryEnd.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtHistoryEnd.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryEnd.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtHistoryEnd.Name = "dtHistoryEnd";
			this.dtHistoryEnd.Size = new System.Drawing.Size(209, 26);
			this.dtHistoryEnd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtHistoryEnd.TabIndex = 6;
			this.dtHistoryEnd.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtHistoryEnd.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// labelX3
			// 
			this.labelX3.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.labelX3.ForeColor = System.Drawing.Color.Black;
			this.labelX3.Location = new System.Drawing.Point(10, 94);
			this.labelX3.Name = "labelX3";
			this.labelX3.Size = new System.Drawing.Size(208, 23);
			this.labelX3.TabIndex = 5;
			this.labelX3.Text = "Thời gian bắt đầu:";
			// 
			// dtHistoryBegin
			// 
			this.dtHistoryBegin.AutoOffFreeTextEntry = true;
			this.dtHistoryBegin.BackColor = System.Drawing.Color.White;
			// 
			// 
			// 
			this.dtHistoryBegin.BackgroundStyle.Class = "DateTimeInputBackground";
			this.dtHistoryBegin.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryBegin.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
			this.dtHistoryBegin.ButtonDropDown.Visible = true;
			this.dtHistoryBegin.CustomFormat = "HH:mm dd/MM/yyyy";
			this.dtHistoryBegin.DateTimeSelectorVisibility = DevComponents.Editors.DateTimeAdv.eDateTimeSelectorVisibility.Both;
			this.dtHistoryBegin.ForeColor = System.Drawing.Color.Black;
			this.dtHistoryBegin.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
			this.dtHistoryBegin.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Center;
			this.dtHistoryBegin.IsPopupCalendarOpen = false;
			this.dtHistoryBegin.Location = new System.Drawing.Point(10, 123);
			// 
			// 
			// 
			this.dtHistoryBegin.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtHistoryBegin.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryBegin.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
			// 
			// 
			// 
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
			this.dtHistoryBegin.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryBegin.MonthCalendar.DayClickAutoClosePopup = false;
			this.dtHistoryBegin.MonthCalendar.DisplayMonth = new System.DateTime(2015, 7, 1, 0, 0, 0, 0);
			this.dtHistoryBegin.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dtHistoryBegin.MonthCalendar.MarkedDates = new System.DateTime[0];
			this.dtHistoryBegin.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
			// 
			// 
			// 
			this.dtHistoryBegin.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.dtHistoryBegin.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
			this.dtHistoryBegin.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.dtHistoryBegin.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.dtHistoryBegin.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
			this.dtHistoryBegin.Name = "dtHistoryBegin";
			this.dtHistoryBegin.Size = new System.Drawing.Size(209, 26);
			this.dtHistoryBegin.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
			this.dtHistoryBegin.TabIndex = 4;
			this.dtHistoryBegin.TimeSelectorTimeFormat = DevComponents.Editors.DateTimeAdv.eTimeSelectorFormat.Time24H;
			this.dtHistoryBegin.TimeSelectorType = DevComponents.Editors.DateTimeAdv.eTimeSelectorType.TouchStyle;
			// 
			// cbDeviceHistory
			// 
			this.cbDeviceHistory.BackColor = System.Drawing.Color.WhiteSmoke;
			this.cbDeviceHistory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cbDeviceHistory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDeviceHistory.ForeColor = System.Drawing.Color.Black;
			this.cbDeviceHistory.FormattingEnabled = true;
			this.cbDeviceHistory.ImageList = this.deviceImageList;
			this.cbDeviceHistory.ItemHeight = 64;
			this.cbDeviceHistory.Location = new System.Drawing.Point(10, 18);
			this.cbDeviceHistory.Name = "cbDeviceHistory";
			this.cbDeviceHistory.Size = new System.Drawing.Size(209, 70);
			this.cbDeviceHistory.TabIndex = 1;
			this.cbDeviceHistory.SelectedIndexChanged += new System.EventHandler(this.cbDeviceHistory_SelectedIndexChanged);
			// 
			// tabDeviceHistory
			// 
			this.tabDeviceHistory.AttachedControl = this.superTabControlPanel3;
			this.tabDeviceHistory.Enabled = false;
			this.tabDeviceHistory.GlobalItem = false;
			this.tabDeviceHistory.Name = "tabDeviceHistory";
			this.tabDeviceHistory.Text = "Lịch sử thiết bị";
			// 
			// superTabControlPanel2
			// 
			this.superTabControlPanel2.Controls.Add(this.gridBlocks);
			this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.superTabControlPanel2.Location = new System.Drawing.Point(0, 36);
			this.superTabControlPanel2.Name = "superTabControlPanel2";
			this.superTabControlPanel2.Size = new System.Drawing.Size(1090, 650);
			this.superTabControlPanel2.TabIndex = 0;
			this.superTabControlPanel2.TabItem = this.tabBlockManager;
			// 
			// gridBlocks
			// 
			this.gridBlocks.BackColor = System.Drawing.Color.WhiteSmoke;
			this.gridBlocks.DefaultVisualStyles.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
			this.gridBlocks.DefaultVisualStyles.CellStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridBlocks.DefaultVisualStyles.ColumnHeaderStyles.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
			this.gridBlocks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridBlocks.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
			this.gridBlocks.ForeColor = System.Drawing.Color.Black;
			this.gridBlocks.Location = new System.Drawing.Point(0, 0);
			this.gridBlocks.Name = "gridBlocks";
			// 
			// 
			// 
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockID);
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockKwh);
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockDate);
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockChart);
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockDevice);
			this.gridBlocks.PrimaryGrid.Columns.Add(this.colBlockImport);
			this.gridBlocks.PrimaryGrid.DefaultRowHeight = 75;
			padding1.Bottom = 4;
			padding1.Top = 4;
			this.gridBlocks.PrimaryGrid.DefaultVisualStyles.ColumnHeaderStyles.Default.Padding = padding1;
			this.gridBlocks.PrimaryGrid.SelectionGranularity = DevComponents.DotNetBar.SuperGrid.SelectionGranularity.RowWithCellHighlight;
			this.gridBlocks.PrimaryGrid.SortLevel = DevComponents.DotNetBar.SuperGrid.SortLevel.None;
			this.gridBlocks.Size = new System.Drawing.Size(1090, 650);
			this.gridBlocks.TabIndex = 0;
			this.gridBlocks.CellClick += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellClickEventArgs>(this.gridBlocks_CellClick);
			// 
			// colBlockID
			// 
			this.colBlockID.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colBlockID.Name = "ID";
			// 
			// colBlockKwh
			// 
			this.colBlockKwh.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colBlockKwh.Name = "Tiêu hao";
			this.colBlockKwh.Width = 125;
			// 
			// colBlockDate
			// 
			this.colBlockDate.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colBlockDate.Name = "Thời gian";
			this.colBlockDate.Width = 175;
			// 
			// colBlockChart
			// 
			this.colBlockChart.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
			this.colBlockChart.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridMicroChartEditControl);
			this.colBlockChart.Name = "Biểu đồ (W)";
			this.colBlockChart.Width = 250;
			// 
			// colBlockDevice
			// 
			this.colBlockDevice.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
			this.colBlockDevice.Name = "Thiết bị";
			this.colBlockDevice.Width = 200;
			// 
			// colBlockImport
			// 
			background1.Color1 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.colBlockImport.CellStyles.MouseOver.Background = background1;
			this.colBlockImport.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
			this.colBlockImport.MarkRowDirtyOnCellValueChange = false;
			this.colBlockImport.Name = "Nhập";
			this.colBlockImport.Width = 125;
			// 
			// tabBlockManager
			// 
			this.tabBlockManager.AttachedControl = this.superTabControlPanel2;
			this.tabBlockManager.Enabled = false;
			this.tabBlockManager.GlobalItem = false;
			this.tabBlockManager.Name = "tabBlockManager";
			this.tabBlockManager.Text = "Quản lý dữ liệu";
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
			this.statusBar.Location = new System.Drawing.Point(0, 685);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(1090, 26);
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
			this.btnAuthor.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.cbTheme,
            this.cpCanvasColor,
            this.cpBaseColor});
			this.btnAuthor.Text = "Kim Hảo @ 2015";
			this.btnAuthor.Click += new System.EventHandler(this.btnAuthor_Click);
			// 
			// cbTheme
			// 
			this.cbTheme.Caption = "Giao diện";
			this.cbTheme.ComboWidth = 125;
			this.cbTheme.DropDownHeight = 106;
			this.cbTheme.ItemHeight = 14;
			this.cbTheme.Name = "cbTheme";
			this.cbTheme.SelectedIndexChanged += new System.EventHandler(this.cbTheme_SelectedIndexChanged);
			// 
			// cpCanvasColor
			// 
			this.cpCanvasColor.Name = "cpCanvasColor";
			this.cpCanvasColor.Symbol = "";
			this.cpCanvasColor.Text = "Màu nền";
			this.cpCanvasColor.SelectedColorChanged += new System.EventHandler(this.cpCanvasColor_SelectedColorChanged);
			// 
			// cpBaseColor
			// 
			this.cpBaseColor.Name = "cpBaseColor";
			this.cpBaseColor.Symbol = "";
			this.cpBaseColor.Text = "Màu giao diện";
			this.cpBaseColor.SelectedColorChanged += new System.EventHandler(this.cpBaseColor_SelectedColorChanged);
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
			this.deviceImageListCombo.Images.SetKeyName(5, "line.jpg");
			this.deviceImageListCombo.Images.SetKeyName(6, "other.jpg");
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1090, 711);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.superTabControl1);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Energy Monitor @ KH - 2015";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
			this.superTabControl1.ResumeLayout(false);
			this.superTabControlPanel4.ResumeLayout(false);
			this.superTabControlPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtStatisticEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtStatisticBegin)).EndInit();
			this.superTabControlPanel1.ResumeLayout(false);
			this.superTabControlPanel5.ResumeLayout(false);
			this.superTabControlPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtEnvironmentEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtEnvironmentBegin)).EndInit();
			this.superTabControlPanel3.ResumeLayout(false);
			this.superTabControlPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtHistoryEnd)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtHistoryBegin)).EndInit();
			this.superTabControlPanel2.ResumeLayout(false);
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
		private DevComponents.DotNetBar.SuperTabItem tabBlockManager;
		private DevComponents.DotNetBar.ButtonX btnUpdateData;
		private DevComponents.DotNetBar.LabelX labelX1;
		private DevComponents.DotNetBar.Controls.TextBoxX txtLogUpdateTime;
		private DevComponents.DotNetBar.ListBoxAdv lbFileList;
		private DevComponents.DotNetBar.Bar statusBar;
		private DevComponents.DotNetBar.LabelItem lblStatus;
		private DevComponents.DotNetBar.ButtonItem btnAuthor;
		private DevComponents.DotNetBar.Controls.TextBoxX txtDiffTime;
		private DevComponents.DotNetBar.LabelX labelX2;
		private DevComponents.DotNetBar.Controls.CircularProgress progUpdateData;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colDeviceID;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colDeviceType;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colDeviceName;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colDeviceAction;
		private System.Windows.Forms.ImageList deviceImageList;
		private System.Windows.Forms.ImageList deviceImageListCombo;
		private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridDevice;
		private DevComponents.DotNetBar.SuperGrid.SuperGridControl gridBlocks;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockID;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockKwh;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockDevice;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockImport;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockChart;
		private DevComponents.DotNetBar.SuperGrid.GridColumn colBlockDate;
		private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
		private DevComponents.DotNetBar.SuperTabItem tabDeviceHistory;
		private DevComponents.DotNetBar.ComboBoxItem cbTheme;
		private DevComponents.DotNetBar.ColorPickerDropDown cpCanvasColor;
		private DevComponents.DotNetBar.ColorPickerDropDown cpBaseColor;
		private DeviceComboBox cbDeviceHistory;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHistoryBegin;
		private DevComponents.DotNetBar.LabelX labelX3;
		private DevComponents.DotNetBar.LabelX labelX4;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtHistoryEnd;
		private DevComponents.DotNetBar.ButtonX btnUpdateHistory;
		private ZedGraph.ZedGraphControl graphHistory;
		private DevComponents.DotNetBar.Controls.CircularProgress progDeviceHistory;
		private DevComponents.DotNetBar.LabelX labelX5;
		private DevComponents.DotNetBar.Controls.ComboBoxEx cbHistoryY2;
		private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel4;
		private DevComponents.DotNetBar.SuperTabItem tabDeviceStatistic;
		private DevComponents.DotNetBar.LabelX labelX6;
		private System.Windows.Forms.TextBox txtDeviceHistoryPower;
		private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel5;
		private DevComponents.DotNetBar.SuperTabItem tabEnvironment;
		private System.Windows.Forms.TextBox txtAverageTemperature;
		private DevComponents.DotNetBar.LabelX labelX7;
		private DevComponents.DotNetBar.ButtonX btnUpdateEvironment;
		private DevComponents.DotNetBar.LabelX labelX8;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEnvironmentEnd;
		private DevComponents.DotNetBar.LabelX labelX9;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtEnvironmentBegin;
		private ZedGraph.ZedGraphControl graphEnvironment;
		private System.Windows.Forms.TextBox txtStatisticPower;
		private DevComponents.DotNetBar.LabelX labelX10;
		private DevComponents.DotNetBar.Controls.ComboBoxEx cbStatisticType;
		private DevComponents.DotNetBar.LabelX labelX11;
		private DevComponents.DotNetBar.Controls.CircularProgress progDeviceStatistic;
		private DevComponents.DotNetBar.ButtonX btnUpdateStatistic;
		private DevComponents.DotNetBar.LabelX labelX12;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStatisticEnd;
		private DevComponents.DotNetBar.LabelX labelX13;
		private DevComponents.Editors.DateTimeAdv.DateTimeInput dtStatisticBegin;
		private DeviceComboBox cbDeviceStatistic;
		private ZedGraph.ZedGraphControl graphStatistic;
		private DevComponents.DotNetBar.Controls.CheckBoxX cbStatisticPieChart;
	}
}