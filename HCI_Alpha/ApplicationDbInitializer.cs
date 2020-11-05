using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCI_Alpha
{
    public class ApplicationDbInitializer
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if(roleManager.FindByNameAsync("Admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "Admin"
                };

                IdentityResult roleResult = roleManager.CreateAsync(role).Result;

            }

            if (userManager.FindByEmailAsync("admin@etsu.edu").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@etsu.edu",
                    Email = "admin@etsu.edu"
                };
                IdentityResult result = userManager.CreateAsync(user, "Passw0rd!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }

        }
    }
}
