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
    public partial class PluginCommandsForm : Telerik.WinControls.UI.RadForm
    {
        public PluginCommandsForm(string pluginName, string pathToTheXML)
        {
            InitializeComponent();
			this.Text = "Commands for " + pluginName;

			RadTreeViewGrammarManager.LoadGrammarFromXML(pathToTheXML, ref treeViewCommands);
			treeViewCommands.Enabled = false;
        }
    }
}
