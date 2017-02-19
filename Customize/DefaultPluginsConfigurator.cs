namespace Turbo.Plugins.JackCeparouCompass.Customize
{
    using Turbo.Plugins.Default;

    public class DefaultPluginsConfigurator : BasePlugin, ICustomizer
    {
        public DefaultPluginsConfigurator()
        {
            Enabled = true;
        }

        public void Customize()
        {
            // I'M BRAVE ENOUGH
            Hud.TogglePlugin<MonsterPackPlugin>(true);
            Hud.TogglePlugin<EliteMonsterAffixPlugin>(false);
            /////////////////////////////////////////////////

            Hud.RunOnPlugin<InventoryAndStashPlugin>(plugin =>
            {
                plugin.NotGoodDisplayEnabled = true;
                plugin.DefinitelyBadDisplayEnabled = true;
                //plugin.LooksGoodDisplayEnabled = true;
            });

            //Hud.RunOnPlugin<FeetBuffListPlugin>(plugin =>
            //{
            //    plugin.BuffPainter.ShowTimeLeftNumbers = true;
            //    plugin.BuffPainter.Opacity = 0.85f;

            //    // Iron Skin
            //    plugin.RuleCalculator.Rules.Add(new BuffRule(291804) { IconIndex = null, MinimumIconCount = 1, ShowTimeLeft = true, IconSizeMultiplier = 1.0f, });
            //});

            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                plugin.LabelList.WidthFunc = () => Hud.Window.Size.Height * 0.0630f;

                plugin.LabelList.LabelDecorators[9].TextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                plugin.LabelList.LabelDecorators[9].HintFunc = () => "pickup radius";

                /*var index = 9; //0..9
                if (index < plugin.LabelList.LabelDecorators.Count && index >= 0)
                {
                    plugin.LabelList.LabelDecorators[index].TextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                    plugin.LabelList.LabelDecorators[index].HintFunc = () => "pickup radius";
                }/**/
            });

            Hud.RunOnPlugin<GlobePlugin>(plugin =>
            {
                plugin.RiftOrbDecorator.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(255, 240, 120, 240, 3),
                    Radius = 1.5f
                });
            });

            Hud.RunOnPlugin<PlayerSkillPlugin>(plugin =>
            {
                plugin.SentryDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                //plugin.SentryDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));

                plugin.SentryWithCustomEngineeringDecorator.Decorators.Add(new GroundCircleDecorator(Hud)
                {
                    Brush = Hud.Render.CreateBrush(178, 240, 148, 32, 2),
                    Radius = 16,
                });

                //plugin.SentryWithCustomEngineeringDecorator.GetDecorators<MapShapeDecorator>().ForEach(d => d.ShapePainter = new CircleShapePainter(Hud));
            });

            //Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
            //{
            //    plugin.DecoratorByClass[HeroClass.Barbarian].GetDecorators<MapLabelDecorator>().ForEach(d =>
            //    {
            //        d.LabelFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 0, false, false, 128, 0, 0, 0, true);
            //        d.Up = true;
            //    });
            //    plugin.DecoratorByClass[HeroClass.Barbarian].GetDecorators<GroundLabelDecorator>().ForEach(d =>
            //    {
            //        d.BorderBrush = Hud.Render.CreateBrush(255, 255, 255, 0, 1);
            //        d.TextFont = Hud.Render.CreateFont("tahoma", 6f, 255, 255, 255, 0, false, false, 128, 0, 0, 0, true);
            //    });
            //});

            Enabled = false;
        }

        //public override void PaintWorld(WorldLayer layer)
        //{
        //    Hud.RunOnPlugin<OtherPlayersPlugin>(plugin =>
        //    {
        //        plugin.DecoratorByClass[Hud.Game.Me.HeroClassDefinition.HeroClass].Paint(layer, Hud.Game.Me, Hud.Game.Me.FloorCoordinate, Hud.Game.Me.BattleTagAbovePortrait);
        //    });
        //}
    }
}