using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
	public class EmulateCommandEventArgs : EventArgs
	{
		public string Command{ get; set; }
		public Plugin Sender { get; set; }
		public EmulateCommandEventArgs(Plugin aSender, string aCommand)
		{
			Sender = aSender;
			Command = aCommand;
		}
	}
}
