using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DamePizzu.Model;
using DamePizzu.Services;
using Microsoft.EntityFrameworkCore;
using Xamarin.Forms;

namespace DamePizzu.ViewModel
{
    public class OrdersViewModel : BaseViewModel
    {
        public OrdersViewModel()
        {
            FavoriteCommand = new Command<Order>((o) => {
                MessagingCenter.Send(o, "Favorited");
            });

            RefreshCommand = new Command(ExecuteRefreshCommand);
        }

        public Command<Order> FavoriteCommand { get; set; }

        public ICommand RefreshCommand { get; }

        bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set {
                isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
            }
        }

        void ExecuteRefreshCommand()
        {
            ReloadOrders();

            // Stop refreshing
            IsRefreshing = false;
        }

        public ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders {
            get => orders;
            set { orders = value; OnPropertyChanged(nameof(Orders)); }
        }

        public void ReloadOrders()
        {
            using (var orderContext = new OrderContext())
            {
                var OrdersContext = orderContext
                    .Orders
                    .Include(o => o.OrderAccessories)
                    .OrderByDescending(order => order.Created).ToList();

                Orders = new ObservableCollection<Order>(OrdersContext);
            }
        }

    }
}
