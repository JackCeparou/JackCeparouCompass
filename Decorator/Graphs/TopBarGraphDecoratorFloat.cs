using System;

namespace Turbo.Plugins.JackCeparouCompass.Decorator.Graphs
{
    public class TopBarGraphDecoratorFloat : AbstractTopBarGraphDecorator<float>
    {
        public TopBarGraphDecoratorFloat(IController hud) : base(hud)
        {
        }

        protected override float GetHeight(float entry, float max)
        {
            if (max == 0) return 0;

            return entry/max;
        }

        protected override bool Equals(float lastEntry, float entry)
        {
            return Math.Abs(lastEntry - entry) < float.Epsilon;
        }
    }
}
