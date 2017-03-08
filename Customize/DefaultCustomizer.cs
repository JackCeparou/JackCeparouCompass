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

            using (var itemsAndInventoryConfigurator = new ItemsAndInventoryConfigurator())
            {
                itemsAndInventoryConfigurator.Configure(Hud);
            }

            using (var monstersConfigurator = new MonstersConfigurator())
            {
                monstersConfigurator.Configure(Hud);
            }

            using (var actorsConfigurator = new ActorsConfigurator())
            {
                actorsConfigurator.Configure(Hud);
            }

            using (var playersConfigurator = new PlayersConfigurator())
            {
                playersConfigurator.Configure(Hud);
            }

            using (var buffListsConfigurator = new BuffListsConfigurator())
            {
                buffListsConfigurator.Configure(Hud);
            }

            using (var labelListsConfigurator = new LabelListsConfigurator())
            {
                labelListsConfigurator.Configure(Hud);
            }

            Enabled = false;
        }
    }
}