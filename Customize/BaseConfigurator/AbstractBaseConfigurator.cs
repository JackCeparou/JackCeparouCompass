using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Plugins.Jack.Customize.BaseConfigurator
{
    public abstract class AbstractBaseConfigurator : IConfigurator
    {
        public abstract void Configure(IController hud);

        public void Dispose()
        {
        }
    }
}
