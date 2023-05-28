using GamersChatAPI.Models;

namespace GamersChat.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        public IEnumerable<CartItem> GetCartItemsByUserId(Guid userId);
        public void AddCartItem(CartItem cartItem);
        public void RemoveCartItem(Guid cartItemId);
    }
}
