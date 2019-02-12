using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack.Extensions
{
    public static class EnumerableExtension
    {
        public static void RemoveRule(this List<BuffRule> rules, uint sno)
        {
            var rule = rules.FirstOrDefault(r => r.PowerSno == sno);
            rules.Remove(rule);
        }
    }
}
