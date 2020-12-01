using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DamePizzu
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void GoToCart(System.Object sender, System.EventArgs e)
        {
            Command GoToCartCommand = new Command(RedirectToCart);
            GoToCartCommand.Execute(null);
        }

        async void RedirectToCart()
        {
            await Shell.Current.GoToAsync("//Cart");
        }
    }
}
