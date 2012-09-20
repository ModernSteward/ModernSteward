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

namespace XmlGrammarToListOfCommandsForm
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			var openFile = new OpenFileDialog();
			openFile.Filter = "*.xml | *.xml";

			if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				List<string> pluginsCommands = new List<string>();
				RadTreeView tree = new RadTreeView();
				RadTreeViewGrammarManager.LoadGrammarFromXML(openFile.FileName, ref tree);

				foreach (var node in tree.Nodes)
				{
					RadTreeViewGrammarManager.GetAllCommands(node, node.Text, ref pluginsCommands);
				}

				textBoxCommands.ResetText();
				foreach (var command in pluginsCommands)
				{
					textBoxCommands.AppendText(command + Environment.NewLine);
				}
			}
		}
	}
}
