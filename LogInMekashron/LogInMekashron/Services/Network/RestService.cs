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
        //string url = "http://isapi.mekashron.com/StartAJob/General.dll";
        //private string xmlMessage = "<? xml version = \"1.0\" encoding = \"UTF-8\" ?>\r\n" +
        //"< env : Envelope xmlns: env = \"http://www.w3.org/2003/05/soap-envelope\" " +
        //  "xmlns: ns1 = \"urn:General.Intf-IGeneral\" " +
        //  "xmlns: xsd = \"http://www.w3.org/2001/XMLSchema\" " +
        //  "xmlns: xsi = \"http://www.w3.org/2001/XMLSchema-instance\" " +
        //  "xmlns: enc = \"http://www.w3.org/2003/05/soap-encoding\" >" +
        //  "< env:Body >< ns1:Login env:encodingStyle = \"http://www.w3.org/2003/05/soap-encoding\" >" +
        //  "< UserName xsi: type = \"xsd:string\" > user_Andrey </ UserName >" +
        //  "< Password xsi: type = \"xsd:string\" > user_Andrey </ Password >" +
        //  "< IP xsi: type = \"xsd:string\" ></ IP ></ ns1:Login ></ env:Body ></ env:Envelope >";

        public async Task<T> GetAsync<T>(string url, string InLogIn, string InPassword)
        {
            var soapString = this.ConstructSoapRequest(InLogIn, InPassword);
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("SOAPAction", "http://isapi.mekashron.com/StartAJob/General.dll");
                var content = new StringContent(soapString, Encoding.UTF8, "text/xml");

                using (var response = await client.PostAsync(url, content))
                {
                    var soapResponse = await response.Content.ReadAsStringAsync();
                    return (T)this.ParseSoapResponse(soapResponse);
                }

                //var response = await client.GetAsync(url);
                //var content = await response.Content.ReadAsStringAsync();
                //var temp = Encoding.UTF8.GetBytes(content);
                //using (var stream = new MemoryStream(temp))
                //{
                //var serializer = new XmlSerializer(typeof(T));
                //return (T)serializer.Deserialize(stream);
                //}
            }
        }

        object ParseSoapResponse(string soapResponse)
        {
            var soap = XDocument.Parse(soapResponse);
            XNamespace ns = "http://isapi.mekashron.com/";
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
            "< IP xsi: type = \"xsd:string\" ></ IP ></ ns1:Login ></ env:Body ></ env:Envelope >", inLogIn, inPassword);
        }
    }
}

