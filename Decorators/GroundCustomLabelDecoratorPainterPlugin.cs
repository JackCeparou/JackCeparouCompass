using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

// this is an adaptation by Jack of a default hud plugin, all credits to KillerJohn
namespace Turbo.Plugins.Jack.Decorators
{
    // - all GroundLabelDecorators are registering here instead of painting themselves
    // - at PaintWorldFinished step this plugin will collect, and group all GroundLabelDecorators, and adjust them
    // - after adjustment, all GroundLabelDecorators are painted at the same time
    public class GroundCustomLabelDecoratorPainterPlugin : BasePlugin, IInGameWorldPainter
    {
        public float Padding { get; set; }
        public float ScreenBorderPadding { get; set; }

        private Dictionary<IWorldCoordinate, List<RegisteredLabel>> _registeredLabels = new Dictionary<IWorldCoordinate, List<RegisteredLabel>>();

        public GroundCustomLabelDecoratorPainterPlugin()
        {
            Enabled = true;
            Padding = 0.002f;
            ScreenBorderPadding = 0.01f;
        }

        public override void Load(IController hud)
        {
            Order = int.MaxValue;
            base.Load(hud);
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (layer != WorldLayer.Ground) return;

            var groundRect = Hud.Window.GroundRectangle;
            var padding = Hud.Window.Size.Height * Padding;
            var screenBorderPadding = Hud.Window.Size.Height * ScreenBorderPadding;

            foreach (var kvp in _registeredLabels)
            {
                var coord = kvp.Key;
                var list = kvp.Value;

                var tw = 0.0f;
                var sc = coord.ToScreenCoordinate(true, true);
                var maxH = 0.0f;

                foreach (var regLabel in list)
                {
                    var layout = regLabel.Decorator.TextFont.GetTextLayout(regLabel.Text);
                    var w = layout.Metrics.Width + padding * 6;
                    tw += w;
                    if (layout.Metrics.Height > maxH) maxH = layout.Metrics.Height;
                }

                var forceOnScreen = list.Any(regLabel => regLabel.Decorator.ForceOnScreen);

                var x = sc.X - tw / 2;
                if (forceOnScreen)
                {
                    x = Math.Max(screenBorderPadding, Math.Min(x, groundRect.Width - screenBorderPadding - tw));
                }

                foreach (var regLabel in list)
                {
                    var layout = regLabel.Decorator.TextFont.GetTextLayout(regLabel.Text);
                    var w = layout.Metrics.Width + padding * 6;
                    var h = layout.Metrics.Height + padding * 2;

                    var y = regLabel.Decorator.CenterBaseLine ? sc.Y - layout.Metrics.Height / 2 : sc.Y + (maxH - layout.Metrics.Height) / 2;

                    if (forceOnScreen)
                    {
                        y = Math.Max(screenBorderPadding, Math.Min(y, groundRect.Bottom - screenBorderPadding - h));
                    }

                    var rect = new SharpDX.RectangleF(x + regLabel.Decorator.OffsetX, y + regLabel.Decorator.OffsetY - padding, w, h);

                    if (regLabel.Decorator.BackgroundTexture1 != null)
                    {
                        regLabel.Decorator.BackgroundTexture1.Draw(rect, regLabel.Decorator.BackgroundTextureOpacity1);
                    }

                    if (regLabel.Decorator.BackgroundTexture2 != null)
                    {
                        regLabel.Decorator.BackgroundTexture2.Draw(rect, regLabel.Decorator.BackgroundTextureOpacity2);
                    }

                    if (regLabel.Decorator.BackgroundBrush != null)
                    {
                        regLabel.Decorator.BackgroundBrush.DrawRectangle(rect);
                    }

                    regLabel.Decorator.TextFont.DrawText(layout, x + regLabel.Decorator.OffsetX + padding * 3, y + regLabel.Decorator.OffsetY);

                    if (regLabel.Decorator.BorderBrush != null)
                    {
                        regLabel.Decorator.BorderBrush.DrawRectangle(rect);
                    }

                    x += w;
                }
            }

            _registeredLabels.Clear();
        }

        internal void EnqueLabelForPaint(GroundCustomLabelDecorator decorator, IWorldCoordinate coord, string text)
        {
            if (string.IsNullOrEmpty(text)) return;

            List<RegisteredLabel> list;
            if (!_registeredLabels.TryGetValue(coord, out list))
            {
                list = new List<RegisteredLabel>();
                _registeredLabels.Add(coord, list);
            }
            list.Add(new RegisteredLabel()
            {
                Decorator = decorator,
                Coord = coord,
                Text = text
            });
        }

        private sealed class RegisteredLabel
        {
            public GroundCustomLabelDecorator Decorator { get; set; }
            public IWorldCoordinate Coord { get; set; }
            public string Text { get; set; }
        }
    }
}