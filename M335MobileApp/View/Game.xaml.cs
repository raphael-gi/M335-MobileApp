using System;
using System.IO;
using M335MobileApp.Data;
using M335MobileApp.Model;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace M335MobileApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game : ContentPage
    {
        private int id;
        public Game(int id)
        {
            InitializeComponent();
            //ID wird abgerufen
            this.id = id;
        }
        protected override async void OnAppearing()
        {
            MainDatabase db = new MainDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Games.db3"));
            Games game = await db.Select1Game(id);
            G.Text = game.Game;
            C.Text = game.Creator;
            D.Text = game.Date.ToString("dddd, dd MMMM yyyy");
        }
    }
}