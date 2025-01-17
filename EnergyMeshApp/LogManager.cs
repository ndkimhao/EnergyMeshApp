﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMeshApp
{
	class LogManager
	{

		public static List<LogRecord> LogEntryList = new List<LogRecord>();
		public static Dictionary<long, PowerBlock> PowerBlockList = new Dictionary<long, PowerBlock>();

		public static string[] GetAllLog()
		{
			return Directory.GetFiles(@"logs\", "*.*", SearchOption.AllDirectories);
		}

		public static void LoadLog()
		{
			LogEntryList.Clear();
			PowerBlockList.Clear();
			string[] files = Directory.GetFiles(@"logs\", "*.*", SearchOption.AllDirectories);
			List<string> listFiles = files.ToList();
			listFiles.Sort();
			files = listFiles.ToArray();
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
						LogRecord logEntry = null;
						int type = -1;
						switch (type = int.Parse(data[1]))
						{
							case (int)LogType.MasterHeartbeat:
								{
									Log_MasterHeartbeat log = new Log_MasterHeartbeat();
									log.ClientID = 1;
									log.VCC = float.Parse(data[2]);
									log.Uptime = uint.Parse(data[3]);
									log.FreeRam = uint.Parse(data[4]);
									log.Temperature = float.Parse(data[5]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientHeartbeat:
								{
									Log_ClientHeartbeat log = new Log_ClientHeartbeat();
									log.ClientID = byte.Parse(data[2]);
									log.VCC = float.Parse(data[3]);
									log.Uptime = uint.Parse(data[4]);
									log.FreeRam = uint.Parse(data[5]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientTemperature:
								{
									Log_ClientTemperature log = new Log_ClientTemperature();
									log.ClientID = byte.Parse(data[2]);
									log.Temperature = float.Parse(data[3]);
									logEntry = log;
								}
								break;
							case (int)LogType.ClientRealPower:
								{
									Log_ClientRealPower log = new Log_ClientRealPower();
									log.ClientID = byte.Parse(data[2]);
									log.SensorID = byte.Parse(data[3]);
									log.SessionID = uint.Parse(data[4]);
									log.RealPower = Math.Abs(float.Parse(data[5]));
									if (log.RealPower < G.POWER_MIN) log.RealPower = 0;
									logEntry = log;
								}
								break;
							case (int)LogType.ClientDetailPower:
								{
									Log_ClientDetailPower log = new Log_ClientDetailPower();
									log.ClientID = byte.Parse(data[2]);
									log.SensorID = byte.Parse(data[3]);
									log.SessionID = uint.Parse(data[4]);
									log.V = float.Parse(data[5]);
									if (log.V < G.V_MIN || log.V > G.V_MAX) log.V = 0;
									log.I = Math.Abs(float.Parse(data[6]));
									if (log.I < G.I_MIN) log.I = 0;
									logEntry = log;
								}
								break;
						}
						if (logEntry != null)
						{
							logEntry.Type = (LogType)type;
							logEntry.Time = realDT;
							LogEntryList.Add(logEntry);
							if (logEntry is IPowerRecord)
							{
								IPowerRecord rec = (IPowerRecord)logEntry;
								long blockID = rec.BlockID;
								PowerBlock block;
								if (!PowerBlockList.TryGetValue(blockID, out block))
								{
									block = new PowerBlock()
									{
										ID = blockID,
										ClientID = rec.ClientID,
										SensorID = rec.SensorID,
										SessionID = rec.SessionID,
										IsDeleted = false,
										RealPowerList = new List<Log_ClientRealPower>(),
										DetailPowerList = new List<Log_ClientDetailPower>()
									};
									PowerBlockList.Add(blockID, block);
								}
								if (rec is Log_ClientRealPower)
								{
									block.RealPowerList.Add((Log_ClientRealPower)rec);
								}
								else
								{
									block.DetailPowerList.Add((Log_ClientDetailPower)rec);
								}
							}
						}
					}
				}
				catch { }
			}
			foreach (PowerBlock block in PowerBlockList.Values)
			{
				block.BeginTime = block.RealPowerList.First().Time;
				block.EndTime = block.RealPowerList.Last().Time;
			}
		}

		public static DateTime GetUpdatedLog()
		{
			DateTime result = new DateTime(0);
			foreach (var logEntry in LogEntryList)
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
