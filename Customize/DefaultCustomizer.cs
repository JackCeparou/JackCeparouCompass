using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Jack.Extensions;

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

            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                var expandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true);
                var expandedHintWidthMultiplier = 3;

                var adLabel = plugin.LabelList.LabelDecorators[6];
                adLabel.ExpandedHintFont = expandedHintFont;
                adLabel.ExpandedHintWidthMultiplier = expandedHintWidthMultiplier;
                adLabel.ExpandUpLabels = new List<TopLabelDecorator>
                {
                    CreateTopLabel(ItemLocation.RightHand, () => "Off hand"),
                    CreateTopLabel(ItemLocation.LeftHand, () => "Main hand"),
                    CreateTopLabel(ItemLocation.Shoulders, () => "Shoulders"),
                    CreateTopLabel(ItemLocation.Hands, () => "Hands"),
                    CreateTopLabel(ItemLocation.LeftRing, () => "Left ring"),
                    CreateTopLabel(ItemLocation.RightRing, () => "Right ring"),
                    CreateTopLabel(ItemLocation.Neck, () => "Neck"),
                };

            });

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

        private TopLabelDecorator CreateTopLabel(ItemLocation location, StringGeneratorFunc hintFunc)
        {
            return new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                ExpandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true),
                ExpandedHintWidthMultiplier = 3,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => Hud.Game.Items
                    .Where(item => item.Location == location).Select(item => item.StatList.AreaDamage())
                    .FirstOrDefault()
                    .ToString("F0", System.Globalization.CultureInfo.InvariantCulture) + "%",
                HintFunc = hintFunc,
            };
        }
    }
}