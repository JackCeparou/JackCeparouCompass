using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Extensions
{
    public static class PlayerPowerInfoExtensions
    {
        public static IController Hud { get; set; }

        private static Dictionary<uint, IPlayerSkill> playerSkills = new Dictionary<uint, IPlayerSkill>();

        public static IPlayerSkill GetPlayerSkill(this IPlayerPowerInfo info, uint sno)
        {
            return playerSkills.ContainsKey(sno)
                ? playerSkills[sno]
                : (playerSkills[sno] = Hud.Game.Me.Powers.UsedSkills.FirstOrDefault(s => s.SnoPower.Sno == sno));
        }
    }

    public class PlayerPowerInfoExtensionsPlugin : BasePlugin, ICustomizer
    {
        public void Customize()
        {
            PlayerPowerInfoExtensions.Hud = Hud;
            Enabled = false;
        }
    }
}
