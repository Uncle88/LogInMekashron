using System;

using Xamarin.Forms;
using LogInMekashron.Services;
using System.ComponentModel;
using LogInMekashron.Network;

namespace LogInMekashron.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        public LogInViewModel() { }

        private Command _clickCommand;
        private string _inLogIn;
        private string _inPassword;
        private LogInService _logInServiсe;

        public string InLogIn
        {
            get { return _inLogIn; }
            set
            {
                _inLogIn = value;
                OnPropertyChanged(nameof(InLogIn));
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

