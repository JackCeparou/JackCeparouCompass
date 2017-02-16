namespace Turbo.Plugins.JackCeparouCompass.Monsters
{
    using System;
    using Turbo.Plugins.Default;

    public class DangerousAffixMonsterConfig : BasePlugin
    {
        public DangerousAffixMonsterConfig() { Enabled = true; }

        public override void Customize()
        {
            Hud.RunOnPlugin<DangerousAffixMonsterPlugin>(plugin =>
            {
                ////////////////////////////////////////////////
                // first, redefine plugin defaults if you want :
                ////////////////////////////////////////////////
                // DEFAULTS //
                //////////////
                // plugin.DefaultMapShapePainter = new CircleShapePainter(Hud);
                // plugin.DefaultRadiusTransformator = new StandardPingRadiusTransformator(Hud, 500);
                // plugin.DefaultBackgroundBrush = Hud.Render.CreateBrush(255, 0, 0, 0, 0);
                // plugin.DefaultForegroundBrush = Hud.Render.CreateBrush(255, 255, 0, 0, 0);
                // plugin.DefaultEliteAffixesFont = Hud.Render.CreateFont("tahoma", 10f, 200, 255, 255, 0, false, false, 128, 0, 0, 0, true);
                // plugin.DefaultMinionAffixesFont = Hud.Render.CreateFont("tahoma", 7f, 200, 255, 255, 0, false, false, 128, 0, 0, 0, true);
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                // A complete example for Juggernaut overriding all defaults
                plugin.DefineDangerousAffix(MonsterAffix.Juggernaut,
                    (a) => a.NameLocalized.Substring(0, 3), // or a string like "Jug"
                    priority: 420, // higher first
                    backgroundBrush: Hud.Render.CreateBrush(255, 0, 0, 0, 0),
                    foregroundBrush : Hud.Render.CreateBrush(255, 255, 0, 0, 0),
                    shapePainter: new TriangleShapePainter(Hud), // default new CircleShapePainter(Hud)
                    ping: true, // default true
                    radiusTransformator: new StandardPingRadiusTransformator(Hud, 333),
                    eliteFont: Hud.Render.CreateFont("tahoma", 10f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                    minionFont : Hud.Render.CreateFont("tahoma", 7f, 200, 255, 0, 0, false, false, 128, 0, 0, 0, true),
                    showMinionDecorators: false, // default false
                    showMinionAffixesNames: false // default false
                );
                plugin.DefineDangerousAffix(MonsterAffix.Illusionist, (a) => a.NameLocalized.Substring(0, 3));
                plugin.DefineDangerousAffix(MonsterAffix.Reflect, (a) => a.NameLocalized.Substring(0, 1));
                plugin.DefineDangerousAffix(MonsterAffix.Poison, (a) => a.NameLocalized.Substring(0, 1));
                plugin.DefineDangerousAffix(MonsterAffix.Arcane, (a) => a.NameLocalized.Substring(0, 2));
                plugin.DefineDangerousAffix(MonsterAffix.Shielding, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Molten, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Desecrator, (a) => a.NameLocalized.Substring(0, 3));
                plugin.DefineDangerousAffix(MonsterAffix.Molten, (a) => a.NameLocalized.Substring(0, 4));
                plugin.DefineDangerousAffix(MonsterAffix.Wormhole, (a) => a.NameLocalized.Substring(0, 4));

                plugin.DefineDangerousAffix(MonsterAffix.Waller, string.Empty);
            });

            Enabled = false;
        }
    }
}