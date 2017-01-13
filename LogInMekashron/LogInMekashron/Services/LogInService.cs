using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogInMekashron.Services
{
    public class LogInService
    {
        private RestService _restService;

        public LogInService()
        {
            _restService = new RestService();
        }

        public async Task LogIn(string InLogIn, string InPassword)
        {
            var response = await _restService.GetAsync<object>("/account/login.json");


            return;
        }
    }
}

