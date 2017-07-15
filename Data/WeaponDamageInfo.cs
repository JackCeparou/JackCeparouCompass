namespace Turbo.Plugins.Jack.Data
{
    using System.Collections.Generic;
    using Turbo.Plugins.Jack.Models;

    public class WeaponDamageInfo
    {
        public List<WeaponDamageDefinition> Weapons { get; private set; }

        /*
         * BASE RANGE :
         * NONE : -217604914, 4077362382
         * ARCANE : -958518464, 3336448832
         * COLD : 2034881816
         * FIRE : 1956949244
         * HOLY : -303435822, 3991531474
         * LIGHTNING : 93536762
         * POISON : 93343854
         *
         * DMG % : 3699593118	Savage
         * AS % : 996645142	Vanquishing
         *
         * AD % : -415821016, 3879146280
         */

        public const uint BaseDamageRangeId = 4077362382;
        public const uint BaseDamageRangeArcaneId = 3336448832;
        public const uint BaseDamageRangeColdId = 2034881816;
        public const uint BaseDamageRangeFireId = 1956949244;
        public const uint BaseDamageRangeHolyId = 3991531474;
        public const uint BaseDamageRangeLightningId = 93536762;
        public const uint BaseDamageRangePoisonId = 93343854;

        public const uint DamageBonusPercentId = 3699593118;
        public const uint AttackSpeedBonusPercentId = 996645142;

        public static HashSet<uint> BaseDamageRangeAffixIds = new HashSet<uint>()
        {
            BaseDamageRangeId,
            BaseDamageRangeArcaneId,
            BaseDamageRangeColdId,
            BaseDamageRangeFireId,
            BaseDamageRangeHolyId,
            BaseDamageRangeLightningId,
            BaseDamageRangePoisonId,
        };

        public WeaponDamageInfo()
        {
            Weapons = new List<WeaponDamageDefinition>()
            {
                new WeaponDamageDefinition() { Id = 1, Type = "Daibo", Aps = 1.15f, BaseMin = 994, BaseMax = 1845, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 2, Type = "One_Handed Mace", Aps = 1.2f, BaseMin = 316, BaseMax = 585, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 3, Type = "Two_Handed Mace", Aps = 1.0f, BaseMin = 1737, BaseMax = 1912, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 4, Type = "One_Handed Axe", Aps = 1.3f, BaseMin = 249, BaseMax = 461, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 5, Type = "Two_Handed Axe", Aps = 1.1f, BaseMin = 1384, BaseMax = 1685, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 6, Type = "One_Handed Sword", Aps = 1.4f, BaseMin = 168, BaseMax = 392, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 7, Type = "Two_Handed Sword", Aps = 1.15f, BaseMin = 1137, BaseMax = 1702, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 8, Type = "One_Handed Flail", Aps = 1.4f, BaseMin = 192, BaseMax = 355, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 9, Type = "Two_Handed Flail", Aps = 1.15f, BaseMin = 1351, BaseMax = 1486, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 10, Type = "Hand Crossbow", Aps = 1.6f, BaseMin = 126, BaseMax = 714, BonusMinMin = 858, BonusMinMax = 1049, BonusMaxMin = 1028, BonusMaxMax = 1304, BonusAncientMinMin = 1153, BonusAncientMinMax = 1365, BonusAncientMaxMin = 1305, BonusAncientMaxMax = 1700, },
                new WeaponDamageDefinition() { Id = 11, Type = "Bow", Aps = 1.4f, BaseMin = 143, BaseMax = 815, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 12, Type = "Dagger", Aps = 1.5f, BaseMin = 107, BaseMax = 321, BonusMinMin = 858, BonusMinMax = 1049, BonusMaxMin = 1028, BonusMaxMax = 1304, BonusAncientMinMin = 1153, BonusAncientMinMax = 1365, BonusAncientMaxMin = 1305, BonusAncientMaxMax = 1700, },

                new WeaponDamageDefinition() { Id = 13, Type = "Spear", Aps = 1.2f, BaseMin = 353, BaseMax = 585, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 113, Type = "Spear", Aps = 1.2f, BaseMin = 353, BaseMax = 526, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },

                new WeaponDamageDefinition() { Id = 14, Type = "One_Handed Mighty Weapon", Aps = 1.3f, BaseMin = 249, BaseMax = 461, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 15, Type = "Two_Handed Mighty Weapon", Aps = 1.1f, BaseMin = 1462, BaseMax = 1609, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },

                new WeaponDamageDefinition() { Id = 16, Type = "Ceremonial Knife", Aps = 1.4f, BaseMin = 117, BaseMax = 469, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                //barber v2..
                new WeaponDamageDefinition() { Id = 116, Type = "Ceremonial Knife", Aps = 1.5f, BaseMin = 117, BaseMax = 469, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },

                new WeaponDamageDefinition() { Id = 17, Type = "Fist Weapon", Aps = 1.4f, BaseMin = 168, BaseMax = 392, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 18, Type = "Polearm", Aps = 1.05f, BaseMin = 1497, BaseMax = 1823, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 19, Type = "Staff", Aps = 1.1f, BaseMin = 1229, BaseMax = 1839, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },
                new WeaponDamageDefinition() { Id = 20, Type = "Crossbow", Aps = 1.1f, BaseMin = 779, BaseMax = 945, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 21, Type = "Wand", Aps = 1.4f, BaseMin = 193, BaseMax = 357, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1491, BonusAncientMaxMax = 1940, },

                new WeaponDamageDefinition() { Id = 22, Type = "One_Handed Scythe", Aps = 1.3f, BaseMin = 249, BaseMax = 461, BonusMinMin = 981, BonusMinMax = 1199, BonusMaxMin = 1175, BonusMaxMax = 1490, BonusAncientMinMin = 1318, BonusAncientMinMax = 1560, BonusAncientMaxMin = 1609, BonusAncientMaxMax = 1940, },
                new WeaponDamageDefinition() { Id = 23, Type = "Two_Handed Scythe", Aps = 1.1f, BaseMin = 1461, BaseMax = 1607, BonusMinMin = 1177, BonusMinMax = 1439, BonusMaxMin = 1410, BonusMaxMax = 1788, BonusAncientMinMin = 1582, BonusAncientMinMax = 1870, BonusAncientMaxMin = 1790, BonusAncientMaxMax = 2325, },

            };

            // TODO : find a way to avoid multiple entries (I look at you barber !)
        }
    }
}