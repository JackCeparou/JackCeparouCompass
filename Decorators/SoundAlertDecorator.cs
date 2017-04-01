namespace Turbo.Plugins.Jack.Decorators
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class SoundAlertDecorator : IWorldDecorator
    {
        public bool Enabled { get; set; }
        public IController Hud { get; private set; }
        public WorldLayer Layer { get; private set; }

        public Func<IActor, string> TextFunc { get; set; }
        public string LastText { get; private set; }

        public SoundAlertDecorator(IController hud)
        {
            Hud = hud;
            Enabled = true;
            Layer = WorldLayer.Ground;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (actor == null) return;
            LastText = text;
            if (actor.LastSpeak != null) return;

            // register for sound play
            actor.LastSpeak = Hud.CreateWatch();

            if (actor.GetData<SoundAlertDecorator>() == null)
                actor.SetData<SoundAlertDecorator>(this);
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield break;
        }
    }
}