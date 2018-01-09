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
                        //var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                        //layoutParams.SetMargins(0, 0, 0, 0);
                        //LayoutParameters = layoutParams;           
                        //Control.LayoutParameters = layoutParams;
                        //Control.SetPadding(0, 0, 0, 0);
                        //SetPadding(0, 0, 0, 0);
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}

