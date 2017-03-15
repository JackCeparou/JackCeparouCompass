namespace Turbo.Plugins.Jack.Decorators.TopTables
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class TopTableCellDecorator : ITransparentCollection
    {
        public IController Hud { get; set; }

        public IFont TextFont { get; set; }

        public IBrush BackgroundBrush { get; set; }
        public IBrush BorderBrush { get; set; }

        public TopTableCellDecorator(IController hud)
        {
            Hud = hud;
        }

        public void Paint(float x, float y, float w, float h, string text, HorizontalAlign align)
        {
            if (TextFont == null) return;

            if (BackgroundBrush != null)
            {
                //BackgroundBrush.DrawRectangle(x, y, w, h);
                BackgroundBrush.DrawRectangleGridFit(x, y, w, h);
            }

            if (!string.IsNullOrEmpty(text))
            {
                var layout = TextFont.GetTextLayout(text);
                var layoutChar = TextFont.GetTextLayout(":");
                switch (align)
                {
                    case HorizontalAlign.Left:
                        TextFont.DrawText(layout, x + layoutChar.Metrics.Width, y + (h - layout.Metrics.Height) / 2);
                        break;

                    case HorizontalAlign.Center:
                        TextFont.DrawText(layout, x + (w - layout.Metrics.Width) / 2, y + (h - layout.Metrics.Height) / 2);
                        break;

                    case HorizontalAlign.Right:
                        TextFont.DrawText(layout, x + w - layout.Metrics.Width - layoutChar.Metrics.Width, y + (h - layout.Metrics.Height) / 2);
                        break;
                }
            }

            if (BorderBrush != null)
            {
                //BorderBrush.DrawRectangle(x, y, w, h);
                BorderBrush.DrawRectangleGridFit(x, y, w, h);
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return TextFont;
            yield return BackgroundBrush;
            yield return BorderBrush;
        }
    }
}