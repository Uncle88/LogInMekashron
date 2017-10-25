using System;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using LogInMekashron.Dialog;
using LogInMekashron.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogInMekashron.Droid.DialogService.DialogService))]
namespace LogInMekashron.Droid.DialogService
{
    public class DialogService : IDialogService
    {
        void IDialogService.ShowMessage(string Message)
        {
            //var alert = new AlertDialog.Builder(this);
            //alert.SetView(LayoutInflater.Inflate(Resource.Layout.Modal, null));
            //alert.Create().Show();

            AlertDialog.Builder bilder = new AlertDialog.Builder(null);
            AlertDialog alertdialog = bilder.Create();
            alertdialog.SetTitle("Title");
            alertdialog.SetMessage(Message);

            alertdialog.Show();
        }
    }
}
