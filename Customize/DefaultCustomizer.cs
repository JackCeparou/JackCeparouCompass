namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.Default;

    public class DefaultCustomizer : BasePlugin, ICustomizer
    {
        public DefaultCustomizer()
        {
            Enabled = true;
        }

        public void Customize()
        {
            // toggle some default plugins
            Hud.TogglePlugin<DebugPlugin>(true);
            Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(false);
            Hud.TogglePlugin<PortraitBottomStatsPlugin>(false);
            Hud.TogglePlugin<SkillRangeHelperPlugin>(false);
            Hud.RunOnPlugin<OriginalSkillBarPlugin>(plugin => plugin.SkillPainter.EnableSkillDpsBar = false);

            using (var configurator = new ItemsAndInventoryConfigurator())
            {
                configurator.Configure(Hud);
            }

            using (var configurator = new MonstersConfigurator())
            {
                configurator.Configure(Hud);
            }

            using (var configurator = new ActorsConfigurator())
            {
                configurator.Configure(Hud);
            }

            using (var configurator = new PlayersConfigurator())
            {
                configurator.Configure(Hud);
            }

            using (var configurator = new BuffListsConfigurator())
            {
                configurator.Configure(Hud);
            }

            using (var configurator = new LabelListsConfigurator())
            {
                configurator.Configure(Hud);
            }

            Enabled = false;
        }
    }
}