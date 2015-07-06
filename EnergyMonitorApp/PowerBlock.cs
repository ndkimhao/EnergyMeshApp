using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	class PowerBlock
	{
		public byte ClientID { get; set; }
		public byte SensorID { get; set; }
		public uint SessionID { get; set; }
		public long ID { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime BeginTime { get; set; }
		public DateTime EndTime { get; set; }
		public ushort GlobalSensorID
		{
			get
			{
				return (ushort)(ClientID << 8 | SensorID);
			}
		}
		public List<Log_ClientRealPower> RealPowerList { get; set; }
		public List<Log_ClientDetailPower> DetailPowerList { get; set; }

		private double _WH = double.MinValue;
		public double WH
		{
			get
			{
				if (_WH == double.MinValue)
				{
					_WH = 0;
					int forTo = RealPowerList.Count - 1;
					for (int i = 0; i < forTo; i++)
					{
						Log_ClientRealPower rec = RealPowerList[i];
						TimeSpan diff = RealPowerList[i + 1].Time - rec.Time;
						if (diff.TotalSeconds > G.MAX_SECOND_RECORD_REALPOWER) continue;
						_WH += rec.RealPower * diff.TotalSeconds;
					}
					_WH /= 3600;
				}
				return _WH;
			}
		}
	}

}
