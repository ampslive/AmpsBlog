using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.Models
{
    public class BlogDbContextDelete : DbContext
    {
        private object connectionString;

        public BlogDbContextDelete()
        {

        }
        public BlogDbContextDelete(DbContextOptions<BlogDbContextDelete> options) : base(options)
        {
            
        }

        public BlogDbContextDelete(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }
    }
}