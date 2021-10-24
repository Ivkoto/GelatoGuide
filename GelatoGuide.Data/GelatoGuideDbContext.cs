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
        
        public DbSet<Article> Articles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Place> Places { get; init; }

        public DbSet<ShippingAddress> ShippingAddresses { get; set; }

        public DbSet<ShopItem> ShopItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
