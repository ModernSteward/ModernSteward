using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace ModernSteward
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();

            gridViewNotInitializedPlugins.AllowAutoSizeColumns = true;
            gridViewNotInitializedPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridViewInitializedPlugins.AllowAutoSizeColumns = true;
            gridViewInitializedPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

            gridViewNotInitializedPlugins.Rows.Add("LightsManagerPlugin", false, "Инициализирай!");
            //gridViewInitializedPlugins.Rows.Add("LightsManagerPlugin", false, "Деинициализирай!");

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
            //gridViewInitializedPlugins.Rows.Add((sender as GridCommandCellElement).RowInfo);
            var cell = (sender as GridCommandCellElement);
            gridViewInitializedPlugins.Rows.Add(cell.RowInfo.Cells[0].Value, cell.RowInfo.Cells[1].Value, "Деинициализирай!");
            gridViewNotInitializedPlugins.Rows.Remove((sender as GridCommandCellElement).RowInfo);
        }

        private void radMenuItemPluginWizard_Click(object sender, EventArgs e)
        {
            PluginWizard.PluginWizardForm pluginWizardForm = new PluginWizard.PluginWizardForm();
            pluginWizardForm.Show();
        }
    }
}
