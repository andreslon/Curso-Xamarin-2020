using CedesistemasApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace CedesistemasApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new LoginPage();


        }

        protected override void OnStart()
        {
            AppCenter.Start("android=3e462661-d0d6-4926-923d-9dd118ff12b4;",
                  typeof(Analytics), typeof(Crashes));

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        } 
    }
}
