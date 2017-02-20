using LogInMekashron.Dialog;
using LogInMekashron.LogIn;
using LogInMekashron.Services;
using Xamarin.Forms;
using System.Xml.Linq;
using LogInMekashron.Helpers;
using LogInMekashron.Views;
using System.Threading.Tasks;
using LogInMekashron.Model;
using Newtonsoft.Json;

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
                    XDocument doc = await _loginServiсe.Login(Login, Password);
                    string Message1 = DialogFilter.LinqFilter(doc);
                    RootObject obj = JsonConvert.DeserializeObject<RootObject>(Message1);

                    FormattedString formattedString = new FormattedString();
                    formattedString.Spans.Contains(new Span
                    {
                        Text = obj.ResultMessage,
                        ForegroundColor = Color.Orange
                    });

                    _dialogService.ShowMessage(obj.ResultMessage);
                }));
            }
        }
    }
}

