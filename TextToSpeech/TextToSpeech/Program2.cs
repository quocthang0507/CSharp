using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.AudioFormat;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TextToSpeech
{
	public class Program2
	{
		public static void Main2(string[] args)
		{

			// Initialize a new instance of the SpeechSynthesizer.  
			using (SpeechSynthesizer synth = new SpeechSynthesizer())
			{

				// Get information about supported audio formats.  
				string AudioFormats = "";
				foreach (SpeechAudioFormatInfo fmt in synth.Voice.SupportedAudioFormats)
				{
					AudioFormats += String.Format("{0}\n",
					fmt.EncodingFormat.ToString());
				}

				// Write information about the voice to the console.  
				Console.WriteLine(" Name:          " + synth.Voice.Name);
				Console.WriteLine(" Culture:       " + synth.Voice.Culture);
				Console.WriteLine(" Age:           " + synth.Voice.Age);
				Console.WriteLine(" Gender:        " + synth.Voice.Gender);
				Console.WriteLine(" Description:   " + synth.Voice.Description);
				Console.WriteLine(" ID:            " + synth.Voice.Id);
				if (synth.Voice.SupportedAudioFormats.Count != 0)
				{
					Console.WriteLine(" Audio formats: " + AudioFormats);
				}
				else
				{
					Console.WriteLine(" No supported audio formats found");
				}

				// Get additional information about the voice.  
				string AdditionalInfo = "";
				foreach (string key in synth.Voice.AdditionalInfo.Keys)
				{
					AdditionalInfo += String.Format("  {0}: {1}\n",
					  key, synth.Voice.AdditionalInfo[key]);
				}

				Console.WriteLine(" Additional Info - " + AdditionalInfo);
				Console.WriteLine();
			}

			Console.WriteLine();
			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}
	}
}
