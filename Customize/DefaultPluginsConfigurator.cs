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

            Hud.RunOnPlugin<InventoryAndStashPlugin>(plugin =>
            {
                plugin.NotGoodDisplayEnabled = true;
                plugin.DefinitelyBadDisplayEnabled = true;
                //plugin.LooksGoodDisplayEnabled = true;
            });

            //Hud.RunOnPlugin<FeetBuffListPlugin>(plugin =>
            //{
            //    plugin.BuffPainter.ShowTimeLeftNumbers = true;
            //    plugin.BuffPainter.Opacity = 0.85f;

            //    // Iron Skin
            //    plugin.RuleCalculator.Rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });
            //});

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
            //});

            //Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            //{
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
            });

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