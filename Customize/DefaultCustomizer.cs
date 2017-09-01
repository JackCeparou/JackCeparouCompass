using System;
using System.Linq;

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
            //Hud.TogglePlugin<TopExperienceStatistics>(false);
            Hud.TogglePlugin<AttributeLabelListPlugin>(false);
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

            Hud.RunOnPlugin<Turbo.Plugins.Default.OtherPlayersPlugin>(plugin =>
            {
                plugin.Order = int.MaxValue;

                plugin.DecoratorByClass[HeroClass.Barbarian].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 250, 10, 10, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.Crusader].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 0, 200, 250, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.DemonHunter].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 0, 0, 200, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.Monk].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 120, 0, 200, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.Necromancer].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 175, 238, 238, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.WitchDoctor].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 0, 155, 125, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
                plugin.DecoratorByClass[HeroClass.Wizard].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Radius = -1,
                    Brush = Hud.Render.CreateBrush(255, 250, 50, 180, 0),
                    Enabled = true,
                    ShapePainter = new CircleShapePainter(Hud),
                });
            });

            //Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            //{
            //    plugin.EnableCustomSpeak = true;
            //    plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets, "OMAGAD a gift!");
            //    plugin.CustomSpeakTable.Add(Hud.Sno.SnoItems.Consumable_Add_Sockets_1, "OMAGAD a gift!");
            //    plugin.CustomSpeakTable.Add(Hud.Inventory.GetSnoItem(1844495708), "OMAGAD a gift!");
            //});

            //Hud.RunOnPlugin<DangerousMonsterPlugin>(plugin =>
            //{
            //    foreach (var name in new string[] { "Wood Wraith", "Highland Walker", "The Old Man", "Fallen Lunatic", "Deranged Fallen", "Fallen Maniac", "Frenzied Lunatic", "Herald of Pestilence", "Terror Demon", "Demented Fallen", "Savage Beast", "Tusked Bogan", "Punisher", "Anarch", "Corrupted Angel", "Winged Assassin", "Exarch" })
            //    {
            //        plugin.RemoveName(name);
            //    }
            //});

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