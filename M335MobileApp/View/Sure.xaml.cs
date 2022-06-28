using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using M335MobileApp.Data;
using M335MobileApp.Model;
using System.IO;

namespace M335MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sure : ContentPage
    {
        private int id;
        private Games game;
        public Sure(int id)
        {
            InitializeComponent();
            //ID wird abgerufen
            this.id = id;
        }
        protected override async void OnAppearing()
        {
            try
            {
                game = await App.Database.Select1Game(id);
                Gname.Text = game.Game;
            }
            catch
            {
                await DisplayAlert("Oh no!", "Couldn't find your game!", "Ok");
            }
        }
        async void ButtDel(object sender, EventArgs e)
        {
            try
            {
                await App.Database.DeleteGame(game);
                await Navigation.PushAsync(new MainPage(2));
            }
            catch
            {
                await DisplayAlert("Oh no!", "Couldn't delete your game!", "Ok");
            }
        }
        async void ButtBack(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List());
        }
    }
}