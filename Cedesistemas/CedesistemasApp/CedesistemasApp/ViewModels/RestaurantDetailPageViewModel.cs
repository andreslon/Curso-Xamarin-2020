using CedesistemasApp.Interfaces;
using CedesistemasApp.Models;
using CedesistemasApp.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CedesistemasApp.ViewModels
{
    public class RestaurantDetailPageViewModel: BaseViewModel
    { 
        public ObservableCollection<ProductModel> Products { get; set; }
        public RestaurantModel Item { get; set; }
        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            Item = item;
            Products = new ObservableCollection<ProductModel>();
            LoadProducts(); 
        } 

        async private void LoadProducts()
        {
            var device = DependencyService.Get<IDeviceService>();
            if (device.CheckConnectivity())
            {
                foreach (var item in await new RestaurantRepository().GetProducts(Item.Id))
                {
                    Products.Add(item);
                }
            } 
        }
    }
}
