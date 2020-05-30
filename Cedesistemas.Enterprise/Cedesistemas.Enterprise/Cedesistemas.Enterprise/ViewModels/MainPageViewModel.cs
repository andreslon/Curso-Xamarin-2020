using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cedesistemas.Enterprise.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand GoToRestaurantsCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            GoToRestaurantsCommand = new Command(GoToRestaurants);
        }

        async private void GoToRestaurants(object obj)
        {
            var parameters = new NavigationParameters();
            parameters.Add("Id", Guid.NewGuid());
            await NavigationService.NavigateAsync("RestaurantsPage", parameters);
        }
    }
}
