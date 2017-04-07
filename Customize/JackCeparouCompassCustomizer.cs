using System;
using Turbo.Plugins.Jack.Labs;
using Turbo.Plugins.Jack.Players;

namespace Turbo.Plugins.Jack.Customize
{
    //using System.Collections.Generic;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Actors;
    using Turbo.Plugins.Jack.Customize.JackCeparouCompass;

    public class JackCeparouCompassCustomizer : BasePlugin, ICustomizer
    {
        public JackCeparouCompassCustomizer()
        {
            Enabled = true;
            Order = 44;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            //Says.Debug("J1 {0} {1}", "Load", Order);
        }

        public void Customize()
        {
            //Says.Debug("J2 {0} {1}", "Customize", Order);

            Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin => plugin.ShowInTown = true);
            //Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin =>
            //{
            //    plugin.BridgesDecorators.ToggleDecorators<GroundLabelDecorator>(false);
            //    plugin.DoorsDecorators.ToggleDecorators<GroundLabelDecorator>(false);
            //    plugin.BreakablesDoorsDecorators.ToggleDecorators<GroundLabelDecorator>(false);
            //});

            //Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin => { plugin.Affixes.Clear(); });

            using (var alertListsConfigurator = new AlertListsConfigurator())
            {
                alertListsConfigurator.Configure(Hud);
            }

            ////////////
            // SKILLS //
            ////////////
            Hud.RunOnPlugin<Jack.Players.PlayerSkillCooldownSoundAlertPlugin>(plugin =>
            {
                plugin.InTown = true;
                plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
                //plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk, "Walk"); // custom name
                //plugin.Add(106237); // by sno
                //plugin.Add(106237, "Walk"); // by sno with custom name

                // remove entries
                //plugin.Remove(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
                //plugin.Remove(106237);

                // clear all
                //plugin.Clear();
            });

            ///////////
            // ITEMS //
            ///////////
            Hud.RunOnPlugin<DefaultOverride.Items.ItemsPlugin>(plugin =>
            {
                //itemsPlugin.NormalKeepDecorator.Enabled = true;
                //itemsPlugin.MagicKeepDecorator.Enabled = true;
                //itemsPlugin.RareKeepDecorator.Enabled = true;
                plugin.DeathsBreathDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(192, 102, 202, 177, -2),
                    Radius = 1.25f,
                });
            });

            //Hud.RunOnPlugin<Grischu.BuffStatistic.BuffStatistics>(plugin =>
            //{
            //    //plugin.Enabled = false;
            //    Says.Debug(1);
            //    plugin.AddBuff(403464, 1, "Gogok");
            //    Says.Debug(2);
            //    plugin.AddBuff(359583, 1, "Focus");
            //    plugin.AddBuff(359583, 2, "Restraint");
            //    plugin.XPos = Hud.Window.Size.Width * 0.8f;
            //    plugin.YPos = Hud.Window.Size.Height * 0.5f;
            //});

            //Hud.RunOnPlugin<TopTableSamplePlugin>(plugin =>
            //{
            //    var col = 0;
            //    //plugin.Table.Lines.Sort((a, b) =>
            //    //{
            //    //    var t = -a.Cells[col].TextFunc(a.Position, col, 0, 0).CompareTo(b.Cells[col].TextFunc(b.Position, col, 0, 0));
            //    //    Says.Debug(t);
            //    //    return t;
            //    //});
            //    //plugin.Table.Lines.Reverse();
            //    plugin.Table.Sort(2, false);
            //});

            //Hud.RunOnPlugin<StandardMonsterPlugin>(plugin =>
            //{
            //    plugin.EliteChampionDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.Radius = 8f);
            //});

            Enabled = false;
        }
    }
}