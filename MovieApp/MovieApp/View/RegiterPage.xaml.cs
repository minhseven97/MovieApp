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
    public partial class RegiterPage : ContentPage
    {
        private List<Register> allPersons;
        public List<Register> AllPersons
        {
            get { return allPersons; }
            set
            {
                allPersons = value;
                OnPropertyChanged();
            }
        }
        RegiterPageViewModel firebaseHelper = new RegiterPageViewModel();
        public RegiterPage()
        {
            InitializeComponent();
            loading.IsVisible = false;
        }
        protected async override void OnAppearing()
        {

            base.OnAppearing();
            loading.IsVisible = true;
            AllPersons = await firebaseHelper.GetAllAcc();
            loading.IsVisible = false;
        }
        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            int bien = 0;
            if (txtPass1.Text.Length >= 6)
            {
                if (txtPass1.Text == txtPass2.Text)
                {
                    foreach (var item in AllPersons)
                    {
                        if (item.UserName == txtName.Text)
                        {
                            await DisplayAlert("Cảnh báo", "Tên tài khoản đã tồn tại", "OK");
                            bien = 1;
                            break;
                        }
                        else
                            bien = 2;
                    }
                    if (bien == 2)
                    {
                        loading.IsVisible = true;
                        await firebaseHelper.AddAcc(txtName.Text, txtPass1.Text);
                        txtPass1.Text = string.Empty;
                        txtName.Text = string.Empty;
                        txtPass2.Text = string.Empty;
                        loading.IsVisible = false;
                        await DisplayAlert("Chúc mừng", "Tài khoản đã đăng ký thành công", "OK");
                    }
                }
                else
                    await DisplayAlert("Cảnh báo", "Mật khẩu không giống nhau", "OK");
            }
            else
                await DisplayAlert("Cảnh báo", "Mật khẩu phải lớn hơn 8 ký tự", "OK");
        }
    }
}