namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;

    public class MonstersConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            // I'M BRAVE ENOUGH
            Hud.TogglePlugin<MonsterPackPlugin>(true);
            Hud.TogglePlugin<EliteMonsterAffixPlugin>(false);

            /////////////
            // GOBLINS //
            /////////////
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
        }
    }
}