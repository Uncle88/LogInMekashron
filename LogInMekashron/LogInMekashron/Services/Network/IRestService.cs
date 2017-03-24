using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LogInMekashron.Network
{
    public interface IRestService
    {
        Task<XDocument> GetAsync<T>(string url, StringContent content);
    }
}

