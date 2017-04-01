namespace Turbo.Plugins.Jack.Decorators
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class GroundLineFromMeDecorator : IWorldDecoratorWithRadius
    {
        public bool Enabled { get; set; }
        public IController Hud { get; private set; }
        public WorldLayer Layer { get; private set; }

        public IFont TextFont { get; set; }

        public IBrush ActiveBrush { get; set; }
        public IBrush InactiveBrush { get; set; }

        public double ActiveRange { get; set; }
        public double HideRange { get; set; }
        public float ActiveStrokeWidth { get; set; }
        public float InactiveStrokeWidth { get; set; }

        public float OnLineStartOffset { get; set; }
        public float OnLineEndOffset { get; set; }

        public float Radius { get; set; }
        public float TextOffset { get; set; }
        public bool ShowText { get; set; }

        public GroundLineFromMeDecorator(IController hud)
        {
            Hud = hud;
            Enabled = true;
            Layer = WorldLayer.Ground;
            Radius = -1;
            TextOffset = 160;
            ShowText = true;

            ActiveStrokeWidth = 2f;
            InactiveStrokeWidth = ActiveStrokeWidth * 0.5f;

            OnLineStartOffset = 60;
            OnLineEndOffset = 80;
        }

        public IEnumerable<ITransparent> GetTransparents()
        {
            yield return ActiveBrush;
            yield return InactiveBrush;
            yield return TextFont;
        }

        public void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (ActiveBrush == null || InactiveBrush == null) return;

            var distance = actor.NormalizedXyDistanceToMe;
            if (distance <= HideRange) return;

            var monsterCoord = coord.ToScreenCoordinate();
            var myCoords = Hud.Game.Me.ScreenCoordinate;

            //Draw line to actor
            var start = PointOnLine(myCoords.X, myCoords.Y, monsterCoord.X, monsterCoord.Y, OnLineStartOffset);
            var end = PointOnLine(monsterCoord.X, monsterCoord.Y, myCoords.X, myCoords.Y, OnLineEndOffset);

            if (distance < ActiveRange)
            {
                ActiveBrush.DrawLine(start.X, start.Y, end.X, end.Y, ActiveStrokeWidth);
            }
            else
            {
                InactiveBrush.DrawLine(start.X, start.Y, end.X, end.Y, InactiveStrokeWidth);
            }

            if (ShowText) //Draw text
            {
                var layout = TextFont.GetTextLayout(string.Format("{0:N0}", distance));
                var p = PointOnLine(myCoords.X, myCoords.Y, monsterCoord.X, monsterCoord.Y, TextOffset);
                TextFont.DrawText(layout, p.X, p.Y);
                //textDistanceAway += 30; // avoid text overlap
            }
        }

        public IScreenCoordinate PointOnLine(float x1, float y1, float x2, float y2, float offset)
        {
            //Returns a coordinate at offset distance away from x1,y1 towards x2,y2
            var distance = (float)Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
            var ratio = offset / distance;

            var x3 = ratio * x2 + (1 - ratio) * x1;
            var y3 = ratio * y2 + (1 - ratio) * y1;
            return Hud.Window.CreateScreenCoordinate(x3, y3);
        }
    }
}