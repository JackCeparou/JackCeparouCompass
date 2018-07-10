using SharpDX.DirectInput;
using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Customize
{
    public class KeyboardConfigurator : BasePlugin, ICustomizer
    {
        public KeyboardConfigurator()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<Jack.Keyboard.OptionTogglerPlugin>(plugin => {
                // register the letter 'K' to toggle minimap clipping
                plugin.AddAction(Key.K, (hud) => hud.SceneReveal.MinimapClip = !hud.SceneReveal.MinimapClip);

            });
        }
    }
}
