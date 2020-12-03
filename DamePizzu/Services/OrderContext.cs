using System;
using System.IO;
using DamePizzu.Model;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace DamePizzu.Services
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderAccessories> OrderAccessories { get; set; }

        public OrderContext()
        {
            SQLitePCL.Batteries_V2.Init();
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "orders.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
