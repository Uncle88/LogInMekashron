using System;
using System.Threading.Tasks;
using LogInMekashron.LogIn;
using Xamarin.Forms;

namespace LogInMekashron.Services
{
    public class LogInService : ILogInService
    {
        private RestService _restService;

        public LogInService()
        {
            _restService = new RestService();
        }

        public async Task LogIn(string InLogIn, string InPassword)
        {
            await _restService.GetAsync<object>("text/xml", InLogIn, InPassword);
            return;
        }
    }
}

