using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using Core;
using Utility;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        public override void Trigger(string aArguments)
        {
            Console.WriteLine("{0}\n", aArguments);
        }

        public override Grammar GetGrammar()
        {
            return new Grammar(TreeViewToGrammarBuilderAlgorithm.CreateGrammarFromXML(Environment.CurrentDirectory + @"\TestGrammarWithSearchEngine.xml"));
        }
    }
}
