using GamersChat.Models;
using GamersChat.Repositories;
using GamersChat.Repositories.Interfaces;

namespace GamersChat.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public Product EditProduct(Product product)
        {
            return this._productRepository.EditProduct(product);
        }

        public void DeleteProduct(Guid productId)
        {
            _productRepository.DeleteProduct(productId);
        }

        public Product GetProduct(Guid productId)
        {
            return _productRepository.GetProduct(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
    }
}
