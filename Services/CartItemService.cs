using GamersChat.Repositories.Interfaces;
using GamersChatAPI.Models;

namespace GamersChat.Services
{
    public class CartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository repository)
        {
            this._cartItemRepository = repository;
        }


        public IEnumerable<CartItem> GetCartItemsByUserId(Guid userId)
        {
            return _cartItemRepository.GetCartItemsByUserId(userId);
        }

        public void AddCartItem(CartItem cartItem)
        {
            _cartItemRepository.AddCartItem(cartItem);
        }

        public void RemoveCartItem(Guid cartItemId)
        {
            _cartItemRepository.RemoveCartItem(cartItemId);
        }
    }
}
