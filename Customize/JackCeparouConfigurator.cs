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