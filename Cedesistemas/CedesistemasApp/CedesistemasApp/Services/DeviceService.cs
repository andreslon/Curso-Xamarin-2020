using CedesistemasApp.Interfaces;
using CedesistemasApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceService))]
namespace CedesistemasApp.Services
{
    public class DeviceService : IDeviceService
    {
        public void Call(string phone)
        {
            try
            {
                PhoneDialer.Open(phone);
            }
            catch (ArgumentNullException anEx)
            {
                // Number was null or white space
            }
            catch (FeatureNotSupportedException ex)
            {
                // Phone Dialer is not supported on this device.
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        } 
        public bool CheckConnectivity()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                // Connection to internet is available
                return true;
            }
            return false;
        } 
        async public void OpenBrowser(string url)
        {
            var uri = new Uri(url);
            await Browser.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }



    }
}
