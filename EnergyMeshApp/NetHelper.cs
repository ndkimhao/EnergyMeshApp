using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMeshApp
{
	class NetHelper
	{

		public static void DownloadHTTP(string uri, string path)
		{
			int bytesRead = 0;
			byte[] buffer = new byte[2048];

			WebRequest request = WebRequest.Create(G.HTTP_SERVER_URI + uri);
			request.Timeout = G.CONNECT_TIMEOUT;
			request.Credentials = new NetworkCredential(G.HTTP_USER, G.HTTP_PASS);
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
			request.Timeout = G.CONNECT_TIMEOUT;
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

		public static string[] ListLogsHTTP()
		{
			List<string> files = new List<string>();
			WebRequest request = WebRequest.Create(G.HTTP_SERVER_URI);
			request.Timeout = G.CONNECT_TIMEOUT;
			request.Credentials = new NetworkCredential(G.HTTP_USER, G.HTTP_PASS);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			if (response.StatusCode == HttpStatusCode.OK)
			{
				Stream dataStream = response.GetResponseStream();
				StreamReader reader = new StreamReader(dataStream);
				List<string> lines = reader.ReadToEnd().Split('\r', '\n').ToList();
				reader.Close();
				response.Close();

				int state = 0;
				for (int i = 0; i < lines.Count; )
				{
					if (String.IsNullOrEmpty(lines[i]))
					{
						lines.RemoveAt(i);
					}
					if (state == 0)
					{
						if (lines[i] == ">>BEGIN<<") state++;
						lines.RemoveAt(i);
					}
					else if (state == 1)
					{
						if (lines[i] == ">>END<<")
						{
							state++;
						}
						else
						{
							i++;
						}
					}
					else
					{
						lines.RemoveAt(i);
					}
				}
				string y = null, m = null, d = null, h = null;
				foreach (string str in lines)
				{
					if (str.StartsWith("\t\t\t"))
					{
						if (str.IndexOf(".LUP") != -1)
						{
							h = str.Trim().Substring(0, 2);
							string uri = String.Format("{0}/{1}/{2}/{3}.log", y, m, d, h);
							files.Add(uri);
						}
					}
					else if (str.StartsWith("\t\t"))
					{
						d = str.Trim().Substring(0, 2);
					}
					else if (str.StartsWith("\t"))
					{
						m = str.Trim().Substring(0, 2);
					}
					else
					{
						y = str.Trim().Substring(0, 4);
					}
				}

			}
			else
			{
				response.Close();
			}
			return files.ToArray();
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
				ftp.Timeout = G.CONNECT_TIMEOUT;
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
