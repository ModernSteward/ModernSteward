using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Net;

namespace ModernSteward
{
	public class WebPlugin
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string LocalFilepath { get; set; }
		public string DownloadURL { get; set; }

		public WebPlugin(WebPluginPrinciple plugin)
		{
			ID = plugin.Id;
			Name = plugin.Title;
			Description = plugin.Description;
			DownloadURL = Consts.PluginDownloadURL + ID;
		}

		public WebPlugin(int aID, string aName, string aDescription)
		{
			ID = aID;
			Name = aName;
			Description = aDescription;

			DownloadURL = Consts.PluginDownloadURL + ID;
		}

		public bool Download(string destinationPath)
		{
			bool downloadedSuccessful = false;

			try
			{
				LocalFilepath = destinationPath;
				WebClient Client = new WebClient();
				Client.DownloadFile(DownloadURL, destinationPath + this.Name + ".zip");

				downloadedSuccessful = true;
			}
			catch { }

			return downloadedSuccessful;
		}
	}
}
