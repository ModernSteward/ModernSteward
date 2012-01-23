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
using ModernSteward;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using SpeechLib;
using System.IO.Ports;

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

            radCheckBoxIsTheNodeDictation.IsThreeState = false;
            radCheckBoxIsTheNodeDictation.Visible = false;
            
            treeViewCommands.Nodes.Add("Turn the lights");
            treeViewCommands.Nodes[0].Nodes.Add("on");
            treeViewCommands.Nodes[0].Nodes.Add("off");

            treeViewCommands.SelectedNodeChanged += new RadTreeView.RadTreeViewEventHandler(treeViewCommands_SelectedNodeChanged);

            treeViewCommands.ExpandAll();
        }

        void treeViewCommands_ContextMenuOpening(object s, TreeViewContextMenuOpeningEventArgs args)
        {
            foreach (var item in args.Menu.Items)
            {
                if (args.Node.Tag == Consts.Dictation)
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
            radCheckBoxIsTheNodeDictation.Visible = true;
            if (args.Node.Tag != null)
            {
                if (args.Node.Tag.ToString() == Consts.Dictation)
                {
                    radCheckBoxIsTheNodeDictation.Checked = true;
                }
            }
            else
            {
                radCheckBoxIsTheNodeDictation.Checked = false;
            }
        }

        private void buttonStartRecognition_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();

            Grammar grammar = new Grammar(TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromTree(treeViewCommands));
            MessageBox.Show(
                TreeViewToGrammarBuilderAlgorithm.CreateGrammarBuilderFromTree(treeViewCommands).DebugShowPhrases);
            recognitionEngine.LoadGrammar(grammar);

            recognitionEngine.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognitionEngine_SpeechDetected);
            /*
            SerialPort port;

            port = new SerialPort("COM4");

            port.BaudRate = 4800;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            port.Parity = Parity.None;

            port.Open();
             */

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
                foreach (var item in args.Result.Semantics)
                {
                    Console.WriteLine("\n\t-->Value: {0}, Key: {1}", item.Value.Value, item.Key);
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
                GrammarManager.SaveGrammarToXML(treeViewCommands, saveFileDialog.FileName);
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
                    treeViewCommands = GrammarManager.LoadGrammarFromXML(openFileDialog.FileName);
                    MessageBox.Show("Grammar loaded successfully");
                }
                catch {
                    MessageBox.Show("Invalid file format", "Error");
                }
            }
        }

        private void radCheckBoxIsTheNodeDictation_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                treeViewCommands.SelectedNode.Tag = Consts.Dictation;
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




        private void buttonShowTheTreeInPlainText_Click(object sender, EventArgs e)
        {
            foreach (var node in treeViewCommands.Nodes)
            {
                closedBrackets = 0;
                openedBrackets = 0;
                Recursion(node, 0);
                while (closedBrackets < openedBrackets)
                {
                    ShiftNTabsInTheConsole((openedBrackets - closedBrackets) - 1);
                    Console.WriteLine("}");
                    closedBrackets++;
                }
            }
        }


        int openedBrackets = 0;
        int closedBrackets = 0;

        void ShiftNTabsInTheConsole(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("\t");
            }
        }

        const string semanticsInString = "aSemantics";
        private void Recursion(RadTreeNode node, int level)
        {
            ShiftNTabsInTheConsole(level);
            Console.Write("if({0}[{1}].Key == \"{2}\")", semanticsInString, level, node.Text); Console.WriteLine("{");
            openedBrackets++;

            if (node.Nodes.Count == 0)
            {
                if (node.Tag != null)
                {
                    if (node.Tag.ToString() == Consts.Dictation)
                    {
                        ShiftNTabsInTheConsole(level + 1);
                        string dictationFor = node.Text.Replace(" ", "");
                        Console.WriteLine("string dictationFor{0} = {1}[{2}].Value;", dictationFor, semanticsInString, level);

                    }
                    else
                    {
                        Console.WriteLine("\n");
                    }
                }
                else
                {
                    Console.WriteLine("\n");
                }

                ShiftNTabsInTheConsole(level);
                Console.WriteLine("}");
                closedBrackets++;
            }

            foreach (var childNode in node.Nodes)
            {
                Recursion(childNode, level+1);
            }
        }

        private void buttonMakeSolution_Click(object sender, EventArgs e)
        {

        }
    }
}
