using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Plugins.Jack.Interfaces;
using Turbo.Plugins;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.EventManager
{
    public class ScreenResizeEventPlugin : BasePlugin, IInGameTopPainter, INewAreaHandler
    {
        private int screenHeight;
        private int screenWidth;

        private static readonly List<IScreenResizeHandler> registredPlugins = new List<IScreenResizeHandler>();
        public List<IScreenResizeHandler> RegistredPlugins
        {
            get { return registredPlugins; }
        }

        public ScreenResizeEventPlugin()
        {
            Enabled = true;
            Order = int.MinValue;
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (newGame)
                CheckSize();
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;

            CheckSize();
        }

        public static void Register(IScreenResizeHandler plugin)
        {
            registredPlugins.Add(plugin);
        }

        private void CheckSize()
        {
            var size = Hud.Window.Size;
            if (screenHeight == size.Height && screenWidth == size.Width) return;

            foreach (var plugin in registredPlugins)
            {
                plugin.OnScreenResize(screenHeight, screenWidth, size.Height, size.Width);
            }

            screenHeight = size.Height;
            screenWidth = size.Width;
        }
    }
}
