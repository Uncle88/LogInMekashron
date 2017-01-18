using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogInMekashron.Network
{
    public interface IRestService
    {
        Task<T> GetAsync<T>(string url);
    }
}

