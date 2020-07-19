using MovieApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.ViewModel
{
    public class PlayerViewModel : BaseViewModel
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
    }
}
