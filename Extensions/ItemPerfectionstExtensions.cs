namespace Turbo.Plugins.Jack.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ItemPerfectionstExtensions
    {
        public static int WeaponDamageBaseMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Min").Select(s => (int)s.Cur).FirstOrDefault();
        }

        public static int WeaponDamageBaseMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBaseMin() + perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Delta").Select(s => (int)s.Cur).FirstOrDefault();
        }

        public static float WeaponDamageBonusMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Min").Select(s => (int)s.Cur).FirstOrDefault();
        }

        public static float WeaponDamageBonusMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBaseMin() + perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Delta").Select(s => (int)s.Cur).FirstOrDefault();
        }

        public static float WeaponDamageBonusMinMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Min").Select(s => (int)s.Min).FirstOrDefault();
        }
        public static float WeaponDamageBonusMinMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Min").Select(s => (int)s.Max).FirstOrDefault();
        }

        public static float WeaponDamageBonusMaxMin(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBonusMinMin() + perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Delta").Select(s => (int)s.Min).FirstOrDefault();
        }
        public static float WeaponDamageBonusMaxMax(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.WeaponDamageBonusMaxMin() + perfections.Where(s => s.Attribute.Code == "Damage_Weapon_Delta").Select(s => (int)s.Max).FirstOrDefault();
        }

        public static IItemPerfection Intelligence(this IEnumerable<IItemPerfection> perfections)
        {
            return perfections.FirstOrDefault(p => p.Attribute.Code == "Intelligence_Item");
        }

        public static double Percent(this IItemPerfection perfection)
        {
            if (perfection.Cur == perfection.Max) return 1;
            if (perfection.Cur == perfection.Min) return 0;

            return ((perfection.Cur - perfection.Min)/(perfection.Max - perfection.Min));
        }
    }
}