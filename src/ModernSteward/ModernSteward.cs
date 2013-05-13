using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ModernSteward
{
    static class ModernSteward
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				Application.Run(new MainForm());
			}
			catch (ObjectDisposedException)
			{

			}
		}
    }
}
