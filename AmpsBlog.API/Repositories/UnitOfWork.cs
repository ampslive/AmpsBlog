using System;
using System.Threading.Tasks;
using AmpsBlog.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Repositories
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly DbContext _dbContext;
        public IBlogRepository Blogs { get ; set; }

        public UnitOfWork()
        {
            //_dbContext = new BlogDbContext(string connectionString);
        }
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
            Blogs = new BlogRepository(_dbContext);
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