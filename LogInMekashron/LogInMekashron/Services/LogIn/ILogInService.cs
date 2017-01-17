using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogInMekashron.LogIn
{
    interface ILogInService
    {
        Task LogIn(string InLogIn, string InPassword);
    }
}

