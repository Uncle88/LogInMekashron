using System.Threading.Tasks;
using LogInMekashron.Dialog;
using LogInMekashron.Helpers;
using LogInMekashron.LogIn;
using LogInMekashron.Model;
using LogInMekashron.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace LogInMekashron.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private Command _clickCommand;
        private string _login;
        private string _password;
        private ILoginService _loginServiсe;
        private IDialogService _dialogService;

        public LoginViewModel()
        {
            _loginServiсe = new LogInService();
            _dialogService = new DialogService();
        }

        public string Login
        {
            get { return _login; }
            set
            {
                if (value != _login)
                {
                    _login = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command ClickCommand
        {
            get
            {
                return _clickCommand ?? (_clickCommand = new Command(async (_) =>
                {
                    if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
                    {
                        ColorEffect();
                        return;
                    }
                    await GetData();
                }));
            }
        }

        public void ColorEffect()
        {
            var _entry = new Entry();
            _entry.Effects.Add(Effect.Resolve("LogInMekashron.EntryEffect"));
            OnPropertyChanged(Login);
            //_entryEffect.Element.Effects.Add(Effect.Resolve("LogInMekashron.EntryEffect"));
        }

        public async Task GetData()
        {
            var doc = await _loginServiсe.Login(Login, Password);
            string Message = DialogFilter.LinqFilter(doc);
            ResponseObject obj = JsonConvert.DeserializeObject<ResponseObject>(Message);
            _dialogService.ShowMessage(obj.ResultMessage);
        }
    }
}