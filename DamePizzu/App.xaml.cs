using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DamePizzu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Locator.Initalize();

            MainPage = new AppShell();
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
