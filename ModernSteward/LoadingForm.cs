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

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Email = textBoxEmail.Text;
            Password = textBoxPassword.Text;

			WebControlManager webControl = new WebControlManager(Email, Password);
			if (webControl.Login())
			{
				var listInstalledPlugins = webControl.GetInstalled();
				foreach (var webPlugin in listInstalledPlugins)
				{
					string innerPluginDirectoryPath = "";
					Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins");
					Directory.CreateDirectory(Environment.CurrentDirectory + @"\Plugins\" + webPlugin.Name);
					innerPluginDirectoryPath = Environment.CurrentDirectory + @"\Plugins\" + webPlugin.Name + @"\";

					if (webPlugin.Download(innerPluginDirectoryPath))
					{
						DownloadedPlugins.Add(webPlugin);
					}
				}
			}

            this.Close();
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
	}
}
