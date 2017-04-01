using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Turbo.Plugins.Jack.TextToSpeech
{
    public class SoundAlert<T> where T : IActor
    {
        public Func<T, string> TextFunc { get; set; }
        public string LastText { get; set; }
    }
}
