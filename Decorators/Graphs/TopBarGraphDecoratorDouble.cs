using System;

namespace Turbo.Plugins.Jack.Decorators.Graphs
{
    public class TopBarGraphDecoratorDouble : AbstractTopBarGraphDecorator<double>
    {
        public TopBarGraphDecoratorDouble(IController hud) : base(hud)
        {
        }

        protected override float GetHeight(double entry, double max)
        {
            if (max == 0) return 0;

            return (float)(entry / max);
        }

        protected override bool Equals(double lastEntry, double entry)
        {
            return Math.Abs(lastEntry - entry) < double.Epsilon;
        }
    }
}
