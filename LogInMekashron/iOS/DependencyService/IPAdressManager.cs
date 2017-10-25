using System;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using LogInMekashron.LogIn;
using Xamarin.Forms;


[assembly: Dependency(typeof(LogInMekashron.iOS.DependencyService.IPAdressManager))]



namespace LogInMekashron.iOS.DependencyService
{
    public class IPAdressManager : IIPAddressManager
    {
        public string GetIPAddress()
        {
            {
                String ipAddress = "";

                foreach (var netInterface in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (netInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    {
                        foreach (var addrInfo in netInterface.GetIPProperties().UnicastAddresses)
                        {
                            if (addrInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddress = addrInfo.Address.ToString();

                            }
                        }
                    }
                }

                return ipAddress;
            }
        }
    }
}
