using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seed
{
    public class UserSeed
    {
        public static async Task SeedAsync(UserManager<AppUser> userManager)
        {
            if (userManager.Users.Any()) return;


            var users = new List<AppUser>()
            {
                new AppUser
                {
                    FullName = "Admin",
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "1234567890",
                },
                new AppUser
                {
                    FullName = "Customer",
                    UserName = "customer",
                    Email = "quoctien@gmail.com",
                    PhoneNumber = "1234567890",
                },
            };

            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Admin_123");
            }

            var adminUser = await userManager.FindByNameAsync("Admin");

            await userManager.AddToRoleAsync(adminUser, "Admin");

            var customerUser = await userManager.FindByNameAsync("Customer");

            await userManager.AddToRoleAsync(customerUser, "Customer");
        }
    }
}
