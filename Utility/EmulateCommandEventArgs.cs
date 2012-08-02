using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
	public class EmulateCommandEventArgs : EventArgs
	{
		public string Command{ get; set; }
		public EmulateCommandEventArgs(string aCommand)
		{
			Command = aCommand;
		}
	}
}
