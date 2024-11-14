using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

public static class SeedData
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Ensure the Admin role exists
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Check if the admin user exists
        var adminUser = await userManager.FindByNameAsync("shujaat siddiqui");
        if (adminUser == null)
        {
            // Create the admin user
            adminUser = new IdentityUser
            {
                UserName = "shujaat siddiqui",
                Email = "shujaat@example.com", // Replace with a valid email if needed
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(adminUser, "Abcd1234..");
            if (result.Succeeded)
            {
                // Assign the Admin role to the user
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    Console.WriteLine($"Error creating admin user: {error.Description}");
                }
            }
        }
    }
}
