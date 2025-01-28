using Sample.App.Domain.SQL;
using Sample.App.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.BLL
{
    /// <summary>
    /// Service class for managing Order operations.
    /// Implements IService<Order>.
    /// </summary>
    public class OrderService : IService<Order>
    {
        private readonly IRepository<Order> _orderRepository;

        /// <summary>
        /// Initializes a new instance of the OrderService class.
        /// </summary>
        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        /// <summary>
        /// Get all orders from the repository.
        /// </summary>
        /// <returns>List of all orders.</returns>
        public List<Order> Get()
        {
            var listData = _orderRepository.Get();
            return listData;
        }

        /// <summary>
        /// Get a specific order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>The order entity if found.</returns>
        public async Task<Order> GetAsync(int id)
        {
            var data = await _orderRepository.GetAsync(id);
            return data;
        }

        /// <summary>
        /// Save a new order to the repository.
        /// </summary>
        /// <param name="order">The order entity to save.</param>
        /// <returns>The created order entity.</returns>
        public async Task<Order> CreateAsync(Order order)
        {
            var data = await _orderRepository.CreateAsync(order);
            return data;
        }

        /// <summary>
        /// Update an existing order in the repository.
        /// </summary>
        /// <param name="order">The order entity with updated values.</param>
        /// <returns>The updated order entity.</returns>
        public async Task<Order> UpdateAsync(Order order)
        {
            var data = await _orderRepository.UpdateAsync(order);
            return data;
        }

        /// <summary>
        /// Delete an order by its ID.
        /// </summary>
        /// <param name="id">The ID of the order to delete.</param>
        /// <returns>The ID of the deleted order.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _orderRepository.DeleteAsync(id);
        }
    }

}
