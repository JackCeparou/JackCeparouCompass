﻿namespace Turbo.Plugins.Jack.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class ItemStatListExtensions
    {
        public static int WeaponDamageBaseMin(this IEnumerable<IItemStat> stats)
        {
            return stats
                .Where(s => s.Id == "Damage_Weapon_Min#0")
                .Select(s => (int)s.DoubleValue).FirstOrDefault();
        }

        public static int WeaponDamageBaseMax(this IEnumerable<IItemStat> stats)
        {
            return stats
                .Where(s => s.Id == "Damage_Weapon_Max#0")
                .Select(s => (int)s.DoubleValue).FirstOrDefault();
        }

        public static float WeaponDamageBonusMin(this IEnumerable<IItemStat> stats)
        {
            var result = stats
                .Where(s => s.Id != "Damage_Weapon_Min#0" && s.Id.StartsWith("Damage_Weapon_Min#") && s.DoubleValue != 0)
                .Select(s => (float)s.DoubleValue).FirstOrDefault();

            return result != 0
                ? result
                : stats.Where(s => s.Id == "Damage_Weapon_Bonus_Min_X1#0").Select(s => (float)s.DoubleValue).FirstOrDefault();
        }

        public static float WeaponDamageBonusMax(this IEnumerable<IItemStat> stats)
        {
            var result = stats
                .Where(s => s.Id != "Damage_Weapon_Max#0" && s.Id.StartsWith("Damage_Weapon_Max#") && s.DoubleValue != 0)
                .Select(s => (float)s.DoubleValue).FirstOrDefault();

            if (result != 0)
                return result;

            result = stats.Where(s => s.Id == "Damage_Weapon_Bonus_Min_X1#0").Select(s => (float)s.DoubleValue).FirstOrDefault()
                   + stats.Where(s => s.Id == "Damage_Weapon_Bonus_Delta_X1#0").Select(s => (float)s.DoubleValue).FirstOrDefault();

            return result;
        }

        public static float WeaponDamageBonusDamage(this IEnumerable<IItemStat> stats)
        {
            return stats.Where(s => s.Id == "dmg_pbonus").Select(s => (float)s.DoubleValue).FirstOrDefault();
        }

        public static float WeaponDamageBonusDamagePercent(this IEnumerable<IItemStat> stats)
        {
            return stats.WeaponDamageBonusDamage() / 100f;
        }

        public static float WeaponDamageAttackSpeed(this IEnumerable<IItemStat> stats)
        {
            return stats.Where(s => s.Id == "as_weap").Select(s => (float)s.DoubleValue).FirstOrDefault();
        }

        public static float WeaponDamageBonusAttackSpeed(this IEnumerable<IItemStat> stats)
        {
            return stats.Where(s => s.Id == "as_extr").Select(s => (float)s.DoubleValue).FirstOrDefault();
        }
        public static float WeaponDamageBonusAttackSpeedPercent(this IEnumerable<IItemStat> stats)
        {
            return stats.WeaponDamageBonusAttackSpeed() / 100f;
        }

        public static float AreaDamage(this IEnumerable<IItemStat> stats)
        {
            return stats.Where(s => s.Id == "areadmg").Select(s => (float)s.DoubleValue).FirstOrDefault();
        }
    }
}