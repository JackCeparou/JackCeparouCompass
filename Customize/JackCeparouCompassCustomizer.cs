namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.JackCeparouCompass;

    public class JackCeparouCompassCustomizer : BasePlugin, ICustomizer
    {
        public JackCeparouCompassCustomizer()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<Jack.Actors.DoorsPlugin>(plugin => plugin.ShowInTown = true);

            using (var alertListsConfigurator = new AlertListsConfigurator(Hud))
            {
                alertListsConfigurator.Configure();
            }

            Enabled = false;
        }
    }
}