using System;
using System.Collections.Generic;
using System.Text;

namespace Cedesistemas.Enterprise.Interfaces
{
    public interface IDeviceService
    {
        bool CheckConnectivity();
        void OpenBrowser(string url);
        void Call(string phone);
    }
}
