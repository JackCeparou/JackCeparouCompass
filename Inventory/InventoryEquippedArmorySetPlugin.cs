namespace Turbo.Plugins.Jack.Inventory
{
    using Plugins;
    using Plugins.Default;
    using System.Linq;

    public class InventoryEquippedArmorySetPlugin : BasePlugin, IInGameTopPainter
    {
        public IFont ArmorySetFont { get; set; }
        public bool FirstSetOnly { get; set; }

        public InventoryEquippedArmorySetPlugin()
        {
            Enabled = true;
            FirstSetOnly = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ArmorySetFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 163, 0, false, false, false);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.Inventory) return;

            var uiInv = Hud.Inventory.InventoryMainUiElement;
            if (!uiInv.Visible) return;

            var annIds = Hud.Game.Items.Where(i => i.Location >= ItemLocation.Head && i.Location <= ItemLocation.Neck).Select(i => i.AnnId).ToList();
            var setNames = Hud.Game.Me.ArmorySets.Where(set => set.ItemAnnIds.Any() && set.ItemAnnIds.All(id => annIds.Contains(id))).Select(set => set.Name).ToList();

            if (setNames.Count == 0) return;

            var text = FirstSetOnly ? setNames.First() : string.Join("\n", setNames);

            var layout = ArmorySetFont.GetTextLayout(text);
            var x = uiInv.Rectangle.Left + (uiInv.Rectangle.Width * 0.75f) - (layout.Metrics.Width / 2);
            var y = uiInv.Rectangle.Top + (uiInv.Rectangle.Width * 0.21f) - layout.Metrics.Height;

            ArmorySetFont.DrawText(layout, x, y);
        }
    }
}