namespace Turbo.Plugins.Jack.Extensions
{
    public static class GemPowersExtensions
    {
        private static IGemPowerList gemPowerList;

        public static IGemPowerList GemPowers(this IController controller)
        {
            return gemPowerList ?? (gemPowerList = new GemPowerList(controller));
        }
    }

    public class GemPowerList : IGemPowerList
    {
        public IController Hud { get; private set; }

        public ISnoPower BaneOfThePowerfulPrimary { get { return Hud.Sno.GetSnoPower(383014); } }
        public ISnoPower BaneOfThePowerfulSecondary { get { return Hud.Sno.GetSnoPower(451157); } }
        public ISnoPower BaneOfTheTrappedPrimary { get { return Hud.Sno.GetSnoPower(403456); } }
        public ISnoPower BaneOfTheTrappedSecondary { get { return Hud.Sno.GetSnoPower(403457); } }
        public ISnoPower BaneOfTheStrickenPrimary { get { return Hud.Sno.GetSnoPower(428348); } }
        public ISnoPower BaneOfTheStrickenSecondary { get { return Hud.Sno.GetSnoPower(428349); } }
        public ISnoPower BoonOfTheHoarderPrimary { get { return Hud.Sno.GetSnoPower(403470); } }
        public ISnoPower BoonOfTheHoarderSecondary { get { return Hud.Sno.GetSnoPower(403784); } }
        public ISnoPower BoyarskysChipPrimary { get { return Hud.Sno.GetSnoPower(428352); } }
        public ISnoPower BoyarskysChipSecondary { get { return Hud.Sno.GetSnoPower(428353); } }
        public ISnoPower EnforcerPrimary { get { return Hud.Sno.GetSnoPower(403466); } }
        public ISnoPower EnforcerSecondary { get { return Hud.Sno.GetSnoPower(403472); } }
        public ISnoPower EsotericAlterationPrimary { get { return Hud.Sno.GetSnoPower(428029); } }
        public ISnoPower EsotericAlterationSecondary { get { return Hud.Sno.GetSnoPower(428030); } }
        public ISnoPower GemOfEasePrimary { get { return Hud.Sno.GetSnoPower(403459); } }
        public ISnoPower GemOfTheToxinPrimary { get { return Hud.Sno.GetSnoPower(403461); } }
        public ISnoPower GemOfTheToxinSecondary { get { return Hud.Sno.GetSnoPower(403556); } }
        public ISnoPower GogokOfSwiftnessPrimary { get { return Hud.Sno.GetSnoPower(403464); } }
        public ISnoPower GogokOfSwiftnessSecondary { get { return Hud.Sno.GetSnoPower(403524); } }
        public ISnoPower IceblinkPimary { get { return Hud.Sno.GetSnoPower(428354); } }
        public ISnoPower IceblinkSecondary { get { return Hud.Sno.GetSnoPower(428356); } }
        public ISnoPower InvigoratingGemstonePrimary { get { return Hud.Sno.GetSnoPower(403465); } }
        public ISnoPower InvigoratingGemstoneSecondary { get { return Hud.Sno.GetSnoPower(403624); } }
        public ISnoPower MirinaeTeardropOfStarweaverPrimary { get { return Hud.Sno.GetSnoPower(403463); } }
        public ISnoPower MirinaeTeardropOfStarweaverSecondary { get { return Hud.Sno.GetSnoPower(403620); } }
        public ISnoPower MoltenWidebeestsGizzardPrimary { get { return Hud.Sno.GetSnoPower(428031); } }
        public ISnoPower MoltenWidebeestsGizzardSecondary { get { return Hud.Sno.GetSnoPower(428032); } }
        public ISnoPower MoratoriumPrimary { get { return Hud.Sno.GetSnoPower(403467); } }
        public ISnoPower MoratoriumSecondary { get { return Hud.Sno.GetSnoPower(403687); } }
        public ISnoPower MutilationGuardPrimary { get { return Hud.Sno.GetSnoPower(428350); } }
        public ISnoPower MutilationGuardSecondary { get { return Hud.Sno.GetSnoPower(428351); } }
        public ISnoPower PainEnhancerPrimary { get { return Hud.Sno.GetSnoPower(403462); } }
        public ISnoPower PainEnhancerSecondary { get { return Hud.Sno.GetSnoPower(403600); } }
        public ISnoPower RedSoulShardPrimary { get { return Hud.Sno.GetSnoPower(454736); } }
        public ISnoPower RedSoulShardSecondary { get { return Hud.Sno.GetSnoPower(454737); } }
        public ISnoPower SimplicitysStrengthPrimary { get { return Hud.Sno.GetSnoPower(403469); } }
        public ISnoPower SimplicitysStrengthSecondary { get { return Hud.Sno.GetSnoPower(403473); } }
        public ISnoPower TaegukPrimary { get { return Hud.Sno.GetSnoPower(403471); } }
        public ISnoPower TaegukSecondary { get { return Hud.Sno.GetSnoPower(403785); } }
        public ISnoPower WreathOfLightningPrimary { get { return Hud.Sno.GetSnoPower(403460); } }
        public ISnoPower WreathOfLightningSecondary { get { return Hud.Sno.GetSnoPower(403560); } }
        public ISnoPower ZeisStoneOfVengeancePrimary { get { return Hud.Sno.GetSnoPower(403468); } }
        public ISnoPower ZeisStoneOfVengeanceSecondary { get { return Hud.Sno.GetSnoPower(403727); } }

        public GemPowerList(IController controller)
        {
            Hud = controller;
        }
    }

    public interface IGemPowerList
    {
        ISnoPower BaneOfThePowerfulPrimary { get; }
        ISnoPower BaneOfThePowerfulSecondary { get; }
        ISnoPower BaneOfTheTrappedPrimary { get; }
        ISnoPower BaneOfTheTrappedSecondary { get; }
        ISnoPower BaneOfTheStrickenPrimary { get; }
        ISnoPower BaneOfTheStrickenSecondary { get; }
        ISnoPower BoonOfTheHoarderPrimary { get; }
        ISnoPower BoonOfTheHoarderSecondary { get; }
        ISnoPower BoyarskysChipPrimary { get; }
        ISnoPower BoyarskysChipSecondary { get; }
        ISnoPower EnforcerPrimary { get; }
        ISnoPower EnforcerSecondary { get; }
        ISnoPower EsotericAlterationPrimary { get; }
        ISnoPower EsotericAlterationSecondary { get; }
        ISnoPower GemOfEasePrimary { get; }
        ISnoPower GemOfTheToxinPrimary { get; }
        ISnoPower GemOfTheToxinSecondary { get; }
        ISnoPower GogokOfSwiftnessPrimary { get; }
        ISnoPower GogokOfSwiftnessSecondary { get; }
        ISnoPower IceblinkPimary { get; }
        ISnoPower IceblinkSecondary { get; }
        ISnoPower InvigoratingGemstonePrimary { get; }
        ISnoPower InvigoratingGemstoneSecondary { get; }
        ISnoPower MirinaeTeardropOfStarweaverPrimary { get; }
        ISnoPower MirinaeTeardropOfStarweaverSecondary { get; }
        ISnoPower MoltenWidebeestsGizzardPrimary { get; }
        ISnoPower MoltenWidebeestsGizzardSecondary { get; }
        ISnoPower MoratoriumPrimary { get; }
        ISnoPower MoratoriumSecondary { get; }
        ISnoPower MutilationGuardPrimary { get; }
        ISnoPower MutilationGuardSecondary { get; }
        ISnoPower PainEnhancerPrimary { get; }
        ISnoPower PainEnhancerSecondary { get; }
        ISnoPower RedSoulShardPrimary { get; }
        ISnoPower RedSoulShardSecondary { get; }
        ISnoPower SimplicitysStrengthPrimary { get; }
        ISnoPower SimplicitysStrengthSecondary { get; }
        ISnoPower TaegukPrimary { get; }
        ISnoPower TaegukSecondary { get; }
        ISnoPower WreathOfLightningPrimary { get; }
        ISnoPower WreathOfLightningSecondary { get; }
        ISnoPower ZeisStoneOfVengeancePrimary { get; }
        ISnoPower ZeisStoneOfVengeanceSecondary { get; }
    }
}