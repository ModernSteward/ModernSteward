using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Speech.Recognition;
using ModernSteward;

namespace ModernSteward
{
    public class Plugin
    {
        public string Name;

        private Assembly Assembly;

        object instanceOfMyType;

        public Plugin(string aName, string aAssemblyPath)
        {
            Name = aName;

            Assembly = Assembly.LoadFrom(aAssemblyPath);
            Type type = Assembly.GetType("ModernSteward.CustomPlugin");
            instanceOfMyType = Activator.CreateInstance(type);
        }

        public void TriggerPlugin(List<KeyValuePair<string, string>> aSemantics)
        {
            (instanceOfMyType as PluginFunctionality).Trigger(aSemantics);
        }

        public Grammar GetGrammar()
        {
            return (instanceOfMyType as PluginFunctionality).GetGrammar();
        }

        public GrammarBuilder GetGrammarBuilder()
        {
            return (instanceOfMyType as PluginFunctionality).GetGrammarBuilder();
        }

        public bool Initialize()
        {
            return (instanceOfMyType as PluginFunctionality).Initialize();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
