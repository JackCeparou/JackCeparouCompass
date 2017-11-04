namespace Turbo.Plugins.Jack.TextToSpeech
{
    using System;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class SoundAlertManagerPlugin : BasePlugin, IAfterCollectHandler
    {
        public int SoundAlertMaxRate { get; set; }

        private static IController _hud;
        private int step;

        public SoundAlertManagerPlugin()
        {
            Enabled = true;
            Order = int.MaxValue / 2;
            SoundAlertMaxRate = 2000;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            _hud = hud;
        }

        public void AfterCollect()
        {
            if (!Hud.Game.IsInGame) return;
            if (Hud.Sound.LastSpeak.ElapsedMilliseconds != 0 && !Hud.Sound.LastSpeak.TimerTest(SoundAlertMaxRate)) return;

            //var monster = Hud.Game.AliveMonsters.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IMonster>>() != null);
            //if (Speak<IMonster>(monster))
            //    return;
            //var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IActor>>() != null);
            //if (Speak<IActor>(actor))
            //    return;
            //var item = Hud.Game.Items.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IItem>>() != null);
            //if (Speak<IItem>(item))
            //    return;
            //var shrine = Hud.Game.Shrines.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IShrine>>() != null);
            //if (Speak<IShrine>(shrine))
            //    return;

            switch (step)
            {
                case 0:
                    var monster = Hud.Game.AliveMonsters.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IMonster>>() != null);
                    Speak<IMonster>(monster);
                    break;

                case 1:
                    var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IActor>>() != null);
                    Speak<IActor>(actor);
                    break;

                case 2:
                    var item = Hud.Game.Items.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IItem>>() != null);
                    Speak<IItem>(item);
                    break;

                case 3:
                    var shrine = Hud.Game.Shrines.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IShrine>>() != null);
                    Speak<IShrine>(shrine);
                    break;

                default:
                    break;
            }

            step = ++step % 4;
        }

        public bool Speak<T>(T actor) where T : IActor
        {
            if (actor == null)
                return false;

            if (!Hud.Sound.LastSpeak.IsRunning)
                Hud.Sound.LastSpeak.Restart();

            var data = actor.GetData<SoundAlert<T>>();
            var text = data.TextFunc == null ? actor.SnoActor.NameLocalized : data.TextFunc(actor);
            if (!string.IsNullOrWhiteSpace(text))
            {
                actor.LastSpeak.Restart();
                Hud.Sound.Speak(text); 
            }
            return true;
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