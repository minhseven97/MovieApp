using mo.Animations;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Task.Run(async () =>
            {
                await ViewAnimations.FadeAnimY(FaceButton);
                await ViewAnimations.FadeAnimY(LoginButton);
                await ViewAnimations.FadeAnimY(SignupButton);
            });
        }

        private async void login_click(object sender, EventArgs e)
        {
            var IsConnected = CrossConnectivity.Current.IsConnected;
            if (IsConnected == true)
            {
                await Navigation.PushAsync(new WatchlistPage());
            }
            else
            {
                await DisplayAlert("Cảnh báo", "Bạn chưa kết nối mạng", "OK");
            }
        }
    }
}