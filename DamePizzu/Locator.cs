using System;
using DamePizzu.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DamePizzu
{
    public static class Locator
    {
        private static IServiceProvider serviceProvider;

        public static void Initalize()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IOrderRepository, SqliteOrderRepository>();
            services.AddTransient<MainPage>();
            services.AddTransient<OrdersPage>();
            services.AddTransient<CartPage>();
            services.AddTransient<DetailPage>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    } 
}
