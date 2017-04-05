namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;

    public class BuffListsConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            Hud.RunOnPlugin<PlayerBottomBuffListPlugin>(plugin =>
            {
                plugin.BuffPainter.ShowTimeLeftNumbers = true;
                plugin.BuffPainter.Opacity = 0.85f;

                var rules = plugin.RuleCalculator.Rules;

                // Iron Skin
                rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });

                // Pylons
                rules.Add(new BuffRule(263029) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true }); // Pylon, Conduit - Normal Rift
                rules.Add(new BuffRule(403404) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true }); // Pylon, Conduit - Greater Rift
                rules.Add(new BuffRule(262935) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true }); // Pylon, Power
                rules.Add(new BuffRule(266258) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true }); // Pylon, Channeling
                rules.Add(new BuffRule(266254) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true }); // Pylon, Shield

                // Legendary power
                rules.Add(new BuffRule(402458) { IconIndex = 1, MinimumIconCount = 1, ShowTimeLeft = true }); // Legendary, In-Geom
            });
        }
    }
}