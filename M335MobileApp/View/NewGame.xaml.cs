using System;
using M335MobileApp.Model;
using M335MobileApp.Data;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace M335MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewGame : ContentPage
    {
        public NewGame()
        {
            InitializeComponent();
        }
        private async void SaveGame(object sender, EventArgs e)
        {
            Games games = new Games();
            games.Game = Game.Text;
            games.Creator = Creator.Text;
            games.Date = DateSel.Date;
            if (string.IsNullOrWhiteSpace(games.Game) || string.IsNullOrWhiteSpace(games.Creator))
            {
                await DisplayAlert("Empty", "Don't leave any Fields empty", "OK");
            }
            else
            {
                try
                {
                    await App.Database.NewGame(games);
                    await Navigation.PushAsync(new MainPage(1));
                }
                catch
                {
                    await DisplayAlert("Oh no!", "Couldn't create your game!", "Ok");
                }
            }
        }
    }
}