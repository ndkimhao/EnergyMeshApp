using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	enum LogType : int
	{
		MasterHeartbeat = 1, ClientHeartbeat, ClientTemperature, ClientRealPower, ClientDetailPower
	}

	class LogRecord
	{
		public LogType Type { get; set; }
		public DateTime Time { get; set; }
		public byte From { get; set; }
	}

	class Log_MasterHeartbeat : LogRecord
	{
		public float VCC { get; set; }
		public uint Uptime { get; set; }
		public uint FreeRam { get; set; }
		public float Temperature { get; set; }
	}

	class Log_ClientHeartbeat : LogRecord
	{
		public float VCC { get; set; }
		public uint Uptime { get; set; }
		public uint FreeRam { get; set; }
	}

	class Log_ClientTemperature : LogRecord
	{
		public float Temperature { get; set; }
	}

	interface IPowerRecord
	{
		byte From { get; set; }
		byte SensorID { get; set; }
		uint SessionID { get; set; }
		long BlockID { get; }
	}

	class Log_ClientRealPower : LogRecord, IPowerRecord
	{
		public byte SensorID { get; set; }
		public uint SessionID { get; set; }
		public float RealPower { get; set; }
		public long BlockID
		{
			get
			{
				return (long)From << 48 | (long)SensorID << 40 | (long)SessionID;
			}
		}
	}

	class Log_ClientDetailPower : LogRecord, IPowerRecord
	{
		public byte SensorID { get; set; }
		public uint SessionID { get; set; }
		public float V { get; set; }
		public float I { get; set; }
		public long BlockID
		{
			get
			{
				return (long)From << 48 | (long)SensorID << 40 | (long)SessionID;
			}
		}
	}

	class PowerBlock
	{
		public byte From { get; set; }
		public byte SensorID { get; set; }
		public uint SessionID { get; set; }
		public long BlockID { get; set; }
		public ushort GlobalSensorID
		{
			get
			{
				return (ushort)(From << 8 | SensorID);
			}
		}
		public List<Log_ClientRealPower> RealPowerList { get; set; }
		public List<Log_ClientDetailPower> DetailPowerList { get; set; }
	}
}
