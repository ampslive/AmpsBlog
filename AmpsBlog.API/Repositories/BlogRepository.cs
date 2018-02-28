using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmpsBlog.API.Interfaces;
using AmpsBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Repositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        public DbContext BlogDbContext { get { return _dbContext as DbContext; } }

        public BlogRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        public IEnumerable<Blog> GetBlogsWithAuthors(int pageSize, int pageIndex)
        {
            throw new NotImplementedException();
            //return BlogDbContext.Blogs..Skip((pageIndex-1) * pageIndex).Take(pageSize).ToList();
            //return _dbContext.Blogs.Skip((pageIndex-1) * pageIndex).
        }

        public Blog GetBlogWithAuthor(int id)
        {
            throw new NotImplementedException();
        }
    }
}