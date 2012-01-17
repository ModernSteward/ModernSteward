using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace ModernSteward
{
    public abstract class PluginFunctionality
    {
        public abstract void Trigger(List<KeyValuePair<string, string>> aSemantics);

        public abstract void Initialize(bool onStartup);

        public abstract GrammarBuilder GetGrammarBuilder();

        public Grammar GetGrammar()
        {
            return new Grammar(GetGrammarBuilder());
        }
    }
}
