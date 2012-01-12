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
            if (currentNode.Tag == null)
            {
                currentGrammar = new GrammarBuilder(new SemanticResultKey(currentNode.Text, new GrammarBuilder(currentNode.Text)));
            }
            else if (currentNode.Tag.ToString() == Consts.Dictation) 
            {
                GrammarBuilder fakeDictation = new GrammarBuilder();
                fakeDictation.AppendDictation();
                DictationGrammar dictGrammar = new DictationGrammar();
                currentGrammar = new GrammarBuilder(new SemanticResultKey(currentNode.Text, fakeDictation));
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
                wholeGrammar.Add(new Choices(currentGrammar));
            }
            return wholeGrammar;
        }

        public static GrammarBuilder CreateGrammarBuilderFromXML(string path)
        {
            RadTreeView XMLTree = new RadTreeView();
            XMLTree.LoadXML(path);
            return CreateGrammarBuilderFromTree(XMLTree);
        }

        public static GrammarBuilder CreateGrammarBuilderFromXML(Stream stream)
        {
            RadTreeView XMLTree = new RadTreeView();
            XMLTree.LoadXML(stream);
            return CreateGrammarBuilderFromTree(XMLTree);
        }
    }
}
