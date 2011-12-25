using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;

namespace Utility
{
    public static class TreeViewToGrammarBuilderAlgorithm
    {
        private static GrammarBuilder MakeGrammarBuilderRecursively(TreeNode currentNode)
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
            return currentGrammar;
        }

        public static GrammarBuilder ExportGrammarBuilder(TreeView treeView)
        {
            GrammarBuilder currentGrammar = new GrammarBuilder();
            Choices wholeGrammar = new Choices();

            for (int i = 0; i < treeView.Nodes.Count; ++i)
            {
                currentGrammar = MakeGrammarBuilderRecursively(treeView.Nodes[i]);
                wholeGrammar.Add(new Choices(currentGrammar));
            }
            
            return wholeGrammar;
        }
    }
}
