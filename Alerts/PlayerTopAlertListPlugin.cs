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
                NameSnoId = 375483,
                EquippedSkills = new uint[] { 375483 },
                InactiveBuffs = new BuffId[] { new BuffId(375483) }
            });
            // Battle Rage
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                NameSnoId = 79076,
                EquippedSkills = new uint[] { 79076 },
                InactiveBuffs = new BuffId[] { new BuffId(79076) }
            });
            // Ignore Pain
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                NameSnoId = 79528,
                EquippedSkills = new uint[] { 79528 },
                InactiveBuffs = new BuffId[] { new BuffId(79528) }
            });
            // Call of Ancients
            // only when wearing IK 4pc
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Barbarian)
            {
                NameSnoId = 80049,
                EquippedSkills = new uint[] { 80049 },
                ActiveBuffs = new BuffId[] { new BuffId(318760) },
                InvocationActorSnoIds = new HashSet<uint>() { 90443, 90535, 90536 }
            });

            // ========
            // Crusader
            // ========
            // Akarat's Champion
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Crusader)
            {
                NameSnoId = 269032,
                EquippedSkills = new uint[] { 269032 },
                ActiveBuffs = new BuffId[] { new BuffId(359585) }, // Only when wearing akkhan 6pc
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
                NameSnoId = 3968109489,
                MessageFormat = "\u2694 {0} \u2694",
                ActiveBuffs = new BuffId[] { new BuffId(246562, 1)},
            });
            // Sweeping Wind : Drained
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Monk)
            {
                //NameFunc = (Hud) => "STACKS!",
                NameSnoId = 96090,
                EquippedSkills = new uint[] { 96090 },
                InactiveBuffs = new BuffId[] { new BuffId(96090), new BuffId(446562) },
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
                //NameFunc = (Hud) => "STACKS!",
                NameSnoId = 96090,
                EquippedSkills = new uint[] { 96090 },
                ActiveBuffs = new BuffId[] { new BuffId(446562)},
                CustomCondition = (controller) =>
                {
                    var sweepingWind = controller.Game.Me.Powers.GetBuff(96090);
                    return (sweepingWind != null && sweepingWind.IconCounts[0] < 2);
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
                ShowInTown = true,
                NameSnoId = 30624,
                EquippedSkills = new uint[] { 30624 },
                InvocationActorSnoIds = new HashSet<uint>() { 432690, 432691, 432692, 432693, 432694, 122305, 179776, 171491, 179778, 171501, 171502, 179780, 179779, 179772 }
            });
            // zombie dogs
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.WitchDoctor)
            {
                ShowInTown = true,
                NameSnoId = 102573,
                EquippedSkills = new uint[] { 102573 },
                InvocationActorSnoIds = new HashSet<uint>() { 51353, 108536, 103215, 108543, 104079, 105763, 108560, 110959, 105772, 103235, 108550, 103217, 108556, 105606 }
            });

            // ======
            // Wizard
            // ======
            // Energy Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                NameSnoId = 86991,
                EquippedSkills = new uint[] { 86991 },
                InactiveBuffs = new BuffId[] { new BuffId(74499), new BuffId(86991), new BuffId(73223) },
            });
            // Storm Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                NameSnoId = 74499,
                EquippedSkills = new uint[] { 74499 },
                InactiveBuffs = new BuffId[] { new BuffId(74499), new BuffId(86991), new BuffId(73223) },
            });
            // Ice Armor
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                NameSnoId = 73223,
                EquippedSkills = new uint[] { 73223 },
                InactiveBuffs = new BuffId[] { new BuffId(74499), new BuffId(86991), new BuffId(73223) },
            });
            // Magic Weapon
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                NameSnoId = 76108,
                EquippedSkills = new uint[] { 76108 },
                InactiveBuffs = new BuffId[] { new BuffId(76108), }
            });
            // Familiar
            AlertList.Alerts.Add(new Alert(Hud, HeroClass.Wizard)
            {
                NameSnoId = 99120,
                EquippedSkills = new uint[] { 99120 },
                InactiveBuffs = new BuffId[] { new BuffId(99120), }
            });
        }

        public void PaintWorld(WorldLayer layer)
        {
            AlertList.PaintWorld(layer);
        }

        public void PaintTopInGame(ClipState clipState)
        {
            //Simon.Says.Debug(Hud.Inventory.GetSnoItem(3563390301).NameLocalized);
            AlertList.PaintTopInGame(clipState);
        }
    }
}