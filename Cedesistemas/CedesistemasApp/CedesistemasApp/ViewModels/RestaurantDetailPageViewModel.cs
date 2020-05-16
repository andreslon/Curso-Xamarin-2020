using CedesistemasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CedesistemasApp.ViewModels
{
    public class RestaurantDetailPageViewModel
    {
        public RestaurantModel Item { get; set; }
        public RestaurantDetailPageViewModel(RestaurantModel item)
        {
            Item = item;
        }
    }
}
