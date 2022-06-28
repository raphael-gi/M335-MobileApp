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
            try
            {
                Games game = await App.Database.Select1Game(id);
                G.Text = game.Game;
                C.Text = game.Creator;
                D.Text = game.Date.ToString("dddd, dd MMMM yyyy");
            }
            catch
            {
                await DisplayAlert("Oh no!", "Couldn't find your game!", "Ok");
            }
        }
    }
}