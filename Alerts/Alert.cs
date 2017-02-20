namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Default;

    public delegate bool BooleanConditionFunc(IController hud);

    public delegate string StringGeneratorFunc(IController hud);

    public class BuffId
    {
        public uint Sno { get; set; }
        public int? Icon { get; set; }

        public BuffId(uint sno, int? icon = null)
        {
            Sno = sno;
            Icon = icon;
        }
    }

    public class Alert
    {
        public IController Hud { get; private set; }

        // state
        public bool Enabled { get; set; }
        public bool Visible { get { return CheckVisibility(); } }

        // conditions
        public HeroClass HeroClass { get; set; }
        public bool ShowInTown { get; set; }
        public BooleanConditionFunc CustomCondition { get; set; }
        public bool CheckSkillCooldowns { get; set; }
        public uint[] EquippedSkills { get; set; }
        public uint[] EquippedPassives { get; set; }
        public uint[] MissingSkills { get; set; }
        public uint[] MissingPassives { get; set; }
        public BuffId[] ActiveBuffs { get; set; }
        public bool AllActiveBuffs { get; set; }
        public BuffId[] InactiveBuffs { get; set; }
        public bool AllInactiveBuffs { get; set; }
        public HashSet<uint> ActorSnoIds { get; set; }
        public HashSet<uint> InvocationActorSnoIds { get; set; }

        // decorators
        public WorldDecoratorCollection PlayerDecorators { get; set; }
        public TopLabelDecorator Label { get; set; }

        // text
        public string MessageFormat { get; set; }
        public uint NameSnoId { get; set; }
        public StringGeneratorFunc NameFunc { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Alert" /> class.
        /// </summary>
        /// <param name="hud">The hud.</param>
        /// <param name="heroClass">The hero class.</param>
        /// <param name="text">The text.</param>
        public Alert(IController hud, HeroClass heroClass = HeroClass.None, string text = null)
        {
            Hud = hud;
            Enabled = true;
            ShowInTown = true;
            HeroClass = heroClass;
            MessageFormat = "!! {0} !!";
            CheckSkillCooldowns = true;
            AllActiveBuffs = true;
            AllInactiveBuffs = true;
            if (text == null)
            {
                NameFunc = (controller) =>
                {
                    var skill = controller.Game.Me.Powers.UsedSkills.FirstOrDefault(s => s.SnoPower.Sno == NameSnoId);
                    if (skill != null && skill.SnoPower != null)
                    {
                        return skill.SnoPower.NameLocalized;
                    }

                    var passive = controller.Game.Me.Powers.UsedPassives.FirstOrDefault(s => s.Sno == NameSnoId);
                    if (passive != null)
                    {
                        return passive.NameLocalized;
                    }

                    var buff = controller.Game.Me.Powers.GetBuff(NameSnoId);
                    if (buff != null && buff.SnoPower != null)
                    {
                        return buff.SnoPower.NameLocalized;
                    }

                    var item = controller.Inventory.GetSnoItem(NameSnoId);
                    if (item != null)
                    {
                        return item.NameLocalized;
                    }

                    if (Hud.Game.Me.CubeSnoItem1 != null && Hud.Game.Me.CubeSnoItem1.Sno == NameSnoId)
                    {
                        return Hud.Game.Me.CubeSnoItem1.NameLocalized;
                    }
                    if (Hud.Game.Me.CubeSnoItem2 != null && Hud.Game.Me.CubeSnoItem2.Sno == NameSnoId)
                    {
                        return Hud.Game.Me.CubeSnoItem2.NameLocalized;
                    }
                    if (Hud.Game.Me.CubeSnoItem3 != null && Hud.Game.Me.CubeSnoItem3.Sno == NameSnoId)
                    {
                        return Hud.Game.Me.CubeSnoItem3.NameLocalized;
                    }

                    return "....";//string.Empty;
                };
            }
            else
            {
                NameFunc = (controller) => text;
            }

            Label = new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 11, 255, 244, 30, 30, false, false, 242, 0, 0, 0, true),
                TextFunc = () => string.Format(CultureInfo.InvariantCulture, MessageFormat, NameFunc.Invoke(Hud)),
            };
        }

        /// <summary>
        /// Checks the visibility.
        /// </summary>
        /// <returns></returns>
        public bool CheckVisibility()
        {
            if (HeroClass != HeroClass.None && Hud.Game.Me.HeroClassDefinition.HeroClass != HeroClass) return false;
            if (Hud.Game.IsInTown && !ShowInTown) return false;
            //return true;
            var visible = true;
            var player = Hud.Game.Me;
            var powers = player.Powers;

            if (EquippedSkills != null)
                visible = EquippedSkills.All(skill => powers.UsedSkills.Any(playerSkill => playerSkill.SnoPower.Sno == skill && (!playerSkill.IsOnCooldown || !CheckSkillCooldowns)));

            if (visible && MissingSkills != null)
                visible = MissingSkills.Any(skill => powers.UsedSkills.All(playerSkill => playerSkill.SnoPower.Sno != skill));

            if (visible && EquippedPassives != null)
                visible = EquippedPassives.All(passive => powers.UsedPassives.Any(playerPassive => playerPassive.Sno == passive));

            if (visible && MissingPassives != null)
                visible = MissingPassives.Any(passive => powers.UsedPassives.All(playerPassive => playerPassive.Sno != passive));

            if (visible && ActiveBuffs != null) {
                visible = AllActiveBuffs
                    ? ActiveBuffs.All(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno))
                    : ActiveBuffs.Any(buff => buff.Icon.HasValue ? powers.BuffIsActive(buff.Sno, buff.Icon.Value) : powers.BuffIsActive(buff.Sno));
            }
            if (visible && InactiveBuffs != null) {
                visible = AllInactiveBuffs
                    ? InactiveBuffs.All(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno))
                    : InactiveBuffs.Any(buff => buff.Icon.HasValue ? !powers.BuffIsActive(buff.Sno, buff.Icon.Value) : !powers.BuffIsActive(buff.Sno));
            }

            if (visible && ActorSnoIds != null && ActorSnoIds.Count > 0)
                visible = !Hud.Game.Actors.Any(a => ActorSnoIds.Contains(a.SnoActor.Sno));

            if (visible && InvocationActorSnoIds != null && InvocationActorSnoIds.Count > 0)
                visible = !Hud.Game.Actors.Any(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && InvocationActorSnoIds.Contains(a.SnoActor.Sno));

            if (visible && CustomCondition != null)
                visible = CustomCondition.Invoke(Hud);

            return visible;
        }
    }
}