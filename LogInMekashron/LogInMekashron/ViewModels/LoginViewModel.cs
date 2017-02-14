using LogInMekashron.Dialog;
using LogInMekashron.LogIn;
using LogInMekashron.Services;
using Xamarin.Forms;
using System.Xml.Linq;
using LogInMekashron.Helpers;
using LogInMekashron.Views;
using System.Threading.Tasks;

namespace LogInMekashron.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Command _clickCommand;
        private string _login;
        private string _password;
        private ILoginService _loginServiсe;
        private IDialogService _dialogService;
        private XDocument _doc;
        private string _message;

        public LoginViewModel()
        {
            _loginServiсe = new LogInService();
            _dialogService = new DialogService();
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public XDocument doc
        {
            get { return _doc; }
            set
            {
                _doc = value;
                OnPropertyChanged(nameof(doc));
            }
        }

        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public Command ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Command(async (_) =>//
                {
                    if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                    {
                        return;
                    }
                    XDocument doc1 = await _loginServiсe.Login(Login, Password);
                    string Message1 = DialogFilter.LinqFilter(doc1);
                    _dialogService.ShowMessage(Message1);
                }));
            }
        }
    }
}

