using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public class InspectorGadgetPlugin : BasePlugin, IInGameTopPainter, ICustomizer, IAfterCollectHandler, IInGameWorldPainter, IKeyEventHandler, INewAreaHandler
    {
        public IFont UsageLowFont { get; set; }
        public IFont UsageHighFont { get; set; }
        public IBrush BackgroundBrush { get; set; }

        public float MinUsageThreshold { get; set; }
        public float HighUsageThreshold { get; set; }
        public bool ForceDisplay { get; set; }
        public string[] Columns { get; set; }

        public List<IPlugin> PluginsAlwaysDisplayed { get; set; }
        public List<IPlugin> PluginsNeverDisplayed { get; set; }

        public Func<IPlugin, bool> PluginDisplayedPredicate { get; set; }
        public Func<IPlugin, double> OrderByPredicate { get; set; }

        private IOrderedEnumerable<IPlugin> plugins;
        private float rowHeaderSpacer = 10;
        private float columnWidth = 50;

        public InspectorGadgetPlugin()
        {
            Enabled = true;
            Order = int.MaxValue;
            // note : maybe event missing ?? (item identified, item keep decision, item location changed, item picked, loot generated, monster killed, portal found, skill cooldown) ???
            Columns = new string[] { /*"Load", "Customize",*/ "AfterCollect", "PaintWorld", "PaintTopInGame", /*"OnNewArea", "OnKeyEvent"*/ }.Reverse().ToArray();
            PluginsAlwaysDisplayed = new List<IPlugin>();
            PluginsNeverDisplayed = new List<IPlugin>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            //ForceDisplay = true;
            //PluginsAlwaysDisplayed.Add(this);

            MinUsageThreshold = 3f;
            HighUsageThreshold = 1.5f;

            PluginDisplayedPredicate = p => !PluginsAlwaysDisplayed.Contains(p) && !PluginsNeverDisplayed.Contains(p) && p.PerformanceCounters.Sum(c => c.Value.LastValue) > MinUsageThreshold;
            OrderByPredicate = p => p.PerformanceCounters.Sum(c => c.Value.LastValue);

            UsageLowFont = Hud.Render.CreateFont("courier new", 6, 255, 0, 255, 0, true, false, false);
            UsageHighFont = Hud.Render.CreateFont("courier new", 6, 255, 255, 50, 50, true, false, false);
            BackgroundBrush = Hud.Render.CreateBrush(128, 0, 0, 0, 0);
        }

        public void Customize()
        {
            Hud.TogglePlugin<Default.DebugPlugin>(true);
        }

        public void AfterCollect()
        {
            if (!ForceDisplay && !Hud.Window.CursorInsideRect(Hud.Window.Size.Width * 0.92f, 0f, Hud.Window.Size.Width * 0.08f, Hud.Window.Size.Height * 0.01f))
            {
                plugins = null;
                return;
            }

            plugins = Hud.AllPlugins
                .Where(PluginDisplayedPredicate)
                .OrderByDescending(OrderByPredicate);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (plugins == null) return;

            var layout = UsageLowFont.GetTextLayout("000.00__");
            columnWidth = layout.Metrics.Width;

            //var x = Hud.Window.Size.Width - Hud.Window.Size.Height * 0.31f - columnWidth;
            var x = Hud.Render.MinimapUiElement.Rectangle.Left - columnWidth;
            var currentY = 0f;
            var rowHeaderX = x - columnWidth * (Columns.Count() - 1);
            var columnsTotalWidth = columnWidth * Columns.Count();

            layout = UsageLowFont.GetTextLayout(string.Format("Plugins : {0}/{1}  ", plugins.Count(), Hud.AllPlugins.Count()));
            UsageLowFont.DrawText(layout, rowHeaderX - layout.Metrics.Width - rowHeaderSpacer, currentY);

            var _x = x;
            var odd = false;
            foreach (var counterKey in Columns)
            {
                UsageLowFont.DrawText(counterKey, _x, currentY + (odd ? 0 : layout.Metrics.Height));
                _x -= columnWidth;
                odd = !odd;
            }

            currentY += layout.Metrics.Height * 2;

            currentY = DrawPluginsBlock(PluginsAlwaysDisplayed, rowHeaderX, x, currentY, columnsTotalWidth, layout.Metrics.Height);
            currentY = DrawPluginsBlock(plugins, rowHeaderX, x, currentY, columnsTotalWidth, layout.Metrics.Height);

            //currentY = DrawPluginsBlock(plugins.Where(p => !p.ToString().StartsWith("Turbo.Plugins.Default.")), rowHeaderX, x, currentY, columnsTotalWidth, layout.Metrics.Height);
            //currentY = DrawPluginsBlock(plugins.Where(p => p.ToString().StartsWith("Turbo.Plugins.Default.")), rowHeaderX, x, currentY, columnsTotalWidth, layout.Metrics.Height, "{0} :");
        }

        private float DrawPluginsBlock(IEnumerable<IPlugin> plugins, float rowHeaderX, float x, float _y, float _w, float h, string format = "{0} ({1}):")
        {
            BackgroundBrush.DrawRectangle(rowHeaderX - rowHeaderSpacer, _y, rowHeaderSpacer + _w, h * plugins.Count());

            foreach (var plugin in plugins)
            {
                var layout = UsageLowFont.GetTextLayout(string.Format(format, plugin.GetType().Name.Replace("Plugin", ""), plugin.ToString().Split('.')[2]));
                //layout = UsageLowFont.GetTextLayout(string.Format("{0} :", plugin.ToString()));
                BackgroundBrush.DrawRectangle(rowHeaderX - rowHeaderSpacer - layout.Metrics.Width, _y, layout.Metrics.Width, layout.Metrics.Height);
                UsageLowFont.DrawText(layout, rowHeaderX - layout.Metrics.Width - rowHeaderSpacer, _y);

                var _x = x;
                foreach (var counter in Columns.Select(counterKey => plugin.PerformanceCounters.Where(c => c.Key == counterKey).Select(c => c.Value).FirstOrDefault()))
                {
                    if (counter != null && counter.LastValue > 0)
                    {
                        //var text = string.Format(CultureInfo.InvariantCulture, "{0:0.##}/{1:0.##}", counter.LastValue, counter.LastCount);
                        var text = counter.LastValue.ToString("0.##", CultureInfo.InvariantCulture);
                        (counter.LastValue <= HighUsageThreshold ? UsageLowFont : UsageHighFont).DrawText(text, _x, _y);
                    }

                    _x -= columnWidth;
                }

                _y += layout.Metrics.Height;
            }

            if (plugins.Any())
                _y += h / 2;

            return _y;
        }

        private float DrawPluginsBlock2(IEnumerable<IPlugin> plugins, float rowHeaderX, float x, float _y, float _w, float h, string format = "{0} ({1}):")
        {
            BackgroundBrush.DrawRectangle(rowHeaderX - rowHeaderSpacer, _y, rowHeaderSpacer + _w, h * plugins.Count());

            foreach (var plugin in plugins)
            {
                var layout = UsageLowFont.GetTextLayout(string.Format(format, plugin.GetType().Name.Replace("Plugin", ""), plugin.ToString().Split('.')[2]));
                //layout = UsageLowFont.GetTextLayout(string.Format("{0} :", plugin.ToString()));
                BackgroundBrush.DrawRectangle(rowHeaderX - rowHeaderSpacer - layout.Metrics.Width, _y, layout.Metrics.Width, layout.Metrics.Height);
                UsageLowFont.DrawText(layout, rowHeaderX - layout.Metrics.Width - rowHeaderSpacer, _y);

                var _x = x;
                foreach (var counter in Columns.Select(counterKey => plugin.PerformanceCounters.Where(c => c.Key == counterKey).Select(c => c.Value).FirstOrDefault()))
                {
                    if (counter != null && counter.LastValue > 0)
                    {
                        //var text = string.Format(CultureInfo.InvariantCulture, "{0:0.##}/{1:0.##}", counter.LastValue, counter.LastCount);
                        var text = counter.LastValue.ToString("0.##", CultureInfo.InvariantCulture);
                        (counter.LastValue <= HighUsageThreshold ? UsageLowFont : UsageHighFont).DrawText(text, _x, _y);
                    }

                    _x -= columnWidth;
                }

                _y += layout.Metrics.Height;
            }

            if (plugins.Any())
                _y += h / 2;

            return _y;
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            //noop
        }

        public void OnKeyEvent(IKeyEvent keyEvent)
        {
            //noop
        }

        public void PaintWorld(WorldLayer layer)
        {
            //noop
        }
    }
}