namespace Turbo.Plugins.Jack.Items
{
    using System.Collections.Generic;
    using System.Linq;
    using Turbo.Plugins.Default;

    public class ItemDropSoundAlertPlugin : BasePlugin, ILootGeneratedHandler, IAfterCollectHandler
    {
        public bool Legendary { get; set; }
        public bool AncientLegendary { get; set; }
        public bool PrimalAncientLegendary { get; set; }
        public bool Set { get; set; }
        public bool AncientSet { get; set; }
        public bool PrimalAncientSet { get; set; }

        public HashSet<uint> ItemSnos { get; set; }

        public ItemDropSoundAlertPlugin()
        {
            Enabled = true;

            Legendary = false;
            AncientLegendary = false;
            PrimalAncientLegendary = true;
            Set = false;
            AncientSet = false;
            PrimalAncientSet = true;

            ItemSnos = new HashSet<uint>();
        }

        public override void Load(IController hud)
        {
            base.Load(hud);
        }

        public void AfterCollect()
        {
            var item = Hud.Game.Items.FirstOrDefault(x => x.Location == ItemLocation.Floor && x.LastSpeak != null && x.LastSpeak.IsRunning);
            if (item == null || !Hud.LastSpeak.TimerTest(2000)) return;
            Says.Debug(Hud.LastSpeak.ElapsedMilliseconds, item.SnoItem.NameLocalized);

            item.LastSpeak.Stop();
            Hud.Speak(item.SnoItem.NameLocalized);
        }

        public void OnLootGenerated(IItem item, bool gambled)
        {
            if (item.LastSpeak != null) return;

            //Says.Debug(item.SnoItem.Sno, item.SnoItem.NameEnglish);

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

            if (ItemSnos.Contains(item.SnoItem.Sno)) MarkSoundAlert(item);
        }

        private void MarkSoundAlert(IItem item)
        {
            if (item.LastSpeak != null) return;

            item.LastSpeak = Hud.CreateWatch();
            item.LastSpeak.Restart();
        }
    }
}