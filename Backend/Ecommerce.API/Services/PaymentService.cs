using Azure;
using Ecommerce.BLayer.Data;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;

namespace Ecommerce.API.Controllers
{
    public class PaymentService : IPaymentService
    {

        public PaymentService()
        {
            StripeConfiguration.ApiKey = "sk_test_51Lx5ufFjZ2d2ixOMakzSO6vTs22dFu46juurIfRLBkMx58Sq82VEuQVlNMAlebTkXUOqinvEIH";
        }
        public Session CreateChecoutSession(List<CartItem> cartItems)
        {

            var lineItems = new List<SessionLineItemOptions>();
            cartItems.ForEach(ci => lineItems.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions {
                    UnitAmount = (long?)(ci.Price * 100),
                    Currency ="gbp",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name= ci.ProductTitle,
                        Images = new List<string> {  ci.Image}
                    }
                },
                Quantity = ci.Quantity
            }));
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string>
                {
                    "card",
                },

                LineItems = lineItems,
                Mode = "payment",
                SuccessUrl = "https://localhost:7171/order-success",
                CancelUrl = "https://localhost:7171/cart",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            return session;
        }
    }
}
