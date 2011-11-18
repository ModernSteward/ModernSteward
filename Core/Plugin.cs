using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;

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

        public string Command
        {
            get;
            set;
        }

        Plugin(string aName, string aKeyword, string aCommand)
        {
            Name = aName;
            Keyword = aKeyword;
            Command = aCommand;
        }

        public void TriggerPlugin(string aAdditionalCommands)
        {
            Console.WriteLine("Command{0}\nAdditionalCommands{1}\n", Command, aAdditionalCommands);
        }
    }
}
