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

		public static readonly string DefaultImageKey = _DeviceTypeImageBinding.First().Value;
		public static readonly string DefaultName = "Thiết bị mới";
	}
}
