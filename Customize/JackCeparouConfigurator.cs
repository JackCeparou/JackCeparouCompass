namespace Turbo.Plugins.Jack.Customize
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class JackCeparouConfigurator : BasePlugin, ICustomizer
    {
        public JackCeparouConfigurator()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin => plugin.ShowInTown = true);

            //Hud.RunOnPlugin<PickupRangePlugin>(plugin =>
            //{
            //    plugin.FillBrush = Hud.Render.CreateBrush(3, 255, 255, 255, 0);
            //    plugin.OutlineBrush = Hud.Render.CreateBrush(12, 0, 0, 0, 3);
            //});

            /*Hud.RunOnPlugin<Jack.RiftTimerPlugin>(plugin =>
            {
                plugin.ShowClosingTimer = false;
                plugin.ShowGreaterRiftTimer = true;
                plugin.ShowGreaterRiftCompletedTimer = true;
                plugin.GreaterRiftCountdown = true;

                plugin.ObjectiveProgressSymbol = "\u2694"; //?
                plugin.GuardianAliveSymbol = "\uD83D\uDC7F"; //??
                plugin.GuardianDeadSymbol = "\uD83D\uDC80"; //??

                plugin.MinutesSecondsFormat = "{0:%m}:{0:ss}";
                plugin.SecondsFormat = "{0:%s}";

                plugin.ProgressPercentFormat = "({0:F1}%)";
                plugin.ClosingSecondsFormat = "({0:%s})";

                plugin.ProgressBarTimerFont = Hud.Render.CreateFont("tahoma", 7, 224, 255, 210, 150, true, false, false);
                plugin.ProgressBarTimerFont.SetShadowBrush(222, 0, 0, 0, true);

                plugin.ObjectiveProgressFont = Hud.Render.CreateFont("tahoma", 8, 224, 240, 240, 240, false, false, false);
                plugin.ObjectiveProgressFont.SetShadowBrush(222, 0, 0, 0, true);

                plugin.CompletionDisplayLimit = 90;
                //plugin.RiftCompletionTitleFunc = () => riftQuest.QuestStep.SplashLocalized.Trim(); //DEFAULT
                plugin.RiftCompletionTitleFunc = () => "Rift completion";
                plugin.CompletionLabelDecorator = new TopLabelWithTitleDecorator(Hud)
                {
                    BorderBrush = Hud.Render.CreateBrush(255, 180, 147, 109, -1),
                    BackgroundBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 0),
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 255, 210, 150, true, false, false),
                    TitleFont = Hud.Render.CreateFont("tahoma", 6, 255, 180, 147, 109, true, false, false),
                };
            });/**/

            var itemsIds = new HashSet<uint>() { 1844495708 };
            Hud.RunOnPlugin<Jack.Alerts.PlayerTopAlertListPlugin>(plugin =>
            {
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
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

            Hud.RunOnPlugin<Jack.Alerts.MinimapLeftAlertListPlugin>(plugin =>
            {
                var ancientRank = -1;
                plugin.AlertList.VerticalCenter = false;
                plugin.AlertList.RatioSpacerY = 0;

                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2731{1}{0}{1}\u2731", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });

                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2605{1}{0}{1}\u2605", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 235, 120, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank),
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

            #endregion GoblinPlugin

            Enabled = false;
        }
    }
}