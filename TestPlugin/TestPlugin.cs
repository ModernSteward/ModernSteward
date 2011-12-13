using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using Core;

namespace ModernSteward
{
    public class CustomPlugin : PluginFunctionality
    {
        public override void Trigger(string aArguments)
        {
            Console.WriteLine("{0}\n", aArguments);
        }

        public override Grammar GetLevelGrammar(int level)
        {
            throw new NotImplementedException();
        }
    }
}
