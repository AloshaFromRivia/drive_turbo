using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SomeUsualShop.Models
{
    public class AppIdentityDbContext : IdentityDbContext<DriveTurboUser>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
        :base(options)
        {
            
        }
        
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
            IConfiguration configuration) {

            UserManager<DriveTurboUser> userManager =
                serviceProvider.GetRequiredService<UserManager<DriveTurboUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];

            if (await roleManager.FindByNameAsync("User") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }
            if (await userManager.FindByNameAsync(username) == null) {
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                
                DriveTurboUser user = new DriveTurboUser() {
                    UserName = username,
                    Email = email
                };

                IdentityResult result = await userManager
                    .CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}