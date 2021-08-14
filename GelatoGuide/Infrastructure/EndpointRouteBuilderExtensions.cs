using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GelatoGuide.Infrastructure
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void MapDefaultAreaRoute(this IEndpointRouteBuilder endpoints)
        {
            endpoints.MapControllerRoute(name: "area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
        }
    }
}
