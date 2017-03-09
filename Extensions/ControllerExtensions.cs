namespace Turbo.Plugins.Jack.Extensions
{
    using System;
    using System.Linq;

    public static class ControllerExtensions
    {
        [Obsolete("Use GuessLocalizedName instead.")]
        public static string GetLocalizedName(this IController Hud, uint snoId)
        {
            return Hud.GuessLocalizedName(snoId);
        }

        public static string GuessLocalizedName(this IController Hud, uint snoId)
        {
            var power = Hud.Sno.GetSnoPower(snoId);
            if (power != null)
            {
                return power.NameLocalized;
            }
            /*TODO: check if powers localized names are working as intended
            var skill = Hud.Game.Me.Powers.UsedSkills.FirstOrDefault(s => s.SnoPower.Sno == snoId);
            if (skill != null && skill.SnoPower != null)
            {
                return skill.SnoPower.NameLocalized;
            }

            var passive = Hud.Game.Me.Powers.UsedPassives.FirstOrDefault(s => s.Sno == snoId);
            if (passive != null)
            {
                return passive.NameLocalized;
            }

            var buff = Hud.Game.Me.Powers.GetBuff(snoId);
            if (buff != null && buff.SnoPower != null)
            {
                return buff.SnoPower.NameLocalized;
            }
            /*end of todo*/

            var item = Hud.Inventory.GetSnoItem(snoId);
            if (item != null)
            {
                return item.NameLocalized;
            }

            if (Hud.Game.Me.CubeSnoItem1 != null && Hud.Game.Me.CubeSnoItem1.Sno == snoId)
            {
                return Hud.Game.Me.CubeSnoItem1.NameLocalized;
            }
            if (Hud.Game.Me.CubeSnoItem2 != null && Hud.Game.Me.CubeSnoItem2.Sno == snoId)
            {
                return Hud.Game.Me.CubeSnoItem2.NameLocalized;
            }
            if (Hud.Game.Me.CubeSnoItem3 != null && Hud.Game.Me.CubeSnoItem3.Sno == snoId)
            {
                return Hud.Game.Me.CubeSnoItem3.NameLocalized;
            }

            return snoId.ToString();
        }
    }
}