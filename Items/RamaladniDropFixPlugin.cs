namespace Turbo.Plugins.Jack.Items
{
    using System.Linq;
    using Turbo.Plugins.Default;
    using Turbo.Plugins.Jack.TextToSpeech;

    public class RamaladniDropFixPlugin : BasePlugin, IAfterCollectHandler
    {
        public SoundAlert<IItem> SoundAlert { get; private set; }

        public RamaladniDropFixPlugin()
        {
            Enabled = true;

            SoundAlert = SoundAlertFactory.Create<IItem>((item) => item.SnoItem.NameLocalized);
        }

        public void AfterCollect()
        {
            var gifts = Hud.Game.Items.Where(item => item.SnoItem.Sno == 1844495708 && item.Location == ItemLocation.Floor && item.LastSpeak == null && item.Unidentified/*.*/);
            foreach (var gift in gifts)
            {
                SoundAlertManagerPlugin.Register<IItem>(gift, SoundAlert);
            }
        }
    }
}