using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ModernSteward
{
	public class CrashReporter
	{
		private WebRequest request;
		private static string postData;
		private string URL = "http://google.com";

		public void Report(Exception ex)
		{
			try
			{
				string errorMsg = ex.Message;
				string errorStackTrace = ex.StackTrace;

				AddItem("ERRORMSG", errorMsg);
				AddItem("STACKTRACE", errorStackTrace);

				Post();
			}
			catch
			{
				//do nothing - reporting crash failed
			}
		}

		public CrashReporter()
		{
			// Create a request using a URL that can receive a post.
			request = WebRequest.Create(URL);
			// Set the Method property of the request to POST.
			request.Method = "POST";
			// Set the ContentType property of the WebRequest.
			request.ContentType = "application/x-www-form-urlencoded";
			postData = "";

		}

		/// Add an combination of key/value to post to the server
		///the identifier you'll use while retrieving the POST data
		///value of the POST for that key
		private void AddItem(string key, string value)
		{
			postData += "&amp;" + key + "=" + System.Web.HttpUtility.UrlEncode(value);
			//clean up so we make sure it doesn't start with a &amp;
			postData.TrimStart("&amp".ToArray());
		}


		private void Post()
		{
			byte[] byteArray = Encoding.UTF8.GetBytes(postData);
			request.ContentLength = byteArray.Length;
			Stream dataStream = request.GetRequestStream();
			dataStream.Write(byteArray, 0, byteArray.Length);
			dataStream.Close();
			WebResponse response = request.GetResponse();

			Console.WriteLine(((HttpWebResponse)response).StatusDescription);


			dataStream = response.GetResponseStream();
			StreamReader reader = new StreamReader(dataStream);
			string responseFromServer = reader.ReadToEnd();
			Console.WriteLine(responseFromServer);
			reader.Close();
			dataStream.Close();
			response.Close();
		}
	}
}
