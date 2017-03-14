namespace Turbo.Plugins.Jack.DevTool.Logger
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Turbo.Plugins.Default;

    public class LogToScreenPlugin : BasePlugin, IInGameTopPainter
    {
        public TopLabelDecorator MessageFrame { get; set; }
        public Dictionary<LogLevel, IFont> Fonts { get; set; }

        public Func<float> XFunc { get; set; }
        public Func<float> YFunc { get; set; }

        public LogToScreenPlugin()
        {
            Enabled = true;
            Fonts = new Dictionary<LogLevel, IFont>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            var fontFamily = "consolas";
            MessageFrame = new TopLabelDecorator(hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont(fontFamily, 7, 224, 240, 240, 64, true, false, false),
                //AlertTextFunc = () => string.Join("\n", Log.Messages.Select(m => m.Message)),
            };

            Fonts.Add(LogLevel.Error, Hud.Render.CreateFont(fontFamily, 7, 224, 255, 0, 0, true, false, false));
            Fonts.Add(LogLevel.All, Hud.Render.CreateFont(fontFamily, 7, 224, 240, 240, 240, true, false, false));
            Fonts.Add(LogLevel.Info, Hud.Render.CreateFont(fontFamily, 7, 224, 64, 240, 64, true, false, false));
            Fonts.Add(LogLevel.Debug, Hud.Render.CreateFont(fontFamily, 7, 224, 240, 240, 64, true, false, false));

            XFunc = () => Hud.Window.Size.Width * 0.2f;
            YFunc = () => Hud.Window.Size.Height * 0.1042f;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            // dumb test
            //Says.Error(Guid.NewGuid().ToString());

            //try
            //{
            //    var item = Hud.Inventory.GetSnoItem(1612258795);
            //    Jack.Says.Debug(item.NameEnglish);
            //}
            //catch (Exception ex)
            //{
            //    Says.Debug(ex.Message);
            //}
            ////337492 Nephalem Rift
            //foreach (var s in Hud.Game.Quests.Where(q => q.SnoQuest.Type != QuestType.Bounty))
            //{
            //    Says.Debug("{0} {1}", s.SnoQuest.Sno, s.SnoQuest.NameEnglish);
            //}
            //foreach (var s in Hud.Game.Me.Powers.PassiveSlots)
            //{
            //    Says.Debug("{0} {1}", s.Sno, s.NameEnglish);
            //}
            //foreach (var s in Hud.Game.Me.Powers.UsedPassives)
            //{
            //    Says.Error("{0} {1}", s.Sno, s.NameEnglish);
            //}

            if (Hud.Input.IsKeyDown(Keys.X))
            {
                Says.Messages.Clear();
            }
            if (Says.Messages.Count == 0) return;

            var screenSize = Hud.Window.Size;
            var x = XFunc();
            var y = YFunc();

            var estimatedWidth = Says.Messages.Max(m => m.Message.Length) * 8f; // TODO : fix for long exceptions
            var estimatedHeight = (Says.Messages.Count + 1) * 14f + 20 + 2;

            MessageFrame.Paint(x, y, estimatedWidth, estimatedHeight, HorizontalAlign.Left);

            x += 10;
            y += 4;

            Fonts[LogLevel.All].DrawText("Jack says :", x, y);
            y += 14;

            foreach (var message in Says.Messages)
            {
                Fonts[message.Level].DrawText(message.Message, x, y);
                y += 14;
            }
        }
    }
}