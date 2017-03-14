using System;
using System.Collections.Generic;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Labs.Texture
{
    public class TextureSizeGeneratorPlugin : BasePlugin, IInGameTopPainter
    {
        private int index;
        private List<uint> textureList;

        public TextureSizeGeneratorPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            textureList = new TextureList().TextureIds;
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.AfterClip) return;
            if (!Hud.Game.Me.IsInTown) return;
            if (index == -1) return;

            if (index >= textureList.Count)
            {
                Says.Info("Finished !!");
                index = -1;
                return;
            }

            try
            {
                var id = textureList[index];
                var texture = Hud.Texture.GetTexture(id);
                if (texture == null)
                {
                    Says.Error("No texture here !! " + id);
                }
                else
                {
                    texture.Draw(Hud.Window.Size.Width / 2f - texture.Width / 2, Hud.Window.Size.Height / 2f - texture.Height / 2, texture.Width, texture.Height);
                    //texture.Draw(Hud.Window.Size.Width / 2f, Hud.Window.Size.Height / 2f, texture.Width, texture.Height);
                    Says.Debug(id, texture.Width, texture.Height);
                    Hud.Debug(id + "\t" + texture.Width + "\t" + texture.Height);
                }

                index++;
            }
            catch (Exception ex)
            {
                Says.Error(ex.Message);
            }
        }
    }
}