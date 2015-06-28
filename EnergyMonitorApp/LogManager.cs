using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	class LogManager
	{

		public static DateTime GetUpdatedLog()
		{
			DateTime result = new DateTime(2015, 1, 1, 0, 0, 0);
			string newestPath;
			string[] files = Directory.GetFiles(@"logs\","*.*",SearchOption.AllDirectories);
			foreach (string file in files)
			{
				System.Windows.Forms.MessageBox.Show(file);
			}
			return result;
		}

	}
}
