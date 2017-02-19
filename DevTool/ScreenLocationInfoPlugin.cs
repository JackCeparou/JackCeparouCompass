using System.Globalization;
using System.Linq;
using SharpDX.DirectInput;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.DevTool
{
    public class ScreenLocationInfoPlugin : BasePlugin, IInGameTopPainter, IKeyEventHandler
    {
        public IBrush BackgroundBrush { get; set; }
        public IFont TextFont { get; set; }

        public int Offset { get; set; }
        public int Padding { get; set; }

        public IKeyEvent ToggleKeyEvent { get; set; }
        public bool Visible { get; set; }

        public ScreenLocationInfoPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            TextFont = Hud.Render.CreateFont("tahoma", 7, 224, 240, 240, 64, true, false, false);
            BackgroundBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 0);
            Offset = 20;
            Padding = 5;

            ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.V, false, false, false);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (!Visible) return;

            var s = Hud.Window.Size;

            var text = string.Format(CultureInfo.InvariantCulture, "{0}x{1}\nX: {2,4}\nY: {3,4}",
                s.Width, s.Height,
                string.Format(CultureInfo.InvariantCulture, "{0} px | % : {1}f", Hud.Window.CursorX, Hud.Window.CursorX / (float)s.Width),
                string.Format(CultureInfo.InvariantCulture, "{0} px | % : {1}f", Hud.Window.CursorY, Hud.Window.CursorY / (float)s.Height)
                );

            var layout = TextFont.GetTextLayout(text);
            var h = layout.Metrics.Height;
            var w = layout.Metrics.Width;

            var offsetX = Hud.Window.CursorX + (int)(s.Width / 2 > Hud.Window.CursorX ? Offset : -w -Offset);
            var offsetY = Hud.Window.CursorY + (int)(s.Height / 2 > Hud.Window.CursorY ? Offset : -h -Offset);

            BackgroundBrush.DrawRectangle(offsetX - Padding, offsetY - Padding, w + Padding * 2, h + Padding * 2);
            TextFont.DrawText(layout, offsetX, offsetY);
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.IsPressed && ToggleKeyEvent.Matches(keyEvent))
            {
                Visible = !Visible;
            }
        }
    }
}