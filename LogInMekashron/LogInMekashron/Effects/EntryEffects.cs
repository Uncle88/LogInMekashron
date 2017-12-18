using System;
using Xamarin.Forms;

namespace LogInMekashron.Effects
{
    public class EntryEffects : RoutingEffect
    {
        public Color BackGround { get; set; }

        public EntryEffects() : base("LogInMekashron.EntryEffect")
        {
        }
    }
}
