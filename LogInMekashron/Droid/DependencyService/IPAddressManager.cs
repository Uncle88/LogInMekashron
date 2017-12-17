using System.Net;
using LogInMekashron.LogIn;


[assembly: Xamarin.Forms.Dependency(typeof(LogInMekashron.Droid.DependencyService.IPAddressManager))]
namespace LogInMekashron.Droid.DependencyService
{
    class IPAddressManager : IIPAddressManager
    {
        public string GetIPAddress()
        {
            IPAddress[] adresses = Dns.GetHostAddresses(Dns.GetHostName());

            if (adresses != null && adresses[0] != null)
            {
                return adresses[0].ToString();
            }
            else
            {
                return null;
            }
        }
    }
}
