using GelatoGuide.Data;
using GelatoGuide.Data.Enumerations;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using GelatoGuide.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Options;
using static GelatoGuide.WebConstants;

namespace GelatoGuide.Infrastructure
{
    public static class ApplicationBuilderExtension
    {

        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var data = services.GetRequiredService<GelatoGuideDbContext>();

            MigrateDatabase(services, data);

            SeedRoles(services, data);

            SeedAdministrator(services, data);

            return app;
        }

        private static void MigrateDatabase(IServiceProvider services, GelatoGuideDbContext data)
        {

            data.Database.Migrate();
        }

        private static void SeedRoles(IServiceProvider services, GelatoGuideDbContext data)
        {
            if (data.Roles.Any())
            {
                return;
            }

            data.Roles.AddRange(new []
            {
                new IdentityRole{Name = RegularUserRoleName, NormalizedName = RegularUserRoleName.ToUpper()},
                new IdentityRole{Name = PremiumUserRoleName, NormalizedName = PremiumUserRoleName.ToUpper()},
                new IdentityRole{Name = AdministratorRoleName, NormalizedName = AdministratorRoleName.ToUpper()}
                
            });

            data.SaveChanges();
        }

        private static void SeedAdministrator(IServiceProvider services, GelatoGuideDbContext data)
        {
            var userManager = services.GetRequiredService<UserManager<User>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await userManager.Users.AnyAsync(u => u.UserName == "Admin"))
                    {
                        return;
                    }

                    IdentityRole role;

                    if (!await roleManager.RoleExistsAsync(AdministratorRoleName))
                    {
                        role = new IdentityRole { Name = AdministratorRoleName };

                        await roleManager.CreateAsync(role);
                    }
                    else
                    {
                        role = await data.Roles.FirstOrDefaultAsync(r => r.Name == AdministratorRoleName);
                    }
                    

                    var user = new User
                    {
                        UserName = "Admin" ,
                        Email = "admin@gelatoguide.com",
                        FullName = "Admin"
                    };

                    await userManager.CreateAsync(user, "root9406");

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }
    }
}
