using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieApp.View;
using Xamarin.Essentials;
using MovieApp.Core;

namespace MovieApp
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjkxMzE3QDMxMzgyZTMyMmUzMG03WmVIenBrMmpmaDVnTjBTcUwwWU9aWWNsN3JhZ0t5Q3JDUmVMUVdGMzQ9");
            InitializeComponent();
            Device.SetFlags(new[] { "Expander_Experimental" });
            MainPage = new NavigationPage(new Login());
        }
        public static string Name1;
        public static string Seleted1;
        private bool _isAppRunning;
        public static bool IsNetworkDownPopupDisplayed = false;
        protected override void OnStart()
        {
            InitializeNetworkMonitor();
        }

        protected override void OnSleep()
        {
            _isAppRunning = false;
        }

        protected override void OnResume()
        {
            _isAppRunning = true;
            Connectivity_ConnectivityChanged(null, null);
        }
        public void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            if (_isAppRunning)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (!NetworkStateMonitor.NetworkIsReady() && !IsNetworkDownPopupDisplayed)
                    {
                        IsNetworkDownPopupDisplayed = true;
                        Application.Current.MainPage.DisplayAlert("Cảnh báo", "Kiểm tra lại kết nối mạng", "Ok");
                    }
                    else if (NetworkStateMonitor.NetworkIsReady() && IsNetworkDownPopupDisplayed)
                    {
                        IsNetworkDownPopupDisplayed = false;
                    }
                });
            }
        }
        private void InitializeNetworkMonitor()
        {
            if (!_isAppRunning)
                _isAppRunning = true;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
        }
    }
}
