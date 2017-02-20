using Turbo.Plugins.Jack.Models;

namespace Turbo.Plugins.Jack.Alerts
{
    using System.Collections.Generic;
    using Turbo.Plugins.Default;

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

            // =========
            // Barbarian
            // =========
            // War Cry
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                TextSnoId = 375483,
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
                MessageFormat = "\u2694 {0} \u2694",
                Rule =
                {
                    ActiveBuffs = new [] { new SnoPowerId(246562, 1)},
                },
            });
            // Sweeping Wind : Drained
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                //AlertTextFunc = (id) => "STACKS!",
                TextSnoId = 96090,
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
                Rule =
                {
                    ShowInTown = true,
                    EquippedSkills = new [] { new SnoPowerId(102573) },
                    InvocationActorSnoIds = new HashSet<uint>() { 51353, 108536, 103215, 108543, 104079, 105763, 108560, 110959, 105772, 103235, 108550, 103217, 108556, 105606 }
                },
            });

            // ======
            // Wizard
            // ======
            // Energy Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                TextSnoId = 86991,
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