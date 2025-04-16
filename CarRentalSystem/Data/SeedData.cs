using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using CarRentalSystem.Data;

namespace CarRentalSystem.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create a default Admin user if not exists
            var user = await userManager.FindByEmailAsync("admin@example.com");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };
                await userManager.CreateAsync(user, "Password123!");
            }
            await userManager.AddToRoleAsync(user, "Admin");

            // Create a default User if not exists
            var normalUser = await userManager.FindByEmailAsync("user@example.com");
            if (normalUser == null)
            {
                normalUser = new ApplicationUser
                {
                    UserName = "user@example.com",
                    Email = "user@example.com"
                };
                await userManager.CreateAsync(normalUser, "Password123!");
            }
            await userManager.AddToRoleAsync(normalUser, "User");
        }
    }
}
