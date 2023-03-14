
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task AddOrder(Order order);
        Task UpdateOrder(Order order);
        Task<IEnumerable<Order>> GetOrders();
        Task<Order> GetSingleOrders(int id);
    }
}
