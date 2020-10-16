using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MovieApp.View;

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
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
