using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using ModernSteward;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        public override void Trigger(List<KeyValuePair<string, string>> aSemantics)
        {
        }
		
        public override GrammarBuilder GetGrammarBuilder()
        {
			return TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(Environment.CurrentDirectory + @"\TestGrammarWithSearchEngine.xml");
        }

        public override bool Initialize()
        {
			TryToEmulateCommand(this, new EmulateCommandEventArgs("test"));
            return true;
        }

		public override bool Deinitialize()
		{
			return true;
		}

		public override event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public override event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
    }
}
