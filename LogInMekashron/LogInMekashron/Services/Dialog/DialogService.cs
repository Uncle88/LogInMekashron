using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using LogInMekashron.Services;
using System.Xml.Linq;
using System.Linq;
using LogInMekashron.Views;


namespace LogInMekashron.Dialog
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string Message)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Application.Current.MainPage.DisplayAlert("Message", Message, "OK");
            });
        }
    }
}