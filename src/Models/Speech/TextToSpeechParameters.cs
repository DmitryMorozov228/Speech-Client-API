﻿using System.Collections.Generic;

namespace SpeechClient.Models.Speech
{
    /// <summary>
    /// Inputs Options for the TTS Service.
    /// </summary>
    public class TextToSpeechParameters
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextToSpeechParameters"/> class.
        /// </summary>
        /// <seealso cref="SpeechClient"/>
        public TextToSpeechParameters()
        {
            Language = "en-us";
            VoiceName = "Microsoft Server Speech Text to Speech Voice (en-US, ZiraRUS)";
            // Default to Riff16Khz16BitMonoPcm output format.
            OutputFormat = AudioOutputFormatEnum.Riff16Khz16BitMonoPcm;
        }

        /// <summary>
        /// Gets or sets the audio output format.
        /// </summary>
        public AudioOutputFormatEnum OutputFormat { get; set; }

        /// <summary>
        /// Gets or sets the language of the text.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the type of the voice: male/female.
        /// </summary>
        public GenderEnum VoiceType { get; set; }

        /// <summary>
        /// Gets or sets the name of the voice.
        /// </summary>
        /// <remarks>Voices list is available at https://docs.microsoft.com/en-us/azure/cognitive-services/speech-service/supported-languages#text-to-speech.
        /// </remarks>
        public string VoiceName { get; set; }

        /// <summary>
        /// Gets or sets the text to speech.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        internal IEnumerable<KeyValuePair<string, string>> Headers
        {
            get
            {
                var toReturn = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("Content-Type", "application/ssml+xml")
                    };

                string outputFormat;
                switch (OutputFormat)
                {
                    case AudioOutputFormatEnum.Raw16Khz16BitMonoPcm:
                        outputFormat = "raw-16khz-16bit-mono-pcm";
                        break;

                    case AudioOutputFormatEnum.Raw8Khz8BitMonoMULaw:
                        outputFormat = "raw-8khz-8bit-mono-mulaw";
                        break;

                    case AudioOutputFormatEnum.Riff16Khz16BitMonoPcm:
                        outputFormat = "riff-16khz-16bit-mono-pcm";
                        break;

                    case AudioOutputFormatEnum.Riff8Khz8BitMonoMULaw:
                        outputFormat = "riff-8khz-8bit-mono-mulaw";
                        break;

                    case AudioOutputFormatEnum.Ssml16Khz16BitMonoSilk:
                        outputFormat = "ssml-16khz-16bit-mono-silk";
                        break;

                    case AudioOutputFormatEnum.Raw16Khz16BitMonoTrueSilk:
                        outputFormat = "raw-16khz-16bit-mono-truesilk";
                        break;

                    case AudioOutputFormatEnum.Ssml16Khz16BitMonoTts:
                        outputFormat = "ssml-16khz-16bit-mono-tts";
                        break;

                    case AudioOutputFormatEnum.Audio16Khz128KBitRateMonoMp3:
                        outputFormat = "audio-16khz-128kbitrate-mono-mp3";
                        break;

                    case AudioOutputFormatEnum.Audio16Khz64KBitRateMonoMp3:
                        outputFormat = "audio-16khz-64kbitrate-mono-mp3";
                        break;

                    case AudioOutputFormatEnum.Audio16Khz32KBitRateMonoMp3:
                        outputFormat = "audio-16khz-32kbitrate-mono-mp3";
                        break;

                    case AudioOutputFormatEnum.Audio16Khz16KbpsMonoSiren:
                        outputFormat = "audio-16khz-16kbps-mono-siren";
                        break;

                    case AudioOutputFormatEnum.Riff16Khz16KbpsMonoSiren:
                        outputFormat = "riff-16khz-16kbps-mono-siren";
                        break;

                    case AudioOutputFormatEnum.Raw24Khz16BitMonoPcm:
                        outputFormat = "raw-24khz-16bit-mono-pcm";
                        break;

                    case AudioOutputFormatEnum.Riff24Khz16BitMonoPcm:
                        outputFormat = "riff-24khz-16bit-mono-pcm";
                        break;

                    case AudioOutputFormatEnum.Audio24Khz48KBitRateMonoMp3:
                        outputFormat = "audio-24khz-48kbitrate-mono-mp3";
                        break;

                    case AudioOutputFormatEnum.Audio24Khz96KBitRateMonoMp3:
                        outputFormat = "audio-24khz-96kbitrate-mono-mp3";
                        break;

                    case AudioOutputFormatEnum.Audio24Khz160KBitRateMonoMp3:
                        outputFormat = "audio-24khz-160kbitrate-mono-mp3";
                        break;

                    default:
                        outputFormat = "riff-16khz-16bit-mono-pcm";
                        break;
                }

                toReturn.Add(new KeyValuePair<string, string>("X-Microsoft-OutputFormat", outputFormat));
                // The software originating the request
                toReturn.Add(new KeyValuePair<string, string>("User-Agent", "TextToSpeechClient"));

                return toReturn;
            }
            set
            {
                Headers = value;
            }
        }
    }
}