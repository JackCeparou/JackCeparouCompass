// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
// *.txt files are not loaded automatically by TurboHUD
// you have to change this file's extension to .cs to enable it
// ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Models;

    public class AlertListSampleCustomizationPlugin : BasePlugin, ICustomizer
    {
        public AlertListSampleCustomizationPlugin()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<PlayerBottomAlertListPlugin>(plugin =>
            {
                var list = plugin.AlertList;
                list.Up = false; // up or down
                list.RatioY = 0.6f;
                list.RatioWidth = 0.2f; // based on screen height to preserve proportions
                list.RatioX = 0.5f; // center horizontally

                // Flying Dragon
                list.Alerts.Add(new Alert(Hud, HeroClass.Monk)
                {
                    TextSnoId = 3968109489,
                    MessageFormat = "\u2694 {0} \u2694",//⚔
                    Rule =
                    {
                        ActiveBuffs = new [] { new SnoPowerId(246562, 1) },
                    },
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
                    TextSnoId = 79528,
                    MessageFormat = "\uD83D\uDEE1 {0} \uD83D\uDEE1",//🛡
                    Rule =
                    {
                        AllActiveBuffs = false,
                        ActiveBuffs = new [] { new SnoPowerId(79528, 0), new SnoPowerId(79528, 1), },
                    },
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
                    //AlertTextFunc = (id) => "Oculus",
                    TextSnoId = 3563390301,
                    MessageFormat = "\u2694 {0} \u2694",//⚔
                    Rule =
                    {
                        ActiveBuffs = new [] { new SnoPowerId(402461, 2) },
                    },
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
                    TextSnoId = 317076,
                    MessageFormat = "\uD83D\uDEE1 {0} \uD83D\uDEE1",//🛡
                    Rule =
                    {
                        ActiveBuffs = new [] { new SnoPowerId(317076, 1) },
                    },
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