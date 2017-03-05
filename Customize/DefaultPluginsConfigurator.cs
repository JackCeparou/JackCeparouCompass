namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;

    public class DefaultPluginsConfigurator : BasePlugin, ICustomizer
    {
        public DefaultPluginsConfigurator()
        {
            Enabled = true;
        }

        public void Customize()
        {
            // I'M BRAVE ENOUGH
            Hud.TogglePlugin<MonsterPackPlugin>(true);
            Hud.TogglePlugin<EliteMonsterAffixPlugin>(false);
            /////////////////////////////////////////////////

            Hud.TogglePlugin<DebugPlugin>(true);
            // disable some default plugins
            Hud.TogglePlugin<MultiplayerExperienceRangePlugin>(false);
            Hud.TogglePlugin<PortraitBottomStatsPlugin>(false);
            Hud.TogglePlugin<SkillRangeHelperPlugin>(false);

            //Hud.RunOnPlugin<BountyTablePlugin>(plugin =>
            //{
            //    plugin.ToggleKeyEvent = Hud.Input.CreateKeyEvent(true, Key.F8, false, false, false);
            //});

            ///////////////////
            // PICKUP RADIUS //
            ///////////////////
            Hud.RunOnPlugin<PickupRangePlugin>(plugin =>
            {
                plugin.FillBrush = Hud.Render.CreateBrush(12, 255, 255, 255, 0);
                plugin.OutlineBrush = Hud.Render.CreateBrush(30, 0, 0, 0, 3);
            });

            ///////////////
            // SKILL BAR //
            ///////////////
            // disable dps on skill bar
            Hud.RunOnPlugin<OriginalSkillBarPlugin>(plugin =>
            {
                plugin.SkillPainter.EnableSkillDpsBar = false;
            });

            ///////////////////////
            // STASH & INVENTORY //
            ///////////////////////
            Hud.RunOnPlugin<InventoryAndStashPlugin>(plugin =>
            {
                // enable sell darkening
                //inventoryAndStashPlugin.SellEnabled = true;

                // shh, go away blinking cube!
                plugin.CanCubedEnabled = false;

                // ancient rank font
                plugin.AncientRankFont = Hud.Render.CreateFont("arial", 8, 224, 255, 64, 64, true, false, false);
                plugin.AncientRankFont.SetShadowBrush(224, 0, 0, 0, true);

                plugin.SocketedLegendaryGemRankFont = Hud.Render.CreateFont("arial", 7, 255, 240, 240, 64, true, false, false);
                plugin.SocketedLegendaryGemRankFont.SetShadowBrush(128, 0, 0, 0, true);

                // change darken brush to a lighter one
                //inventoryAndStashPlugin.DarkenBrush = Hud.Render.CreateBrush(120, 38, 38, 38, 0);

                plugin.NotGoodDisplayEnabled = true;
                plugin.DefinitelyBadDisplayEnabled = true;
                //plugin.LooksGoodDisplayEnabled = true;
            });

            ///////////
            // ITEMS //
            ///////////
            Hud.RunOnPlugin<ItemsPlugin>(plugin =>
            {
                //itemsPlugin.NormalKeepDecorator.Enabled = true;
                //itemsPlugin.MagicKeepDecorator.Enabled = true;
                //itemsPlugin.RareKeepDecorator.Enabled = true;
                plugin.DeathsBreathDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 102, 202, 177, -2),
                    Radius = 1.25f,
                });
            });

            ////////////////////////
            // EXPLOSIVE MONSTERS //
            ////////////////////////
            //var explosiveMonsterPlugin = Hud.GetPlugin<ExplosiveMonsterPlugin>();
            //if (explosiveMonsterPlugin != null)
            //{
            //    explosiveMonsterPlugin.InRiftDecorator.Add(new GroundTimerDecorator(Hud)
            //    {
            //        CountDownFrom = 3,
            //        BackgroundBrushEmpty = Hud.Render.CreateBrush(64, 0, 0, 0, 0),
            //        BackgroundBrushFill = Hud.Render.CreateBrush(160, 255, 255, 255, 0),
            //        Radius = 20
            //    });
            //}

            /////////////
            // BANNERS //
            /////////////
            //var bannerPlugin = Hud.GetPlugin<BannerPingPlugin>();
            //if (bannerPlugin != null)
            //{
            //    bannerPlugin.InRiftDecorator.Add(new GroundCircleDecorator(Hud)
            //    {
            //        Brush = Hud.Render.CreateBrush(178, 0, 255, 0, 3),
            //        Radius = 8,
            //        RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250),
            //    });
            //    bannerPlugin.InRiftDecorator.Add(new MapShapeDecorator(Hud)
            //    {
            //        Brush = Hud.Render.CreateBrush(178, 0, 255, 0, 3),
            //        ShapePainter = new CircleShapePainter(Hud),
            //        Radius = 8,
            //        RadiusTransformator = new StandardPingRadiusTransformator(Hud, 250),
            //    });
            //}

            /////////////
            // SHRINES //
            /////////////
            Hud.RunOnPlugin<ShrinePlugin>(plugin =>
            {
                plugin.AllShrineDecorator.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 6f, 192, 255, 255, 55, false, false, 128, 0, 0, 0, true),
                    RadiusOffset = 5.0f,
                });
            });

            ////////////////////
            // OTHERS PLAYERS //
            ////////////////////
            /*
            Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
            {
                plugin.DecoratorByClass.ForEach(wd =>
                {
                    wd.Value.GetDecorators<GroundLabelDecorator>().ForEach(d => d.Enabled = false);
                });

                plugin.NameOffsetZ = 0;

                plugin.DecoratorByClass[HeroClass.Crusader].Decorators.Add(new MapShapeDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 250, 10, 10, 5),
                    ShapePainter = new CircleShapePainter(Hud),
                    Radius = 2f,
                });
                plugin.DecoratorByClass[HeroClass.Crusader].Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(200, 250, 10, 10, 5),
                    Radius = 4f
                });
            });/**/

            Hud.RunOnPlugin<PlayerBottomBuffListPlugin>(plugin =>
            {
                plugin.BuffPainter.ShowTimeLeftNumbers = true;
                plugin.BuffPainter.Opacity = 0.85f;

                // Iron Skin
                plugin.RuleCalculator.Rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });
            });

            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                plugin.LabelList.WidthFunc = () => Hud.Window.Size.Height * 0.0630f;

                plugin.LabelList.LabelDecorators[9].TextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                plugin.LabelList.LabelDecorators[9].HintFunc = () => "pickup radius";

                /*var index = 9; //0..9
                if (index < plugin.LabelList.LabelDecorators.Count && index >= 0)
                {
                    plugin.LabelList.LabelDecorators[index].AlertTextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                    plugin.LabelList.LabelDecorators[index].HintFunc = () => "pickup radius";
                }/**/
            });

            Hud.RunOnPlugin<GlobePlugin>(plugin =>
            {
                plugin.RiftOrbDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 120, 240, 3),
                    Radius = 1.5f
                });
            });

            Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
            {
                plugin.SentryDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                //plugin.SentryDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));

                plugin.SentryWithCustomEngineeringDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                //plugin.SentryWithCustomEngineeringDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));
            });

            //Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
            //{
            //    plugin.DecoratorByClass[HeroClass.Barbarian].GetDecorators<MapLabelDecorator>().ForEach(d =>
            //    {
            //        d.LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 0, false, false, 128, 0, 0, 0, true);
            //        d.Up = true;
            //    });
            //    plugin.DecoratorByClass[HeroClass.Barbarian].GetDecorators<GroundLabelDecorator>().ForEach(d =>
            //    {
            //        d.BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 1);
            //        d.TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 0, false, false, 128, 0, 0, 0, true);
            //    });
            //});

            //Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            //{
            //    plugin.AllGoblinDecorators().ForEach(decorators =>
            //    {
            //        decorators.ToggleDecorators<GroundLabelDecorator>(false);
            //        decorators.Add(new Jack.Decorators.GroundCustomLabelDecorator(Hud)
            //        {
            //            TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 0, true, false, true),
            //            TextFunc = () => "BLA-BLA",
            //            OffsetX = -40f,
            //            OffsetY = 30f,
            //        });
            //    });
            //});

            Hud.RunOnPlugin<HoveredItemInfoPlugin>(plugin =>
            {
                StringGeneratorFunc func = () => string.Format("{0}{1}", Hud.Inventory.HoveredItem.AncientRank > 0 ? "\uD83E\uDC1D " : string.Empty, Hud.Inventory.HoveredItem.SnoItem.NameLocalized);
                plugin.LegendaryNameDecorator.TextFunc = func;
                plugin.SetNameDecorator.TextFunc = func;
            });

            Hud.RunOnPlugin<GoblinPlugin>(plugin =>
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

                plugin.MalevolentTormentorDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.BloodThiefDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 155, 0, 255, true, false, true)
                });
                plugin.OdiousCollectorDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 0, 255, 0, true, false, true)
                });
                plugin.GemHoarderDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, true, false, true)
                });
                plugin.GelatinousDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 0, 0, 255, true, false, true)
                });
                plugin.GildedBaronDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 240, 0, true, false, true)
                });
                plugin.InsufferableMiscreantDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 50, 50, true, false, true)
                });
                plugin.DefaultGoblinDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 200, 150, 150, 150, true, false, true)
                });
                plugin.RainbowGoblinDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.MenageristGoblinDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 0, true, false, true)
                });
                plugin.TreasureFiendGoblinDecorator.Decorators.Add(new MapLabelDecorator(Hud)
                {
                    LabelFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 163, 15, true, false, true)
                });
            });/**/

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