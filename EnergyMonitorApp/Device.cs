using DevComponents.DotNetBar.SuperGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	enum DeviceType
	{
		AirConditioner, ElectricSocket, Fan, WashingMachine, WaterHeater
	}

	[Serializable()]
	class Device
	{
		public int ID { get; set; }
		public DeviceType Type { get; set; }
		public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public List<long> BlockList { get; set; }

		private static readonly Dictionary<DeviceType, string> _DeviceTypeImageBinding = new Dictionary<DeviceType, string>
		{
			{DeviceType.ElectricSocket, "electric_socket.jpg"},
			{DeviceType.AirConditioner, "air_conditioner.jpg"},
			{DeviceType.Fan, "fan.jpg"},
			{DeviceType.WashingMachine, "washing_machine.jpg"},
			{DeviceType.WaterHeater, "water_heater.jpg"},
		};
		public string ImageKey
		{
			get
			{
				return _DeviceTypeImageBinding[Type];
			}
			set
			{
				Type = _DeviceTypeImageBinding.FirstOrDefault(x => x.Value == value).Key;
			}
		}

		public DateTime BeginTime
		{
			get
			{
				DateTime result = DateTime.MaxValue;
				foreach (PowerBlock block in LogManager.PowerBlockList.Values)
				{
					if (BlockList.Exists(l => l == block.ID) && block.BeginTime < result)
					{
						result = block.BeginTime;
					}
				}
				return result;
			}
		}

		public DateTime EndTime
		{
			get
			{
				DateTime result = DateTime.MinValue;
				foreach (PowerBlock block in LogManager.PowerBlockList.Values)
				{
					if (BlockList.Exists(l => l == block.ID) && block.EndTime > result)
					{
						result = block.EndTime;
					}
				}
				return result;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		public static readonly string DefaultImageKey = _DeviceTypeImageBinding.First().Value;
		public static readonly string DefaultName = "Thiết bị mới";
	}
}
