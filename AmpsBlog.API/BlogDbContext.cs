using AmpsBlog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AmpsBlog.API
{
    public class BlogDbContext : DbContext
    {

        private readonly IOptions<ConnectionSettings> config;
        
        public BlogDbContext(IOptions<ConnectionSettings> Config)
        {
            this.config = Config;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = config.Value.DefaultConnection;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                    .HasOne(p => p.Blog)
                    .WithMany(b => b.Posts)
                    .HasForeignKey(p => p.BlogId);
        }
    }
}