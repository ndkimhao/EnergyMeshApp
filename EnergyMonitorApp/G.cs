using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	class G
	{

		public static readonly string FTP_SERVER = "127.0.0.1";
		public static readonly string FTP_SERVER_URI = "ftp://" + FTP_SERVER + "/logs/";
		public static readonly string FTP_USER = "house_1";
		public static readonly string FTP_PASS = "123456";

		public static readonly string MASTER_SERVER_URI = "http://192.168.1.128/logs/";

	}
}
