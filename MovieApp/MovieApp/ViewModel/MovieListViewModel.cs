using MovieApp.Model;
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
    public class MovieListViewModel : BaseViewModel
    {
        public MovieListViewModel()
        {
            GetOnlineData();
        }

        public Movie FeaturedMovie => WatchList?.Where(x => x.IsFeatured == true).FirstOrDefault();


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

        public ICommand PlayCommand => new Command(() =>
        {
            if (FeaturedMovie != null)
            {
                var vm = new PlayerViewModel { SelectedMovie = FeaturedMovie };
                var page = new PlayerPage { BindingContext = vm };
                Application.Current.MainPage.Navigation.PushAsync(page);
            }
        });

        //private async void GetOnlineData()
        //{
        //    var client = new HttpClient();
        //    var result = await client.GetStringAsync("https://devcrux.com/movies.json");
        //    WatchList = JsonConvert.DeserializeObject<ObservableCollection<Movie>>(result);
        //}
        private ObservableCollection<Movie> GetOnlineData()
        {
            return WatchList = new ObservableCollection<Movie>
            {
                new Movie{ Title = "A Good Woman Is Hard To Find",
                            Synopsis= "Set in the underbelly of Northern Ireland, A Good Woman is Hard to Find follows Sarah Collins (Sarah Bolger, “Mayans M.C.”, “The Tudors”, Emelie), a single mother struggling to raise two young children while searching for answers about the unsolved murder of her husband. After being coerced into helping a low-level drug dealer stash stolen narcotics, she finds herself the target of local crime boss Leo Miller (Edward Hogg). Forced to take desperate measures to keep her family safe, Sarah turns the tables on her victimizers in one final act of bloody vengeance.",
                            Thumbnail= "https://cauthu.com.vn/wp-content/uploads/2020/06/yua-mikami-9.jpg",
                            Url= "https://manifest.prod.boltdns.net/manifest/v1/hls/v4/clear/6168375563001/1477dcaa-2a49-4f82-8084-410f6a584ba1/23efa53f-d30b-4d55-9ced-3f20d27eec43/10s/rendition.m3u8?fastly_token=NWYxNDZkMjFfMzk5Yjk2MGRiZWFlOTBkN2VlODcwYjQ5MTZkMjJjOGViZWI0Yzg0MTlkYmY1ZDg4ZTg4ZjBjMWNlMWJkYmM3ZQ%3D%3D",
                             IsFeatured= true},
                new Movie{ Title = "ssssss",
                            Synopsis= "Set in the underbelly of Northern Ireland, A Good Woman is Hard to Find follows Sarah Collins (Sarah Bolger, “Mayans M.C.”, “The Tudors”, Emelie), a single mother struggling to raise two young children while searching for answers about the unsolved murder of her husband. After being coerced into helping a low-level drug dealer stash stolen narcotics, she finds herself the target of local crime boss Leo Miller (Edward Hogg). Forced to take desperate measures to keep her family safe, Sarah turns the tables on her victimizers in one final act of bloody vengeance.",
                            Thumbnail= "https://devcrux.com/wp-content/uploads/108377.jpg",
                            Url= "https://movietrailers.apple.com/movies/independent/a-good-woman-is-hard-to-find/a-good-woman-is-hard-to-find-trailer-1_h480p.mov",
                             IsFeatured= true},
            };
        }
    }
}
