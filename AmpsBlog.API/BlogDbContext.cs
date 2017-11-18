using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(string connectionString)
        {
            
        }
    }
}