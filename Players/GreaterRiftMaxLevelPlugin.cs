using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public class GreaterRiftMaxLevelPlugin : BasePlugin, IInGameTopPainter
    {
        public TopLabelDecorator HighestSoloRiftLevelDecorator { get; set; }

        public GreaterRiftMaxLevelPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            HighestSoloRiftLevelDecorator = new TopLabelDecorator(Hud)
            {
                BackgroundTexture1 = Hud.Texture.Button2TextureBrown,
                BackgroundTextureOpacity1 = 0.7f,
                TextFont = Hud.Render.CreateFont("tahoma", 7, 250, 255, 255, 255, false, false, true),

                TextFunc = () => "GR " + Hud.Game.Me.HighestSoloRiftLevel,

                HintFunc = () => "Highest solo rift level",
            };
        }

        public void PaintTopInGame(ClipState clipState)
        {
            if (Hud.Render.UiHidden) return;
            if (clipState != ClipState.BeforeClip) return;

            var uiRect = Hud.Game.Me.PortraitUiElement.Rectangle;

            if (Hud.Game.Me.CurrentLevelNormal == 70)
            {
                HighestSoloRiftLevelDecorator.Paint(uiRect.Left + uiRect.Width * 0.26f, uiRect.Top + uiRect.Height * 0.2f, uiRect.Width * 0.5f, uiRect.Height * 0.1f, HorizontalAlign.Center);
            }
        }
    }
}