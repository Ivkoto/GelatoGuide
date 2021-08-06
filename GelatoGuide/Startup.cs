using GelatoGuide.Data;
using GelatoGuide.Data.Models;
using GelatoGuide.Infrastructure;
using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Roles;
using GelatoGuide.Services.Users;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GelatoGuide
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
            => this.Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<GelatoGuideDbContext>(options
                    => options
                        .UseSqlServer(this.Configuration
                        .GetConnectionString("DefaultConnection")));

            services
                .AddDatabaseDeveloperPageExceptionFilter();


            services
                .AddDefaultIdentity<User>(options
                    =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<GelatoGuideDbContext>();

            services
                .AddControllersWithViews();

            services
                .AddTransient<IUserService, UserService>()
                .AddTransient<IPlaceService, PlaceService>()
                .AddTransient<IBlogService, BlogService>();

            services
                .AddTransient<IRoleService, RoleService>();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.PrepareDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app
                .UseHttpsRedirection()
                .UseStaticFiles()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(name: "areaRout",
                        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
                    //endpoints.MapControllerRoute(name: "rolesRout",
                    //    pattern: "{area:exists}/{controller=Roles}/{action=Index}/{id?}");
                    endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

                    //remove if app didn't work for some point
                    endpoints.MapDefaultControllerRoute();
                    endpoints.MapRazorPages();
                });
        }
    }
}
