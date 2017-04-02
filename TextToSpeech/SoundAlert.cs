namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System;

    public class SoundAlert<T> where T : IActor
    {
        public Func<T, string> TextFunc { get; set; }
    }
}