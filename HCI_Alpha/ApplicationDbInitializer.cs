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
            if(roleManager.FindByNameAsync("admin").Result == null)
            {
                IdentityRole role = new IdentityRole
                {
                    Name = "admin"
                };

                IdentityResult roleResult = roleManager.CreateAsync(role).Result;

            }

            if (userManager.FindByEmailAsync("trimmj@etsu.edu").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "trimmj@etsu.edu",
                    Email = "trimmj@etsu.edu"
                };
                IdentityResult result = userManager.CreateAsync(user, "FuckOff123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }

            }

        }
    }
}
