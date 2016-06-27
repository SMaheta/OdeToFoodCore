
using Microsoft.EntityFrameworkCore;

namespace OdeToFoodCore.Entities
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options) : base(options) {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
