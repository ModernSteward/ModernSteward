using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition;
using Telerik.WinControls.UI;
using System.IO;

namespace ModernSteward
{
    public static class TreeViewToGrammarBuilderAlgorithm
    {
        private static GrammarBuilder MakeGrammarBuilderRecursively(RadTreeNode currentNode)
        {
            GrammarBuilder currentGrammar = new GrammarBuilder();
            if ((currentNode.Tag as GrammarTreeViewTag).Optional != true &&
                (currentNode.Tag as GrammarTreeViewTag).IsDictation != true)
            {
                currentGrammar = new GrammarBuilder(new SemanticResultKey(currentNode.Text, new GrammarBuilder(currentNode.Text)));
            }
            else if ((currentNode.Tag as GrammarTreeViewTag).Optional && (currentNode.Tag as GrammarTreeViewTag).IsDictation != true)
            {
                currentGrammar = new GrammarBuilder(new SemanticResultKey(currentNode.Text, new GrammarBuilder(currentNode.Text)), 0, 1);
            }
            else if ((currentNode.Tag as GrammarTreeViewTag).IsDictation)
            {
                GrammarBuilder fakeDictation = new GrammarBuilder();
                fakeDictation.AppendDictation();
                DictationGrammar dictGrammar = new DictationGrammar((currentNode.Tag as GrammarTreeViewTag).DictationContext);
                if ((currentNode.Tag as GrammarTreeViewTag).Optional)
                {
                    currentGrammar = new GrammarBuilder(new SemanticResultKey(currentNode.Text, fakeDictation), 0, 1);
                }
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

        public static GrammarBuilder CreateGrammarBuilderFromTree(RadTreeView treeView)
        {
            GrammarBuilder currentGrammar = new GrammarBuilder();
            Choices wholeGrammar = new Choices();

            for (int i = 0; i < treeView.Nodes.Count; ++i)
            {
                currentGrammar = MakeGrammarBuilderRecursively(treeView.Nodes[i]);
            }
            return new Choices(currentGrammar);
        }

        public static GrammarBuilder CreateGrammarBuilderFromXML(string path)
        {
            RadTreeView XMLTree = RadTreeViewGrammarManager.LoadGrammarFromXML(path);
            return CreateGrammarBuilderFromTree(XMLTree);
        }

        public static GrammarBuilder CreateGrammarBuilderFromXML(Stream stream)
        {
            RadTreeView XMLTree = RadTreeViewGrammarManager.LoadGrammarFromXML(stream);
            return CreateGrammarBuilderFromTree(XMLTree);
        }
    }
}
