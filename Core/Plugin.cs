using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Runtime.InteropServices;
using System.Reflection;
using Core;

namespace ModernSteward
{
    public class Plugin
    {
        public string Name
        {
            get;
            set;
        }

        public string Keyword
        {
            get;
            set;
        }

        private Assembly Assembly;

        public Plugin(string aName, string aKeyword, string aAssemblyPath)
        {
            Name = aName;
            Keyword = aKeyword;
            Assembly = Assembly.LoadFrom(aAssemblyPath);
        }

        public void TriggerPlugin(string aAdditionalCommands)
        {
            Type type = Assembly.GetType("ModernSteward.CustomPlugin");

            object instanceOfMyType = Activator.CreateInstance(type);

            (instanceOfMyType as PluginFunctionality).Trigger(aAdditionalCommands);
        }
    }
}
