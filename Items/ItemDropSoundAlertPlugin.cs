namespace Turbo.Plugins.Jack.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.TextToSpeech;

    public class ItemDropSoundAlertPlugin : BasePlugin, ILootGeneratedHandler, IAfterCollectHandler
    {
        public bool Legendary { get; set; }
        public bool AncientLegendary { get; set; }
        public bool PrimalAncientLegendary { get; set; }
        public bool Set { get; set; }
        public bool AncientSet { get; set; }
        public bool PrimalAncientSet { get; set; }

        public bool Gambled { get; set; }
        public bool InTown { get; set; }

        public string AncientLegendaryNamePrefix { get; set; }
        public string PrimalAncientLegendaryNamePrefix { get; set; }
        public string AncientSetNamePrefix { get; set; }
        public string PrimalAncientSetNamePrefix { get; set; }

        public HashSet<uint> ItemSnos { get; set; }
        public HashSet<uint> AncientItemSnos { get; set; }
        public HashSet<uint> PrimalAncientItemSnos { get; set; }

        public Dictionary<uint, string> ItemCustomNames { get; set; }

        public SoundAlert<IItem> SoundAlert { get; private set; }

        public ItemDropSoundAlertPlugin()
        {
            Enabled = true;

            Legendary = false;
            AncientLegendary = false;
            PrimalAncientLegendary = true;
            Set = false;
            AncientSet = false;
            PrimalAncientSet = true;

            Gambled = true;
            InTown = true;

            AncientLegendaryNamePrefix = string.Empty;
            PrimalAncientLegendaryNamePrefix = string.Empty;
            AncientSetNamePrefix = string.Empty;
            PrimalAncientSetNamePrefix = string.Empty;

            ItemSnos = new HashSet<uint>();
            AncientItemSnos = new HashSet<uint>();
            PrimalAncientItemSnos = new HashSet<uint>();

            ItemCustomNames = new Dictionary<uint, string>();

            SoundAlert = SoundAlertFactory.Create<IItem>((item) => GetItemName(item));
        }

        public void OnLootGenerated(IItem item, bool gambled)
        {
            if (!gambled) return;
            if (!Gambled) return;

            CheckLoot(item, true);
        }

        public void AfterCollect()
        {
            if (!Hud.Game.IsInGame) return;

            var items = Hud.Game.Items.Where(item => item.Location == ItemLocation.Floor && item.LastSpeak == null && item.GetData<IItem>() == null);
            foreach (var item in items)
            {
                CheckLoot(item, false);
                item.SetData<IItem>(item);
            }
        }

        public void CheckLoot(IItem item, bool gambled)
        {
            if (item.LastSpeak != null) return;
            if (Hud.Game.IsInTown && !InTown && !gambled) return;

            if (item.SetSno != uint.MaxValue)
            {
                switch (item.AncientRank)
                {
                    case 1:
                        if (AncientSet) MarkSoundAlert(item);
                        break;

                    case 2:
                        if (PrimalAncientSet) MarkSoundAlert(item);
                        break;

                    default:
                        if (Set) MarkSoundAlert(item);
                        break;
                }
            }
            else if (item.IsLegendary)
            {
                switch (item.AncientRank)
                {
                    case 1:
                        if (AncientLegendary) MarkSoundAlert(item);
                        break;

                    case 2:
                        if (PrimalAncientLegendary) MarkSoundAlert(item);
                        break;

                    default:
                        if (Legendary) MarkSoundAlert(item);
                        break;
                }
            }

            if (ItemSnos.Contains(item.SnoItem.Sno))
            {
                MarkSoundAlert(item);
                return;
            }
            if (item.AncientRank == 1 && AncientItemSnos.Contains(item.SnoItem.Sno))
            {
                MarkSoundAlert(item);
                return;
            }
            if (item.AncientRank == 2 && PrimalAncientItemSnos.Contains(item.SnoItem.Sno))
            {
                MarkSoundAlert(item);
                return;
            }
        }

        public string GetItemName(IItem item)
        {
            var name = ItemCustomNames.Where(n => n.Key == item.SnoItem.Sno).Select(n => n.Value).FirstOrDefault() ?? item.SnoItem.NameLocalized;

            if (item.AncientRank == 0) return name;

            if (item.SetSno != uint.MaxValue)
            {
                switch (item.AncientRank)
                {
                    case 1:
                        name = string.Join(" ", AncientSetNamePrefix, name);
                        break;

                    case 2:
                        name = string.Join(" ", PrimalAncientSetNamePrefix, name);
                        break;
                }
            }
            else
            {
                switch (item.AncientRank)
                {
                    case 1:
                        name = string.Join(" ", AncientLegendaryNamePrefix, name);
                        break;

                    case 2:
                        name = string.Join(" ", PrimalAncientLegendaryNamePrefix, name);
                        break;
                }
            }

            return name;
        }

        private void MarkSoundAlert(IItem item)
        {
            SoundAlertManagerPlugin.Register(item, SoundAlert);
        }
    }
}