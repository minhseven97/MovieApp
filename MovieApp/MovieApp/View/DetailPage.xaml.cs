using MovieApp.Core;
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
    public partial class DetailPage : ContentPage
    {
        DetailViewModel firebaseHelper = new DetailViewModel();
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        private List<Comment> allComment;
        public List<Comment> AllComment
        {
            get { return allComment; }
            set
            {
                allComment = value;
                OnPropertyChanged();
            }
        }
        public DetailPage()
        {
            InitializeComponent();
            loading.IsVisible = false;
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IOrientationHandler>().ForcePortrait();
            loading.IsVisible = true;
            var vm = (DetailViewModel)BindingContext;
            var nameMovie = vm.SelectedMovie.MovieId;
            AllComment = await firebaseHelper.GetAllComment();
            List<Comment> list = new List<Comment>();
            //List<Comment> list1 = new List<Comment>();
            foreach(var item in AllComment)
            {
                if(item.NameMovie == nameMovie)
                {
                    list.Add(item);
                }
            }
            list.Reverse();
            lstPersons.ItemsSource = list;
            loading.IsVisible = false;
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            Name = App.Name1;
            var vm = (DetailViewModel)BindingContext;
            var nameMovie = vm.SelectedMovie.MovieId;
            await firebaseHelper.AddComment(Name, nameMovie, txtCom.Text);
            txtCom.Text = string.Empty;
            AllComment = await firebaseHelper.GetAllComment();
            List<Comment> list = new List<Comment>();
            foreach (var item in AllComment)
            {
                if (item.NameMovie == nameMovie)
                {
                    list.Add(item);
                }
            }
            list.Reverse();
            lstPersons.ItemsSource = list;
        }
    }
}