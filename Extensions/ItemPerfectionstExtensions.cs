namespace Turbo.Plugins.Jack.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ItemPerfectionsExtensions
    {
        #region KnownAttributeNames
        private static readonly string[] DamageWeaponMin = new string[] { "Damage_Weapon_Min", "Damage_Weapon_Bonus_Min_X1" };
        private static readonly string[] DamageWeaponDelta = new string[] { "Damage_Weapon_Delta", "Damage_Weapon_Bonus_Delta_X1" }; 
        #endregion

        #region GetPerfection
        public static float Get(this IEnumerable<IItemPerfection> perfections, string code, Func<IItemPerfection, double?> select)
        {
            return perfections
                .Where(s => s?.Attribute?.Code == code)
                .Select(s => (float)(select?.Invoke(s) ?? -1))
                .FirstOrDefault();
        }
        public static float Get(this IEnumerable<IItemPerfection> perfections, Func<IItemPerfection, double?> select, params string[] codes)
        {
            foreach (var code in codes)
            {
                var current = perfections
                    .Where(s => s?.Attribute?.Code == code)
                    .Select(s => (float?)select?.Invoke(s))
                    .FirstOrDefault();

                if (current.HasValue)
                    return current.Value;
            }

            return -1;
        } 
        #endregion

        #region WeaponDamageBase
        public static float WeaponDamageBaseMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Cur, DamageWeaponMin);
        }
        public static float WeaponDamageBaseMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBaseMin() + perfections.WeaponDamageDeltaCurrent();
        } 
        #endregion

        #region WeaponDamageBonus
        public static float WeaponDamageBonusMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Cur, DamageWeaponMin);
        }
        public static float WeaponDamageBonusMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBaseMin() + perfections.WeaponDamageDeltaCurrent();
        }

        public static float WeaponDamageBonusMinMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Min, DamageWeaponMin);
        }
        public static float WeaponDamageBonusMinMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Max, DamageWeaponMin);
        }

        public static float WeaponDamageBonusMaxMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBonusMinMin() + perfections.WeaponDamageDeltaMin();
        }
        public static float WeaponDamageBonusMaxMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBonusMaxMin() + perfections.WeaponDamageDeltaMax();
        } 
        #endregion

        #region WeaponDamageDelta
        public static float WeaponDamageDeltaMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Min, DamageWeaponDelta);
        }
        public static float WeaponDamageDeltaCurrent(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Cur, DamageWeaponDelta);
        }
        public static float WeaponDamageDeltaMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Max, DamageWeaponDelta);
        }
        #endregion

        public static bool WeaponDamageRangeMaxxed(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Get(s => s?.Max, DamageWeaponMin) == perfections.Get(s => s?.Cur, DamageWeaponMin)
                && perfections.Get(s => s?.Max, DamageWeaponDelta) == perfections.Get(s => s?.Cur, DamageWeaponDelta);
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