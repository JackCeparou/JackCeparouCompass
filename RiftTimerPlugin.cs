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

        public bool IsGamePaused
        {
            //// TODO : turn this into a 'IsGamePaused' helper property
            //// TODO : check if pause is still not working when in Achievements tab
            //var uiMenu = Hud.Render.GetUiElement("Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd");
            //var uiAchievements = Hud.Render.GetUiElement("Root.NormalLayer.BattleNetAchievements_main.LayoutRoot.OverlayContainer");ontainer");
            get
            {
                if (Hud.Game.NumberOfPlayersInGame > 1) return false;
                if (Hud.Render.GetUiElement("Root.NormalLayer.gamemenu_dialog.gamemenu_bkgrnd").Visible) return true;
                if (Hud.Render.GetUiElement("Root.NormalLayer.BattleNetAchievements_main.LayoutRoot.OverlayContainer").Visible) return true;

                return false;
            }
        }

        public bool IsGuardianAlive { get { return riftQuest.QuestStepId == 3 || riftQuest.QuestStepId == 16; } }
        public bool IsGuardianDead { get { return riftQuest.QuestStepId == 10 || riftQuest.QuestStepId == 34; } }
        public bool IsNephalemRift { get { return riftQuest.QuestStepId > 0 && riftQuest.QuestStepId <= 10; } }
        public bool IsGreaterRift { get { return riftQuest.QuestStepId > 10 && riftQuest.QuestStepId <= 46; } }

        private const uint riftClosingMilliseconds = 30000;

        private IQuest riftQuest { get { return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 337492); } }
        //private IQuest greaterRiftQuest { get { return Hud.Game.Quests.FirstOrDefault(q => q.SnoQuest.Sno == 382695); } }

        private IUiElement uiRiftProgressBar { get { return Hud.Render.GetUiElement("Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.rift_container.rift_progress_bar"); } }
        //private IUiElement uiGreaterRiftProgressBar { get { return Hud.Render.GetUiElement("Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.greater_rift_container.rift_progress_bar"); } }

        private IWatch riftTimer;
        private IWatch guardianTimer;
        //private IWatch pauseTimer;
        //private IWatch guardianPauseTimer;

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

            //pauseTimer = Hud.CreateWatch();
            riftTimer = Hud.CreateWatch();
            guardianTimer = Hud.CreateWatch();
            //guardianPauseTimer = Hud.CreateWatch();
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (Hud.Inventory.InventoryMainUiElement.Visible) return;
            if (riftQuest == null) return;
            if (riftQuest.State == QuestState.none) return;
            //if (riftQuest.QuestStepId > 10) return;
            //if (Hud.Game.SpecialArea == SpecialArea.GreaterRift) return;

            //var uiRiftProgressBar = Hud.Render.GetUiElement("Root.NormalLayer.eventtext_bkgrnd.eventtext_region.stackpanel.rift_wrapper.rift_container.rift_progress_bar");
            //if (uiRiftProgressBar == null)
            //    return; //useless ??

            /*
            try
            {
                //Simon.Says.Debug(string.Join(", ", new object[]
                //{
                //    riftQuest.State,
                //    Hud.Game.SpecialArea,
                //    riftQuest.QuestStepId//,
                //    //string.Join(",", riftQuest.SnoQuest.Steps.Select(s => s.Id.ToString() + " " + s.SplashEnglish))
                //    //string.Join(",", riftQuest.SnoQuest.Steps.Select(s => s.Id))
                //}));
                //Simon.Says.Debug(string.Join(",", new object[]
                //{
                //    greaterRiftQuest,
                //    //greaterRiftQuest.State,
                //    //greaterRiftQuest.QuestStepId,
                //    //Hud.Game.SpecialArea,
                //    //string.Join(",", greaterRiftQuest.SnoQuest.Steps.Select(s => s.Id.ToString() + " " + s.SplashEnglish))
                //}));
            }
            catch (Exception ex)
            {
                Simon.Says.Error(ex.Message);
            }/**/

            if (uiRiftProgressBar.Visible && IsNephalemRift)
            {
                var layout = ProgressBarTimerFont.GetTextLayout(GetText(true));
                var x = uiRiftProgressBar.Rectangle.Left - layout.Metrics.Width / 2 + uiRiftProgressBar.Rectangle.Width * (float)Hud.Game.RiftPercentage / 100.0f;

                ProgressBarTimerFont.DrawText(layout, x, uiRiftProgressBar.Rectangle.Bottom + Hud.Window.Size.Height * 0.015f);
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
            if (!Hud.Game.IsInGame) return;
            //// game cannot be paused in multiplayer games
            //if (Hud.Game.NumberOfPlayersInGame > 1) return;

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
                //if (pauseTimer.IsRunning || pauseTimer.ElapsedMilliseconds > 0)
                //{
                //    pauseTimer.Reset();
                //}
                //if (guardianPauseTimer.IsRunning || guardianPauseTimer.ElapsedMilliseconds > 0)
                //{
                //    guardianPauseTimer.Reset();
                //}

                return;
            }

            // handle guardian
            if (IsGuardianAlive)
            {
                if (!guardianTimer.IsRunning)
                    guardianTimer.Restart();
            }
            else if (IsGuardianDead && guardianTimer.IsRunning)
            {
                guardianTimer.Stop();
            }

            // handle game pause
            if (IsGamePaused)
            {
                //if (!pauseTimer.IsRunning)
                //    pauseTimer.Start();

                //if (!guardianPauseTimer.IsRunning && IsGuardianAlive)
                //    guardianPauseTimer.Start();

                //return;
                if (riftTimer.IsRunning)
                    riftTimer.Stop();

                if (guardianTimer.IsRunning)
                    guardianTimer.Stop();

                return;
            }
            if (!riftTimer.IsRunning && !IsGuardianDead)
                riftTimer.Start();

            if (!guardianTimer.IsRunning && IsGuardianAlive)
                guardianTimer.Start();
            //if (pauseTimer.IsRunning)
            //{
            //    pauseTimer.Stop();
            //}
            //if (guardianPauseTimer.IsRunning)
            //{
            //    guardianPauseTimer.Stop();
            //}
            if (IsGreaterRift && IsGuardianDead && riftTimer.IsRunning)
            {
                riftTimer.Stop();
            }
            if (IsNephalemRift && riftQuest.State == QuestState.completed && riftTimer.IsRunning)
            {
                riftTimer.Stop();
            }

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

            //var timeSpan = TimeSpan.FromMilliseconds(riftQuest.StartedOn.ElapsedMilliseconds - riftQuest.CompletedOn.ElapsedMilliseconds - pauseTimer.ElapsedMilliseconds);
            var timeSpan = TimeSpan.FromMilliseconds(riftTimer.ElapsedMilliseconds);
            textBuilder.AppendFormat(CultureInfo.InvariantCulture, (timeSpan.Minutes < 1) ? SecondsFormat : MinutesSecondsFormat, timeSpan);

            if (onlyTimer)
                return textBuilder.ToString();

            if (Hud.Game.RiftPercentage < 100)// && Hud.Game.RiftPercentage >= 0.1)
            {
                if (IsNephalemRift && Hud.Game.RiftPercentage > 0.1)
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

            //if (Hud.Game.SpecialArea != SpecialArea.Rift)
            //{
            //    if (Hud.Game.RiftPercentage < 100 && Hud.Game.RiftPercentage >= 0.1)
            //    {
            //        textBuilder.AppendFormat(CultureInfo.InvariantCulture, ProgressPercentFormat, Hud.Game.RiftPercentage);
            //    }
            //    else if (riftQuest.QuestStep != null)
            //    {
            //        switch (riftQuest.QuestStep.Id)
            //        {
            //            case 10:
            //                textBuilder.Append(GuardianDeadSymbol);
            //                break;
            //            case 3:
            //                textBuilder.Append(GuardianAliveSymbol);
            //                break;
            //        }
            //    }
            //}

            if (ShowClosingTimer && riftQuest.State == QuestState.completed)
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