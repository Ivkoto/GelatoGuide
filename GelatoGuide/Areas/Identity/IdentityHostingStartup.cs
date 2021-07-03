using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(GelatoGuide.Areas.Identity.IdentityHostingStartup))]
namespace GelatoGuide.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}