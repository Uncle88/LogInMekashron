using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogInMekashron.LogIn
{
    interface ILoginService
    {
        Task Login(string logIn, string password);
    }
}

