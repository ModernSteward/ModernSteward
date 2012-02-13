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

    }
}
