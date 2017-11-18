using Microsoft.EntityFrameworkCore;
using AmpsBlog.Models;

namespace AmpsBlog.API
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(string connectionString)
        {
            
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}