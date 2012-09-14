using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
	public class WebPlugin
	{
		public string Name{ get; set; }
		public string PluginPath { get; set; }

		public WebPlugin(string aName, string aPath)
		{
			Name = aName;
			PluginPath = aPath;
		}
	}
}
