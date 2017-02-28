using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Faders
{
    public class AlwaysOnFader : IFader
    {
        public bool TestVisiblity(bool visibleTestResult)
        {
            return true;
        }
    }
}