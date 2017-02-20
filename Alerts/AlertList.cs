namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class AlertList : List<Alert>
    {
        public IController Hud { get; private set; }

        public bool Up { get; set; }
        public HorizontalAlign TextAlign { get; set; }

        public float RatioTop { get; set; }
        public float RatioLeft { get; set; }
        public float RatioWidth { get; set; }
        public float RatioVerticalSpace { get; set; }

        public IList<Alert> Alerts { get; set; }

        public AlertList(IController hud)
        {
            Hud = hud;
            Up = true;
            Alerts = new List<Alert>();
            TextAlign = HorizontalAlign.Center;

            RatioTop = 0.3f;
            RatioWidth = 0.1f;
            RatioLeft = 0.5f - RatioWidth / 2;
            RatioVerticalSpace = 0.002f;
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

            var y = Hud.Window.Size.Height * RatioTop;
            var x = Hud.Window.Size.Width * RatioLeft;
            var w = Hud.Window.Size.Width * RatioWidth;
            var s = Hud.Window.Size.Height * RatioVerticalSpace;

            var alerts = Alerts.Where(a => a.Visible);
            foreach (var alert in alerts)
            {
                var alertLayout = alert.Label.TextFont.GetTextLayout(":");
                var h = alertLayout.Metrics.Height;

                alert.Label.Paint(x, y, w, h, TextAlign);

                y += Up ? -h-s : h+s;
            }
        }
    }
}