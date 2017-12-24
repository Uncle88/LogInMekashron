using System;
using Android.Content;
using Android.Graphics.Drawables;
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
        {}

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //GradientDrawable gradientDrawable = new GradientDrawable();
                //gradientDrawable.SetColor(Element.BackgroundColor.ToAndroid());
                Control.SetBackgroundColor(global::Android.Graphics.Color.Red);
            }
        }
    }
}
