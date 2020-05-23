using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CedesistemasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public MapPage(double latitud, double longitud, string name, string address)
        {
            Latitud = latitud;
            Longitud = longitud;
            Name = name;
            Address = address;
            InitializeComponent();
            SetPin( );
        }

        private void SetPin( )
        {
            var position = new Position(Latitud, Longitud);
            Pin pin = new Pin
            {
                Label = Name,
                Address = Address,
                Type = PinType.Place,
                Position = position
            };
            map.Pins.Add(pin);

            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));
            map.MoveToRegion(mapSpan);
        }

        async private void btn_close_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopModalAsync(true);
        }

        async private void btn_navigate_Clicked(object sender, EventArgs e)
        {
            var location = new Location(Latitud, Longitud);
            var options = new MapLaunchOptions { Name = Name };

            await Xamarin.Essentials.Map.OpenAsync(location, options);
        }
    }
}