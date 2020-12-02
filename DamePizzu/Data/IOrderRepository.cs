using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DamePizzu.Model;

namespace DamePizzu.Data
{
    public interface IOrderRepository
    {
        Task Initialize();
        Task<List<Order>> GetOrders();
        Task AddOrUpdateOrder(Order order);
    }
}
