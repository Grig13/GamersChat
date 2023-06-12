using GamersChat.Data;
using GamersChat.Models;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product EditProduct(Product product)
        {
            var existingProduct = GetProduct(product.Id);
            existingProduct.Title = product.Title;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.CanDeliver = product.CanDeliver;
            existingProduct.IsNew = product.IsNew;
            existingProduct.PhoneNumber = product.PhoneNumber;
            existingProduct.Email = product.Email;
            existingProduct.City = product.City;
            existingProduct.Category = product.Category;
            existingProduct.ImageUrl = product.ImageUrl;
            _context.SaveChanges();
            return existingProduct;
        }

        public void DeleteProduct(Guid productId)
        {
            var product = _context.Products.Find(productId);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public Product GetProduct(Guid productId)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return _context.Products.Find(productId);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }
    }
}
