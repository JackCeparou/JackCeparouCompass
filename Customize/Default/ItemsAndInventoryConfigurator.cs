namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;

    public class ItemsAndInventoryConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            ///////////
            // ITEMS //
            ///////////
            Hud.RunOnPlugin<HoveredItemInfoPlugin>(plugin =>
            {
                StringGeneratorFunc func = () => string.Format("{0}{1}{2}", 
                    Hud.Inventory.HoveredItem.AncientRank > 0 ? "\uD83E\uDC1D " : string.Empty, 
                    Hud.Inventory.HoveredItem.AncientRank > 1 ? "\uD83E\uDC1D " : string.Empty, 
                    Hud.Inventory.HoveredItem.SnoItem.NameLocalized);
                plugin.LegendaryNameDecorator.TextFunc = func;
                plugin.SetNameDecorator.TextFunc = func;
            });

            ///////////////////
            // PICKUP RADIUS //
            ///////////////////
            Hud.RunOnPlugin<PickupRangePlugin>(plugin =>
            {
                plugin.FillBrush = Hud.Render.CreateBrush(12, 255, 255, 255, 0);
                plugin.OutlineBrush = Hud.Render.CreateBrush(30, 0, 0, 0, 3);
            });

            ///////////////////////
            // STASH & INVENTORY //
            ///////////////////////
            Hud.RunOnPlugin<InventoryAndStashPlugin>(plugin =>
            {
                // enable sell darkening
                plugin.NotGoodDisplayEnabled = false;
                plugin.DefinitelyBadDisplayEnabled = false;

                // shh, go away blinking cube!
                //plugin.CanCubedEnabled = false;

                // ancient rank font
                plugin.AncientRankFont = Hud.Render.CreateFont("arial", 7, 255, 227, 153, 25, true, false, 220, 0, 0, 0, true);
                plugin.PrimalRankFont = Hud.Render.CreateFont("arial", 7, 255, 255, 64, 64, true, false, 180, 0, 0, 0, true);

                plugin.SocketedLegendaryGemRankFont = Hud.Render.CreateFont("arial", 7, 255, 240, 240, 64, true, false, 128, 0, 0, 0, true);

                // change darken brush to a lighter one
                ////inventoryAndStashPlugin.DarkenBrush = Hud.Render.CreateBrush(120, 38, 38, 38, 0);

                //plugin.NotGoodDisplayEnabled = true;
                plugin.DefinitelyBadDisplayEnabled = true;
                //plugin.LooksGoodDisplayEnabled = true;
            });
        }
    }
}