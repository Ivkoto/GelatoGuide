using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GelatoGuide.Data
{
    public class GelatoGuideDbContext : IdentityDbContext
    {
        public GelatoGuideDbContext(DbContextOptions<GelatoGuideDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
