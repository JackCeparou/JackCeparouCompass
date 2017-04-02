namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System;

    public sealed class SoundAlert<T> where T : IActor
    {
        public Func<T, string> TextFunc { get; set; }
    }
}