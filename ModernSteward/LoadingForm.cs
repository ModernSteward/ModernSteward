using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace ModernSteward
{
    public partial class LoadingForm : Telerik.WinControls.UI.RadForm
    {
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
                textBoxPasswordEntered = true;
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
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            WebControlManager webControl = new WebControlManager(email, password);

            //TODO: Download the users' plugins and add them

            this.Close();
        }

        private void buttonOfflineMode_Click(object sender, EventArgs e)
        {
            //TODO: Maybe it will need some additional information e.g. advanced mode 
            //for the plugin rights distribution system

            this.Close();
        }
    }
}
