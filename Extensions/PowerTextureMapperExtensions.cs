namespace Turbo.Plugins.Jack.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Turbo.Plugins.Default;

    public static class PowerTextureMapperExtensions
    {
        public static IController Hud { get; private set; }
        public static ISnoItem DefaultItem { get; set; }

        private static readonly Dictionary<uint, List<uint>> itemSnoIds = new Dictionary<uint, List<uint>>();
        private static readonly HashSet<uint> blackList = new HashSet<uint>();

        public static void Init(IController hud, ISnoItem defaultItem)
        {
            Hud = hud;
            DefaultItem = defaultItem;
        }

        public static IEnumerable<ISnoItem> GetItems(this ISnoPower power)
        {
            if (!CheckPower(power))
            {
                yield return DefaultItem;
                yield break;
            }

            foreach (var id in itemSnoIds[power.Sno])
            {
                yield return Hud.Inventory.GetSnoItem(id);
            }
        }

        public static ISnoItem GetItem(this ISnoPower power)
        {
            if (!CheckPower(power))
            {
                return DefaultItem;
            }

            return Hud.Inventory.GetSnoItem(itemSnoIds[power.Sno].First());
        }

        public static IEnumerable<uint> GetItemSnos(this ISnoPower power)
        {
            if (!CheckPower(power))
            {
                yield return DefaultItem.Sno;
                yield break;
            }
            
            foreach (var id in itemSnoIds[power.Sno])
            {
                yield return id;
            }
        }

        public static uint GetItemSno(this ISnoPower power)
        {
            if (!CheckPower(power))
            {
                return DefaultItem.Sno;
            }

            return itemSnoIds[power.Sno].First();
        }

        private static bool CheckPower(ISnoPower power)
        {
            if (itemSnoIds.ContainsKey(power.Sno)) return true;
            if (blackList.Contains(power.Sno)) return false;

            var items = Hud.Sno.GetAllSnoItems()
                    .Where(x => x.LegendaryPower != null && x.LegendaryPower.Sno == power.Sno)
                    .Select(x => x.Sno)
                    .ToList();

            if (!items.Any())
            {
                //Says.Debug("blacklist {0}", power.Sno);
                blackList.Add(power.Sno);
                return false;
            }

            //Says.Debug("add {0} : {1} : {2}", power.Sno, items.Count, string.Join(",", items));
            itemSnoIds.Add(power.Sno, items);

            return true;
        }
    }

    public class PowerTextureMapperExtensionsPlugin : BasePlugin
    {
        public PowerTextureMapperExtensionsPlugin()
        {
            Enabled = true;
            Order = int.MinValue;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            PowerTextureMapperExtensions.Init(hud, hud.Sno.SnoItems.Lewis_Test_Dagger);
            Enabled = false;
        }
    }
}
