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
        LoginView _loginView;

        //public void ShowMessage1(string Message)
        //{
        //    _loginView = new LoginView();
        //    _loginView.DisplayAlert("Message", Message, "OK");
        //}

        public void ShowMessage(string Message)
        {
            _loginView = new LoginView();
            Device.BeginInvokeOnMainThread(() =>
            {
                _loginView.DisplayAlert("title", Message, "OK");
            });

        }
    }
}