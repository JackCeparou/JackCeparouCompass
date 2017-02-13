namespace Turbo.Plugins.JackCeparouCompass
{
    using Turbo.Plugins.Default;

    public class HeadBuffListPlugin : BasePlugin
    {
        public BuffPainter BuffPainter { get; set; }
        public BuffRuleCalculator RuleCalculator { get; private set; }
        public float PositionY { get; set; }

        public HeadBuffListPlugin()
        {
            Enabled = true;
            PositionY = 0.28f;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            BuffPainter = new BuffPainter(Hud, true)
            {
                Opacity = 0.85f,
                ShowTimeLeftNumbers = false,
                ShowTooltips = false,
                TimeLeftFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
                StackFont = Hud.Render.CreateFont("tahoma", 6, 255, 255, 255, 255, false, false, 255, 0, 0, 0, true),
            };

            RuleCalculator = new BuffRuleCalculator(Hud)
            {
                SizeMultiplier = 1.0f,
            };

            BuffPainter.ShowTimeLeftNumbers = true;

            //RuleCalculator.Rules.Add(new BuffRule(403471) { IconIndex = null, MinimumIconCount = 1, ShowStacks = true, ShowTimeLeft = true }); // Taeguk
            //RuleCalculator.Rules.Add(new BuffRule(359583) { IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true }); // Focus
            //RuleCalculator.Rules.Add(new BuffRule(359583) { IconIndex = 2, MinimumIconCount = 1, ShowTimeLeft = true }); // Restraint

            RuleCalculator.Rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });
        }

        public override void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            RuleCalculator.CalculatePaintInfo(Hud.Game.Me);
            if (RuleCalculator.PaintInfoList.Count == 0) return;

            var y = Hud.Window.Size.Height * PositionY;
            BuffPainter.PaintHorizontalCenter(RuleCalculator.PaintInfoList, 0, y, Hud.Window.Size.Width, RuleCalculator.StandardIconSize, RuleCalculator.StandardIconSpacing);
        }
    }
}