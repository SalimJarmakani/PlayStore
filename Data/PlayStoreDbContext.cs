using Microsoft.EntityFrameworkCore;
using PlayStore.Models;

namespace PlayStore.Data
{
    public class PlayStoreDbContext : DbContext
    {
        public PlayStoreDbContext(DbContextOptions<PlayStoreDbContext> options) : base(options) { }



        public DbSet<App> App { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Reply> Reply { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public DbSet<User> User { get; set; }
    }
}
