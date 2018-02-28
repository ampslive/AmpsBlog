using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmpsBlog.Models
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        Task<TEntity> Get(int? id);
        Task<List<TEntity>> GetAll();
        void Remove(TEntity obj);
    }

    public interface IBlogRepository : IRepository<Blog> 
    {
        IEnumerable<Blog> GetBlogsWithAuthors(int pageSize, int pageIndex);
        Blog GetBlogWithAuthor(int id); 
    }

    public interface IUnitofWork : IDisposable
    {
        IBlogRepository Blogs { get; set; }

        Task<int> SaveAsync();
    }

}