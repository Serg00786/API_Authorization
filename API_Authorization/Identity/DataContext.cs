using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API_Authorization.Identity
{
    public class DataContext : IdentityDbContext<AppUser>
    {
    }
}
