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
        public ICommand OpenUrlCommand { get; set; }
        public ICommand CallCommand { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        public RestaurantModel Item { get; set; }
        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            OpenUrlCommand = new Command(OpenUrl);

            CallCommand = new Command(Call);
            Item = item;
            Products = new ObservableCollection<ProductModel>();
            LoadProducts();
        }
        async private void LoadProducts()
        { 
            foreach (var item in await new RestaurantRepository().GetProducts(Item.Id))
            {
                Products.Add(item);
            } 
        }
        private void OpenUrl(object url) 
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.OpenBrowser(url.ToString());
        }
        private void Call(object phone)
        {
            var deviceService = DependencyService.Get<IDeviceService>();
            deviceService.Call(phone.ToString());
        }
    }
}
