using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Turbo.Plugins.Default;
using Turbo.Plugins.Jack.Decorators;

namespace Turbo.Plugins.Jack.Customize
{
    public class SoundAlertCustomizer : BasePlugin, ICustomizer
    {
        public SoundAlertCustomizer()
        {
            Enabled = true;
        }

        public void Customize()
        {
            Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            {
                plugin.EnableSpeak = false; //just in case the default change

                foreach (var deco in plugin.AllGoblinDecorators())
                {
                    deco.Add(new SoundAlertDecorator(Hud)
                    {
                        TextFunc = (actor) => actor.SnoActor.NameLocalized,
                    });
                }
            });

            //Hud.RunOnPlugin<GoblinPlugin>(plugin =>
            //{
            //    plugin.EnableSpeak = false; //just in case the default change

            //    var soundAlert = new SoundAlertDecorator(Hud);

            //    plugin.MalevolentTormentorDecorator;
            //    plugin.BloodThiefDecorator;
            //    plugin.OdiousCollectorDecorator;
            //    plugin.GemHoarderDecorator;
            //    plugin.GelatinousDecorator;
            //    plugin.GildedBaronDecorator;
            //    plugin.InsufferableMiscreantDecorator;
            //    plugin.DefaultGoblinDecorator;
            //    plugin.RainbowGoblinDecorator;
            //    plugin.MenageristGoblinDecorator;
            //    plugin.TreasureFiendGoblinDecorator;


            //});

            Enabled = false;
        }
    }
}
