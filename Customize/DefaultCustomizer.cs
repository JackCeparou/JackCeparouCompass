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

            using (var itemsAndInventoryConfigurator = new ItemsAndInventoryConfigurator(Hud))
            {
                itemsAndInventoryConfigurator.Configure();
            }

            using (var monstersConfigurator = new MonstersConfigurator(Hud))
            {
                monstersConfigurator.Configure();
            }

            using (var actorsConfigurator = new ActorsConfigurator(Hud))
            {
                actorsConfigurator.Configure();
            }

            using (var playersConfigurator = new PlayersConfigurator(Hud))
            {
                playersConfigurator.Configure();
            }

            using (var buffListsConfigurator = new BuffListsConfigurator(Hud))
            {
                buffListsConfigurator.Configure();
            }

            using (var labelListsConfigurator = new LabelListsConfigurator(Hud))
            {
                labelListsConfigurator.Configure();
            }

            Enabled = false;
        }
    }
}