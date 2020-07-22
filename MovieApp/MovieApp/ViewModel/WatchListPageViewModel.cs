﻿using MovieApp.Model;
using MovieApp.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModel
{
    public class WatchListPageViewModel : BaseViewModel
    {
        public WatchListPageViewModel()
        {
            GetOnlineData();
        }

        public Movie FeaturedMovie => WatchList?.Where(x => x.IsFeatured == true).FirstOrDefault();


        private Movie selectedMovie;
        private Movie selectedMovie1;
        private Movie selectedMovie2;
        public Movie SelectedMovie
        {
            get { return selectedMovie; }
            set
            {
                selectedMovie = value;
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

        private ObservableCollection<Movie> watchList;
        public ObservableCollection<Movie> WatchList
        {
            get { return watchList; }
            set
            {
                watchList = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FeaturedMovie));
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
        public ICommand SelectionCommand1 => new Command(() =>
        { 
            if (selectedMovie1 != null)
            {
                var vm1 = new DetailViewModel { SelectedMovie = selectedMovie1 };
                var page1 = new DetailPage { BindingContext = vm1 };
                Application.Current.MainPage.Navigation.PushAsync(page1);
            }
        });
        public ICommand SelectionCommand2 => new Command(() =>
        {
            if (selectedMovie2 != null)
            {
                var vm2 = new DetailViewModel { SelectedMovie = selectedMovie2 };
                var page2 = new DetailPage { BindingContext = vm2 };
                Application.Current.MainPage.Navigation.PushAsync(page2);
            }
        });

        public ICommand PlayCommand => new Command(() =>
        {
            if (FeaturedMovie != null)
            {
                var vm = new PlayerViewModel { SelectedMovie = FeaturedMovie };
                var page = new PlayerPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });

        private async void GetOnlineData()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync("https://sample-notification-12baf.firebaseio.com/Movies/.json");
            var listmovie = result.Replace("null,"," ");
            WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(listmovie);
        }
    }
}