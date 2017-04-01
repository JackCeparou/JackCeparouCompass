namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SoundAlertManagerPlugin : BasePlugin, IAfterCollectHandler
    {
        public int SoundAlertMaxRate { get; set; }

        private static IController _hud;

        public SoundAlertManagerPlugin()
        {
            Enabled = true;
            SoundAlertMaxRate = 2000;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            _hud = hud;
        }

        public void AfterCollect()
        {
            if (Hud.LastSpeak.ElapsedMilliseconds != 0 && !Hud.LastSpeak.TimerTest(SoundAlertMaxRate)) return;

            var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IActor>>() != null);
            if (actor != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = actor.GetData<SoundAlert<IActor>>();
                var text = data.TextFunc == null ? data.LastText : data.TextFunc(actor);
                actor.LastSpeak.Restart();
                Hud.Speak(text);
                return;
            }

            var item = Hud.Game.Items.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IItem>>() != null);
            if (item != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = item.GetData<SoundAlert<IItem>>();
                var text = data.TextFunc == null ? data.LastText : data.TextFunc(item);
                item.LastSpeak.Restart();
                Hud.Speak(text);
                return;
            }
        }

        public static void Register(IActor actor)
        {
            if (actor.LastSpeak != null) return;

            actor.LastSpeak = _hud.CreateWatch();
            //actor.LastSpeak.Restart();
        }
    }
}