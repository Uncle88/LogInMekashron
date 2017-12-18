using System.ComponentModel;
using Foundation;
using LogInMekashron.iOS.Effects;
using UIKit;
using Xamarin.Forms;

[assembly: ResolutionGroupName("Mekashron")]
[assembly: ExportEffect(typeof(EntryEffect), "EntryEffect")]
namespace LogInMekashron.iOS.Effects
{
    public class EntryEffect : PlatformEffect<UIView, UITextField>

    {
        UIColor backgroundColor;
        protected override void OnAttached()
        {
            Control.BackgroundColor = backgroundColor = UIColor.Red;
            //if (Control is UITextField)
            //{
            //Control.BackgroundColor = UIColor.Red;
            //Control.AttributedPlaceholder = new NSAttributedString(Control.Placeholder, null, UIColor.Red);
            //}
        }

        protected override void OnDetached()
        {
            Control.BackgroundColor = UIColor.White;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);
            if (args.PropertyName == "Login")
            {
                if (Control.BackgroundColor == backgroundColor)
                {
                    Control.BackgroundColor = UIColor.White;
                }
                else
                {
                    Control.BackgroundColor = backgroundColor;
                }
            }
        }
    }
}


