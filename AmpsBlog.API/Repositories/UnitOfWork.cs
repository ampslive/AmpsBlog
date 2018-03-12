using System;
using System.Threading.Tasks;
using AmpsBlog.API.Interfaces;
using AmpsBlog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly BlogDbContext _dbContext;
        public IBlogRepository Blogs { get ; set; }
        public IRepository<Post> Posts { get ; set; }

        public UnitOfWork()
        {
            //Blogs = new BlogRepository(_dbContext);
        }
        public UnitOfWork(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
            Blogs = new BlogRepository(_dbContext);
            Posts = new Repository<Post>(_dbContext);
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}