using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public static class WorldCoordinateExtensions
    {
        public static IController Hud { get; set; }

        public static Vector2 ToVector2(this IActor actor, float offsetWorldX = 0, float offsetWorldY = 0, float offsetWorldZ = 0, float translateX = 0, float translateY = 0)
        {
            return actor.FloorCoordinate.ToVector2(offsetWorldX, offsetWorldY, offsetWorldZ, translateX, translateY);
        }

        public static Vector2 ToVector2(this IWorldCoordinate coords, float offsetWorldX = 0, float offsetWorldY = 0, float offsetWorldZ = 0, float translateX = 0, float translateY = 0)
        {
            offsetWorldX += coords.X;
            offsetWorldY += coords.Y;
            offsetWorldZ += coords.Z;

            var referer = Hud.Game.Me.FloorCoordinate;
            var xd = offsetWorldX - referer.X;
            var yd = offsetWorldY - referer.Y;
            var zd = offsetWorldZ - referer.Z;

            var w = -0.515 * xd + -0.514 * yd + -0.686 * zd + 97.985;
            var X = (-1.682 * xd + 1.683 * yd + 0 * zd + 7.045e-3) / w;
            var Y = (-1.54 * xd + -1.539 * yd + 2.307 * zd + 6.161) / w;

            var aspectChange = coords.Window.Size.Width / (double)coords.Window.Size.Height / (4.0f / 3.0f); // 4:3 = default aspect ratio
            X /= aspectChange;

            var rX = (float)((X + 1) / 2 * coords.Window.Size.Width);
            var rY = (float)((1 - Y) / 2 * coords.Window.Size.Height);
            return new Vector2(rX + translateX, rY + translateY);
        }
    }

    public class WorldCoordinateExtensionsPlugin : BasePlugin
    {
        public WorldCoordinateExtensionsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            WorldCoordinateExtensions.Hud = hud;
            Enabled = false;
        }
    }
}
