namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System;
    using Turbo.Plugins.Jack.Decorators;

    public class SoundAlertFactory
    {
        public static SoundAlert<T> Create<T>(Func<T, string> textFunc) where T : IActor
        {
            return new SoundAlert<T>() { TextFunc = textFunc };
        }

        public static SoundAlertDecorator<U> Create<U>(IController hud, Func<U, string> textFunc = null) where U : IActor
        {
            var soundAlert = Create(textFunc ?? new Func<U, string>((actor) => actor.SnoActor.NameLocalized));
            return new SoundAlertDecorator<U>(hud, soundAlert);
        }
    }
}