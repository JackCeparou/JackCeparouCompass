namespace Turbo.Plugins.JackCeparouCompass.Customize
{
    using Turbo.Plugins.Default;

    public class JackCeparouConfigurator : BasePlugin
    {
        public JackCeparouConfigurator()
        {
            Enabled = true;
        }

        public override void Customize()
        {
            Hud.RunOnPlugin<JackCeparouCompass.Actors.DoorsPlugin>(plugin => plugin.ShowInTown = true);

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
            });

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