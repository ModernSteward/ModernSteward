using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ModernSteward
{
	[Serializable]
	public class Macro
	{
		public List<MacroEvent> Events = new List<MacroEvent>();

		public Macro()
		{
			togglingDesktopDone += new EventHandler(Macro_togglingDesktopDone);
		}

		void Macro_togglingDesktopDone(object sender, EventArgs e)
		{
			foreach (MacroEvent macroEvent in Events)
			{
				Thread.Sleep(macroEvent.TimeSinceLastEvent);

				switch (macroEvent.MacroEventType)
				{
					case MacroEventType.MouseMove:
						{
							MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;

							MouseSimulator.X = mouseArgs.X;
							MouseSimulator.Y = mouseArgs.Y;
						}
						break;
					case MacroEventType.MouseDown:
						{
							MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
							MouseSimulator.MouseDown(mouseArgs.Button);
						}
						break;
					case MacroEventType.MouseUp:
						{
							MouseEventArgs mouseArgs = (MouseEventArgs)macroEvent.EventArgs;
							MouseSimulator.MouseUp(mouseArgs.Button);
						}
						break;
					case MacroEventType.KeyDown:
						{
							KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;
							KeyboardSimulator.KeyDown(keyArgs.KeyCode);
						}
						break;
					case MacroEventType.KeyUp:
						{
							KeyEventArgs keyArgs = (KeyEventArgs)macroEvent.EventArgs;
							KeyboardSimulator.KeyUp(keyArgs.KeyCode);
						}
						break;
					default:
						break;
				}
			}
		}
		public Macro(List<MacroEvent> events)
		{
			Events = events;
			togglingDesktopDone += new EventHandler(Macro_togglingDesktopDone);
		}

		Thread threadToggleDesktop;

		private event EventHandler togglingDesktopDone;

		private void toggleDesktop()
		{
			Shell32.Shell shell = new Shell32.Shell();
			shell.ToggleDesktop();

			togglingDesktopDone(this, null);
		}

		public void Execute()
		{
			threadToggleDesktop = new Thread(new ThreadStart(toggleDesktop));

			threadToggleDesktop.Start();
		}
	}
}
