using System;
using Microsoft.Extensions.DependencyInjection;

namespace DamePizzu
{
    public static class Locator
    {
        private static IServiceProvider serviceProvider;

        public static void Initalize()
        {
            var services = new ServiceCollection();
            services.AddTransient<MainPage>();
            services.AddTransient<OrdersPage>();
            services.AddTransient<DetailPage>();
            services.AddTransient<OrderPage>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    } 
}
