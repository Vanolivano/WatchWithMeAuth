using Microsoft.AspNetCore.Identity;

namespace BusinessLogicLayer.Domains
{
    public class AppUser : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long FacebookId { get; set; }
        public string PictureUrl { get; set; }
    }
}