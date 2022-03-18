using API_Authorization.Identity;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Authorization.Migrations
{
    public class DataSeed
    {
        public static async Task SeedDataAsync(DataContext context, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                            {
                                new AppUser
                                    {
                                        Displayname = "TestUserFirst",
                                        UserName = "TestUserFirst",
                                        Email = "testuserfirst@test.com"
                                    },

                                new AppUser
                                    {
                                        Displayname = "TestUserSecond",
                                        UserName = "TestUserSecond",
                                        Email = "testusersecond@test.com"
                                    }
                              };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "qazwsX123@");
                }
            }
        }
    }
}
