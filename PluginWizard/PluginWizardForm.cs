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

            textBoxSaveFilePath.ReadOnly = false;

            pluginWizard.NextButton.Text = "Следващ";
            pluginWizard.BackButton.Text = "Назад";
            pluginWizard.CancelButton.Text = "Откажи";

            pluginWizard.HelpButton.Text = "Помощ";
            pluginWizard.HelpButton.Click += new EventHandler(HelpButton_Click);

            treeViewCommands.AllowEdit = true;
            treeViewCommands.AllowRemove = true;
            treeViewCommands.AllowAdd = true;
            treeViewCommands.AllowDefaultContextMenu = true;

            treeViewCommands.Nodes.Add("CustomPlugin");

            treeViewCommands.ContextMenu = new System.Windows.Forms.ContextMenu();
            treeViewCommands.ContextMenu.MenuItems.Add(new MenuItem("New node", 
                (sender, args) =>
                {
                    treeViewCommands.Nodes.Add("New Node");
                }));
            
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

        void HelpButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

            ZipManager.Extract(masterPluginZip, pluginPath);

            string generatedCodeToHandleTheSpeechRecognitionEngineResults = 
                CodeGenerator.generateCodeToHandleTheSpeechRecognitionEngineResults(treeViewCommands);

            CodeGenerator.InsertStringIntoAFileAtASpecificLineOfAFile(pluginPath + @"\CustomPlugin\CustomPlugin\CustomPlugin.cs",
                generatedCodeToHandleTheSpeechRecognitionEngineResults, lineToInsertTheGeneratedCode);
            
            treeViewCommands.SaveXML(pluginPath + @"\CustomPlugin\CustomPlugin\CustomPluginGrammar.xml");

            string windowsRootDirectory = Environment.GetEnvironmentVariable("WINDIR");
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = windowsRootDirectory + @"\explorer.exe";
            prc.StartInfo.Arguments = pluginPath;
            prc.Start();


            this.Close();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browseForFolder = new FolderBrowserDialog();
            if (browseForFolder.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBoxSaveFilePath.Text = browseForFolder.SelectedPath;
                pluginPath = browseForFolder.SelectedPath;
            }
        }

        private void pluginWizard_Cancel(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
