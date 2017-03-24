using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using LogInMekashron;
using LogInMekashron.iOS;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace LogInMekashron.iOS
{
    public class CustomLabelRenderer : LabelRenderer
    {
        public CustomLabelRenderer()
        {
        }
    }
}
