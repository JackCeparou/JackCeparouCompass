namespace Turbo.Plugins.Jack.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ItemPerfectionsExtensions
    {
        public static int Get(this IEnumerable<IItemPerfection> perfections, string code, Func<IItemPerfection, double?> select)
        {
            return perfections
                .Where(s => s?.Attribute?.Code == code)
                .Select(s => (int)(select?.Invoke(s) ?? -1))
                .FirstOrDefault();
        }

        public static int WeaponDamageBaseMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get("Damage_Weapon_Min", s => s?.Cur);
        }

        public static int WeaponDamageBaseMax(this IEnumerable<IItemPerfection> perfections)
        {
            var itemPerfections = perfections as IItemPerfection[] ?? perfections.ToArray();
            return itemPerfections.WeaponDamageBaseMin() + itemPerfections.Get("Damage_Weapon_Delta", s => s?.Cur);
        }

        public static float WeaponDamageBonusMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get("Damage_Weapon_Min", s => s?.Cur);
        }

        public static float WeaponDamageBonusMax(this IEnumerable<IItemPerfection> perfections)
        {
            var itemPerfections = perfections as IItemPerfection[] ?? perfections.ToArray();
            return itemPerfections.WeaponDamageBaseMin() + itemPerfections.Get("Damage_Weapon_Delta", s => s?.Cur);
        }

        public static float WeaponDamageBonusMinMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get("Damage_Weapon_Min", s => s?.Min);
        }
        public static float WeaponDamageBonusMinMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get("Damage_Weapon_Min", s => s?.Max);
        }

        public static float WeaponDamageBonusMaxMin(this IEnumerable<IItemPerfection> perfections)
        {
            var itemPerfections = perfections as IItemPerfection[] ?? perfections.ToArray();
            return itemPerfections.WeaponDamageBonusMinMin() + itemPerfections.Get("Damage_Weapon_Delta", s => s?.Min);
        }
        public static float WeaponDamageBonusMaxMax(this IEnumerable<IItemPerfection> perfections)
        {
            var itemPerfections = perfections as IItemPerfection[] ?? perfections.ToArray();
            return itemPerfections.WeaponDamageBonusMaxMin() + itemPerfections.Get("Damage_Weapon_Delta", s => s?.Max);
        }

        public static IItemPerfection Intelligence(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.FirstOrDefault(p => p?.Attribute?.Code == "Intelligence_Item");
        }

        public static double Percent(this IItemPerfection perfection)
        {
            if (perfection.Cur == perfection.Max) return 1;
            if (perfection.Cur == perfection.Min) return 0;

            return ((perfection.Cur - perfection.Min)/(perfection.Max - perfection.Min));
        }
    }
}