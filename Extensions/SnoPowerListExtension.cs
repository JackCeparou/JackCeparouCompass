using System.Collections.Generic;

namespace Turbo.Plugins.Jack.Extensions
{
    public static class SnoPowerListExtension
    {
        //public static IEnumerable<ISnoPower> AllPlayerPowers(this ISnoPowerList powerList)
        //{
        //    foreach (var power in powerList.BarbarianPowers())
        //    {
        //        yield return power;
        //    }
        //    foreach (var power in powerList.CrusaderPowers())
        //    {
        //        yield return power;
        //    }
        //    foreach (var power in powerList.DemonHunterPowers())
        //    {
        //        yield return power;
        //    }
        //    foreach (var power in powerList.MonkPowers())
        //    {
        //        yield return power;
        //    }
        //    foreach (var power in powerList.WitchDoctorPowers())
        //    {
        //        yield return power;
        //    }
        //    foreach (var power in powerList.WizardPowers())
        //    {
        //        yield return power;
        //    }
        //}

        //public static IEnumerable<ISnoPower> BarbarianPowers(this ISnoPowerList powerList)
        //{
        //    // Barbarian skills
        //    yield return powerList.Barbarian_AncientSpear;
        //    yield return powerList.Barbarian_Avalanche;
        //    yield return powerList.Barbarian_Bash;
        //    yield return powerList.Barbarian_BattleRage;
        //    yield return powerList.Barbarian_CallOfTheAncients;
        //    yield return powerList.Barbarian_Cleave;
        //    yield return powerList.Barbarian_Earthquake;
        //    yield return powerList.Barbarian_Frenzy;
        //    yield return powerList.Barbarian_FuriousCharge;
        //    yield return powerList.Barbarian_GroundStomp;
        //    yield return powerList.Barbarian_HammerOfTheAncients;
        //    yield return powerList.Barbarian_IgnorePain;
        //    yield return powerList.Barbarian_Leap;
        //    yield return powerList.Barbarian_Overpower;
        //    yield return powerList.Barbarian_Rend;
        //    yield return powerList.Barbarian_Revenge;
        //    yield return powerList.Barbarian_SeismicSlam;
        //    yield return powerList.Barbarian_Sprint;
        //    yield return powerList.Barbarian_ThreateningShout;
        //    yield return powerList.Barbarian_WarCry;
        //    yield return powerList.Barbarian_WeaponThrow;
        //    yield return powerList.Barbarian_Whirlwind;
        //    yield return powerList.Barbarian_WrathOfTheBerserker;
        //    yield return powerList.Barbarian_Passive_Animosity; // 205228
        //    yield return powerList.Barbarian_Passive_BerserkerRage; // 205187
        //    yield return powerList.Barbarian_Passive_Bloodthirst; // 205217
        //    yield return powerList.Barbarian_Passive_BoonOfBulKathos; // 204603
        //    yield return powerList.Barbarian_Passive_Brawler; // 205133
        //    yield return powerList.Barbarian_Passive_EarthenMight; // 361661
        //    yield return powerList.Barbarian_Passive_InspiringPresence; // 205546
        //    yield return powerList.Barbarian_Passive_Juggernaut; // 205707
        //    yield return powerList.Barbarian_Passive_NervesOfSteel; // 217819
        //    yield return powerList.Barbarian_Passive_NoEscape; // 204725
        //    yield return powerList.Barbarian_Passive_PoundOfFlesh; // 205205
        //    yield return powerList.Barbarian_Passive_Rampage; // 296572
        //    yield return powerList.Barbarian_Passive_Relentless; // 205398
        //    yield return powerList.Barbarian_Passive_Ruthless; // 205175
        //    yield return powerList.Barbarian_Passive_Superstition; // 205491
        //    yield return powerList.Barbarian_Passive_SwordAndBoard; // 340877
        //    yield return powerList.Barbarian_Passive_ToughAsNails; // 205848
        //    yield return powerList.Barbarian_Passive_Unforgiving; // 205300
        //    yield return powerList.Barbarian_Passive_WeaponsMaster; // 206147
        //}

        //public static IEnumerable<ISnoPower> CrusaderPowers(this ISnoPowerList powerList)
        //{
        //    // Crusader skills
        //    yield return powerList.Crusader_AkaratsChampion;
        //    yield return powerList.Crusader_BlessedHammer;
        //    yield return powerList.Crusader_BlessedShield;
        //    yield return powerList.Crusader_Bombardment;
        //    yield return powerList.Crusader_Condemn;
        //    yield return powerList.Crusader_Consecration;
        //    yield return powerList.Crusader_CrushingResolve;
        //    yield return powerList.Crusader_FallingSword;
        //    yield return powerList.Crusader_FistOfTheHeavens;
        //    yield return powerList.Crusader_HeavensFury;
        //    yield return powerList.Crusader_IronSkin;
        //    yield return powerList.Crusader_Judgment;
        //    yield return powerList.Crusader_Justice;
        //    yield return powerList.Crusader_LawsOfFate;
        //    yield return powerList.Crusader_LawsOfHope;
        //    yield return powerList.Crusader_LawsOfJustice;
        //    yield return powerList.Crusader_LawsOfValor;
        //    yield return powerList.Crusader_Phalanx;
        //    yield return powerList.Crusader_Provoke;
        //    yield return powerList.Crusader_Punish;
        //    yield return powerList.Crusader_ShieldBash;
        //    yield return powerList.Crusader_ShieldGlare;
        //    yield return powerList.Crusader_Slash;
        //    yield return powerList.Crusader_Smite;
        //    yield return powerList.Crusader_SteedCharge;
        //    yield return powerList.Crusader_SweepAttack;
        //    yield return powerList.Crusader_Passive_Blunt; // 348773
        //    yield return powerList.Crusader_Passive_DivineFortress; // 356176
        //    yield return powerList.Crusader_Passive_Fanaticism; // 357269
        //    yield return powerList.Crusader_Passive_Fervor; // 357218
        //    yield return powerList.Crusader_Passive_Finery; // 311629
        //    yield return powerList.Crusader_Passive_HeavenlyStrength; // 286177
        //    yield return powerList.Crusader_Passive_HoldYourGround; // 302500
        //    yield return powerList.Crusader_Passive_HolyCause; // 310804
        //    yield return powerList.Crusader_Passive_Indestructible; // 309830
        //    yield return powerList.Crusader_Passive_Insurmountable; // 310640
        //    yield return powerList.Crusader_Passive_IronMaiden; // 310783
        //    yield return powerList.Crusader_Passive_LongArmOfTheLaw; // 310678
        //    yield return powerList.Crusader_Passive_LordCommander; // 348741
        //    yield return powerList.Crusader_Passive_Renewal; // 356173
        //    yield return powerList.Crusader_Passive_Righteousness; // 356147
        //    yield return powerList.Crusader_Passive_ToweringShield; // 356052
        //    yield return powerList.Crusader_Passive_Vigilant; // 310626
        //    yield return powerList.Crusader_Passive_Wrathful; // 310775
        //}

        //public static IEnumerable<ISnoPower> DemonHunterPowers(this ISnoPowerList powerList)
        //{
        //    // Demon Hunter skills
        //    yield return powerList.DemonHunter_Bolas;
        //    yield return powerList.DemonHunter_Caltrops;
        //    yield return powerList.DemonHunter_Chakram;
        //    yield return powerList.DemonHunter_ClusterArrow;
        //    yield return powerList.DemonHunter_Companion;
        //    yield return powerList.DemonHunter_ElementalArrow;
        //    yield return powerList.DemonHunter_EntanglingShot;
        //    yield return powerList.DemonHunter_EvasiveFire;
        //    yield return powerList.DemonHunter_FanOfKnives;
        //    yield return powerList.DemonHunter_Grenades;
        //    yield return powerList.DemonHunter_HungeringArrow;
        //    yield return powerList.DemonHunter_Impale;
        //    yield return powerList.DemonHunter_MarkedForDeath;
        //    yield return powerList.DemonHunter_Multishot;
        //    yield return powerList.DemonHunter_Preparation;
        //    yield return powerList.DemonHunter_RainOfVengeance;
        //    yield return powerList.DemonHunter_RapidFire;
        //    yield return powerList.DemonHunter_Sentry;
        //    yield return powerList.DemonHunter_ShadowPower;
        //    yield return powerList.DemonHunter_SmokeScreen;
        //    yield return powerList.DemonHunter_SpikeTrap;
        //    yield return powerList.DemonHunter_Strafe;
        //    yield return powerList.DemonHunter_Vault;
        //    yield return powerList.DemonHunter_Vengeance;
        //    yield return powerList.DemonHunter_Passive_Ambush; // 352920
        //    yield return powerList.DemonHunter_Passive_Archery; // 209734
        //    yield return powerList.DemonHunter_Passive_Awareness; // 324770
        //    yield return powerList.DemonHunter_Passive_Ballistics; // 155723
        //    yield return powerList.DemonHunter_Passive_Brooding; // 210801
        //    yield return powerList.DemonHunter_Passive_CullTheWeak; // 155721
        //    yield return powerList.DemonHunter_Passive_CustomEngineering; // 208610
        //    yield return powerList.DemonHunter_Passive_Grenadier; // 208779
        //    yield return powerList.DemonHunter_Passive_HotPursuit; // 155725
        //    yield return powerList.DemonHunter_Passive_Leech; // 439525
        //    yield return powerList.DemonHunter_Passive_NightStalker; // 218350
        //    yield return powerList.DemonHunter_Passive_NumbingTraps; // 218398
        //    yield return powerList.DemonHunter_Passive_Perfectionist; // 155722
        //    yield return powerList.DemonHunter_Passive_Sharpshooter; // 155715
        //    yield return powerList.DemonHunter_Passive_SingleOut; // 338859
        //    yield return powerList.DemonHunter_Passive_SteadyAim; // 164363
        //    yield return powerList.DemonHunter_Passive_TacticalAdvantage; // 218385
        //    yield return powerList.DemonHunter_Passive_ThrillOfTheHunt; // 211225
        //}

        //public static IEnumerable<ISnoPower> MonkPowers(this ISnoPowerList powerList)
        //{
        //    // Monk skills
        //    yield return powerList.Monk_BlindingFlash;
        //    yield return powerList.Monk_BreathOfHeaven;
        //    yield return powerList.Monk_CripplingWave;
        //    yield return powerList.Monk_CycloneStrike;
        //    yield return powerList.Monk_DashingStrike;
        //    yield return powerList.Monk_DeadlyReach;
        //    yield return powerList.Monk_Epiphany;
        //    yield return powerList.Monk_ExplodingPalm;
        //    yield return powerList.Monk_FistsOfThunder;
        //    yield return powerList.Monk_InnerSanctuary;
        //    yield return powerList.Monk_LashingTailKick;
        //    yield return powerList.Monk_MantraOfConviction;
        //    yield return powerList.Monk_MantraOfHealing;
        //    yield return powerList.Monk_MantraOfRetribution;
        //    yield return powerList.Monk_MantraOfSalvation;
        //    yield return powerList.Monk_MysticAlly;
        //    yield return powerList.Monk_Serenity;
        //    yield return powerList.Monk_SevenSidedStrike;
        //    yield return powerList.Monk_SweepingWind;
        //    yield return powerList.Monk_TempestRush;
        //    yield return powerList.Monk_WaveOfLight;
        //    yield return powerList.Monk_WayOfTheHundredFists;
        //    yield return powerList.Monk_Passive_BeaconOfYtar; // 209104
        //    yield return powerList.Monk_Passive_ChantOfResonance; // 156467
        //    yield return powerList.Monk_Passive_CombinationStrike; // 218415
        //    yield return powerList.Monk_Passive_ExaltedSoul; // 209027
        //    yield return powerList.Monk_Passive_FleetFooted; // 209029
        //    yield return powerList.Monk_Passive_Alacrity; // 156492
        //    yield return powerList.Monk_Passive_Harmony; // 404168
        //    yield return powerList.Monk_Passive_Momentum; // 341559
        //    yield return powerList.Monk_Passive_MythicRhythm; // 315271
        //    yield return powerList.Monk_Passive_NearDeathExperience; // 156484
        //    yield return powerList.Monk_Passive_Determination; // 402633
        //    yield return powerList.Monk_Passive_RelentlessAssault; // 404245
        //    yield return powerList.Monk_Passive_Resolve; // 211581
        //    yield return powerList.Monk_Passive_SeizeTheInitiative; // 209628
        //    yield return powerList.Monk_Passive_SixthSense; // 209622
        //    yield return powerList.Monk_Passive_TheGuardiansPath; // 209812
        //    yield return powerList.Monk_Passive_Transcendence; // 209250
        //    yield return powerList.Monk_Passive_Unity; // 368899
        //}

        //public static IEnumerable<ISnoPower> WitchDoctorPowers(this ISnoPowerList powerList)
        //{
        //    // Witch Doctor skills
        //    yield return powerList.WitchDoctor_AcidCloud;
        //    yield return powerList.WitchDoctor_BigBadVoodoo;
        //    yield return powerList.WitchDoctor_CorpseSpider;
        //    yield return powerList.WitchDoctor_FetishArmy;
        //    yield return powerList.WitchDoctor_Firebats;
        //    yield return powerList.WitchDoctor_Firebomb;
        //    yield return powerList.WitchDoctor_Gargantuan;
        //    yield return powerList.WitchDoctor_GraspOfTheDead;
        //    yield return powerList.WitchDoctor_Haunt;
        //    yield return powerList.WitchDoctor_Hex;
        //    yield return powerList.WitchDoctor_Horrify;
        //    yield return powerList.WitchDoctor_LocustSwarm;
        //    yield return powerList.WitchDoctor_MassConfusion;
        //    yield return powerList.WitchDoctor_Piranhas;
        //    yield return powerList.WitchDoctor_PlagueOfToads;
        //    yield return powerList.WitchDoctor_PoisonDart;
        //    yield return powerList.WitchDoctor_Sacrifice;
        //    yield return powerList.WitchDoctor_SoulHarvest;
        //    yield return powerList.WitchDoctor_SpiritBarrage;
        //    yield return powerList.WitchDoctor_SpiritWalk;
        //    yield return powerList.WitchDoctor_SummonZombieDog;
        //    yield return powerList.WitchDoctor_WallOfDeath;
        //    yield return powerList.WitchDoctor_ZombieCharger;
        //    yield return powerList.WitchDoctor_Passive_BadMedicine; // 217826
        //    yield return powerList.WitchDoctor_Passive_BloodRitual; // 208568
        //    yield return powerList.WitchDoctor_Passive_CircleOfLife; // 208571
        //    yield return powerList.WitchDoctor_Passive_ConfidenceRitual; // 442741
        //    yield return powerList.WitchDoctor_Passive_CreepingDeath; // 340908
        //    yield return powerList.WitchDoctor_Passive_FetishSycophants; // 218588
        //    yield return powerList.WitchDoctor_Passive_FierceLoyalty; // 208639
        //    yield return powerList.WitchDoctor_Passive_GraveInjustice; // 218191
        //    yield return powerList.WitchDoctor_Passive_GruesomeFeast; // 208594
        //    yield return powerList.WitchDoctor_Passive_JungleFortitude; // 217968
        //    yield return powerList.WitchDoctor_Passive_MidnightFeast; // 340909
        //    yield return powerList.WitchDoctor_Passive_SwamplandAttunement; // 340910
        //    yield return powerList.WitchDoctor_Passive_PierceTheVeil; // 208628
        //    yield return powerList.WitchDoctor_Passive_RushOfEssence; // 208565
        //    yield return powerList.WitchDoctor_Passive_SpiritualAttunement; // 208569
        //    yield return powerList.WitchDoctor_Passive_SpiritVessel; // 218501
        //    yield return powerList.WitchDoctor_Passive_TraitZombieDogSpawner; // 109560
        //    yield return powerList.WitchDoctor_Passive_TribalRites; // 208601
        //    yield return powerList.WitchDoctor_Passive_VisionQuest; // 209041
        //    yield return powerList.WitchDoctor_Passive_ZombieHandler; // 208563
        //}

        //public static IEnumerable<ISnoPower> WizardPowers(this ISnoPowerList powerList)
        //{
        //    // Wizard skills
        //    yield return powerList.Wizard_ArcaneOrb;
        //    yield return powerList.Wizard_ArcaneTorrent;
        //    yield return powerList.Wizard_Archon;
        //    yield return powerList.Wizard_ArchonArcaneBlast;
        //    yield return powerList.Wizard_ArchonArcaneStrike;
        //    yield return powerList.Wizard_ArchonDisintegrationWave;
        //    yield return powerList.Wizard_ArchonSlowTime;
        //    yield return powerList.Wizard_ArchonTeleport;
        //    yield return powerList.Wizard_BlackHole;
        //    yield return powerList.Wizard_Blizzard;
        //    yield return powerList.Wizard_DiamondSkin;
        //    yield return powerList.Wizard_Disintegrate;
        //    yield return powerList.Wizard_Electrocute;
        //    yield return powerList.Wizard_EnergyArmor;
        //    yield return powerList.Wizard_EnergyTwister;
        //    yield return powerList.Wizard_ExplosiveBlast;
        //    yield return powerList.Wizard_Familiar;
        //    yield return powerList.Wizard_FrostNova;
        //    yield return powerList.Wizard_Hydra;
        //    yield return powerList.Wizard_IceArmor;
        //    yield return powerList.Wizard_MagicMissile;
        //    yield return powerList.Wizard_MagicWeapon;
        //    yield return powerList.Wizard_Meteor;
        //    yield return powerList.Wizard_MirrorImage;
        //    yield return powerList.Wizard_RayOfFrost;
        //    yield return powerList.Wizard_ShockPulse;
        //    yield return powerList.Wizard_SlowTime;
        //    yield return powerList.Wizard_SpectralBlade;
        //    yield return powerList.Wizard_StormArmor;
        //    yield return powerList.Wizard_Teleport;
        //    yield return powerList.Wizard_WaveOfForce;
        //    yield return powerList.Wizard_Passive_ArcaneDynamo; // 208823
        //    yield return powerList.Wizard_Passive_AstralPresence; // 208472
        //    yield return powerList.Wizard_Passive_Audacity; // 341540
        //    yield return powerList.Wizard_Passive_Blur; // 208468
        //    yield return powerList.Wizard_Passive_ColdBlooded; // 226301
        //    yield return powerList.Wizard_Passive_Conflagration; // 218044
        //    yield return powerList.Wizard_Passive_Dominance; // 341344
        //    yield return powerList.Wizard_Passive_ElementalExposure; // 342326
        //    yield return powerList.Wizard_Passive_Evocation; // 208473
        //    yield return powerList.Wizard_Passive_GalvanizingWard; // 208541
        //    yield return powerList.Wizard_Passive_GlassCannon; // 208471
        //    yield return powerList.Wizard_Passive_Illusionist; // 208547
        //    yield return powerList.Wizard_Passive_Paralysis; // 226348
        //    yield return powerList.Wizard_Passive_PowerHungry; // 208478
        //    yield return powerList.Wizard_Passive_Prodigy; // 208493
        //    yield return powerList.Wizard_Passive_TemporalFlux; // 208477
        //    yield return powerList.Wizard_Passive_UnstableAnomaly; // 208474
        //    yield return powerList.Wizard_Passive_UnwaveringWill; // 298038
        //}

        public static IEnumerable<ISnoPower> GenericPowers(this ISnoPowerList powerList)
        {
            // Generic powers
            yield return powerList.Generic_1000MonsterFightMeteor; // 199789
            yield return powerList.Generic_a1dunLeorBigFireGrate; // 108017
            yield return powerList.Generic_a1dunLeorFireGutterfire; // 175159
            yield return powerList.Generic_a1dunLeorHallwayBladeTrap; // 441108
            yield return powerList.Generic_a1dunleoricfireTrench; // 89418
            yield return powerList.Generic_a1dunleoricfireTrench01; // 90428
            yield return powerList.Generic_a1dunleoricfireTrench02; // 112259
            yield return powerList.Generic_a2dunAqdActWoodPlatformDamage; // 396386
            yield return powerList.Generic_a2dunCaveGoatmenDroppingLogTrapattack; // 175069
            yield return powerList.Generic_a2dunCaveLarva; // 206565
            yield return powerList.Generic_a2dunCaveLarvaAOE; // 189864
            yield return powerList.Generic_a2dunCaveSlimeGeyserA; // 114308
            yield return powerList.Generic_a2dunZoltTeslaTowerColdspawnAttack; // 223739
            yield return powerList.Generic_a2dunZoltTeslaTowerFire; // 29983
            yield return powerList.Generic_a2dunZoltTeslaTowerFirespawnAttack; // 223738
            yield return powerList.Generic_a2dunZoltTeslaTowerIceNova; // 29984
            yield return powerList.Generic_a2dunZoltTeslaTowerLightningpewpew; // 174642
            yield return powerList.Generic_a2dunZoltTeslaTowerLightningspawnAttack; // 223731
            yield return powerList.Generic_a2dunZoltTeslaTowerPoisonspawnAttack; // 223740
            yield return powerList.Generic_A2EvacuationBelialBomb; // 153000
            yield return powerList.Generic_a3battlefielddemonicforge; // 174905
            yield return powerList.Generic_A3BattlefieldDemonMineAOE; // 122327
            yield return powerList.Generic_a3dunbastionKeepGuardFireAtNothing; // 180931
            yield return powerList.Generic_a3duncraterDemonClawBombA; // 162328
            yield return powerList.Generic_a3dunCraterDemonClawBombAtrigger; // 206575
            yield return powerList.Generic_a3duncraterDemonGroundTrapGasChamber; // 123043
            yield return powerList.Generic_a3duncraterDemonGroundTrapGasChamberFireOnly; // 212330
            yield return powerList.Generic_a3dunKeepBarrelStackShortDamage; // 55014
            yield return powerList.Generic_a3dunKeepExplodingBarrelStunpower; // 186638
            yield return powerList.Generic_a3dunkeepfireTrench01; // 200051
            yield return powerList.Generic_a3dunkeepfireTrench02; // 200038
            yield return powerList.Generic_A3IntroCatapultAttack; // 244155
            yield return powerList.Generic_a4dunGardenCorruptionMine; // 188960
            yield return powerList.Generic_a4dunHeavenHellRiftFallingRocksA; // 223721
            yield return powerList.Generic_a4dunHeavenHellRiftFallingRocksB; // 223722
            yield return powerList.Generic_a4DunHellFissure; // 223286
            yield return powerList.Generic_a4dunSpireCorruptionGeyser; // 219695
            yield return powerList.Generic_a4dunspirefirewall; // 223284
            yield return powerList.Generic_a4dunspireSpikeTrap; // 220634
            yield return powerList.Generic_ActorDisabledBuff; // 93716
            yield return powerList.Generic_ActorGhostedBuff; // 224639
            yield return powerList.Generic_ActorInTownBuff; // 220304
            yield return powerList.Generic_ActorInvulBuff; // 439438
            yield return powerList.Generic_ActorLoadingBuff; // 212032
            yield return powerList.Generic_Adriaevent47blast; // 199222
            yield return powerList.Generic_Adriaevent47projectile; // 199198
            yield return powerList.Generic_AIBackpedal; // 313697
            yield return powerList.Generic_AIBackpedalOneShotThroughActors; // 327537
            yield return powerList.Generic_AICircle; // 29986
            yield return powerList.Generic_AICircleLong; // 29987
            yield return powerList.Generic_AICircleStrafe; // 29989
            yield return powerList.Generic_AICircleStrafeShort; // 29988
            yield return powerList.Generic_AIClose; // 29990
            yield return powerList.Generic_AICloseLong; // 29991
            yield return powerList.Generic_AIEscortFollow; // 29992
            yield return powerList.Generic_AIEvadeBuff; // 99543
            yield return powerList.Generic_AIFollow; // 29993
            yield return powerList.Generic_AIFollowClose; // 29995
            yield return powerList.Generic_AIFollowMeleeLead; // 104514
            yield return powerList.Generic_AIFollowMeleeLeadPet; // 231004
            yield return powerList.Generic_AIFollowPath; // 29994
            yield return powerList.Generic_AIFollowWithWalk; // 1728
            yield return powerList.Generic_AIIdle; // 29996
            yield return powerList.Generic_AIIdleLong; // 29997
            yield return powerList.Generic_AIIdleShort; // 29998
            yield return powerList.Generic_AIOrbit; // 55433
            yield return powerList.Generic_AIReturnToGuardObject; // 193411
            yield return powerList.Generic_AIReturnToPath; // 30000
            yield return powerList.Generic_AIRunAway; // 30001
            yield return powerList.Generic_AIRunAwayLong; // 30002
            yield return powerList.Generic_AIRunAwayShort; // 30003
            yield return powerList.Generic_AIRunAwayShortV2; // 410363
            yield return powerList.Generic_AIRunInFront; // 30004
            yield return powerList.Generic_AIRunInFrontGuaranteed; // 163339
            yield return powerList.Generic_AIRunNearby; // 30005
            yield return powerList.Generic_AIRunNearbyGloam; // 30006
            yield return powerList.Generic_AIRunNearbyLong; // 30007
            yield return powerList.Generic_AIRunNearbyShort; // 30008
            yield return powerList.Generic_AIRunTo; // 30009
            yield return powerList.Generic_AIRunToGuaranteed; // 163338
            yield return powerList.Generic_AIRunToGuaranteedSpider; // 376110
            yield return powerList.Generic_AISprintInFrontGuaranteed; // 163336
            yield return powerList.Generic_AISprintTo; // 82805
            yield return powerList.Generic_AISprintToGuaranteed; // 163335
            yield return powerList.Generic_AIStrafe; // 30010
            yield return powerList.Generic_AITownWalkToGuaranteed; // 217618
            yield return powerList.Generic_AIWalkInFront; // 30012
            yield return powerList.Generic_AIWalkInFrontGuaranteed; // 163334
            yield return powerList.Generic_AIWalkTo; // 30013
            yield return powerList.Generic_AIWalkToGuaranteed; // 163333
            yield return powerList.Generic_AIWander; // 1729
            yield return powerList.Generic_AIWanderLong; // 30015
            yield return powerList.Generic_AIWanderRun; // 30014
            yield return powerList.Generic_AIWandersuperLong; // 30016
            yield return powerList.Generic_AIWarnOthers; // 114421
            yield return powerList.Generic_AncientSpearKnockback; // 106281
            yield return powerList.Generic_AngelCorruptPiercingDash; // 440446
            yield return powerList.Generic_AnniversaryBuffEXPMF; // 311167
            yield return powerList.Generic_AxeBadData; // 30020
            yield return powerList.Generic_AxeOperateGizmo; // 30021
            yield return powerList.Generic_AxeOperateNPC; // 30022
            yield return powerList.Generic_AzmodanAODDamage; // 123199
            yield return powerList.Generic_AzmodanFallingCorpses; // 122700
            yield return powerList.Generic_AzmodanGlobeOfAnnihilation; // 122699
            yield return powerList.Generic_AzmodanLaserAttack; // 129243
            yield return powerList.Generic_AzmodanMelee; // 133744
            yield return powerList.Generic_AzmodanonDeath; // 176046
            yield return powerList.Generic_AzmodanPhase3Channel; // 123466
            yield return powerList.Generic_AzmodanTaunt; // 211934
            yield return powerList.Generic_AzmodanTurning; // 211856
            yield return powerList.Generic_BannerDrop; // 185040
            yield return powerList.Generic_BannerDropPVP; // 234255
            yield return powerList.Generic_BanterCooldown; // 134334
            yield return powerList.Generic_BareHandedPassive; // 30145
            yield return powerList.Generic_BarrelExplodeInstant; // 1736
            yield return powerList.Generic_BeastCharge; // 30147
            yield return powerList.Generic_BeastWeaponMeleeInstant; // 109289
            yield return powerList.Generic_BelialArmProxy; // 259123
            yield return powerList.Generic_BelialGroundPound; // 67753
            yield return powerList.Generic_BelialLightningBreath; // 95856
            yield return powerList.Generic_BelialLightningStrikeEnrage; // 241757
            yield return powerList.Generic_BelialLightningStrikev2; // 96212
            yield return powerList.Generic_BelialMelee; // 96712
            yield return powerList.Generic_BelialMeleeReach; // 156429
            yield return powerList.Generic_BelialPhase3Buff; // 95811
            yield return powerList.Generic_BelialRangedAttack; // 63079
            yield return powerList.Generic_BelialSprint; // 98565
            yield return powerList.Generic_BelialSprintAway; // 105312
            yield return powerList.Generic_BigRedCharge; // 149875
            yield return powerList.Generic_BigRedFireBreath; // 150552
            yield return powerList.Generic_BlockChance10; // 355392
            yield return powerList.Generic_BodyGuardTeleport; // 131193
            yield return powerList.Generic_BoneTurretMortarCast; // 433233
            yield return powerList.Generic_BountyGroundsBurrowOut; // 446530
            yield return powerList.Generic_BrickhouseArmShields; // 72675
            yield return powerList.Generic_BrickhouseDestructionSetup; // 180875
            yield return powerList.Generic_BrickhouseEnrage; // 72713
            yield return powerList.Generic_BrickhouseSlam; // 72812
            yield return powerList.Generic_BugWingsBuff; // 255336
            yield return powerList.Generic_BurrowIn; // 30156
            yield return powerList.Generic_BurrowInHidden; // 194582
            yield return powerList.Generic_BurrowInSetup; // 69949
            yield return powerList.Generic_BurrowInSetup2HSwing; // 327086
            yield return powerList.Generic_BurrowInSetupHidden; // 346610
            yield return powerList.Generic_BurrowInSetupStaff; // 327088
            yield return powerList.Generic_BurrowOut; // 30157
            yield return powerList.Generic_BurrowOutNoFacing; // 75226
            yield return powerList.Generic_BurrowOutSetup; // 194596
            yield return powerList.Generic_BurrowStartBuff; // 30158
            yield return powerList.Generic_ButcherDamagingFire; // 86627
            yield return powerList.Generic_ButcherFloorPanelFire; // 96925
            yield return powerList.Generic_ButcherFrenzy; // 85001
            yield return powerList.Generic_ButcherFrenzyCustomLRBoss; // 364220
            yield return powerList.Generic_ButcherGrapplingHook; // 83008
            yield return powerList.Generic_ButcherOnDeath; // 209203
            yield return powerList.Generic_ButcherSlam; // 85152
            yield return powerList.Generic_ButcherSmash; // 30160
            yield return powerList.Generic_ButcherSpears; // 198671
            yield return powerList.Generic_ButcherTargetRanged; // 109153
            yield return powerList.Generic_CainIntroSwing; // 102449
            yield return powerList.Generic_CaldeumPoisonLaser; // 156211
            yield return powerList.Generic_CalldownGrenade; // 91155
            yield return powerList.Generic_CalloutCooldown; // 134225
            yield return powerList.Generic_CameraFocusBuff; // 151595
            yield return powerList.Generic_CameraFocusPetBuff; // 151604
            yield return powerList.Generic_CannotDieDuringBuff; // 225599
            yield return powerList.Generic_caOutBoneYardsCollapsingBonesDamage; // 396376
            yield return powerList.Generic_caOutOasisAttackPlantattack; // 102874
            yield return powerList.Generic_CatapultAttack; // 108036
            yield return powerList.Generic_ChampionClone; // 30166
            yield return powerList.Generic_ChampionTeleport; // 30167
            yield return powerList.Generic_CleanupSummonsOnDeath; // 442438
            yield return powerList.Generic_CollectorsEditionBuff; // 208706
            yield return powerList.Generic_CommunityEventBuffEXPMF; // 370781
            yield return powerList.Generic_CompanionBuff; // 275399
            yield return powerList.Generic_ConsolePowerGlobe; // 300082
            yield return powerList.Generic_ConsumablePotionBuffs; // 409455
            yield return powerList.Generic_Cooldown; // 30176
            yield return powerList.Generic_CopiedVisualEffectsBuff; // 91052
            yield return powerList.Generic_CoreEliteDropPod; // 134816
            yield return powerList.Generic_CoreEliteDropPodBegin; // 136455
            yield return powerList.Generic_CoreElitePodSetUp; // 134815
            yield return powerList.Generic_CorpulentExplode; // 30178
            yield return powerList.Generic_CorruptAngelSpectralStrike; // 122978
            yield return powerList.Generic_CosmeticSpectralHoundBuff; // 428398
            yield return powerList.Generic_CreepMobCreeperAttack; // 72366
            yield return powerList.Generic_CreepMobKnockback; // 71646
            yield return powerList.Generic_CreepMobKnockbackLR; // 376935
            yield return powerList.Generic_CreepMobRangedArmAttack; // 71688
            yield return powerList.Generic_CritDebuffCold; // 30180
            yield return powerList.Generic_CryptChildEat; // 1738
            yield return powerList.Generic_CryptChildLeapOut; // 30185
            yield return powerList.Generic_CryptChildLeapOutBuff; // 30186
            yield return powerList.Generic_DamageAttribute; // 86152
            yield return powerList.Generic_DebuffBleed; // 228423
            yield return powerList.Generic_DebuffBlind; // 103216
            yield return powerList.Generic_DebuffCharmed; // 311910
            yield return powerList.Generic_DebuffChilled; // 30195
            yield return powerList.Generic_DebuffFeared; // 101002
            yield return powerList.Generic_DebuffFireDamageProc; // 312061
            yield return powerList.Generic_DebuffForceGripped; // 312799
            yield return powerList.Generic_DebuffPoisonDamageProc; // 312062
            yield return powerList.Generic_DebuffRooted; // 101003
            yield return powerList.Generic_DebuffSlowed; // 100971
            yield return powerList.Generic_DebuffStunned; // 101000
            yield return powerList.Generic_DeleteSelfAnim; // 346635
            yield return powerList.Generic_demonFlyerdropBomb; // 132940
            yield return powerList.Generic_DemonFlyerFireBreath; // 155188
            yield return powerList.Generic_DemonFlyerProjectile; // 130798
            yield return powerList.Generic_demonFlyersnatch; // 121326
            yield return powerList.Generic_DemonTrooperLeapOut; // 143198
            yield return powerList.Generic_DervishWhirlwind; // 30207
            yield return powerList.Generic_DervishWhirlwindMortarPrototype; // 256026
            yield return powerList.Generic_DespairMeleeCleave; // 152865
            yield return powerList.Generic_DespairMeleeCleaveEnrage; // 241778
            yield return powerList.Generic_DespairSummonMinion; // 150486
            yield return powerList.Generic_DespairTeleport; // 149911
            yield return powerList.Generic_DespairTeleportAway; // 209700
            yield return powerList.Generic_DespairVolley; // 152866
            yield return powerList.Generic_DespairVolleyLRBoss; // 366277
            yield return powerList.Generic_DestructableObjectAOE; // 30208
            yield return powerList.Generic_DestructableObjectChandelierAOE; // 30209
            yield return powerList.Generic_DestructableObjectChandelierAOEHoist; // 358809
            yield return powerList.Generic_DestructionStreakBuffRunSpeed; // 368174
            yield return powerList.Generic_DHCompanionChargeAttack; // 133887
            yield return powerList.Generic_DHCompanionMeleeAttack; // 227240
            yield return powerList.Generic_DHrainofArrowsshadowBeastbombDrop; // 150075
            yield return powerList.Generic_DiabloCharge; // 195816
            yield return powerList.Generic_DiabloClawRip; // 136189
            yield return powerList.Generic_DiabloClawRipUber; // 375905
            yield return powerList.Generic_DiabloCorruptionShield; // 161174
            yield return powerList.Generic_DiabloCurseOfAnguish; // 136828
            yield return powerList.Generic_DiabloCurseOfDestruction; // 136831
            yield return powerList.Generic_DiabloCurseOfHate; // 136830
            yield return powerList.Generic_DiabloCurseOfPain; // 136829
            yield return powerList.Generic_DiabloExpandingFireRing; // 185997
            yield return powerList.Generic_DiabloExpandingFireRingUber; // 375908
            yield return powerList.Generic_DiabloFireMeteor; // 214831
            yield return powerList.Generic_DiabloGetHit; // 214668
            yield return powerList.Generic_DiabloHellSpikes; // 136226
            yield return powerList.Generic_DiabloLightningBreath; // 136219
            yield return powerList.Generic_DiabloLightningBreathLRTerrorDemon; // 428985
            yield return powerList.Generic_DiabloLightningBreathLRTerrorDemonClone; // 439719
            yield return powerList.Generic_DiabloLightningBreathUber; // 375904
            yield return powerList.Generic_DiabloLightningBreathv2; // 167560
            yield return powerList.Generic_DiabloPhase1Buff; // 141865
            yield return powerList.Generic_DiabloPhase2Buff; // 136850
            yield return powerList.Generic_DiabloPhase3Buff; // 136852
            yield return powerList.Generic_DiabloRingOfFire; // 136223
            yield return powerList.Generic_DiabloRingOfFireUber; // 375907
            yield return powerList.Generic_DiabloShadowClones; // 136281
            yield return powerList.Generic_DiabloShadowVanish; // 136237
            yield return powerList.Generic_DiabloShadowVanishCharge; // 142582
            yield return powerList.Generic_DiabloShadowVanishGrab; // 136849
            yield return powerList.Generic_DiabloSmashPunyDestructible; // 169212
            yield return powerList.Generic_DiabloStompAndStun; // 199476
            yield return powerList.Generic_DiabloTeleport; // 219598
            yield return powerList.Generic_DisableGetHitBuffInfinite; // 360319
            yield return powerList.Generic_DisablePowerBuffInfinite; // 340708
            yield return powerList.Generic_DOTDebuff; // 95701
            yield return powerList.Generic_DrinkHealthPotion; // 30211
            yield return powerList.Generic_DualWieldBuff; // 193438
            yield return powerList.Generic_DualWieldScripted; // 335158
            yield return powerList.Generic_DualWieldScriptedRemove; // 335253
            yield return powerList.Generic_DuelBuff; // 270058
            yield return powerList.Generic_DuelDefeatBuff; // 275135
            yield return powerList.Generic_EasterEggWorldBuff; // 434761
            yield return powerList.Generic_EatCorpse; // 30214
            yield return powerList.Generic_ElectricEelElectricBurst; // 57932
            yield return powerList.Generic_ElectricEelLeapOut; // 59836
            yield return powerList.Generic_EmoteAttack; // 188254
            yield return powerList.Generic_EmoteBye; // 185085
            yield return powerList.Generic_EmoteDance; // 384214
            yield return powerList.Generic_EmoteDie; // 185087
            yield return powerList.Generic_EmoteFollow; // 185042
            yield return powerList.Generic_EmoteGive; // 185081
            yield return powerList.Generic_EmoteGo; // 185629
            yield return powerList.Generic_EmoteHelp; // 185093
            yield return powerList.Generic_EmoteHold; // 188256
            yield return powerList.Generic_EmoteLaugh; // 188258
            yield return powerList.Generic_EmoteNo; // 188252
            yield return powerList.Generic_EmoteRetreat; // 188255
            yield return powerList.Generic_EmoteRun; // 185598
            yield return powerList.Generic_EmoteSorry; // 185083
            yield return powerList.Generic_EmoteStay; // 188253
            yield return powerList.Generic_EmoteTakeObjective; // 188257
            yield return powerList.Generic_EmoteThanks; // 185082
            yield return powerList.Generic_EmoteWait; // 185600
            yield return powerList.Generic_EmoteYes; // 188251
            yield return powerList.Generic_EnchantressCharm; // 102057
            yield return powerList.Generic_EnchantressCripple; // 84469
            yield return powerList.Generic_EnchantressDisorient; // 101990
            yield return powerList.Generic_EnchantressFocusedMind; // 101425
            yield return powerList.Generic_EnchantressForcefulPush; // 101969
            yield return powerList.Generic_EnchantressMassCharm; // 201524
            yield return powerList.Generic_EnchantressMeleeInstant; // 230238
            yield return powerList.Generic_EnchantressMissileWard; // 257687
            yield return powerList.Generic_EnchantressPoweredArmor; // 101461
            yield return powerList.Generic_EnchantressRunAway; // 186200
            yield return powerList.Generic_EnchantressScorchedEarth; // 220872
            yield return powerList.Generic_EnterRecallPortal; // 201538
            yield return powerList.Generic_EnterStoneOfRecall; // 200036
            yield return powerList.Generic_EnvironmentKillBuffResourceRegen; // 391680
            yield return powerList.Generic_EquippedLegendaryPower; // 434427
            yield return powerList.Generic_EscortingBuff; // 86241
            yield return powerList.Generic_ExitRecallPortal; // 201570
            yield return powerList.Generic_ExitStoneOfRecall; // 200039
            yield return powerList.Generic_FallenChampionLeaderShout; // 30222
            yield return powerList.Generic_FallenChampionPowerHit; // 1740
            yield return powerList.Generic_FallenGruntShout; // 30223
            yield return powerList.Generic_FallenLunaticAggroA; // 158955
            yield return powerList.Generic_FallenLunaticAggroB; // 330501
            yield return powerList.Generic_FallenLunaticAggroC; // 330800
            yield return powerList.Generic_FallenLunaticAggroD; // 330802
            yield return powerList.Generic_FallenLunaticSuicide; // 66547
            yield return powerList.Generic_FallenLunaticSuicideRingSummon; // 433469
            yield return powerList.Generic_FallenShamanProjectile; // 30225
            yield return powerList.Generic_FallenShamanProjectileLR; // 364817
            yield return powerList.Generic_FallingSwordCheckPathPassability; // 329401
            yield return powerList.Generic_FastMummyDiseaseCloud; // 30227
            yield return powerList.Generic_FrenzyAffix; // 123843
            yield return powerList.Generic_GenericArrowProjectile; // 30242
            yield return powerList.Generic_GenericSetCannotBeAddedToAITargetList; // 129386
            yield return powerList.Generic_GenericSetDoesFakeDamage; // 129395
            yield return powerList.Generic_GenericSetInvisible; // 76107
            yield return powerList.Generic_GenericSetInvulnerable; // 62731
            yield return powerList.Generic_GenericSetObserver; // 129393
            yield return powerList.Generic_GenericSetTakesNoDamage; // 129394
            yield return powerList.Generic_GenericSetUntargetable; // 62666
            yield return powerList.Generic_GenericTaunt; // 60777
            yield return powerList.Generic_GhostAUniqueHouse1000UndeadSlow; // 94972
            yield return powerList.Generic_GhostMeleeDrain; // 30243
            yield return powerList.Generic_GhostSoulSiphon; // 30244
            yield return powerList.Generic_GhostWalkThroughWalls; // 99094
            yield return powerList.Generic_Gizmoa3dunrmptOilVatAAttack; // 129689
            yield return powerList.Generic_GizmoOperatePortalWithAnimation; // 30249
            yield return powerList.Generic_gkillElitePack; // 230745
            yield return powerList.Generic_glevelUp; // 85954
            yield return powerList.Generic_glevelUpAA; // 252038
            yield return powerList.Generic_GluttonyBreathAttack; // 93838
            yield return powerList.Generic_GluttonyGasCloud; // 93676
            yield return powerList.Generic_GluttonyGasCloudLRBoss; // 369667
            yield return powerList.Generic_GluttonyLoogiespawn; // 211292
            yield return powerList.Generic_GluttonyOnDeath; // 98587
            yield return powerList.Generic_GoatmanColdShield; // 123158
            yield return powerList.Generic_GoatmanDrumsBeating; // 97497
            yield return powerList.Generic_GoatmanIceball; // 99077
            yield return powerList.Generic_GoatmanLightningShield; // 30251
            yield return powerList.Generic_GoatmanMoonclanRangedProjectile; // 30252
            yield return powerList.Generic_GoatmanShamanEmpower; // 168554
            yield return powerList.Generic_GoatmanShamanLightningbolt; // 77342
            yield return powerList.Generic_GoatMutantEnrage; // 131588
            yield return powerList.Generic_GoatMutantGroundSmash; // 131699
            yield return powerList.Generic_GoatMutantRangedProjectile; // 159004
            yield return powerList.Generic_GoatMutantShamanBlast; // 157947
            yield return powerList.Generic_GoblinAffixTeleporter; // 413313
            yield return powerList.Generic_gparagonBuff; // 286747
            yield return powerList.Generic_GraveDiggerKnockbackAttack; // 30255
            yield return powerList.Generic_graveDiggerwardenrangedAttack; // 113817
            yield return powerList.Generic_GraveRobberDodgeLeft; // 30256
            yield return powerList.Generic_GraveRobberDodgeRight; // 30257
            yield return powerList.Generic_graveRobberProjectile; // 30258
            yield return powerList.Generic_GreedStompAndStun; // 408505
            yield return powerList.Generic_HealingWellHeal; // 30264
            yield return powerList.Generic_Hearth; // 30265
            yield return powerList.Generic_HearthFinish; // 30266
            yield return powerList.Generic_HellPortalSummoningMachineActivate; // 118226
            yield return powerList.Generic_HelperArcherProjectile; // 73289
            yield return powerList.Generic_HirelingCalloutBattleCry; // 87093
            yield return powerList.Generic_HirelingCalloutBattleFinished; // 117323
            yield return powerList.Generic_HirelingDismiss; // 196142
            yield return powerList.Generic_HirelingDismissBuff; // 196103
            yield return powerList.Generic_HirelingDismissBuffRemove; // 196251
            yield return powerList.Generic_HirelingMageMagicMissile; // 30273
            yield return powerList.Generic_HoodedNightmareBoneArmor; // 135701
            yield return powerList.Generic_HoodedNightmareCurses; // 136071
            yield return powerList.Generic_HoodedNightmareGatewayToHell; // 136072
            yield return powerList.Generic_HoodedNightmareLightningOfUnlife; // 135412
            yield return powerList.Generic_IdentifyAllWithCast; // 293981
            yield return powerList.Generic_IdentifyWithCast; // 226757
            yield return powerList.Generic_IdentifyWithCastLegendary; // 259848
            yield return powerList.Generic_IGRBuffEXP; // 238686
            yield return powerList.Generic_ImmuneToFearDuringBuff; // 30283
            yield return powerList.Generic_ImmuneToRootDuringBuff; // 30284
            yield return powerList.Generic_ImmuneToSnareDuringBuff; // 30285
            yield return powerList.Generic_ImmuneToStunDuringBuff; // 30286
            yield return powerList.Generic_InteractCrouching; // 30287
            yield return powerList.Generic_InteractNormal; // 30288
            yield return powerList.Generic_InvisibileDuringBuff; // 30289
            yield return powerList.Generic_InvulnerableDuringBuff; // 30290
            yield return powerList.Generic_IzualCharge; // 241651
            yield return powerList.Generic_IzualFrostNova; // 162329
            yield return powerList.Generic_IzualFrozenCast; // 241653
            yield return powerList.Generic_KillActor; // 445899
            yield return powerList.Generic_Knockback; // 70432
            yield return powerList.Generic_KnockbackNoLandingAnim; // 356848
            yield return powerList.Generic_KnockbackOverObstacles; // 85936
            yield return powerList.Generic_KnockbackThroughOwnedByTeam; // 329195
            yield return powerList.Generic_Knockdown; // 30296
            yield return powerList.Generic_LacuniBurrowIn; // 30297
            yield return powerList.Generic_LacuniBurrowOut; // 30298
            yield return powerList.Generic_LacuniCombo; // 1744
            yield return powerList.Generic_LacuniLeap; // 30300
            yield return powerList.Generic_LacuniLob; // 30301
            yield return powerList.Generic_LacuniMaleDoubleSwing; // 30299
            yield return powerList.Generic_Laugh; // 30307
            yield return powerList.Generic_LaughSkeletonKing; // 84699
            yield return powerList.Generic_LeahHulkOut; // 190230
            yield return powerList.Generic_LeahVortex; // 93831
            yield return powerList.Generic_LeahVortexAgain; // 208501
            yield return powerList.Generic_LRBossCollapseCeiling; // 366477
            yield return powerList.Generic_LRBossFast; // 366481
            yield return powerList.Generic_LRBossIzualCharge; // 366830
            yield return powerList.Generic_LRBossPathBlockedTeleport; // 366204
            yield return powerList.Generic_LRBossSprint; // 366527
            yield return powerList.Generic_MaghdaMark; // 131741
            yield return powerList.Generic_MaghdaMothDust; // 131745
            yield return powerList.Generic_MaghdaPortalCreateCinematic; // 184598
            yield return powerList.Generic_MaghdaProjectile; // 30568
            yield return powerList.Generic_MaghdaPunish; // 131746
            yield return powerList.Generic_MaghdaPunishCinematic; // 178279
            yield return powerList.Generic_MaghdaSummonBeserker; // 131744
            yield return powerList.Generic_MaghdaTeleport; // 131749
            yield return powerList.Generic_MagicPaintingSummonSkeleton; // 30313
            yield return powerList.Generic_MalletDemonPowerHit; // 123381
            yield return powerList.Generic_ManualWalk; // 229128
            yield return powerList.Generic_MastaBlastaCombinedDismountRider; // 145022
            yield return powerList.Generic_MastaBlastaCombinedLobbedShot; // 143940
            yield return powerList.Generic_MastaBlastaRiderAlphaStrike; // 140857
            yield return powerList.Generic_MastaBlastaRiderCombine; // 143991
            yield return powerList.Generic_MastaBlastaRiderLeap; // 140856
            yield return powerList.Generic_MastaBlastaRiderLobbedShot; // 139356
            yield return powerList.Generic_MastaBlastaRiderLobbedShotLR; // 445562
            yield return powerList.Generic_MastaBlastaSteedCombine; // 144289
            yield return powerList.Generic_MastaBlastaSteedDrainAttack; // 141333
            yield return powerList.Generic_MastaBlastaSteedStomp; // 140859
            yield return powerList.Generic_MistressOfPainAscend; // 212136
            yield return powerList.Generic_MistressOfPainDescend; // 212237
            yield return powerList.Generic_MistressOfPainPainBolts; // 136790
            yield return powerList.Generic_MistressOfPainPainBoltsLR; // 369693
            yield return powerList.Generic_MistressOfPainSpiderlingExplode; // 137143
            yield return powerList.Generic_MistressOfPainSummonSpiders; // 136958
            yield return powerList.Generic_MistressOfPainSummonSpidersAirborne; // 212239
            yield return powerList.Generic_MistressOfPainTeleportToThrone; // 137483
            yield return powerList.Generic_MistressOfPainWebPatch; // 136722
            yield return powerList.Generic_MonsterAffixArcaneEnchanted; // 214594
            yield return powerList.Generic_MonsterAffixArcaneEnchantedCast; // 214791
            yield return powerList.Generic_MonsterAffixArcaneEnchantedCastNoTarget; // 450358
            yield return powerList.Generic_MonsterAffixArcaneEnchantedChampion; // 221130
            yield return powerList.Generic_MonsterAffixArcaneEnchantedMinion; // 221219
            yield return powerList.Generic_MonsterAffixArcaneEnchantedNewPetBasic; // 219671
            yield return powerList.Generic_MonsterAffixAvengerArcaneEnchanted; // 384426
            yield return powerList.Generic_MonsterAffixAvengerArcaneEnchantedCast; // 384436
            yield return powerList.Generic_MonsterAffixAvengerArcaneEnchantedNewPetBasic; // 392128
            yield return powerList.Generic_MonsterAffixAvengerBuff; // 226292
            yield return powerList.Generic_MonsterAffixAvengerChampion; // 226289
            yield return powerList.Generic_MonsterAffixAvengerMortar; // 384594
            yield return powerList.Generic_MonsterAffixAvengerMortarCast; // 384596
            yield return powerList.Generic_MonsterAffixBallista; // 91098
            yield return powerList.Generic_MonsterAffixChampionBuff; // 210333
            yield return powerList.Generic_MonsterAffixDesecrator; // 70874
            yield return powerList.Generic_MonsterAffixDesecratorBuff; // 156106
            yield return powerList.Generic_MonsterAffixDesecratorBuffChampion; // 221131
            yield return powerList.Generic_MonsterAffixDesecratorCast; // 156105
            yield return powerList.Generic_MonsterAffixDieTogether; // 91232
            yield return powerList.Generic_MonsterAffixElectrified; // 81420
            yield return powerList.Generic_MonsterAffixElectrifiedLRBossCustom; // 365083
            yield return powerList.Generic_MonsterAffixElectrifiedMinion; // 109899
            yield return powerList.Generic_MonsterAffixElectrifiedMinionRakEvent; // 169461
            yield return powerList.Generic_MonsterAffixExtraHealth; // 70650
            yield return powerList.Generic_MonsterAffixFast; // 70849
            yield return powerList.Generic_MonsterAffixFrozen; // 90144
            yield return powerList.Generic_MonsterAffixFrozenCast; // 231149
            yield return powerList.Generic_MonsterAffixFrozenRare; // 231157
            yield return powerList.Generic_MonsterAffixHealing; // 276798
            yield return powerList.Generic_MonsterAffixHealthlink; // 71239
            yield return powerList.Generic_MonsterAffixIllusionist; // 71108
            yield return powerList.Generic_MonsterAffixIllusionistCast; // 264185
            yield return powerList.Generic_MonsterAffixJailer; // 222743
            yield return powerList.Generic_MonsterAffixJailerCast; // 222744
            yield return powerList.Generic_MonsterAffixJailerChampion; // 222745
            yield return powerList.Generic_MonsterAffixJuggernaut; // 455436
            yield return powerList.Generic_MonsterAffixKnockback; // 70655
            yield return powerList.Generic_MonsterAffixLinked; // 226497
            yield return powerList.Generic_MonsterAffixMissileDampening; // 91028
            yield return powerList.Generic_MonsterAffixMissileDampeningCast; // 376860
            yield return powerList.Generic_MonsterAffixMolten; // 90314
            yield return powerList.Generic_MonsterAffixMoltenMinion; // 109898
            yield return powerList.Generic_MonsterAffixMortar; // 215756
            yield return powerList.Generic_MonsterAffixMortarCast; // 215757
            yield return powerList.Generic_MonsterAffixNightmarish; // 247258
            yield return powerList.Generic_MonsterAffixPheonix; // 120655
            yield return powerList.Generic_MonsterAffixPlagued; // 90566
            yield return powerList.Generic_MonsterAffixPlaguedCast; // 231115
            yield return powerList.Generic_MonsterAffixPuppetmaster; // 71023
            yield return powerList.Generic_MonsterAffixPuppetmasterMinion; // 71024
            yield return powerList.Generic_MonsterAffixReflectsDamage; // 230877
            yield return powerList.Generic_MonsterAffixReflectsDamageCast; // 285770
            yield return powerList.Generic_MonsterAffixShielding; // 226437
            yield return powerList.Generic_MonsterAffixShieldingCast; // 226438
            yield return powerList.Generic_MonsterAffixTeleporterBuff; // 155958
            yield return powerList.Generic_MonsterAffixTeleporterCast; // 155959
            yield return powerList.Generic_MonsterAffixThunderstormBuff; // 336177
            yield return powerList.Generic_MonsterAffixThunderstormBuffChampion; // 336178
            yield return powerList.Generic_MonsterAffixThunderstormCast; // 336179
            yield return powerList.Generic_MonsterAffixVampiric; // 70309
            yield return powerList.Generic_MonsterAffixVortexBuff; // 120306
            yield return powerList.Generic_MonsterAffixVortexBuffChampion; // 221132
            yield return powerList.Generic_MonsterAffixVortexCast; // 120305
            yield return powerList.Generic_MonsterAffixWaller; // 226293
            yield return powerList.Generic_MonsterAffixWallerCast; // 226294
            yield return powerList.Generic_MonsterAffixWallerRare; // 231117
            yield return powerList.Generic_MonsterAffixWallerRareCast; // 231118
            yield return powerList.Generic_MonsterPoisonMeleeAttack; // 30333
            yield return powerList.Generic_MonsterRangedProjectile; // 30334
            yield return powerList.Generic_MonsterSpellProjectile; // 30338
            yield return powerList.Generic_MorluSpellcasterBreathOfFire; // 158970
            yield return powerList.Generic_MorluSpellcasterBreathOfFrost; // 263415
            yield return powerList.Generic_MorluSpellcasterMeteor; // 158969
            yield return powerList.Generic_MorluSpellcasterMeteorGraspOfTheDeadPrototype; // 256045
            yield return powerList.Generic_MorluSpellcasterShift; // 158968
            yield return powerList.Generic_MorluSpellcasterShiftNoCooldownCold; // 428806
            yield return powerList.Generic_MultiplayerBuff; // 258199
            yield return powerList.Generic_NPCLookAt; // 30342
            yield return powerList.Generic_OasisRockslideADamage; // 395342
            yield return powerList.Generic_OnDeathArcane; // 30343
            yield return powerList.Generic_OnDeathCold; // 30344
            yield return powerList.Generic_OnDeathFire; // 30345
            yield return powerList.Generic_OnDeathLightning; // 30346
            yield return powerList.Generic_OnDeathPoison; // 30347
            yield return powerList.Generic_OperateHelperAttach; // 30348
            yield return powerList.Generic_p1GreedCharge; // 380460
            yield return powerList.Generic_p1GreedChargeLong; // 391073
            yield return powerList.Generic_p1GreedChargeNoLOS; // 398253
            yield return powerList.Generic_p1GreedGoblinKnockback; // 394194
            yield return powerList.Generic_p1GreedGoldenMeteorShower; // 385810
            yield return powerList.Generic_p1GreedGoldSpawner; // 385737
            yield return powerList.Generic_p1GreedMinionPassiveLifetimeBuff; // 382195
            yield return powerList.Generic_p1GreedPassiveGoblinSpawnertest; // 391176
            yield return powerList.Generic_p1GreedPassiveLifetimeBuff; // 381205
            yield return powerList.Generic_p1GreedShockwave; // 380646
            yield return powerList.Generic_p1GreedSpawnMinion; // 382342
            yield return powerList.Generic_p1GreedUltimateMeteorShower; // 391193
            yield return powerList.Generic_p1TieredRiftSpawnNPC; // 409173
            yield return powerList.Generic_p1TreasureGoblinOnDeathAnniversaryPortal; // 434819
            yield return powerList.Generic_p1TreasureGoblinOnDeathGreedPortal; // 382738
            yield return powerList.Generic_p1TreasureGoblinOnDeathWhimsyshirePortal; // 405592
            yield return powerList.Generic_p2FallenLunaticAggroring; // 434026
            yield return powerList.Generic_P2LegendaryPotion07; // 433021
            yield return powerList.Generic_P2SpecialGoblinRiftSpawn; // 429651
            yield return powerList.Generic_p43ADBarrelExplode; // 455182
            yield return powerList.Generic_p43ADEventAnvilOfFury; // 455050
            yield return powerList.Generic_p43ADTrapArrow; // 455198
            yield return powerList.Generic_p43d1ButcherMeleeBasic; // 455501
            yield return powerList.Generic_p43d1DiabloClawRip; // 453765
            yield return powerList.Generic_p43d1fastMummyMelee; // 453803
            yield return powerList.Generic_p43d1fastMummyStealth; // 453802
            yield return powerList.Generic_p43d1FleshPitFlyerBlink; // 453994
            yield return powerList.Generic_p43d1GorehoundAcidSpit; // 454139
            yield return powerList.Generic_p43d1MageFlash; // 454586
            yield return powerList.Generic_p43d1MageTeleport; // 454584
            yield return powerList.Generic_p43d1TerrorDemonLightningBreath; // 454163
            yield return powerList.Generic_p43d1ZoltunKulleFieryBoulder; // 453734
            yield return powerList.Generic_p43d1ZoltunKulleTeleport; // 453738
            yield return powerList.Generic_p43d1ZombieSkinnyMelee; // 454045
            yield return powerList.Generic_P4CrabMotherEnrage; // 442660
            yield return powerList.Generic_P4DemonFlyerFireBreath; // 439325
            yield return powerList.Generic_p4demonTrooperSpecialMelee; // 435046
            yield return powerList.Generic_P4ForestMysteriousHermitArcaneFireball; // 445642
            yield return powerList.Generic_P4ForestMysteriousHermitArcaneFireball_; // 445864
            yield return powerList.Generic_P4ForestMysteriousHermitArcaneFlameWall_; // 445865
            yield return powerList.Generic_p4ForestMysteriousHermitBoomerangBlade; // 445808
            yield return powerList.Generic_p4ForestMysteriousHermitProjectile; // 437112
            yield return powerList.Generic_p4ForestMysteriousHermitTeleportIllusion; // 445850
            yield return powerList.Generic_P4ForestMysteriousManSpiritForm; // 437524
            yield return powerList.Generic_P4ForestMysteriousManSpiritSetup; // 437546
            yield return powerList.Generic_p4GoatmanFireball; // 433729
            yield return powerList.Generic_p4IceGoatmanRangedChargedShot; // 437534
            yield return powerList.Generic_p4IcePorcupineBackpedalShot; // 434171
            yield return powerList.Generic_p4IcePorcupineJumpBack; // 434174
            yield return powerList.Generic_p4IcePorcupineNova; // 430206
            yield return powerList.Generic_p4IcePorcupineShot; // 434209
            yield return powerList.Generic_p4LRBossFedExCharge; // 433232
            yield return powerList.Generic_p4LRBossSpawnBoneTurrets; // 433225
            yield return powerList.Generic_p4LRTerrorDemonWall; // 429019
            yield return powerList.Generic_p4MaggotSuicideProgressiveFreeze; // 435737
            yield return powerList.Generic_P4MermaidHydra; // 442662
            yield return powerList.Generic_p4MoleRatCharge; // 423014
            yield return powerList.Generic_p4rathostteleport; // 423072
            yield return powerList.Generic_p4RatKingDoubleSwing; // 436574
            yield return powerList.Generic_p4RatKingLifetimeBuffPlagued; // 440700
            yield return powerList.Generic_p4RatKingRatBallMonsterSetup; // 427175
            yield return powerList.Generic_p4RatKingSummonRatBallMonster; // 427176
            yield return powerList.Generic_p4RatKingSummonRatVolcano; // 427244
            yield return powerList.Generic_p4RatKingThunderdome; // 427211
            yield return powerList.Generic_p4RatKingWaspRain; // 432984
            yield return powerList.Generic_p4ruinsfrostEventTheZiggurat; // 433486
            yield return powerList.Generic_P4RuinsFrostTrapSwingingBlade; // 406180
            yield return powerList.Generic_P4SacrificeMonsterBreakableNova; // 450213
            yield return powerList.Generic_P4SacrificeMonsterEnrage; // 447376
            yield return powerList.Generic_P4SandWaspProjectile; // 410520
            yield return powerList.Generic_p4SasquatchGorillaPound; // 430556
            yield return powerList.Generic_p4SasquatchRockPunchKnockback; // 415079
            yield return powerList.Generic_p4SasquatchSpikeLine; // 430582
            yield return powerList.Generic_p4SasquatchTriplePunch; // 430448
            yield return powerList.Generic_p4ScavengerSpawnerADeath; // 435467
            yield return powerList.Generic_p4ScorpionBugHoverProjectile; // 426866
            yield return powerList.Generic_p4SeaMonsterSpawnCrabs; // 431678
            yield return powerList.Generic_p4SetDungBarbKingsEnmy; // 444770
            yield return powerList.Generic_p4SetDungBarbKingsPly; // 444771
            yield return powerList.Generic_p4SetDungBarbMightEnmy; // 444922
            yield return powerList.Generic_p4SetDungBarbMightPly; // 444923
            yield return powerList.Generic_p4SetDungBarbRaekorEnmy; // 444875
            yield return powerList.Generic_p4SetDungBarbRaekorPly; // 444876
            yield return powerList.Generic_p4SetDungBarbWastesEnmy; // 444832
            yield return powerList.Generic_p4SetDungBarbWastesPly; // 444834
            yield return powerList.Generic_p4SetDungCruAkkhanEnmy; // 444632
            yield return powerList.Generic_p4SetDungCruAkkhanPly; // 444633
            yield return powerList.Generic_p4SetDungCruRolandEnmy; // 444712
            yield return powerList.Generic_p4SetDungCruRolandPly; // 444713
            yield return powerList.Generic_p4SetDungCruSeekerEnmy; // 445277
            yield return powerList.Generic_p4SetDungCruSeekerPly; // 445278
            yield return powerList.Generic_p4SetDungCruThornsEnmy; // 445257
            yield return powerList.Generic_p4SetDungCruThornsPly; // 445258
            yield return powerList.Generic_p4SetDungDeathBarbKings; // 444769
            yield return powerList.Generic_p4SetDungDeathBarbMight; // 444915
            yield return powerList.Generic_p4SetDungDeathBarbRaekor; // 444874
            yield return powerList.Generic_p4SetDungDeathBarbWastes; // 444826
            yield return powerList.Generic_p4SetDungDeathCruAkkhan; // 444631
            yield return powerList.Generic_p4SetDungDeathCruRoland; // 444710
            yield return powerList.Generic_p4SetDungDeathCruSeeker; // 445276
            yield return powerList.Generic_p4SetDungDeathCruThorns; // 445251
            yield return powerList.Generic_p4SetDungDeathDHEss; // 445035
            yield return powerList.Generic_p4SetDungDeathDHMar; // 444996
            yield return powerList.Generic_p4SetDungDeathDHNat; // 445007
            yield return powerList.Generic_p4SetDungDeathDHShadow; // 445062
            yield return powerList.Generic_p4SetDungDeathWDHaunt; // 445098
            yield return powerList.Generic_p4SetDungDeathWDJade; // 445155
            yield return powerList.Generic_p4SetDungDeathWDSpider; // 445132
            yield return powerList.Generic_p4SetDungDeathWDTooth; // 445081
            yield return powerList.Generic_p4SetDungDeathWizFirebird; // 444577
            yield return powerList.Generic_p4SetDungDeathWizOpus; // 443832
            yield return powerList.Generic_p4SetDungDeathWizRasha; // 444516
            yield return powerList.Generic_p4SetDungDeathWizVyr; // 444972
            yield return powerList.Generic_p4SetDungDHEssEnmy; // 445036
            yield return powerList.Generic_p4SetDungDHEssPly; // 445037
            yield return powerList.Generic_p4SetDungDHMarEnmy; // 444997
            yield return powerList.Generic_p4SetDungDHMarPly; // 444998
            yield return powerList.Generic_p4SetDungDHNatEnmy; // 445009
            yield return powerList.Generic_p4SetDungDHNatPly; // 445010
            yield return powerList.Generic_p4SetDungDHShadowEnmy; // 445063
            yield return powerList.Generic_p4SetDungDHShadowPly; // 445064
            yield return powerList.Generic_p4SetDungGenericsEnmy; // 443795
            yield return powerList.Generic_p4SetDungGenericsPly; // 443833
            yield return powerList.Generic_p4SetDungGenericsPlyBalance; // 450351
            yield return powerList.Generic_p4SetDungGenericsPortal; // 450469
            yield return powerList.Generic_p4SetDungMonsterAffixMortarCast; // 447584
            yield return powerList.Generic_p4SetDungPedestalBarbKings; // 447950
            yield return powerList.Generic_p4SetDungPedestalBarbMight; // 447975
            yield return powerList.Generic_p4SetDungPedestalBarbRaekor; // 447976
            yield return powerList.Generic_p4SetDungPedestalBarbWastes; // 447977
            yield return powerList.Generic_p4SetDungPedestalCruAkkhan; // 447978
            yield return powerList.Generic_p4SetDungPedestalCruRoland; // 447979
            yield return powerList.Generic_p4SetDungPedestalCruSeeker; // 447980
            yield return powerList.Generic_p4SetDungPedestalCruThorns; // 447981
            yield return powerList.Generic_p4SetDungPedestalDHEss; // 447982
            yield return powerList.Generic_p4SetDungPedestalDHMar; // 447984
            yield return powerList.Generic_p4SetDungPedestalDHNat; // 447983
            yield return powerList.Generic_p4SetDungPedestalDHShadow; // 447985
            yield return powerList.Generic_p4SetDungPedestalWDHaunt; // 447990
            yield return powerList.Generic_p4SetDungPedestalWDJade; // 447991
            yield return powerList.Generic_p4SetDungPedestalWDSpider; // 447992
            yield return powerList.Generic_p4SetDungPedestalWDTooth; // 447993
            yield return powerList.Generic_p4SetDungPedestalWizFirebird; // 447995
            yield return powerList.Generic_p4SetDungPedestalWizOpus; // 447996
            yield return powerList.Generic_p4SetDungPedestalWizRasha; // 447997
            yield return powerList.Generic_p4SetDungPedestalWizVyr; // 447998
            yield return powerList.Generic_p4SetDungPortalChecks; // 447038
            yield return powerList.Generic_p4SetDungWDHauntEnmy; // 445099
            yield return powerList.Generic_p4SetDungWDHauntPly; // 445100
            yield return powerList.Generic_p4SetDungWDJadeEnmy; // 445156
            yield return powerList.Generic_p4SetDungWDJadePly; // 445157
            yield return powerList.Generic_p4SetDungWDSpiderEnmy; // 445133
            yield return powerList.Generic_p4SetDungWDSpiderPly; // 445134
            yield return powerList.Generic_p4SetDungWDToothEnmy; // 445082
            yield return powerList.Generic_p4SetDungWDToothPly; // 445083
            yield return powerList.Generic_p4SetDungWestmarchBruteCharge; // 451207
            yield return powerList.Generic_p4SetDungWizFirebirdEnmy; // 445771
            yield return powerList.Generic_p4SetDungWizFirebirdPly; // 445772
            yield return powerList.Generic_p4SetDungWizOpusEnmy; // 444008
            yield return powerList.Generic_p4SetDungWizOpusPly; // 443898
            yield return powerList.Generic_p4SetDungWizRashaEnmy; // 444519
            yield return powerList.Generic_p4SetDungWizRashaPly; // 444520
            yield return powerList.Generic_p4SetDungWizVyrEnmy; // 444975
            yield return powerList.Generic_p4SetDungWizVyrPly; // 444976
            yield return powerList.Generic_P4ShrineDebuffDamage; // 445778
            yield return powerList.Generic_P4ShrineDebuffSpawner; // 445788
            yield return powerList.Generic_p4SkeletonZombieSpawnerADeath; // 433150
            yield return powerList.Generic_P4SpiderBombAODDamage; // 274506
            yield return powerList.Generic_P4SpiderBombBurrowIn; // 275328
            yield return powerList.Generic_p4WaspNestDeath; // 410598
            yield return powerList.Generic_p4WickermanSpawnerADeath; // 435834
            yield return powerList.Generic_P4WoodWraithSummonSporesCeremonyEvent; // 435833
            yield return powerList.Generic_p4WoodWraithVineTrap; // 430133
            yield return powerList.Generic_p4YetiIceBreath; // 411373
            yield return powerList.Generic_p4YetiIceSpikes; // 413296
            yield return powerList.Generic_p4YetiMeleeBasic; // 437834
            yield return powerList.Generic_p4YetiOverheadSmash; // 440693
            yield return powerList.Generic_p4YetiSnowBoulderRoll; // 429905
            yield return powerList.Generic_PagesBuffDamage; // 262935
            yield return powerList.Generic_PagesBuffElectrified; // 263029
            yield return powerList.Generic_PagesBuffElectrifiedCast; // 340227
            yield return powerList.Generic_PagesBuffElectrifiedCastTieredRift; // 398655
            yield return powerList.Generic_PagesBuffElectrifiedTieredRift; // 403404
            yield return powerList.Generic_PagesBuffInfiniteCasting; // 266258
            yield return powerList.Generic_PagesBuffInvulnerable; // 266254
            yield return powerList.Generic_PagesBuffInvulnerableCastv2; // 428595
            yield return powerList.Generic_PagesBuffRunSpeed; // 266271
            yield return powerList.Generic_PagesBuffRunSpeedKnockbackCast; // 428605
            yield return powerList.Generic_PagesBuffRunSpeedWallerCast; // 428607
            yield return powerList.Generic_PandemoniumPortal; // 257036
            yield return powerList.Generic_PandemoniumPortalDiablo; // 366954
            yield return powerList.Generic_PandemoniumPortalghom; // 366951
            yield return powerList.Generic_PandemoniumPortalSiegeBreaker; // 366953
            yield return powerList.Generic_PandemoniumPortalSkeletonKing; // 366950
            yield return powerList.Generic_PickupNearby; // 131976
            yield return powerList.Generic_PlagueOfToadsKnockback; // 147876
            yield return powerList.Generic_PlayerUpscaledBuff; // 375617
            yield return powerList.Generic_ProxyDelayedPower; // 30385
            yield return powerList.Generic_Punch; // 30391
            yield return powerList.Generic_PVPBuff; // 97359
            yield return powerList.Generic_PVPcontrolpoint; // 265723
            yield return powerList.Generic_PvPDamageBuff; // 202701
            yield return powerList.Generic_PvPDeathstreakBuff; // 203535
            yield return powerList.Generic_PvPHealingMacguffin; // 222243
            yield return powerList.Generic_PVPhill; // 267462
            yield return powerList.Generic_PvPHunterBuff; // 404985
            yield return powerList.Generic_PvPLevelEqualizerBuff; // 234527
            yield return powerList.Generic_PVPPeanutNeutralObjective; // 276837
            yield return powerList.Generic_PvPRangedProjectile; // 1749
            yield return powerList.Generic_PVPRoundEndBuff; // 170408
            yield return powerList.Generic_PVPShrineMurderball; // 275730
            yield return powerList.Generic_PVPSkirmishBuff; // 96719
            yield return powerList.Generic_PVPspawnersetup; // 268588
            yield return powerList.Generic_PVPspawnerTowerDefenders; // 272501
            yield return powerList.Generic_PVPStationaryattack; // 274304
            yield return powerList.Generic_PVPThreeControlSpawnDefenders; // 276805
            yield return powerList.Generic_pxBoneyardsCampSnakemanSpawner; // 432968
            yield return powerList.Generic_pxbountytestchaosportalssummonChampion; // 430626
            yield return powerList.Generic_pxBridgeCampDemonSpawner; // 433224
            yield return powerList.Generic_pxCampPortalSpawner; // 434337
            yield return powerList.Generic_pxCraterCampDemonSpawner; // 433300
            yield return powerList.Generic_pxFesteringWoodsCampGhoulSpawner; // 432385
            yield return powerList.Generic_pxGardensOfHopeCampDemonSpawner; // 433137
            yield return powerList.Generic_pxGraveyardCampReaperSpawner; // 433338
            yield return powerList.Generic_pxHighlandsCampCultistSpawner; // 432262
            yield return powerList.Generic_pxLeoricsDungeonCampDemonSpawner; // 434382
            yield return powerList.Generic_pxOasisCampSnakemanSpawner; // 432336
            yield return powerList.Generic_pxQuestFollowerDamageSetup; // 432327
            yield return powerList.Generic_pxRampartsCampDemonSpawner; // 433391
            yield return powerList.Generic_pxRuinsFrostKingKanaiWhirlwind; // 436329
            yield return powerList.Generic_pxRuinsFrostThreeGuardiansGoatmanLeap; // 434813
            yield return powerList.Generic_pxSpiderCavesCampCocoonHumanVictim; // 432781
            yield return powerList.Generic_pxSpiderCavesCampSpiderSpawner; // 432782
            yield return powerList.Generic_pxSpireCampDemonSpawner; // 433421
            yield return powerList.Generic_pxStingingWindsCampCultistSpawner; // 433057
            yield return powerList.Generic_pxWestmarchCampReaperSpawner; // 433254
            yield return powerList.Generic_pxWildernessCampTemplarSpawner; // 430766
            yield return powerList.Generic_QuestCanyonBridgeEnchantressRevealFootsteps; // 103338
            yield return powerList.Generic_QuestCanyonBridgePlayerRevealFootsteps; // 103337
            yield return powerList.Generic_QuillDemonProjectile; // 107729
            yield return powerList.Generic_QuillDemonProjectileFastAttack; // 364571
            yield return powerList.Generic_RakCenterStoneelectrifiedMinion; // 169411
            yield return powerList.Generic_RandomMovespeedScripted; // 367779
            yield return powerList.Generic_RangedEscortProjectile; // 30394
            yield return powerList.Generic_RatKingLifetimeBuff; // 440699
            yield return powerList.Generic_RedWingsBuff; // 317139
            yield return powerList.Generic_RemoveBurrowEffect; // 30420
            yield return powerList.Generic_ResurrectFallen; // 30422
            yield return powerList.Generic_ResurrectionBuff; // 30424
            yield return powerList.Generic_RockwormAttack; // 30426
            yield return powerList.Generic_RockwormBurrowAndTeleport; // 330606
            yield return powerList.Generic_RockwormBurstOut; // 30427
            yield return powerList.Generic_RockwormGrab; // 219076
            yield return powerList.Generic_RockwormGrabBurstOut; // 230406
            yield return powerList.Generic_RockwormHideIdle; // 30428
            yield return powerList.Generic_RockwormPreBurst; // 30429
            yield return powerList.Generic_RockwormRetreat; // 30430
            yield return powerList.Generic_RockwormWeb; // 30431
            yield return powerList.Generic_RootTryGrab; // 30433
            yield return powerList.Generic_SandMonsterBurrowOut; // 213730
            yield return powerList.Generic_SandMonsterBurrowOutLong; // 59308
            yield return powerList.Generic_SandMonsterSandWall; // 30438
            yield return powerList.Generic_SandmonsterWeaponMeleeInstant; // 223914
            yield return powerList.Generic_SandsharkBurrowIn; // 30440
            yield return powerList.Generic_SandsharkBurrowOut; // 30441
            yield return powerList.Generic_SandTornadoOnSpawn; // 30448
            yield return powerList.Generic_SandWaspProjectile; // 30449
            yield return powerList.Generic_ScavengerBurrowIn; // 30450
            yield return powerList.Generic_ScavengerBurrowOut; // 30451
            yield return powerList.Generic_ScavengerLeap; // 1752
            yield return powerList.Generic_ScoundrelAnatomy; // 30454
            yield return powerList.Generic_ScoundrelBandage; // 30455
            yield return powerList.Generic_ScoundrelCripplingShot; // 95675
            yield return powerList.Generic_ScoundrelDirtyFighting; // 97436
            yield return powerList.Generic_ScoundrelHysteria; // 200169
            yield return powerList.Generic_ScoundrelPoisonArrow; // 30460
            yield return powerList.Generic_ScoundrelPowerShot; // 95690
            yield return powerList.Generic_ScoundrelRangedProjectile; // 99902
            yield return powerList.Generic_ScoundrelRunAway; // 99904
            yield return powerList.Generic_ScoundrelVanish; // 30464
            yield return powerList.Generic_ScrollBuff; // 30469
            yield return powerList.Generic_SelectingSkill; // 217340
            yield return powerList.Generic_SetItemBonusBuff; // 123014
            yield return powerList.Generic_SetModeEscortFollow; // 30471
            yield return powerList.Generic_ShieldSkeletonShield; // 30473
            yield return powerList.Generic_ShrineCallMonster; // 213187
            yield return powerList.Generic_ShrineDesecratedBlessed; // 30476
            yield return powerList.Generic_ShrineDesecratedEnlightened; // 30477
            yield return powerList.Generic_ShrineDesecratedFortune; // 30478
            yield return powerList.Generic_ShrineDesecratedFrenzied; // 30479
            yield return powerList.Generic_ShrineDesecratedHoarder; // 260348
            yield return powerList.Generic_ShrineDesecratedReloaded; // 260349
            yield return powerList.Generic_ShrineDesecratedtreasureGoblin; // 269350
            yield return powerList.Generic_ShrinePowerBlessed; // 278268
            yield return powerList.Generic_ShrinePowerEnlightened; // 278269
            yield return powerList.Generic_ShrinePowerFortune; // 278270
            yield return powerList.Generic_ShrinePowerFrenzied; // 278271
            yield return powerList.Generic_SidekickStatsBoostBuff; // 377314
            yield return powerList.Generic_SidekickWeaponDamageBoostBuff; // 377413
            yield return powerList.Generic_SiegebreakerDemonBite; // 30482
            yield return powerList.Generic_SiegebreakerDemonCharge; // 30484
            yield return powerList.Generic_SiegebreakerDemonChargeNew; // 182586
            yield return powerList.Generic_SiegebreakerDemonGrab; // 30487
            yield return powerList.Generic_SiegebreakerDemonGrabToBite; // 30488
            yield return powerList.Generic_SiegebreakerDemonLookAround; // 1754
            yield return powerList.Generic_SiegebreakerDemonMiniCharge; // 30490
            yield return powerList.Generic_SiegebreakerDemonPound; // 30491
            yield return powerList.Generic_SiegebreakerDemonRoar; // 228688
            yield return powerList.Generic_SiegebreakerDemonStomp; // 30492
            yield return powerList.Generic_SiegebreakerEnrage; // 240529
            yield return powerList.Generic_SiegeBreakerReflectsDamageCast; // 376912
            yield return powerList.Generic_SkeletonArcherProjectile; // 30495
            yield return powerList.Generic_SkeletonKingCleave; // 30504
            yield return powerList.Generic_SkeletonKingSummonSkeleton; // 30496
            yield return powerList.Generic_SkeletonKingTeleport; // 79334
            yield return powerList.Generic_SkeletonKingTeleportAway; // 81504
            yield return powerList.Generic_SkeletonKingWhirlwind; // 73824
            yield return powerList.Generic_skeletonMageColdprojectile; // 30497
            yield return powerList.Generic_skeletonMageFireAOE; // 30498
            yield return powerList.Generic_skeletonMageFireprojectile; // 30499
            yield return powerList.Generic_skeletonMageLightningpierce; // 30500
            yield return powerList.Generic_skeletonMagepoisondeath; // 30501
            yield return powerList.Generic_skeletonMagePoisonpierce; // 30502
            yield return powerList.Generic_SkeletonSummonerProjectile; // 30503
            yield return powerList.Generic_SkillOverrideStartedOrEnded; // 221275
            yield return powerList.Generic_SnakemanCasterElectricBurst; // 30509
            yield return powerList.Generic_SnakemanMeleeStealth; // 30512
            yield return powerList.Generic_SnakemanMeleeUnstealth; // 30513
            yield return powerList.Generic_SoaringAscend; // 69743
            yield return powerList.Generic_SoaringDescend; // 54196
            yield return powerList.Generic_SoulRipperDespairTongueLash; // 226572
            yield return powerList.Generic_SoulRipperTongueLash; // 145822
            yield return powerList.Generic_SpiderQueenVomitSpidersCharge; // 151219
            yield return powerList.Generic_SpiderQueenVomitSpidersVomit; // 151516
            yield return powerList.Generic_SpiderQueenWebSpit; // 151218
            yield return powerList.Generic_SpiderSprintThroughObjectsTo; // 137642
            yield return powerList.Generic_SpiderWebImmobolize; // 30518
            yield return powerList.Generic_SpiderWebSlow; // 76961
            yield return powerList.Generic_SpiderWebSlowSpit; // 76951
            yield return powerList.Generic_SplashDamageProc; // 376298
            yield return powerList.Generic_SporeCloud; // 30525
            yield return powerList.Generic_StealthBuff; // 30527
            yield return powerList.Generic_StitchExplode; // 30529
            yield return powerList.Generic_StitchMeleeAlternate; // 30530
            yield return powerList.Generic_StitchPush; // 30531
            yield return powerList.Generic_SuccubusBloodStar; // 120874
            yield return powerList.Generic_SuccubusBloodStarLR; // 366103
            yield return powerList.Generic_SuccubusFly; // 136508
            yield return powerList.Generic_SuccubusLeap; // 120875
            yield return powerList.Generic_SuicideProc; // 30538
            yield return powerList.Generic_SuicideScripted; // 369834
            yield return powerList.Generic_Summoned; // 30540
            yield return powerList.Generic_SummonFallenAUnique01; // 166154
            yield return powerList.Generic_SummonFallenOnSpawn; // 30541
            yield return powerList.Generic_SummoningMachineSummon; // 117580
            yield return powerList.Generic_SummonSkeleton; // 30543
            yield return powerList.Generic_SummonSkeletonJondar; // 168212
            yield return powerList.Generic_SummonSkeletonOnSpawn; // 30545
            yield return powerList.Generic_SummonSkeletonOrb; // 30546
            yield return powerList.Generic_SummonSkeletonPillar; // 1757
            yield return powerList.Generic_SummonTriuneDemon; // 30547
            yield return powerList.Generic_SummonZombieCrawler; // 30550
            yield return powerList.Generic_SummonZombieVomit; // 94734
            yield return powerList.Generic_Swarmdeath; // 128729
            yield return powerList.Generic_TarPitSlowOff; // 67110
            yield return powerList.Generic_TarPitSlowOn; // 67106
            yield return powerList.Generic_TauntedMonsterRangedProjectile; // 212952
            yield return powerList.Generic_TauntedWeaponMeleeInstant; // 212953
            yield return powerList.Generic_TeleportCheckPathPassability; // 290885
            yield return powerList.Generic_TeleportToPlayer; // 318242
            yield return powerList.Generic_TeleportToPlayerCast; // 371139
            yield return powerList.Generic_TeleportToWaypoint; // 349060
            yield return powerList.Generic_TeleportToWaypointCast; // 371141
            yield return powerList.Generic_TemplarGuardian; // 30359
            yield return powerList.Generic_TemplarHeal110; // 257640
            yield return powerList.Generic_TemplarInspire; // 30356
            yield return powerList.Generic_TemplarIntervene; // 93938
            yield return powerList.Generic_TemplarInterveneProc; // 94008
            yield return powerList.Generic_TemplarIntimidate; // 93901
            yield return powerList.Generic_TemplarLoyalty; // 30357
            yield return powerList.Generic_TemplarMeleeInstant; // 230239
            yield return powerList.Generic_TemplarOnslaught; // 93888
            yield return powerList.Generic_TemplarShieldCharge; // 30360
            yield return powerList.Generic_TentacleHorseAUnique01Charge; // 209509
            yield return powerList.Generic_TerrorDemonMeleeStrike; // 123907
            yield return powerList.Generic_TerrorDemonShadowPhase; // 123935
            yield return powerList.Generic_TerrorDemonShadowPhaseEnd; // 123964
            yield return powerList.Generic_TestSpikeTrapRuins; // 409416
            yield return powerList.Generic_Thorns; // 30554
            yield return powerList.Generic_ThousandPounderKnockback; // 30557
            yield return powerList.Generic_ThousandPounderMelee; // 439350
            yield return powerList.Generic_tongueprototype; // 86990
            yield return powerList.Generic_TransformToActivatedTriune; // 30563
            yield return powerList.Generic_trDunCathWallCollapseDamage; // 186216
            yield return powerList.Generic_trDunCathWallCollapseDamageoffset; // 227949
            yield return powerList.Generic_TreasureGoblinAnniversaryEscape; // 434749
            yield return powerList.Generic_TreasureGoblinAnniversaryThrowPortal; // 434776
            yield return powerList.Generic_TreasureGoblinEscape; // 105371
            yield return powerList.Generic_TreasureGoblinPause; // 54055
            yield return powerList.Generic_TreasureGoblinPlayAlertSound; // 260595
            yield return powerList.Generic_TreasureGoblinPortalIn; // 408659
            yield return powerList.Generic_TreasureGoblinThrowPortal; // 54836
            yield return powerList.Generic_TreasureGoblinThrowPortalBackup; // 432643
            yield return powerList.Generic_TreasureGoblinThrowPortalFast; // 105665
            yield return powerList.Generic_TreasureGoblinUsePortal; // 54866
            yield return powerList.Generic_TriuneBerserkerPowerHit; // 30567
            yield return powerList.Generic_TriuneSummonerProjectile; // 30570
            yield return powerList.Generic_TriuneSummonerShield; // 30571
            yield return powerList.Generic_TriuneSummonerSplitSummonCast; // 30572
            yield return powerList.Generic_TriuneVesselCharge; // 30573
            yield return powerList.Generic_TriuneVesselOverpower; // 30574
            yield return powerList.Generic_trOutLogStackShortDamage; // 186138
            yield return powerList.Generic_trOutLogStackTrap; // 100287
            yield return powerList.Generic_trouttristramfieldspunjitrapaoe; // 91261
            yield return powerList.Generic_trouttristramfieldspunjitrapmirroraoe; // 95387
            yield return powerList.Generic_UberDespairMeleeCleave; // 260844
            yield return powerList.Generic_UberDespairSummonMinion; // 257950
            yield return powerList.Generic_UberDespairSummonMinionDiablo; // 375537
            yield return powerList.Generic_UberDespairTeleport; // 260845
            yield return powerList.Generic_UberDespairTeleportEnrageDiablo; // 376039
            yield return powerList.Generic_UberDespairVolley; // 260847
            yield return powerList.Generic_UberDespairVolleyDiablo; // 376056
            yield return powerList.Generic_UberDiabloMirrorImage; // 375929
            yield return powerList.Generic_UberDiabloStompAndStun; // 365978
            yield return powerList.Generic_UberGluttonyBreathAttack; // 260848
            yield return powerList.Generic_UberGluttonyGasCloud; // 260849
            yield return powerList.Generic_UberGluttonyGasCloudDiablo; // 376396
            yield return powerList.Generic_UberGluttonyLoogiespawn; // 257951
            yield return powerList.Generic_UberMaghdaMothDust; // 278341
            yield return powerList.Generic_UberMaghdaPunish; // 260976
            yield return powerList.Generic_UberMaghdaPunishShielded; // 260977
            yield return powerList.Generic_UberMaghdaSummonBeserker; // 257952
            yield return powerList.Generic_UberMaghdaSummonBeserkerDiablo; // 375493
            yield return powerList.Generic_UberSiegebreakerDemonPound; // 259946
            yield return powerList.Generic_UberSiegebreakerDemonStomp; // 258635
            yield return powerList.Generic_UberSkeletonKingCleave; // 258636
            yield return powerList.Generic_UberSkeletonKingSummonSkeleton; // 256110
            yield return powerList.Generic_UberSkeletonKingSummonSkeletonDiablo; // 375473
            yield return powerList.Generic_UberSkeletonKingWhirlwind; // 258637
            yield return powerList.Generic_UberZoltunKulleCollapseCeiling; // 260851
            yield return powerList.Generic_UberZoltunKulleEnergyTwister; // 260852
            yield return powerList.Generic_UberZoltunKulleFieryBoulder; // 260853
            yield return powerList.Generic_UberZoltunKulleSlowTime; // 259947
            yield return powerList.Generic_UberZoltunKulleSlowTimeDiablo; // 376043
            yield return powerList.Generic_UberZoltunKulleTeleport; // 258638
            yield return powerList.Generic_UnburiedBossCleave; // 93715
            yield return powerList.Generic_UnburiedKnockback; // 30580
            yield return powerList.Generic_UnburiedMeleeAttack; // 30581
            yield return powerList.Generic_UnburiedWreckableAttack; // 202344
            yield return powerList.Generic_UnholyShield; // 122977
            yield return powerList.Generic_UninterruptibleDuringBuff; // 79486
            yield return powerList.Generic_UniqueMonsterEarthquakePrototype; // 256059
            yield return powerList.Generic_UniqueMonsterGenericAOENova; // 270004
            yield return powerList.Generic_UniqueMonsterGenericAOERandomAroundOwner; // 363519
            yield return powerList.Generic_UniqueMonsterGenericAOETargeted; // 270040
            yield return powerList.Generic_UniqueMonsterGenericProjectile; // 152540
            yield return powerList.Generic_UniqueMonsterGenericProjectile2; // 359684
            yield return powerList.Generic_UniqueMonsterGenericProjectileAllPlayers; // 346247
            yield return powerList.Generic_UniqueMonsterGenericSummon; // 270043
            yield return powerList.Generic_UniqueMonsterGenericSummon2; // 359685
            yield return powerList.Generic_UniqueMonsterIceTrailPassivePrototype; // 260815
            yield return powerList.Generic_UniqueMonsterTempestRushPrototype; // 256060
            yield return powerList.Generic_UntargetableDuringBuff; // 30582
            yield return powerList.Generic_UrzaelStompAndStun; // 361300
            yield return powerList.Generic_UseArcaneGlyph; // 165553
            yield return powerList.Generic_UseDungeonStone; // 220318
            yield return powerList.Generic_UseHealthGlyph; // 30584
            yield return powerList.Generic_UseItem; // 1759
            yield return powerList.Generic_UseLootRunPortal; // 389049
            yield return powerList.Generic_UseLootRunProgressGlyph; // 404128
            yield return powerList.Generic_UseManaGlyph; // 30585
            yield return powerList.Generic_UseStoneOfRecall; // 191590
            yield return powerList.Generic_Walk; // 30588
            yield return powerList.Generic_WallMonsterSpawn; // 143063
            yield return powerList.Generic_WallMonsterSpawnSiegeBreaker; // 316261
            yield return powerList.Generic_Warp; // 30589
            yield return powerList.Generic_WarpInMagical; // 132910
            yield return powerList.Generic_waterloggedCorpseEelSpawn; // 57931
            yield return powerList.Generic_waterloggedCorpsePoisonCloud; // 57028
            yield return powerList.Generic_waterTowerAOasiscaOutBreakableDamage; // 396375
            yield return powerList.Generic_WeaponMeleeInstant; // 30592
            yield return powerList.Generic_WeaponMeleeInstantBothHand; // 30593
            yield return powerList.Generic_WeaponMeleeInstantCowKing; // 368212
            yield return powerList.Generic_WeaponMeleeInstantFreezeFacing; // 106087
            yield return powerList.Generic_WeaponMeleeInstantOffHand; // 30594
            yield return powerList.Generic_WeaponMeleeInstantShortEscape; // 263041
            yield return powerList.Generic_WeaponMeleeInstantWreckables; // 202345
            yield return powerList.Generic_WeaponMeleeNoClose; // 70218
            yield return powerList.Generic_WeaponMeleeObstruction; // 30595
            yield return powerList.Generic_WeaponMeleeReachInstant; // 30596
            yield return powerList.Generic_WeaponMeleeReachInstantFreezeFacing; // 115624
            yield return powerList.Generic_WeaponRangedInstant; // 30598
            yield return powerList.Generic_WeaponRangedProjectile; // 30599
            yield return powerList.Generic_WeaponRangedWand; // 30601
            yield return powerList.Generic_WoDFlagBuff; // 375412
            yield return powerList.Generic_WoodWraithSummonSpores; // 30800
            yield return powerList.Generic_WorldCreatingBuff; // 223604
            yield return powerList.Generic_x1abattoirfurnace01; // 324819
            yield return powerList.Generic_x1AbattoirfurnaceSpinner; // 354796
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerEvent; // 359960
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerEventPhase1; // 375458
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerEventPhase2; // 375462
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerEventPhase3; // 375499
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamclockwise; // 354856
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamclockwiseEvent; // 355457
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamclockwiseEventPhase1; // 377631
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamclockwiseEventPhase2; // 377636
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamclockwiseEventPhase3; // 377641
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamcounterClockwise; // 354884
            yield return powerList.Generic_x1AbattoirfurnaceSpinnerfireBeamcounterClockwiseEvent; // 355458
            yield return powerList.Generic_x1AbattoirfurnaceWall; // 355369
            yield return powerList.Generic_x1AdriaArenaFloorPanelFire; // 290708
            yield return powerList.Generic_x1AdriaArenaFloorPanelStart; // 298181
            yield return powerList.Generic_X1AdriaBossArenaGasOff0; // 340805
            yield return powerList.Generic_X1AdriaBossArenaGasOff1; // 340806
            yield return powerList.Generic_X1AdriaBossArenaGasOn0; // 340804
            yield return powerList.Generic_X1AdriaBossArenaGasOn1; // 340807
            yield return powerList.Generic_x1AdriaCauldronSpawnerActivate; // 330791
            yield return powerList.Generic_x1AdriaCauldronSpawnerInitialPoolsBuff; // 358590
            yield return powerList.Generic_x1AdriaCauldronSpawnerLifetimeBuff; // 330783
            yield return powerList.Generic_x1AdriaCauldronSpawnerRoomPools; // 355825
            yield return powerList.Generic_x1AdriaCauldronSpawnerRoomPoolsInner; // 355826
            yield return powerList.Generic_x1AdriaCauldronSpawnerRoomPoolsOuter; // 355827
            yield return powerList.Generic_x1AdriaDelayedTeleportAttack; // 293152
            yield return powerList.Generic_x1AdriaDelayedTeleportCauldronActivate; // 362989
            yield return powerList.Generic_x1AdriaDelayedTeleportStart; // 293151
            yield return powerList.Generic_x1AdriaJumpBack; // 284247
            yield return powerList.Generic_x1AdriaPhaseOneAIState; // 360204
            yield return powerList.Generic_x1AdriaPhaseTwoAIState; // 360205
            yield return powerList.Generic_x1AdriaScriptedSequence180Turn; // 365720
            yield return powerList.Generic_x1AdriaSpitAtPlayer; // 359746
            yield return powerList.Generic_x1AdriaWingSweepLeft; // 354328
            yield return powerList.Generic_x1AdriaWingSweepRight; // 354340
            yield return powerList.Generic_X1armorScavengerAsteroidRain; // 341833
            yield return powerList.Generic_x1armorScavengerbuff; // 271621
            yield return powerList.Generic_x1armorScavengerBurrowIn; // 273462
            yield return powerList.Generic_x1armorScavengerBurrowOut; // 271740
            yield return powerList.Generic_x1armorScavengerPreBurrow; // 322380
            yield return powerList.Generic_X1AsteroidBasic; // 330593
            yield return powerList.Generic_X1AsteroidBasicSmall; // 442208
            yield return powerList.Generic_X1AsteroidPool; // 330129
            yield return powerList.Generic_X1AsteroidSpawn; // 292865
            yield return powerList.Generic_X1BloodhawkEventBallistaBossFuriousCharge; // 364196
            yield return powerList.Generic_x1bogbearTrap; // 237495
            yield return powerList.Generic_x1BogBearTrapTrigger; // 376509
            yield return powerList.Generic_x1BogBlightBurrowIn; // 276820
            yield return powerList.Generic_x1BogBlightBurrowOut; // 276843
            yield return powerList.Generic_x1BogBlightPustuleDeath; // 341714
            yield return powerList.Generic_x1BogBlightPustuleSpawn; // 234556
            yield return powerList.Generic_x1BogBlightPustuleSpawnCon; // 399284
            yield return powerList.Generic_x1BogBogWater; // 335458
            yield return powerList.Generic_x1BogBogWaterlarge; // 335795
            yield return powerList.Generic_x1BogBogWatermedium; // 335789
            yield return powerList.Generic_x1BogFamilyBruteCharge; // 238930
            yield return powerList.Generic_x1BogFamilyBruteShout; // 239018
            yield return powerList.Generic_x1BogFamilyBruteSummonMeleeAction; // 247961
            yield return powerList.Generic_x1BogFamilyBruteSummonMeleeActionUnique; // 355511
            yield return powerList.Generic_x1BogFamilyBruteThrowDude; // 238965
            yield return powerList.Generic_X1BogFamilyGuardTowerSetup; // 339982
            yield return powerList.Generic_x1BogFamilyMeleeTransform; // 338049
            yield return powerList.Generic_x1BogFamilyRangedBearTrap; // 239743
            yield return powerList.Generic_x1BogFamilyRangedBearTrapFromTower; // 340026
            yield return powerList.Generic_x1BogFamilyRangedBearTrapFromTowerReturnToFacing; // 340041
            yield return powerList.Generic_x1BogFamilyRangedRapidShot; // 336527
            yield return powerList.Generic_x1BogFamilyRangedRapidShotFromTower; // 339985
            yield return powerList.Generic_x1BogFamilyRangedRapidShotFromTowerReturnToFacing; // 339986
            yield return powerList.Generic_X1BogKingOfTheHillLeap; // 288754
            yield return powerList.Generic_x1BogPlantexplodeKnockback; // 234539
            yield return powerList.Generic_x1CatacombsDoorAonDeath; // 263272
            yield return powerList.Generic_x1CatacombsFloorRunesAonDeath; // 267289
            yield return powerList.Generic_x1CatacombsSpiritTotemactivate; // 345943
            yield return powerList.Generic_x1CesspoolSlimePosionAttack; // 301930
            yield return powerList.Generic_x1ChallengeBuffImmuneStun; // 299410
            yield return powerList.Generic_X1ChallengeLureSupersizeLure; // 346299
            yield return powerList.Generic_x1CrazedAngelArcherFireArrow; // 366438
            yield return powerList.Generic_x1DarkAngelDeath; // 363569
            yield return powerList.Generic_x1DarkAngelSoulRush; // 335991
            yield return powerList.Generic_x1DarkAngelSummon; // 342349
            yield return powerList.Generic_x1deathMaidenPowerSlamLRBoss; // 366275
            yield return powerList.Generic_x1deathMaidenPowerSlamPrototype; // 254440
            yield return powerList.Generic_x1deathMaidenSpinAttackMortarLRBoss; // 366276
            yield return powerList.Generic_x1deathMaidenSpinAttackPrototype; // 253326
            yield return powerList.Generic_x1deathMaidenSummonprototype; // 253328
            yield return powerList.Generic_x1deathMaidenSummonprototypeextraskeletons; // 369862
            yield return powerList.Generic_x1DeathMaidenUniqueFireAbattoirFurnaceFireWreath; // 376562
            yield return powerList.Generic_x1DetonateDOTBuffs; // 363984
            yield return powerList.Generic_X1DHCompanionBoarIntervene; // 368154
            yield return powerList.Generic_x1FloaterAngelLightningBeam; // 340186
            yield return powerList.Generic_x1FloaterAngelLightningBeamMalthael; // 359519
            yield return powerList.Generic_x1FloaterAngelTeleport; // 340168
            yield return powerList.Generic_x1FloaterAngelTransform; // 340083
            yield return powerList.Generic_x1FloaterAngelTransformMalthael; // 357811
            yield return powerList.Generic_X1FortressBVisuals; // 343407
            yield return powerList.Generic_X1FortressJudgeEventSpawnKnockback; // 334740
            yield return powerList.Generic_x1FortressPortalSwitch; // 360496
            yield return powerList.Generic_X1FortressPortalSwitchCheckMonsters; // 361425
            yield return powerList.Generic_X1FortressPortalSwitchTeleportMonster; // 361488
            yield return powerList.Generic_x1FortressRotatingDoor; // 330641
            yield return powerList.Generic_X1GenericBreakWallsBuff; // 377827
            yield return powerList.Generic_x1GhostDarkSoulSiphon; // 346580
            yield return powerList.Generic_x1GhostSoulSiphon; // 298686
            yield return powerList.Generic_x1GhostSoulSiphonFire; // 346561
            yield return powerList.Generic_x1GhostWalkThroughWalls; // 299066
            yield return powerList.Generic_x1GreedDeath; // 392702
            yield return powerList.Generic_x1ImperiusCleave; // 293555
            yield return powerList.Generic_X1ImperiusEnemyOrNothing; // 345327
            yield return powerList.Generic_x1ImperiusLeapSmash; // 293355
            yield return powerList.Generic_x1ImperiusWingsBuff; // 378346
            yield return powerList.Generic_X1Kylacheer; // 315456
            yield return powerList.Generic_X1Kylafalldownanimation; // 315448
            yield return powerList.Generic_X1Kylashieldup; // 315450
            yield return powerList.Generic_X1LegendaryAIRunToGuaranteedSpider; // 439849
            yield return powerList.Generic_X1LegendaryGenericPotionPowerup; // 342078
            yield return powerList.Generic_X1LegendaryPotion06; // 344094
            yield return powerList.Generic_X1LegendaryPotion07; // 405166
            yield return powerList.Generic_X1LegendaryPotion08; // 428812
            yield return powerList.Generic_X1LegendaryPotion09; // 434626
            yield return powerList.Generic_X1LegendaryPotion10; // 451310
            yield return powerList.Generic_X1LifetimeBuffAbsorbNonPlayerDamage; // 327306
            yield return powerList.Generic_X1LRBossBigRedIzualFrostNova; // 354164
            yield return powerList.Generic_x1LRBossButcherSpears; // 416435
            yield return powerList.Generic_x1LRBossDarkAngelSoulRush; // 366520
            yield return powerList.Generic_x1LRBossDarkAngelSummon; // 366525
            yield return powerList.Generic_x1LRBossDarkAngelWave; // 369463
            yield return powerList.Generic_X1LRBossdemonFlyerMegaFireBreath; // 354687
            yield return powerList.Generic_X1LRBossExpandingFireRing; // 374236
            yield return powerList.Generic_X1LRBossFireNova; // 367112
            yield return powerList.Generic_X1LRBossGenericTaunt; // 374471
            yield return powerList.Generic_X1LRBossMorluSpellcasterMeteor; // 374569
            yield return powerList.Generic_x1LRBossmorluSpellcasterWeaponMeleeInstant; // 428903
            yield return powerList.Generic_X1LRBossRatKingBurrowSetup; // 427151
            yield return powerList.Generic_X1LRBossRatKingDeadPlayerTaunt; // 428491
            yield return powerList.Generic_X1LRBossRatKingDeadPlayerTauntSearch; // 428492
            yield return powerList.Generic_X1LRBossRatKingOnDeath; // 427689
            yield return powerList.Generic_x1LRBossSandmonsterOnDeath; // 439911
            yield return powerList.Generic_x1LRBossSharedCooldown; // 367289
            yield return powerList.Generic_X1LRBossSkeletonKingSummonSkeleton; // 373204
            yield return powerList.Generic_X1LRBossSkeletonKingWhirlwind; // 375515
            yield return powerList.Generic_X1LRBossSkeletonSummonerProjectile; // 359186
            yield return powerList.Generic_X1LRBossSkeletonSummonerProjectileB; // 369518
            yield return powerList.Generic_X1LRBossSkeletonSummonerProjectileC; // 369519
            yield return powerList.Generic_x1LRBossSkeletonSummonerSummoning; // 365266
            yield return powerList.Generic_X1LRBossSuccubusFirestorm; // 374493
            yield return powerList.Generic_X1LRBossSummonCoreElites; // 445693
            yield return powerList.Generic_X1LRCreepMobHerdingAttack; // 429291
            yield return powerList.Generic_X1LRCreepMobMultipleArmAttack; // 309921
            yield return powerList.Generic_X1LRCreepMobRangedArmLineAttack; // 429077
            yield return powerList.Generic_x1MalthaelBaalAIState; // 328714
            yield return powerList.Generic_x1MalthaelBaalFesteringAppendageMelee; // 330055
            yield return powerList.Generic_x1MalthaelBaalHoarfrost; // 324846
            yield return powerList.Generic_x1MalthaelBaalRift; // 330084
            yield return powerList.Generic_x1MalthaelBaalSummonFesteringAppendages; // 330063
            yield return powerList.Generic_x1MalthaelDeathFogMonsterSetup; // 325140
            yield return powerList.Generic_x1MalthaelDiabloAIState; // 328715
            yield return powerList.Generic_x1MalthaelDiabloTeleportFireNovaLightning; // 334760
            yield return powerList.Generic_X1MalthaelDrainSoul; // 327766
            yield return powerList.Generic_x1MalthaelHealthGlobeDropper; // 340819
            yield return powerList.Generic_x1MalthaelMephistoAIState; // 328712
            yield return powerList.Generic_x1MalthaelMephistoPoisonCloud; // 330366
            yield return powerList.Generic_x1MalthaelMephistoSkullMissile; // 323604
            yield return powerList.Generic_x1MalthaelMephistoSpawnInvisLightningProxies; // 354617
            yield return powerList.Generic_x1MalthaelMephistoSpiralLightningInward; // 358059
            yield return powerList.Generic_x1MalthaelMephistoSummonRotatingLightning; // 348226
            yield return powerList.Generic_x1MalthaelMephistoTeleportExplodeOrbs; // 347681
            yield return powerList.Generic_x1MalthaelOnDeath; // 371010
            yield return powerList.Generic_x1MalthaelPhaseOneAIState; // 330358
            yield return powerList.Generic_x1MalthaelPhaseThreeAIState; // 367300
            yield return powerList.Generic_x1MalthaelPhaseTwoAIState; // 330360
            yield return powerList.Generic_X1MalthaelSickleThrowTeleport; // 327847
            yield return powerList.Generic_x1MalthaelSpiritDeath; // 360885
            yield return powerList.Generic_x1MalthaelSpiritFog; // 362756
            yield return powerList.Generic_X1MalthaelSummonDeathFogMonster; // 325184
            yield return powerList.Generic_X1MalthaelSummonFloaterAngel; // 354045
            yield return powerList.Generic_x1MalthaelSwordShieldStart; // 325648
            yield return powerList.Generic_x1MalthaelSwordShieldStop; // 325649
            yield return powerList.Generic_x1MoleMutantEnragedCombo; // 350022
            yield return powerList.Generic_x1MoleMutantRangedJumpBackShot; // 354881
            yield return powerList.Generic_x1MoleMutantRangedProjectile; // 349044
            yield return powerList.Generic_x1MoleMutantShamanBlast; // 349528
            yield return powerList.Generic_x1MoleMutantShamanResurrect; // 350639
            yield return powerList.Generic_X1MonsterAffixAvengerCorpseBomberRare; // 384623
            yield return powerList.Generic_X1MonsterAffixAvengerCorpseBomberRareCast; // 384624
            yield return powerList.Generic_X1MonsterAffixAvengerLightningStorm; // 384628
            yield return powerList.Generic_X1MonsterAffixAvengerLightningStormCast; // 384630
            yield return powerList.Generic_X1MonsterAffixAvengerOrbiter; // 384570
            yield return powerList.Generic_X1MonsterAffixAvengerOrbiterCast; // 384571
            yield return powerList.Generic_X1MonsterAffixCorpseBomber; // 308319
            yield return powerList.Generic_X1MonsterAffixCorpseBomberCast; // 308318
            yield return powerList.Generic_X1MonsterAffixCorpseBomberRare; // 309247
            yield return powerList.Generic_X1MonsterAffixCorpseBomberRareCast; // 309248
            yield return powerList.Generic_X1MonsterAffixLightningStorm; // 328052
            yield return powerList.Generic_x1MonsterAffixLightningStormAIClose; // 332756
            yield return powerList.Generic_X1MonsterAffixLightningStormCast; // 328053
            yield return powerList.Generic_X1MonsterAffixLightningStormChampion; // 349751
            yield return powerList.Generic_X1MonsterAffixLightningStormKillSelf; // 349748
            yield return powerList.Generic_X1MonsterAffixLightningStormPulse; // 348532
            yield return powerList.Generic_X1MonsterAffixLightningStormTagTarget; // 332683
            yield return powerList.Generic_X1MonsterAffixOrbiter; // 343528
            yield return powerList.Generic_X1MonsterAffixOrbiterCast; // 343527
            yield return powerList.Generic_X1MonsterAffixOrbiterChampion; // 345214
            yield return powerList.Generic_X1MonsterAffixOrbiterChampionCast; // 345215
            yield return powerList.Generic_X1MonsterAffixTeleportMines; // 337106
            yield return powerList.Generic_X1MonsterAffixTeleportMinesCast; // 337107
            yield return powerList.Generic_X1NegativeHealthGlobeFlash; // 334807
            yield return powerList.Generic_x1NightScreamerAllyBiteTransform; // 338025
            yield return powerList.Generic_x1NightScreamerCanTransform; // 338114
            yield return powerList.Generic_X1NightScreamerFuriousCharge; // 322542
            yield return powerList.Generic_x1NightScreamerScreamAttack; // 324956
            yield return powerList.Generic_x1NPCWestmarchAldritchCrushingResolve; // 367807
            yield return powerList.Generic_x1PandBruteDecapitateSlide; // 329848
            yield return powerList.Generic_X1pandemoniumideationtimeStopBuff; // 300679
            yield return powerList.Generic_x1PandExtCollapsingPillar; // 322467
            yield return powerList.Generic_x1PandExtEventgreatWeaponbossSuckIn; // 360331
            yield return powerList.Generic_x1PandExtEventgreatWeaponfireEnergyPulses; // 361400
            yield return powerList.Generic_x1PandExtEventgreatWeaponsummonBoss; // 358496
            yield return powerList.Generic_x1PandExtEventgreatWeaponsummonMonsters; // 357034
            yield return powerList.Generic_x1PandExtideationbaconbeaconOnDeath; // 300721
            yield return powerList.Generic_x1PandExtIdeationWarSpawnerAngel; // 301247
            yield return powerList.Generic_x1PandExtIdeationWarSpawnerDemon; // 301248
            yield return powerList.Generic_x1PandExtImperiusChargetowerschains; // 364483
            yield return powerList.Generic_x1PandExtImperiusChargeTowersSetup; // 365313
            yield return powerList.Generic_X1PandExtRamKnockback; // 323354
            yield return powerList.Generic_x1pandExtRangedPrototype; // 272299
            yield return powerList.Generic_x1pandExtRangedPrototypeStrafeLeft; // 323070
            yield return powerList.Generic_x1pandExtRangedPrototypeStrafeRight; // 323071
            yield return powerList.Generic_X1PandExtTimeTrap; // 347846
            yield return powerList.Generic_X1PandFortressOrdnanceChronoField; // 321861
            yield return powerList.Generic_X1PandFortressOrdnanceMine; // 321168
            yield return powerList.Generic_X1PandFortressOrdnanceShocker; // 321860
            yield return powerList.Generic_X1PandHexMazePortalChampSummon; // 347156
            yield return powerList.Generic_X1PandIntSplitMonstermerge; // 276351
            yield return powerList.Generic_X1PandIntSplitMonstersplit; // 276298
            yield return powerList.Generic_x1PandLeaperAngelLeap; // 277005
            yield return powerList.Generic_x1PandMazePortalTestPower; // 270752
            yield return powerList.Generic_x1PandMazePortalTestPowerBloone; // 374755
            yield return powerList.Generic_x1PandMazePortalTestPowerBorgoth; // 374759
            yield return powerList.Generic_x1PandMazePortalTestPowerGrotescor; // 374763
            yield return powerList.Generic_x1PandMazePortalTestPowerHaziael; // 374767
            yield return powerList.Generic_x1PandMazePortalTestPowerMagrethar; // 374771
            yield return powerList.Generic_x1PandMazePortalTestPowerSeverag; // 374775
            yield return powerList.Generic_x1PandRockwormBurstOut; // 330626
            yield return powerList.Generic_x1PandSniperAngelcloseRangedAttack; // 279220
            yield return powerList.Generic_x1PandSniperAngelcloseRangedAttackLRBoss; // 375514
            yield return powerList.Generic_x1PandSniperAngelrangedAttack; // 274493
            yield return powerList.Generic_x1PandSniperAngelrangedAttackLRBoss; // 365321
            yield return powerList.Generic_X1PassiveBountyScroll; // 356461
            yield return powerList.Generic_X1PassiveBountyScrollBeastDamage; // 375252
            yield return powerList.Generic_X1PassiveBountyScrollBossDamage; // 366183
            yield return powerList.Generic_X1PassiveBountyScrollDemonDamage; // 375246
            yield return powerList.Generic_X1PassiveBountyScrollEliteDamage; // 359128
            yield return powerList.Generic_X1PassiveBountyScrollExperience; // 356462
            yield return powerList.Generic_X1PassiveBountyScrollLifeRegen; // 377214
            yield return powerList.Generic_X1PassiveBountyScrollRunSpeed; // 375263
            yield return powerList.Generic_X1PassiveBountyScrollUndeadDamage; // 375248
            yield return powerList.Generic_X1PlaguedLacuniMaleSummon; // 357878
            yield return powerList.Generic_x1PlaguedLacuniSpecialMelee; // 359826
            yield return powerList.Generic_x1portalGuardianMinionprojectile; // 302416
            yield return powerList.Generic_x1PortalGuardianTurning; // 334633
            yield return powerList.Generic_x1PortalMonsterBurrowIn; // 270783
            yield return powerList.Generic_x1PortalMonsterBurrowOut; // 270782
            yield return powerList.Generic_x1PortalMonsterLifetimeBuff; // 270784
            yield return powerList.Generic_X1PortalMonsterPortalSummon; // 325081
            yield return powerList.Generic_X1PortalMonsterRoarSummon; // 330047
            yield return powerList.Generic_X1PortalMonsterStomp; // 279029
            yield return powerList.Generic_x1PortalMonsterSwipe; // 323805
            yield return powerList.Generic_x1RockFodderCharge; // 271815
            yield return powerList.Generic_X1RockFodderFuriousCharge; // 322494
            yield return powerList.Generic_X1RockFodderFuriousChargeRockHiveQueen; // 371040
            yield return powerList.Generic_x1RockFodderTumble; // 327540
            yield return powerList.Generic_x1rockwormpandprojectile; // 323210
            yield return powerList.Generic_X1SandmonsterpetWeaponMeleeInstant; // 439832
            yield return powerList.Generic_X1SandmonsterWeaponMeleeInstant; // 377188
            yield return powerList.Generic_x1ScaryEyesBurrowInHidden; // 246451
            yield return powerList.Generic_x1ScaryEyesBurrowOut; // 246453
            yield return powerList.Generic_x1ScaryEyescharge; // 254946
            yield return powerList.Generic_X1ScoundrelMultishot; // 365395
            yield return powerList.Generic_X1ScoundrelMultishotPassive; // 366585
            yield return powerList.Generic_X1ShardPassiveFakeGlobes; // 333071
            yield return powerList.Generic_X1ShardPassiveMinResource; // 333072
            yield return powerList.Generic_x1SkeletonArcherFireArrow; // 300136
            yield return powerList.Generic_x1SkeletonArcherFireArrowBackpedal; // 313920
            yield return powerList.Generic_x1SkeletonStab; // 315052
            yield return powerList.Generic_x1SkeletonStrafe; // 314835
            yield return powerList.Generic_X1SnitchleyTreasureGoblinEscape; // 375703
            yield return powerList.Generic_X1SpectralHoundBuff; // 370348
            yield return powerList.Generic_X1SummonVanityPet; // 319739
            yield return powerList.Generic_X1tempballistaswitchleap; // 286732
            yield return powerList.Generic_x1UberDiabloHellSpikes; // 375439
            yield return powerList.Generic_x1UdderLightning; // 338723
            yield return powerList.Generic_x1UniqueNPCEnchantressForcefulPush; // 345292
            yield return powerList.Generic_x1UniqueNPCEnchantressMassCharm; // 344565
            yield return powerList.Generic_x1UniqueNPCEnchantressScorchedEarth; // 345394
            yield return powerList.Generic_x1UniqueNPCTemplarHeal; // 344096
            yield return powerList.Generic_x1UniqueNPCTemplarOnslaught; // 344099
            yield return powerList.Generic_x1UniqueNPCTemplarShieldCharge; // 344098
            yield return powerList.Generic_x1UniqueTriuneSummonerProjectile; // 346525
            yield return powerList.Generic_x1UrzaelCannonball; // 340870
            yield return powerList.Generic_x1UrzaelCannonballBurning; // 347799
            yield return powerList.Generic_x1UrzaelCeilingDebris; // 346168
            yield return powerList.Generic_x1UrzaelCeilingDebrisBurning; // 347842
            yield return powerList.Generic_x1UrzaelFlameSweep; // 292061
            yield return powerList.Generic_x1UrzaelLeapKnockback; // 346045
            yield return powerList.Generic_x1UrzaelMeleeInstant; // 308295
            yield return powerList.Generic_x1UrzaelPhaseOneAIState; // 346028
            yield return powerList.Generic_x1UrzaelPhaseTwoAIState; // 346027
            yield return powerList.Generic_x1WestmarchBruteBChargeCustomLRBoss; // 364239
            yield return powerList.Generic_x1WestmarchBruteBChargeCustomLRBossHulkmode; // 367003
            yield return powerList.Generic_x1WestmarchBruteCharge; // 278970
            yield return powerList.Generic_x1WestmarchBruteDecapitate; // 278971
            yield return powerList.Generic_x1WestmarchBruteVomit; // 278972
            yield return powerList.Generic_X1WestmarchHoundDeadPlayerTaunt; // 335450
            yield return powerList.Generic_X1WestmarchHoundDeadPlayerTauntSearch; // 335449
            yield return powerList.Generic_X1WestmarchHoundShakeTarget; // 335522
            yield return powerList.Generic_x1westmarchRangedRangedAttackPrototype; // 289871
            yield return powerList.Generic_x1westmarchRangedSlowAreaDenialPrototype; // 289870
            yield return powerList.Generic_x1WestmarchRatCharge; // 360845
            yield return powerList.Generic_x1WestmarchRatKamikaze; // 360240
            yield return powerList.Generic_X1WestmConvert; // 306381
            yield return powerList.Generic_X1WestmConvert2; // 330011
            yield return powerList.Generic_X1WestmConvertAoE; // 307341
            yield return powerList.Generic_X1WestmConvertDelayedStart2; // 330009
            yield return powerList.Generic_X1WestmConvertDelayedStartFromTarget; // 313957
            yield return powerList.Generic_X1WestmConvertScripted; // 328861
            yield return powerList.Generic_X1westmdoomedWomanvisual; // 354949
            yield return powerList.Generic_x1westmHoistTriggeronDeathPower; // 244759
            yield return powerList.Generic_x1westmideationeventRATZNGGOLD; // 285955
            yield return powerList.Generic_x1westmSoulSummonerOrbSummonNearTarget; // 319534
            yield return powerList.Generic_X1westmSoulsummonersetup; // 301826
            yield return powerList.Generic_X1westmSoulSummonerSummon; // 313229
            yield return powerList.Generic_X1westmUniqueghostLordshockwave; // 315014
            yield return powerList.Generic_x1WickermanAggro; // 247959
            yield return powerList.Generic_X1WickerManFireNova; // 348207
            yield return powerList.Generic_X1WickerManFirePhantom; // 288538
            yield return powerList.Generic_x1WickermanSuicide; // 247960
            yield return powerList.Generic_x1WraithChargeClose; // 291711
            yield return powerList.Generic_X1WraithMelee; // 265587
            yield return powerList.Generic_X1WraithPiercingDash; // 265911
            yield return powerList.Generic_X1X1EventSpeedKillChampionSpawner; // 365581
            yield return powerList.Generic_X1X1EventSpeedKillSpawner; // 364720
            yield return powerList.Generic_x1ZombieFemaleProjectilePoison; // 355496
            yield return powerList.Generic_ZKBallSummonSkeleton; // 30804
            yield return powerList.Generic_zoltsmallFloorSpawner; // 30808
            yield return powerList.Generic_zoltTabletstateChange; // 30810
            yield return powerList.Generic_ZoltunKulleCollapseCeiling; // 139705
            yield return powerList.Generic_ZoltunKulleEnergyTwister; // 139736
            yield return powerList.Generic_ZoltunKulleFieryBoulder; // 139942
            yield return powerList.Generic_ZoltunKulleSlowTime; // 139831
            yield return powerList.Generic_ZoltunKulleTeleport; // 139711
            yield return powerList.Generic_ZoltunKulleTeleportToPlayer; // 241753
            yield return powerList.Generic_ZoltunKulleTeleportToPlayerEnrage; // 243289
            yield return powerList.Generic_ZombieEatStart; // 178483
            yield return powerList.Generic_ZombieEatStop; // 178485
            yield return powerList.Generic_ZombieFemaleProjectile; // 110518
            yield return powerList.Generic_ZombieKillerGrab; // 1771
        }
    }
}