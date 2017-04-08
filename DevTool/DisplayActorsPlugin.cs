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
        public Keys HotKey { get; set; }
        public GroundLabelDecorator Decorator { get; set; }

        public DisplayActorsPlugin()
        {
            Enabled = true;
            HotKey = Keys.W;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Decorator = new GroundLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("consolas", 8, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
            };
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (!Hud.Input.IsKeyDown(HotKey) || layer != WorldLayer.Ground) return;

            foreach (var actor in Hud.Game.Actors)
            {
                var text = string.Format("{0} : {1} {2}\n{3}, {4}, {5}\n{6}",
                    actor.SnoActor.Sno,
                    actor.SnoActor.NameLocalized,
                    actor.SnoActor.Kind,
                    actor.IsOperated ? "Operated" : "!Operated",
                    actor.IsClickable ? "Clickable" : "!Clickable",
                    actor.IsDisabled ? "Disabled" : "!Disabled",
                    actor.SnoActor.Code);
                Decorator.Paint(actor, actor.FloorCoordinate, text);
            }
        }
    }
}
