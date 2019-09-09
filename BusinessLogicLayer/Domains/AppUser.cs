using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Domains
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}