namespace Turbo.Plugins.JackCeparouCompass
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Turbo.Plugins.Default;

    public class RiftTimerPlugin : BasePlugin
    {
        public IFont ProgressBarTimerFont { get; set; }
        public IFont ObjectiveProgressFont { get; set; }

        public string ObjectiveProgressSymbol { get; set; }
        public string GuardianAliveSymbol { get; set; }
        public string GuardianDeadSymbol { get; set; }

        public string SecondsFormat { get; set; }
        public string MinutesSecondsFormat { get; set; }
        public string ProgressPercentFormat { get; set; }
        public string ClosingSecondsFormat { get; set; }

        public bool ShowClosingTimer { get; set; }

        public bool IsGuardianAlive { get { return riftQuest.QuestStepId == 3 || riftQuest.QuestStepId == 16; } }
        public bool IsGuardianDead
        {
            get
            {
                if (Hud.Game.Monsters.Any(m => m.Rarity == ActorRarity.Boss && !m.IsAlive))
                    return true;

                return riftQuest.QuestStepId == 5 || riftQuest.QuestStepId == 10 || riftQuest.QuestStepId == 34 || riftQuest.QuestStepId == 46;
            }
        }

        public bool IsNephalemRift { get { return riftQuest.QuestStepId == 1 || riftQuest.QuestStepId == 3 || riftQuest.QuestStepId == 10; } }
        public bool IsGreaterRift { get { return riftQuest.QuestStepId == 13 || riftQuest.QuestStepId == 16 || riftQuest.QuestStepId == 34 || riftQuest.QuestStepId == 46; } }

        private const uint riftClosingMilliseconds = 30000;
        private SpecialArea? currentRun;
        //private TimeSpan greaterRiftMaxDuration = new TimeSpan(0, 15, 0);

        private IQuest riftQuest {
            get
            {
                return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 337492) ?? // rift
                       Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 382695);   // gr
            }
        }

        private IUiElement uiProgressBar {
            get
            {
                return Hud.Render.GetUiElement(IsNephalemRift
                    ? "Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.rift_container.rift_progress_bar" // rift
                    : "Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.greater_rift_container.rift_progress_bar"); // gr
            }
        }

        private IWatch riftTimer;
        private IWatch guardianTimer;
        private IWatch pauseTimer;

        private readonly StringBuilder textBuilder;

        public RiftTimerPlugin()
        {
            Enabled = true;

            textBuilder = new StringBuilder();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ObjectiveProgressSymbol = "\u2694"; //⚔
            GuardianAliveSymbol = "\uD83D\uDC7F"; //👿
            GuardianDeadSymbol = "\uD83D\uDC80"; //💀

            MinutesSecondsFormat = "{0:%m}:{0:ss}";
            SecondsFormat = "{0:%s}";

            ProgressPercentFormat = "({0:F1}%)";
            ClosingSecondsFormat = "({0:%s})";

            ProgressBarTimerFont = Hud.Render.CreateFont("tahoma", 7, 224, 255, 210, 150, true, false, false);
            ProgressBarTimerFont.SetShadowBrush(222, 0, 0, 0, true);

            ObjectiveProgressFont = Hud.Render.CreateFont("tahoma", 8, 224, 240, 240, 240, false, false, false);
            ObjectiveProgressFont.SetShadowBrush(222, 0, 0, 0, true);

            pauseTimer = Hud.CreateWatch();
            riftTimer = Hud.CreateWatch();
            guardianTimer = Hud.CreateWatch();
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (Hud.Inventory.InventoryMainUiElement.Visible) return;
            if (riftQuest == null) return;
            if (riftQuest.State == QuestState.none) return;
            if (currentRun == null)
            {
                currentRun = IsNephalemRift ? SpecialArea.Rift : SpecialArea.GreaterRift;
            }


            if (IsNephalemRift && uiProgressBar.Visible)
            {
                var layout = ProgressBarTimerFont.GetTextLayout(GetText(true));
                var x = uiProgressBar.Rectangle.Left - layout.Metrics.Width / 2 + uiProgressBar.Rectangle.Width * (float)Hud.Game.RiftPercentage / 100.0f;

                ProgressBarTimerFont.DrawText(layout, x, uiProgressBar.Rectangle.Bottom + Hud.Window.Size.Height * 0.015f);
            }
            else
            {
                var layout = ObjectiveProgressFont.GetTextLayout(GetText(false));
                var x = Hud.Render.MinimapUiElement.Rectangle.Right - layout.Metrics.Width - Hud.Window.Size.Height * 0.033f;
                var y = Hud.Render.MinimapUiElement.Rectangle.Bottom + Hud.Window.Size.Height * 0.0033f;

                ObjectiveProgressFont.DrawText(layout, x, y);
            }
        }

        public override void AfterCollect()
        {
            // reset states if needed
            if (riftQuest == null || (riftQuest != null && riftQuest.State == QuestState.none))
            {
                if (riftTimer.IsRunning || riftTimer.ElapsedMilliseconds > 0)
                {
                    riftTimer.Reset();
                }
                if (guardianTimer.IsRunning || guardianTimer.ElapsedMilliseconds > 0)
                {
                    guardianTimer.Reset();
                }
                if (pauseTimer.IsRunning || pauseTimer.ElapsedMilliseconds > 0)
                {
                    pauseTimer.Reset();
                }

                currentRun = null;

                return;
            }

            // guardian
            if (IsGuardianAlive)
            {
                if (!guardianTimer.IsRunning)
                    guardianTimer.Start();
            }
            else if (IsGuardianDead && guardianTimer.IsRunning)
            {
                guardianTimer.Stop();
            }

            // game pause
            if (Hud.Game.IsPaused || (IsGreaterRift && Hud.Game.NumberOfPlayersInGame == 1 && Hud.Game.IsLoading))
            {
                if (!pauseTimer.IsRunning)
                    pauseTimer.Start();

                if (riftTimer.IsRunning)
                    riftTimer.Stop();

                if (guardianTimer.IsRunning)
                    guardianTimer.Stop();

                return;
            }

            // (re)start/stop timers if needed
            if (!riftTimer.IsRunning && !IsGuardianDead)
                riftTimer.Start();

            if (!guardianTimer.IsRunning && IsGuardianAlive)
                guardianTimer.Start();

            if (pauseTimer.IsRunning)
                pauseTimer.Stop();

            if (IsGreaterRift && IsGuardianDead && riftTimer.IsRunning)
                riftTimer.Stop();

            if (IsNephalemRift && riftQuest.State == QuestState.completed && riftTimer.IsRunning)
                riftTimer.Stop();

            //Simon.Says.Debug("{0} {1}", riftTimer.ElapsedMilliseconds, riftQuest.StartedOn.ElapsedMilliseconds);
        }

        private string GetText(bool onlyTimer)
        {
            textBuilder.Clear();

            if (!onlyTimer && !string.IsNullOrWhiteSpace(ObjectiveProgressSymbol))
            {
                textBuilder.Append(ObjectiveProgressSymbol);
                textBuilder.Append(" ");
            }

            if (currentRun == SpecialArea.GreaterRift)
            {
                var timeSpan = TimeSpan.FromMilliseconds(riftTimer.ElapsedMilliseconds);
                textBuilder.AppendFormat(CultureInfo.InvariantCulture, (timeSpan.Minutes < 1) ? SecondsFormat : MinutesSecondsFormat, timeSpan);
                //Simon.Says.Debug("GR {0} {1}", riftQuest.QuestStepId, timeSpan, TimeSpan.FromMilliseconds(riftQuest.StartedOn.ElapsedMilliseconds));
                // 3:07.385 3:05.783 => 1602
                // 3:18.054 3:16.750 => 1304
                // 3:01.388 3:00.466 => 922
                // 2:52.126 2:51.016 => 1110
                //
            }
            else
            {
                var _timeSpan = TimeSpan.FromMilliseconds(riftQuest.StartedOn.ElapsedMilliseconds - riftQuest.CompletedOn.ElapsedMilliseconds - pauseTimer.ElapsedMilliseconds);
                textBuilder.AppendFormat(CultureInfo.InvariantCulture, (_timeSpan.Minutes < 1) ? SecondsFormat : MinutesSecondsFormat, _timeSpan);
                //Simon.Says.Debug("NR {0} {1}", riftQuest.QuestStepId, _timeSpan);
            }

            if (onlyTimer)
                return textBuilder.ToString();

            if (Hud.Game.RiftPercentage < 100)// && Hud.Game.RiftPercentage >= 0.1)
            {
                if ((IsNephalemRift || !uiProgressBar.Visible ) && Hud.Game.RiftPercentage > 0.1)
                {
                    textBuilder.Append(" ");
                    textBuilder.AppendFormat(CultureInfo.InvariantCulture, ProgressPercentFormat, Hud.Game.RiftPercentage);
                }
            }
            else if (IsGuardianAlive || IsGuardianDead || !guardianTimer.IsRunning)
            {
                textBuilder.Append(" ");
                textBuilder.Append(IsGuardianAlive ? GuardianAliveSymbol : GuardianDeadSymbol);

                //var guardianTimeSpan = TimeSpan.FromMilliseconds(guardianTimer.ElapsedMilliseconds - guardianPauseTimer.ElapsedMilliseconds);
                var guardianTimeSpan = TimeSpan.FromMilliseconds(guardianTimer.ElapsedMilliseconds);
                textBuilder.Append(" ");
                textBuilder.AppendFormat(CultureInfo.InvariantCulture, (guardianTimeSpan.Minutes < 1) ? SecondsFormat : MinutesSecondsFormat, guardianTimeSpan);
            }

            if (ShowClosingTimer && !IsGreaterRift && riftQuest.State == QuestState.completed)
            {
                textBuilder.Append(" ");
                textBuilder.AppendFormat(ClosingSecondsFormat, TimeSpan.FromMilliseconds(riftClosingMilliseconds - riftQuest.CompletedOn.ElapsedMilliseconds));
            }

            return textBuilder.ToString();
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