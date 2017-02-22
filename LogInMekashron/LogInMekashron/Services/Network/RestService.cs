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
using LogInMekashron.Network;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.Diagnostics.Contracts;


namespace LogInMekashron.Services
{
    public class RestService : IRestService
    {
        public async Task<XDocument> GetAsync<T>(string url, StringContent content)
        {
            var client = new HttpClient();
            var uri = new Uri(url);

            content.Headers.TryAddWithoutValidation("Content-Type", "text/xml;charset=utf-8");
            content.Headers.TryAddWithoutValidation("SOAPAction", "urn:General.Intf-IGeneral");

            var response = await client.PostAsync(uri, content);

            string myResult = await response.Content.ReadAsStringAsync();//var soapRespons

            XDocument doc = XDocument.Parse(myResult);
            return doc;//soapResponse;//!!!
        }

    }
}

