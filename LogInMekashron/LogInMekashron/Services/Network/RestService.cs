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

namespace LogInMekashron.Services
{
    public class RestService : IRestService
    {
        private const string Url = "http://isapi.mekashron.com/StartAJob/General.dll?mode=default";

        public async Task<T> GetAsync<T>(string url, string InLogIn, string InPassword)
        {
            var soapString = this.ConstructSoapRequest(InLogIn, InPassword);
            var client = new HttpClient();

            HttpContent httpContent = new StringContent(soapString);
            HttpResponseMessage response;

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, Url);
            string SOAPAction = "";
            req.Headers.Add("SOAPAction", SOAPAction);
            req.Method = HttpMethod.Post;
            req.Content = httpContent;
            req.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml; charset=utf-8");

            response = await client.SendAsync(req);

            var responseBodyAsText = await response.Content.ReadAsStringAsync();
            return (T)this.ParseSoapResponse(responseBodyAsText);

        }

        object ParseSoapResponse(string soapResponse)
        {
            var soap = XDocument.Parse(soapResponse);
            XNamespace ns = "http://isapi.mekashron.com/StartAJob/General.dll?mode=default";
            var rez = soap.Descendants(ns + "AddResponse").First().Element(ns + "AddResult").Value;
            return rez;
        }

        private string ConstructSoapRequest(string inLogIn, string inPassword)
        {
            return String.Format(@"<? xml version = \1.0\ encoding = \UTF-8\ ?>\r\n" +
        "< env : Envelope xmlns: env = \"http://www.w3.org/2003/05/soap-envelope\" " +
            "xmlns: ns1 = \"urn:General.Intf-IGeneral\" " +
            "xmlns: xsd = \"http://www.w3.org/2001/XMLSchema\" " +
            "xmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\" " +
            "xmlns: enc = \"http://www.w3.org/2003/05/soap-encoding\" >" +
            "< env:Body >< ns1:Login env:encodingStyle = \"http://www.w3.org/2003/05/soap-encoding\" >" +
                                 "< UserName xsi: type = \"xsd:string\" > {0} </ UserName >" +
                                 "< Password xsi: type = \"xsd:string\" > {1} </ Password >" +
                                 "< IP xsi: type = \"xsd:string\" > 3 </ IP ></ ns1:Login ></ env:Body ></ env:Envelope >", inLogIn, inPassword);
        }
    }
}

