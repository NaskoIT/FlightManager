using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using static FlightManager.Common.GlobalConstants;

namespace FlightManager.Data.Seeding
{
    internal class RolesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            await SeedRoleAsync(roleManager, Roles.Administrator);
            await SeedRoleAsync(roleManager, Roles.Employee);
        }

        private static async Task SeedRoleAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            bool roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                IdentityResult result = await roleManager.CreateAsync(new IdentityRole(roleName));
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
