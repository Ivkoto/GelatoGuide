using GelatoGuide.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GelatoGuide.Data
{
    public class GelatoGuideDbContext : IdentityDbContext<User>
    {
        public GelatoGuideDbContext(DbContextOptions<GelatoGuideDbContext> options)
            : base(options)
        {
        }

        public DbSet<Place> Places { get; init; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<ShopItems> ShopItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
