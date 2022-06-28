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
        private MainDatabase db = new MainDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Games.db3"));
        public Sure(int id)
        {
            InitializeComponent();
            //ID wird abgerufen
            this.id = id;
        }
        protected override async void OnAppearing()
        {
            game = await db.Select1Game(id);
            Gname.Text = game.Game;
        }
        async void ButtDel(object sender, EventArgs e)
        {
            await db.DeleteGame(game);
            await Navigation.PushAsync(new MainPage(2));
        }
        async void ButtBack(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new List());
        }
    }
}