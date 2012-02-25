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
			this.StartPosition = FormStartPosition.CenterScreen;
        }

		public void ShowLoadingForm()
		{
			this.Show();
			System.Threading.Thread.Sleep(4000);
		}

		public void CloseLoadingForm()
		{
			this.Close();
		}
    }
}
