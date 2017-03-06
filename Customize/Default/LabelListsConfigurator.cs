namespace Turbo.Plugins.Jack.Customize.Default
{
    using Turbo.Plugins.Default;

    public class LabelListsConfigurator : IConfigurator
    {
        public void Configure(IController Hud)
        {
            Hud.RunOnPlugin<AttributeLabelListPlugin>(plugin =>
            {
                plugin.LabelList.WidthFunc = () => Hud.Window.Size.Height * 0.0630f;

                plugin.LabelList.LabelDecorators[9].TextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                plugin.LabelList.LabelDecorators[9].HintFunc = () => "pickup radius";

                /*var index = 9; //0..9
                if (index < plugin.LabelList.LabelDecorators.Count && index >= 0)
                {
                    plugin.LabelList.LabelDecorators[index].AlertTextFunc = () => Hud.Game.Me.Stats.PickupRange.ToString("#");
                    plugin.LabelList.LabelDecorators[index].HintFunc = () => "pickup radius";
                }/**/
            });
        }

        public void Dispose()
        {
        }
    }
}