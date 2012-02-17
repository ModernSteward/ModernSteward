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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Xml;

namespace ModernSteward
{
	public partial class MainForm : Telerik.WinControls.UI.RadForm
	{

		private PluginHandler mPluginHandler = new PluginHandler();
		private Core mCore;

		private bool recognitionEngineRunning = false;

		public MainForm()
		{
			InitializeComponent();

			try
			{
				mCore = new Core();
				mCore.SpeechRecognizedCoreEvent += new Core.SpeechRecognizedCoreEventHandler(mCore_SpeechRecognizedCoreEvent);
			}
			catch (InvalidOperationException)
			{
				RadMessageBox.Show("Трябва да свържете микрофона си преди да стартирате апликацията!");
				this.Close();
			}

			gridViewPlugins.AllowAutoSizeColumns = true;
			gridViewPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewPlugins.AllowAutoSizeColumns = true;
			gridViewPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewPlugins.CommandCellClick += new CommandCellClickEventHandler(gridViewPlugins_CommandCellClick);

			labelStatusInStatusStrip.Text = "";
			labelStatusInStatusStrip.TextChanged += new EventHandler(labelStatusInStatusStrip_TextChanged);	

		}

		int ticks = 0;
		void labelStatusInStatusStrip_TextChanged(object sender, EventArgs e)
		{
			ticks = 0;
			Timer timer = new Timer();
			timer.Start();
			timer.Tick += new EventHandler(timer_Tick);
		}

		void timer_Tick(object sender, EventArgs e)
		{
			ticks++;
			if (ticks == 20)
			{
				labelStatusInStatusStrip.Text = "";
				(sender as Timer).Stop();
				ticks = 0;
			}
		}

		void  mCore_SpeechRecognizedCoreEvent(Plugin pluginTriggered)
		{
			labelStatusInStatusStrip.Text = pluginTriggered.Name + " бе задействан.";
			labelStatusInStatusStrip.UpdateLayout();
		}

		void gridViewPlugins_CommandCellClick(object sender, EventArgs e)
		{
			var buttonCell = (sender as GridCommandCellElement);
			var row = buttonCell.RowInfo;

			if (((bool)row.Cells["Checkbox"].Value) == false)
			{
				Plugin newPlugin = new Plugin(row.Cells["Name"].Value.ToString(), row.Tag.ToString());
				if (newPlugin.Initialize())
				{
					mPluginHandler.Plugins.Add(newPlugin);
					row.Cells["Checkbox"].Value = true;
					row.Cells["Button"].Value = "Деинициализирай!";

					labelStatusInStatusStrip.Text = newPlugin.Name + " бе инициализиран успешно.";
				}
				else
				{
					RadMessageBox.Show("Получи се някаква грешка при инициализирането на плъгина. Моля, свържете се със създателя на плъгина.");
				}
			}
			else
			{
				foreach (var plugin in mPluginHandler.Plugins)
				{
					if (plugin.Name == row.Cells["Name"].Value.ToString())
					{
						mPluginHandler.Plugins.Remove(plugin);

						row.Cells["Checkbox"].Value = false;
						row.Cells["Button"].Value = "Инициализирай!";
						break;
					}
				}
			}
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
			try
			{
				try
				{
					if (textBoxPluginName.Text != "" && textBoxPluginPath.Text != "")
					{
						bool nameAlreadyTaken = false;
						foreach (var row in gridViewPlugins.Rows)
						{
							string name = row.Cells["Name"].Value.ToString();
							if (name == textBoxPluginName.Text)
							{

								nameAlreadyTaken = true;
							}
						}

						if (!nameAlreadyTaken)
						{
							// Little hack to check if the program will later be able to load the plugin successfully
							PluginHandler testPluginHandler = new PluginHandler();
							testPluginHandler.Plugins.Add(new Plugin(textBoxPluginName.Text, textBoxPluginPath.Text));

							AddPluginToTheGridView(textBoxPluginName.Text, textBoxPluginPath.Text);

							labelStatusInStatusStrip.Text = textBoxPluginName.Text + " бе добавен.";

							textBoxPluginPath.Text = "";
							textBoxPluginName.Text = "";
						}
						else
						{
							RadMessageBox.Show("Вече има плъгин с това име!");
						}
					}
				}
				catch
				{
					RadMessageBox.Show("Плъгинът е невалиден или несъвместим с настоящата версия!");
				}
			}
			catch { }
		}

		private void AddPluginToTheGridView(string pluginName, string pluginPath)
		{
			gridViewPlugins.Rows.Add(false, pluginName, "Инициализирай!");
			gridViewPlugins.Rows[gridViewPlugins.Rows.Count - 1].Tag = pluginPath;
		}


		private void buttonStartStop_Click(object sender, EventArgs e)
		{
			if (!recognitionEngineRunning)
			{
				if (mPluginHandler.Plugins.Count != 0)
				{
					mCore.LoadPlugins(mPluginHandler);
					try
					{
						mCore.StartAsyncRecognition();
					}
					catch
					{
						RadMessageBox.Show("При стартиране на \"Модерният иконом\" нещо се провали. Моля, свържете се с администратор.");
					}

					buttonStartStop.Text = "Изключи";
					labelStartStop.Text = "ВКЛЮЧЕНО";
					labelStartStop.ForeColor = Color.Green;

					recognitionEngineRunning = true;

					gridViewPlugins.Enabled = false;
				}
				else
				{
					RadMessageBox.Show("За да стартирате \"Модерният иконом\" трябва да сте инициализирали поне един плъгин.");
				}
			}
			else
			{
				mCore.StopAsyncRecognition();

				buttonStartStop.Text = "Включи";
				labelStartStop.Text = "ИЗКЛЮЧЕНО";
				labelStartStop.ForeColor = Color.Red;

				recognitionEngineRunning = false;

				gridViewPlugins.Enabled = true;
			}
		}

		private void buttonBrowseForPlugin_Click(object sender, EventArgs e)
		{
			OpenFileDialog openPluginAssemblyFileDialog = new OpenFileDialog();
			openPluginAssemblyFileDialog.Filter = "ModernSteward Plugins|*.msp|All files|*.*";
			if (openPluginAssemblyFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				textBoxPluginPath.Text = openPluginAssemblyFileDialog.FileName;
			}
		}

		private void MenuItemSave_Click(object sender, EventArgs e)
		{

			gridViewPlugins.XmlSerializationInfo.DisregardOriginalSerializationVisibility = true;

			gridViewPlugins.XmlSerializationInfo.SerializationMetadata.Add(
					typeof(RadGridView),
					"MasterTemplate",
					DesignerSerializationVisibilityAttribute.Content);

			SaveFileDialog saveUserProfileFileDialog = new SaveFileDialog();
			saveUserProfileFileDialog.Filter = "ModernSteward user profile|*.msu|All files|*.*";

			if (saveUserProfileFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(saveUserProfileFileDialog.FileName))
				{
					gridViewPlugins.SaveLayout(xmlWriter);
				}
			}
		}

		private void menuItemOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openUserProfileFileDialog = new OpenFileDialog();
			openUserProfileFileDialog.Filter = "*ModernSteward user profile|*.msu|All files|*.*";
			if (openUserProfileFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				using (XmlReader xmlReader = XmlReader.Create(openUserProfileFileDialog.FileName))
				{
					xmlReader.Read();
					gridViewPlugins.LoadLayout(xmlReader);
				}
			}
		}
	}
}
