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
			loadingForm.ShowDialog();

			try
			{
				mCore = new Core();
				mCore.SpeechRecognizedCoreEvent += new Core.SpeechRecognizedCoreEventHandler(mCore_SpeechRecognizedCoreEvent);
			}
			catch (InvalidOperationException ex)
			{
				RadMessageBox.Show("You have to connect the microphone before executing the program!", "Error");
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

			notifyIcon = new NotifyIcon();
			notifyIcon.Visible = true;


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

		void mCore_SpeechRecognizedCoreEvent(Plugin pluginTriggered)
		{
			try
			{
				labelStatusInStatusStrip.Text = pluginTriggered.Name + " was triggered.";
				labelStatusInStatusStrip.UpdateLayout();
			}
			catch
			{
				// Telerik RadControls, dude... failing for some reason
			}
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
							row.Cells["Button"].Value = "Deinitialize!";

							labelStatusInStatusStrip.Text = plugin.Name + " was initialized successfully.";
						}
						else
						{
							RadMessageBox.Show("An error occured during plugin's initialization. Please, connect to the plugin's creator.", "Error");
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
						labelStatusInStatusStrip.Text = plugin.Name + " was deinitialized successfully.";

						plugin.Initialized = false;

						row.Cells["Checkbox"].Value = false;
						row.Cells["Button"].Value = "Initialize!";
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
							mPluginHandler.Plugins.Add(new Plugin(textBoxPluginName.Text, textBoxPluginPath.Text));

							AddPluginToTheGridView(textBoxPluginName.Text, textBoxPluginPath.Text);

							labelStatusInStatusStrip.Text = textBoxPluginName.Text + " was added.";

							textBoxPluginPath.Text = "";
							textBoxPluginName.Text = "";
						}
						else
						{
							RadMessageBox.Show("There is already a plugin with this name! Please, choose another one.", "Error");
						}
					}
				}
				catch (Exception ex)
				{
					var reporter = new CrashReporter();
					reporter.Report(ex);

					RadMessageBox.Show(@"An error occured. The plugin might be out of date, not valid or ModernSteward is installed in a directory without administration privileges. 
						Please, start ModernSteward with administrator privileges or connect to the support crew.", "Error");

				}
			}
			catch (Exception ex)
			{
				var reporter = new CrashReporter();
				reporter.Report(ex);
			}
		}

		private void AddPluginToTheGridView(string pluginName, string pluginPath)
		{
			gridViewPlugins.Rows.Add(false, pluginName, "Initialize!");
			gridViewPlugins.Rows[gridViewPlugins.Rows.Count - 1].Tag = pluginPath;
		}

		private void buttonStartStop_Click(object sender, EventArgs e)
		{
			if (!recognitionEngineRunning)
			{
				bool atLeastOnePluginInitialized = false;
				foreach (var plugin in mPluginHandler.Plugins)
				{
					if (plugin.Initialized == true)
					{
						atLeastOnePluginInitialized = true;
					}
				}

				if (mPluginHandler.Plugins.Count != 0 && atLeastOnePluginInitialized)
				{
					mCore.LoadPluginsGrammar(mPluginHandler);
					try
					{
						mCore.StartAsyncRecognition();
					}
					catch (Exception ex)
					{
						RadMessageBox.Show("An error occured while starting the ModernSteward speech recognition engine. Please, connect to the support crew.", "Error");
						return;
					}

					buttonStartStop.Text = "Turn off";
					labelStartStop.Text = "TURNED ON";
					labelStartStop.ForeColor = Color.Green;

					recognitionEngineRunning = true;

					gridViewPlugins.Enabled = false;
				}
				else
				{
					RadMessageBox.Show("To start the ModernSteward speech recognition engine you should've initlaized at least one plugin.", "Error");
				}
			}
			else
			{
				mCore.StopAsyncRecognition();

				buttonStartStop.Text = "Turn on";
				labelStartStop.Text = "TURNED OFF";
				labelStartStop.ForeColor = Color.Red;

				recognitionEngineRunning = false;

				gridViewPlugins.Enabled = true;
			}
		}

		private void buttonBrowseForPlugin_Click(object sender, EventArgs e)
		{
			OpenFileDialog openPluginZipFileDialog = new OpenFileDialog();
			openPluginZipFileDialog.Filter = "ModernSteward Plugins|*.zip|All files|*.*";
			if (openPluginZipFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				textBoxPluginPath.Text = openPluginZipFileDialog.FileName;
				try
				{
					textBoxPluginName.Text =
						openPluginZipFileDialog.FileName.Remove(0, Path.GetDirectoryName(openPluginZipFileDialog.FileName).Length + 1);
					textBoxPluginName.Text = textBoxPluginName.Text.Remove(textBoxPluginName.Text.Length - 4, 4);
				}
				catch { }
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
					RadMessageBox.Show("An error occured while saving the profile. Please, connect to the support crew.", "Error");
					var reporter = new CrashReporter();
					reporter.Report(ex);
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

					labelStatusInStatusStrip.Text = openUserProfileFileDialog.FileName + " бе зареден успешно.";
				}
				catch (Exception ex)
				{
					RadMessageBox.Show("The file is corrupted. \nPlease, connect to the support crew.", "Error");
					var reporter = new CrashReporter();
					reporter.Report(ex);
				}
				finally
				{
					if (openedSuccessfull)
					{
						labelStatusInStatusStrip.Text = openUserProfileFileDialog.FileName + " was loaded successfully.";
					}
					else
					{
						labelStatusInStatusStrip.Text = openUserProfileFileDialog.FileName + " was loaded UNsuccessfully.";
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
				RadMessageBox.Show("You should select a plugin first!");
			}
		}

		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.WindowState = FormWindowState.Normal;
				this.ShowInTaskbar = true;
			}
			this.Activate();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
			this.ShowInTaskbar = false;
			this.notifyIcon.Visible = false;
			this.notifyIcon.Dispose();

		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.ShowInTaskbar = false;
			}
		}

		private void menuItemMacroWizard_Click(object sender, EventArgs e)
		{
			var macroWizard = new MacroWizardForm();
			macroWizard.Show();
		}
	}
}
