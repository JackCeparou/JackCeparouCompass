namespace Turbo.Plugins.Jack.Customize.JackCeparouCompass
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class AlertListsConfigurator : IConfigurator
    {
        public void Configure(IController Hud)
        {
            var itemsIds = new HashSet<uint>() { 1844495708 };
            Hud.RunOnPlugin<Jack.Alerts.PlayerTopAlertListPlugin>(plugin =>
            {
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MessageFormat = "\uD83C\uDF81 {0} \uD83C\uDF81",//??
                    AlertTextFunc = (id) =>
                    {
                        var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && itemsIds.Contains(item.SnoItem.Sno));

                        if (items.Count() > 1)
                            return string.Join(", ", items.GroupBy(k => k.FullNameLocalized).Select(item => string.Format(CultureInfo.InvariantCulture, "{0} {1}", item.Count(), item.Key)));

                        return items.Count() == 1 ? items.First().FullNameLocalized : string.Empty;
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && itemsIds.Contains(item.SnoItem.Sno)),
                    }
                });
            });

            Hud.RunOnPlugin<Jack.Alerts.MinimapLeftAlertListPlugin>(plugin =>
            {
                var ancientRank = -1;
                plugin.AlertList.VerticalCenter = false;
                plugin.AlertList.RatioSpacerY = 0;

                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2731{1}{0}{1}\u2731", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });

                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2605{1}{0}{1}\u2605", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 235, 120, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (controller) => controller.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified/**/ && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });
            });
        }

        public void Dispose()
        {
        }
    }
}