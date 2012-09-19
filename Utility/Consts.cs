using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
    public static class Consts
    {
        public const string Dictation = "dictation";
        public const string NameOfTheGirl = "Melissa";

		
		public const string PluginDownloadURL = ServerURL + @"/plugin/download/";

		public const string ServerURL = "http://78.90.135.20:3000";
										//"http://www.modernsteward.com";

		public static int CommandRequestsThreadSleep = 5000; //ms
	}
}
