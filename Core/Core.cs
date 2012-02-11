using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace ModernSteward
{
    public class Core
    {
        /// <summary>
        /// Represents the recognition engine of the application
        /// </summary>
        private SpeechRecognitionEngine mRecognitionEngine;
        private PluginHandler mPluginHandler = new PluginHandler();

        /// <summary>
        /// Initializes the RecognitionEngine
        /// </summary>
        public Core()
        {
            mRecognitionEngine =  new SpeechRecognitionEngine();
            mRecognitionEngine.SetInputToDefaultAudioDevice();

            mRecognitionEngine.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(RecognitionEngine_SpeechRecognized);
        }

        void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            foreach (var plugin in mPluginHandler.Plugins)
            {
                if (e.Result.Grammar.Name == plugin.Name)
                {
                    plugin.TriggerPlugin(ModernSteward.SemanticsToDict.Convert(e.Result.Semantics));
                }
            }
            
        }

        /// <summary>
        /// Loads the grammar ONLY of the plugins from the passed PluginHandler. Grammar loaded before will be unloaded!
        /// You can only load pluggins while the recognition is not running!
        /// </summary>
        /// <param name="aPluginHandler"></param>
        /// <returns>Boolean if the loading was successfull</returns>
        public bool LoadPlugins(PluginHandler aPluginHandler)
        {
            mPluginHandler = aPluginHandler;
            try
            {
                mRecognitionEngine.UnloadAllGrammars();
                foreach (var plugin in aPluginHandler.Plugins)
                {
                    Grammar pluginGrammar = plugin.GetGrammar();
                    pluginGrammar.Name = plugin.Name;
                    mRecognitionEngine.LoadGrammar(pluginGrammar);
                }
            }
            catch
            {
                return false;
            }
            return true;
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
