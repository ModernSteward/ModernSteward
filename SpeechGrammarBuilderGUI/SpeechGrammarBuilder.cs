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


            treeViewCommands.Nodes.Add("I would like a");
            treeViewCommands.Nodes[0].Nodes.Add("pizza");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("with peperoni");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("without peperoni");
            treeViewCommands.Nodes[0].Nodes.Add("hotdog");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("with peperoni");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("without peperoni");
            treeViewCommands.Nodes.Add("I hate");
            treeViewCommands.Nodes[1].Nodes.Add("pizza");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("with peperoni");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("with salt");

            treeViewCommands.ExpandAll();

        }

        private void InitializeNodeContextMenu()
        {            
            nodeContextMenu.MenuItems.Add("Add custom command", new EventHandler(ContextMenuAddCustomComamand_OnClick));
            nodeContextMenu.MenuItems.Add("Add custom choises", new EventHandler(ContextMenuAddCustomChoises_OnClick));
            nodeContextMenu.MenuItems.Add("Add full wildcard", new EventHandler(ContextMenuAddFullWildCard_OnClick));
            nodeContextMenu.MenuItems.Add("Edit node", new EventHandler(ContextMenuEditNode_OnClick));
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

        void ContextMenuAddCustomChoises_OnClick(object s, EventArgs args)
        {
            throw new NotImplementedException();
        }

        void ContextMenuAddFullWildCard_OnClick(object s, EventArgs args)
        {
            throw new NotImplementedException();
        }

        void ContextMenuEditNode_OnClick(object s, EventArgs args)
        {
            throw new NotImplementedException();
        }

        void ContextMenuDeleteNode_OnClick(object s, EventArgs args)
        {
            throw new NotImplementedException();
        }

        private GrammarBuilder MakeGrammarBuilderRecursively(TreeNode currentNode)
        {
            GrammarBuilder currentGrammar;
            if (currentNode.Text != "WILDCARD")
            {
                currentGrammar = new GrammarBuilder(currentNode.Text);
            }
            else
            {
                currentGrammar = new GrammarBuilder();
                currentGrammar.AppendWildcard();
            }
            Choices tempGrammar = new Choices();

            for (int i = 0; i < currentNode.Nodes.Count; i++)
            {
                tempGrammar.Add(MakeGrammarBuilderRecursively(currentNode.Nodes[i]));
            }
            if (tempGrammar.ToGrammarBuilder().DebugShowPhrases != "[]")
            {
                currentGrammar.Append(tempGrammar);
            }
            //Console.WriteLine(currentNode.Text);
            return currentGrammar;
        }

        public GrammarBuilder ExportGrammarBuilder(TreeView treeView)
        {
            GrammarBuilder currentGrammar = new GrammarBuilder();
            Choices wholeGrammar = new Choices();
            
            for (int i = 0; i < treeViewCommands.Nodes.Count; ++i)
            {
                currentGrammar = MakeGrammarBuilderRecursively(treeViewCommands.Nodes[i]);
                wholeGrammar.Add(new Choices(currentGrammar));
            }

            GrammarBuilder returnGrammar = new GrammarBuilder("Computer");
            returnGrammar.Append(wholeGrammar);
            Console.WriteLine("{0}", returnGrammar.DebugShowPhrases);
            return returnGrammar;
        }

        private void buttonWriteInConsoleTheTree_Click(object sender, EventArgs e)
        {
            GrammarBuilder wholeGrammar = ExportGrammarBuilder(treeViewCommands);

            MessageBox.Show(wholeGrammar.DebugShowPhrases);
        }

        private void buttonStartRecognition_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine recognitionEngine = new SpeechRecognitionEngine();
            recognitionEngine.SetInputToDefaultAudioDevice();
            MessageBox.Show(ExportGrammarBuilder(treeViewCommands).DebugShowPhrases);

            Grammar grammar = new Grammar(ExportGrammarBuilder(treeViewCommands));
            grammar.Enabled = true;
            recognitionEngine.LoadGrammar(grammar);

            recognitionEngine.SpeechRecognized += (s, args) =>
            {
                Console.WriteLine("\n\t--{0}", args.Result.Text);
            };
            recognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
        }
    }
}
