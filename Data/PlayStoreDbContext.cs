using Microsoft.EntityFrameworkCore;
using PlayStore.Models;
using System.Reflection.Metadata;

namespace PlayStore.Data
{
    public class PlayStoreDbContext : DbContext
    {
        public PlayStoreDbContext(DbContextOptions<PlayStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Reviews)
                .WithOne(e => e.Item)
                .HasForeignKey(e => e.ItemId)
                .HasPrincipalKey(e => e.Id);


            modelBuilder.Entity<Review>()
                .HasMany(e => e.Replies)
                .WithOne(e => e.Review)
                .HasForeignKey(e => e.ReviewId)
                .HasPrincipalKey(e => e.Id);
        }




        public DbSet<Item> Item { get; set; }
        public DbSet<App> App { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Reply> Reply { get; set; }
        public DbSet<Movie> Movie { get; set; }

        public DbSet<User> User { get; set; }
    }
}
