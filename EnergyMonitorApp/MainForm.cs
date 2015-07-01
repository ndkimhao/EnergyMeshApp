using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using EnergyMonitorApp.Properties;
using System.IO;
using System.Threading;
using DevComponents.DotNetBar.SuperGrid;
using DevComponents.DotNetBar;

namespace EnergyMonitorApp
{
	public partial class MainForm : MetroForm
	{

		public MainForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
			gridInit();
		}

		#region "Device list function"

		private void gridInit()
		{
			colDeviceType.EditorType = typeof(MyGridImageEditControl);
			colDeviceType.EditorParams = new object[] { deviceImageList, ImageSizeMode.Zoom };
			colAction.EditorType = typeof(MyGridRadialMenuEditControl);
			((MyGridRadialMenuEditControl)colAction.EditControl).ItemClick += RadialDevice_ItemClick;

			GridPanel panel = gridDevice.PrimaryGrid;
			DeviceManager.LoadDeviceList();
			foreach (Device dev in DeviceManager.DeviceList)
			{
				if (!dev.IsDeleted)
				{
					panel.Rows.Add(new GridRow(dev.ID, dev.ImageKey, dev.Name, null));
				}
			}
		}

		private void RadialDevice_ItemClick(object sender, EventArgs e)
		{
			if (((BaseItem)sender).Tag != null)
			{
				RadialAction action = (RadialAction)((BaseItem)sender).Tag;
				GridPanel panel = gridDevice.PrimaryGrid;
				SelectedElementCollection selectedRows = gridDevice.GetSelectedRows();
				if (selectedRows.Count != 0)
				{
					int rowIndex = ((GridRow)selectedRows[0]).RowIndex;
					if (action == RadialAction.Delete)
					{
						string act = isAddingRow ? "HỦY</font> thiết bị vừa tạo" : "XÓA</font> thiết bị";
						if (MessageBoxEx.Show(this, "<font size='18'><b>Bạn có thật sự muốn <font color='#B02B2C'>" + act + " ?</b></font>",
							"<font size='15'><b>Xác nhận</b></font>", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							if (isAddingRow && rowIndex == (panel.Rows.Count - 1))
							{
								isAddingRow = false;
								gridDevice.PrimaryGrid.ShowInsertRow = false;
								gridDevice.PrimaryGrid.ShowInsertRow = true;
							}
							else
							{
								int ID = (int)((GridRow)panel.Rows[rowIndex]).Cells[0].Value;
								DeviceManager.DeviceList.Find(dev => dev.ID == ID).IsDeleted = true;
							}
							panel.Rows.RemoveAt(rowIndex);
						}
					}
					else if (action == RadialAction.Accept)
					{
						GridRow row = (GridRow)panel.Rows[rowIndex];
						if (isAddingRow && rowIndex == (panel.Rows.Count - 1))
						{
							Device dev = new Device()
							{
								ID = DeviceManager.GetNewId(),
								ImageKey = (string)row.Cells[1].Value,
								Name = (string)row.Cells[2].Value,
								IsDeleted = false
							};
							row.Cells[0].Value = dev.ID;
							DeviceManager.DeviceList.Add(dev);
							DeviceManager.SaveDeviceList();

							isAddingRow = false;
							gridDevice.PrimaryGrid.ShowInsertRow = true;
						}
						else
						{
							int ID = (int)row.Cells[0].Value;
							Device dev = DeviceManager.DeviceList.Find(d => d.ID == ID);
							dev.ImageKey = (string)row.Cells[1].Value;
							dev.Name = (string)row.Cells[2].Value;
							DeviceManager.SaveDeviceList();
						}
						row.RowDirty = false;
					}
				}
			}
		}

		Random ran = new Random();
		private GridRow GetNewRow()
		{
			string id = ran.Next(50).ToString();
			string name = "Test device id " + id;

			GridRow row = new GridRow(id, deviceImageListCombo.Images.Keys[0], name, null);
			return row;
		}

		private void gridDevice_CloseEdit(object sender, GridCloseEditEventArgs e)
		{
			if (e.GridCell.ColumnIndex == 1)
			{
				e.GridCell.EditorType = typeof(MyGridImageEditControl);
				e.GridCell.EditorParams = new object[] { deviceImageList, ImageSizeMode.Zoom };
			}
		}

		private readonly Dictionary<string, string> deviceTypeDict = new Dictionary<string, string>()
		{
			{"air_conditioner.jpg", "Máy lạnh"},
			{"electric_socket.jpg", "Ổ cắm"},
			{"fan.jpg", "Quạt máy"},
			{"washing_machine.jpg", "Máy giặt"},
			{"water_heater.jpg", "Máy nước nóng"},
		};
		private void gridDevice_CellDoubleClick(object sender, GridCellDoubleClickEventArgs e)
		{
			if (e.GridCell.ColumnIndex == 1)
			{
				e.GridCell.EditorType = typeof(GridImageCombo);
				e.GridCell.EditorParams = new object[] { deviceImageListCombo, deviceTypeDict, deviceImageListCombo.ImageSize.Width * 2 };
			}
		}

		private void gridDevice_RowSetDefaultValues(object sender, GridRowSetDefaultValuesEventArgs e)
		{
			if (e.NewRowContext == NewRowContext.RowInit)
			{
				GridRow row = e.GridRow;
				row.Cells[0].Value = "Mới";
				row.Cells[1].Value = Device.DefaultImageKey;
				row.Cells[2].Value = Device.DefaultName;
				row.Cells[3].Value = null;
			}
		}

		private bool isAddingRow = false;
		private void gridDevice_RowAdded(object sender, GridRowAddedEventArgs e)
		{
			gridDevice.PrimaryGrid.ShowInsertRow = false;
			isAddingRow = true;
			GridPanel panel = gridDevice.PrimaryGrid;
		}

		#endregion

		#region "Update Data"

		Thread updateDataThread;
		private void btnUpdateData_Click(object sender, EventArgs e)
		{
			if (updateDataThread == null || !updateDataThread.IsAlive)
			{
				updateDataThread = new Thread(doUpdateDate);
				updateDataThread.IsBackground = true;
				//updateDataThread.Priority = ThreadPriority.Highest;
				updateDataThread.Start();
			}
		}

		private void doUpdateDate()
		{
			lbFileList.Visible = false;
			progUpdateData.IsRunning = true;

			lblStatus.Text = "Đang cập nhật dữ liệu...";

			List<string> curLog = LogManager.GetAllLog().Select(str => str.Replace('\\', '/')).ToList();
			List<string> listBoxItems = new List<string>();

			// Get data from ftp server
			try
			{
				string[] ftpList = NetHelper.ListLogsFTP();
				foreach (string uri in ftpList)
				{
					string path = uri.Replace(G.FTP_SERVER_URI, "");
					string realPath = "logs/" + path;
					try
					{
						if (File.Exists(realPath))
						{
							listBoxItems.Add(path + " (cũ)");
						}
						else
						{
							listBoxItems.Add(path + " (mới)");
							NetHelper.DownloadFTP(uri, realPath);
						}
						curLog.Remove(curLog.Find(str => realPath.Equals(str)));
					}
					catch
					{
						lblStatus.Text = "Tải file từ máy chủ FTP lỗi: " + path;
					}
				}
			}
			catch
			{
				lblStatus.Text = "Kết nối máy chủ FTP lỗi";
			}

			// Get data directly from Master
			try
			{
				string[] httpList = NetHelper.ListLogsHTTP();
				foreach (string uri in httpList)
				{
					try
					{
						string realPath = "logs/" + uri;
						NetHelper.DownloadHTTP(uri, realPath);
						if (File.Exists(realPath))
						{
							listBoxItems.Add(uri + " (cập nhật)");
						}
						else
						{
							listBoxItems.Add(uri + " (mới)");
						}
						curLog.Remove(curLog.Find(str => realPath.Equals(str)));
					}
					catch
					{
						lblStatus.Text = "Tải file từ máy chủ HTTP lỗi: " + uri;
					}
				}
			}
			catch
			{
				lblStatus.Text = "Kết nối máy chủ HTTP lỗi";
			}

			// Local file
			foreach (string path in curLog)
			{
				string dispPath = path.Replace("logs/", "");
				listBoxItems.Add(dispPath + " (nội bộ)");
			}

			// Display data
			lbFileList.Items.Clear();
			listBoxItems.Sort();
			lbFileList.DataSource = listBoxItems;

			// Load log
			lblStatus.Text = "Đang xử lý dữ liệu...";
			try
			{
				LogManager.LoadLog();
			}
			catch
			{
				lblStatus.Text = "Xử lý dữ liệu lỗi";
			}

			DateTime updatedDate = LogManager.GetUpdatedLog();
			TimeSpan diff = DateTime.Now - updatedDate;
			string strDate = updatedDate.ToString("HH:mm:ss dd/MM/yyyy");
			string strDiff = diff.Days == 0 ? string.Format("{0:00} giờ {1:00} phút {2:00} giây",
				diff.Hours, diff.Minutes, diff.Seconds) :
				string.Format("{0} ngày {1:00} giờ {2:00} phút {3:00} giây",
				(int)diff.TotalDays, diff.Hours, diff.Minutes, diff.Seconds);
			txtLogUpdateTime.Text = strDate;
			lblStatus.Text = "Dữ liệu cập nhật đến " + strDate + " (trễ " + strDiff + ")"; ;
			txtDiffTime.Text = strDiff;

			lbFileList.Visible = true;
			progUpdateData.IsRunning = false;
		}

		private void btnAuthor_Click(object sender, EventArgs e)
		{
			new AboutForm().ShowDialog(this);
		}

		#endregion

	}
}
