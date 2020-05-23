using System;
using System.Collections.Generic;
using System.Text;

namespace CedesistemasApp.Interfaces
{
    public interface IDeviceService
    {
        bool CheckConnectivity();
        void OpenBrowser(string url);
    }
}
