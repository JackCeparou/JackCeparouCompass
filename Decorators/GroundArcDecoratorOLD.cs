using System;
using System.Collections.Generic;
using SharpDX.Direct2D1;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public class GroundArcDecoratorOLD: IWorldDecoratorWithRadius
    {

        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; set; }

        public IBrush Brush { get; set; }
        public IBrush ShadowBrush { get; set; }

        public float Radius { get; set; }

        public Func<bool> IsShownFunc { get; set; }
        public Func<float> FilledPercentFunc { get; set; }

        public GroundArcDecoratorOLD(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Ground;
            Hud = hud;
            Radius = 1.0f;

            IsShownFunc = () => true;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (Brush == null) return;
            if (Radius <= 0) return;
            if (!IsShownFunc.Invoke()) return;

            var pct = FilledPercentFunc == null ? 100 : FilledPercentFunc.Invoke();

            using (var pg = Hud.Render.CreateGeometry())
            {
                using (var gs = pg.Open())
                {
                    var startAngleFull = 90f;
                    var endAngleFull = 360f;
                    var fullAngleRange = endAngleFull - startAngleFull;
                    var halfRange = fullAngleRange / 2f;
                    var angleStep = fullAngleRange / 90f;

                    var start = Math.Max(startAngleFull, startAngleFull + halfRange * pct);
                    var end = Math.Min(endAngleFull, endAngleFull - halfRange * pct);

                    if (start > end)
                        return;

                    var started = false;
                    for (var angle = start; angle <= end; angle += angleStep)
                    {
                        var radians = (angle - 180f) * Math.PI / 180.0f;
                        var cos = (float)Math.Cos(radians);
                        var sin = (float)Math.Sin(radians);
                        var mx = Radius * cos;
                        var my = Radius * sin;

                        var vector = actor.ToVector2(mx, my, 0);

                        if (started)
                        {
                            gs.AddLine(vector);
                        }
                        else
                        {
                            started = true;
                            gs.BeginFigure(vector, FigureBegin.Filled);
                        }
                    }

                    gs.EndFigure(FigureEnd.Open);
                    gs.Close();
                }

                if (ShadowBrush != null)
                    ShadowBrush.DrawGeometry(pg);

                Brush.DrawGeometry(pg);
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return Brush;
            yield return ShadowBrush;
        }

    }

}