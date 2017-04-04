namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.Customize.BaseConfigurator;

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
            });
        }
    }
}