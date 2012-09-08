using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ModernSteward
{
	[Serializable]
	public class MyMouseEventArgs : EventArgs
	{
		public MyMouseEventArgs(MouseButtons button, int clicks, int x, int y, int delta)
		{
			_Button = button;
			_Clicks = clicks;
			_X = x;
			_Y = y;
			_Delta = delta;
		}

		private MouseButtons _Button;
		private int _Clicks;
		private int _Delta;
		private int _X;
		private int _Y;

		public MouseButtons Button { get { return _Button; } }
		public int Clicks { get { return _Clicks; } }
		public int Delta { get { return _Delta; } }
		public Point Location { get { return new Point(_X, _Y); } }
		public int X { get { return _X; } }
		public int Y { get { return _Y; } }

		public MyMouseEventArgs(MouseEventArgs e)
		{
			_Button = e.Button;
			_Clicks = e.Clicks;
			_X = e.X;
			_Y = e.Y;
			_Delta = e.Delta;
		}

		public static implicit operator MyMouseEventArgs(MouseEventArgs e)
		{
			return new MyMouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
		}
		public static implicit operator MouseEventArgs(MyMouseEventArgs e)
		{
			return new MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, e.Delta);
		}
	}
}
