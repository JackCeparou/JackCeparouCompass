using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.DevTool
{
    public class DisplayActorsPlugin : BasePlugin, IInGameWorldPainter
    {
        public GroundLabelDecorator Decorator { get; set; }

        public DisplayActorsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new GroundLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("consolas", 10, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
            };
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (!Hud.Input.IsKeyDown(Keys.W) || layer != WorldLayer.Ground) return;

            foreach (var actor in Hud.Game.Actors)
            {
                var text = string.Format("{0} {1}", actor.SnoActor.Sno, actor.SnoActor.NameEnglish);
                Decorator.Paint(actor, actor.FloorCoordinate, text);
            }
        }
    }
}
