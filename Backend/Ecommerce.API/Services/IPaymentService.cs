
using Ecommerce.BLayer.Data;
using Stripe.Checkout;

namespace Ecommerce.API.Controllers
{
    public interface IPaymentService
    {
        Session CreateChecoutSession(List<CartItem> cartItems);
    }
}
