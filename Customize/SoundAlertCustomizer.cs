namespace Turbo.Plugins.Jack.Customize
{
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.TextToSpeech;

    public class SoundAlertCustomizer : BasePlugin, ICustomizer
    {
        public SoundAlertCustomizer()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<Plugins.Default.StandardMonsterPlugin>(plugin =>
            {
                plugin.BossDecorator.Add(SoundAlertFactory.Create<IActor>(Hud));
            });

            Hud.RunOnPlugin<Plugins.Default.ShrinePlugin>(plugin =>
            {
                //plugin.AllShrineDecorator.Add(SoundAlertFactory.Create<IShrine>(Hud, (shrine) => shrine.SnoActor.NameLocalized));
                plugin.AllShrineDecorator.Add(SoundAlertFactory.Create<IShrine>(Hud, (shrine) => {
                    var text = string.Empty;
                    switch (shrine.Type)
                    {
                        case ShrineType.BanditShrine:
                            text = shrine.SnoActor.NameLocalized;
                            break;
                        case ShrineType.BlessedShrine:
                        case ShrineType.EnlightenedShrine:
                        case ShrineType.FortuneShrine:
                        case ShrineType.FrenziedShrine:
                        case ShrineType.EmpoweredShrine:
                        case ShrineType.FleetingShrine:
                            text = shrine.SnoActor.NameLocalized.ToLower().Replace("shrine", "").Trim();
                            break;
                        case ShrineType.PowerPylon:
                        case ShrineType.ConduitPylon:
                        case ShrineType.ChannelingPylon:
                        case ShrineType.ShieldPylon:
                        case ShrineType.SpeedPylon:
                            text = shrine.SnoActor.NameLocalized;
                            break;
                    }

                    return text;
                }));

                plugin.PoolOfReflectionDecorator.Add(SoundAlertFactory.Create<IShrine>(Hud, (shrine) => "pool"));
            });

            Hud.RunOnPlugin<Plugins.Default.GoblinPlugin>(plugin =>
            {
                plugin.EnableSpeak = false; //just in case the default change
                //plugin.PortalDecorator.Add(SoundAlertFactory.Create<IActor>(Hud, (actor) => "portal"));
            });

            Hud.RunOnPlugin<Jack.Monsters.GoblinSoundAlertPlugin>(plugin =>
            {
                plugin.GoblinPack.TextFunc = (monster) => "goblin pack";

                //plugin.DefaultGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.MalevolentTormentor = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.BloodThief = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.OdiousCollector = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.GemHoarder = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.Gelatinous = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.GildedBaron = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.InsufferableMiscreant = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.RainbowGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.MenageristGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
                //plugin.TreasureFiendGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            });

            Hud.RunOnPlugin<Jack.Items.ItemDropSoundAlertPlugin>(plugin =>
            {
                // legendaries
                plugin.Legendary = false;
                plugin.AncientLegendary = true;
                plugin.PrimalAncientLegendary = true;
                // sets
                plugin.Set = false;
                plugin.AncientSet = true;
                plugin.PrimalAncientSet = true;

                // alerts when gambling at kadala ?
                plugin.Gambled = true;

                // ancient & primals prefixes
                plugin.AncientLegendaryNamePrefix = "Ancient";
                plugin.PrimalAncientLegendaryNamePrefix = "Primal";
                plugin.AncientSetNamePrefix = "Ancient Set";
                plugin.PrimalAncientSetNamePrefix = "Primal Set";

                // Exceptions on above rules :
                // ---------------------------

                // add any item
                plugin.ItemSnos.Add(1844495708); // 1844495708 - Ramaladni's Gift
                //plugin.ItemSnos.Add(2332226049); // health globe

                // ancients items if ancient rank == 1 is not activated
                // example for // 916911834 - Sacred Harvester
                //plugin.AncientItemSnos.Add(916911834);

                // primals items if ancient rank == 2 is not activated
                //plugin.PrimalAncientItemSnos.Add(12354689);

                // custom items names (if the item is not in one of the other list, this will do nothing)
                plugin.ItemCustomNames.Add(1844495708, "OMAGAD a gift"); // 1844495708 - Ramaladni's Gift
                //plugin.ItemCustomNames.Add(2332226049, "health"); // health globe
            });

            ////////////
            // SKILLS //
            ////////////
            Hud.RunOnPlugin<Jack.Players.PlayerSkillCooldownSoundAlertPlugin>(plugin =>
            {
                plugin.InTown = true;
                //plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
                plugin.Add(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk, "Walk"); // custom name
                //plugin.Add(106237); // by sno
                //plugin.Add(106237, "Walk"); // by sno with custom name

                // remove entries
                //plugin.Remove(Hud.Sno.SnoPowers.WitchDoctor_SpiritWalk);
                //plugin.Remove(106237);

                // clear all
                //plugin.Clear();

                //plugin.Add(Hud.Sno.SnoPowers.Wizard_BlackHole, false, true, null, "BH");
                //plugin.Add(Hud.Sno.SnoPowers.Wizard_Passive_UnstableAnomaly, true, true, "Cheat death", "ok"); // don't work on passive
            });

            //Hud.RunOnPlugin<RamaladniDropFixPlugin>(plugin =>
            //{
            //    plugin.SoundAlert.TextFunc = (item) => "OMAGAD a gift";
            //});

            //Hud.RunOnPlugin<MonsterRiftProgressionColoringPlugin>(plugin =>
            //{
            //    plugin.Decorator1.Add(new SoundAlertDecorator(Hud));
            //    plugin.Decorator2.Add(new SoundAlertDecorator(Hud));
            //    plugin.Decorator3.Add(new SoundAlertDecorator(Hud));
            //    plugin.Decorator4.Add(new SoundAlertDecorator(Hud));
            //    plugin.Decorator5.Add(new SoundAlertDecorator(Hud));
            //});

            Enabled = false;
        }
    }
}