using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins.Jack.Labs.Powers
{
    public class PowerPainter
    {
        public IController Hud { get; set; }

        public IFont TextFont { get; set; }

        public IBrush BackgroundBrush { get; set; }
        public IBrush LegendaryBackgroundBrush { get; set; }
        public IBrush SetBackgroundBrush { get; set; }

        public float StandardIconSize
        {
            get
            {
                return 55f / 1200.0f * Hud.Window.Size.Height * SizeMultiplier;
            }
        }

        public float StandardIconSpacing
        {
            get
            {
                return 3.0f / 1200.0f * Hud.Window.Size.Height * SizeMultiplier;
            }
        }

        public float SizeMultiplier { get; set; }
        public float ColumnWidthRatio { get; set; }

        public PowerPainter(IController hud)
        {
            Hud = hud;

            TextFont = Hud.Render.CreateFont("consolas", 6, 242, 255, 255, 255, false, false, false);

            BackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
            LegendaryBackgroundBrush = Hud.Render.CreateBrush(160, 255, 140, 0, 0);
            SetBackgroundBrush = Hud.Render.CreateBrush(160, 50, 220, 50, 0);

            SizeMultiplier = 0.30f;
            ColumnWidthRatio = 0.20f;
        }

        public void Paint(IEnumerable<ISnoPower> powers, float x, float y, int textLenght = 25)
        {
            BackgroundBrush.DrawRectangle(0, 0, Hud.Window.Size.Width, Hud.Window.Size.Height);

            foreach (var power in powers)
            {
                Paint(power, x, y, textLenght);

                y += StandardIconSize + StandardIconSpacing;

                if (!(y > Hud.Window.Size.Height*0.98f)) continue;

                y = 0;
                x += Hud.Window.Size.Width * ColumnWidthRatio;
            }
        }

        public void Paint(ISnoPower power, float x, float y, int textLenght = 25)
        {
            var name = string.Empty;
            var items = power.GetItemSnos();
            if (items.Any(xx => xx != 0) && string.IsNullOrWhiteSpace(power.NameEnglish))
            {
                name = Hud.Inventory.GetSnoItem(items.First()).NameEnglish;
            }
            else
            {
                name = string.IsNullOrWhiteSpace(power.NameEnglish) ? power.Sno.ToString() : power.NameEnglish;
            }

            if (name.Length > textLenght)
            {
                name = name.Substring(0, textLenght);
            }

            var layout = TextFont.GetTextLayout(string.Format("{0,25} Icons: ", name));
            var layoutSpacer = TextFont.GetTextLayout(":");
            TextFont.DrawText(layout, x, y);

            if (Hud.Window.CursorInsideRect(x, y, layout.Metrics.Width, layout.Metrics.Height))
            {
                Hud.Render.SetHint(power.Sno + " : " + power.Code + " : " + power.DescriptionEnglish);
            }

            x += layout.Metrics.Width + layoutSpacer.Metrics.Width * 2;

            if (power.NormalIconTextureId != 0)
            {
                var texture = Hud.Texture.GetTexture(power.NormalIconTextureId);

                if (texture != null)
                    texture.Draw(x, y, StandardIconSize, StandardIconSize);
                else
                    BackgroundBrush.DrawRectangle(x, y, StandardIconSize, StandardIconSize);

                if (Hud.Window.CursorInsideRect(x, y, StandardIconSize, StandardIconSize))
                {
                    Hud.Render.SetHint("TextureId : " + power.NormalIconTextureId);
                }
                x += StandardIconSize + StandardIconSpacing;
            }

            foreach (var icon in power.Icons.Where(xxx => xxx.Exists && xxx.TextureId != 0 && xxx.TextureId != power.NormalIconTextureId).Select(xxx => xxx.TextureId).Distinct())
            {
                var texture = Hud.Texture.GetTexture(icon);

                if (texture != null)
                    texture.Draw(x, y, StandardIconSize, StandardIconSize);
                else
                    BackgroundBrush.DrawRectangle(x, y, StandardIconSize, StandardIconSize);

                if (Hud.Window.CursorInsideRect(x, y, StandardIconSize, StandardIconSize))
                {
                    Hud.Render.SetHint("TextureId : " + icon);
                }

                x += StandardIconSize + StandardIconSpacing;
            }

            layout = TextFont.GetTextLayout(" Items: ");
            TextFont.DrawText(layout, x, y);
            x += layout.Metrics.Width + layoutSpacer.Metrics.Width;

            foreach (var sno in items)
            {
                if (sno == 0) continue;

                var item = Hud.Inventory.GetSnoItem(sno);
                if (item == null) continue;

                var brush = item.SetItemBonusesSno == uint.MaxValue
                    ? LegendaryBackgroundBrush
                    : SetBackgroundBrush;

                brush.DrawRectangle(x, y, StandardIconSize, StandardIconSize);

                var texture = Hud.Texture.GetItemTexture(item);

                if (texture != null)
                    texture.Draw(x, y, StandardIconSize, StandardIconSize);
                else
                    BackgroundBrush.DrawRectangle(x, y, StandardIconSize, StandardIconSize);

                if (Hud.Window.CursorInsideRect(x, y, StandardIconSize, StandardIconSize))
                {
                    Hud.Render.SetHint(item.NameEnglish + " : " + item.Sno + " : i" + item.Level + " : " + item.SetItemBonusesSno);
                }

                x += StandardIconSize + StandardIconSpacing;
            }
        }
    }
}