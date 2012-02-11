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
            this.radLabelProductName.Text = "Модерният иконом";
            this.radLabelVersion.Text = String.Format("Версия {0}", aCurrentVersion);

            string AssemblyDescription = "";

            this.radTextBoxDescription.Text = AssemblyDescription;
        }
    }
}
