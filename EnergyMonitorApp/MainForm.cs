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
using System.Net;
using System.IO;

namespace EnergyMonitorApp
{
	public partial class MainForm : MetroForm
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void btnUpdateData_Click(object sender, EventArgs e)
		{
			lbFileList.Items.Clear();
			List<string> curLog = LogManager.GetAllLog().Select(str => str.Replace('\\', '/')).ToList();
			List<string> listBoxItems = new List<string>();

			// Get data from ftp server
			try
			{
				string[] ftpList = NetHelper.ListLogsFTP();
				foreach (string uri in ftpList)
				{
					try
					{
						string path = uri.Replace(G.FTP_SERVER_URI, "");
						string realPath = "logs/" + path;
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
					}
				}
			}
			catch
			{
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
					catch { }
				}
			}
			catch { }

			// Local file
			foreach (string path in curLog)
			{
				string dispPath = path.Replace("logs/", "");
				listBoxItems.Add(dispPath + " (nội bộ)");
			}

			// Display data
			listBoxItems.Sort();
			lbFileList.DataSource = listBoxItems;

			// Load log
			LogManager.LoadLog();

			txtLogUpdateTime.Text = LogManager.GetUpdatedLog().ToString("HH:mm:ss dd/MM/yyyy");
		}

	}
}
