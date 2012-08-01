using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;
using System.Threading;

namespace ModernSteward
{
	public class Core
	{
		/// <summary>
		/// Represents the recognition engine of the application
		/// </summary>
		private SpeechRecognitionEngine mRecognitionEngine;

		/// <summary>
		/// Stores the loaded plugins
		/// </summary>
		private PluginHandler mPluginHandler = new PluginHandler();

		public delegate void SpeechRecognizedCoreEventHandler(Plugin pluginTriggered);

		public event SpeechRecognizedCoreEventHandler SpeechRecognizedCoreEvent;

		/// <summary>
		/// Initializes the RecognitionEngine
		/// </summary>
		public Core()
		{
			mRecognitionEngine = new SpeechRecognitionEngine();
			mRecognitionEngine.SetInputToDefaultAudioDevice();

			mRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(RecognitionEngine_SpeechRecognized);
		}

		void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
		{
			foreach (var _plugin in mPluginHandler.Plugins)
			{
				var plugin = _plugin; //pretty cool hack because of the renewing variable in the foreach

				if (e.Result.Grammar.Name == plugin.Name)
				{
					SpeechRecognizedCoreEvent.Invoke(plugin);

					var semantics = ModernSteward.SemanticsToDict.Convert(e.Result.Semantics);

					try
					{
						Thread pluginThread = new Thread(delegate()
						{
							plugin.TriggerPlugin(semantics);
						});
						pluginThread.Start();
					}
					catch (Exception ex)
					{
						//System.Windows.Forms.MessageBox.Show(ex.Message);
					}
				}
			}

		}

		/// <summary>
		/// Loads the grammar ONLY of the plugins from the passed PluginHandler. Grammar loaded before will be unloaded!
		/// You can only load plugins while the recognition is not running!
		/// </summary>
		/// <param name="aPluginHandler"></param>
		/// <returns>Boolean if the loading was successful</returns>
		public bool LoadPluginsGrammar(PluginHandler aPluginHandler)
		{
			mPluginHandler = aPluginHandler;
			try
			{
				mRecognitionEngine.UnloadAllGrammars();

				foreach (var plugin in aPluginHandler.Plugins)
				{
					if (plugin.Initialized)
					{
						Grammar pluginGrammar = plugin.GetGrammar();
						pluginGrammar.Name = plugin.Name;
						mRecognitionEngine.LoadGrammar(pluginGrammar);
						plugin.RequestGrammarUpdate += new EventHandler<GrammarUpdateRequestEventArgs>(GrammarUpdateRequested);
					}
					else
					{
						mPluginHandler.Plugins.Remove(plugin);
					}
				}
			}
			catch (Exception ex)
			{
				return false;
			}
			return true;
		}

		protected void GrammarUpdateRequested(object sender, EventArgs e)
		{
			mRecognitionEngine.RequestRecognizerUpdate();
			mRecognitionEngine.RecognizerUpdateReached += new EventHandler<RecognizerUpdateReachedEventArgs>(mRecognitionEngine_RecognizerUpdateReached);
		}

		void mRecognitionEngine_RecognizerUpdateReached(object sender, RecognizerUpdateReachedEventArgs e)
		{
			LoadPluginsGrammar(mPluginHandler);
		}

		/// <summary>
		/// Starts the speech recognition engine async.
		/// </summary>
		public void StartAsyncRecognition()
		{
			mRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
		}

		/// <summary>
		/// Stops the speech recognition engine async.
		/// </summary>
		public void StopAsyncRecognition()
		{
			mRecognitionEngine.RecognizeAsyncStop();
		}
	}
}
