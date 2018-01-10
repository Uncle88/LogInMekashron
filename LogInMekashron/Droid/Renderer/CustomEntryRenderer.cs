using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Widget;
using LogInMekashron.Droid.Renderer;
using LogInMekashron.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace LogInMekashron.Droid.Renderer
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        { }

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
                if (Control != null)
                {
                    if (customEntry.IsEmpty)
                    {
                        var background = new GradientDrawable();
                        background.SetStroke(2, Android.Graphics.Color.Red);
                        background.SetCornerRadius(3.0f);
                        Control.Background = background;
                    }
                    else
                    {
                        var background = new GradientDrawable();
                        background.SetStroke(1, Android.Graphics.Color.Black);
                        background.SetCornerRadius(3.0f);
                        Control.Background = background;
                    }
                }
            }
        }
    }
}

