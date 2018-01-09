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
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
            if (e.PropertyName == CustomEntry.IsEmptyProperty.PropertyName)
            {
                var customEntry = Element as CustomEntry;
                if (customEntry == null)
                {
                    return;
                }
                if (Control!=null)
                {
                    if (customEntry.IsEmpty)
                    {
                        Control.BorderStyle = UITextBorderStyle.RoundedRect;
                        Control.Layer.BorderColor = UIColor.Red.CGColor;
                        Control.Layer.BorderWidth = new nfloat(2.0);
                    }
                    else
                    {
                        Control.BorderStyle = UITextBorderStyle.RoundedRect;
                        Control.Layer.BorderColor = UIColor.Black.CGColor;
                        Control.Layer.BorderWidth = new nfloat(1.0);
                    }
                }
            }
        }
    }
}
