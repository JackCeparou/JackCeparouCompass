using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.DevTool
{
    public class DisplayPlayerSkillsPlugin : BasePlugin, IInGameTopPainter, IKeyEventHandler
    {
        public IKeyEvent DisplayHotKey { get; set; }
        public IKeyEvent DumpHotKey { get; set; }
        public IFont Font { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public float StartX { get; set; }
        public float StartY { get; set; }

        private bool _showList;

        public DisplayPlayerSkillsPlugin()
        {
            Enabled = true;
            StartX = 20f;
            StartY = 20f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            //_showList = true;

            Font = Hud.Render.CreateFont("consolas", 6, 255, 0, 170, 0, false, false, true);
            BackgroundBrush = Hud.Render.CreateBrush(192, 92, 92, 92, 0);

            DisplayHotKey = Hud.Input.CreateKeyEvent(true, SharpDX.DirectInput.Key.N, true, false, false);
            DumpHotKey = Hud.Input.CreateKeyEvent(true, SharpDX.DirectInput.Key.N, true, false, true);
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            if (keyEvent.Matches(DumpHotKey) && keyEvent.IsPressed)
            {
                DumpToFile();
                return;
            }
            if (keyEvent.Matches(DisplayHotKey) && keyEvent.IsPressed)
            {
                _showList = !_showList;
            }
        }

        private void DumpToFile()
        {
            var fileName = string.Format("dump_player_skills_{0:yyMMddHHmmss}.txt", DateTime.Now);
            var text = string.Join(Environment.NewLine, GetBuffLines());
            Hud.TextLog.Log(fileName, text, false);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (!_showList) return;

            var lines = GetBuffLines();
            var lineWithMaxLength = lines.FirstOrDefault(l => l.Length == lines.Max(ll => ll.Length));

            if (string.IsNullOrEmpty(lineWithMaxLength)) return;

            var layout = Font.GetTextLayout(lineWithMaxLength);
            var h = layout.Metrics.Height;
            var w = layout.Metrics.Width;
            var x = StartX;
            var y = StartY;

            //var lineCount = (int)((Hud.Window.GroundRectangle.Top + Hud.Window.GroundRectangle.Height - StartX) / h);
            //lineCount /= 2;
            //var columns = new List<List<string>>()
            //{
            //    new List<string>()
            //};
            //var currentColumnIndex = 0;
            //while (currentColumnIndex * lineCount < lines.Count)
            //{
            //    var column = lines.Skip(currentColumnIndex * lineCount).Take(lineCount);
            //    columns[currentColumnIndex].AddRange(column);
            //    currentColumnIndex++;
            //}

            var lineCount = (int)((Hud.Window.GroundRectangle.Top + Hud.Window.GroundRectangle.Height - StartX) / h);
            var estimatedWidth = w * ((lines.Count / lineCount) + 1);
            if (BackgroundBrush != null)
                BackgroundBrush.DrawRectangle(StartX - h / 2f, StartY - h / 2f, estimatedWidth + h, h * Math.Min(lineCount, lines.Count) + h);

            foreach (var line in lines)
            {
                Font.DrawText(line, x, y);

                if (y >= Hud.Window.GroundRectangle.Bottom - (h*2))
                {
                    x += w;
                    y = StartY;
                }
                else
                {
                    y += h;
                }
            }
        }

        private List<string> GetBuffLines()
        {
            var lines = Hud.Game.Me.Powers.CurrentSkills
                    .Where(skill => skill != null && skill.SnoPower != null)
                    .OrderBy(skill => string.IsNullOrEmpty(skill.SnoPower.NameEnglish) ? 1 : 0)
                    .ThenBy(skill => skill.SnoPower.Sno)
                    .Select(skill =>
                    {
                        //var iconCount = IconCount(skill.Buff.IconCounts);
                        return string.Join(
                            " | ",
                            string.Format("{0} {1,6} {2}",
                                skill.BuffIsActive ? "⚫" : "⚪",
                                skill.SnoPower.Sno,
                                string.IsNullOrEmpty(skill.SnoPower.NameEnglish)
                                    ? skill.SnoPower.Code
                                        .Replace("ItemPassive_Unique", "*")
                                        .Replace("Community_Event_Buff", "*")
                                    : skill.SnoPower.NameEnglish
                            ),
                            //iconCount,
                            //string.Join(" ",
                            //    buff.IconCounts.Take(iconCount).Select(i => string.Format("{0:0.#}", i))),
                            //string.Join(" ",
                            //    skill.Buff.TimeLeftSeconds.Take(iconCount)
                            //        .Select(t => string.Format("{0,3:0.0}", t))),
                            string.Format("{0} {1}", skill.Rune, skill.RuneNameEnglish)
                        );
                    })
                    .ToList();

            return lines;
        }

        private int IconCount(int[] items)
        {
            return LastIndexOf(items, 1) + 1;
        }

        private int LastIndexOf(int[] items, int value)
        {
            for (var index = items.Length-1; index > 0; index--)
            {
                if (items[index] < value)
                    continue;

                return index;
            }

            return 0;
        }
    }
}
