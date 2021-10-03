using Microsoft.AspNetCore.Identity;
using System.Linq;
using StoreManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreManagement.DB
{
    public class Seeder
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, DBContext context)
        {
            if (!context.Users.Any())
            {
                List<string> roles = new List<string> { "Admin", "Regular" };
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }

                List<AppUser> users = new List<AppUser>
                {
                    new AppUser
                    {
                        FirstName="John",
                        LastName="Smith",
                        Email="jsmith@gmail.com",
                        PhoneNumber="6758299020"
                    },
                    new AppUser
                    {
                        FirstName="Phineas",
                        LastName="Ferb",
                        Email="phfe@gmail.com",
                        PhoneNumber="6754782390"

                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@ssW0rd");
                    if (user == users[0])
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(user, "Regular");
                    }
                }
            }
        }
    }
}