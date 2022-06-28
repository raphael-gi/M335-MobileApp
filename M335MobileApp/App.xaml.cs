using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using M335MobileApp.Data;
using System.IO;

namespace M335MobileApp
{
    public partial class App : Application
    {
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
