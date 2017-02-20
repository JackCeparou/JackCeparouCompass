namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class PlayerBottomAlertListPlugin : BasePlugin, IInGameTopPainter, IInGameWorldPainter
    {
        public AlertList AlertList { get; set; }

        public Alert IgnorePain { get; set; }
        public Alert Oculus { get; set; }
        public Alert InnerSanctuary { get; set; }
        public Alert FlyingDragon { get; set; }

        public PlayerBottomAlertListPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            AlertList = new AlertList(Hud)
            {
                TextAlign = HorizontalAlign.Center,
                Up = false,
                RatioTop = 0.65f,
            };

            AlertList.Alerts.Add(FlyingDragon = new Alert(Hud, HeroClass.Monk)
            {
                NameSnoId = 246562,
                MessageFormat = "\u2694 {0} \u2694",
                ActiveBuffs = new BuffId[] { new BuffId(246562, 1) },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                    BackgroundBrush = Hud.Render.CreateBrush(100, 50, 200, 255, 0),
                    BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                },
            });

            AlertList.Alerts.Add(IgnorePain = new Alert(Hud, HeroClass.None)
            {
                NameSnoId = 79528,
                MessageFormat = "{0}",
                AllActiveBuffs = false,
                ActiveBuffs = new BuffId[] { new BuffId(79528, 0), new BuffId(79528, 1), },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                    BackgroundBrush = Hud.Render.CreateBrush(100, 100, 225, 100, 0),
                    BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1),
                }
            });

            AlertList.Alerts.Add(Oculus = new Alert(Hud, HeroClass.None)
            {
                NameSnoId = 3563390301,
                MessageFormat = "{0}",
                ActiveBuffs = new BuffId[] { new BuffId(402461, 2)},
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                    BackgroundBrush = Hud.Render.CreateBrush(100, 255, 255, 50, 0),
                    BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                },
            });
            //Oculus.NameFunc = (controller) => "Oculus";

            AlertList.Alerts.Add(InnerSanctuary = new Alert(Hud, HeroClass.None)
            {
                NameSnoId = 317076,
                MessageFormat = "{0}",
                ActiveBuffs = new BuffId[] { new BuffId(317076, 1)},
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                    BackgroundBrush = Hud.Render.CreateBrush(100, 185, 220, 245, 0),
                    BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                },
            });
        }

        public void PaintWorld(WorldLayer layer)
        {
            AlertList.PaintWorld(layer);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            AlertList.PaintTopInGame(clipState);
        }
    }
}