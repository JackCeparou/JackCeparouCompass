using Turbo.Plugins.Jack.Extensions;

namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
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

            // ===
            // ALL
            // ===
            // Molten explosions
            var moltenIds = new HashSet<uint>() { 4803, 4804, 224225, 247987 };
            AlertList.Alerts.Add(new Alert(Hud)
            {
                MessageFormat = "\uD83D\uDCA3 \uD83D\uDCA5 \uD83D\uDCA3",//💣 💥 💣
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
            var explosiveMonsterIds = new HashSet<uint>()
            {
                4104, 4105, 4106, // Fast Mummy
                3847, 218307, 218308, 365450, 3848, 218405, 3849, 113994, 3850, 195639, 365465, 191592, // Grotesque
            };
            AlertList.Alerts.Add(new Alert(Hud)
            {
                MessageFormat = "\uD83D\uDCA5 {0} \uD83D\uDCA5",//💥
                AlertTextFunc = (id) =>
                {
                    var sno = Hud.Game.Monsters.FirstOrDefault(m => explosiveMonsterIds.Contains(m.SnoActor.Sno));
                    return sno != null && sno.SnoActor != null ? sno.SnoActor.NameLocalized : "\uD83D\uDCA3";//💣
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
                MessageFormat = "\u2694 {0} \u2694",//⚔
                Rule =
                {
                    ActiveBuffs = new [] { new SnoPowerId(402461, 2) },
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
                TextSnoId = 375483,
                MessageFormat = "\u26A0 {0} \u26A0",//⚠
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(375483) },
                    InactiveBuffs = new [] { new SnoPowerId(375483) }
                },
            });
            // Battle Rage
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = 79076,
                MessageFormat = "\u26A0 {0} \u26A0",//⚠
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(79076) },
                    InactiveBuffs = new [] { new SnoPowerId(79076) }
                },
            });
            // Ignore Pain
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = 79528,
                MessageFormat = "\u26A0 {0} \u26A0",//⚠
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(79528) },
                    InactiveBuffs = new [] { new SnoPowerId(79528) }
                },
            });
            // Call of Ancients
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = 80049,
                MessageFormat = "\u26A0 {0} \u26A0",//⚠
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(80049) },
                    ActiveBuffs = new [] { new SnoPowerId(318760) }, // only when wearing IK 4pc
                    InvocationActorSnoIds = new HashSet<uint>() { 90443, 90535, 90536 }
                },
            });

            // ========
            // Crusader
            // ========
            // Akarat's Champion
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Crusader)
            {
                TextSnoId = 269032,
                MessageFormat = "\uD83D\uDCAA {0} \uD83D\uDCAA",//💪
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(269032) },
                    ActiveBuffs = new [] { new SnoPowerId(359585) }, // Only when wearing akkhan 6pc
                },
            });

            // ===========
            // DemonHunter
            // ===========

            // ====
            // Monk
            // ====
            // Flying Dragon
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                TextSnoId = 3968109489,
                MessageFormat = "\u2694 {0} \u2694",//⚔
                Rule =
                {
                    ActiveBuffs = new [] { new SnoPowerId(246562, 1)},
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
                    EquippedSkills = new [] { new SnoPowerId(96090) },
                    InactiveBuffs = new [] { new SnoPowerId(96090), new SnoPowerId(446562) },
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
                    EquippedSkills = new [] { new SnoPowerId(96090) },
                    ActiveBuffs = new [] { new SnoPowerId(446562)},
                    CustomCondition = (controller) =>
                    {
                        var sweepingWind = controller.Game.Me.Powers.GetBuff(96090);
                        return (sweepingWind != null && sweepingWind.IconCounts[0] < 2);
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
            // WitchDoctor
            // ===========
            // gargantuans
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = 30624,
                MessageFormat = "\uD83D\uDEB6 {0} \uD83D\uDEB6", //🚶
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new [] { new SnoPowerId(30624) },
                    InvocationActorSnoIds = new HashSet<uint>() { 432690, 432691, 432692, 432693, 432694, 122305, 179776, 171491, 179778, 171501, 171502, 179780, 179779, 179772 }
                },
            });
            // zombie dogs
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = 102573,
                MessageFormat = "\uD83D\uDC15 {0} \uD83D\uDC15",//🐕
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new [] { new SnoPowerId(102573) },
                    InvocationActorSnoIds = new HashSet<uint>() { 51353, 108536, 103215, 108543, 104079, 105763, 108560, 110959, 105772, 103235, 108550, 103217, 108556, 105606 }
                },
            });
            // Hex
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                TextSnoId = 30631, // HEX
                MessageFormat = "\u26A0 {0} \u26A0",//⚠
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(30631) }, // HEX
                    ActiveBuffs = new [] { new SnoPowerId(439308) }, // arachyr set 4 piece
                    InactiveBuffs = new [] { new SnoPowerId(30631) }, // HEX
                }

            });

            // ======
            // Wizard
            // ======
            // Energy Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 86991,
                MessageFormat = "\u269B {0} \u269B",//⚛
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(86991) },
                    InactiveBuffs = new [] { new SnoPowerId(74499), new SnoPowerId(86991), new SnoPowerId(73223) },
                },
            });
            // Storm Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 74499,
                MessageFormat = "\u269B {0} \u269B",//⚛
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(74499) },
                    InactiveBuffs = new [] { new SnoPowerId(74499), new SnoPowerId(86991), new SnoPowerId(73223) },
                },
            });
            // Ice Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 73223,
                MessageFormat = "\u269B {0} \u269B",//⚛
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(73223) },
                    InactiveBuffs = new [] { new SnoPowerId(74499), new SnoPowerId(86991), new SnoPowerId(73223) },
                },
            });
            // Magic Weapon
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 76108,
                MessageFormat = "\uD83D\uDDE1 {0} \uD83D\uDDE1",//🗡
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(76108) },
                    InactiveBuffs = new [] { new SnoPowerId(76108), }
                },
            });
            // Familiar
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 99120,
                MessageFormat = "!! {0} !!",
                Rule =
                {
                    EquippedSkills = new [] { new SnoPowerId(99120) },
                    InactiveBuffs = new [] { new SnoPowerId(99120), }
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