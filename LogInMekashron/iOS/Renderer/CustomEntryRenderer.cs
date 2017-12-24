using System;
using LogInMekashron.iOS.Renderer;
using LogInMekashron.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace LogInMekashron.iOS.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var entry = e.NewElement; 

            if (Control != null)
            {
                Control.BackgroundColor = UIColor.Red;
            }
        }
    }
}
