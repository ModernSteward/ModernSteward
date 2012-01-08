using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModernSteward;
using ModernSteward;
using System.Speech.Recognition;

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
                Grammar grammar = pluginHandler.Plugins[0].GetGrammar();
                recognitionEngine.LoadGrammar(grammar);
            }

            catch
            {
                MessageBox.Show("Plugin not loaded or grammar is really fucked...");
            }

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
                foreach (var item in args.Result.Semantics)
                {
                    Console.WriteLine("\n\t-->Value: {0}, Key: {1}", item.Value.Value, item.Key);
                }
                pluginHandler.Plugins[0].TriggerPlugin(args.Result.Semantics);
            };

            recognitionEngine.SpeechRecognitionRejected += (s, args) =>
            {
                foreach (var alt in args.Result.Alternates)
                    Console.WriteLine("\nREJECTED\nAlt:{0}\t conf:{1}", alt.Text, alt.Confidence);
            };

            MessageBox.Show("Recognition engine started!");
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple); 
        }
    }
}
