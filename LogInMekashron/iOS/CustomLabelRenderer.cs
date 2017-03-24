using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LogInMekashron;
using LogInMekashron.iOS;
using UIKit;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace LogInMekashron.iOS
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.Red;
            }
        }
    }
}
