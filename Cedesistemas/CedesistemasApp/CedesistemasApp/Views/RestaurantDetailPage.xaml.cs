
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
    }
}