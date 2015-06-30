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

namespace EnergyMonitorApp
{
	public partial class MainForm : MetroForm
	{
		public MainForm()
		{
			InitializeComponent();
			Control.CheckForIllegalCrossThreadCalls = false;
		}

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

	}
}
