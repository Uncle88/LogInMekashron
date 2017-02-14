using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using LogInMekashron.Network;


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

            string myResult = await response.Content.ReadAsStringAsync();

            XDocument doc = XDocument.Parse(myResult);
            return doc;
        }
    }
}

