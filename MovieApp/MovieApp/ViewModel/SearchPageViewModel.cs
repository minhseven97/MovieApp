using MovieApp.Model;
using MovieApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModel
{
    public class SearchPageViewModel : BaseViewModel
    {
        private Movie selectedMovie;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
                OnPropertyChanged();
            }
        }
        private ObservableCollection<Movie> watchList;
        public ObservableCollection<Movie> WatchList
        {
            get { return watchList; }
            set
            {
                watchList = value;
                OnPropertyChanged();
            }
        }
        public ICommand SelectionCommand => new Command(() =>
        {
            if (selectedMovie != null)
            {
                var vm = new DetailViewModel { SelectedMovie = selectedMovie };
                var page = new DetailPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });
    }
}
