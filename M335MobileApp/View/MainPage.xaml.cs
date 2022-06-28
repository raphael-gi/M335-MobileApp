using System;
using Xamarin.Forms;
using M335MobileApp.View;

namespace M335MobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(int created)
        {
            InitializeComponent();
            if (created == 1)
            {
                DisplayAlert("Game Created", "Your Game has successfully been created", "OK");
            }
            if (created == 2)
            {
                DisplayAlert("Game Deleted", "Your Game has successfully been deleted", "OK");
            }
        }
        private async void ListGame(object sender, EventArgs e)
        {
            //Schickt Benutzer auf Seite mit Liste
            await Navigation.PushAsync(new List());
        }
        private async void SaveGame(object sender, EventArgs e)
        {
            //Schickt Benutzer auf Seite um neues Spiel zu erstellen
            await Navigation.PushAsync(new NewGame());
        }
    }
}
