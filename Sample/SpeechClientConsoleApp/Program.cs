using System;
using System.IO;
using System.Threading.Tasks;
using SpeechClient.Models.Speech;

namespace SpeechClientConsoleApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Initializes the speech client.
            var speechClient = new SpeechClient.SpeechClient(SpeechClientConfiguration.SpeechRegion, SpeechClientConfiguration.SpeechSubscriptionKey);

            Console.WriteLine("Calling Speech Service for speech-to-text (using a sample file)...\n");
            using (var fileStream = File.OpenRead(@"SpeechSample.wav"))
            {
                var response = await speechClient.RecognizeAsync(fileStream, "en-US", RecognitionResultFormatEnum.Detailed);
                Console.WriteLine($"Recognition Result: {response.RecognitionStatus}");
                Console.WriteLine(response.DisplayText);
            }

            await speechClient.SpeakAsync(new TextToSpeechParameters
            {
                Language = "en-US",
                VoiceType = GenderEnum.Female,
                VoiceName = "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)",
                Text = "Hello everyone! Today is really a beautiful day.",
            });
        }
    }
}
