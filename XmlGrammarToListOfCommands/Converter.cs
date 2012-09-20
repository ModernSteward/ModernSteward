using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ModernSteward;
using Telerik.WinControls.UI;

namespace XmlGrammarToListOfCommands
{
	public partial class Converter : Form
	{
		public Converter()
		{
			InitializeComponent();
		}

		private void buttonBrowse_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();
			if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{

				try
				{

					List<string> pluginsCommands = new List<string>();
					RadTreeView tree = new RadTreeView();
					RadTreeViewGrammarManager.LoadGrammarFromXML(openFile.FileName, ref tree);

					foreach (var node in tree.Nodes)
					{
						RadTreeViewGrammarManager.GetAllCommands(node, node.Text, ref pluginsCommands);
					}

					textBoxListOfCommands.Text = "";
					foreach (var command in pluginsCommands)
					{
						textBoxListOfCommands.AppendText(command + Environment.NewLine);
					}

					textBoxXmlFilePath.Text = openFile.FileName;
				}
				catch {
					MessageBox.Show("Not a valid grammar file!");
				}
			}
		}
	}
}
