using Firebase.Database;
using Firebase.Database.Query;
using MovieApp.Model;
using MovieApp.View;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <summary>
        /// comment
        /// </summary>
        FirebaseClient firebase = new FirebaseClient("https://sample-notification-12baf.firebaseio.com/");

        public async Task<List<Comment>> GetAllComment()
        {

            return (await firebase
              .Child("Comments")
              .OnceAsync<Comment>()).Select(item => new Comment
              {
                  NameUser = item.Object.NameUser,
                  NameMovie = item.Object.NameMovie,
                  Comment1 = item.Object.Comment1
              }).ToList();
        }

        public async Task AddComment(string nameUser, string NameMovie, string comment1)
        {

            await firebase
              .Child("Comments")
              .PostAsync(new Comment() { NameUser = nameUser, NameMovie = NameMovie, Comment1 = comment1 });
        }
    }
}
