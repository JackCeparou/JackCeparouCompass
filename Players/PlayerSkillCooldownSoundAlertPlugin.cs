namespace Turbo.Plugins.Jack.Players
{
    using System;
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

    public class PlayerSkillCooldownSoundAlertPlugin : BasePlugin, ISkillCooldownHandler
    {
        public bool InTown { get; set; }
        public HashSet<uint> PowerSnos { get; set; }
        public Dictionary<uint, string> PowerCustomNames { get; set; }
        public Func<IPlayerSkill, string> TextFunc { get; set; }

        public PlayerSkillCooldownSoundAlertPlugin()
        {
            Enabled = true;
            InTown = true;
            PowerSnos = new HashSet<uint>();
            PowerCustomNames = new Dictionary<uint, string>();
            TextFunc = (power) => power.SnoPower.NameLocalized;
        }

        public void OnCooldown(IPlayerSkill snoPower, bool expired)
        {
            if (!expired) return;
            if (Hud.Game.IsInTown && !InTown) return;
            if (!snoPower.Player.IsMe) return;

            if (PowerSnos.Contains(snoPower.SnoPower.Sno))
            {
                var text = PowerCustomNames.ContainsKey(snoPower.SnoPower.Sno)
                    ? PowerCustomNames[snoPower.SnoPower.Sno]
                    : TextFunc(snoPower);

                Hud.Speak(text);
            }

            //Says.Debug(snoPower.SnoPower.Sno, snoPower.SnoPower.NameLocalized, expired);
        }

        public void Add(ISnoPower power, string text = null)
        {
            Add(power.Sno, text);
        }

        public void Add(uint sno, string text = null)
        {
            PowerSnos.Add(sno);
            if (!string.IsNullOrWhiteSpace(text) && !PowerCustomNames.ContainsKey(sno))
            {
                PowerCustomNames.Add(sno, text);
            }
        }

        public void Remove(ISnoPower power)
        {
            Remove(power.Sno);
        }

        public void Remove(uint sno)
        {
            if (PowerSnos.Contains(sno))
            {
                PowerSnos.Remove(sno);
            }
            if (PowerCustomNames.ContainsKey(sno))
            {
                PowerCustomNames.Remove(sno);
            }
        }

        public void Clear()
        {
            PowerSnos.Clear();
            PowerCustomNames.Clear();
        }
    }
}