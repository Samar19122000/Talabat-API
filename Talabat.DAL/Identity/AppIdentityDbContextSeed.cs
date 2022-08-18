using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.DAL.Entities.Identity;

namespace Talabat.DAL.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Samar Algammal",
                    UserName = "SamarAlgammal",
                    Email = "SamarAlgammal@gmail.com",
                    PhoneNumber = "0123456789",
                    Address = new Address()
                    {
                        FristName = "Samar",
                        LastName =   "Algammal",
                        Country = "Egypt",
                        City = "Nasr City",
                        Street = "10 Tahrir Street"
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }

    }
}
