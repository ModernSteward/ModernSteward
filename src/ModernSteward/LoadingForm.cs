using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using WebControl;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace ModernSteward
{
    public partial class LoadingForm : Telerik.WinControls.UI.RadForm
    {
		public List<WebPlugin> DownloadedPlugins = new List<WebPlugin>();
		public OperatingMode Mode = OperatingMode.OnlineNormal;

        public LoadingForm()
        {
            InitializeComponent();
            
            this.Width = 520;
			this.Height = 325;

			this.StartPosition = FormStartPosition.CenterScreen;
        }

        bool textBoxEmailEntered = false;
        bool textBoxPasswordEntered = false;

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            if (!textBoxEmailEntered)
            {
                textBoxEmail.Text = "";
				textBoxEmailEntered = true;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            if (!textBoxPasswordEntered)
            {
                textBoxPassword.Text = "";
                textBoxPasswordEntered = true;
            }
        }

		public WebControlManager WebControl;


		private void DownloadPlugins()
		{
			//this.Invoke(new MethodInvoker(Close));

			Email = textBoxEmail.Text;
			Password = textBoxPassword.Text;

			WebControl = new WebControlManager(Email, Password);
			if (WebControl.Login())
			{
				var listInstalledPlugins = WebControl.GetInstalled();
				foreach (var webPlugin in listInstalledPlugins)
				{
					string innerPluginDirectoryPath = "";
					Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins");
					Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins\" + webPlugin.Name);
					innerPluginDirectoryPath = Environment.CurrentDirectory + @"\Plugins\" + webPlugin.Name + @"\" + webPlugin.Name + ".zip";
					webPlugin.LocalFilepath = innerPluginDirectoryPath;

					if (webPlugin.Download(innerPluginDirectoryPath))
					{
						DownloadedPlugins.Add(webPlugin);
					}
				}
				this.Invoke(new MethodInvoker(Close));
			}
			else
			{
				this.Invoke(new MethodInvoker(ShowLoginNotSuccessfulMessageBox));
			}
		}

		private void ShowLoginNotSuccessfulMessageBox()
		{
			waitingBarDownloadingPlugins.StopWaiting();
			waitingBarDownloadingPlugins.Visible = false;

			buttonLogin.Enabled = true;
			textBoxEmail.Enabled = true;
			textBoxPassword.Enabled = true;

			RadMessageBox.Show("Login not successful! ");
		}

        private void buttonLogin_Click(object sender, EventArgs e)
        {
			buttonLogin.Enabled = false;
			textBoxEmail.Enabled = false;
			textBoxPassword.Enabled = false;
			waitingBarDownloadingPlugins.Visible = true;
			waitingBarDownloadingPlugins.StartWaiting();

			Task taskDownloadPlugins = new Task(DownloadPlugins);
			taskDownloadPlugins.Start();
        }

        private void buttonOfflineMode_Click(object sender, EventArgs e)
        {
			Mode = OperatingMode.OfflineAdvanced;

            this.Close();
        }

		private void LoadingForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (Mode != OperatingMode.OfflineAdvanced) // hack -  When the Offline button is clicked, the mode changes to OfflineAdvanced. Because the initalization value of Mode is OnlineNormal this way we are checking wether the buttonOfflineMode or the buttonLogin was clicked 
			{
				if (checkBoxGeneralPluginControl.Checked)
				{
					Mode = OperatingMode.OnlineAdvanced;
				}
			}
		}

		public string Email { get; set; }

		public string Password { get; set; }

		private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				buttonLogin_Click(this, new EventArgs());
			}
		}
	}
}
