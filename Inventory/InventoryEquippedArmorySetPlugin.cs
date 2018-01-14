namespace Turbo.Plugins.Jack.Inventory
{
    using Plugins;
    using Plugins.Default;
    using SharpDX.Direct2D1;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class InventoryEquippedArmorySetPlugin : BasePlugin, IInGameTopPainter, IItemLocationChangedHandler, INewAreaHandler
    {
        public bool FirstSetOnly { get; set; }
        public IFont ArmorySetFont { get; set; }
        public IBrush ArmorySetBrush { get; set; }
        public Action<IController, IItem, System.Drawing.RectangleF> DrawArmorySet { get; set; }

        private HashSet<uint> equippedItemsAnnIdsHash;

        public InventoryEquippedArmorySetPlugin()
        {
            Enabled = true;
            FirstSetOnly = true;
            DrawArmorySet = DrawArmorySetInternal;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            ArmorySetFont = Hud.Render.CreateFont("tahoma", 10, 255, 255, 163, 0, false, false, false);
            ArmorySetBrush = Hud.Render.CreateBrush(255, 119, 171, 255, 1, DashStyle.Dash);
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (!newGame) return;

            StateGuard(true);
        }

        public void OnItemLocationChanged(IItem item, ItemLocation @from, ItemLocation @to)
        {
            // if moved item is equipped/removed
            if ((@from >= ItemLocation.Head && @from <= ItemLocation.Neck) || (@to >= ItemLocation.Head && @to <= ItemLocation.Neck))
            {
                StateGuard(true);
            }
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.Inventory) return;

            var uiInv = Hud.Inventory.InventoryMainUiElement;
            if (!uiInv.Visible) return;

            StateGuard();
            DrawEquippedSetName(uiInv, equippedItemsAnnIdsHash);

            var stashTabAbs = Hud.Inventory.SelectedStashTabIndex + Hud.Inventory.SelectedStashPageIndex * Hud.Inventory.MaxStashTabCountPerPage;
            var inventoryAndStashItems = Hud.Game.Items
                .Where(item => item.Location == ItemLocation.Inventory || item.Location == ItemLocation.Stash)
                .Where(item => item.Location != ItemLocation.Stash || (item.InventoryY / 10) == stashTabAbs)
                .Where(item => item.InventoryX >= 0 && item.InventoryY >= 0)
                ;
            var visibleSetItems = inventoryAndStashItems
                .Where(item => Hud.Game.Me.ArmorySets.Any(armorySet => armorySet.ContainsItem(item)));
            foreach (var item in visibleSetItems)
            {
                DrawItem(item);
            }
        }

        private void DrawItem(IItem item)
        {
            var rect = Hud.Inventory.GetItemRect(item);
            if (rect == System.Drawing.RectangleF.Empty) return;

            DrawArmorySet(Hud, item, rect);
        }

        private void StateGuard(bool resetState = false)
        {
            if (resetState)
            {
                equippedItemsAnnIdsHash = null;
                return;
            }

            if (equippedItemsAnnIdsHash != null) return;

            var equippedItemsAnnIds = Hud.Game.Items
                    .Where(i => i.Location >= ItemLocation.Head && i.Location <= ItemLocation.Neck)
                    .Select(i => i.AnnId)
                    .ToList();
            equippedItemsAnnIdsHash = new HashSet<uint>(equippedItemsAnnIds);
        }

        private void DrawEquippedSetName(IUiElement uiInv, HashSet<uint> annIdsHash)
        {
            var setNames =
                Hud.Game.Me.ArmorySets.Where(set => set.ItemAnnIds.Any() && set.ItemAnnIds.All(id => annIdsHash.Contains(id)))
                    .Select(set => set.Name)
                    .ToList();

            if (setNames.Count == 0) return;

            var text = FirstSetOnly ? setNames.First() : string.Join("\n", setNames);

            var layout = ArmorySetFont.GetTextLayout(text);
            var x = uiInv.Rectangle.Left + (uiInv.Rectangle.Width * 0.75f) - (layout.Metrics.Width / 2);
            var y = uiInv.Rectangle.Top + (uiInv.Rectangle.Width * 0.21f) - layout.Metrics.Height;

            ArmorySetFont.DrawText(layout, x, y);
        }

        private void DrawArmorySetInternal(IController hud, IItem item, System.Drawing.RectangleF rect)
        {
            ArmorySetBrush.DrawRectangle(rect);
        }
    }
}