using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{

    public class OtherPlayerCirclesPlugin : BasePlugin, IInGameWorldPainter
    {

        public Dictionary<HeroClass, WorldDecoratorCollection> DecoratorByClass { get; set; }

        public OtherPlayerCirclesPlugin()
        {
            Enabled = true;
            DecoratorByClass = new Dictionary<HeroClass, WorldDecoratorCollection>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            DecoratorByClass.Add(HeroClass.Barbarian, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(200, 250, 10, 10, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.Crusader, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(240, 0, 200, 250, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.DemonHunter, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(255, 0, 0, 200, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.Monk, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(245, 120, 0, 200, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.Necromancer, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(255, 175, 238, 238, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.WitchDoctor, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(155, 0, 155, 125, 0),
                }
            ));

            DecoratorByClass.Add(HeroClass.Wizard, new WorldDecoratorCollection(
                new GroundCircleDecorator(Hud)
                {
                    Radius = 2,
                    Brush = Hud.Render.CreateBrush(255, 250, 50, 180, 0),
                }
            ));
        }

        public void PaintWorld(WorldLayer layer)
        {
            var players = Hud.Game.Players.Where(player => !player.IsMe && player.CoordinateKnown && (player.HeadStone == null));
            foreach (var player in players)
            {
                WorldDecoratorCollection decorator;
                if (!DecoratorByClass.TryGetValue(player.HeroClassDefinition.HeroClass, out decorator)) continue;

                decorator.Paint(layer, null, player.FloorCoordinate, player.BattleTagAbovePortrait);
            }
        }
    }
}