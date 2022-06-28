using System;
using System.IO;
using M335MobileApp.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace M335MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class List : ContentPage
    {
        public List()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            try
            {
                collectionView.ItemsSource = await App.Database.SelectGame();
            }
            catch
            {
                await DisplayAlert("Oh no!", "Couldn't find your games!", "Ok");
            }
        }
        private async void ButtSee(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            await Navigation.PushAsync(new Game(id));
        }
        async void ButtDel(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            await Navigation.PushAsync(new Sure(id));
        }
        private async void ButtEdit(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int id = Int32.Parse(button.ClassId);
            await Navigation.PushAsync(new Edit(id));
        }
        private async void ToHome(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(0));
        }
        private async void ToNewG(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewGame());
        }
    }
}
