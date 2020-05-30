using Cedesistemas.Enterprise.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cedesistemas.Enterprise.ViewModels
{
    public class RestaurantsPageViewModel : ViewModelBase
    {
        public IDeviceService DeviceService { get; set; }
        public RestaurantsPageViewModel(IDeviceService deviceService, INavigationService navigationService):base(navigationService)
        {
            DeviceService = deviceService;
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
