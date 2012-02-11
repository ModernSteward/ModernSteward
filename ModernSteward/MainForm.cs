using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Speech.Recognition;
using System.Text.RegularExpressions;

namespace ModernSteward
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {

        private PluginHandler mPluginHandler = new PluginHandler();
        private Core mCore = new Core();

        private bool recognitionEngineRunning = false;

        public MainForm()
        {
            InitializeComponent();

            gridViewNotInitializedPlugins.AllowAutoSizeColumns = true;
            gridViewNotInitializedPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridViewInitializedPlugins.AllowAutoSizeColumns = true;
            gridViewInitializedPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridViewNotInitializedPlugins.Rows.Add("LightsManagerPlugin", false, "Инициализирай!");

            gridViewNotInitializedPlugins.CommandCellClick += new CommandCellClickEventHandler(gridViewNotInitializedPlugins_CommandCellClick);
            gridViewInitializedPlugins.CommandCellClick += new CommandCellClickEventHandler(gridViewInitializedPlugins_CommandCellClick);

            gridViewNotInitializedPlugins.Rows[0].Cells[0].Style.BackColor = Color.Red;

            //(gridViewPlugins.Columns[2] as GridViewCommandColumn).HeaderTextAlignment = ContentAlignment.MiddleCenter;
            
        }

        void gridViewInitializedPlugins_CommandCellClick(object sender, EventArgs e)
        {
            var cell = (sender as GridCommandCellElement);
            gridViewNotInitializedPlugins.Rows.Add(cell.RowInfo.Cells[0].Value, cell.RowInfo.Cells[1].Value, "Инициализирай!");
            gridViewInitializedPlugins.Rows.Remove((sender as GridCommandCellElement).RowInfo);
        }

        void gridViewNotInitializedPlugins_CommandCellClick(object sender, EventArgs e)
        {
            var cell = (sender as GridCommandCellElement);
            gridViewInitializedPlugins.Rows.Add(cell.RowInfo.Cells[0].Value, cell.RowInfo.Cells[1].Value, "Деинициализирай!");
            gridViewNotInitializedPlugins.Rows.Remove((sender as GridCommandCellElement).RowInfo);
        }

        private void radMenuItemPluginWizard_Click(object sender, EventArgs e)
        {
            PluginWizard.PluginWizardForm pluginWizardForm = new PluginWizard.PluginWizardForm();
            pluginWizardForm.Show();
        }

        private void menuItemMasterDictionary_Click(object sender, EventArgs e)
        {
            MasterDictionaryForm masterDictionaryForm = new MasterDictionaryForm();
            masterDictionaryForm.Show();
        }

        //TO IMPLEMENT!!!
        private void menuItemHelp_Click(object sender, EventArgs e)
        {

        }

        private void menuItemCreators_Click(object sender, EventArgs e)
        {
            AboutTheCreators aboutTheCreators = new AboutTheCreators("1.0");
            aboutTheCreators.Show();
        }

        private void buttonAddPlugin_Click(object sender, EventArgs e)
        {
            if (browseEditorAddPlugin.Text != "" && Regex.IsMatch(textBoxPluginName.Text, @"^[\w]+$")) //regex expression matches if the textBoxPluginName.Text contains only letters, or underscores
            {
                try
                {
                    mPluginHandler.Plugins.Add(new Plugin(textBoxPluginName.Text, textBoxPluginName.Text, browseEditorAddPlugin.Text));
                }
                catch
                {
                    RadMessageBox.Show("Плъгинът е невалиден или несъвместим с настоящата версия!");
                }
            }
        }


        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            if (!recognitionEngineRunning)
            {
                mCore.LoadPlugins(mPluginHandler);

                mCore.StartAsyncRecognition();
                buttonStartStop.Text = "Изключи";
                labelStartStop.Text = "ВКЛЮЧЕНО";
                labelStartStop.ForeColor = Color.Green;

                recognitionEngineRunning = true;
            }
            else
            {
                mCore.StopAsyncRecognition();
                buttonStartStop.Text = "Включи";
                labelStartStop.Text = "ИЗКЛЮЧЕНО";
                labelStartStop.ForeColor = Color.Red;

                recognitionEngineRunning = false;
                
            }
        }
    }
}
