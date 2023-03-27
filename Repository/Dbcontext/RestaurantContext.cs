using Microsoft.EntityFrameworkCore;
using Models;


namespace Dbcontext
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
              : base(options)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Cuisines)
                .WithOne(c => c.Restaurant)
                .HasForeignKey(c => c.RestaurantId);
        }
    }
}
