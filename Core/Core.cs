using System;
using System.Speech.Recognition;
using System.Threading;
using System.Collections.Generic;
using WebControl;
using System.Threading.Tasks;
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

		private OperatingMode Mode = OperatingMode.OfflineAdvanced;

		private WebControlManager webControlManager;

		/// <summary>
		/// Initializes the RecognitionEngine
		/// </summary>
		public Core(OperatingMode aMode)
		{
			Initialization();

			Mode = aMode;
		}

		public Core(OperatingMode aMode, string aEmail, string aPassword)
		{
			Initialization();
			
			Mode = aMode;
			Email = aEmail;
			Password = aPassword;
		}

		CancellationTokenSource webControlCancelationSorce;
		CancellationToken webControlCancelation;

		void StopWebInterfaceCommandSeeking()
		{
			webControlCancelationSorce.Cancel();
		}

		void StartWebInterfaceCommandsSeeking()
		{
			webControlCancelationSorce = new CancellationTokenSource();
			webControlCancelation = webControlCancelationSorce.Token;

			var webCommandsSeeking = new Task(() => SeekForCommandsInTheWebInterface(), webControlCancelation);
			webCommandsSeeking.Start();
		}

		void SeekForCommandsInTheWebInterface()
		{
			while (true)
			{
				if (webControlCancelation.IsCancellationRequested)
				{
					return;
				}
				else
				{
					var commands = webControlManager.SeekForCommands();
					foreach (var command in commands)
					{
						TryEmulatingCommand(command.PluginID, new EmulateCommandEventArgs(command.Text));
					}
				}
				Thread.Sleep(Consts.CommandRequestsThreadSleep);
			}
		}

		void Initialization()
		{
			mRecognitionEngine = new SpeechRecognitionEngine();
			mRecognitionEngine.SetInputToDefaultAudioDevice();

			mRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(RecognitionEngine_SpeechRecognized);
			mRecognitionEngine.EmulateRecognizeCompleted += new EventHandler<EmulateRecognizeCompletedEventArgs>(mRecognitionEngine_EmulateRecognizeCompleted);
			mRecognitionEngine.RecognizeCompleted += new EventHandler<RecognizeCompletedEventArgs>(mRecognitionEngine_RecognizeCompleted);
		}

		void mRecognitionEngine_EmulateRecognizeCompleted(object sender, EmulateRecognizeCompletedEventArgs e)
		{
			StartAsyncRecognition();
		}

		void mRecognitionEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
		{
			if (commandToEmulate != "")
			{
				mRecognitionEngine.EmulateRecognizeAsync(commandToEmulate);
				commandToEmulate = "";
			}
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
						CrashReporter.Report(ex);
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
						//mPluginHandler.Plugins.Remove(plugin);
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
			if (toReloadTheGrammars)
			{
				LoadPluginsGrammar(mPluginHandler);
				toReloadTheGrammars = false;
			}
		}

		private void StartAsyncRecognition()
		{
			mRecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
		}

		/// <summary>
		/// Starts the speech recognition engine async and start seeking for web commands.
		/// </summary>
		public void StartAsyncRecognitionAndWebControl()
		{
			StartAsyncRecognition();

            if (Mode == OperatingMode.OnlineNormal || Mode == OperatingMode.OnlineAdvanced)
            {
                webControlManager = new WebControlManager("yanchev.lyubomir@gmail.com", "test");
                webControlManager.Login();

                StartWebInterfaceCommandsSeeking();
            }
		}

		private void StopAsyncRecognition()
		{
			mRecognitionEngine.RecognizeAsyncCancel();
			mRecognitionEngine.RecognizeAsyncStop();
		}

		/// <summary>
		/// Stops the speech recognition engine async and stops seeking for web commands.
		/// </summary>
		public void StopAsyncRecognitionAndWebControl()
		{
			StopAsyncRecognition();
            if (Mode == OperatingMode.OnlineAdvanced && Mode == OperatingMode.OnlineNormal)
            {
                StopWebInterfaceCommandSeeking();
            }
		}

		private string Email;
		private string Password;

		private void TryEmulatingCommand(object sender, EmulateCommandEventArgs e)
		{
			
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
					//throw new NullReferenceException();
				}

				if (Mode == OperatingMode.OnlineNormal)
				{
					isAuthorised = checkPluginControlAuthorisation(senderPlugin, receiver);
				}
				else
				{
					isAuthorised = true;
				}

				if (isAuthorised)
				{
					try
					{
						commandToEmulate = "Melissa " + e.Command;
						StopAsyncRecognition();
					}
					catch (Exception ex)
					{
						CrashReporter.Report(ex);
					}
				}
			}
			finally
			{
				//
			}
		}

		private bool checkPluginControlAuthorisation(Plugin aSender, Plugin aReceiver)
		{
			try
			{
				return webControlManager.CheckPermission(aSender.ID, aReceiver.ID);
			}
			catch
			{
				return false; 
			}
		}

		public string commandToEmulate = "";
	}
}
