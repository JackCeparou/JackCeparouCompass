using System;
using System.Collections.Generic;
using System.Linq;
using SharpDX;
using SharpDX.Direct2D1;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public class GroundArcDecorator_V2: IWorldDecoratorWithRadius
    {
        public bool Enabled { get; set; }
        public WorldLayer Layer { get; private set; }
        public IController Hud { get; set; }

        public IBrush Brush { get; set; }
        public IBrush BackgroundBrush { get; set; }

        private float _startAngle;
        private float _endAngle;

        public float StartAngle
        {
            get { return _startAngle; }
            set { _startAngle = Math.Max(Math.Abs(value), 0f); }
        }

        public float EndAngle
        {
            get { return _endAngle; }
            set { _endAngle = Math.Min(Math.Abs(value), 360f); }
        }

        public float Radius { get; set; }
        public float Stroke { get; set; }

        public Func<bool> IsEnabledFunc { get; set; }
        public Func<float> FilledPercentFunc { get; set; }
        public Func<GroundArcDecorator_V2, int> SectionsCountFunc { get; set; }

        public GroundArcDecorator_V2(IController hud)
        {
            Enabled = true;
            Layer = WorldLayer.Ground;
            Hud = hud;
            Radius = 1.0f;
            Stroke = 1.0f;
            StartAngle = 90f;
            EndAngle = 270f;

            IsEnabledFunc = () => true;
            SectionsCountFunc = (p) => Math.Max(10, (int) (p.EndAngle - p.StartAngle) / 9);
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (!IsEnabledFunc.Invoke()) return;
            if (Brush == null) return;
            if (Radius <= 0) return;

            var missingPercent = FilledPercentFunc == null
                ? 0f
                : (100f - FilledPercentFunc.Invoke()) / 100f;

            coord = actor == null
                ? coord
                : actor.FloorCoordinate;

            var sectionsCounts = SectionsCountFunc.Invoke(this);
            Draw(coord, StartAngle, EndAngle, sectionsCounts, missingPercent, BackgroundBrush, Brush);
        }

        private void Draw(IWorldCoordinate coord, float startAngle, float endAngle, int sectionsCount,
            float missingPercent, IBrush bgBrush, IBrush brush)
        {
            var fullAngleRange = endAngle - startAngle;
            var halfRange = fullAngleRange / 2f;
            var angleStep = fullAngleRange / sectionsCount;
            var halfStroke = Stroke / 2f;

            var start = Math.Max(startAngle, startAngle + halfRange * missingPercent);
            var end = Math.Min(endAngle, endAngle - halfRange * missingPercent);
            if (start > end || start < 0 || end < 0 || start > 360)
                return;

            using (var pg = Hud.Render.CreateGeometry())
            {
                using (var gs = pg.Open())
                {
                    var outerVectors = new List<Vector2>();
                    var innerVectors = new List<Vector2>();
                    var capsCoordinates = new List<IWorldCoordinate>();

                    for (var angle = start; angle <= end; angle += angleStep)
                    {
                        if (angle + angleStep > end) //if it's the last step
                            angle = end;

                        //convert to radiant for ease of use, and set top == 0f, counter clockwise up to 360.
                        var radians = (angle - 135f) * Math.PI / 180.0f;
                        var cos = (float) Math.Cos(radians);
                        var sin = (float) Math.Sin(radians);

                        if (angle == start || angle == end)
                            capsCoordinates.Add(coord.Offset(Radius * cos, Radius * sin, 0));

                        //outer point
                        var mx = (Radius + halfStroke) * cos;
                        var my = (Radius + halfStroke) * sin;

                        var vector = coord.ToVector2(mx, my, 0);
                        outerVectors.Add(vector);

                        //inner point
                        var mx2 = (Radius - halfStroke) * cos;
                        var my2 = (Radius - halfStroke) * sin;

                        vector = coord.ToVector2(mx2, my2, 0);
                        innerVectors.Add(vector);
                    }

                    gs.BeginFigure(outerVectors.First(), FigureBegin.Filled);
                    foreach (var v in outerVectors.Skip(1))
                    {
                        gs.AddLine(v);
                    }

                    ////TODO: if rounded cap, add half circle
                    //var capCoord = capsCoordinates.Last();
                    //for (var angle = 135f; angle < 315f; angle += 1f)
                    //{
                    //    if (angle + angleStep > end) //if it's the last step
                    //        angle = end;

                    //    //convert to radiant for ease of use, and set top == 0f, counter clockwise up to 360.
                    //    var radians = angle * Math.PI / 180.0f;
                    //    var cos = (float)Math.Cos(radians);
                    //    var sin = (float)Math.Sin(radians);

                    //    var mx = halfStroke * cos;
                    //    var my = halfStroke * sin;

                    //    var vector = capCoord.ToVector2(mx - 3, my - 3, 0);
                    //    gs.AddLine(vector);
                    //}

                    innerVectors.Reverse();
                    foreach (var v in innerVectors)
                    {
                        gs.AddLine(v);
                    }

                    //TODO: if rounded cap, add half circle

                    gs.EndFigure(FigureEnd.Closed);

                    //gs.BeginFigure(capsCoordinates.Last().ToVector2(), FigureBegin.Filled);
                    //var capCoord = capsCoordinates.Last();
                    //for (var angle = 90f; angle < 270f; angle += 9f)
                    //{
                    //    if (angle + angleStep > end) //if it's the last step
                    //        angle = end;

                    //    //convert to radiant for ease of use, and set top == 0f, counter clockwise up to 360.
                    //    var radians = angle * Math.PI / 180.0f;
                    //    var cos = (float)Math.Cos(radians);
                    //    var sin = (float)Math.Sin(radians);

                    //    var mx = halfStroke * cos;
                    //    var my = halfStroke * sin;

                    //    var vector = capCoord.ToVector2(mx, my, 0);
                    //    gs.AddLine(vector);
                    //}
                    //gs.EndFigure(FigureEnd.Closed);

                    //
                    gs.Close();

                    if (bgBrush != null)
                        bgBrush.DrawGeometry(pg);

                    brush.DrawGeometry(pg);
                }
            }
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return Brush;
            yield return BackgroundBrush;
        }


        public void Paint_OLD(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (Brush == null) return;
            if (Radius <= 0) return;
            if (!IsEnabledFunc.Invoke()) return;

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
                    var halfStroke = Stroke / 2f;

                    var start = Math.Max(startAngleFull, startAngleFull + halfRange * pct);
                    var end = Math.Min(endAngleFull, endAngleFull - halfRange * pct);

                    if (start > end)
                        return;

                    var started = false;
                    var returnVectors = new List<Vector2>();
                    var innerVectors = new List<Vector2>();
                    var innerReturnVectors = new List<Vector2>();
                    for (var angle = startAngleFull; angle <= endAngleFull; angle += angleStep)
                    {
                        var radians = (angle - 180f) * Math.PI / 180.0f;
                        var cos = (float)Math.Cos(radians);
                        var sin = (float)Math.Sin(radians);
                        var mx = (Radius + halfStroke) * cos;
                        var my = (Radius + halfStroke) * sin;

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

                        var mx2 = (Radius - halfStroke) * cos;
                        var my2 = (Radius - halfStroke) * sin;

                        vector = actor.ToVector2(mx2, my2, 0);
                        returnVectors.Add(vector);
                    }

                    returnVectors.Reverse();
                    foreach (var returnVector in returnVectors)
                    {
                        gs.AddLine(returnVector);
                    }

                    gs.EndFigure(FigureEnd.Closed);
                    gs.Close();
                }

                Brush.DrawGeometry(pg);

                if (BackgroundBrush != null)
                    BackgroundBrush.DrawGeometry(pg);
            }
        }
    }

}