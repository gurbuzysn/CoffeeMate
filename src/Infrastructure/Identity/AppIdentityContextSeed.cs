using ApplicationCore.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public static class AppIdentityContextSeed
    {
        public async static Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            if (await roleManager.Roles.AnyAsync() || await userManager.Users.AnyAsync())
                return;

            var demoUser = new ApplicationUser()
            {
                FirstName = "Karen",
                LastName = "Doe",
                Email = AuthorizationConstant.DEFAULT_DEMO_USER,
                UserName = AuthorizationConstant.DEFAULT_DEMO_USER,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(demoUser);

            var adminUser = new ApplicationUser()
            {
                FirstName = "John",
                LastName = "Doe",
                Email = AuthorizationConstant.DEFAULT_ADMIN_USER,
                UserName = AuthorizationConstant.DEFAULT_ADMIN_USER,
                EmailConfirmed = true
            };

            await roleManager.CreateAsync(new IdentityRole(AuthorizationConstant.Roles.ADMIN));

            await userManager.CreateAsync(adminUser, AuthorizationConstant.DEFAULT_PASSWORD);
            await userManager.AddToRoleAsync(adminUser, AuthorizationConstant.Roles.ADMIN);

        }
    }
}
