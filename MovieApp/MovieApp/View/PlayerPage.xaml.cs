using MediaManager;
using MovieApp.Core;
using MovieApp.ViewModel;
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
    public partial class PlayerPage : ContentPage
    {
        HistoryViewModel firebaseHelper = new HistoryViewModel();
        public PlayerPage()
        {
            InitializeComponent();
            DependencyService.Get<IOrientationHandler>().ForceLandscape();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CrossMediaManager.Current.Stop();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            DateTime dt = DateTime.Now;
            string dateview = dt.ToString("dd/MM/yyyy");
            await firebaseHelper.AddHis(App.Name1, dateview, App.Seleted1);
        }
    }
}