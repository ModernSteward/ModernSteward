using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ModernSteward
{
	public static class CrashReporter
	{
		public static string server = "http://www.modernsteward.com";

		public static void Report(Exception ex)
		{
			try
			{
				string postData = string.Format("error={0}&stacktrace={1}", ex.Message, ex.StackTrace);
				Post(postData);
			}
			catch
			{
				//do nothing - reporting crash failed
			}
		}

		private static void Post(string text)
		{
			string uri = server + "/crashreporter";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.Method = "POST";
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;

			byte[] postBytes = Encoding.ASCII.GetBytes(text);
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = postBytes.Length;

			Stream requestStream = request.GetRequestStream();
			requestStream.Write(postBytes, 0, postBytes.Length);
			requestStream.Close();
		}

	}
}
