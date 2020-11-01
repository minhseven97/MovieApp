using Firebase.Database;
using Firebase.Database.Query;
using MovieApp.Model;
using MovieApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MovieApp.ViewModel
{
    public class HistoryViewModel : BaseViewModel
    {
        FirebaseClient firebase = new FirebaseClient("https://sample-notification-12baf.firebaseio.com/");
        private ObservableCollection<Movie> watchListHis;
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
        public ObservableCollection<Movie> WatchListHis
        {
            get { return watchListHis; }
            set
            {
                watchListHis = value;
                OnPropertyChanged();
            }
        }
        public async Task<List<History>> GetAllHis()
        {

            return (await firebase
              .Child("Historys")
              .OnceAsync<History>()).Select(item => new History
              {
                  NameUser = item.Object.NameUser,
                  TimeView = item.Object.TimeView,
                  NameMovie = item.Object.NameMovie
              }).ToList();
        }

        public async Task AddHis(string nameUser, string timeView, string nameMovie)
        {

            await firebase
              .Child("Historys")
              .PostAsync(new History() { NameUser = nameUser, TimeView = timeView, NameMovie = nameMovie });
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
