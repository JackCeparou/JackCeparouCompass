using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;
using Turbo.Plugins.Default;
using Turbo.Plugins.Resu;

namespace Turbo.Plugins.Jack
{
    [Flags]
    public enum CapStyle
    {
        Flat = 1,
        Rounded = 2,
        Fixed = 4,
        FlatFixed = Fixed | Flat,
        RoundedFixed = Fixed | Rounded,
    }

    public static class BrushExtensions
    {
        public static IController Hud { get; set; }

        public static void Draw(this IBrush brush,
            float radius, int sectionsCount, float stroke,
            IWorldCoordinate coord,
            float startAngle, float endAngle,
            CapStyle endCapStyle = CapStyle.Flat, CapStyle startCapStyle = CapStyle.Flat,
            float missingPercent = 0, IBrush bgBrush = null)
        {
            var fullAngleRange = endAngle - startAngle;
            var halfRange = fullAngleRange / 2f;
            var angleStep = fullAngleRange / sectionsCount;
            var halfStroke = stroke / 2f;

            var start = Math.Max(startAngle, startAngle + halfRange * missingPercent);
            var end = Math.Min(endAngle, endAngle - halfRange * missingPercent);
            if (start > end || start < 0 || end < 0 || start > 360)
                return;

            using (var pg = Hud.Render.CreateGeometry())
            {
                using (var gs = pg.Open())
                {
                    var started = false;
                    var outerVectors = new List<Vector2>();
                    var innerVectors = new List<Vector2>();

                    for (var angle = start; angle <= end; angle += angleStep)
                    {
                        if (angle + angleStep > end) //if it's the last step, round the end
                            angle = end;

                        //convert to radiant for ease of use, and set top == 0f, counter clockwise up to 360.
                        var radians = (angle - 135f) * Math.PI / 180.0f;
                        var cos = (float)Math.Cos(radians);
                        var sin = (float)Math.Sin(radians);

                        //outer point
                        var mx = (radius + halfStroke) * cos;
                        var my = (radius + halfStroke) * sin;

                        var vector = coord.ToVector2(mx, my, 0);

                        if (started)
                        {
                        }

                        if (!started)
                        {
                            started = true;
                            gs.BeginFigure(vector, FigureBegin.Filled);
                        }

                        outerVectors.Add(vector);

                        //inner point, store for later use
                        var mx2 = (radius - halfStroke) * cos;
                        var my2 = (radius - halfStroke) * sin;

                        vector = coord.ToVector2(mx2, my2, 0);
                        innerVectors.Add(vector);
                    }

                    foreach (var v in outerVectors.Skip(1))
                    {
                        gs.AddLine(v);
                    }

                    //TODO: if rounded cap, add half circle
                    innerVectors.Reverse();
                    foreach (var v in innerVectors)
                    {
                        gs.AddLine(v);
                    }
                    //TODO: if rounded cap, add half circle

                    gs.EndFigure(FigureEnd.Closed);
                    gs.Close();

                    if (bgBrush != null)
                        bgBrush.DrawGeometry(pg);

                    brush.DrawGeometry(pg);
                }
            }
        }

        public static void DrawWorldCirclePartial(this IBrush brush,
            float radius, int sectionsCount, float stroke,
            IWorldCoordinate coord,
            float startAngle, float endAngle,
            CapStyle endCapStyle = CapStyle.Flat, CapStyle startCapStyle = CapStyle.Flat,
            float missingPercent = 0, IBrush bgBrush = null)
        {
            var fullAngleRange = endAngle - startAngle;
            var halfRange = fullAngleRange / 2f;
            var halfStroke = stroke / 2f;

            var start = Math.Max(startAngle, startAngle + halfRange * missingPercent);
            var end = Math.Min(endAngle, endAngle - halfRange * missingPercent);
            if (start > end || start < 0 || end < 0 || start > 360)
                return;

            using (var pg = Hud.Render.CreateGeometry())
            {
                using (var gs = pg.Open())
                {
                    var outerVectors = ArcVectors(radius + halfStroke, coord, start, end, sectionsCount);
                    var innerVectors = ArcVectors(radius - halfStroke, coord, start, end, sectionsCount);

                    gs.BeginFigure(outerVectors.First(), FigureBegin.Filled);
                    foreach (var v in outerVectors.Skip(1))
                    {
                        gs.AddLine(v);
                    }

                    //TODO: if rounded cap, add half circle
                    innerVectors.Reverse();
                    foreach (var v in innerVectors)
                    {
                        gs.AddLine(v);
                    }
                    //TODO: if rounded cap, add half circle

                    gs.EndFigure(FigureEnd.Closed);
                    gs.Close();

                    if (bgBrush != null)
                        bgBrush.DrawGeometry(pg);

                    brush.DrawGeometry(pg);
                }
            }
        }

        private static List<Vector2> ArcVectors(float radius, IWorldCoordinate coord, float start, float end, int sectionsCount)
        {
            var angleStep = (end - start) / sectionsCount;
            var vectors = new List<Vector2>();
            for (var angle = start; angle <= end; angle += angleStep)
            {
                if (angle + angleStep > end) //if it's the last step, round the end
                    angle = end;

                //convert to radiant for ease of use, and set top == 0f, counter clockwise up to 360.
                var radians = (angle - 135f) * Math.PI / 180.0f;
                var cos = (float) Math.Cos(radians);
                var sin = (float) Math.Sin(radians);

                var mx = radius * cos;
                var my = radius * sin;

                var vector = coord.ToVector2(mx, my, 0);
                vectors.Add(vector);
            }

            return vectors;
        }
    }

    public class BrushExtensionsPlugin : BasePlugin
    {
        public BrushExtensionsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            BrushExtensions.Hud = hud;
            Enabled = false;
        }
    }
}
