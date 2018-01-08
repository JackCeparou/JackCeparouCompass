using System;
using System.Collections.Generic;
using System.Linq;
using Turbo.Plugins.Default;

namespace Turbo.Plugins.Jack
{
    public static class ObjectDataExtensions
    {
        private static readonly Dictionary<IActor, Dictionary<Type, object>> actorsData = new Dictionary<IActor, Dictionary<Type, object>>();

        public static void SetData<T>(this IActor actor, T value)
        {
            if (!actorsData.ContainsKey(actor))
                actorsData[actor] = new Dictionary<Type, object>();

            actorsData[actor][typeof(T)] = value;
        }

        public static T GetData<T>(this IActor actor)
        {
            if (!actorsData.ContainsKey(actor))
                return default(T);

            if (!actorsData[actor].ContainsKey(typeof(T)))
                return default(T);

            return (T)actorsData[actor][typeof(T)];
        }

        public static void Reset()
        {
            if (!actorsData.Any())
                return;

            actorsData.ForEach(actor =>
            {
                if (actor.Value != null)
                    actor.Value.Clear();
            });
            actorsData.Clear();
        }
    }

    public class ObjectDataExtensionsManagerPlugin : BasePlugin, INewAreaHandler
    {
        public ObjectDataExtensionsManagerPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            ObjectDataExtensions.Reset();
        }
    }
}