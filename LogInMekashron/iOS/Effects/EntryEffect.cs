using System;
using Foundation;
using LogInMekashron.Effects;
using UIKit;
using Xamarin.Forms;

[assembly: ResolutionGroupName("LogInMekashron.Effects")]
[assembly: ExportEffect(typeof(EntryEffects), "EntryEffect")]
namespace LogInMekashron.iOS.Effects
{
    public class EntryEffect : PlatformEffect<UIView, UITextField>
    {
        protected override void OnAttached()
        {
            if (Control is UITextField)
            {
                Control.AttributedPlaceholder = new NSAttributedString(Control.Placeholder, null, UIColor.Red);
            }
        }

        protected override void OnDetached()
        {}
    }
}

