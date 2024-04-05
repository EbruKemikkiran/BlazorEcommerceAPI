



using Ecommerce.Assembly.Models;

namespace Ecommerce.Assembly.Services.CategoryService
{
    public interface ICategoryService
    {
        List<Category> Categories { get; set; }
        Task LoadCategories();
    }
}
