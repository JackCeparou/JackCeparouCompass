namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class AlertPlugin : BasePlugin, ICustomizer
    {
        public AlertPlugin()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<PlayerBottomAlertListPlugin>(plugin =>
            {
                var list = plugin.AlertList;
                list.RatioTop = 0.6f;
                list.RatioWidth = 0.06f;
                list.RatioLeft = 0.5f - list.RatioWidth / 2;

                // Flying Dragon
                list.Alerts.Add(new Alert(Hud, HeroClass.Monk)
                {
                    NameSnoId = 246562,
                    MessageFormat = "\u2694 {0} \u2694",
                    ActiveBuffs = new PowerSnoId[] { new PowerSnoId(246562, 1) },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                        BackgroundBrush = Hud.Render.CreateBrush(100, 50, 200, 255, 0),
                        BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                    },
                });
                // Ignore Pain
                list.Alerts.Add(new Alert(Hud, HeroClass.None)
                {
                    NameSnoId = 79528,
                    MessageFormat = "{0}",
                    AllActiveBuffs = false,
                    ActiveBuffs = new PowerSnoId[] { new PowerSnoId(79528, 0), new PowerSnoId(79528, 1), },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                        BackgroundBrush = Hud.Render.CreateBrush(100, 100, 225, 100, 0),
                        BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1),
                    }
                });
                // Oculus
                list.Alerts.Add(new Alert(Hud, HeroClass.None)
                {
                    //.NameFunc = (controller) => "Oculus",
                    NameSnoId = 3563390301,
                    MessageFormat = "{0}",
                    ActiveBuffs = new PowerSnoId[] { new PowerSnoId(402461, 2) },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                        BackgroundBrush = Hud.Render.CreateBrush(100, 255, 255, 50, 0),
                        BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                    },
                });
                // Inner Sanctuary
                list.Alerts.Add(new Alert(Hud, HeroClass.None)
                {
                    NameSnoId = 317076,
                    MessageFormat = "{0}",
                    ActiveBuffs = new PowerSnoId[] { new PowerSnoId(317076, 1) },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 9, 255, 244, 244, 244, false, false, 242, 0, 0, 0, true),
                        BackgroundBrush = Hud.Render.CreateBrush(100, 185, 220, 245, 0),
                        BorderBrush = Hud.Render.CreateBrush(178, 0, 0, 0, 1)
                    },
                });
            });
        }
    }
}