using Android.Support.V7.App;
using LogInMekashron.Dialog;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogInMekashron.Droid.DialogService.DialogService))]
namespace LogInMekashron.Droid.DialogService
{
    public class DialogService : IDialogService
    {
        void IDialogService.ShowMessage(string Message)
        {
            AlertDialog.Builder bilder = new AlertDialog.Builder(null);
            AlertDialog alertdialog = bilder.Create();
            alertdialog.SetTitle("Authenticate message");
            alertdialog.SetMessage(Message);
            alertdialog.Show();
        }
    }
}
