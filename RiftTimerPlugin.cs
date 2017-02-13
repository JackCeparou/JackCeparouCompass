using System.Text;
using SharpDX.DirectWrite;

namespace Turbo.Plugins.JackCeparouCompass
{
    using System;
    using System.Linq;
    using Turbo.Plugins.Default;
    using System.Globalization;

    public class RiftTimerPlugin : BasePlugin
    {
        //public TopLabelDecorator InRiftDecorator { get; set; }
        //public TopLabelDecorator OtherAreaDecorator { get; set; }

        public IFont InRiftFont { get; set; }
        public IFont OtherAreaFont { get; set; }

        public string OtherAreaPrefix { get; set; }
        public string MinutesSecondsFormat { get; set; }
        public string SecondsFormat { get; set; }
        public string RiftPercentFormat { get; set; }
        public string ClosingSecondsFormat { get; set; }

        public bool ShowClosingTimer { get; set; }

        private IQuest riftQuest { get { return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 337492); } }
        private IWatch pauseTimer;
        private const uint riftClosingMilliseconds = 30000;

        public RiftTimerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            OtherAreaPrefix = "\u2694 "; //⚔
            //MinutesSecondsFormat = "{0:%m}m {0:%s}s";
            MinutesSecondsFormat = "{0:%m}:{0:ss}";
            //SecondsFormat = "{0:%s}s";
            SecondsFormat = "{0:%s}";

            RiftPercentFormat = " ({0:#}%)";
            ClosingSecondsFormat = " ({0:%s})";

            pauseTimer = Hud.CreateWatch();

            InRiftFont = Hud.Render.CreateFont("tahoma", 7, 224, 255, 210, 150, true, false, false);
            InRiftFont.SetShadowBrush(222, 0, 0, 0, true);

            OtherAreaFont = Hud.Render.CreateFont("tahoma", 8, 224, 240, 240, 240, true, false, false);
            OtherAreaFont.SetShadowBrush(222, 0, 0, 0, true);

            /*
            InRiftDecorator = new TopLabelDecorator(hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(200, 255, 255, 255, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 7, 224, 255, 210, 150, true, false, false),
                TextFunc = GetText,
            };
            InRiftDecorator.TextFont.SetShadowBrush(222, 0, 0, 0, true);

            OtherAreaDecorator = new TopLabelDecorator(hud)
            {
                BackgroundBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 0),
                BorderBrush = Hud.Render.CreateBrush(0, 0, 0, 0, 2),
                TextFont = Hud.Render.CreateFont("tahoma", 8, 224, 240, 240, 240, true, false, false),
                TextFunc = GetText,
            };
            OtherAreaDecorator.TextFont.SetShadowBrush(222, 0, 0, 0, true);/**/
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (Hud.Inventory.InventoryMainUiElement.Visible) return;
            if (riftQuest == null) return;
            if (riftQuest.State == QuestState.none) return;
            if (riftQuest.QuestStepId > 10) return;
            if (Hud.Game.SpecialArea == SpecialArea.GreaterRift) return;

            var uiRect = Hud.Render.GetUiElement("Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.rift_container.rift_progress_bar");
            if (uiRect == null)
                return; //useless ??

            var layout = OtherAreaFont.GetTextLayout(GetText());

            if (uiRect.Visible)
            {
                var x = uiRect.Rectangle.Left - layout.Metrics.Width/2 + uiRect.Rectangle.Width * (float)Hud.Game.RiftPercentage / 100.0f;
                InRiftFont.DrawText(layout, x, uiRect.Rectangle.Bottom + Hud.Window.Size.Height * 0.015f);
            }
            else
            {
                var uiMapRect = Hud.Render.MinimapUiElement;
                var x = uiMapRect.Rectangle.Right - layout.Metrics.Width - Hud.Window.Size.Height*0.033f;
                var y = uiMapRect.Rectangle.Bottom + Hud.Window.Size.Height * 0.0033f;

                OtherAreaFont.DrawText(layout, x, y);
            }

        }

        public override void AfterCollect()
        {
            if (!Hud.Game.IsInGame) return;
            // game cannot be paused in multiplayer games
            if (Hud.Game.NumberOfPlayersInGame > 1) return;

            if (riftQuest == null || (riftQuest != null && riftQuest.State == QuestState.none))
            {
                if (pauseTimer.ElapsedMilliseconds > 0)
                {
                    pauseTimer.Stop(); //probably useless if it's a stopwatch
                    pauseTimer.Reset();
                }
            }

            // TODO : turn this into a 'IsGamePaused' helper property
            // TODO : check if pause is still not working when in Achievements tab
            var uiMenu = Hud.Render.GetUiElement("Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd");
            var uiAchievements = Hud.Render.GetUiElement("Root.NormalLayer.BattleNetAchievements_main.LayoutRoot.OverlayContainer");

            if (uiMenu.Visible || uiAchievements.Visible)
            {
                if (!pauseTimer.IsRunning)
                    pauseTimer.Start();
            }
            else if (pauseTimer.IsRunning)
            {
                pauseTimer.Stop();
            }
            //Simon.Says.Debug(pauseTimer.ElapsedMilliseconds.ToString());
        }

        private string GetText()
        {
            var timeSpan = TimeSpan.FromMilliseconds(riftQuest.StartedOn.ElapsedMilliseconds - riftQuest.CompletedOn.ElapsedMilliseconds - pauseTimer.ElapsedMilliseconds);
            var format = (timeSpan.Minutes < 1) ? SecondsFormat : MinutesSecondsFormat;

            if (Hud.Game.SpecialArea != SpecialArea.Rift)
            {
                if (!string.IsNullOrWhiteSpace(OtherAreaPrefix))
                    format = OtherAreaPrefix + format;

                if (Hud.Game.RiftPercentage < 100 && Hud.Game.RiftPercentage >= 1)
                {
                    format += string.Format(CultureInfo.InvariantCulture, RiftPercentFormat, Hud.Game.RiftPercentage);
                }
                else if (riftQuest.QuestStep != null)
                {
                    switch (riftQuest.QuestStep.Id)
                    {
                        case 10:
                            //format += " (Complete)";
                            //format += " \u2620"; //☠
                            format += " \uD83D\uDC80"; //💀
                            break;
                        case 3:
                            //format += " (Guardian)";
                            format += " \uD83D\uDC7F"; //👿
                            break;
                    }
                }
            }

            if (ShowClosingTimer && riftQuest.State == QuestState.completed)
            {
                format += string.Format(ClosingSecondsFormat, TimeSpan.FromMilliseconds(riftClosingMilliseconds - riftQuest.CompletedOn.ElapsedMilliseconds));
            }

            return string.Format(format, timeSpan);
        }
    }
}

/*
try
{
    Simon.Says.Debug(string.Join(",", new object[]
    {
        //riftQuest.Counter,
        riftQuest.State,
        //riftQuest.Progress,
        //riftQuest.StartedOn.ElapsedMilliseconds,
        //riftQuest.CompletedOn.ElapsedMilliseconds,
        //riftQuest.SnoQuest.Steps.Count(),
        //string.Join(",", riftQuest.SnoQuest.Steps.Select(s => s.SplashEnglish)),
        Hud.Game.SpecialArea,
        //string.Join(",", riftQuest.SnoQuest.Steps.Take(7).Select(s => s.SplashEnglish)),
        //string.Join(",", riftQuest.SnoQuest.Steps.Take(7).Select(s => s.Id))
        //string.Join(",", riftQuest.SnoQuest.Steps.Select(s => s.SplashEnglish))
    }));
}
catch (Exception ex)
{
    Simon.Says.Error(ex.Message);
}/**/
