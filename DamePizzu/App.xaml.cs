using System;
using DamePizzu.Data;
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

            InitializeRepostiory();

            InitializeMainPage();
        }


        private void InitializeRepostiory()
        {
            IOrderRepository repository = Locator.Resolve<IOrderRepository>();
            repository.Initialize();
        }

        private void InitializeMainPage()
        {
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
