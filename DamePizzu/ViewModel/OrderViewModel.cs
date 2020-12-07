using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DamePizzu.Model;
using DamePizzu.Services;
using Xamarin.Forms;

namespace DamePizzu.ViewModel
{
    public class OrderViewModel : BaseViewModel
    {
        public OrderViewModel()
        {
            foodAccessories = GetFoodAccessories();
        }

        public ICommand FinishOrder => new Command(DoFinishOrder);
        private void DoFinishOrder()
        {
            double totalPrice = 0;
            totalPrice += selectedFood.Price;

            foreach (var item in FoodAccessories)
            {
                totalPrice += item.Quantity * item.Price;
            }

            Device.BeginInvokeOnMainThread(async () =>
            {
                bool finish = await Shell.Current.DisplayAlert("Dokončit objednávku", "Opravdu chcete objednat zboží v hodnotě: " + totalPrice + " Kč?", "Ano", "Ne");

                if (finish)
                {
                    var newOrder = new Order {
                        TotalPrice = totalPrice,
                        Food = selectedFood.Name,
                        OrderAccessories = new List<OrderAccessories>()
                    };

                    foreach (var item in FoodAccessories.Where(a => a.Quantity > 0))
                    {
                        newOrder.OrderAccessories.Add(new OrderAccessories
                        {
                            Name = item.Name,
                            Quantity = item.Quantity,
                            PriceOneItem = item.Price,
                            TotalPrice = item.Price * item.Quantity
                        });
                    }

                    using (var orderContext = new OrderContext())
                    {
                        orderContext.Orders.Add(newOrder);
                        orderContext.SaveChanges();
                        await Shell.Current.GoToAsync("//Home");
                    }
                }
            });
           

        }

        private Food selectedFood;
        public Food SelectedFood
        {
            get { return selectedFood; }
            set
            {
                selectedFood = value;
                OnPropertyChanged(nameof(SelectedFood));
            }
        }

        private ObservableCollection<FoodAccessories> foodAccessories;
        public ObservableCollection<FoodAccessories> FoodAccessories
        {
            get { return foodAccessories; }
            set
            {
                foodAccessories = value;
                OnPropertyChanged(nameof(FoodAccessories));
            }
        }

        private ObservableCollection<FoodAccessories> GetFoodAccessories()
        {
            return new ObservableCollection<FoodAccessories> {
                new FoodAccessories { Name = "Kuřecí maso", Price = 50 },
                new FoodAccessories { Name = "Sýr", Price = 20 },
                new FoodAccessories { Name = "Kečup", Price = 15 }
            };
        }
    }
}
