using System;
using System.IO;
using M335MobileApp.Data;
using M335MobileApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace M335MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit : ContentPage
    {
        private int id;
        public Edit(int id)
        {
            InitializeComponent();
            //ID wird abgerufen
            this.id = id;
        }
        protected override async void OnAppearing()
        {
            try
            {
                Games game = await App.Database.Select1Game(id);
                //Eingabefelder erhalten default value
                G.Text = game.Game;
                C.Text = game.Creator;
                D.Date = game.Date;
            }
            catch
            {
                await DisplayAlert("Oh no!", "Couldn't find your game!", "Ok");
            }
        }
        private async void EditGame(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(G.Text) || string.IsNullOrWhiteSpace(C.Text))
            {
                await DisplayAlert("Empty", "Don't leave any Fields empty", "OK");
            }
            else
            {
                try
                {
                    Games game = await App.Database.Select1Game(id);
                    //Neues Game Objekt wird erstellt
                    game.Game = G.Text;
                    game.Creator = C.Text;
                    game.Date = D.Date;
                    await App.Database.EditGame(game);

                    await Navigation.PushAsync(new List());
                }
                catch
                {
                    await DisplayAlert("Oh no!", "Couldn't edit your game!", "Ok");
                }
            }
        }
    }
}