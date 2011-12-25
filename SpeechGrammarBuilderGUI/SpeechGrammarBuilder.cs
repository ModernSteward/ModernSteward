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

namespace SpeechGrammarBuilderGUI
{
    public partial class SpeechGrammarBuilderForm : Form
    {
        ContextMenu nodeContextMenu = new ContextMenu();

        EventHandler lambdaEvent;

        public SpeechGrammarBuilderForm()
        {
            InitializeComponent();

            InitializeNodeContextMenu();

            treeViewCommands.LabelEdit = true;

            treeViewCommands.ContextMenu = new ContextMenu();
            treeViewCommands.ContextMenu.MenuItems.Add("Add first node", 
                lambdaEvent += (sender, args) => {
                    treeViewCommands.Nodes.Add("first node");
                    treeViewCommands.Nodes[treeViewCommands.Nodes.Count - 1].ContextMenu = nodeContextMenu;
                });

            

            //MessageBox.Show(ExportGrammarBuilder().DebugShowPhrases);

            /*
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
            */

            treeViewCommands.ExpandAll();
        }

        private void InitializeNodeContextMenu()
        {            
            nodeContextMenu.MenuItems.Add("Add custom command", new EventHandler(ContextMenuAddCustomComamand_OnClick));
            nodeContextMenu.MenuItems.Add("Add full wildcard", new EventHandler(ContextMenuAddWildcard_OnClick));
            nodeContextMenu.MenuItems.Add("Delede node", new EventHandler(ContextMenuDeleteNode_OnClick));
        }

        void AddNode(TreeNode aParrentNode, string aName)
        {
            treeViewCommands.BeginUpdate();
            aParrentNode.Nodes.Add(aName);
            aParrentNode.Nodes[aParrentNode.Nodes.Count - 1].ContextMenu = nodeContextMenu;
            treeViewCommands.EndUpdate();
        }

        void ContextMenuAddCustomComamand_OnClick(object s, EventArgs args)
        {
            AddNode(treeViewCommands.SelectedNode, "CustomCommand");
        }

        void ContextMenuAddWildcard_OnClick(object s, EventArgs args)
        {
            AddNode(treeViewCommands.SelectedNode, "WILDCARD");
        }

        void ContextMenuDeleteNode_OnClick(object s, EventArgs args)
        {
            treeViewCommands.SelectedNode.Remove();
        }

        private void buttonStartRecognition_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();
            MessageBox.Show("Recognition engine started!");

            Grammar grammar = new Grammar(TreeViewToGrammarBuilderAlgorithm.ExportGrammarBuilder(treeViewCommands));
            recognitionEngine.LoadGrammar(grammar);

            recognitionEngine.SpeechDetected += new EventHandler<SpeechDetectedEventArgs>(recognitionEngine_SpeechDetected);

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
                if (args.Result.Text == "Computer open notepad")
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

            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }

        void recognitionEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            Console.WriteLine("\n\t--{0}", e.AudioPosition.ToString());
        }

        private void buttonExportToXML_Click(object sender, EventArgs e)
        {
            jhTreeViewTools.LoadAndSave.saveTree(treeViewCommands,
                System.Environment.CurrentDirectory + "tryingToSerializeATree.xml");
        }

        private void buttonLoadTree_Click(object sender, EventArgs e)
        {
            jhTreeViewTools.LoadAndSave.loadTree(treeViewCommands, 
                System.Environment.CurrentDirectory + "tryingToSerializeATree.xml");

            SetContextMenuToAllNodesRecursive(treeViewCommands);
        }

        #region Recursion to set the contextmenu of all the nodes
        private void TreeViewGoRecursive(TreeNode treeNode)
        {
            treeNode.ContextMenu = nodeContextMenu;
            foreach (TreeNode tn in treeNode.Nodes)
            {
                TreeViewGoRecursive(tn);
            }
        }

        private void SetContextMenuToAllNodesRecursive(TreeView treeView)
        {
            TreeNodeCollection nodes = treeView.Nodes;
            foreach (TreeNode n in nodes)
            {
                TreeViewGoRecursive(n);
            }
        }
        #endregion
    }
}
