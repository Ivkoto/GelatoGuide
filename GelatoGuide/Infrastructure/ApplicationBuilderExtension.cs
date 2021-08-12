using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using static GelatoGuide.WebConstants;

namespace GelatoGuide.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        private static TestSeedData testSeedData = new TestSeedData();

        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var data = services.GetRequiredService<GelatoGuideDbContext>();

            MigrateDatabase(services, data);

            SeedRoles(services, data);

            SeedAdministrator(services, data);

            SeedPlaces(data);

            SeedArticles(data);

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

            data.Roles.AddRange(new[]
            {
                new IdentityRole{Name = Roles.RegularName, NormalizedName = Roles.RegularName.ToUpper()},
                new IdentityRole{Name = Roles.PremiumName, NormalizedName = Roles.PremiumName.ToUpper()},
                new IdentityRole{Name = Roles.AdminName, NormalizedName = Roles.AdminName.ToUpper()}

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
                    if (await userManager.Users.AnyAsync(u => u.UserName == Admin.InitialUsername))
                    {
                        return;
                    }

                    IdentityRole role;

                    if (!await roleManager.RoleExistsAsync(Roles.AdminName))
                    {
                        role = new IdentityRole { Name = Roles.AdminName };

                        await roleManager.CreateAsync(role);
                    }
                    else
                    {
                        role = await data.Roles.FirstOrDefaultAsync(r => r.Name == Roles.AdminName);
                    }


                    var user = new User
                    {
                        UserName = Admin.InitialUsername,
                        Email = Admin.InitialEmail,
                        FullName = Admin.InitialFullName
                    };

                    await userManager.CreateAsync(user, Admin.InitialPassword);

                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void SeedPlaces(GelatoGuideDbContext data)
        {
            if (data.Places.Any())
            {
                return;
            }

            data.Places.AddRange(testSeedData.Places());

            data.SaveChanges();
        }

        private static void SeedArticles(GelatoGuideDbContext data)
        {
            if (data.Articles.Any())
            {
                return;
            }

            data.Articles.AddRange(testSeedData.Articles());

            data.SaveChanges();
        }
    }
}
