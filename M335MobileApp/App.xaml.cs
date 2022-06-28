using System;
using Xamarin.Forms;
using M335MobileApp.Data;
using System.IO;

namespace M335MobileApp
{
    public partial class App : Application
    {
        private static MainDatabase db;
        
        public static MainDatabase Database
        {
            get
            {
                if (db == null)
                {
                    db = new MainDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Games.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();
            //Main Page wird aufgerufen und NavBar werden Farben zugeteilt
            MainPage = new NavigationPage(new MainPage(0)) { BarBackgroundColor = Color.FromHex("#161616"), BarTextColor = Color.White };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
