using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Plugins.Jack.Customize.BaseConfigurator
{
    public interface IConfigurator : IDisposable
    {
        void Configure(IController hud);
    }
}
