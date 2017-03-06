namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;

    public class ActorsConfigurator : IConfigurator
    {
        public void Configure(IController Hud)
        {
            ////////////
            // GLOBES //
            ////////////
            Hud.RunOnPlugin<GlobePlugin>(plugin =>
            {
                plugin.RiftOrbDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 120, 240, 3),
                    Radius = 1.5f
                });
            });

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
        }

        public void Dispose()
        {
        }
    }
}