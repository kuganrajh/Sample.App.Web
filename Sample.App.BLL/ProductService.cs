using Sample.App.Domain.SQL;
using Sample.App.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.BLL
{
    /// <summary>
    /// Service class for managing Product operations.
    /// Implements IService<Product>.
    /// </summary>
    public class ProductService : IService<Product>
    {
        private readonly IRepository<Product> _productRepository;

        /// <summary>
        /// Initializes a new instance of the ProductService class.
        /// </summary>
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products from the repository.
        /// </summary>
        /// <returns>List of all products.</returns>
        public List<Product> Get()
        {
            var listData = _productRepository.Get();
            return listData;
        }

        /// <summary>
        /// Get a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product.</param>
        /// <returns>The product entity if found.</returns>
        public async Task<Product> GetAsync(int id)
        {
            var data = await _productRepository.GetAsync(id);
            return data;
        }

        /// <summary>
        /// Save a new product to the repository.
        /// </summary>
        /// <param name="product">The product entity to save.</param>
        /// <returns>The created product entity.</returns>
        public async Task<Product> CreateAsync(Product product)
        {
            var data = await _productRepository.CreateAsync(product);
            return data;
        }

        /// <summary>
        /// Update an existing product in the repository.
        /// </summary>
        /// <param name="product">The product entity with updated values.</param>
        /// <returns>The updated product entity.</returns>
        public async Task<Product> UpdateAsync(Product product)
        {
            var data = await _productRepository.UpdateAsync(product);
            return data;
        }

        /// <summary>
        /// Delete a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        /// <returns>The ID of the deleted product.</returns>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _productRepository.DeleteAsync(id);
        }
    }

}
