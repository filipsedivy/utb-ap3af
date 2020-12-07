using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DamePizzu.Model;
using DamePizzu.Services;
using DamePizzu.ViewModel;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace DamePizzu
{
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
            BindingContext = new OrdersViewModel();

            MessagingCenter.Subscribe<Order>(this, "Favorited", (o) =>
            {
                bool isFavourite = o.Favourite;
                using (var orderContext = new OrderContext())
                {
                    o.Favourite = !o.Favourite;
                    orderContext.Update(o);
                    orderContext.SaveChanges();
                }

                if (isFavourite)
                {
                    DisplayAlert("Objednávka", $"Objednávka {o.Food} byla odebrána z oblíbených", "Děkuji");
                }
                else
                {
                    DisplayAlert("Objednávka", $"Objednávka {o.Food} byla přidána do oblíbených", "Děkuji");
                }

                var bc = BindingContext as OrdersViewModel;
                bc.ReloadOrders();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var bc = BindingContext as OrdersViewModel;
            bc.ReloadOrders();
        }
    }
}
