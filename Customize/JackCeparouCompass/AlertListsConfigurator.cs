using System.Windows.Forms;
using Turbo.Plugins.Default;
using Turbo.Plugins.Jack.Models;

namespace Turbo.Plugins.Jack.Customize.JackCeparouCompass
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;
    using Turbo.Plugins.Jack.Extensions;

    public class AlertListsConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            // Ramalandi
            Hud.RunOnPlugin<Jack.Alerts.PlayerTopAlertListPlugin>(plugin =>
            {
                var itemsIds = new HashSet<uint>() { 1844495708 };
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MessageFormat = "\uD83C\uDF81 {0} \uD83C\uDF81",
                    AlertTextFunc = (id) =>
                    {
                        var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.Unidentified && itemsIds.Contains(item.SnoItem.Sno));

                        if (items.Count() > 1)
                            return string.Join(", ", items.GroupBy(k => k.FullNameLocalized).Select(item => string.Format(CultureInfo.InvariantCulture, "{0} {1}", item.Count(), item.Key)));

                        return items.Count() == 1 ? items.First().FullNameLocalized : string.Empty;
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (player) => Hud.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified && itemsIds.Contains(item.SnoItem.Sno)),
                    }
                });
            });

            // dh free vault with shadow set
            Hud.RunOnPlugin<Jack.Alerts.PlayerTopAlertListPlugin>(plugin =>
            {
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MessageFormat = "\uD83C\uDF81 {0} \uD83C\uDF81",
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 11, 255, 30, 244, 30, false, false, 242, 0, 0, 0, true)
                    },
                    AlertTextFunc = (id) =>
                    {
                        return "!! Free vault !!";
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        ActiveBuffs = new SnoPowerId[] { new SnoPowerId(445266, 1), }
                    }
                });
            });

            //Hud.RunOnPlugin<Jack.Alerts.PlayerTopAlertListPlugin>(plugin =>
            //{
            //    plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
            //    {
            //        //TextSnoId = Hud.Sno.SnoPowers.LegacyOfNightmares2().Sno,
            //        MessageFormat = "{0} !",
            //        AlertTextFunc = (id) =>
            //        {
            //            return Hud.GuessLocalizedName(3758303663);
            //        },
            //        Rule =
            //        {
            //            ShowInTown = true,
            //            VisibleCondition = (player) => player.Powers.LegacyOfNightmares2() != null,
            //        }
            //    });
            //});

            //Hud.RunOnPlugin<Jack.Alerts.PlayerLeftAlertListPlugin>(plugin =>
            //{
            //    plugin.AlertList.VerticalCenter = false;
            //    plugin.AlertList.RatioSpacerY = 0;

            //    plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
            //    {
            //        MultiLine = true,
            //        LinesFunc = () =>
            //        {
            //            var gems = Hud.Game.Me.Powers.UsedLegendaryPowers.EquippedLegendaryGemsBuffs();

            //            return gems.Where(x => x.Active).Select(buff => string.Format(CultureInfo.InvariantCulture, "{0} : {1}", buff.SnoPower.Sno, buff.SnoPower.Code));
            //        },
            //        Label =
            //        {
            //            TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
            //        },
            //        Rule =
            //        {
            //            ShowInTown = true,
            //        }
            //    });
            //});


            // Loot list near Minimap
            Hud.RunOnPlugin<Jack.Alerts.MinimapLeftAlertListPlugin>(plugin =>
            {
                var ancientRank = -1;
                plugin.AlertList.VerticalCenter = false;
                plugin.AlertList.RatioSpacerY = 0;

                // Set
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2731{1}{0}{1}\u2731", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (player) => Hud.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno != uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });

                // Legendary
                plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
                {
                    MultiLine = true,
                    LinesFunc = () =>
                    {
                        return Hud.Game.Items
                                .Where(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank)
                                .Select(item => string.Format(CultureInfo.InvariantCulture, "\u2605{1}{0}{1}\u2605", item.SnoItem.NameLocalized, item.AncientRank > 0 ? " \uD83E\uDC1D " : " "));
                    },
                    Label =
                    {
                        TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 235, 120, 0, false, false, true),
                    },
                    Rule =
                    {
                        ShowInTown = true,
                        VisibleCondition = (player) => Hud.Game.Items.Any(item => item.Location == ItemLocation.Floor && item.Unidentified && item.SetSno == uint.MaxValue && item.AncientRank > ancientRank),
                    }
                });
            });

            /* show all buffs */
            //Hud.RunOnPlugin<Jack.Alerts.PlayerLeftAlertListPlugin>(plugin =>
            //{
            //    plugin.AlertList.Up = false;
            //    plugin.AlertList.RatioX = 0.02f;
            //    plugin.AlertList.RatioY = 0.1f;
            //    plugin.AlertList.VerticalCenter = false;
            //    plugin.AlertList.TextAlign = HorizontalAlign.Left;
            //    plugin.AlertList.RatioSpacerY = 0;

            //    plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
            //    {
            //        MultiLine = true,
            //        LinesFunc = () =>
            //        {
            //            return
            //                Hud.Game.Me.Powers.AllBuffs
            //                    .Where(buff => buff != null && buff.SnoPower != null && !string.IsNullOrEmpty(buff.SnoPower.NameEnglish))
            //                    .OrderBy(buff => buff.SnoPower.Sno)
            //                    .Select(buff => string.Join(
            //                        " | ",
            //                        buff.SnoPower.NameEnglish,
            //                        buff.SnoPower.Sno.ToString(),
            //                        buff.SnoPower.Code,
            //                        buff.Active,
            //                        //string.Format("{0:0.#}", buff.TimeLeft()),
            //                        string.Join(", ", buff.IconCounts.Select(i => string.Format("{0:0.#}", i))),
            //                        string.Join(", ", buff.TimeLeftSeconds.Select(t => string.Format("{0:0.#}", t)))
            //                        ));
            //        },
            //        Label =
            //        {
            //            TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
            //        },
            //        Rule =
            //        {
            //            ShowInTown = true,
            //            VisibleCondition = (player) => /*Hud.Game.IsInTown &&*/ Hud.Input.IsKeyDown(Keys.B),
            //        }
            //    });

            //    plugin.AlertList.Alerts.Add(new Jack.Alerts.Alert(Hud)
            //    {
            //        MultiLine = true,
            //        LinesFunc = () =>
            //        {
            //            return
            //                Hud.Game.Me.Powers.AllBuffs
            //                    .Where(buff => buff != null && buff.SnoPower != null && /*buff.SnoPower.Sno == 430674 &&*/ string.IsNullOrEmpty(buff.SnoPower.NameEnglish))
            //                    .OrderBy(buff => buff.SnoPower.Sno)
            //                    .Select(buff => string.Join(
            //                        " | ",
            //                        buff.SnoPower.Sno.ToString(),
            //                        buff.SnoPower.Code,
            //                        buff.Active,
            //                        //string.Format("{0:0.#}", buff.TimeLeft()),
            //                        string.Join(", ", buff.IconCounts.Select(i => string.Format("{0:0.#}", i))),
            //                        string.Join(", ", buff.TimeLeftSeconds.Select(t => string.Format("{0:0.#}", t)))
            //                        ));
            //        },
            //        Label =
            //        {
            //            TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 0, 170, 0, false, false, true),
            //        },
            //        Rule =
            //        {
            //            ShowInTown = true,
            //            VisibleCondition = (player) => /*Hud.Game.IsInTown &&*/ Hud.Input.IsKeyDown(Keys.B),
            //        }
            //    });
            //});/*end*/
        }
    }
}