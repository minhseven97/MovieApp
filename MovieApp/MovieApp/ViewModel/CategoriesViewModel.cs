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
    public class CategoriesViewModel: BaseViewModel
    {
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
        private Movie selectedMovie3;
        private Movie selectedMovie1;
        private Movie selectedMovie2;
        public Movie SelectedMovie3
        {
            get { return selectedMovie3; }
            set
            {
                selectedMovie3 = value;
                OnPropertyChanged();
            }
        }
        public Movie SelectedMovie1
        {
            get { return selectedMovie1; }
            set
            {
                selectedMovie1 = value;
                OnPropertyChanged();
            }
        }
        public Movie SelectedMovie2
        {
            get { return selectedMovie2; }
            set
            {
                selectedMovie2 = value;
                OnPropertyChanged();
            }
        }
        public ICommand Selection1Command => new Command(() =>
        {
            if (selectedMovie1 != null)
            {
                var vm = new DetailViewModel { SelectedMovie = selectedMovie1 };
                var page = new DetailPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });
        //chọn phim từ list funny
        public ICommand Selection2Command => new Command(() =>
        {
            if (selectedMovie2 != null)
            {
                var vm1 = new DetailViewModel { SelectedMovie = selectedMovie2 };
                var page1 = new DetailPage { BindingContext = vm1 };
                Application.Current.MainPage.Navigation.PushAsync(page1);
            }
        });
        //chọn phim từ list hành đọng
        public ICommand Selection3Command => new Command(() =>
        {
            if (selectedMovie3 != null)
            {
                var vm2 = new DetailViewModel { SelectedMovie = selectedMovie3 };
                var page2 = new DetailPage { BindingContext = vm2 };
                Application.Current.MainPage.Navigation.PushAsync(page2);
            }
        });
    }
}
