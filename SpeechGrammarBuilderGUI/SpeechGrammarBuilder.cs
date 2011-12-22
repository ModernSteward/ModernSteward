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


            treeViewCommands.Nodes.Add("first node");
            treeViewCommands.Nodes[0].Nodes.Add("1.1");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("1.1.1");
            treeViewCommands.Nodes[0].Nodes[0].Nodes.Add("1.1.2");
            treeViewCommands.Nodes[0].Nodes.Add("1.2");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("1.2.1");
            treeViewCommands.Nodes[0].Nodes[1].Nodes.Add("1.2.2");
            treeViewCommands.Nodes.Add("second node");
            treeViewCommands.Nodes[1].Nodes.Add("2.1");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("2.1.1");
            treeViewCommands.Nodes[1].Nodes[0].Nodes.Add("2.1.2");

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

            for (int i = 0; i < currentNode.Nodes.Count; ++i)
            {
                tempGrammar.Add(MakeGrammarBuilderRecursively(currentNode.Nodes[i]));
            }
            currentGrammar.Append(tempGrammar);
            Console.WriteLine(currentNode.Text);
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

            return wholeGrammar.ToGrammarBuilder();
        }

        private void buttonWriteInConsoleTheTree_Click(object sender, EventArgs e)
        {
            GrammarBuilder wholeGrammar = ExportGrammarBuilder(treeViewCommands);

            MessageBox.Show(wholeGrammar.DebugShowPhrases);
            Console.WriteLine("{0}", wholeGrammar.DebugShowPhrases);
        }
    }
}
