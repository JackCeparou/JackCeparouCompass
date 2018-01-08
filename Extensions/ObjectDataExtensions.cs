using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Plugins.Jack
{
    public static class ObjectDataExtensions
    {
        private static Dictionary<IActor, Dictionary<Type, object>> actorDictionary = new Dictionary<IActor, Dictionary<Type, object>>();

        public static void SetData<T>(this IActor actor, T value)
        {
            if (!actorDictionary.ContainsKey(actor))
                actorDictionary[actor] = new Dictionary<Type, object>();

            actorDictionary[actor][typeof (T)] = value;
        }

        public static T GetData<T>(this IActor actor)
        {
            if (!actorDictionary.ContainsKey(actor))
                return default(T);

            if (!actorDictionary[actor].ContainsKey(typeof (T)))
                return default(T);

            return (T)actorDictionary[actor][typeof (T)];
        }
    }
}
