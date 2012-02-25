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
	[Serializable]
    public class Plugin
    {
        public string Name;

		public string AssemblyPath;

        private Assembly Assembly;

		[NonSerialized]
        private object instanceOfMyType;
		[NonSerialized]
		public bool Initialized = false;
	

		public Plugin() { }

        public Plugin(string aName, string aAssemblyPath)
        {
            Name = aName;
			AssemblyPath = aAssemblyPath;

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
			Initialized = (instanceOfMyType as PluginFunctionality).Initialize();
            return Initialized;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
