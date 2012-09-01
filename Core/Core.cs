using System;
using System.Speech.Recognition;
using System.Threading;
using System.Collections.Generic;
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
                        var reporter = new CrashReporter();
                        reporter.Report(ex);
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
						plugin.TryToEmulateCommand += new EventHandler<EmulateCommandEventArgs>(TryEmulatingCommand);
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

		bool toReloadTheGrammars = false;

		protected void GrammarUpdateRequested(object sender, EventArgs e)
		{
			mRecognitionEngine.RequestRecognizerUpdate();
			mRecognitionEngine.RecognizerUpdateReached += new EventHandler<RecognizerUpdateReachedEventArgs>(RecognitionEngine_RecognizerUpdateReached);
			toReloadTheGrammars = true;
		}

		void RecognitionEngine_RecognizerUpdateReached(object sender, RecognizerUpdateReachedEventArgs e)
		{
			if(toReloadTheGrammars){
				LoadPluginsGrammar(mPluginHandler);
				toReloadTheGrammars = false;
			}
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
		
		List<EmulateCommandEventArgs> RequestsForCommandEmulation = new List<EmulateCommandEventArgs>();

		private void TryEmulatingCommand(object sender, EmulateCommandEventArgs e)
		{
			StopAsyncRecognition();
			Thread.Sleep(333);
			try
			{
				bool isAuthorised = false;

				Plugin receiver = null;
				Plugin senderPlugin = sender as Plugin;

				foreach (var plugin in mPluginHandler.Plugins)
				{
					string pathToXls = plugin.PluginGrammarTreePath;
					if (RadTreeViewGrammarManager.MatchGrammarToPlugin(pathToXls, e.Command))
					{
						receiver = plugin;
					}
				}

				if (receiver == null)
				{
					throw new NullReferenceException();
				}

				
				isAuthorised = checkPluginControlAuthorisation(senderPlugin, receiver);
				

				if (isAuthorised)
				{
					try
					{
						mRecognitionEngine.EmulateRecognizeAsync("Melissa " + e.Command);
					}
					catch (Exception ex)
					{
                        var reporter = new CrashReporter();
                        reporter.Report(ex);
					}
				}

			}
			finally
			{
				Thread.Sleep(333);
				StartAsyncRecognition();
			}

		}

		private bool checkPluginControlAuthorisation(Plugin aSender, Plugin aReceiver)
		{
			try
			{
				string senderHash = ZipManager.GetMD5FromAZip(aSender.PluginPath);
				string receiverHash = ZipManager.GetMD5FromAZip(aReceiver.PluginPath);
			}
			catch { }


			//TODO: connection to the database

			return true;
		}
	}
}
