using CedesistemasApp.Interfaces;
using CedesistemasApp.Models;
using CedesistemasApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace CedesistemasApp.ViewModels
{
    public class RestaurantsPageViewModel : BaseViewModel
    {   public ObservableCollection<RestaurantModel> Restaurantes { get; set; }

        public RestaurantsPageViewModel()
        {
            Restaurantes = new ObservableCollection<RestaurantModel>();
            LoadRestaurants();
        }
        async private void LoadRestaurants()
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            if (deviceService.CheckConnectivity())
            {
                IsRefreshing = true;
                foreach (var item in await new RestaurantRepository().GetRestaurants())
                {
                    Restaurantes.Add(item);
                }
                IsRefreshing = false;
            } 
        }
    }
}
