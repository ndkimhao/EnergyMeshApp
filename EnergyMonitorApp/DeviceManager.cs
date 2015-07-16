using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMeshApp.Properties;

namespace EnergyMeshApp
{
	class DeviceManager
	{
		public static List<Device> DeviceList;
		private static Device _NullDevice;
		public static Device NullDevice
		{
			get
			{
				return _NullDevice;
			}
		}

		public static void DeleteBlock(long ID)
		{
			for (int i = 0; i < NullDevice.BlockList.Count; )
			{
				if (NullDevice.BlockList[i] == ID)
				{
					NullDevice.BlockList.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
			foreach (Device dev in DeviceList)
			{
				for (int i = 0; i < dev.BlockList.Count; )
				{
					if (dev.BlockList[i] == ID)
					{
						dev.BlockList.RemoveAt(i);
					}
					else
					{
						i++;
					}
				}
			}
		}

		public static Device getBlockOwner(long ID)
		{
			foreach (long blockID in NullDevice.BlockList)
			{
				if (blockID == ID) return NullDevice;
			}
			foreach (Device dev in DeviceList)
			{
				foreach (long blockID in dev.BlockList)
				{
					if (blockID == ID) return dev;
				}
			}
			return null;
		}

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

		public static Device getByID(int ID)
		{
			return DeviceList.Find(d => d.ID == ID);
		}

		public static void LoadDeviceList()
		{
			string str = Settings.Default.DeviceList;
			if (string.IsNullOrEmpty(str))
			{
				_NullDevice = new Device()
				{
					ID = -3,
					Name = null,
					BlockList = new List<long>()
				};
				DeviceList = new List<Device>();
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
			_NullDevice = DeviceList[0];
			DeviceList.RemoveAt(0);
		}

		public static void SaveDeviceList()
		{
			DeviceList.Add(NullDevice);
			Settings.Default.DeviceList = G.SerializeBase64(DeviceList);
			DeviceList.Remove(NullDevice);
			Settings.Default.Save();
		}
	}
}
