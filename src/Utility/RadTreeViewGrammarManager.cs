using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;
using System.IO;

namespace ModernSteward
{
    public static class RadTreeViewGrammarManager
    {
        public static void LoadGrammarFromXML(string filePath, ref RadTreeView tree)
        {
            tree.LoadXML(filePath, typeof(GrammarTreeViewTag));
        }

        public static RadTreeView LoadGrammarFromXML(Stream stream)
        {
            RadTreeView tree = new RadTreeView();
            tree.LoadXML(stream, typeof(GrammarTreeViewTag));
            return tree;
        }

        public static bool SaveGrammarToXML(RadTreeView tree, string filePath){
            try
            {
                tree.SaveXML(filePath, typeof(GrammarTreeViewTag));
            }
            catch {
                return false;
            }
            return true;
        }

        public static bool SaveGrammarToXML(RadTreeView tree, Stream stream)
        {
            try
            {
                tree.SaveXML(stream, typeof(GrammarTreeViewTag));
            }
            catch
            {
                return false;
            }
            return true;
        }

		public static bool MatchGrammarToPlugin(string pathToXml, string aCommand)
		{
			List<string> pluginsCommands = new List<string>();
			RadTreeView tree = new RadTreeView();
			LoadGrammarFromXML(pathToXml, ref tree);

			foreach (var node in tree.Nodes)
			{
				GetAllCommands(node, node.Text, ref pluginsCommands);
			}

			foreach (var command in pluginsCommands)
			{
				if (command == aCommand)
				{
					return true;
				}
			}
			return false;
		}

		public static void GetAllCommands(RadTreeNode root, string text, ref List<String> result)
		{
			if (root == null)
			{
				return;
			}

			if (root.Nodes.Count == 0)
			{

				result.Add(text);
			}

			RadTreeNode child = null;
			for (int i = 0; i < root.Nodes.Count; i++)
			{
				child = root.Nodes[i];
				//text += ' ' + child.Text;
				GetAllCommands(child, text + ' ' + child.Text, ref result);
			}
		}
    }
}
