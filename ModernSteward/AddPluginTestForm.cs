using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;

namespace ModernSteward
{
    public partial class AddPluginTestForm : Form
    {
        PluginHandler pluginHandler = new PluginHandler();

        public AddPluginTestForm()
        {
            InitializeComponent();
        } 

        private void buttonAddPlugin_Click(object sender, EventArgs e)
        {
            pluginHandler.Plugins.Add(new Plugin(textBoxName.Text, textBoxKeyword.Text, textBoxPluginPath.Text));
            comboBoxPlugins.Items.Clear();
            foreach (var plugin in pluginHandler.Plugins)
            {
                comboBoxPlugins.Items.Add(plugin);
            }
            textBoxName.Text = "";
            textBoxKeyword.Text = "";
        }

        private void buttonTriggerPlugin_Click(object sender, EventArgs e)
        {
            (comboBoxPlugins.SelectedItem as Plugin).TriggerPlugin(textBoxAdditionalCommands.Text);
        }

        private void buttonBrowseForPlugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "dll files (*.dll)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textBoxPluginPath.Text = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            
        }
    }
}
