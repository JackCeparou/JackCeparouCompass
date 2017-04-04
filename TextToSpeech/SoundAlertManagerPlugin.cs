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
            if (Speak<IMonster>(monster))
                return;

            var actor = Hud.Game.Actors.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IActor>>() != null);
            if (Speak<IActor>(actor))
                return;

            var item = Hud.Game.Items.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IItem>>() != null);
            if (Speak<IItem>(item))
                return;

            var shrine = Hud.Game.Shrines.FirstOrDefault(a => a.LastSpeak != null && !a.LastSpeak.IsRunning && a.GetData<SoundAlert<IShrine>>() != null);
            if (Speak<IShrine>(shrine))
                return;
        }

        public bool Speak<T>(T actor) where T : IActor
        {
            if (actor == null)
                return false;

            if (!Hud.LastSpeak.IsRunning)
                Hud.LastSpeak.Restart();

            var data = actor.GetData<SoundAlert<T>>();
            var text = data.TextFunc == null ? actor.SnoActor.NameLocalized : data.TextFunc(actor);
            actor.LastSpeak.Restart();
            Hud.Speak(text);
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
