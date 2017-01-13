using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogInMekashron.Network
{
    interface IRestService
    {
        Task<T> GetAsync<T>(string url);
    }
}

