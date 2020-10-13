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
    public partial class SearchPage : ContentPage
    {
        public SearchPage()
        {
            InitializeComponent();
            this.BindingContext = new SearchPageViewModel();

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ListSearch.SelectedItem = null;
        }
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var vm = (SearchPageViewModel)BindingContext;
            var listsearchmovie = vm.WatchList.Where(c => c.Title.ToLower().Contains(Search.Text.ToLower()));
            ListSearch.ItemsSource = listsearchmovie;
        }
    }
}