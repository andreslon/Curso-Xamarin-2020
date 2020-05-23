
using CedesistemasApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CedesistemasApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantDetailPage : ContentPage
    {
        public RestaurantDetailPage(ViewModels.RestaurantDetailPageViewModel restaurantDetailPageViewModel)
        {
            InitializeComponent();
            BindingContext = restaurantDetailPageViewModel;
        }
        async private void btn_address_Clicked(object sender, System.EventArgs e)
        {
            var vm = (RestaurantDetailPageViewModel)BindingContext;
            await this.Navigation.PushModalAsync(new MapPage(vm.Item.Latitud, vm.Item.Longitud, vm.Item.Nombre, vm.Item.Direccion));
        }
    }
}