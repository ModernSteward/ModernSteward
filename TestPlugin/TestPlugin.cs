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
        public override void Trigger(SemanticValue aSemantics)
        {
            
        }

        public override Grammar GetGrammar()
        {
            return new Grammar(TreeViewToGrammarBuilderAlgorithm.CreateGrammarFromXML(Environment.CurrentDirectory + @"\TestGrammarWithSearchEngine.xml"));
        }

        public override void Initialize()
        {
            
        }
    }
}
