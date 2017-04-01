namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Decorators;

    public class SoundAlertManagerPlugin : BasePlugin, IAfterCollectHandler
    {
        public int SoundAlertMaxRate { get; set; }

        public SoundAlertManagerPlugin()
        {
            Enabled = true;
            SoundAlertMaxRate = 5000;
        }

        public void AfterCollect()
        {
            if (Hud.LastSpeak.ElapsedMilliseconds != 0 && !Hud.LastSpeak.TimerTest(SoundAlertMaxRate)) return;

            var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlertDecorator>() != null);
            if (actor != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = actor.GetData<SoundAlertDecorator>();
                var text = data.TextFunc == null ? data.LastText : data.TextFunc(actor);
                actor.LastSpeak.Restart();
                Hud.Speak(text);
            }
        }

        public static void Register(IActor actor)
        {
            
        }
    }
}