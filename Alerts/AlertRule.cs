namespace Turbo.Plugins.Jack.Alerts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Jack.Models;

    public class AlertRule
    {
        public IController Hud { get; set; }

        public HeroClass HeroClass { get; set; }

        public bool ShowInTown { get; set; }
        public bool ShowOutOfTown { get; set; }
        public bool ShowInCombat { get; set; }
        public bool ShowOutOfCombat { get; set; }
        public bool CheckSkillCooldowns { get; set; }

        public bool AllEquippedSkills { get; set; }
        public bool AllActiveBuffs { get; set; }
        public bool AllInactiveBuffs { get; set; }

        public Func<IPlayer, bool> VisibleCondition { get; set; }
        public Func<IPlayer, bool> CustomCondition { get; set; }
        public SnoPowerId[] EquippedSkills { get; set; }
        public SnoPowerId[] MissingSkills { get; set; }
        public SnoPowerId[] ActiveBuffs { get; set; }
        public SnoPowerId[] InactiveBuffs { get; set; }
        public uint[] EquippedPassives { get; set; }
        public uint[] MissingPassives { get; set; }
        public HashSet<uint> ActorSnoIds { get; set; }
        public HashSet<uint> InvocationActorSnoIds { get; set; }

        public AlertRule(IController hud, HeroClass heroClass = HeroClass.None)
        {
            Hud = hud;
            HeroClass = heroClass;

            ShowInTown = false;
            ShowOutOfTown = true;
            ShowInCombat = true;
            ShowOutOfCombat = true;
            AllActiveBuffs = true;
            AllInactiveBuffs = true;
            AllEquippedSkills = true;
            CheckSkillCooldowns = true;
            VisibleCondition = IsVisible;
        }

        public bool IsVisible(IPlayer player)
        {
            if (!TestPlayerCondition(player)) return false;

            var powers = player.Powers;

            if (!TestEquippedSkills(powers)) return false;
            if (!TestMissingSkills(powers)) return false;
            if (!TestEquippedPassives(powers)) return false;
            if (!TestMissingPassives(powers)) return false;
            if (!TestActiveBuffs(powers)) return false;
            if (!TestInactiveBuffs(powers)) return false;

            if (!TestActors()) return false;
            if (!TestInvocations()) return false;

            return CustomCondition == null || CustomCondition.Invoke(player);
        }

        private bool TestPlayerCondition(IPlayer player)
        {
            if (HeroClass != HeroClass.None && player.HeroClassDefinition.HeroClass != HeroClass) return false;
            if (Hud.Game.IsInTown && !ShowInTown) return false;
            if (!Hud.Game.IsInTown && !ShowOutOfTown) return false;
            if (player.InCombat && !ShowInCombat) return false;
            return player.InCombat || ShowOutOfCombat;
        }

        private bool TestActiveBuffs(IPlayerPowerInfo powers)
        {
            if (ActiveBuffs != null)
            {
                return AllActiveBuffs
                    ? ActiveBuffs.All(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno))
                    : ActiveBuffs.Any(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno));
            }
            return true;
        }

        private bool TestActors()
        {
            return ActorSnoIds == null || Hud.Game.Actors.Any(a => ActorSnoIds.Contains(a.SnoActor.Sno));
        }

        private bool TestEquippedPassives(IPlayerPowerInfo powers)
        {
            return EquippedPassives == null || EquippedPassives.All(passive => powers.UsedPassives.Any(playerPassive => playerPassive.Sno == passive));
        }

        private bool TestEquippedSkills(IPlayerPowerInfo powers)
        {
            if (EquippedSkills != null)
            {
                return AllEquippedSkills
                    ? EquippedSkills.All(skill => powers.UsedSkills.Any(playerSkill => (skill.Icon.HasValue ? playerSkill.SnoPower.Sno == skill.Sno && playerSkill.Rune == skill.Icon.Value : playerSkill.SnoPower.Sno == skill.Sno) && (!playerSkill.IsOnCooldown || !CheckSkillCooldowns)))
                    : EquippedSkills.Any(skill => powers.UsedSkills.Any(playerSkill => (skill.Icon.HasValue ? playerSkill.SnoPower.Sno == skill.Sno && playerSkill.Rune == skill.Icon.Value : playerSkill.SnoPower.Sno == skill.Sno) && (!playerSkill.IsOnCooldown || !CheckSkillCooldowns)));
            }
            return true;
        }

        private bool TestInactiveBuffs(IPlayerPowerInfo powers)
        {
            if (InactiveBuffs != null)
            {
                return AllInactiveBuffs
                    ? InactiveBuffs.All(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno))
                    : InactiveBuffs.Any(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno));
            }
            return true;
        }

        private bool TestInvocations()
        {
            if (InvocationActorSnoIds != null)
                return !Hud.Game.Actors.Any(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && InvocationActorSnoIds.Contains(a.SnoActor.Sno));

            return true;
        }

        private bool TestMissingPassives(IPlayerPowerInfo powers)
        {
            return MissingPassives == null || MissingPassives.Any(passive => powers.UsedPassives.All(playerPassive => playerPassive.Sno != passive));
        }

        private bool TestMissingSkills(IPlayerPowerInfo powers)
        {
            return MissingSkills == null || MissingSkills.Any(skill => powers.UsedSkills.All(playerSkill => playerSkill.SnoPower.Sno != skill.Sno));
        }
    }
}