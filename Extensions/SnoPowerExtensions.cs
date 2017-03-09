namespace Turbo.Plugins.Jack.Extensions
{
    using Turbo.Plugins.Jack.Models;

    public static class SnoPowerExtensions
    {
        public static SnoPowerId CreateSnoPowerId(this ISnoPower power)
        {
            return new SnoPowerId(power.Sno);
        }

        public static SnoPowerId CreateSnoPowerId(this ISnoPower power, int icon)
        {
            return new SnoPowerId(power.Sno, icon);
        }
    }
}