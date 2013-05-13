using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;

namespace ModernSteward
{
	public static class Melissa
	{
		public static void Say(string text)
		{
			SpeechSynthesizer s = new SpeechSynthesizer();
			s.Speak(text);
		}
	}
}
