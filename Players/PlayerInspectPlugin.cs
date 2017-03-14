using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Turbo.Plugins.Default;
using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins.Jack.Players
{
    public class PlayerInspectPlugin : BasePlugin, IInGameTopPainter
    {
        private int playerShown;

        public PlayerInspectPlugin()
        {
            Enabled = true;

            playerShown = -1;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        private uint index = 4280468080;
        private ITexture _texture;

        public void PaintTopInGame(ClipState clipState)
        {
            if (clipState != ClipState.BeforeClip) return;
            if (!Hud.Game.Me.IsInTown) return;
            if (Hud.Input.IsKeyDown(Keys.X))
            {
                playerShown = -1;
                return;
            }

            //var texture = Hud.Texture.GetTexture("p2_Mojo_norm_unique_02"); // henri
            //for (var i = 0; i < 10000; i++)
            //{
            //    var texture = Hud.Texture.GetTexture(++index);
            //    if (texture == null) continue;

            //    _texture = texture;
            //    Hud.Debug(index.ToString());
            //}

            //if (_texture != null)
            //    _texture.Draw(Hud.Window.Size.Width / 2, Hud.Window.Size.Height / 2, _texture.Width, _texture.Height);

            //Says.Debug(index, string.Format(CultureInfo.InvariantCulture, "{0:0.000%}", ((float)index) / uint.MaxValue));

            foreach (var _player in Hud.Game.Players)
            {
                var portrait = _player.PortraitUiElement.Rectangle;
                if (!Hud.Window.CursorInsideRect(portrait.X, portrait.Y, portrait.Width, portrait.Height)) continue;

                playerShown = _player.PortraitIndex;
                break;
            }
            if (playerShown == -1) return;

            var player = Hud.Game.Players.FirstOrDefault(x => x.PortraitIndex == playerShown);
            if (player == null)
            {
                playerShown = -1;
                return;
            }

            var skills = player.Powers.SkillSlots;
            var passives = player.Powers.PassiveSlots;
            var gems = player.Powers.UsedLegendaryPowers.EquippedLegendaryGemsBuffs().Where(x => x.Active);
            var powers = player.Powers.UsedLegendaryPowers.EquippedLegendaryItemsBuffs().Where(x => x.Active);
            var setBonusPowers = player.Powers.AllSetBonusBuffs().Where(x => x != null && x.Active);
        }
    }
}