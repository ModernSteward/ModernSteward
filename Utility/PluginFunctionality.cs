using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace ModernSteward
{
    public abstract class PluginFunctionality
    {
        public abstract void Trigger(SemanticValue aSemantics);

        public abstract void Initialize();

        public abstract Grammar GetGrammar();
    }
}
