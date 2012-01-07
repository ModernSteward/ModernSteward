using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModernSteward;
using System.Speech.Recognition;

namespace ModernSteward
{
    public class PluginHandler
    {
        public List<Plugin> Plugins = new List<Plugin>();

        public bool FindPluginAndTrigger(string aKeyword, SemanticValue aSemantics)
        {
            bool found = false;
            foreach(var plugin in Plugins){
                if (plugin.Keyword == aKeyword)
                {
                    TriggerEvent(plugin, aSemantics);
                    found = true;
                    break;
                }
            }
            return found;
        }

        private void TriggerEvent(Plugin aPlugin, SemanticValue aSemantics)
        {
            aPlugin.TriggerPlugin(aSemantics);
        }
    }
}
