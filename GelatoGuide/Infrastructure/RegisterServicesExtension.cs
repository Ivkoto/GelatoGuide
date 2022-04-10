using GelatoGuide.Services.Blog;
using GelatoGuide.Services.Places;
using GelatoGuide.Services.Roles;
using GelatoGuide.Services.Shop;
using GelatoGuide.Services.Users;
using Microsoft.Extensions.DependencyInjection;

namespace GelatoGuide.Infrastructure;

public static class RegisterServicesExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<IUserService, UserService>()
            .AddTransient<IPlaceService, PlaceService>()
            .AddTransient<IBlogService, BlogService>()
            .AddTransient<IShopService, ShopService>()
            .AddTransient<IRoleService, RoleService>();

        return services;
    }
}