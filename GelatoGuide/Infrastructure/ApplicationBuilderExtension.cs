using System.Linq;
using GelatoGuide.Data;
using GelatoGuide.Data.Enumerations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GelatoGuide.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<GelatoGuideDbContext>();

            data.Database.Migrate();

            return app;
        }

        private static void SeedRoles(GelatoGuideDbContext data)
        {
            if (data.Roles.Any())
            {
                return;
            }

            data.Roles.AddRange(new []
            {
                new IdentityRole(RolesEnum.Admin.ToString()),
                new IdentityRole(RolesEnum.Regular.ToString()),
                new IdentityRole(RolesEnum.Premium.ToString())
            });

            data.SaveChanges();
        }
    }
}
