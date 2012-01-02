using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Speech.Recognition;
using System.Diagnostics;
using System.Xml.Serialization;
using Utility;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SpeechLib;

namespace SpeechGrammarBuilderGUI
{
    public partial class SpeechGrammarBuilderForm : RadForm
    {
        RadContextMenu nodeContextMenu = new RadContextMenu();

        public SpeechGrammarBuilderForm()
        {
            InitializeComponent();

            treeViewCommands.AllowEdit = true;
            treeViewCommands.AllowRemove = true;
            treeViewCommands.AllowAdd = true;
            treeViewCommands.AllowDefaultContextMenu = true;

            treeViewCommands.ContextMenuOpening += new TreeViewContextMenuOpeningEventHandler(treeViewCommands_ContextMenuOpening);

            radCheckBoxIsTheNodeWildcard.IsThreeState = false;
            radCheckBoxIsTheNodeWildcard.Visible = false;
            
            treeViewCommands.Nodes.Add("I would like a");
            treeViewCommands.Nodes[0].Nodes.Add("pizza");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("with some sugar");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("without some sugar");
            treeViewCommands.Nodes[0].Nodes.Add("hotdog");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("with salt");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("without some salt");
            treeViewCommands.Nodes.Add("I hate");
            treeViewCommands.Nodes[1].Nodes.Add("pizza");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("with some sugar");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("with sugar");
            treeViewCommands.Nodes.Add("open");
            treeViewCommands.Nodes[2].Nodes.Add("notepad");

            treeViewCommands.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(treeViewCommands_SelectedNodeChanged);

            treeViewCommands.ExpandAll();
        }

        void treeViewCommands_ContextMenuOpening(object s, TreeViewContextMenuOpeningEventArgs args)
        {
            foreach (var item in args.Menu.Items)
            {
                if (args.Node.Tag == Consts.Wildcard)
                {
                    //args.Menu.Items["New"].Visibility = ElementVisibility.Collapsed;
                }
                else
                {
                    args.Menu.Items["New"].Visibility = ElementVisibility.Visible;
                }
            }
        }

        void treeViewCommands_SelectedNodeChanged(object s, RadTreeViewEventArgs args)
        {
            radCheckBoxIsTheNodeWildcard.Visible = true;
            if (args.Node.Tag != null)
            {
                if (args.Node.Tag.ToString() == Consts.Wildcard)
                {
                    radCheckBoxIsTheNodeWildcard.Checked = true;
                }
            }
            else
            {
                radCheckBoxIsTheNodeWildcard.Checked = false;
            }
        }

        private void buttonStartRecognition_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();

            Grammar grammar = new Grammar(TreeViewToGrammarBuilderAlgorithm.CreateGrammarFromTree(treeViewCommands));
            MessageBox.Show(
                TreeViewToGrammarBuilderAlgorithm.CreateGrammarFromTree(treeViewCommands).DebugShowPhrases);
            recognitionEngine.LoadGrammar(grammar);

            recognitionEngine.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognitionEngine_SpeechDetected);

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
                foreach (var item in args.Result.Semantics)
                {
                    Console.WriteLine("\n\t-->Value: {0}, Key: {1}", item.Value.Value, item.Key);
                }
                if (args.Result.Text == "open notepad")
                {
                    Process notepadProcess = new Process();
                    notepadProcess.StartInfo.FileName = "notepad.exe";
                    notepadProcess.Start();
                }
            };

            recognitionEngine.SpeechRecognitionRejected += (s, args) =>
            {
                foreach(var alt in args.Result.Alternates)
                Console.WriteLine("\nREJECTED\nAlt:{0}\t conf:{1}", alt.Text, alt.Confidence);
            };

            //recognitionEngine.EmulateRecognize("I would like a banana");

            MessageBox.Show("Recognition engine started!");
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);            
        }

        void recognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.WriteLine("\n\t--{0}", e.AudioPosition.ToString());
        }


        private void buttonExportToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeViewCommands.SaveXML(saveFileDialog.FileName);
            }
        }

        private void buttonLoadTree_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    treeViewCommands.LoadXML(openFileDialog.FileName);
                    MessageBox.Show("Grammar loaded successfully");
                }
                catch {
                    MessageBox.Show("Invalid file format", "Error");
                }
            }
        }

        private void radCheckBoxIsTheNodeWildcard_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                treeViewCommands.SelectedNode.Tag = Consts.Wildcard;
            }
            else if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                treeViewCommands.SelectedNode.Tag = null;
            }
        }

        private void buttonPrintDictItems_Click(object sender, EventArgs e)
        {
            ISpeechLexiconWords splexWords;
            SpLexicon lex = new SpLexicon();
            int generationId = 0;
            splexWords = lex.GetWords(SpeechLexiconType.SLTUser, out generationId);
            foreach (ISpeechLexiconWord splexWord in splexWords)
            {
                Console.WriteLine("{0}, {1}", splexWord.Word, splexWord.LangId);   
            }
        }

        private void buttonAddWordToTheDictionary_Click(object sender, EventArgs e)
        {
            SpLexicon lex = new SpLexicon();
            lex.AddPronunciation(textBoxWordToAddToTheDictionary.Text, 1033);
        }
    }
}
