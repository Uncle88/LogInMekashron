using System;
using Xamarin.Forms;
using LogInMekashron.Services;
using System.ComponentModel;
using LogInMekashron.Network;

namespace LogInMekashron.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {


        private Command _clickCommand;
        private string _inLogIn;
        private string _inPassword;
        private LogInService _logInServiсe;

        public LogInViewModel()
        {
            this._logInServiсe = new LogInService();
        }
        public string InLogIn
        {
            get { return _inLogIn; }
            set
            {
                _inLogIn = value;
                OnPropertyChanged(nameof(InPassword));
            }
        }

        public string InPassword
        {
            get { return _inPassword; }
            set
            {
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
                 }));
            }
        }

    }
}

