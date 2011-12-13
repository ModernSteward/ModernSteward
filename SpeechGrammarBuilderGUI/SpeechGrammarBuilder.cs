using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;

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

            treeViewCommands.ContextMenu = new ContextMenu();
            treeViewCommands.ContextMenu.MenuItems.Add("Add first node", 
                lambdaEvent += (sender, args) => {
                    treeViewCommands.Nodes.Add("first node");
                    treeViewCommands.Nodes[treeViewCommands.Nodes.Count - 1].ContextMenu = nodeContextMenu;
                });

            //treeViewCommands.Nodes.Add("first node");
        }

        private void InitializeNodeContextMenu()
        {
            nodeContextMenu.MenuItems.Add("Add custom command", new EventHandler(ContextMenuAddCustomComamand_OnClick));
            nodeContextMenu.MenuItems.Add("Add custom wildcard", new EventHandler(ContextMenuAddCustomWildcard_OnClick));
            nodeContextMenu.MenuItems.Add("Add full wildcard", new EventHandler(ContextMenuAddFullWildCard_OnClick));
            nodeContextMenu.MenuItems.Add("Edit node", new EventHandler(ContextMenuEditNode_OnClick));
            nodeContextMenu.MenuItems.Add("Delede node", new EventHandler(ContextMenuDeleteNode_OnClick));
        }

        void AddNode(TreeNode aParrentNode, string aName)
        {
            aParrentNode.Nodes.Add(aName);
            aParrentNode.Nodes[aParrentNode.Nodes.Count - 1].ContextMenu = nodeContextMenu;
        }

        void ContextMenuAddCustomComamand_OnClick(object s, EventArgs args)
        {
            throw new NotImplementedException();
        }

        void ContextMenuAddCustomWildcard_OnClick(object s, EventArgs args)
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
    }
}
