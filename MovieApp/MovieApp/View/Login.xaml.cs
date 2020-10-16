using mo.Animations;
using MovieApp.Model;
using MovieApp.ViewModel;
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
        RegiterPageViewModel firebaseHelper = new RegiterPageViewModel();
        private List<Register> allPersons;
        public List<Register> AllPersons
        {
            get { return allPersons; }
            set
            {
                allPersons = value;
                OnPropertyChanged();
            }
        }
        
        public Login()
        {
            InitializeComponent();
            loading.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            loading.IsVisible = true;
            AllPersons = await firebaseHelper.GetAllAcc();
            await ViewAnimations.FadeAnimY(LoginButton);
            await ViewAnimations.FadeAnimY(SignupButton);
            loading.IsVisible = false;
        }
        //public static string Name1;
        private async Task Check()
        {
            foreach (var item in AllPersons)
            {
                if (item.UserName == txtName.Text && item.Password == txtPass1.Text)
                {
                    await Navigation.PushAsync(new WatchlistPage());
                    bien = 1;
                    App.Name1 = txtName.Text;
                    break;
                }
                else
                    bien = 2;
            }
        }
        int bien = 0;
        private async void login_click(object sender, EventArgs e)
        {
            loading.IsVisible = true;
            var IsConnected = CrossConnectivity.Current.IsConnected;
            if (IsConnected == true)
            {
                await Check();
                if(bien==2)
                    await DisplayAlert("Cảnh báo", "Sai tài khoản hoặc mật khẩu", "OK");
            }
            else
            {
                await DisplayAlert("Cảnh báo", "Bạn chưa kết nối mạng", "OK");
            }
            loading.IsVisible = false;
        }
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Thông báo", "Bạn chắc chắn muốn thoát app?", "Có", "Không");
                if (result)
                {
                    System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
                }
            });
            return true;
        }

        private async void regi_click(object sender, EventArgs e)
        {
            var IsConnected = CrossConnectivity.Current.IsConnected;
            if (IsConnected == true)
            {
                await Navigation.PushAsync(new RegiterPage());
            }
            else
            {
                await DisplayAlert("Cảnh báo", "Bạn chưa kết nối mạng", "OK");
            }
        }
    }
}