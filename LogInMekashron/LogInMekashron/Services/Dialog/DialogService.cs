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

        public DialogService()
        {
            //_loginView = new LoginView();
        }

        public void ShowMessage(string Message)
        {
            _loginView.DisplayAlert("Message", Message, "OK");
        }
    }
}