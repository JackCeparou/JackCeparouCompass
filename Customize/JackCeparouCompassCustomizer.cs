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

            Hud.RunOnPlugin<DoorsPlugin>(plugin => plugin.ShowInTown = true);
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

            Enabled = false;
        }
    }
}