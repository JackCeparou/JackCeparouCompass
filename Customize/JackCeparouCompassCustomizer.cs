namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Actors;
    using Turbo.Plugins.Jack.Customize.JackCeparouCompass;
    using Turbo.Plugins.Jack.Monsters;

    public class JackCeparouCompassCustomizer : BasePlugin, ICustomizer
    {
        public JackCeparouCompassCustomizer()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<DoorsPlugin>(plugin => plugin.ShowInTown = true);

            Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin => { plugin.Affixes.Clear(); });

            using (var alertListsConfigurator = new AlertListsConfigurator())
            {
                alertListsConfigurator.Configure(Hud);
            }

            Enabled = false;
        }
    }
}