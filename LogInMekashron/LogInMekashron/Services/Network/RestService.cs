using System;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace LogInMekashron.Services
{
    public class RestService : ContentPage
    {
        public async Task<T> GetAsync<T>(string url)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);
                return await ProcessResponse<T>(response);
            }
        }

        async Task<T> ProcessResponse<T>(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsStringAsync();
            return default(T);
        }
    }
}

