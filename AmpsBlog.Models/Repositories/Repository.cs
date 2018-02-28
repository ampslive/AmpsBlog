using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.Models.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public async void Add(TEntity obj)
        {
           await _dbSet.AddAsync(obj);
        }

        public void Remove(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public async Task<TEntity> Get(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
    }
}