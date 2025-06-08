using Microsoft.AspNetCore.Identity;

namespace PortfolioApp.Models
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
    }
}
