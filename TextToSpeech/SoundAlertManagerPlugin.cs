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

            var monster = Hud.Game.AliveMonsters.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IMonster>>() != null);
            if (monster != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = monster.GetData<SoundAlert<IMonster>>();
                var text = data.TextFunc == null ? string.Empty : data.TextFunc(monster);
                monster.LastSpeak.Restart();
                Hud.Speak(text);
                return;
            }

            var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IActor>>() != null);
            if (actor != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = actor.GetData<SoundAlert<IActor>>();
                var text = data.TextFunc == null ? string.Empty : data.TextFunc(actor);
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
                var text = data.TextFunc == null ? string.Empty : data.TextFunc(item);
                item.LastSpeak.Restart();
                Hud.Speak(text);
                return;
            }

            var shrine = Hud.Game.Shrines.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IShrine>>() != null);
            if (shrine != null)
            {
                if (!Hud.LastSpeak.IsRunning)
                    Hud.LastSpeak.Restart();

                var data = shrine.GetData<SoundAlert<IShrine>>();
                var text = data.TextFunc == null ? string.Empty : data.TextFunc(shrine);
                shrine.LastSpeak.Restart();
                Hud.Speak(text);
                return;
            }
        }

        public static void Register(IActor actor)
        {
            if (actor.LastSpeak != null) return;

            actor.LastSpeak = _hud.CreateWatch();
        }

        public static void Register<T>(IActor actor, SoundAlert<T> soundAlert = null) where T : IActor
        {
            if (actor.LastSpeak != null) return;
            actor.LastSpeak = _hud.CreateWatch();

            if (actor.GetData<SoundAlert<T>>() == null)
                actor.SetData<SoundAlert<T>>(soundAlert ?? SoundAlertFactory.Create<T>((a) => a.SnoActor.NameLocalized));
        }
    }
}
