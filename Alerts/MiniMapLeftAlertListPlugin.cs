namespace Turbo.Plugins.Jack.Alerts
{
    using Turbo.Plugins.Default;

    public class MinimapLeftAlertListPlugin : BasePlugin, IInGameTopPainter, IInGameWorldPainter
    {
        public AlertList AlertList { get; set; }

        public MinimapLeftAlertListPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            AlertList = new AlertList(Hud)
            {
                TextAlign = HorizontalAlign.Right,
                Up = false,
                RatioY = 0.05f,
                RatioWidth = 0.2f,
                RatioX = 0.81f,
                VerticalCenter = false,
                RightFunc = (controller) =>
                {
                    var uiMinimapElement = controller.Render.MinimapUiElement;
                    return uiMinimapElement.Rectangle.Left - controller.Window.Size.Height * 0.01f;
                }
            };
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