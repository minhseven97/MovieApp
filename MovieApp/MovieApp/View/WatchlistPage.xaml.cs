using MovieApp.Core;
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
    public partial class WatchlistPage : ContentPage
    {
        public WatchlistPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();
            moviesColView.SelectedItem = null;
            moviesColView1.SelectedItem = null;
            moviesColView2.SelectedItem = null;
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

        private void SettingClick(object sender, EventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Thông báo", "Bạn chắc chắn muốn đăng xuất?", "Có", "Không");
                if (result)
                {
                    await Navigation.PushAsync(new Login());
                }
            });
        }

        private async Task HistoryClickAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HistoryPage());
        }
    }
}