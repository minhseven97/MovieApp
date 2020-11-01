using MovieApp.Model;
using MovieApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private List<History> allHis;
        public List<History> AllHis
        {
            get { return allHis; }
            set
            {
                allHis = value;
                OnPropertyChanged();
            }
        }
        HistoryViewModel firebaseHelper = new HistoryViewModel();
        public HistoryPage()
        {
            InitializeComponent();
            //loading.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //loading.IsVisible = true;
            AllHis = await firebaseHelper.GetAllHis();
            var vm = (HistoryViewModel)BindingContext;
            var listsearchmovie = vm.WatchListHis;
            List<Movie> listTem = new List<Movie>();
            foreach (var item in AllHis)
            {
                if(item.NameUser == App.Name1)
                {
                    foreach (var item1 in listsearchmovie)
                    {
                        if (item1.MovieId == item.NameMovie)
                        {
                            listTem.Add(item1);
                        }
                    }
                }
            }
            listTem.Reverse();
            ListHistory.ItemsSource = listTem;
            //loading.IsVisible = false;
            ListHistory.SelectedItem = null;
        }
    }
}