using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModernSteward;
using Telerik.WinControls.UI;
using SpeechLib;
using System.IO;
using System.Collections;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.Zip;
using Telerik.WinControls;

namespace PluginWizard
{
    public partial class PluginWizardForm : Form
    {
        private int lineToInsertTheGeneratedCode = 16;

        public PluginWizardForm()
        {
            InitializeComponent();

            treeViewCommands.AllowEdit = true;
            treeViewCommands.AllowRemove = true;
            treeViewCommands.AllowAdd = true;
            treeViewCommands.AllowDefaultContextMenu = true;

            treeViewCommands.Nodes.Add("CustomPlugin");

            checkBoxIsTheNodeDictation.IsThreeState = false;
            checkBoxIsTheNodeDictation.Visible = false;

            gridViewDictionaryItems.AllowAddNewRow = false;
            gridViewDictionaryItems.AllowColumnChooser = false;
            gridViewDictionaryItems.AllowColumnResize = false;
            gridViewDictionaryItems.AllowDeleteRow = false;
            gridViewDictionaryItems.AllowDrop = false;
            gridViewDictionaryItems.AllowEditRow = false;
            gridViewDictionaryItems.AllowMultiColumnSorting = false;
            gridViewDictionaryItems.AllowRowReorder = false;
            gridViewDictionaryItems.EnableCustomGrouping = false;
            gridViewDictionaryItems.EnableCustomSorting = false;
            gridViewDictionaryItems.EnableGrouping = false;

            gridViewDictionaryItems.Columns.Add("Дума");

            RenewGridViewDictionaryItems();

            gridViewDictionaryItems.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

        }

        private void RenewGridViewDictionaryItems()
        {
            gridViewDictionaryItems.Rows.Clear();

            ISpeechLexiconWords splexWords;
            SpLexicon lex = new SpLexicon();
            int generationId = 0;
            splexWords = lex.GetWords(SpeechLexiconType.SLTUser, out generationId);
            foreach (ISpeechLexiconWord splexWord in splexWords)
            {
                gridViewDictionaryItems.Rows.Add(splexWord.Word);
            }

        }

        private void checkBoxIsTheNodeDictation_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                treeViewCommands.SelectedNode.Tag = Consts.Dictation;
            }
            else if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                treeViewCommands.SelectedNode.Tag = null;
            }
        }

        private void buttonExportToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                treeViewCommands.SaveXML(saveFileDialog.FileName);
            }
        }

        private void buttonLoadTree_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = false;
            openFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    treeViewCommands.LoadXML(openFileDialog.FileName);
                    MessageBox.Show("Граматиката заредена успешно!");
                }
                catch
                {
                    MessageBox.Show("Невалиден формат на файла!", "Грешка");
                }
            }
        }

        void treeViewCommands_SelectedNodeChanged(object s, RadTreeViewEventArgs args)
        {
            checkBoxIsTheNodeDictation.Visible = true;
            if (args.Node.Tag != null)
            {
                if (args.Node.Tag.ToString() == Consts.Dictation)
                {
                    checkBoxIsTheNodeDictation.Checked = true;
                }
            }
            else
            {
                checkBoxIsTheNodeDictation.Checked = false;
            }
        }

        private void buttonAddNewWordToTheMasterDictionary_Click(object sender, EventArgs e)
        {
            SpLexicon lex = new SpLexicon();
            lex.AddPronunciation(textBoxNewWordToAdd.Text, 1033);
            textBoxNewWordToAdd.Text = "";
            RenewGridViewDictionaryItems();
        }

        private void buttonDeleteSelectedWord_Click(object sender, EventArgs e)
        {
            SpLexicon lex = new SpLexicon();
            lex.RemovePronunciation(gridViewDictionaryItems.SelectedRows[0].Cells[0].Value.ToString(), 1033);
            RenewGridViewDictionaryItems();
        }

        private string pluginPath = @"C:\CustomPlugin";

        private void pluginWizard_Finish(object sender, EventArgs e)
        {
            string masterPluginZip = Environment.CurrentDirectory + @"\CustomPlugin.zip";
            pluginPath = textBoxSaveFilePath.Text;

            Extract(masterPluginZip, pluginPath);

            string generatedCodeToHandleTheSpeechRecognitionEngineResults = generateCodeToHandleTheSpeechRecognitionEngineResults();

            InsertStringIntoAFileAtASpecificLineOfAFile(pluginPath + @"\CustomPlugin\CustomPlugin\CustomPlugin.cs",
                generatedCodeToHandleTheSpeechRecognitionEngineResults, lineToInsertTheGeneratedCode);
            
            treeViewCommands.SaveXML(pluginPath + @"\CustomPlugin\CustomPlugin\CustomPluginGrammar.xml");

            this.Close();
        }

        private void InsertStringIntoAFileAtASpecificLineOfAFile(string aTextFilePath, string aLinesToInsert, int aAtLine)
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

        int openedBracketsInTheGeneratedCode = 0;
        int closedBracketsInTheGeneratedCode = 0;
        private string generateCodeToHandleTheSpeechRecognitionEngineResults()
        {
            string generatedCode = "";
            foreach (var node in treeViewCommands.Nodes)
            {
                closedBracketsInTheGeneratedCode = 0;
                openedBracketsInTheGeneratedCode = 0;
                generatedCode += GeneratingTheCode(node, 0, generatedCode);
            }
            return generatedCode;
        }

        private string ShiftNTabsInTheConsole(int n)
        {
            string tabs = "";
            for (int i = 0; i < n+3; i++)
            {
                tabs += "\t";
            }
            return tabs;
        }

        const string semanticsInString = "semanticsToDict";
        private string GeneratingTheCode(RadTreeNode node, int level, string generatedCode)
        {
            string currentCode = "";
            currentCode += ShiftNTabsInTheConsole(level);
            currentCode += "if(" + semanticsInString.ToString() + "[" + level.ToString() + "].Key == \"" 
                + node.Text.ToString() + "\")";
            currentCode += "{" + Environment.NewLine;
            openedBracketsInTheGeneratedCode++;

            if (node.Tag != null)
            {
                if (node.Tag.ToString() == Consts.Dictation)
                {
                    currentCode += ShiftNTabsInTheConsole(level + 1);
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
            currentCode += ShiftNTabsInTheConsole(level);
            currentCode += "}" + Environment.NewLine;
            closedBracketsInTheGeneratedCode++;            
            return currentCode;
        }

        private int Extract(string sourceFile, string destinationPath)
        {
            ZipInputStream zinstream = null; // used to read from the zip file
            int numFileUnzipped = 0; // number of files extracted from the zip file

            try
            {
                // create a zip input stream from source zip file
                zinstream = new ZipInputStream(File.OpenRead(sourceFile));

                // we need to extract to a folder so we must create it if needed
                if (Directory.Exists(destinationPath) == false)
                    Directory.CreateDirectory(destinationPath);

                ZipEntry theEntry; // an entry in the zip file which could be a file or directory

                // now, walk through the zip file entries and copy each file/directory
                while ((theEntry = zinstream.GetNextEntry()) != null)
                {
                    string dirname = Path.GetDirectoryName(theEntry.Name); // the file path
                    string fname = Path.GetFileName(theEntry.Name);      // the file name

                    // if a path name exists we should create the directory in the destination folder
                    string target = destinationPath + Path.DirectorySeparatorChar + dirname;
                    if (dirname.Length > 0 && !Directory.Exists(target))
                        Directory.CreateDirectory(target);

                    // now we know the proper path exists in the destination so copy the file there
                    if (fname != String.Empty)
                    {
                        DecompressAndWriteFile(destinationPath + Path.DirectorySeparatorChar + theEntry.Name, zinstream);
                        numFileUnzipped++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                zinstream.Close();
            }
            return numFileUnzipped;
        }

        private static void DecompressAndWriteFile(string destination, ZipInputStream source)
        {
            FileStream wstream = null;

            try
            {
                // create a stream to write the file to
                wstream = File.Create(destination);

                const int block = 2048; // number of bytes to decompress for each read from the source

                byte[] data = new byte[block]; // location to decompress the file to

                // now decompress and write each block of data for the zip file entry
                while (true)
                {
                    int size = source.Read(data, 0, data.Length);

                    if (size > 0)
                        wstream.Write(data, 0, size);
                    else
                        break; // no more data
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (wstream != null)
                    wstream.Close();
            }
        }
    }
}
