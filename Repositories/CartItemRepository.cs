using GamersChat.Data;
using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersChat.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public CartItemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CartItem> GetCartItemsByUserId(Guid userId)
        {
            return _dbContext.Set<CartItem>()
                           .Include(ci => ci.Product)
                           .Where(ci => ci.Cart.UserId == userId)
                           .ToList();
        }

        public void AddCartItem(CartItem cartItem)
        {
            _dbContext.Set<CartItem>().Add(cartItem);
            _dbContext.SaveChanges();
        }

        public void RemoveCartItem(Guid cartItemId)
        {
            var cartItem = _dbContext.Set<CartItem>().Find(cartItemId);
            if (cartItem != null)
            {
                _dbContext.Set<CartItem>().Remove(cartItem);
                _dbContext.SaveChanges();
            }
        }
    }
}
