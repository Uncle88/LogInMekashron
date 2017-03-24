using LogInMekashron;
using LogInMekashron.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace LogInMekashron.Droid
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer()
        {
        }
    }
}
