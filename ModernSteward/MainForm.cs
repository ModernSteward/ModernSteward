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

			LoadingForm loadingForm = new LoadingForm();
			loadingForm.ShowLoadingForm();

			try
			{
				mCore = new Core();
				mCore.SpeechRecognizedCoreEvent += new Core.SpeechRecognizedCoreEventHandler(mCore_SpeechRecognizedCoreEvent);
			}
			catch (InvalidOperationException)
			{
				RadMessageBox.Show("Трябва да свържете микрофона си преди да стартирате апликацията!", "Грешка");
				this.Close();
			}

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;

			gridViewPlugins.AllowAutoSizeColumns = true;
			gridViewPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewPlugins.AllowAutoSizeColumns = true;
			gridViewPlugins.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;

			gridViewPlugins.CommandCellClick += new CommandCellClickEventHandler(gridViewPlugins_CommandCellClick);

			labelStatusInStatusStrip.Text = "";
			labelStatusInStatusStrip.TextChanged += new EventHandler(labelStatusInStatusStrip_TextChanged);


			loadingForm.CloseLoadingForm();
			this.Show();
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
				foreach (var plugin in mPluginHandler.Plugins)
				{
					if (plugin.Name == row.Cells["Name"].Value.ToString())
					{
						if (plugin.Initialize())
						{
							row.Cells["Checkbox"].Value = true;
							row.Cells["Button"].Value = "Деинициализирай!";

							labelStatusInStatusStrip.Text = plugin.Name + " бе инициализиран успешно.";
						}
						else
						{
							RadMessageBox.Show("Получи се някаква грешка при инициализирането на плъгина. Моля, свържете се със създателя на плъгина.", "Грешка");
						}
					}
				}
				
			}
			else
			{
				foreach (var plugin in mPluginHandler.Plugins)
				{
					if (plugin.Name == row.Cells["Name"].Value.ToString())
					{
						labelStatusInStatusStrip.Text = plugin.Name + " бе деинициализиран успешно.";

						plugin.Initialized = false;

						row.Cells["Checkbox"].Value = false;
						row.Cells["Button"].Value = "Инициализирай!";
						break;
					}
				}
			}
		}

		private void radMenuItemPluginWizard_Click(object sender, EventArgs e)
		{
			PluginWizardForm pluginWizardForm = new PluginWizardForm();
			pluginWizardForm.Show();
		}

		private void menuItemMasterDictionary_Click(object sender, EventArgs e)
		{
			MasterDictionaryForm masterDictionaryForm = new MasterDictionaryForm();
			masterDictionaryForm.Show();
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
							mPluginHandler.Plugins.Add(new Plugin(textBoxPluginName.Text, textBoxPluginPath.Text));

							AddPluginToTheGridView(textBoxPluginName.Text, textBoxPluginPath.Text);

							labelStatusInStatusStrip.Text = textBoxPluginName.Text + " бе добавен.";

							textBoxPluginPath.Text = "";
							textBoxPluginName.Text = "";
						}
						else
						{
							RadMessageBox.Show("Вече има плъгин с това име!", "Грешка");
						}
					}
				}
				catch (Exception ex)
				{
					RadMessageBox.Show("Плъгинът е невалиден или несъвместим с настоящата версия!", "Грешка");
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
				bool atLeastOnePluginInitialized = true;
				foreach (var plugin in mPluginHandler.Plugins)
				{
					if (plugin.Initialized == true)
					{
						atLeastOnePluginInitialized = true;
					}
				}
				if (mPluginHandler.Plugins.Count != 0 && atLeastOnePluginInitialized)
				{
					
					mCore.LoadPlugins(mPluginHandler);
					try
					{
						mCore.StartAsyncRecognition();
					}
					catch (Exception ex)
					{
						RadMessageBox.Show("При стартиране на \"Модерният иконом\" нещо се провали. Моля, свържете се с администратор.", "Грешка");
					}

					buttonStartStop.Text = "Изключи";
					labelStartStop.Text = "ВКЛЮЧЕНО";
					labelStartStop.ForeColor = Color.Green;

					recognitionEngineRunning = true;

					gridViewPlugins.Enabled = false;
				}
				else
				{
					RadMessageBox.Show("За да стартирате \"Модерният иконом\" трябва да сте инициализирали поне един плъгин.", "Грешка");
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

			SaveFileDialog saveUserProfileFileDialog = new SaveFileDialog();
			saveUserProfileFileDialog.Filter = "ModernSteward user profile|*.msu|All files|*.*";

			if (saveUserProfileFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				var stream = new FileStream(saveUserProfileFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
				try
				{
					System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(mPluginHandler.GetType());
					xmlSerializer.Serialize(stream, mPluginHandler);

					labelStatusInStatusStrip.Text = saveUserProfileFileDialog.FileName + " бе запазен успешно.";
				}
				catch (Exception ex)
				{
					RadMessageBox.Show("Възникна проблем при запазването на профила. Моля, свържете се с администратор", "Грешка");
				}
				finally
				{
					stream.Flush();
					stream.Close();
				}
			}
		}

		private void menuItemOpenFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openUserProfileFileDialog = new OpenFileDialog();
			openUserProfileFileDialog.Filter = "ModernSteward user profile|*.msu|All files|*.*";
			bool openedSuccessfull = false;
			if (openUserProfileFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				Stream stream = new FileStream(openUserProfileFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
				try
				{
					System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(mPluginHandler.GetType());
					mPluginHandler = (PluginHandler)xmlSerializer.Deserialize(stream);

					gridViewPlugins.Rows.Clear();

					foreach (var plugin in mPluginHandler.Plugins)
					{
						plugin.LoadPlugin();
						AddPluginToTheGridView(plugin.Name, plugin.PluginPath);
					}

					openedSuccessfull = true;
				}
				catch (Exception ex)
				{
					RadMessageBox.Show("Възникна проблем при отварянето на профила. Най-вероятно файлът е развален. \nМоля, свържете се с администратор", "Грешка");
				}
				finally
				{
					if (openedSuccessfull)
					{
						labelStatusInStatusStrip.Text = openUserProfileFileDialog.FileName + " бе зареден успешно.";
					}
					else
					{
						labelStatusInStatusStrip.Text = openUserProfileFileDialog.FileName + " бе зареден НЕуспешно.";
					}
					if (stream != null)
					{
						stream.Close();
					}
				}
			}
		}

		private void textBoxPluginName_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonAddPlugin_Click(this, new EventArgs());
			}
		}

		private void menuItemPluginCommands_Click(object sender, EventArgs e)
		{
			try
			{
				string pluginName = gridViewPlugins.SelectedRows[0].Cells["Name"].Value.ToString();
				var foundPlugin = mPluginHandler.Plugins.Find((plugin) => plugin.Name == pluginName);
				var showPluginCommandsForm = new PluginCommandsForm(pluginName, foundPlugin.PluginGrammarTreePath);
				showPluginCommandsForm.Show();
			}
			catch (System.ArgumentOutOfRangeException)
			{
				RadMessageBox.Show("Първо трябва да селектирате плъгин!");
			}
		}
	}
}
