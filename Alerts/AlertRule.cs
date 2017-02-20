using System;
using Turbo.Plugins.Jack.Models;

namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using System.Linq;

    public class AlertRule
    {
        public IController Hud { get; set; }

        public HeroClass HeroClass { get; set; }

        public bool ShowInTown { get; set; }
        public bool CheckSkillCooldowns { get; set; }

        public bool AllEquippedSkills { get; set; }
        public bool AllActiveBuffs { get; set; }
        public bool AllInactiveBuffs { get; set; }

        public Func<IController, bool> VisibleCondition { get; set; }
        public Func<IController, bool> CustomCondition { get; set; }
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

            ShowInTown = true;
            AllActiveBuffs = true;
            AllInactiveBuffs = true;
            AllEquippedSkills = true;
            CheckSkillCooldowns = true;
            VisibleCondition = IsVisible;
        }

        public bool IsVisible(IController controller)
        {
            if (HeroClass != HeroClass.None && Hud.Game.Me.HeroClassDefinition.HeroClass != HeroClass) return false;
            if (controller.Game.IsInTown && !ShowInTown) return false;
            //return true;
            var visible = true;
            var player = controller.Game.Me;
            var powers = player.Powers;

            if (EquippedSkills != null)
            {
                visible = AllEquippedSkills
                    ? EquippedSkills.All(skill => powers.UsedSkills.Any(playerSkill => (skill.Icon.HasValue ? playerSkill.SnoPower.Sno == skill.Sno && playerSkill.Rune == skill.Icon.Value : playerSkill.SnoPower.Sno == skill.Sno) && (!playerSkill.IsOnCooldown || !CheckSkillCooldowns)))
                    : EquippedSkills.Any(skill => powers.UsedSkills.Any(playerSkill => (skill.Icon.HasValue ? playerSkill.SnoPower.Sno == skill.Sno && playerSkill.Rune == skill.Icon.Value : playerSkill.SnoPower.Sno == skill.Sno) && (!playerSkill.IsOnCooldown || !CheckSkillCooldowns)));
            }

            if (visible && MissingSkills != null)
                visible = MissingSkills.Any(skill => powers.UsedSkills.All(playerSkill => playerSkill.SnoPower.Sno != skill.Sno));

            if (visible && EquippedPassives != null)
                visible = EquippedPassives.All(passive => powers.UsedPassives.Any(playerPassive => playerPassive.Sno == passive));

            if (visible && MissingPassives != null)
                visible = MissingPassives.Any(passive => powers.UsedPassives.All(playerPassive => playerPassive.Sno != passive));

            if (visible && ActiveBuffs != null)
            {
                visible = AllActiveBuffs
                    ? ActiveBuffs.All(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno))
                    : ActiveBuffs.Any(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno));
            }
            if (visible && InactiveBuffs != null)
            {
                visible = AllInactiveBuffs
                    ? InactiveBuffs.All(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno))
                    : InactiveBuffs.Any(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno));
            }

            if (visible && ActorSnoIds != null)
                visible = !Hud.Game.Actors.Any(a => ActorSnoIds.Contains(a.SnoActor.Sno));

            if (visible && InvocationActorSnoIds != null)
                visible = !Hud.Game.Actors.Any(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && InvocationActorSnoIds.Contains(a.SnoActor.Sno));

            if (visible && CustomCondition != null)
                visible = CustomCondition.Invoke(Hud);

            return visible;
        }
    }
}