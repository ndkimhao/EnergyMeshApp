using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMeshApp.Properties;
using System.IO;

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
			string data;
			if (!File.Exists("config/device_list.dat"))
			{
				_NullDevice = new Device()
				{
					ID = -3,
					Name = null,
					BlockList = new List<long>()
				};
				DeviceList = new List<Device>();
				data = SaveDeviceList();
			}
			else
			{
				data = File.ReadAllText("config/device_list.dat");
			}
			DeviceList = (List<Device>)G.DeserializeBase64(data);
			DeviceList.Sort((dev1, dev2) => (dev1.ID.CompareTo(dev2.ID)));
			_NullDevice = DeviceList[0];
			DeviceList.RemoveAt(0);
		}

		public static string SaveDeviceList()
		{
			DeviceList.Add(NullDevice);
			string result = G.SerializeBase64(DeviceList);
			DeviceList.Remove(NullDevice);
			if (!Directory.Exists("config"))
			{
				Directory.CreateDirectory("config");
			}
			File.WriteAllText("config/device_list.dat", result);
			return result;
		}
	}
}
