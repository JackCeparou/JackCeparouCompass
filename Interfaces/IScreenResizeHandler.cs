using Turbo.Plugins;

namespace Turbo.Plugins.Jack.Interfaces
{
    public interface IScreenResizeHandler : IPlugin
    {
        void OnScreenResize(float previousHeight, float previousWidth, float newHeight, float newWidth);
    }
}