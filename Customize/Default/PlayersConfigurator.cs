namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;

    public class PlayersConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            ////////////////////
            // PLAYERS SKILLS //
            ////////////////////
            Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
            {
                plugin.SentryDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                ////plugin.SentryDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));

                plugin.SentryWithCustomEngineeringDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                ////plugin.SentryWithCustomEngineeringDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));
            });

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

            ///////////////////
            // OTHER PLAYERS //
            ///////////////////
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
        }
    }
}