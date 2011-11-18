using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModernSteward
{
    public class PluginHandler
    {
        public List<Plugin> Plugins = new List<Plugin>();

        public bool FindPluginAndTrigger(string aKeyword, string aAdditionalCommands)
        {
            bool found = false;
            foreach(var plugin in Plugins){
                if (plugin.Keyword == aKeyword)
                {
                    TriggerEvent(plugin, aAdditionalCommands);
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void TriggerEvent(Plugin aPlugin, string aAdditionalCommands)
        {
            aPlugin.TriggerPlugin(aAdditionalCommands);
        }
    }
}
