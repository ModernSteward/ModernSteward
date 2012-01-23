using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModernSteward;
using System.Speech.Recognition;
using PluginWizard;

namespace ModernSteward
{
    public partial class AddPluginTestForm : Form
    {
        PluginHandler pluginHandler = new PluginHandler();

        public AddPluginTestForm()
        {
            InitializeComponent();
        } 

        private void buttonAddPlugin_Click(object sender, EventArgs e)
        {
            pluginHandler.Plugins.Add(new Plugin(textBoxName.Text, textBoxKeyword.Text, textBoxPluginPath.Text));
            textBoxName.Text = "";
            textBoxKeyword.Text = "";
            MessageBox.Show("Plugin loaded");
        }


        private void buttonBrowseForPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "dll files (*.dll)|*.dll|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPluginPath.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }

        private void buttonStartTheEngine_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();

            try
            {
                Choices pluginsGrammarInChoices = new Choices();
                foreach (var plugin in pluginHandler.Plugins)
                {
                    pluginsGrammarInChoices.Add(plugin.GetGrammarBuilder());
                }
                GrammarBuilder grammarBuilder = new GrammarBuilder();
                grammarBuilder.Append(Consts.NameOfTheGirl);
                grammarBuilder.Append(pluginsGrammarInChoices);

                MessageBox.Show(grammarBuilder.DebugShowPhrases);

                recognitionEngine.LoadGrammar(new Grammar(grammarBuilder));
            }

            catch
            {
                MessageBox.Show("Plugin not loaded or grammar is really fucked...");
            }

            recognitionEngine.SpeechRecognized += (send, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
                foreach (var item in args.Result.Semantics)
                {
                    Console.WriteLine("\n\t-->Value: {0}, Key: {1}", item.Value.Value, item.Key);
                }

                List<KeyValuePair<string, string>> semanticsToDict = new List<KeyValuePair<string, string>>();
                foreach (var s in args.Result.Semantics)
                {
                    semanticsToDict.Add(new KeyValuePair<string, string>(s.Key.ToString(), s.Value.Value.ToString()));
                }
                foreach (var plugin in pluginHandler.Plugins)
                {
                    Console.WriteLine("SemanticsToDict.Key = {0}; plugin.Keyword = {1}", semanticsToDict[0].Key, plugin.Keyword);
                    plugin.TriggerPlugin(semanticsToDict);
                }
            };

            recognitionEngine.SpeechRecognitionRejected += (s, args) =>
            {
                foreach (var alt in args.Result.Alternates)
                    Console.WriteLine("\nREJECTED\nAlt:{0}\t conf:{1}", alt.Text, alt.Confidence);
            };

            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple); 
        }

        private void buttonPluginWizard_Click(object sender, EventArgs e)
        {
            PluginWizardForm pluginWizardForm = new PluginWizardForm();
            pluginWizardForm.Show();
        }
    }
}
