
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using LogInMekashron.LogIn;
using LogInMekashron.Network;
using Xamarin.Forms;

namespace LogInMekashron.Services
{
    public class LogInService : ILoginService
    {
        private const string Url = "http://isapi.mekashron.com/StartAJob/General.dll/soap/ILogin";
        private IRestService _restService;
        public XDocument doc { get; set; }

        public LogInService()
        {
            _restService = new RestService();
        }

        public async Task<XDocument> Login(string login, string password)
        {
            var soapString = this.ConstructSoapRequest(login, password, ipaddress);
            var content = new StringContent(soapString, Encoding.UTF8, "application/xml");
            var doc = await _restService.GetAsync<string>(Url, content);
            return doc;
        }

        string ipaddress = DependencyService.Get<IIPAddressManager>().GetIPAddress();

        private string ConstructSoapRequest(string login, string password, string ipaddress)
        {
            string xmlString = string.Format(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                    <env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"" 
                    xmlns:ns1=""urn:General.Intf-IGeneral"" 
                    xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
                    xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
                    xmlns:enc=""http://www.w3.org/2003/05/soap-encoding"">
                    <env:Body>
                        <ns1:Login env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding"">
                                <UserName xsi:type=""xsd:string"">{0}</UserName>
                                <Password xsi:type=""xsd:string"">{1}</Password>
                                <IP xsi:type=""xsd:string"">{2}</IP>
                            </ns1:Login>
                        </env:Body>
                    </env:Envelope>", login, password, ipaddress);
            return xmlString;
        }
    }
}

