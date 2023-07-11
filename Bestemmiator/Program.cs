using Bestemmiator.Grammar;
using Bestemmiator.Imaging;
using Bestemmiator.Resources;
using System;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;

//SpeechSynthesizer ttssynthesizer = new SpeechSynthesizer();
//using (var speaker = new SpeechSynthesizer()) {
//  speaker.Voice = (SpeechSynthesizer.AllVoices.First(x => x.Gender == VoiceGender.Female && x.Language.Contains("ES")) );
//  ttssynthesizer.Voice = speaker.Voice;
//}...

namespace Bestemmiator
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                Random rand = new Random();

                VoiceInfo[] voices = (from v in synth.GetInstalledVoices()
                                      where v.VoiceInfo.Culture.Name.Contains("it")
                                      select v.VoiceInfo).ToArray();

                Console.WriteLine($"Found {voices.Length} Italian Voices");
                synth.SelectVoice(voices.First().Name);
                                
                while (true)
                {
                    int level = int.Parse(Console.ReadLine()); //1 - 27

                    using (Bitmap bmp = ResourceLoader.GetRandomImage())
                    {                        
                        string text = new Generator().Get(level);

                        ConsoleDrawer.WriteImage(bmp);
                        Console.WriteLine(text);
                        synth.Speak(text);
                    }
                }
            }
        }
    }
}

//PromptBuilder builder = new PromptBuilder();
//builder.AppendText(text);
//synth.SetOutputToWaveFile("disappunto.wav", new SpeechAudioFormatInfo(32000, AudioBitsPerSample.Sixteen, AudioChannel.Mono));
//synth.Speak(builder);

