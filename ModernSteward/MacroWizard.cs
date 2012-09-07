using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModernSteward
{
	public partial class MacroWizardForm : Telerik.WinControls.UI.RadForm
	{
		Macro macro = new Macro();

		int lastTimeRecorded = 0;

		MouseHook mouseHook = new MouseHook();
		KeyboardHook keyboardHook = new KeyboardHook();

		public MacroWizardForm()
		{
			InitializeComponent();

			mouseHook = new MouseHook();
			keyboardHook = new KeyboardHook();

			mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
			mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
			mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);

			keyboardHook.KeyDown += new KeyEventHandler(keyboardHook_KeyDown);
			keyboardHook.KeyUp += new KeyEventHandler(keyboardHook_KeyUp);

			showFormBackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(showFormBackgroundWorker_RunWorkerCompleted);
		}

		void showFormBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Show();
			this.WindowState = FormWindowState.Normal;
		}



		private void buttonRecord_Click(object sender, EventArgs e)
		{
			Shell32.Shell shell = new Shell32.Shell();
			shell.MinimizeAll();

			macro.Events.Clear();
			lastTimeRecorded = Environment.TickCount;

			keyboardHook.Start();
			mouseHook.Start();
		}

		void mouseHook_MouseMove(object sender, MouseEventArgs e)
		{
			macro.Events.Add(
				new MacroEvent(
					MacroEventType.MouseMove,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;

		}

		void mouseHook_MouseDown(object sender, MouseEventArgs e)
		{
			macro.Events.Add(
				new MacroEvent(
					MacroEventType.MouseDown,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		void mouseHook_MouseUp(object sender, MouseEventArgs e)
		{
			macro.Events.Add(
				new MacroEvent(
					MacroEventType.MouseUp,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;

		}

		void keyboardHook_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Escape)
			{
				macro.Events.Add(
					new MacroEvent(
						MacroEventType.KeyDown,
						e,
						Environment.TickCount - lastTimeRecorded
					));
				lastTimeRecorded = Environment.TickCount;
			}
			else
			{
				StopRecording();
			}
		}


		BackgroundWorker showFormBackgroundWorker = new BackgroundWorker();

		private void StopRecording()
		{
			keyboardHook.Stop();
			mouseHook.Stop();

			showFormBackgroundWorker.RunWorkerAsync();

			labelStatus.Text = "Macro recorded!";
		}

		void keyboardHook_KeyUp(object sender, KeyEventArgs e)
		{
			macro.Events.Add(
				new MacroEvent(
					MacroEventType.KeyUp,
					e,
					Environment.TickCount - lastTimeRecorded
				));

			lastTimeRecorded = Environment.TickCount;
		}

		private void radButton1_Click(object sender, EventArgs e)
		{
			macro.Execute();
		}

	}
}
