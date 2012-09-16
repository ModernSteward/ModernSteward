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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ModernSteward
{
	[Serializable]
	public class Plugin
	{
		[NonSerialized]
		public int ID;

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

		public Macro Macros;

		public PluginType Type;

		public Plugin() { }

		public Plugin(string aName, string aPluginPath, int aID = -1)
		{
			Name = aName;
			PluginPath = aPluginPath;

			ID = aID;

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

			PluginGrammarTreePath = innerPluginDirectoryPath + @"CustomPluginGrammar.xml";

			if (File.Exists(innerPluginDirectoryPath + @"CustomPlugin.dll")) //Standart plugin
			{

				mAssembly = Assembly.LoadFile(innerPluginDirectoryPath + @"CustomPlugin.dll");
				
				AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
				Type type = mAssembly.GetType("ModernSteward.CustomPlugin");
				instanceOfMyType = Activator.CreateInstance(type);

				(instanceOfMyType as PluginFunctionality).RequestGrammarUpdate +=
					new EventHandler<GrammarUpdateRequestEventArgs>(GrammarUpdateRequestHandler);

				(instanceOfMyType as PluginFunctionality).TryToEmulateCommand +=
					new EventHandler<EmulateCommandEventArgs>(TryToEmulateCommandHandler);

				Type = PluginType.StandartPlugin;
			}

			else //Macro plugin
			{
				Stream stream = null;
				try
				{
					IFormatter formatter = new BinaryFormatter();
					stream = new FileStream(innerPluginDirectoryPath + "macro.mr", FileMode.Open, FileAccess.Read, FileShare.None);
					stream.Position = 0;
					Macros = (Macro)formatter.Deserialize(stream);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (null != stream)
						stream.Close();
				}

				Type = PluginType.MacroPlugin;
			}
		}

		Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
		{
			foreach (var file in Directory.GetFiles(innerPluginDirectoryPath))
			{
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
			if (Type == PluginType.StandartPlugin)
			{
				(instanceOfMyType as PluginFunctionality).Trigger(aSemantics);
			}
			else //Macro plugin
			{
				Macros.Execute();
			}
		}

		public Grammar GetGrammar()
		{
			if (Type == PluginType.StandartPlugin)
			{
				return (instanceOfMyType as PluginFunctionality).GetGrammar();
			}
			else
			{ // Macro plugin
				return new Grammar(TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(PluginGrammarTreePath));
			}
		}

		public GrammarBuilder GetGrammarBuilder()
		{
			if (Type == PluginType.StandartPlugin)
			{
				return (instanceOfMyType as PluginFunctionality).GetGrammarBuilder();
			}
			else // Macro plugin
			{
				return TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromXML(PluginGrammarTreePath);
			}
		}

		public bool Initialize()
		{
			if (Type == PluginType.StandartPlugin)
			{
				Initialized = (instanceOfMyType as PluginFunctionality).Initialize();
				return Initialized;
			}
			else // Macro plugin
			{
				Initialized = true;
				return Initialized;
			}
		}

		public override string ToString()
		{
			return Name;
		}

		private void GrammarUpdateRequestHandler(object s, GrammarUpdateRequestEventArgs e)
		{
			if (Type == PluginType.StandartPlugin)
			{
				RequestGrammarUpdate.Invoke(s, e);
			}
		}

		public event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;

		~Plugin()
		{
		}

		public void TryToEmulateCommandHandler(object s, EmulateCommandEventArgs e)
		{
			if (Type == PluginType.StandartPlugin)
			{
				TryToEmulateCommand.Invoke(this, e);
			}
		}
	}
}
