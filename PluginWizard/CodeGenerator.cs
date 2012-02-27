using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;
using Telerik.WinControls.UI;
using ModernSteward;

namespace PluginWizard
{
    static class CodeGenerator
    {
        public static void InsertStringIntoAFileAtASpecificLineOfAFile(string aTextFilePath, string aLinesToInsert, int aAtLine)
        {
            string textFilePath = aTextFilePath;
            int indexToInsertTheString = aAtLine;
            string linesToBeInserted = aLinesToInsert;

            #region Reading the file
            ArrayList lines = new ArrayList();
            StreamReader reader = new StreamReader(textFilePath);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }
            reader.Close();
            #endregion

            #region Inserting the new lines
            if (lines.Count > indexToInsertTheString)
            {
                lines.Insert(indexToInsertTheString, aLinesToInsert);
            }
            else
            {
                lines.Add(aLinesToInsert);
            }
            #endregion

            #region Writing the new file with the inserted lines
            StreamWriter writer = new StreamWriter(textFilePath);
            foreach (string strNewLine in lines)
            {
                writer.WriteLine(strNewLine);
            }
            writer.Close();
            #endregion
        }

        public static string generateCodeToHandleTheSpeechRecognitionEngineResults(RadTreeView treeView)
        {
            string generatedCode = "";
            foreach (var node in treeView.Nodes)
            {
                generatedCode += GeneratingTheCode(node, 0, generatedCode);
            }
            return generatedCode;
        }

        private static string ShiftNTabsInTheConsole(int n)
        {
            string tabs = "";
            for (int i = 0; i < n + 3; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }

        const string semanticsInString = "semanticsToDict";
        private static string GeneratingTheCode(RadTreeNode node, int level, string generatedCode)
        {
            string currentCode = "";
            currentCode += ShiftNTabsInTheConsole(level);
            currentCode += "try {" + Environment.NewLine;

            currentCode += ShiftNTabsInTheConsole(level+1);
            currentCode += "if (" + semanticsInString.ToString() + "[" + level.ToString() + "].Key == \"" + node.Text.ToString() + "\")";

            currentCode += "{";

            if ((node.Tag as GrammarTreeViewTag).Optional)
            {
                currentCode += " //optional element";
            }

            currentCode += Environment.NewLine;

            if (node.Tag != null)
            {
                if ((node.Tag as GrammarTreeViewTag).IsDictation)
                {
                    currentCode += ShiftNTabsInTheConsole(level + 2);
                    string dictationFor = node.Text.Replace(" ", "");
                    currentCode += "string dictationFor" + dictationFor + " = "
                        + semanticsInString + "[" + level.ToString() + "].Value;" + Environment.NewLine;
                }
                else
                {
                    currentCode += Environment.NewLine;
                }
            }

            int iteration = 0;
            foreach (var childNode in node.Nodes)
            {
                iteration++;

                currentCode += GeneratingTheCode(childNode, level + 1, generatedCode);
            }
            currentCode += ShiftNTabsInTheConsole(level+1);
            currentCode += "}" + Environment.NewLine;


            currentCode += ShiftNTabsInTheConsole(level);
            currentCode += "}" + Environment.NewLine;
            currentCode += ShiftNTabsInTheConsole(level);
            currentCode += "catch (Exception e) { }"  + Environment.NewLine + Environment.NewLine;

            return currentCode;
        }
    }
}
