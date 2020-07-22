using MediaManager;
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
    public partial class PlayerPage : ContentPage
    {
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
    }
}