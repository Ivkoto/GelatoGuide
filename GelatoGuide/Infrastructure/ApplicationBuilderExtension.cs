﻿using GelatoGuide.Data;
using GelatoGuide.Data.Enumerations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

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

            SeedRoles(data);

            return app;
        }

        private static void SeedRoles(GelatoGuideDbContext data)
        {
            if (data.Roles.Any())
            {
                return;
            }

            data.Roles.AddRange(new[]
            {
                //seed Admin role
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = RolesEnum.Admin.ToString()
                },
                //seed Regular user role
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = RolesEnum.Regular.ToString()
                },
                //seed premium user Role
                new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = RolesEnum.Premium.ToString()
                }
            });

            data.SaveChanges();
        }
    }
}
