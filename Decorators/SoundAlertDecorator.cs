namespace Turbo.Plugins.Jack.Decorators
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.TextToSpeech;

    public class SoundAlertDecorator : IWorldDecorator
    {
        public bool Enabled { get; set; }
        public IController Hud { get; private set; }
        public WorldLayer Layer { get; private set; }

        public SoundAlert<IActor> SoundAlert { get; private set; }

        public Func<IActor, string> TextFunc {
            get { return SoundAlert.TextFunc; }
            set { SoundAlert.TextFunc = value; }
        }
        public string LastText
        {
            get { return SoundAlert.LastText; }
            private set { SoundAlert.LastText = value; }
        }

        public SoundAlertDecorator(IController hud)
        {
            Hud = hud;
            Enabled = true;
            Layer = WorldLayer.Ground;

            SoundAlert = new SoundAlert<IActor>();
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (actor == null) return;

            LastText = text;

            //if (actor.LastSpeak != null) return;

            // register for sound play
            SoundAlertManagerPlugin.Register(actor);
            if (actor.GetData<SoundAlert<IActor>>() == null)
                actor.SetData<SoundAlert<IActor>>(SoundAlert);
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield break;
        }
    }
}