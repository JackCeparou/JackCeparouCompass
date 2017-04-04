namespace Turbo.Plugins.Jack.Players
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class PlayerSkillCooldownSoundAlertPlugin : BasePlugin, ISkillCooldownHandler
    {
        public bool InTown { get; set; }
        public HashSet<uint> PowerSnos { get; set; }
        public Func<IPlayerSkill, string> TextFunc { get; set; }

        public PlayerSkillCooldownSoundAlertPlugin()
        {
            Enabled = true;
            InTown = true;
            PowerSnos = new HashSet<uint>();
            TextFunc = (power) => power.SnoPower.NameLocalized;
        }

        public void OnCooldown(IPlayerSkill snoPower, bool expired)
        {
            if (!expired) return;
            if (Hud.Game.IsInTown && !InTown) return;
            if (!snoPower.Player.IsMe) return;

            if (PowerSnos.Contains(snoPower.SnoPower.Sno))
                Hud.Speak(TextFunc(snoPower));

            //Says.Debug(snoPower.SnoPower.Sno, snoPower.SnoPower.NameLocalized, expired);
        }
    }
}