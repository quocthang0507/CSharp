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
		private const string terminal = "Type your English sentence ('exit' to exit): ";
		private const string introduction = "Welcome to Text To Speech Console Application";
		private const string goodbye = "Good bye!";

		static void Main(string[] args)
		{
			Program2.Main2(args);
		}

		public static void Main1(string[] args)
		{
			// Initialize a new instance of the SpeechSynthesizer.  
			using (SpeechSynthesizer synth = new SpeechSynthesizer())
			{
				SetUpSpeech(synth);
				Console.WriteLine(introduction);
				synth.Speak(introduction);
				while (true)
				{
					Console.Write(terminal);
					synth.Speak(terminal);
					string text = Console.ReadLine();
					if (text == "exit")
					{
						Console.WriteLine(goodbye);
						synth.Speak(goodbye);
						break;
					}
					synth.Speak(text);
				}
			}
			Console.ReadKey();
		}

		static void SetUpSpeech(SpeechSynthesizer synth)
		{
			// Configure the audio output
			synth.SetOutputToDefaultAudioDevice();
			Console.WriteLine("What gender would you like to speak?");
			Console.WriteLine("1. Male\n2. Female\n3. Neutral");
			int voiceIndex = Convert.ToInt32(Console.ReadLine());
			if (voiceIndex == 1 || voiceIndex == 2 || voiceIndex == 3)
				synth.SelectVoiceByHints((VoiceGender)voiceIndex);
		}
	}
}
