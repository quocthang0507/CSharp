using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeech
{
	class Program
	{
		static void Main(string[] args)
		{
			using (SpeechSynthesizer synth = new SpeechSynthesizer())
			{
				synth.SetOutputToDefaultAudioDevice();
				synth.Speak("Hello World");
			}
			Console.ReadKey();
		}
	}
}
