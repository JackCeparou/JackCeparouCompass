namespace Turbo.Plugins.Jack.Customize.Default
{
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;
    using Turbo.Plugins.Jack.Extensions;

    public class LabelListsConfigurator : AbstractBaseConfigurator
    {
        public override void Configure(IController hud)
        {
            var Hud = hud;

            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                plugin.LabelList.WidthFunc = () => Hud.Window.Size.Height * 0.0630f;

                var dpsDecorator = plugin.LabelList.LabelDecorators[2];
                dpsDecorator.TextFunc = () =>
                {
                    var dps = Hud.Game.Me.Offense.SheetDps * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return BasePlugin.ValueToString(dps, ValueFormat.ShortNumber);
                };

                var apsDecorator = plugin.LabelList.LabelDecorators[3];
                apsDecorator.TextFunc = () =>
                {
                    var aps = Hud.Game.Me.Offense.AttackSpeed * (Hud.Game.Me.Powers.BuffIsActive(246562, 1) ? 2 : 1);
                    return aps.ToString("F2", System.Globalization.CultureInfo.InvariantCulture) + "/s";
                };

                plugin.LabelList.LabelDecorators[9].TextFunc = () => Hud.Game.Me.Stats.MoveSpeed.ToString("#");
                plugin.LabelList.LabelDecorators[9].HintFunc = () => string.Empty;

                /*var index = 9; //0..9
                if (index < plugin.LabelList.LabelDecorators.Count && index >= 0)
                {
                    plugin.LabelList.LabelDecorators[index].AlertTextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                    plugin.LabelList.LabelDecorators[index].HintFunc = () => "pickup radius";
                }/**/

                var expandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true);
                var expandedHintWidthMultiplier = 3;

                var adLabel = plugin.LabelList.LabelDecorators[6];
                adLabel.ExpandedHintFont = expandedHintFont;
                adLabel.ExpandedHintWidthMultiplier = expandedHintWidthMultiplier;
                adLabel.ExpandUpLabels = new List<TopLabelDecorator>
                {
                    CreateTopLabel(Hud, ItemLocation.RightHand, () => "Off hand"),
                    CreateTopLabel(Hud, ItemLocation.LeftHand, () => "Main hand"),
                    CreateTopLabel(Hud, ItemLocation.Shoulders, () => "Shoulders"),
                    CreateTopLabel(Hud, ItemLocation.Hands, () => "Hands"),
                    CreateTopLabel(Hud, ItemLocation.LeftRing, () => "Left ring"),
                    CreateTopLabel(Hud, ItemLocation.RightRing, () => "Right ring"),
                    CreateTopLabel(Hud, ItemLocation.Neck, () => "Neck"),
                };
            });
        }

        private TopLabelDecorator CreateTopLabel(IController Hud, ItemLocation location, StringGeneratorFunc hintFunc)
        {
            return new TopLabelDecorator(Hud)
            {
                TextFont = Hud.Render.CreateFont("tahoma", 7, 180, 255, 255, 255, false, false, true),
                ExpandedHintFont = Hud.Render.CreateFont("tahoma", 7, 255, 200, 200, 200, false, false, true),
                ExpandedHintWidthMultiplier = 3,
                BackgroundTexture1 = Hud.Texture.ButtonTextureOrange,
                BackgroundTexture2 = Hud.Texture.BackgroundTextureBlue,
                BackgroundTextureOpacity2 = 0.75f,
                TextFunc = () => Hud.Game.Items
                    .Where(item => item.Location == location).Select(item => item.StatList.AreaDamage())
                    .FirstOrDefault()
                    .ToString("F0", System.Globalization.CultureInfo.InvariantCulture) + "%",
                HintFunc = hintFunc,
            };
        }
    }
}