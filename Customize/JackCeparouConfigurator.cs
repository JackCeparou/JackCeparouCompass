using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Turbo.Plugins.Jack.Alerts;

namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Jack.Actors;
    using Turbo.Plugins.Default;

    public class JackCeparouConfigurator : BasePlugin, ICustomizer
    {
        public JackCeparouConfigurator()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<DoorsPlugin>(plugin => plugin.ShowInTown = true);

            var itemsIds = new HashSet<uint>() { 1844495708 };
            Hud.RunOnPlugin<PlayerTopAlertListPlugin>(plugin =>
            {
                plugin.AlertList.Alerts.Add(new Alert(Hud)
                {
                    MessageFormat = "\uD83C\uDF81 {0} \uD83C\uDF81",//??
                    AlertTextFunc = (id) =>
                    {
                        var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && itemsIds.Contains(item.SnoItem.Sno));

                        if (items.Count() > 1)
                            return string.Join(", ", items.GroupBy(k => k.FullNameLocalized).Select(item => string.Format(CultureInfo.InvariantCulture, "{0} {1}", item.Count(), item.Key)));

                        return items.Count() == 1 ? items.First().FullNameLocalized : string.Empty;
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && itemsIds.Contains(item.SnoItem.Sno)),
                    }
                });
            });

            Hud.RunOnPlugin<MinimapLeftAlertListPlugin>(plugin =>
            {
                var ancientRank = -1;
                plugin.AlertList.VerticalCenter = false;
                plugin.AlertList.RatioSpacerY = 0;

                plugin.AlertList.Alerts.Add(new Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank).Select(item => string.Format(CultureInfo.InvariantCulture, "\uD83C\uDF81 {0} \uD83C\uDF81", item.FullNameLocalized));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });

                plugin.AlertList.Alerts.Add(new Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank).Select(item => string.Format(CultureInfo.InvariantCulture, "\uD83C\uDF81 {0} \uD83C\uDF81", item.FullNameLocalized));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 235, 120, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });
            });

            #region GoblinPlugin
            /*
            Hud.RunOnPlugin<JackCeparouCompass.Monsters.GoblinPlugin>(plugin =>
            {
                var radiusTransformator = new StandardPingRadiusTransformator(Hud, 333);

                plugin.AllGoblinDecorators().ForEach(goblin =>
                {
                    goblin.GetDecorators<MapShapeDecorator>().ForEach(decorator =>
                    {
                        var painter = decorator.ShapePainter as CircleShapePainter;
                        if (painter != null)
                        {
                            decorator.RadiusTransformator = radiusTransformator;
                        }
                    });
                    goblin.GetDecorators<GroundCircleDecorator>().ForEach(decorator =>
                    {
                        decorator.RadiusTransformator = radiusTransformator;
                    });
                });
                plugin.MalevolentTormentorDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.BloodThiefDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 155, 0, 255, true, false, true)
                });
                plugin.OdiousCollectorDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 0, 255, 0, true, false, true)
                });
                plugin.GemHoarderDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true)
                });
                plugin.GelatinousDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 0, 0, 255, true, false, true)
                });
                plugin.GildedBaronDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 240, 0, true, false, true)
                });
                plugin.InsufferableMiscreantDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 50, 50, true, false, true)
                });
                plugin.TreasureGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 200, 150, 150, 150, true, false, true)
                });
                plugin.RainbowGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.MenageristGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.TreasureFiendGoblinDecorators.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 163, 15, true, false, true)
                });
            });/**/
            #endregion

            //Hud.RunOnPlugin<JackCeparouCompass.DoorsPlugin>(plugin =>
            //{
            //    plugin.BridgesDecorators.GetDecorators<MapShapeDecorator>().ForEach(decorator =>
            //    {
            //        decorator.Brush = Hud.Render.CreateBrush(240, 126, 13, 255, 1);
            //    });
            //});

            Enabled = false;
        }

        //public override void PaintWorld(WorldLayer layer)
        //{
        //    Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
        //    {
        //        plugin.DecoratorByClass[Hud.Game.Me.HeroClassDefinition.HeroClass].Paint(layer, Hud.Game.Me, Hud.Game.Me.FloorCoordinate, Hud.Game.Me.BattleTagAbovePortrait);
        //    });
        //}
    }
}