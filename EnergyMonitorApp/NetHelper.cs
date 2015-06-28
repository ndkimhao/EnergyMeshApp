using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMonitorApp
{
	class NetHelper
	{

		public static void DownloadHTTP(string uri, string path)
		{
			int bytesRead = 0;
			byte[] buffer = new byte[2048];

			WebRequest request = WebRequest.Create(G.MASTER_SERVER_URI + uri);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream reader = request.GetResponse().GetResponseStream();
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				FileStream fileStream = new FileStream(path, FileMode.Create);

				while (true)
				{
					bytesRead = reader.Read(buffer, 0, buffer.Length);
					if (bytesRead == 0)
						break;
					fileStream.Write(buffer, 0, bytesRead);
				}
				fileStream.Close();
			}
			response.Close();
		}

		public static void DownloadFTP(string uri, string path)
		{
			int bytesRead = 0;
			byte[] buffer = new byte[2048];

			FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(uri);
			request.Proxy = null;
			request.UsePassive = true;
			request.UseBinary = true;
			request.KeepAlive = true;
			request.Credentials = new NetworkCredential(G.FTP_USER, G.FTP_PASS);
			request.Method = WebRequestMethods.Ftp.DownloadFile;

			Stream reader = request.GetResponse().GetResponseStream();
			Directory.CreateDirectory(Path.GetDirectoryName(path));
			FileStream fileStream = new FileStream(path, FileMode.Create);

			while (true)
			{
				bytesRead = reader.Read(buffer, 0, buffer.Length);
				if (bytesRead == 0)
					break;
				fileStream.Write(buffer, 0, bytesRead);
			}
			fileStream.Close();
		}

		public static string[] ListLogsFTP()
		{
			List<string> files = new List<string>();
			Queue<string> folders = new Queue<string>();

			folders.Enqueue(G.FTP_SERVER_URI);

			while (folders.Count > 0)
			{
				string fld = folders.Dequeue();
				List<string> newFiles = new List<string>();

				FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
				ftp.Credentials = new NetworkCredential(G.FTP_USER, G.FTP_PASS);
				ftp.UsePassive = false;
				ftp.Method = WebRequestMethods.Ftp.ListDirectory;
				using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream()))
				{
					string line = resp.ReadLine();
					while (line != null)
					{
						newFiles.Add(line.Trim());
						line = resp.ReadLine();
					}
				}

				ftp = (FtpWebRequest)FtpWebRequest.Create(fld);
				ftp.Credentials = new NetworkCredential(G.FTP_USER, G.FTP_PASS);
				ftp.UsePassive = false;
				ftp.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
				using (StreamReader resp = new StreamReader(ftp.GetResponse().GetResponseStream()))
				{
					string line = resp.ReadLine();
					while (line != null)
					{
						if (line.Trim().ToLower().StartsWith("d") || line.Contains(" <DIR> "))
						{
							string dir = newFiles.First(x => line.EndsWith(x));
							newFiles.Remove(dir);
							folders.Enqueue(fld + dir + "/");
						}
						line = resp.ReadLine();
					}
				}
				files.AddRange(from f in newFiles select fld + f);
			}
			return files.ToArray();
		}

	}
}
