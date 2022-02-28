using Microsoft.AspNetCore.Identity;

namespace API_Authorization
{
    public class AppUser : IdentityUser
    {
        public string Displayname { get; set; }

    }
}
