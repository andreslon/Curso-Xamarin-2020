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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

#if DEBUG
            txt_email.Text = "admin@admin.com";
            txt_password.Text = "admin";
#endif
        } 
        private void btn_login_Clicked(object sender, EventArgs e)
        {
            string email = txt_email.Text;
            string password = txt_password.Text;

            if (email == "admin@admin.com" && password == "admin")
            {
                //Autenticación Correcta
            }
            else {
                this.DisplayAlert("Campos Incorrectos", "Email o password incorrecto", "Aceptar");
            }
        }
    }
}