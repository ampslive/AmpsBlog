using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmpsBlog.API.Interfaces;
using AmpsBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Repositories
{
    public class PostRepository : Repository<Post>
    {
        public DbContext DbContext { get { return _dbContext as DbContext; } }

        public PostRepository(DbContext dbContext) : base(dbContext)
        {
            
        }

        
    }
}