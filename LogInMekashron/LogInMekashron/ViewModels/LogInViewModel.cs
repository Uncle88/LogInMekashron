using LogInMekashron.Dialog;
using LogInMekashron.LogIn;
using LogInMekashron.Services;
using Xamarin.Forms;

namespace LogInMekashron.ViewModels
{
    public class LogInViewModel : ViewModelBase
    {
        private Command _clickCommand;
        private string _inLogIn;
        private string _inPassword;
        private ILoginService _loginServiсe;
        private IDialogService _dialogService;

        public LogInViewModel()
        {
            _loginServiсe = new LogInService();
            _dialogService = new DialogService();
        }

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
                     if (string.IsNullOrEmpty(InLogIn) || string.IsNullOrEmpty(InPassword))
                     {
                         return;
                     }
                     await _loginServiсe.Login(InLogIn, InPassword);
                     // _dialogService.ShowMessage();
                 }));
            }
        }
    }
}

