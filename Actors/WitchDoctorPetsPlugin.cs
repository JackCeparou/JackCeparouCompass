using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Actors
{
    public class WitchDoctorPetsPlugin : BasePlugin, IInGameWorldPainter
    {
        public HashSet<ActorSnoEnum> GargantuansIds { get; set; }
        public WorldDecoratorCollection GargantuansDecorators { get; set; }

        public HashSet<ActorSnoEnum> ZombiesDogsIds { get; set; }
        public WorldDecoratorCollection ZombiesDogsDecorators { get; set; }


        public WitchDoctorPetsPlugin()
        {
            Enabled = true;
            //GargantuansIds = new HashSet<ActorSnoEnum> { 432690, 432691, 432692, 432693, 432694, 122305, 179776, 171491, 179778, 171501, 171502, 179780, 179779, 179772 };
            //ZombiesDogsIds = new HashSet<ActorSnoEnum> { 51353, 108536, 103215, 108543, 104079, 105763, 108560, 110959, 105772, 103235, 108550, 103217, 108556, 105606 };

            GargantuansIds = new HashSet<ActorSnoEnum>
            {
                ActorSnoEnum._legendary_wd_gargantuan, // = 432690,
                ActorSnoEnum._legendary_wd_gargantuan_absorb, // = 432691,
                ActorSnoEnum._legendary_wd_gargantuan_cleave, // = 432692,
                ActorSnoEnum._legendary_wd_gargantuan_cooldown, // = 432693,
                ActorSnoEnum._legendary_wd_gargantuan_poison, // = 432694,
                //ActorSnoEnum._legendary_wd_gargantuan_slam, // = 432695,
                ActorSnoEnum._wd_gargantuan, // = 122305,
                ActorSnoEnum._wd_gargantuan_attack_swipe, // = 171491,
                ActorSnoEnum._wd_gargantuan_cleaveleft_swipe, // = 171501,
                ActorSnoEnum._wd_gargantuan_cleaveright_swipe, // = 171502,
                ActorSnoEnum._wd_gargantuan_slam, // = 179772,
                ActorSnoEnum._wd_gargantuan_absorb, // = 179776,
                ActorSnoEnum._wd_gargantuan_cleave, // = 179778,
                ActorSnoEnum._wd_gargantuan_poison, // = 179779,
                ActorSnoEnum._wd_gargantuan_cooldown, // = 179780,
            };
            ZombiesDogsIds = new HashSet<ActorSnoEnum>
            {
                ActorSnoEnum._wd_zombiedog, //  51353,
                ActorSnoEnum._wd_zombiedogrune_fire, //  103215,
                ActorSnoEnum._wd_zombiedogrune_poison, //  103217,
                ActorSnoEnum._wd_zombiedogrune_lifesteal, //  103235,
                ActorSnoEnum._wd_zombiedogrune_fire_swipes_02, //  104079,
                ActorSnoEnum._wd_zombiedogrune_poison_swipes_02, //  105606,
                ActorSnoEnum._wd_zombiedogrune_healthglobe, //  105763,
                ActorSnoEnum._wd_zombiedogrune_healthlink_attract, //  105772,
                ActorSnoEnum._wd_zombiedog_cast_spirit, //  108536,
                ActorSnoEnum._wd_zombiedogrune_fire_castspirit, //  108543,
                ActorSnoEnum._wd_zombiedogrune_lifesteal_castspirit, //  108550,
                ActorSnoEnum._wd_zombiedogrune_poison_castspirit, //  108556,
                ActorSnoEnum._wd_zombiedogrune_healthglobe_castspirit, //  108560,
                ActorSnoEnum._wd_zombiedogrune_healthlink, //  110959,
            };
    }

        public override void Load(IController hud)
        {
            base.Load(hud);
            var gargantuanBrush = Hud.Render.CreateBrush(222, 0, 255, 0, 2);
            GargantuansDecorators = new WorldDecoratorCollection(
                new GroundShapeDecorator(hud)
                {
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 1f,
                    Brush = gargantuanBrush,
                },
                new GroundCircleDecorator(hud)
                {
                    Radius = 1f,
                    Brush = gargantuanBrush,
                },
                new MapShapeDecorator(hud)
                {
                    ShapePainter = new TriangleShapePainter(hud),
                    Radius = 6f,
                    Brush = Hud.Render.CreateBrush(255, 0, 255, 0, 1),
                }
                //,
                //new MapShapeDecorator(hud)
                //{
                //    ShapePainter = new CrossShapeFilter(hud),
                //    Radius = 6f,
                //    BarBrush = Hud.Render.CreateBrush(255, 0, 255, 0, 1),
                //}
            );

            var zombieDogBrush = Hud.Render.CreateBrush(178, 0, 255, 0, 2);
            ZombiesDogsDecorators = new WorldDecoratorCollection(
                new GroundShapeDecorator(hud)
                {
                    ShapePainter = WorldStarShapePainter.NewCross(Hud),
                    Radius = 0.35f,
                    Brush = gargantuanBrush,
                },
                new GroundCircleDecorator(hud)
                {
                    Radius = 0.35f,
                    Brush = zombieDogBrush,
                },
                new MapShapeDecorator(hud)
                {
                    ShapePainter = new CrossShapePainter(hud),
                    Radius = 1f,
                    Brush = zombieDogBrush,
                }
            );
            foreach (var mapShapeDecorator in ZombiesDogsDecorators.GetDecorators<MapShapeDecorator>())
            {
                mapShapeDecorator.Enabled = false;
            }
        }

        public void PaintWorld(WorldLayer layer)
        {
            if (Hud.Render.UiHidden) return;
            if (Hud.Game.IsInTown) return;
            if (Hud.Game.Me.HeroClassDefinition.HeroClass != HeroClass.WitchDoctor) return;

            var Gargantuans = Hud.Game.Actors.Where(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && GargantuansIds.Contains(a.SnoActor.Sno));

            foreach (var garg in Gargantuans)
            {
                GargantuansDecorators.Paint(layer, garg, garg.FloorCoordinate, null);
            }

            var zombieDogs = Hud.Game.Actors.Where(a => a.SummonerAcdDynamicId == Hud.Game.Me.SummonerId && ZombiesDogsIds.Contains(a.SnoActor.Sno));

            foreach (var zombieDog in zombieDogs)
            {
                ZombiesDogsDecorators.Paint(layer, zombieDog, zombieDog.FloorCoordinate, null);
            }
        }
    }
}