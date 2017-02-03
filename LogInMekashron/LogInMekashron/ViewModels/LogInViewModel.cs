using System;
using Xamarin.Forms;
using LogInMekashron.Services;
using System.ComponentModel;
using LogInMekashron.Network;
using LogInMekashron.Dialog;
using System.Xml.Linq;
using LogInMekashron.Views;

namespace LogInMekashron.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        private Command _clickCommand;
        private string _inLogIn;
        private string _inPassword;
        private LogInService _logInServiсe;
        private DialogService _dialogService;
        private XDocument _soap;

        public LogInViewModel()
        {
            this._logInServiсe = new LogInService();
            this._dialogService = new DialogService();
        }

        public XDocument Soap
        {
            get { return _soap; }
            set
            {
                _soap = value;
                OnPropertyChanged(nameof(Soap));
            }
        }

        public string InLogIn
        {
            get { return _inLogIn; }
            set
            {
                if (string.IsNullOrEmpty(_inLogIn))
                {
                    var _loginView = new LoginView();
                    _loginView.DisplayAlert("MESSAGE", "Value does not match", "OK");
                }
                _inLogIn = value;

                OnPropertyChanged(nameof(InLogIn));
            }
        }

        public string InPassword
        {
            get { return _inPassword; }
            set
            {
                if (string.IsNullOrEmpty(_inPassword))
                {
                    var _loginView = new LoginView();
                    _loginView.DisplayAlert("MESSAGE", "Value does not match", "OK");
                }
                _inPassword = value;

                OnPropertyChanged(nameof(InPassword));
            }
        }

        public Command ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Command(async (_) =>
                 {
                     await _logInServiсe.LogIn(InLogIn, InPassword);
                     _dialogService.ShowMessage(Soap);
                 }));
            }
        }
    }
}

