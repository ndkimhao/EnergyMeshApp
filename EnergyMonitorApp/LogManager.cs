﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	class LogManager
	{

		public static List<LogEntry> logEntries = new List<LogEntry>();

		public static string[] GetAllLog()
		{
			return Directory.GetFiles(@"logs\", "*.*", SearchOption.AllDirectories);
		}

		public static void LoadLog()
		{
			logEntries.Clear();
			string[] files = Directory.GetFiles(@"logs\", "*.*", SearchOption.AllDirectories);
			foreach (string file in files)
			{
				try
				{
					string[] lines = File.ReadAllLines(file);
					string[] dateData = lines[0].Split('/');
					DateTime dt = new DateTime(int.Parse(dateData[2]), int.Parse(dateData[3]), int.Parse(dateData[4]), int.Parse(dateData[5].Substring(0, 2)), 0, 0);
					for (int i = 1; i < lines.Length; i++)
					{
						string[] data = lines[i].Split(',');
						string[] timeData = data[0].Split(':');
						DateTime realDT = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, int.Parse(timeData[0]), int.Parse(timeData[1]));
						LogEntry logEntry = null;
						int type = -1;
						switch (type = int.Parse(data[1]))
						{
							case (int)LogType.MasterHeartbeat:
								{
									Log_MasterHeartbeat log = new Log_MasterHeartbeat();
									log.From = 1;
									log.VCC = float.Parse(data[2]);
									log.Uptime = int.Parse(data[3]);
									log.FreeRam = int.Parse(data[4]);
									log.Temperature = float.Parse(data[5]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientHeartbeat:
								{
									Log_ClientHeartbeat log = new Log_ClientHeartbeat();
									log.From = byte.Parse(data[2]);
									log.VCC = float.Parse(data[3]);
									log.Uptime = int.Parse(data[4]);
									log.FreeRam = int.Parse(data[5]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientTemperature:
								{
									Log_ClientTemperature log = new Log_ClientTemperature();
									log.From = byte.Parse(data[2]);
									log.Temperature = float.Parse(data[3]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientRealPower:
								{
									Log_ClientRealPower log = new Log_ClientRealPower();
									log.From = byte.Parse(data[2]);
									log.SensorID = byte.Parse(data[3]);
									log.Session = int.Parse(data[4]);
									log.RealPower = float.Parse(data[5]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientDetailPower:
								{
									Log_ClientDetailPower log = new Log_ClientDetailPower();
									log.From = byte.Parse(data[2]);
									log.SensorID = byte.Parse(data[3]);
									log.Session = int.Parse(data[4]);
									log.V = float.Parse(data[5]);
									log.I = float.Parse(data[6]);
									logEntry = log;
								}
								break;
						}
						if (logEntry != null)
						{
							logEntry.Type = (LogType)type;
							logEntry.Time = realDT;
							logEntries.Add(logEntry);
						}
					}
				}
				catch { }
			}
		}

		public static DateTime GetUpdatedLog()
		{
			DateTime result = new DateTime(0);
			foreach (var logEntry in logEntries)
			{
				if (logEntry.Time > result)
				{
					result = logEntry.Time;
				}
			}
			return result;
		}

	}
}