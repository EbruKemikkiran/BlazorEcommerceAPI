
namespace Ecommerce.Assembly.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class User 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

}
