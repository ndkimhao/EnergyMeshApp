using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	enum LogType:int
	{
		MasterHeartbeat = 1, ClientHeartbeat, ClientTemperature, ClientRealPower, ClientDetailPower
	}

	class LogEntry
	{
		public LogType Type { get; set; }
		public DateTime Time { get; set; }
		public byte From { get; set; }
	}

	class Log_MasterHeartbeat : LogEntry
	{
		public float VCC { get; set; }
		public int Uptime { get; set; }
		public int FreeRam { get; set; }
		public float Temperature { get; set; }
	}

	class Log_ClientHeartbeat : LogEntry
	{
		public float VCC { get; set; }
		public int Uptime { get; set; }
		public int FreeRam { get; set; }
	}

	class Log_ClientTemperature : LogEntry
	{
		public float Temperature { get; set; }
	}

	class Log_ClientRealPower : LogEntry
	{
		public byte SensorID { get; set; }
		public int Session { get; set; }
		public float RealPower { get; set; }
	}

	class Log_ClientDetailPower : LogEntry
	{
		public byte SensorID { get; set; }
		public int Session { get; set; }
		public float V { get; set; }
		public float I { get; set; }
	}
}
