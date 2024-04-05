



using Ecommerce.Assembly.Models;

namespace Ecommerce.Assembly.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;
        Task AddToCart(CartItem item);
        Task<List<CartItem>> GetCartItems();
        Task DeleteItem(CartItem item);
        Task EmptyCart();

        Task<string> Checkout();
    }
}
