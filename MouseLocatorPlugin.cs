using Turbo.Plugins.Default;
using Turbo.Plugins.JackCeparouCompass.Decorator;

namespace Turbo.Plugins.JackCeparouCompass
{
    public class MouseLocatorPlugin : BasePlugin
    {
        public TopCircleDecorator MouseDecorator { get; set; }

        public MouseLocatorPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            MouseDecorator = new TopCircleDecorator(hud)
            {
                Brush = Hud.Render.CreateBrush(178, 255, 255, 255, 5),
                HasShadow = true,
                Radius = 31,
                //RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250) { RadiusMinimumMultiplier = 1f, RadiusMaximumMultiplier = 1.4f },
            };
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            //if (Hud.InTown) return;
            if (clipState != ClipState.BeforeClip) return;

            MouseDecorator.Paint(Hud.Window.CursorX, Hud.Window.CursorY);
        }
    }
}