namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Extensions;
    using Turbo.Plugins.Jack.Models;

    public class PlayerTopAlertListPlugin : BasePlugin, IInGameTopPainter, IInGameWorldPainter
    {
        public AlertList AlertList { get; set; }

        public PlayerTopAlertListPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            AlertList = new AlertList(Hud)
            {
                TextAlign = HorizontalAlign.Center,
            };

            var powers = Hud.Sno.SnoPowers;
            var warningMessageFormat = "\u26A0 {0} \u26A0"; //⚠

            // ===
            // ALL
            // ===
            // Molten explosions
            var moltenIds = new HashSet<ActorSnoEnum>()
            {
                ActorSnoEnum._monsteraffix_molten_deathstart_proxy, //4803,
                ActorSnoEnum._monsteraffix_molten_deathexplosion_proxy, //4804,
                ActorSnoEnum._monsteraffix_molten_firering, //224225,
                // TODO : missing!!! ActorSnoEnum.???, //247987,
            };
            AlertList.Alerts.Add(new Alert(Hud)
            {
                MessageFormat = "\uD83D\uDCA3 \uD83D\uDCA5 \uD83D\uDCA3", //💣 💥 💣
                Rule =
                {
                    ActorSnoIds = moltenIds,
                    CustomCondition = (controller) =>
                    {
                        return Hud.Game.Actors.Any(a => moltenIds.Contains(a.SnoActor.Sno) && Hud.Game.Me.FloorCoordinate.XYDistanceTo(a.FloorCoordinate) <= 13);
                    },
                },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 18, 255, 244, 30, 30, false, false, 242, 0, 0, 0, true),
                }
            });
            // Grotesque & Fast Mummy explosions
            var explosiveMonsterIds = new HashSet<ActorSnoEnum>()
            {
                // Fast Mummy
                ActorSnoEnum._fastmummy_a, // = 4104,
                ActorSnoEnum._fastmummy_b, // = 4105,
                ActorSnoEnum._fastmummy_c, // = 4106,
                // Grotesque
                ActorSnoEnum._corpulent_a, // = 3847,
                ActorSnoEnum._corpulent_b, // = 3848,
                ActorSnoEnum._corpulent_c, // = 3849,
                ActorSnoEnum._corpulent_d, // = 3850,
                //_corpulent_suicide_spiders = 137122,
                //_corpulent_suicide_frost = 191602,
                //_corpulent_suicide_imps = 220536,
                ActorSnoEnum._corpulent_c_oasisambush_unique, //  113994,
                ActorSnoEnum._corpulent_frost_a, //  191592,
                ActorSnoEnum._corpulent_d_cultistsurvivor_unique, //  195639,
                ActorSnoEnum._corpulent_a_unique_01, //  218307,
                ActorSnoEnum._corpulent_a_unique_02, //  218308,
                ActorSnoEnum._corpulent_b_unique_01, //  218405,
                ActorSnoEnum._corpulent_a_unique_03, //  365450,
                ActorSnoEnum._corpulent_d_unique_spec_01, //  365465,
            };
            AlertList.Alerts.Add(new Alert(Hud)
            {
                MessageFormat = "\uD83D\uDCA5 {0} \uD83D\uDCA5", //💥
                AlertTextFunc = (id) =>
                {
                    var sno = Hud.Game.Monsters.FirstOrDefault(m => explosiveMonsterIds.Contains(m.SnoActor.Sno));
                    return sno != null && sno.SnoActor != null ? sno.SnoActor.NameLocalized : "\uD83D\uDCA3"; //💣
                },
                Rule =
                {
                    ActorSnoIds = explosiveMonsterIds,
                    VisibleCondition = (controller) =>
                    {
                        return Hud.Game.Monsters.Any(a => explosiveMonsterIds.Contains(a.SnoActor.Sno) && !a.IsAlive && Hud.Game.Me.FloorCoordinate.XYDistanceTo(a.FloorCoordinate) <= 20);
                    },
                },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 18, 255, 244, 30, 30, false, false, 242, 0, 0, 0, true),
                }
            });
            // Oculus
            AlertList.Alerts.Add(new Alert(Hud)
            {
                //AlertTextFunc = (id) => "Oculus",
                TextSnoId = 3563390301,
                MessageFormat = "\u2694 {0} \u2694", //⚔
                Rule =
                {
                    ActiveBuffs = new[] { new SnoPowerId(402461, 2) },
                },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 30, 244, 30, false, false, 242, 0, 0, 0, true),
                }
            });

            // =========
            // Barbarian
            // =========
            // War Cry
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = powers.Barbarian_WarCry.Sno,
                MessageFormat = warningMessageFormat,
                Rule =
                {
                    EquippedSkills = new[] { powers.Barbarian_WarCry.CreateSnoPowerId() },
                    InactiveBuffs = new[] { powers.Barbarian_WarCry.CreateSnoPowerId() }
                },
            });
            // Battle Rage
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = powers.Barbarian_BattleRage.Sno,
                MessageFormat = warningMessageFormat,
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(powers.Barbarian_BattleRage.Sno) },
                    InactiveBuffs = new[] { new SnoPowerId(powers.Barbarian_BattleRage.Sno) }
                },
            });
            // Ignore Pain
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = powers.Barbarian_IgnorePain.Sno,
                MessageFormat = warningMessageFormat,
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(powers.Barbarian_IgnorePain.Sno) },
                    InactiveBuffs = new[] { new SnoPowerId(powers.Barbarian_IgnorePain.Sno) }
                },
            });
            // Call of Ancients
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = powers.Barbarian_CallOfTheAncients.Sno,
                MessageFormat = warningMessageFormat,
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(powers.Barbarian_CallOfTheAncients.Sno) },
                    ActiveBuffs = new[] { new SnoPowerId(318760) }, // only when wearing IK 4pc
                    InvocationActorSnoIds = new HashSet<ActorSnoEnum>()
                    {
                        ActorSnoEnum._barbarian_calloftheancients_1, // = 90443,
                        ActorSnoEnum._barbarian_calloftheancients_2, // = 90535,
                        ActorSnoEnum._barbarian_calloftheancients_3, // = 90536,
                    }
                },
            });

            // ========
            // Crusader
            // ========
            // Akarat's Champion
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Crusader)
            {
                TextSnoId = powers.Crusader_AkaratsChampion.Sno,
                MessageFormat = "\uD83D\uDCAA {0} \uD83D\uDCAA", //💪
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(powers.Crusader_AkaratsChampion.Sno) },
                    ActiveBuffs = new[] { new SnoPowerId(359585) }, // Only when wearing akkhan 6pc
                },
            });
            // Only when wearing seeker of the light 4pc
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Crusader)
            {
                TextSnoId = powers.Crusader_FallingSword.Sno, // Falling Sword
                MessageFormat = warningMessageFormat,
                Rule =
                {
                    ShowOutOfCombat = false,
                    CheckSkillCooldowns = false,
                    EquippedSkills = new[] { new SnoPowerId(powers.Crusader_FallingSword.Sno) },
                    ActiveBuffs = new[] { new SnoPowerId(436426) }, // Only when wearing seeker of the light 4pc
                    InactiveBuffs = new[] { new SnoPowerId(powers.Crusader_FallingSword.Sno) },
                },
            });

            // ===========
            // DemonHunter
            // ===========
            // Vengeance
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.DemonHunter)
            {
                TextSnoId = powers.DemonHunter_Vengeance.Sno,
                MessageFormat = "\u26A0 {0} \u26A0", //⚠
                Rule =
                {
                    CheckSkillCooldowns = true,
                    EquippedSkills = new[] { new SnoPowerId(powers.DemonHunter_Vengeance.Sno) },
                    InactiveBuffs = new[] { new SnoPowerId(powers.DemonHunter_Vengeance.Sno) },
                },
            });
            // ShadowPower 130830
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.DemonHunter)
            {
                TextSnoId = powers.DemonHunter_ShadowPower.Sno,
                MessageFormat = "\uD83D\uDE08 {0} \uD83D\uDE08",//��
                Rule =
                {
                    ShowInTown = true,
                    CheckSkillCooldowns = true,
                    EquippedSkills = new [] { new SnoPowerId(powers.DemonHunter_ShadowPower.Sno) },
                    ActiveBuffs = new [] { new SnoPowerId(318876) }, //318876	ItemPassive_Unique_Ring_680_x1		Shadow Power gains the effect of every rune and lasts forever.
                    InactiveBuffs = new [] { new SnoPowerId(powers.DemonHunter_ShadowPower.Sno) },
                },
            });

            // ====
            // Monk
            // ====
            // Flying Dragon
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                TextSnoId = 3968109489,
                MessageFormat = "\u2694 {0} \u2694", //⚔
                Rule =
                {
                    ActiveBuffs = new[] { new SnoPowerId(246562, 1) },
                },
                Label =
                {
                    TextFont = Hud.Render.CreateFont("tahoma", 14, 255, 30, 244, 30, false, false, 242, 0, 0, 0, true),
                }
            });
            // Sweeping Wind : Drained
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                //AlertTextFunc = (id) => "STACKS!",
                TextSnoId = 96090,
                MessageFormat = "!! {0} !!",
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(96090) },
                    InactiveBuffs = new[] { new SnoPowerId(96090), new SnoPowerId(446562) },
                },
                PlayerDecorators = new WorldDecoratorCollection(
                    new GroundCircleDecorator(Hud)
                    {
                        Brush = Hud.Render.CreateBrush(255, 255, 0, 0, 10.0f),
                        Radius = 5
                    }
                ),
            });

            // Sweeping Wind : Recharge
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                //AlertTextFunc = (id) => "STACKS!",
                TextSnoId = 96090,
                MessageFormat = "!! {0} !!",
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(96090) },
                    ActiveBuffs = new[] { new SnoPowerId(446562) },
                    CustomCondition = (player) =>
                    {
                        var sweepingWind = Hud.Game.Me.Powers.GetBuff(96090);
                        return sweepingWind != null && sweepingWind.IconCounts[0] < 2;
                    },
                },
                PlayerDecorators = new WorldDecoratorCollection(
                    new GroundCircleDecorator(Hud)
                    {
                        Brush = Hud.Render.CreateBrush(255, 0, 0, 255, 10.0f),
                        Radius = 5
                    }
                ),
            });

            // ===========
            // Necromancer
            // ===========
            // Bone Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Necromancer)
            {
                TextSnoId = Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno,
                MessageFormat = "!! {0} !!",
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno) },
                    InactiveBuffs = new[] { new SnoPowerId(Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno) },
                },
            });
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Necromancer)
            {
                TextSnoId = Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno,
                MessageFormat = "\u23F0 {0} \u23F0", //⏰
                AlertTextFunc = sno => string.Format(CultureInfo.InvariantCulture, "{0} {1:0.#}", Hud.GuessLocalizedName(sno), Hud.Game.Me.Powers.GetBuff(sno).TimeLeftSeconds[0]),
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno) },
                    CustomCondition = player => player.Powers.BuffIsActive(Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno) && player.Powers.GetBuff(Hud.Sno.SnoPowers.Necromancer_BoneArmor.Sno).TimeLeftSeconds[0] <= 3,
                },
            });
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Necromancer)
            {
                TextSnoId = powers.Necromancer_CommandGolem.Sno,
                MessageFormat = "\uD83D\uDEB6 {0} \uD83D\uDEB6", //🚶
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new[] { new SnoPowerId(powers.Necromancer_CommandGolem.Sno) },
                    InvocationActorSnoIds = new HashSet<ActorSnoEnum>()
                    {
                        (ActorSnoEnum)471646,
                        (ActorSnoEnum)471647,
                        (ActorSnoEnum)465239,
                        (ActorSnoEnum)471619,
                        (ActorSnoEnum)460042,
                    } //missing some?
                },
            });
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Necromancer)
            {
                TextSnoId = powers.Necromancer_CommandSkeletons.Sno,
                MessageFormat = "\uD83D\uDEB6 {0} \uD83D\uDEB6", //🚶
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new[] { new SnoPowerId(powers.Necromancer_CommandSkeletons.Sno) },
                    InvocationActorSnoIds = new HashSet<ActorSnoEnum>()
                    {
                        (ActorSnoEnum)473147,
                        (ActorSnoEnum)473428,
                        (ActorSnoEnum)473426,
                        (ActorSnoEnum)473420,
                        (ActorSnoEnum)473417,
                        (ActorSnoEnum)473418
                    } //missing some?
                },
            });

            // ===========
            // WitchDoctor
            // ===========
            // gargantuans
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = powers.WitchDoctor_Gargantuan.Sno,
                MessageFormat = "\uD83D\uDEB6 {0} \uD83D\uDEB6", //🚶
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new[] { new SnoPowerId(powers.WitchDoctor_Gargantuan.Sno) },
                    InvocationActorSnoIds = new HashSet<ActorSnoEnum>()
                    {
                        (ActorSnoEnum)432690,
                        (ActorSnoEnum)432691,
                        (ActorSnoEnum)432692,
                        (ActorSnoEnum)432693,
                        (ActorSnoEnum)432694,
                        (ActorSnoEnum)122305,
                        (ActorSnoEnum)179776,
                        (ActorSnoEnum)171491,
                        (ActorSnoEnum)179778,
                        (ActorSnoEnum)171501,
                        (ActorSnoEnum)171502,
                        (ActorSnoEnum)179780,
                        (ActorSnoEnum)179779,
                        (ActorSnoEnum)179772
                    }
                },
            });
            // zombie dogs
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = powers.WitchDoctor_SummonZombieDog.Sno,
                MessageFormat = "\uD83D\uDC15 {0} \uD83D\uDC15", //🐕
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new[] { new SnoPowerId(powers.WitchDoctor_SummonZombieDog.Sno) },
                    InvocationActorSnoIds = new HashSet<ActorSnoEnum>()
                    {
                        (ActorSnoEnum)51353,
                        (ActorSnoEnum)108536,
                        (ActorSnoEnum)103215,
                        (ActorSnoEnum)108543,
                        (ActorSnoEnum)104079,
                        (ActorSnoEnum)105763,
                        (ActorSnoEnum)108560,
                        (ActorSnoEnum)110959,
                        (ActorSnoEnum)105772,
                        (ActorSnoEnum)103235,
                        (ActorSnoEnum)108550,
                        (ActorSnoEnum)103217,
                        (ActorSnoEnum)108556,
                        (ActorSnoEnum)105606
                    }
                },
            });
            // Hex
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = powers.WitchDoctor_Hex.Sno,
                MessageFormat = "\u26A0 {0} \u26A0", //⚠
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(powers.WitchDoctor_Hex.Sno) },
                    ActiveBuffs = new[] { new SnoPowerId(439308) }, // arachyr set 4 piece
                    InactiveBuffs = new[] { new SnoPowerId(powers.WitchDoctor_Hex.Sno) },
                }
            });
            // SoulHarvest
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = powers.WitchDoctor_SoulHarvest.Sno,
                MessageFormat = "\u2668 {0} \u2668", //⚠
                Rule =
                {
                    ShowOutOfCombat = false,
                    EquippedSkills = new[] { new SnoPowerId(powers.WitchDoctor_SoulHarvest.Sno) },
                    InactiveBuffs = new[] { new SnoPowerId(powers.WitchDoctor_SoulHarvest.Sno) },
                },
            });

            // ======
            // Wizard
            // ======
            var allWizardArmors = new[]
            {
                new SnoPowerId(74499),
                new SnoPowerId(86991),
                new SnoPowerId(73223)
            };
            // Energy Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 86991,
                MessageFormat = "\u269B {0} \u269B", //⚛
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(86991) },
                    InactiveBuffs = allWizardArmors,
                },
            });
            // Storm Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 74499,
                MessageFormat = "\u269B {0} \u269B", //⚛
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(74499) },
                    InactiveBuffs = allWizardArmors,
                },
            });
            // Ice Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 73223,
                MessageFormat = "\u269B {0} \u269B", //⚛
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(73223) },
                    InactiveBuffs = allWizardArmors,
                },
            });
            // Magic Weapon
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 76108,
                MessageFormat = "\uD83D\uDDE1 {0} \uD83D\uDDE1", //🗡
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(76108) },
                    InactiveBuffs = new[] { new SnoPowerId(76108), }
                },
            });
            // Familiar
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 99120,
                MessageFormat = "!! {0} !!",
                Rule =
                {
                    EquippedSkills = new[] { new SnoPowerId(99120) },
                    InactiveBuffs = new[] { new SnoPowerId(99120), }
                },
            });
            // Archon & no bubble
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 135663,
                MessageFormat = "\u2668 {0} \u2668", //⚠
                Rule =
                {
                    //CheckSkillCooldowns = false,
                    EquippedSkills = new[] { new SnoPowerId(134872, 1), },
                    ActiveBuffs = new[] { new SnoPowerId(134872), },
                    InactiveBuffs = new[] { new SnoPowerId(135663), }
                },
            });
        }

        public void PaintWorld(WorldLayer layer)
        {
            AlertList.PaintWorld(layer);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            AlertList.PaintTopInGame(clipState);
        }
    }
}