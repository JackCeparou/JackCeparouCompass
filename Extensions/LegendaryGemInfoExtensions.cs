namespace Turbo.Plugins.Jack.Extensions
{
    using System.Collections.Generic;

    public static class LegendaryGemInfoExtensions
    {
        public static IEnumerable<IBuff> AllGemBuffs(this ILegendaryGemInfo powerInfo)
        {
            if (powerInfo.BaneOfThePowerfulPrimary != null) yield return powerInfo.BaneOfThePowerfulPrimary;
            if (powerInfo.BaneOfThePowerfulSecondary != null) yield return powerInfo.BaneOfThePowerfulSecondary;
            if (powerInfo.BaneOfTheStrickenPrimary != null) yield return powerInfo.BaneOfTheStrickenPrimary;
            if (powerInfo.BaneOfTheStrickenSecondary != null) yield return powerInfo.BaneOfTheStrickenSecondary;
            if (powerInfo.BaneOfTheTrappedPrimary != null) yield return powerInfo.BaneOfTheTrappedPrimary;
            if (powerInfo.BaneOfTheTrappedSecondary != null) yield return powerInfo.BaneOfTheTrappedSecondary;
            if (powerInfo.BoonOfTheHoarderPrimary != null) yield return powerInfo.BoonOfTheHoarderPrimary;
            if (powerInfo.BoonOfTheHoarderSecondary != null) yield return powerInfo.BoonOfTheHoarderSecondary;
            if (powerInfo.BoyarskysChipPrimary != null) yield return powerInfo.BoyarskysChipPrimary;
            if (powerInfo.BoyarskysChipSecondary != null) yield return powerInfo.BoyarskysChipSecondary;
            if (powerInfo.EnforcerPrimary != null) yield return powerInfo.EnforcerPrimary;
            if (powerInfo.EnforcerSecondary != null) yield return powerInfo.EnforcerSecondary;
            if (powerInfo.EsotericAlterationPrimary != null) yield return powerInfo.EsotericAlterationPrimary;
            if (powerInfo.EsotericAlterationSecondary != null) yield return powerInfo.EsotericAlterationSecondary;
            if (powerInfo.GemOfEasePrimary != null) yield return powerInfo.GemOfEasePrimary;
            if (powerInfo.GemOfEaseSecondary != null) yield return powerInfo.GemOfEaseSecondary;
            if (powerInfo.GemOfEfficaciousToxinPrimary != null) yield return powerInfo.GemOfEfficaciousToxinPrimary;
            if (powerInfo.GemOfEfficaciousToxinSecondary != null) yield return powerInfo.GemOfEfficaciousToxinSecondary;
            if (powerInfo.GogokOfSwiftnessPrimary != null) yield return powerInfo.GogokOfSwiftnessPrimary;
            if (powerInfo.GogokOfSwiftnessSecondary != null) yield return powerInfo.GogokOfSwiftnessSecondary;
            if (powerInfo.IceblinkPrimary != null) yield return powerInfo.IceblinkPrimary;
            if (powerInfo.IceblinkSecondary != null) yield return powerInfo.IceblinkSecondary;
            if (powerInfo.InvigoratingGemstonePrimary != null) yield return powerInfo.InvigoratingGemstonePrimary;
            if (powerInfo.InvigoratingGemstoneSecondary != null) yield return powerInfo.InvigoratingGemstoneSecondary;
            if (powerInfo.MirinaeTeardropOfTheStarweaverPrimary != null) yield return powerInfo.MirinaeTeardropOfTheStarweaverPrimary;
            if (powerInfo.MirinaeTeardropOfTheStarweaverSecondary != null) yield return powerInfo.MirinaeTeardropOfTheStarweaverSecondary;
            if (powerInfo.MoltenWildebeestsGizzardPrimary != null) yield return powerInfo.MoltenWildebeestsGizzardPrimary;
            if (powerInfo.MoltenWildebeestsGizzardSecondary != null) yield return powerInfo.MoltenWildebeestsGizzardSecondary;
            if (powerInfo.MoratoriumPrimary != null) yield return powerInfo.MoratoriumPrimary;
            if (powerInfo.MoratoriumSecondary != null) yield return powerInfo.MoratoriumSecondary;
            if (powerInfo.MutilationGuardPrimary != null) yield return powerInfo.MutilationGuardPrimary;
            if (powerInfo.MutilationGuardSecondary != null) yield return powerInfo.MutilationGuardSecondary;
            if (powerInfo.PainEnhancerPrimary != null) yield return powerInfo.PainEnhancerPrimary;
            if (powerInfo.PainEnhancerSecondary != null) yield return powerInfo.PainEnhancerSecondary;
            if (powerInfo.RedSoulShardPrimary != null) yield return powerInfo.RedSoulShardPrimary;
            if (powerInfo.RedSoulShardSecondary != null) yield return powerInfo.RedSoulShardSecondary;
            if (powerInfo.SimplicitysStrengthPrimary != null) yield return powerInfo.SimplicitysStrengthPrimary;
            if (powerInfo.SimplicitysStrengthSecondary != null) yield return powerInfo.SimplicitysStrengthSecondary;
            if (powerInfo.TaegukPrimary != null) yield return powerInfo.TaegukPrimary;
            if (powerInfo.TaegukSecondary != null) yield return powerInfo.TaegukSecondary;
            if (powerInfo.WreathOfLightningPrimary != null) yield return powerInfo.WreathOfLightningPrimary;
            if (powerInfo.WreathOfLightningSecondary != null) yield return powerInfo.WreathOfLightningSecondary;
            if (powerInfo.ZeisStoneOfVengeancePrimary != null) yield return powerInfo.ZeisStoneOfVengeancePrimary;
            if (powerInfo.ZeisStoneOfVengeanceSecondary != null) yield return powerInfo.ZeisStoneOfVengeanceSecondary;
        }

        public static IEnumerable<IBuff> AllGemPrimaryBuffs(this ILegendaryGemInfo powerInfo)
        {
            if (powerInfo.BaneOfThePowerfulPrimary != null) yield return powerInfo.BaneOfThePowerfulPrimary;
            if (powerInfo.BaneOfTheStrickenPrimary != null) yield return powerInfo.BaneOfTheStrickenPrimary;
            if (powerInfo.BaneOfTheTrappedPrimary != null) yield return powerInfo.BaneOfTheTrappedPrimary;
            if (powerInfo.BoonOfTheHoarderPrimary != null) yield return powerInfo.BoonOfTheHoarderPrimary;
            if (powerInfo.BoyarskysChipPrimary != null) yield return powerInfo.BoyarskysChipPrimary;
            if (powerInfo.EnforcerPrimary != null) yield return powerInfo.EnforcerPrimary;
            if (powerInfo.EsotericAlterationPrimary != null) yield return powerInfo.EsotericAlterationPrimary;
            if (powerInfo.GemOfEasePrimary != null) yield return powerInfo.GemOfEasePrimary;
            if (powerInfo.GemOfEfficaciousToxinPrimary != null) yield return powerInfo.GemOfEfficaciousToxinPrimary;
            if (powerInfo.GogokOfSwiftnessPrimary != null) yield return powerInfo.GogokOfSwiftnessPrimary;
            if (powerInfo.IceblinkPrimary != null) yield return powerInfo.IceblinkPrimary;
            if (powerInfo.InvigoratingGemstonePrimary != null) yield return powerInfo.InvigoratingGemstonePrimary;
            if (powerInfo.MoltenWildebeestsGizzardPrimary != null) yield return powerInfo.MoltenWildebeestsGizzardPrimary;
            if (powerInfo.MoratoriumPrimary != null) yield return powerInfo.MoratoriumPrimary;
            if (powerInfo.MirinaeTeardropOfTheStarweaverPrimary != null) yield return powerInfo.MirinaeTeardropOfTheStarweaverPrimary;
            if (powerInfo.MutilationGuardPrimary != null) yield return powerInfo.MutilationGuardPrimary;
            if (powerInfo.PainEnhancerPrimary != null) yield return powerInfo.PainEnhancerPrimary;
            if (powerInfo.RedSoulShardPrimary != null) yield return powerInfo.RedSoulShardPrimary;
            if (powerInfo.SimplicitysStrengthPrimary != null) yield return powerInfo.SimplicitysStrengthPrimary;
            if (powerInfo.TaegukPrimary != null) yield return powerInfo.TaegukPrimary;
            if (powerInfo.WreathOfLightningPrimary != null) yield return powerInfo.WreathOfLightningPrimary;
            if (powerInfo.ZeisStoneOfVengeancePrimary != null) yield return powerInfo.ZeisStoneOfVengeancePrimary;
        }

        public static IEnumerable<IBuff> AllGemSecondaryBuffs(this ILegendaryGemInfo powerInfo)
        {
            if (powerInfo.BaneOfThePowerfulSecondary != null) yield return powerInfo.BaneOfThePowerfulSecondary;
            if (powerInfo.BaneOfTheStrickenSecondary != null) yield return powerInfo.BaneOfTheStrickenSecondary;
            if (powerInfo.BaneOfTheTrappedSecondary != null) yield return powerInfo.BaneOfTheTrappedSecondary;
            if (powerInfo.BoonOfTheHoarderSecondary != null) yield return powerInfo.BoonOfTheHoarderSecondary;
            if (powerInfo.BoyarskysChipSecondary != null) yield return powerInfo.BoyarskysChipSecondary;
            if (powerInfo.EnforcerSecondary != null) yield return powerInfo.EnforcerSecondary;
            if (powerInfo.EsotericAlterationSecondary != null) yield return powerInfo.EsotericAlterationSecondary;
            if (powerInfo.GemOfEaseSecondary != null) yield return powerInfo.GemOfEaseSecondary;
            if (powerInfo.GemOfEfficaciousToxinSecondary != null) yield return powerInfo.GemOfEfficaciousToxinSecondary;
            if (powerInfo.GogokOfSwiftnessSecondary != null) yield return powerInfo.GogokOfSwiftnessSecondary;
            if (powerInfo.IceblinkSecondary != null) yield return powerInfo.IceblinkSecondary;
            if (powerInfo.InvigoratingGemstoneSecondary != null) yield return powerInfo.InvigoratingGemstoneSecondary;
            if (powerInfo.MirinaeTeardropOfTheStarweaverSecondary != null) yield return powerInfo.MirinaeTeardropOfTheStarweaverSecondary;
            if (powerInfo.MoltenWildebeestsGizzardSecondary != null) yield return powerInfo.MoltenWildebeestsGizzardSecondary;
            if (powerInfo.MoratoriumSecondary != null) yield return powerInfo.MoratoriumSecondary;
            if (powerInfo.MutilationGuardSecondary != null) yield return powerInfo.MutilationGuardSecondary;
            if (powerInfo.PainEnhancerSecondary != null) yield return powerInfo.PainEnhancerSecondary;
            if (powerInfo.RedSoulShardSecondary != null) yield return powerInfo.RedSoulShardSecondary;
            if (powerInfo.SimplicitysStrengthSecondary != null) yield return powerInfo.SimplicitysStrengthSecondary;
            if (powerInfo.TaegukSecondary != null) yield return powerInfo.TaegukSecondary;
            if (powerInfo.WreathOfLightningSecondary != null) yield return powerInfo.WreathOfLightningSecondary;
            if (powerInfo.ZeisStoneOfVengeanceSecondary != null) yield return powerInfo.ZeisStoneOfVengeanceSecondary;
        }
    }
}