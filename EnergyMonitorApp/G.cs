using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
		public const int CONNECT_TIMEOUT = 500;
		public static readonly string HTTP_SERVER_URI = "http://192.168.1.128/logs/";

		public const double POWER_MIN = 1.5;

		public static string SerializeBase64(object o)
		{
			byte[] bytes;
			long length = 0;
			MemoryStream ws = new MemoryStream();
			BinaryFormatter sf = new BinaryFormatter();
			sf.Serialize(ws, o);
			length = ws.Length;
			bytes = ws.GetBuffer();
			string encodedData = bytes.Length + ":" + Convert.ToBase64String(bytes, 0, bytes.Length, Base64FormattingOptions.None);
			return encodedData;
		}

		public static object DeserializeBase64(string s)
		{
			int p = s.IndexOf(':');
			int length = Convert.ToInt32(s.Substring(0, p));
			byte[] memorydata = Convert.FromBase64String(s.Substring(p + 1));
			MemoryStream rs = new MemoryStream(memorydata, 0, length);
			BinaryFormatter sf = new BinaryFormatter();
			object o = sf.Deserialize(rs);
			return o;
		}
	}
}
