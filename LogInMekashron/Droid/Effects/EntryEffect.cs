using System;
using LogInMekashron.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ResolutionGroupName("Mekashron")]
[assembly: ExportEffect(typeof(EntryEffect), "EntryEffect")]
namespace LogInMekashron.Droid.Effects
{
    public class EntryEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is EntryEditText)
            {
                Control.SetBackgroundColor(Android.Graphics.Color.Red);
            }
        }

        protected override void OnDetached()
        {
            Control.SetBackgroundColor(Android.Graphics.Color.White);
        }
    }
}
