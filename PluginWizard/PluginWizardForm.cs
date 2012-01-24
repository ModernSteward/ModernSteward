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
        }

        void HelpButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void checkBoxIsTheNodeDictation_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {

            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).IsDictation = true;
                textBoxContext.Text = (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).DictationContext;
                textBoxContext.Visible = true;
                labelContext.Visible = true;
            }
            else if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).IsDictation = false;
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).DictationContext = "";
                textBoxContext.Visible = false;
                labelContext.Visible = false;
            }
        }

        private void buttonExportToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.SupportMultiDottedExtensions = false;
            saveFileDialog.Filter = "XML Files|*.xml|All Files|*.*";
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RadTreeViewGrammarManager.SaveGrammarToXML(treeViewCommands, saveFileDialog.FileName);
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
                    treeViewCommands = RadTreeViewGrammarManager.LoadGrammarFromXML(openFileDialog.FileName);
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
            checkBoxItemOptional.Visible = true;
            if ((treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).IsDictation)
            {
                textBoxContext.Text = (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).DictationContext;
                checkBoxIsTheNodeDictation.Checked = true;
                textBoxContext.Visible = true;
                labelContext.Visible = true;
            }
            else
            {
                checkBoxIsTheNodeDictation.Checked = false;
                textBoxContext.Text = "";
                textBoxContext.Visible = false;
                labelContext.Visible = false;
            }

            if ((treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).Optional)
            {
                checkBoxItemOptional.Checked = true;
            }
            else
            {
                checkBoxItemOptional.Checked = false;
            }
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
            
            RadTreeViewGrammarManager.SaveGrammarToXML(treeViewCommands, pluginPath + @"\CustomPlugin\CustomPlugin\CustomPluginGrammar.xml");

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

        private void textBoxContext_TextChanged(object sender, EventArgs e)
        {
            if (checkBoxIsTheNodeDictation.Checked == true)
            {
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).DictationContext = textBoxContext.Text;
            }
        }

        private void checkBoxItemOptional_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
            {
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).Optional = true;
            }
            else if (args.ToggleState == Telerik.WinControls.Enumerations.ToggleState.Off)
            {
                (treeViewCommands.SelectedNode.Tag as GrammarTreeViewTag).Optional = false;
            }
        }

        private void treeViewCommands_NodeAdded(object sender, RadTreeViewEventArgs e)
        {
            e.Node.Tag = new GrammarTreeViewTag(false, "", false);
        }
    }
}
