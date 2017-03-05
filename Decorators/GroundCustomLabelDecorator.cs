using System.Collections.Generic;
using System.Globalization;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Decorators
{

    // this is not a plugin, just a helper class to display labels on the ground
    public class GroundCustomLabelDecorator: GroundLabelDecorator
    {
        public StringGeneratorFunc TextFunc { get; set; }

        public GroundCustomLabelDecorator(IController hud) : base(hud)
        {
        }

        public GroundCustomLabelDecorator(IController hud, string text) : this(hud)
        {
            TextFunc = () => text;
        }

        public GroundCustomLabelDecorator(IController hud, StringGeneratorFunc textFunc) : this(hud)
        {
            TextFunc = textFunc;
        }

        public new void Paint(IActor actor, IWorldCoordinate coord, string text)
        {
            if (!Enabled) return;
            if (TextFunc != null) text = TextFunc.Invoke();

            var painter = Hud.GetPlugin<GroundLabelDecoratorPainterPlugin>();
            if (painter == null) return;

            if ((CountDownFrom > 0) && (actor != null))
            {
                var remaining = CountDownFrom - ((Hud.Game.CurrentGameTick - actor.CreatedAtInGameTick) / 60.0f);
                if (remaining < 0) remaining = 0;

                var vf = (remaining > 1.0f) ? "F0" : "F1";
                text = remaining.ToString(vf, CultureInfo.InvariantCulture);
            }

            painter.EnqueLabelForPaint(this, coord, text);
        }

    }

}