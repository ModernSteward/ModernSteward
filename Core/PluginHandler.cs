using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;
using System.Runtime.Serialization;

namespace ModernSteward
{
	[Serializable()]
    public class PluginHandler
    {
        public List<Plugin> Plugins = new List<Plugin>();
    }
}
