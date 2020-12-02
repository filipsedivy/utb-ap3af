using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DamePizzu.Model;
using SQLite;

namespace DamePizzu.Data
{
    public class SqliteOrderRepository : IOrderRepository
    {
        private SQLiteAsyncConnection _connection;

        public SqliteOrderRepository()
        {
        }

        public async Task AddOrUpdateOrder(Order order)
        {
            if (order.Id != 0)
            {
                _ = await _connection.UpdateAsync(order);
            }
            else
            {
                _ = await _connection.InsertAsync(order);
            }
        }

        public Task<List<Order>> GetOrders()
        {
            return _connection.Table<Order>().ToListAsync(); 
        }

        public async Task Initialize()
        {
            if (_connection != null) return;
            _connection = new SQLiteAsyncConnection(
                Path.Combine(Xamarin.Essentials.FileSystem.AppDataDirectory, "localApp.db3"));

            await _connection.CreateTableAsync<Order>(); 
        }
    }
}
