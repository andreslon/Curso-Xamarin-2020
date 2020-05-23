using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace CedesistemasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public MapPage(string nombre, string direccion, double latitud, double longitud)
        {
            Nombre = nombre;
            Direccion = direccion;
            Latitud = latitud;
            Longitud = longitud;
            InitializeComponent();
            SetPin();
        }

        private void SetPin()
        {
            var position = new Position(Latitud, Longitud);
            var pin = new Pin
            {
                Label = Nombre,
                Address = Direccion,
                Type = PinType.Place,
                Position = position
            };
            map.Pins.Add(pin);

            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.5));
            map.MoveToRegion(mapSpan);

        }

        async private void btn_close_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync(true);
        }
    }
}