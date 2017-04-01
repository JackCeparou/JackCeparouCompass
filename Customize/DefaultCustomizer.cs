using Turbo.Plugins.Jack.Decorators;

namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.Default;

    public class DefaultCustomizer : BasePlugin, ICustomizer
    {
        public DefaultCustomizer()
        {
            Enabled = true;
            Order = 43;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            //Says.Debug("D1 {0} {1}", "Load", Order);
        }

        public void Customize()
        {
            //Says.Debug("D2 {0} {1}", "Customize", Order);
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

            //Hud.TogglePlugin<TopExperienceStatistics>(false);
            //Hud.TogglePlugin<PickupRangePlugin>(false);
            //Hud.TogglePlugin<SkillRangeHelperPlugin>(false);
            //Hud.RunOnPlugin<OriginalSkillBarPlugin>(plugin => plugin.SkillPainter.EnableSkillDpsBar = false);

            //Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            //{
            //    plugin.EnableCustomSpeak = true;
            //    plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets, "OMAGAD a gift!"); 
            //    plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets_1, "OMAGAD a gift!"); 
            //    plugin.CustomSpeakTable.Add(Hud.Inventory.GetSnoItem(1844495708), "OMAGAD a gift!"); 
            //});

            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                var dpsDecorator = plugin.LabelList.LabelDecorators[2];
                dpsDecorator.TextFunc = () =>
                {
                    var dps = Hud.Game.Me.Offense.SheetDps * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return ValueToString(dps, ValueFormat.ShortNumber);
                };
                var apsDecorator = plugin.LabelList.LabelDecorators[3];
                apsDecorator.TextFunc = () =>
                {
                    var aps = Hud.Game.Me.Offense.AttackSpeed * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return aps.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "/s";
                };
            });

            //Hud.RunOnPlugin<ChestPlugin>(plugin =>
            //{
            //    var rectangleShapePainter = new RectangleShapePainter(Hud);

            //    plugin.NormalChestDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = rectangleShapePainter);
            //    plugin.LoreChestDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = rectangleShapePainter);
            //    plugin.ResplendentChestDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = rectangleShapePainter);
            //});

            Enabled = false;
        }
    }
}