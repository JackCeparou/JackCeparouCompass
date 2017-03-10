namespace Turbo.Plugins.Jack.Extensions
{
    using Turbo.Plugins.Default;

    public static class MissingSnoPowerExtensions
    {
        public static IController Hud { get; set; }

        // naming
        public static ISnoPower Monk_FistsOfThunder(this ISnoPowerList powerList)
        {
            return powerList.Monk_FistsofThunder;
        }
        public static ISnoPower Monk_Passive_Determination(this ISnoPowerList powerList)
        {
            return powerList.Monk_Passive_Provocation;
        }
        public static ISnoPower Monk_Passive_Alacrity(this ISnoPowerList powerList)
        {
            return powerList.Monk_Passive_GuidingLight;
        }
        public static ISnoPower WitchDoctor_WallOfDeath(this ISnoPowerList powerList)
        {
            return powerList.WitchDoctor_WallOfZombies;
        }
        public static ISnoPower WitchDoctor_Passive_SwamplandAttunement(this ISnoPowerList powerList)
        {
            return powerList.WitchDoctor_Passive_PhysicalAttunement;
        }
        // end naming

        // missing
        //392883	Wizard_Archon_ArcaneBlast_Cold	Ice Blast	Release a wave of pure energy that damages all nearby enemies.
        //392884	Wizard_Archon_ArcaneBlast_Fire	Fire Blast	Release a wave of pure energy that damages all nearby enemies.
        //392885	Wizard_Archon_ArcaneBlast_Lightning	Lightning Blast	Release a wave of pure energy that damages all nearby enemies.
        //392886	Wizard_Archon_ArcaneStrike_Cold	Frozen Strike	Strike the ground and damage enemies in front of you.
        //392887	Wizard_Archon_ArcaneStrike_Fire	Inferno Strike	Strike the ground and damage enemies in front of you.
        //392888	Wizard_Archon_ArcaneStrike_Lightning	Lightning Strike	Strike the ground and damage enemies in front of you.
        //166616	Wizard_Archon_Cancel	Cancel Archon Form	Release the powers of the Archon and return to your natural form.
        //392889	Wizard_Archon_DisintegrationWave_Cold	Disintegration Wave	Channel a beam of pure energy that pierces through all enemies.
        //392890	Wizard_Archon_DisintegrationWave_Fire	Disintegration Wave	Channel a beam of pure energy that pierces through all enemies.
        //392891	Wizard_Archon_DisintegrationWave_Lightning	Disintegration Wave	Channel a beam of pure energy that pierces through all enemies.
        //375089	X1_Monk_MantraOfConviction_v2_Passive	Mantra of Conviction
        //375050	X1_Monk_MantraOfEvasion_v2_Passive	Mantra of Salvation
        //373154	X1_Monk_MantraOfHealing_v2_Passive	Mantra of Healing
        //375083	X1_Monk_MantraOfRetribution_v2_Passive	Mantra of Retribution
        public static ISnoPower Wizard_Archon_ArcaneBlast_Cold(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392883); }
        public static ISnoPower Wizard_Archon_ArcaneBlast_Fire(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392884); }
        public static ISnoPower Wizard_Archon_ArcaneBlast_Lightning(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392885); }
        public static ISnoPower Wizard_Archon_ArcaneStrike_Cold(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392886); }
        public static ISnoPower Wizard_Archon_ArcaneStrike_Fire(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392887); }
        public static ISnoPower Wizard_Archon_ArcaneStrike_Lightning(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392888); }
        public static ISnoPower Wizard_Archon_Cancel(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(166616); }
        public static ISnoPower Wizard_Archon_DisintegrationWave_Cold(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392889); }
        public static ISnoPower Wizard_Archon_DisintegrationWave_Fire(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392890); }
        public static ISnoPower Wizard_Archon_DisintegrationWave_Lightning(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(392891); }
        public static ISnoPower Monk_MantraOfConviction_v2_Passive(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(375089); }
        public static ISnoPower Monk_MantraOfEvasion_v2_Passive(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(375050); }
        public static ISnoPower Monk_MantraOfHealing_v2_Passive(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(373154); }
        public static ISnoPower Monk_MantraOfRetribution_v2_Passive(this ISnoPowerList powerList) { return Hud.Sno.GetSnoPower(375083); }
        // end missing
    }

    public class MissingSnoPowerExtensionsPlugin : BasePlugin
    {
        public MissingSnoPowerExtensionsPlugin()
        {
            Enabled = true;
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
            MissingSnoPowerExtensions.Hud = hud;
            Enabled = false;
        }
    }
}
