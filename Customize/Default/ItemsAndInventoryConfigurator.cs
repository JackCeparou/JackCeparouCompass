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
            Hud.RunOnPlugin<ItemsPlugin>(plugin =>
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
            Hud.RunOnPlugin<HoveredItemInfoPlugin>(plugin =>
            {
                StringGeneratorFunc func = () => string.Format("{0}{1}", Hud.Inventory.HoveredItem.AncientRank > 0 ? "\uD83E\uDC1D " : string.Empty, Hud.Inventory.HoveredItem.SnoItem.NameLocalized);
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
                //inventoryAndStashPlugin.SellEnabled = true;

                // shh, go away blinking cube!
                plugin.CanCubedEnabled = false;

                // ancient rank font
                plugin.AncientRankFont = Hud.Render.CreateFont("arial", 8, 224, 255, 64, 64, true, false, false);
                plugin.AncientRankFont.SetShadowBrush(224, 0, 0, 0, true);

                plugin.SocketedLegendaryGemRankFont = Hud.Render.CreateFont("arial", 7, 255, 240, 240, 64, true, false, false);
                plugin.SocketedLegendaryGemRankFont.SetShadowBrush(128, 0, 0, 0, true);

                // change darken brush to a lighter one
                ////inventoryAndStashPlugin.DarkenBrush = Hud.Render.CreateBrush(120, 38, 38, 38, 0);

                plugin.NotGoodDisplayEnabled = true;
                plugin.DefinitelyBadDisplayEnabled = true;
                //plugin.LooksGoodDisplayEnabled = true;
            });
        }
    }
}