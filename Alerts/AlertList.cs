namespace Turbo.Plugins.Jack.Alerts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class AlertList
    {
        public IController Hud { get; private set; }

        public bool Up { get; set; }
        public bool VerticalCenter { get; set; }
        public HorizontalAlign TextAlign { get; set; }

        public float RatioX { get; set; }
        public float RatioY { get; set; }
        public float RatioWidth { get; set; }
        public float RatioPaddingY { get; set; }
        public float RatioSpacerY { get; set; }
        public Func<IController, float> RightFunc { get; set; }

        public IList<Alert> Alerts { get; set; }

        public AlertList(IController hud)
        {
            Hud = hud;
            Up = true;
            Alerts = new List<Alert>();
            TextAlign = HorizontalAlign.Center;

            RatioX = 0.5f;
            RatioY = 0.3f;
            RatioWidth = 0.2f;
            RatioPaddingY = 0.003f;
            RatioSpacerY = 0.002f;
        }

        public void PaintWorld(WorldLayer layer)
        {
            var alerts = Alerts.Where(a => a.Enabled && a.PlayerDecorators != null && a.Visible);
            foreach (var alert in alerts)
            {
                alert.PlayerDecorators.Paint(layer, Hud.Game.Me, Hud.Game.Me.FloorCoordinate, alert.Label.TextFunc.Invoke());
            }

            alerts = Alerts.Where(a => a.Enabled && a.ActorDecorators != null && a.Visible);
            foreach (var alert in alerts)
            {
                var actors = Hud.Game.Actors.Where(m => m.DisplayOnOverlay && alert.Rule.ActorSnoIds.Contains(m.SnoActor.Sno));
                foreach (var actor in actors)
                {
                    alert.ActorDecorators.Paint(layer, actor, actor.FloorCoordinate, alert.Label.TextFunc.Invoke());
                }
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            var x = Hud.Window.Size.Width * RatioX;
            var y = Hud.Window.Size.Height * RatioY;
            var w = Hud.Window.Size.Height * RatioWidth;
            var s = Hud.Window.Size.Height * RatioSpacerY;
            var p = Hud.Window.Size.Height * RatioPaddingY;

            if (RightFunc != null)
            {
                x = RightFunc.Invoke(Hud);
            }

            switch (TextAlign)
            {
                case HorizontalAlign.Center:
                    x -= w / 2;
                    break;

                case HorizontalAlign.Right:
                    x -= w;
                    break;
            }

            var alerts = Alerts.Where(a => a.Enabled && a.Visible);
            if (VerticalCenter)
            {
                Up = false;
                var heigth = alerts.Select(a => a.Label.TextFont.GetTextLayout(":").Metrics.Height + s + p * 2).Sum() - s - p * 2;
                //y += Up ? heigth / 2 : -heigth / 2;
                y -= heigth / 2;
            }
            foreach (var alert in alerts)
            {
                var alertLayout = alert.Label.TextFont.GetTextLayout(":");
                var h = alertLayout.Metrics.Height;

                if (alert.MultiLine && alert.LinesFunc != null)
                {
                    foreach (var line in alert.LinesFunc.Invoke())
                    {
                        alert.AlertText = line;
                        alert.Label.Paint(x, y - p, w, h + p * 2, TextAlign);
                        y += Up ? -h : h;
                    }
                    //h = h + s + p * 2;
                }
                else
                {
                    alert.Label.Paint(x, y - p, w, h + p * 2, TextAlign);
                    h = h + s + p * 2;
                    y += Up ? -h : h;
                }
            }
        }
    }
}