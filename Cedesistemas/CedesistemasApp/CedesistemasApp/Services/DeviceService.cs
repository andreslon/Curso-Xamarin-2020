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
    }
}
