namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;

    public class BuffListsConfigurator : IConfigurator
    {
        public void Configure(IController Hud)
        {
            Hud.RunOnPlugin<PlayerBottomBuffListPlugin>(plugin =>
            {
                plugin.BuffPainter.ShowTimeLeftNumbers = true;
                plugin.BuffPainter.Opacity = 0.85f;

                // Iron Skin
                plugin.RuleCalculator.Rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });
            });
        }

        public void Dispose()
        {
        }
    }
}