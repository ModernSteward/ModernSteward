using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using ModernSteward;
using Newtonsoft.Json;

namespace WebControl
{
	public class WebControlManager
	{
		//плъгин се сваля от /plugin/download/id

		private static string server = Consts.ServerURL;

		public string Email;
		public string Password;

		private CookieContainer cookies;
		public WebControlManager()
		{
		}

		public WebControlManager(string email, string password)
		{
			Email = email;
			Password = password;
		}

		public bool Login()
		{

			Logout();
			string post_data = string.Format("email={0}&password={1}", Email, Password);
			string uri = server + "/auth/page/email/login";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.Method = "POST";
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;

			byte[] postBytes = Encoding.ASCII.GetBytes(post_data);
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = postBytes.Length;

			Stream requestStream = request.GetRequestStream();
			requestStream.Write(postBytes, 0, postBytes.Length);
			requestStream.Close();

			try
			{
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			}
			catch {
				return false;
			}

			return true;
		}

		public void Logout()
		{
			cookies = new CookieContainer();
		}

		public List<ButtonClick> GetCommands()
		{
			string uri = server + "/web-interface/list";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;
			request.Timeout = 5000;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<List<ButtonClick>>(result);
		}

		public void Accumulate()
		{
			string uri = server + "/web-interface/accumulate";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			new StreamReader(response.GetResponseStream()).ReadToEnd();
		}

		public List<WebPluginPrinciple> GetPluginsList()
		{
			string uri = server + "/plugin/get-list";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
			return JsonConvert.DeserializeObject<List<WebPluginPrinciple>>(result);
		}

		public List<WebPlugin> GetInstalled()
		{
			string uri = server + "/plugin/get-installed";

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
			List<int> pluginIds = JsonConvert.DeserializeObject<List<int>>(result);

			List<WebPluginPrinciple> all = GetPluginsList();

			List<WebPlugin> allPlugins = new List<WebPlugin>();

			foreach (var plugin in all.Where(x =>{return pluginIds.Contains(x.Id);}).ToList())
			{
				allPlugins.Add(new WebPlugin(plugin));
			}

			return allPlugins;
		}

		public bool CheckPermission(int senderID, int receiverID)
		{
			string uri = server + "/plugin//has-permission/" + senderID + "/" + receiverID;

			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
			request.KeepAlive = false;
			request.ProtocolVersion = HttpVersion.Version11;
			request.AllowWriteStreamBuffering = true;
			request.AllowAutoRedirect = true;
			request.CookieContainer = cookies;

			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			string result = new StreamReader(response.GetResponseStream()).ReadToEnd();

			if (result == "true")
			{
				return true;
			}
			return false;
		}

		public delegate void EmulateCommand(string command);

		public List<WebControl.ButtonClick> SeekForCommands()
		{
			var commands = GetCommands();
			Accumulate();
			return commands;
		}
	}
}
