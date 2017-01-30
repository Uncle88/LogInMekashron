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
        private const string Url = "http://isapi.mekashron.com/StartAJob/General.dll/soap/ILogin";
        public async Task<T> GetAsync<T>(string url, string InLogIn, string InPassword)
        {
            var uri = new Uri(Url);
            var soapString = this.ConstructSoapRequest(InLogIn, InPassword);
            var client = new HttpClient();

            var content = new StringContent(soapString, Encoding.UTF8, "application/xml");
            content.Headers.TryAddWithoutValidation("Content-Type", "text/xml;charset=utf-8");
            content.Headers.TryAddWithoutValidation("SOAPAction", "urn:General.Intf-IGeneral");

            var response = await client.PostAsync(uri, content);

            var soapResponse = await response.Content.ReadAsStringAsync();
            return (T)this.ParseSoapResponse(soapResponse);
        }

        object ParseSoapResponse(string soapResponse)
        {
            var soap = XDocument.Parse(soapResponse);
            //XNamespace ns = "http://www.borland.com/namespaces/Types";//http://isapi.mekashron.comStartAJob/General.dll?mode=default
            //var rez = soap.Descendants(ns + "AddResponse").First().Element(ns + "AddResult").Value;
            return soap;
        }

        private string ConstructSoapRequest(string inLogIn, string inPassword)
        {
            string xmlString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" 
    xmlns:ns1=""urn:General.Intf-IGeneral"" 
    xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
    xmlns:enc=""http://www.w3.org/2003/05/soap-encoding"">
    <env:Body>
        <ns1:Login env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding"">
            <UserName xsi:type=""xsd:string"">Andrey</UserName>
            <Password xsi:type=""xsd:string"">Yep</Password>
            <IP xsi:type=""xsd:string"">120.23.43.23</IP>
        </ns1:Login>
    </env:Body>
</env:Envelope>";
            return xmlString;
        }
    }
}

