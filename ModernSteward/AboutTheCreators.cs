using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace ModernSteward
{
    partial class AboutTheCreators : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Creates a "about" form
        /// </summary>
        /// <param name="aCurrentVersion">The current version of the application</param>
        public AboutTheCreators(string aCurrentVersion)
        {
            InitializeComponent();
            this.radLabelProductName.Text = "ModernSteward";
            this.radLabelVersion.Text = String.Format("Version {0}", aCurrentVersion);

            string AssemblyDescription = "";

            this.radTextBoxDescription.Text = AssemblyDescription;
        }
    }
}
