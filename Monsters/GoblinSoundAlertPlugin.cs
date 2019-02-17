﻿namespace Turbo.Plugins.Jack.Monsters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.TextToSpeech;

    [Obsolete]
    public class GoblinSoundAlertPlugin : BasePlugin, IAfterCollectHandler, INewAreaHandler
    {
        public SoundAlert<IMonster> GoblinPack { get; set; }

        public SoundAlert<IMonster> DefaultGoblin { get; set; }
        public SoundAlert<IMonster> MalevolentTormentor { get; set; }
        public SoundAlert<IMonster> BloodThief { get; set; }
        public SoundAlert<IMonster> OdiousCollector { get; set; }
        public SoundAlert<IMonster> GemHoarder { get; set; }
        public SoundAlert<IMonster> Gelatinous { get; set; }
        public SoundAlert<IMonster> GildedBaron { get; set; }
        public SoundAlert<IMonster> InsufferableMiscreant { get; set; }
        public SoundAlert<IMonster> RainbowGoblin { get; set; }
        public SoundAlert<IMonster> MenageristGoblin { get; set; }
        public SoundAlert<IMonster> TreasureFiendGoblin { get; set; }

        public Dictionary<uint, SoundAlert<IMonster>> SnoMapping { get; private set; }

        private IWatch lastPack;

        public GoblinSoundAlertPlugin()
        {
            Enabled = true;
            SnoMapping = new Dictionary<uint, SoundAlert<IMonster>>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);

            GoblinPack = SoundAlertFactory.Create<IMonster>((monster) => "goblin pack");

            DefaultGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            MalevolentTormentor = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            BloodThief = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            OdiousCollector = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            GemHoarder = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            Gelatinous = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            GildedBaron = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            InsufferableMiscreant = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            RainbowGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            MenageristGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);
            TreasureFiendGoblin = SoundAlertFactory.Create<IMonster>((monster) => monster.SnoMonster.NameLocalized);

            SnoMapping.Add(413289, MalevolentTormentor);
            SnoMapping.Add(408989, BloodThief);
            SnoMapping.Add(5985, OdiousCollector);
            SnoMapping.Add(5987, GemHoarder);
            SnoMapping.Add(408354, Gelatinous); // Gelatinous Sire
            //SnoMapping.Add(410572, Gelatinous); // Gelatinous Spawn
            //SnoMapping.Add(410574, Gelatinous); // Gelatinous Spawn
            SnoMapping.Add(429161, GildedBaron);
            SnoMapping.Add(408655, InsufferableMiscreant);
            SnoMapping.Add(450993, MenageristGoblin);
            SnoMapping.Add(405186, RainbowGoblin);
            SnoMapping.Add(380657, TreasureFiendGoblin);

            lastPack = Hud.Time.CreateWatch();
        }

        public void OnNewArea(bool newGame, ISnoArea area)
        {
            if (lastPack.IsRunning)
            {
                lastPack.Stop();
                lastPack.Reset();
            }
        }

        public void AfterCollect()
        {
            if (!Hud.Game.IsInGame) return;
            if (Hud.Game.IsInTown) return;

            // TODO : greed & whyrmshire portals
            //408679	MarkerLocation_GoblinPortalIn
            // 393030	p1_Greed_Portal
            // 405750	p1_Greed_PortalMonsterSummon	Invisible portal summoner
            //408679	MarkerLocation_GoblinPortalIn

            //var goblins = Hud.Game.AliveMonsters.Where(x => x.SnoMonster.Priority == MonsterPriority.goblin && x.GetData<SoundAlert<IMonster>>() == null && x.SnoActor.Sno != 410572 && x.SnoActor.Sno != 410574);
            var goblins = Hud.Game.AliveMonsters.Where(x => SnoMapping.ContainsKey(x.SnoMonster.Sno) && x.GetData<SoundAlert<IMonster>>() == null);
            //Says.Debug(string.Join(" ", goblins.Select(g => g.SnoMonster.Sno)));
            if (goblins.Count() > 1)
            {
                if (!lastPack.IsRunning || lastPack.TimerTest(180000)) // 3 minutes
                {
                    lastPack.Restart();
                    SoundAlertManagerPlugin.Register<IMonster>(goblins.First(), GoblinPack);
                }
            }
            else
            {
                foreach (var goblin in goblins)
                {
                    SoundAlert<IMonster> soundAlert;
                    if (!SnoMapping.TryGetValue(goblin.SnoMonster.Sno /*.SnoActor.Sno*/, out soundAlert))
                    {
                        soundAlert = DefaultGoblin;
                    }
                    SoundAlertManagerPlugin.Register<IMonster>(goblin, soundAlert);
                }
            }
        }
    }
}