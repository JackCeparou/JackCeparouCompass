using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Faders
{
    public class FakeFader : IFader
    {
        public bool TestVisiblity(bool visibleTestResult)
        {
            return visibleTestResult;
        }
    }
}