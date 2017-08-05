using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using Turbo.Plugins.Default;
using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins.Jack.Labs
{
    public class ItemStatBreakdownPlugin : BasePlugin, IInGameTopPainter, IItemLocationChangedHandler
    {
        public IFont TextFont { get; set; }
        public IBrush GreyBrush { get; set; }
        public IBrush BackgroundBrush { get; set; }
        public IItemRenderer ItemRenderer { get; set; }

        public ItemLocation[] ItemLocations = new ItemLocation[]
        {
            ItemLocation.LeftHand,
            ItemLocation.RightHand,
            ItemLocation.Head,
            ItemLocation.Torso,
            ItemLocation.Hands,
            ItemLocation.Feet,
            ItemLocation.Shoulders,
            ItemLocation.Legs,
            ItemLocation.Bracers,
            ItemLocation.Waist,
            ItemLocation.Neck,
            ItemLocation.LeftRing,
            ItemLocation.RightRing,
        };

        private Func<float> rowHeaderWidth = () => 260;
        private Func<float> columnHeaderWidth = () => 50;

        private IEnumerable<IItem> items;

        private List<IBrush> gradientBrushes = new List<IBrush>();

        public ItemStatBreakdownPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            TextFont = Hud.Render.CreateFont("tahoma", 7, 255, 255, 255, 255, false, false, false);
            TextFont.SetShadowBrush(255, 0, 0, 0, true);
            GreyBrush = Hud.Render.CreateBrush(242, 128, 128, 128, 0);
            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);

            ItemLocations = ItemLocations.Reverse().ToArray();

            ItemRenderer = new StandardItemRenderer(Hud);
            AncientRankFont = Hud.Render.CreateFont("arial", 7, 255, 0, 0, 0, true, false, 220, 227, 153, 25, true);
            PrimalRankFont = Hud.Render.CreateFont("arial", 7, 255, 0, 0, 0, true, false, 180, 255, 64, 64, true);

            var a = 255;
            var step = 51; //17;
            for (int g = 0; g <= 255; g += step)
            {
                gradientBrushes.Add(Hud.Render.CreateBrush(a, 255, g, 0, 0));
            }
            for (int r = 255; r >= 0; r -= step)
            {
                gradientBrushes.Add(Hud.Render.CreateBrush(a, r, 255, 0, 0));
            }
        }

        /*var primaryAffixLabels = {
		    'dmg'  : '+X-Y Damage',
		    'ldmg' : '+X-Y [Elemental] Damage',
		    'pdmg' : '% Damage',
		    'ele'  : '[Element] Skills deal % more damage',
		    'pri'  : 'Primary Attribute (Str, Dex, or Int)',
		    'vit'  : 'Vitality',
		    'as'   : 'Attack Speed Increased by %',
		    'ar'   : 'X All Resistances',
		    'life' : 'Life %',
		    'arm'  : 'Armor',
		    'chd'  : 'Critical Hit Damage Increased by %',
		    'lps'  : 'Regenerates X Life per Second',
		    'chc'  : 'Critical Hit Chance Increased by %',
		    'aoe'  : 'Chance to Deal % area damage on Hit',
		    'loh'  : 'Life per Hit',
		    'cdr'  : 'Reduces Cooldown of all Skills by %',
		    'rcr'  : 'Reduces all Resource Costs by %',
		    'move' : '% Movement Speed',
		    'gen'  : 'Increases [signature skill] damage by %',
		    'spend': 'Increases [spender] damage by %',
		    'sock' : 'Sockets',
		    'edmg' : 'Increases Damage Against Elites by %',
		    'erud' : 'Reduced damage from Elites',
		    'apoc' : 'Critical Hits grant X Arcane Power',
		    'block': '% Chance to Block',
		    'bleed': '% Chance to Inflict Bleed for X Weapon Damage over Y Seconds',
		    'hgen' : 'Increases Hatred Regeneration by X per second',
		    'mgen' : 'Increases Mana Regeneration by X per second',
		    'sgen' : 'Increases Spirit Regeneration by X per second',
		    //'wgen' : 'Increases Wrath Regeneration by X per second',
		    //'fgen' : 'Increases Fury Generation by X per second',
		    'lpfs' : 'Life per Fury Spent',
		    'lpss' : 'Life per Spirit Spent',
	    };/**/
        /* MISSING */
        /*var primaryAffixLabels = {
		    'ele'  : '[Element] Skills deal % more damage',
		    'arm'  : 'Armor',
		    'chd'  : 'Critical Hit Damage Increased by %',
		    'lps'  : 'Regenerates X Life per Second',
		    'chc'  : 'Critical Hit Chance Increased by %',
		    'aoe'  : 'Chance to Deal % area damage on Hit',
		    'loh'  : 'Life per Hit',
		    'cdr'  : 'Reduces Cooldown of all Skills by %',
		    'rcr'  : 'Reduces all Resource Costs by %',
		    'move' : '% Movement Speed',
		    'gen'  : 'Increases [signature skill] damage by %',
		    'spend': 'Increases [spender] damage by %',
		    'sock' : 'Sockets',
		    'edmg' : 'Increases Damage Against Elites by %',
		    'erud' : 'Reduced damage from Elites',
		    'apoc' : 'Critical Hits grant X Arcane Power',
		    'block': '% Chance to Block',
		    'bleed': '% Chance to Inflict Bleed for X Weapon Damage over Y Seconds',
		    'hgen' : 'Increases Hatred Regeneration by X per second',
		    'mgen' : 'Increases Mana Regeneration by X per second',
		    'sgen' : 'Increases Spirit Regeneration by X per second',
		    //'wgen' : 'Increases Wrath Regeneration by X per second',
		    //'fgen' : 'Increases Fury Generation by X per second',
		    'lpfs' : 'Life per Fury Spent',
		    'lpss' : 'Life per Spirit Spent',
	    };/**/

        private string[] primaryDamageAttributes = new string[] {
            "Intelligence_Item",
            "Dexterity_Item",
            "Strength_Item",
            "Attacks_Per_Second_Item_Percent",
            "Attacks_Per_Second_Percent",
            "Crit_Percent_Bonus_Capped",
            "Crit_Damage_Percent",
            "Splash_Damage_Effect_Percent",
            //"Intelligence_Item",
            //"---------",
            "Damage_Weapon_Percent_All",
            "Damage_Weapon_Min",
            "Damage_Weapon_Delta",
            "Damage_Min",
            "Damage_Delta",
            //"---------",
            "Sockets",
            //"---------",
        };

        private string[] ehpAttributes = new string[] {
            "Vitality_Item",
            "Hitpoints_Max_Percent_Bonus_Item",
            "Hitpoints_Regen_Per_Second",
            "Armor_Bonus_Item",
            "Resistance_All",
            "Resistance",
        };

        /*var secondaryAffixLabels = {
            'res'   : 'X [Type] Resistance',
            'rrdmg' : 'Reduces damage from ranged attacks by %',
            'rmdmg' : 'Reduces damage from melee attacks by %',
            'lpk'   : 'Life per Kill',
            'gold'  : '% Extra Gold from Monsters',
            'maxap' : 'Maximum Arcane Power',
            'maxd'  : 'Maximum Discipline',
            'maxm'  : 'Maximum Mana',
            'maxf'  : 'Maximum Fury',
            'maxs'  : 'Maximum Spirit',
            'thorn' : 'Ranged and melee attackers take X damage per hit',
            'xp'    : 'Monster kills grant +X experience',
            'pick'  : 'Increases Gold and Health Pickup by X yards',
            'rdcie' : 'Reduced duration of control impairing effects',
            'blind' : '% Chance to Blind on hit',
            'chill' : '% Chance to Chill on hit',
            'freez' : '% Chance to Freeze on hit',
            'slow' 	: '% Chance to Slow on hit',
            'stun' 	: '% Chance to Stun on hit',
            'fear' 	: '% Chance to Fear on hit',
            'knock' : '% Chance to Knockback on hit',
            'immo'  : '% Chance to Immobilize on hit',
            'dura'  : 'Ignores Durability Loss',
            'glob'  : 'Health globes and potions grant +X life',
            'lvlr'  : 'Level Requirement Reduced by X',
        };/**/
        /* MISSING */
        /*var secondaryAffixLabels = {
            'rrdmg' : 'Reduces damage from ranged attacks by %',
            'rmdmg' : 'Reduces damage from melee attacks by %',
            'maxap' : 'Maximum Arcane Power',
            'maxd'  : 'Maximum Discipline',
            'maxm'  : 'Maximum Mana',
            'maxf'  : 'Maximum Fury',
            'maxs'  : 'Maximum Spirit',
            'thorn' : 'Ranged and melee attackers take X damage per hit',
            'rdcie' : 'Reduced duration of control impairing effects',
        };/**/

        private string[] secondaryAttributes = new string[] {
            "Health_Globe_Bonus_Health",
            "Thorns_Fixed",
            "Hitpoints_On_Hit",
            "Hitpoints_On_Kill",
            "---------",
            "Weapon_On_Hit_Blind_Proc_Chance",
            "Weapon_On_Hit_Chill_Proc_Chance",
            "Weapon_On_Hit_Freeze_Proc_Chance",
            "Weapon_On_Hit_Slow_Proc_Chance",
            "Weapon_On_Hit_Stun_Proc_Chance",
            "Weapon_On_Hit_Fear_Proc_Chance",
            "Weapon_On_Hit_Knockback_Proc_Chance",
            "Weapon_On_Hit_Immobilize_Proc_Chance",
            "---------",
            "On_Hit_Blind_Proc_Chance",
            "On_Hit_Chill_Proc_Chance",
            "On_Hit_Freeze_Proc_Chance",
            "On_Hit_Slow_Proc_Chance",
            "On_Hit_Stun_Proc_Chance",
            "On_Hit_Fear_Proc_Chance",
            "On_Hit_Knockback_Proc_Chance",
            "On_Hit_Immobilize_Proc_Chance",
            "---------",
            "Movement_Scalar",
            "Experience_Bonus",
            "Gold_Find",
            "Gold_PickUp_Radius",
            "Item_Indestructible",
            "Item_Level_Requirement_Reduction",
        };

        private string[] powersAttributes = new string[] {
            "Power_Cooldown_Reduction_Percent_All",
            "Item_Power_Passive",
            "Power_Damage_Percent_Bonus",
            "Damage_Dealt_Percent_Bonus",
        };

        private string[] wtfAttributes = new string[] {
            "Quiver",
        };

        private IEnumerable<string> attributes;

        private IUiElement uiInventory
        {
            get { return Hud.Render.GetUiElement("Root.NormalLayer.inventory_side_pane_container"); }
        }

        public IFont AncientRankFont { get; private set; }
        public IFont PrimalRankFont { get; private set; }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (!uiInventory.Visible) return;

            //GreyBrush.DrawRectangle(0, 0, Hud.Window.Size.Width, Hud.Window.Size.Height);

            if (items == null)
                items = Hud.Game.Items.Where(i => i.Location >= ItemLocation.Head && i.Location <= ItemLocation.Neck);

            // TODO : there is probably a better way to cache this, but i'm not able to detect stats reroll with enchantress
            attributes = items.SelectMany(i => i.Perfections).Select(p => p.Attribute.Code).Distinct();

            var topOffset = 30f;
            var yOffset = 15f;
            var _columnHeaderWidth = columnHeaderWidth();
            var x = uiInventory.Rectangle.Left;
            var y = topOffset + _columnHeaderWidth * 2;

            DrawHeaderLine(x, topOffset, _columnHeaderWidth, items);

            y += DrawStatBlock(primaryDamageAttributes, y, x, _columnHeaderWidth);
            y += yOffset;
            y += DrawStatBlock(ehpAttributes, y, x, _columnHeaderWidth);
            y += yOffset;
            y += DrawStatBlock(secondaryAttributes, y, x, _columnHeaderWidth);
            y += yOffset;
            y += DrawStatBlock(powersAttributes, y, x, _columnHeaderWidth);
            y += yOffset;

            // TODO : remove this, only useful while debugging to find missing stats
            foreach (var attributeCode in attributes)
            {
                if (primaryDamageAttributes.Contains(attributeCode)) continue;
                if (ehpAttributes.Contains(attributeCode)) continue;
                if (secondaryAttributes.Contains(attributeCode)) continue;
                if (powersAttributes.Contains(attributeCode)) continue;

                y += DrawStatLine(attributeCode, x, y, _columnHeaderWidth);
            }
        }

        private float DrawStatBlock(IEnumerable<string> groupAttributes, float y, float x, float _columnHeaderWidth)
        {
            return groupAttributes
                .Where(attributeCode => attributes.Contains(attributeCode))
                .Aggregate(0f, (current, attributeCode) => current + DrawStatLine(attributeCode, x, y + current, _columnHeaderWidth));
        }

        private void DrawColumnHeaders(float x, float y, float columnHeaderWidth)//, List<IItem> items)
        {
            foreach (var location in ItemLocations)
            {
                //var item = items.FirstOrDefault(i => i.Location == location);
                var columnHeaderLayout = TextFont.GetTextLayout(location.ToString());
                TextFont.DrawText(columnHeaderLayout, x + (columnHeaderWidth / 2) - (columnHeaderLayout.Metrics.Width / 2), y - columnHeaderLayout.Metrics.Height);
                x += columnHeaderWidth;
            }
        }

        private void DrawHeaderLine(float x, float y, float columnHeaderWidth, IEnumerable<IItem> items)
        {
            var width = columnHeaderWidth;
            var rect = new RectangleF(x - width, y, width, width * 2);

            foreach (var location in ItemLocations)
            {
                var item = items.FirstOrDefault(i => i.Location == location);
                if (item != null)
                {
                    var bgTex = Hud.Texture.GetItemBackgroundTexture(item);

                    if (bgTex.Width == bgTex.Height)
                    {
                        rect.Y = y + width;
                        rect.Height = width;
                        BackgroundBrush.DrawRectangle(rect);
                    }
                    else
                    {
                        rect.Y = y;
                        rect.Height = width * 2;
                    }

                    ItemRenderer.RenderItem(item, rect);
                    var ancientRank = item.AncientRank;
                    if (ancientRank >= 1)
                    {
                        var ancientRankText = ancientRank == 1 ? "A" : "P";
                        var font = ancientRank == 1 ? AncientRankFont : PrimalRankFont;

                        var textRank = ancientRankText + (item.CaldesannRank > 0 ? ("+" + item.CaldesannRank.ToString("D", CultureInfo.InvariantCulture)) : "");
                        var textLayout = font.GetTextLayout(textRank);
                        font.DrawText(textLayout, rect.Right - textLayout.Metrics.Width - 4, rect.Bottom - textLayout.Metrics.Height - 2);
                    }

                    var text = string.Format("{0:0.#} %", item.Perfection);
                    var layout = TextFont.GetTextLayout(text);
                    var brushIndex = (int)Math.Round(item.Perfection / 100 * (float)(gradientBrushes.Count - 1));
                    if (brushIndex >= 0 && brushIndex < gradientBrushes.Count)
                    {
                        gradientBrushes[brushIndex].DrawRectangle(rect.X, rect.Y - layout.Metrics.Height, columnHeaderWidth, layout.Metrics.Height);
                    }

                    TextFont.DrawText(layout, rect.X + columnHeaderWidth / 2 - layout.Metrics.Width / 2, rect.Y - layout.Metrics.Height);
                }

                rect.X -= width + 1;
            }
        }

        private float DrawStatLine(string attributeCode, float x, float y, float _columnHeaderWidth)
        {
            var rowHeaderLayout = TextFont.GetTextLayout(attributeCode);
            var _x = x;

            foreach (var location in ItemLocations)
            {
                var item = items.FirstOrDefault(i => i.Location == location);
                var brush = BackgroundBrush;
                _x -= _columnHeaderWidth + 1;

                if (item == null) continue;
                var perfection = item.Perfections.FirstOrDefault(p => p.Attribute.Code == attributeCode);

                if (perfection != null)
                {
                    var stringFormat = perfection.Attribute.Code.Contains("Percent") ? "{0:0.#} %" : "{0:0.#}";
                    var text = string.Format(stringFormat, perfection.Cur >= 1 ? perfection.Cur : (perfection.Cur * 100), perfection.Min, perfection.Max, perfection.Percent());
                    var layout = TextFont.GetTextLayout(text);

                    var brushIndex = (int)Math.Round(perfection.Percent() * (float)(gradientBrushes.Count - 1));
                    if (brushIndex >= 0 && brushIndex < gradientBrushes.Count)
                    {
                        brush = gradientBrushes[brushIndex];
                        brush.DrawRectangle(_x, y, _columnHeaderWidth, rowHeaderLayout.Metrics.Height);
                    }

                    TextFont.DrawText(layout, _x + (_columnHeaderWidth / 2) - (layout.Metrics.Width / 2), y);
                }
                else
                {
                    brush.DrawRectangle(_x, y, _columnHeaderWidth, rowHeaderLayout.Metrics.Height);
                }
            }

            TextFont.DrawText(rowHeaderLayout, _x - rowHeaderLayout.Metrics.Width - 2, y);

            return rowHeaderLayout.Metrics.Height + 1;
        }

        public void OnItemLocationChanged(IItem item, ItemLocation from, ItemLocation to)
        {
            if ((from >= ItemLocation.Head && from <= ItemLocation.Neck) || (to >= ItemLocation.Head && to <= ItemLocation.Neck))
            {
                items = null;
            }
        }
    }
}