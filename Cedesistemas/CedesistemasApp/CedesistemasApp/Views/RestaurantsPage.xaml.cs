﻿using CedesistemasApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CedesistemasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantsPage : ContentPage
    {
        public RestaurantsPage()
        {
            InitializeComponent();
            BindingContext = new RestaurantsPageViewModel();
        }
    }
}