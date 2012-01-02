using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace Core
{
    public abstract class PluginFunctionality
    {
        public abstract void Trigger(string aArguments);

        public abstract Grammar GetGrammar();
    }
}
