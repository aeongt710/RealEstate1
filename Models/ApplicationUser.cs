using Microsoft.AspNetCore.Identity;

namespace RealEstate1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
