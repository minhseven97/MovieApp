using MovieApp.Model;
using MovieApp.View;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModel
{
    public class DetailViewModel : BaseViewModel
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

        public ICommand PlayCommand => new Command(() =>
        {
            var vm = new PlayerViewModel { SelectedMovie = selectedMovie };
            var page = new PlayerPage { BindingContext = vm };
            Application.Current.MainPage.Navigation.PushAsync(page);
        });
        public ICommand ShareCommand => new Command(() =>
        {
            CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
            {
                Text = selectedMovie.Link
            });
        });
    }
}
