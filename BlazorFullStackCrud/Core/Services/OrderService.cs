

using Core.Interfaces;
using Core.Interfaces.Service;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository  orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            try
            {
                return await _orderRepository.GetOrders();
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving orders from database.", ex);
            }
        }

        public async Task<Order> GetOrderById(int id)
        {
            try
            {
                return await _orderRepository.GetSingleOrders(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving order with ID {id} from database.", ex);
            }
        }

        public async Task AddOrder(Order order)
        {
            await _orderRepository.AddOrder(order);
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                await _orderRepository.UpdateOrder(order);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating order with ID {order.Id} in database.", ex);
            }
        }

        public async Task DeleteOrder(int id)
        {
            try
            {
                var orderToDelete = await _orderRepository.GetByIdAsync(id);
                if (orderToDelete != null)
                {
                    await _orderRepository.DeleteAsync(orderToDelete.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting order with ID {id} from database.", ex);
            }
        }
    }
}



