using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.IO;

namespace EnergyMeshApp
{
	public partial class AboutForm : DevComponents.DotNetBar.Metro.MetroForm
	{
		public AboutForm()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.Close();
			this.Dispose();
		}

		private void AboutForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control && e.KeyCode == Keys.D)
			{
				if (Directory.Exists("config"))
				{
					Directory.Delete("config", true);
				}
				DeviceManager.LoadDeviceList();
				Application.Exit();
			}
		}
	}
}