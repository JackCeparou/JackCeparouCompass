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

            Hud.RunOnPlugin<Jack.Items.ItemDropSoundAlertPlugin>(plugin =>
            {
                // legendaries
                plugin.Legendary = true;
                plugin.AncientLegendary = true;
                plugin.PrimalAncientLegendary = true;
                // sets
                plugin.Set = true;
                plugin.AncientSet = true;
                plugin.PrimalAncientSet = true;

                // alerts when gambling ?
                plugin.Gambled = true;

                // ancient & primals prefixes
                plugin.AncientLegendaryNamePrefix = "Ancient";
                plugin.PrimalAncientLegendaryNamePrefix = "Primal";
                plugin.AncientSetNamePrefix = "Ancient";
                plugin.PrimalAncientSetNamePrefix = "Primal";
                
                // naming function
                // can be overriden with an anonymous function (item) => { return "string"; }
                //plugin.NameFunc = GetItemName;

                // Exceptions on above rules :
                // ---------------------------
                
                // add any item 
                plugin.ItemSnos.Add(1844495708); // 1844495708 - Ramaladni's Gift
                //plugin.ItemSnos.Add(2332226049); // health globe

                // ancients items if ancient rank == 1 is not activated
                // example for // 916911834 - Sacred Harvester
                //plugin.AncientItemSnos.Add(916911834);

                // primals items if ancient rank == 2 is not activated
                //plugin.PrimalAncientItemSnos.Add(12354689);

                // custom items names (if the item is not in one of the other list, this will do nothing)
                // example for // 1844495708 - Ramaladni's Gift
                plugin.ItemCustomNames.Add(1844495708, "OMAGAD a gift!"); // 1844495708 - Ramaladni's Gift
                //plugin.ItemCustomNames.Add(2332226049, "health"); // health globe
            });

            Enabled = false;
        }
    }
}