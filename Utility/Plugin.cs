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
using System.IO;
using Telerik.WinControls.UI;

namespace ModernSteward
{
	[Serializable]
	public class Plugin
	{
		public string Name;

		public string PluginPath;

		private Assembly mAssembly;

		[NonSerialized]
		private object instanceOfMyType;

		[NonSerialized]
		public bool Initialized = false;

		[NonSerialized]
		private string innerPluginDirectoryPath;

		public string PluginGrammarTreePath;

		public Plugin() { }

		public Plugin(string aName, string aPluginPath)
		{
			Name = aName;
			PluginPath = aPluginPath;

			LoadPlugin();
		}

		/// <summary>
		/// Must be used only after deserialization or in the constructor of the class!!!
		/// </summary>
		public void LoadPlugin()
		{
			string masterPluginZip = PluginPath;
			Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins");
			Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins\" + Name);
			innerPluginDirectoryPath = Environment.CurrentDirectory + @"\Plugins\" + Name + @"\";

			ZipManager.Extract(masterPluginZip, innerPluginDirectoryPath);

			mAssembly = Assembly.LoadFile(innerPluginDirectoryPath + @"CustomPlugin.dll");
			PluginGrammarTreePath = innerPluginDirectoryPath + @"CustomPluginGrammar.xml";

			AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
			Type type = mAssembly.GetType("ModernSteward.CustomPlugin");
			instanceOfMyType = Activator.CreateInstance(type);
			
		}

		Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			foreach(var file in Directory.GetFiles(innerPluginDirectoryPath)){
				try
				{
					if (AssemblyName.GetAssemblyName(file).FullName == args.Name)
					{
						return Assembly.LoadFile(file);
					}
				}
				catch { }
			}
			return null;
		}

		public void TriggerPlugin(List<KeyValuePair<string, string>> aSemantics)
		{
			(instanceOfMyType as PluginFunctionality).Trigger(aSemantics);
		}

		public Grammar GetGrammar()
		{
			//System.Windows.Forms.MessageBox.Show((instanceOfMyType as PluginFunctionality).GetGrammarBuilder().DebugShowPhrases);
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

		~Plugin()
		{
		}
	}
}
