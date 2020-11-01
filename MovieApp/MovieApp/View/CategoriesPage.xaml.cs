using MovieApp.Model;
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
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            List1.SelectedItem = null;
            List2.SelectedItem = null;
            List3.SelectedItem = null;
            List<Movie> listTem = new List<Movie>();
            List<Movie> listTem1 = new List<Movie>();
            var vm = (CategoriesViewModel)BindingContext;
            var WatchList = vm.WatchList;
            foreach (Movie item in WatchList)
            {
                if (item.Category == "Action")
                {
                    listTem.Add(item);
                }
            }
            foreach (Movie item in WatchList)
            {
                if (item.Category == "Funny")
                {
                    listTem1.Add(item);
                }
            }
            List1.ItemsSource = WatchList;
            List2.ItemsSource = listTem1;
            List3.ItemsSource = listTem;
        }
    }
}