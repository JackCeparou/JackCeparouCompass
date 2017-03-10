// adaptation of StormReaver v6 xml theme
namespace Turbo.Plugins.Jack.Monsters
{
    using SharpDX.Direct2D1;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class BossSkillsPlugin : BasePlugin, IInGameWorldPainter
    {
        public Dictionary<uint, WorldDecoratorCollection> SnoMapping { get; set; }

        ////private GroundLabelDecorator debugDecorator;

        public BossSkillsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            SnoMapping = new Dictionary<uint, WorldDecoratorCollection>();

            //<!-- add ground circle to RG Tornado/EnergyTwister (Sand Shaper/Saxtris):
            //139741	ZoltunKulle_EnergyTwister	Energy Twister -->
            //<RG_Tornado_ET enabled="1" keywords="snos=139741">
            //  <ground_circle enabled="1" radius="10" stroke="2" dash="Dash" color="160,255,50,50" />
            //</RG_Tornado_ET>
            SnoMapping.Add(139741, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to RG AOE DOT Poison 10y (The Choker):
            //360046	X1_Unique_Monster_Generic_AOE_DOT_Poison_10foot -->
            //<RG_AOE_Poison_1 enabled="1" keywords="snos=360046">
            // <ground_circle enabled="1" radius="10" stroke="2" dash="Dash" color="160,255,50,50" />
            //</RG_AOE_Poison_1>
            SnoMapping.Add(360046, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 10,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to AOE DOT Poison 20y:
            //363358	X1_Unique_Monster_Generic_AOE_DOT_Poison_20foot -->
            //<RG_AOE_Poison_2 enabled="1" keywords="snos=363358">
            // <ground_circle enabled="1" radius="20" stroke="2" dash="Dash" color="160,255,50,50" />
            //</RG_AOE_Poison_2>
            SnoMapping.Add(363358, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to RG Fire Pentagram / Impact, AOE DOT Fire:
            //159163	g_monster_projectile_fire_impact
            //359693	X1_Unique_Monster_Generic_AOE_DOT_Fire_10foot -->
            //<RG_Fire_Pentagram enabled="1" keywords="snos=159163|359693">
            // <ground_circle enabled="1" radius="11.5" stroke="5" dash="Dash" color="120,255,255,255" />
            //</RG_Fire_Pentagram>
            SnoMapping.Add(159163, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 11.5f,
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 255, 5, DashStyle.Dash)
                }));
            SnoMapping.Add(359693, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 11.5f,
                    Brush = Hud.Render.CreateBrush(120, 255, 255, 255, 5, DashStyle.Dash)
                }));

            //<!-- add ground circle to RG Dangerous skills:
            //Falling Rocks:
            // 368453	x1_LR_Boss_MalletDemon_FallingRocks (Perendi)
            // 374732	x1_Pand_Cellar_FallingRock	Falling Debris
            // 3026	a2dun_Zolt_Random_FallingRocks_C
            //Meteor Strike (Stonesinger):
            // 378237	X1_LR_Boss_AsteroidRain
            //Gas Cloud (Ghom):
            // 93837	Gluttony_gasCloud_proxy
            //-->
            //<RG_Dangerous_Skills1 enabled="1" keywords="snos=93837|368453|374732|3026|378237">
            // <ground_circle enabled="1" radius="20" stroke="2" dash="Dash" color="160,255,50,50" />
            //</RG_Dangerous_Skills1>
            var rgDangerousSkillDecorator = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                });
            //SnoMapping.Add(93837, rgDangerousSkillDecorator);
            SnoMapping.Add(368453, rgDangerousSkillDecorator);
            SnoMapping.Add(374732, rgDangerousSkillDecorator);
            SnoMapping.Add(3026, rgDangerousSkillDecorator);
            SnoMapping.Add(378237, rgDangerousSkillDecorator);

            //<!-- add ground circle to RG Ice Circles 12y? (Rime):
            //359703	X1_Unique_Monster_Generic_AOE_DOT_Cold_10foot -->
            //<RG_Rime_Ice1 enabled="1" keywords="snos=359703">
            // <ground_circle enabled="1" radius="12" color="100,150,150,150" stroke="2" dash="Dash" />
            //</RG_Rime_Ice1>
            SnoMapping.Add(359703, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to RG Ice Circles 22y? (Rime):
            //363356	X1_Unique_Monster_Generic_AOE_DOT_Cold_20foot -->
            //<RG_Rime_Ice2 enabled="1" keywords="snos=363356">
            // <ground_circle enabled="1" radius="22" color="100,150,150,150" stroke="2" dash="Dash" />
            //</RG_Rime_Ice2>
            SnoMapping.Add(363356, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 22,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to RG Ice Projectile (Rime):
            //377087	X1_Unique_Monster_Generic_Projectile_Cold -->
            //<RG_Rime_Ice_Projectiles enabled="1" keywords="snos=377087">
            // <ground_circle enabled="1" radius="3" color="100,150,150,150" stroke="2" dash="Dash" />
            //</RG_Rime_Ice_Projectiles>
            SnoMapping.Add(377087, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(100, 150, 150, 150, 2, DashStyle.Dash)
                }));

            //<!-- ==============================	-->

            //<!-- add ground circle to Diablo Ring of Fire:
            //226350	Diablo_ringofFire_damageArea -->
            //<Diablo_Ring_of_Fire enabled="1" keywords="snos=226350">
            // <ground_circle enabled="1" radius="15" stroke="3" dash="Dash" color="160,255,50,50" />
            //</Diablo_Ring_of_Fire>
            SnoMapping.Add(226350, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 3, DashStyle.Dash)
                }));

            //<!-- add ground circle to Maghda/Uber Maghda Punish Projectile:
            //166686	Maghda_Punish_projectile
            //278340	UberMaghda_Punish_projectile -->
            //<Maghda_Punish_Projectile enabled="1" keywords="snos=166686|278340">
            // <ground_circle enabled="1" radius="3" stroke="2" dash="Dash" color="160,255,50,50" />
            //</Maghda_Punish_Projectile>
            SnoMapping.Add(166686, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));
            SnoMapping.Add(278340, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 3,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 50, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to Zoltun Kulle Slow-Time Bubble:
            //185924	zoltunKulle_slowTime_bubble	-->
            //<Zoltun_Kulle_SlowTime_Bubble enabled="1" keywords="snos=185924">
            // <ground_circle enabled="1" radius="20" stroke="2" dash="Dash" color="160,255,50,255" />
            //</Zoltun_Kulle_SlowTime_Bubble>
            SnoMapping.Add(185924, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 20,
                    Brush = Hud.Render.CreateBrush(160, 255, 50, 255, 2, DashStyle.Dash)
                }));

            //<!-- add ground circle to Adria skills:
            //360738	X1_Adria_arcanePool / 358404	X1_Adria_blood_large
            //292507	x1_Adria_Arena_FloorPanel_Active / 292508	x1_Adria_Arena_FloorPanel_Telegraph
            //363873	x1_Adria_cauldron_spawn_Projectile / 338889	x1_Adria_bouncingProjectile -->
            //<Adria_Arcane_Pool enabled="1" keywords="snos=360738|292507|292508">
            // <ground_circle enabled="1" radius="6" stroke="2" dash="Dash" color="180,255,50,255" />
            //</Adria_Arcane_Pool>
            var adriaArcanePool = new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 6,
                    Brush = Hud.Render.CreateBrush(180, 255, 50, 255, 2, DashStyle.Dash)
                });
            SnoMapping.Add(360738, adriaArcanePool);
            SnoMapping.Add(292507, adriaArcanePool);
            SnoMapping.Add(292508, adriaArcanePool);

            //<Adria_Blood_Pool enabled="1" keywords="snos=358404">
            // <ground_circle enabled="1" radius="12" stroke="1" dash="Dash" color="200,255,0,150" />
            //</Adria_Blood_Pool>
            SnoMapping.Add(358404, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(200, 255, 0, 150, 1, DashStyle.Dash)
                }));

            //<Adria_Blood_Drops enabled="1" keywords="snos=363873|338889">
            // <ground_circle enabled="1" radius="2" stroke="2" dash="Dash" color="200,255,150,255" />
            //</Adria_Blood_Drops>
            SnoMapping.Add(363873, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                }));
            SnoMapping.Add(338889, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(200, 255, 150, 255, 2, DashStyle.Dash)
                }));

            /////////////////
            // Key Wardens //
            /////////////////
            //<!-- Xah'Rith the Keywarden, ACT3 / Rain of Corpses, pending:
            //260762	Uber_Morlu_GroundBomb_Pending -->
            //<XahRith_Skills1 enabled="1" keywords="snos=260762">
            //    <ground_circle enabled="1" radius="12" stroke="2" dash="Dash" color="200,255,50,255" />
            //</XahRith_Skills1>
            SnoMapping.Add(260762, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(200, 255, 50, 255, 2, DashStyle.Dash)
                }));

            //<!-- Xah'Rith the Keywarden, ACT3 / Rain of Corpses, impact:
            //260761	Uber_Morlu_FrozenZombie_proxyActor -->
            //<XahRith_Skills2 enabled="1" keywords="snos=260761">
            //    <ground_circle enabled="1" radius="12" stroke="2" dash="Dash" color="200,255,50,100" />
            //</XahRith_Skills2>
            SnoMapping.Add(260761, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(200, 255, 50, 100, 2, DashStyle.Dash)
                }));

            //<!-- Xah'Rith the Keywarden, ACT3 / Rain of Corpses, DOT:
            //260812	Unique_Monster_IceTrail -->
            //<XahRith_Skills3 enabled="1" keywords="snos=260812">
            //    <ground_circle enabled="1" radius="12" stroke="2" dash="Dash" color="200,255,0,0" />
            //</XahRith_Skills3>
            SnoMapping.Add(260812, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 12,
                    Brush = Hud.Render.CreateBrush(200, 255, 0, 0, 2, DashStyle.Dash)
                }));

            //debugDecorator = new GroundLabelDecorator(Hud)
            //{
            //    TextFont = Hud.Render.CreateFont("tahoma", 12, 255, 255, 255, 255, false, false, true),
            //    BorderBrush = Hud.Render.CreateBrush(180, 255, 50, 255, 2, DashStyle.Dash),
            //};
        }

        public void PaintWorld(WorldLayer layer)
        {
            var bossSkills = Hud.Game.Actors.Where(a => SnoMapping.ContainsKey(a.SnoActor.Sno));
            foreach (var skill in bossSkills)
            {
                SnoMapping[skill.SnoActor.Sno].Paint(layer, skill, skill.FloorCoordinate, string.Empty);
            }

            //foreach (var actor in Hud.Game.Actors)
            //{
            //    debugDecorator.Paint(actor, actor.FloorCoordinate, actor.SnoActor.Sno.ToString());
            //}
        }
    }
}