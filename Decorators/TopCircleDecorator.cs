using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Decorators
{
    // this is not a plugin, just a helper class to display a circle on the ground
    public class TopCircleDecorator
    {
        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; private set; }

        public IBrush Brush { get; set; }
        public IBrush ShadowBrush { get; set; }
        public bool HasShadow { get; set; }

        public float Radius { get; set; }
        public IRadiusTransformator RadiusTransformator { get; set; }

        public TopCircleDecorator(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Ground;
            Hud = hud;
            ShadowBrush = Hud.Render.CreateBrush(96, 0, 0, 0, 1);
            HasShadow = true;
        }

        public void Paint(float x, float y)
        {
            if (!Enabled) return;
            if (Brush == null) return;

            var radius = RadiusTransformator != null ? RadiusTransformator.TransformRadius(Radius) : Radius;

            if (HasShadow)
            {
                if (Brush.StrokeStyle.DashStyle == SharpDX.Direct2D1.DashStyle.Solid)
                {
                    ShadowBrush.StrokeWidth = Brush.StrokeWidth >= 0 ? Brush.StrokeWidth + 1 : Brush.StrokeWidth - 1;
                    ShadowBrush.DrawEllipse(x, y, radius, radius, -1);
                }
            }

            Brush.DrawEllipse(x, y, radius, radius, -1);
        }
    }
}