using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Plugins.Jack.Customize.BaseConfigurator
{
    public abstract class AbstractBaseConfigurator : IConfigurator
    {
        public IController Hud { get; set; }

        protected AbstractBaseConfigurator(IController hud)
        {
            Hud = hud;
        }

        public abstract void Configure();

        public void Dispose()
        {
            Hud = null;
        }
    }
}
