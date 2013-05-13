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
    public partial class MasterDictionaryForm : Telerik.WinControls.UI.RadForm
    {
        public MasterDictionaryForm()
        {
            InitializeComponent();

			this.MaximumSize = this.Size;
			this.MinimumSize = this.Size;
        }
    }
}
