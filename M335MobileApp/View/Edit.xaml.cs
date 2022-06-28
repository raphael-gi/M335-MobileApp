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
            MainDatabase db = new MainDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Games.db3"));
            Games game = await db.Select1Game(id);
            //Eingabefelder erhalten default value
            G.Text = game.Game;
            C.Text = game.Creator;
            D.Date = game.Date;
        }
        private async void EditGame(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(G.Text) || string.IsNullOrWhiteSpace(C.Text))
            {
                await DisplayAlert("Empty", "Don't leave any Fields empty", "OK");
            }
            else
            {
                MainDatabase db = new MainDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Games.db3"));
                Games game = await db.Select1Game(id);
                //Neues Game Objekt wird erstellt
                game.Game = G.Text;
                game.Creator = C.Text;
                game.Date = D.Date;

                await db.EditGame(game);

                await Navigation.PushAsync(new List());
            }
        }
    }
}