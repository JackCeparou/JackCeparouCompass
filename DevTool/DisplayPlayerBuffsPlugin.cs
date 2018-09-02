using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.DevTool
{
    public class DisplayPlayerBuffsPlugin : BasePlugin, IInGameTopPainter, IKeyEventHandler
    {
        public IKeyEvent DisplayHotKey { get; set; }
        public IKeyEvent DumpHotKey { get; set; }
        public IFont Font { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public float StartX { get; set; }
        public float StartY { get; set; }

        private bool _showList;

        public DisplayPlayerBuffsPlugin()
        {
            Enabled = true;
            StartX = 20f;
            StartY = 50f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            Font = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true);
            BackgroundBrush = Hud.Render.CreateBrush(142, 92, 92, 92, 0);

            DisplayHotKey = Hud.Input.CreateKeyEvent(true, SharpDX.DirectInput.Key.B, true, false, false);
            DumpHotKey = Hud.Input.CreateKeyEvent(true, SharpDX.DirectInput.Key.B, true, false, true);
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.Matches(DumpHotKey) && keyEvent.IsPressed)
            {
                DumpToFile();
            }
            if (keyEvent.Matches(DisplayHotKey) && keyEvent.IsPressed)
            {
                _showList = !_showList;
            }
        }

        private void DumpToFile()
        {
            var fileName = string.Format("dump_player_buffs_{0:yyMMddHHmmss}.txt", DateTime.Now);
            var text = string.Join(Environment.NewLine, GetBuffLines());
            Hud.TextLog.Log(fileName, text, false);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (!_showList) return;

            var lines = GetBuffLines();
            var lineWithMaxLength = lines.Where(l => l.Length == lines.Max(x => x.Length)).FirstOrDefault();

            if (string.IsNullOrEmpty(lineWithMaxLength)) return;

            var layout = Font.GetTextLayout(lineWithMaxLength);
            var h = layout.Metrics.Height;
            var w = layout.Metrics.Width;
            var y = StartY;

            if (BackgroundBrush != null)
                BackgroundBrush.DrawRectangle(StartX - h / 2f, StartY - h / 2f, w + h, h * lines.Count + h);

            foreach (var line in GetBuffLines())
            {
                Font.DrawText(line, StartX, y);
                y += h;
            }
        }

        private List<string> GetBuffLines()
        {
            var lines = Hud.Game.Me.Powers.AllBuffs
                    .Where(buff => buff != null && buff.SnoPower != null)
                    .OrderBy(buff => string.IsNullOrEmpty(buff.SnoPower.NameEnglish) ? 1 : 0)
                    .ThenBy(buff => buff.SnoPower.Sno)
                    .Select(buff => string.Join(
                        " | ",
                        string.IsNullOrEmpty(buff.SnoPower.NameEnglish)
                            ? buff.SnoPower.Sno.ToString()
                            : string.Format("{0} | {1}", buff.SnoPower.NameEnglish, buff.SnoPower.Sno.ToString()),
                        buff.SnoPower.Code,
                        buff.Active,
                        //string.Format("{0:0.#}", buff.TimeLeft()),
                        string.Join(", ", buff.IconCounts.Select(i => string.Format("{0:0.#}", i))),
                        string.Join(", ", buff.TimeLeftSeconds.Select(t => string.Format("{0:0.#}", t)))
                        ))
                        .ToList();

            return lines;
        }
    }
}