using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Decorators
{
    // this is not a plugin, just a helper class to display shapes on the minimap
    public class MapCustomLabelDecorator : IWorldDecorator
    {
        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; private set; }

        public IFont LabelFont { get; set; }
        public bool Up { get; set; }
        public float RadiusOffset { get; set; }

        public StringGeneratorFunc TextFunc { get; set; }

        public MapCustomLabelDecorator(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Map;
            Hud = hud;

            Up = false;
        }

        public MapCustomLabelDecorator(IController hud, string text) : this(hud)
        {
            TextFunc = () => text;
        }

        public MapCustomLabelDecorator(IController hud, StringGeneratorFunc textFunc) : this(hud)
        {
            TextFunc = textFunc;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (LabelFont == null) return;
            if (TextFunc != null) text = TextFunc.Invoke();
            if (string.IsNullOrEmpty(text)) return;

            float mapx, mapy;
            Hud.Render.GetMinimapCoordinates(coord.X, coord.Y, out mapx, out mapy);

            var layout = LabelFont.GetTextLayout(text);
            if (!Up)
            {
                LabelFont.DrawText(layout, mapx - layout.Metrics.Width / 2, mapy + RadiusOffset);
            }
            else
            {
                LabelFont.DrawText(layout, mapx - layout.Metrics.Width / 2, mapy - RadiusOffset - layout.Metrics.Height);
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield break;
        }
    }
}