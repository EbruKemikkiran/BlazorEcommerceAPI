﻿


using Ecommerce.Assembly.Models;

namespace Ecommerce.Assembly.Services.ProductService
{
    public interface IProductService
    {
        event Action OnChange;
        List<Product> Products { get; set; }
        Task LoadProducts(string categoryUrl = null);
        Task<Product> GetProduct(int id);
        Task<List<Product>> SearchProducts(string searchText);

    }
}
