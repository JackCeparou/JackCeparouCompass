using Turbo.Plugins;

namespace Turbo.Plugins.Jack.Interfaces
{
    public interface IOnBuffDurationHandler : IPlugin
    {
        void OnBuffDuration(IBuff buff, bool expired);
    }
}