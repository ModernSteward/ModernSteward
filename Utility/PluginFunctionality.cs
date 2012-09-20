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

		/// <summary>
		/// Initializes the plugin
		/// </summary>
		/// <returns>Bool value showing if the initialization was successfull</returns>
		public abstract bool Initialize();

		/// <summary>
		/// Deinitializes the plugin
		/// </summary>
		/// <returns>Bool value showing if the deinitialization was successfull</returns>
		public abstract bool Deinitialize();

		public abstract GrammarBuilder GetGrammarBuilder();

		public Grammar GetGrammar()
		{
			return new Grammar(GetGrammarBuilder());
		}

		public abstract event EventHandler<GrammarUpdateRequestEventArgs> RequestGrammarUpdate;

		public abstract event EventHandler<EmulateCommandEventArgs> TryToEmulateCommand;
	}
}
