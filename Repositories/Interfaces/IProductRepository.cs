using GamersChat.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        Product EditProduct(Product product);
        void DeleteProduct(Guid productId);
        Product GetProduct(Guid productId);
        IEnumerable<Product> GetAllProducts();
    }
}
