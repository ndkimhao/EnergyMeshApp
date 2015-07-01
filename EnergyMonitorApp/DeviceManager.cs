using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMonitorApp.Properties;

namespace EnergyMonitorApp
{
	class DeviceManager
	{
		public static List<Device> DeviceList = new List<Device>();

		public static int GetNewId()
		{
			int newId = 0;
			foreach (Device dev in DeviceList)
			{
				if (dev.ID > newId)
				{
					newId = dev.ID;
				}
			}
			return ++newId;
		}

		public static void LoadDeviceList()
		{
			string str = Settings.Default.DeviceList;
			if (string.IsNullOrEmpty(str))
			{
				SaveDeviceList();
				str = Settings.Default.DeviceList;
			}
			try
			{
				DeviceList = (List<Device>)G.DeserializeBase64(str);
			}
			catch (Exception)
			{
				SaveDeviceList();
				str = Settings.Default.DeviceList;
				DeviceList = (List<Device>)G.DeserializeBase64(str);
			}
			DeviceList.Sort((dev1, dev2) => (dev1.ID.CompareTo(dev2.ID)));
		}

		public static void SaveDeviceList()
		{
			Settings.Default.DeviceList = G.SerializeBase64(DeviceList);
			Settings.Default.Save();
		}
	}
}
