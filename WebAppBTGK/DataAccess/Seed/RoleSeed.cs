using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DataAccess.Seed
{
    public class RoleSeed
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {

            if (roleManager.Roles.Any()) return;

            var roles = new List<IdentityRole>
            {
                new() { Name = "Admin", },
                new() { Name = "Customer", },
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }
        }
    }
}
