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

namespace LogInMekashron.Services
{
    public class RestService : IRestService
    {
        private const string Url = "http://isapi.mekashron.com"; //StartAJob/General.dll?mode=default

        public async Task<T> GetAsync<T>(string url, string InLogIn, string InPassword)
        {

            var soapString = this.ConstructSoapRequest(InLogIn, InPassword);
            var client = new HttpClient();
            client.BaseAddress = new Uri(Url);
            client.DefaultRequestHeaders.Add("SOAPAction", Url);

            var content = new StringContent(soapString, Encoding.UTF8, "application/xml");
            var response = await client.PostAsync(Url, content);//!!!

            var soapResponse = await response.Content.ReadAsStringAsync();
            return (T)this.ParseSoapResponse(soapResponse);
        }

        object ParseSoapResponse(string soapResponse)
        {
            var soap = XDocument.Parse(soapResponse);
            XNamespace ns = "http://isapi.mekashron.com";//StartAJob/General.dll?mode=default
            var rez = soap.Descendants(ns + "AddResponse").First().Element(ns + "AddResult").Value;
            return rez;
        }

        private string ConstructSoapRequest(string inLogIn, string inPassword)
        {
            String xmlString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" xmlns:ns1=""urn:General.Intf-IGeneral"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:enc=""http://www.w3.org/2003/05/soap-encoding""><env:Body><ns1:Login env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding""><UserName xsi:type=""xsd:string"">A</UserName><Password xsi:type=""xsd:string"">Z</Password><IP xsi:type=""xsd:string"">3</IP></ns1:Login></env:Body></env:Envelope>";

            return xmlString;
        }
    }
}

