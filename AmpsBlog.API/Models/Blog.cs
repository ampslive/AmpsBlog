using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Models
{
    public class Blog
    {
        private readonly BlogDbContext _context;
        public Blog()
        {

        }
        // public Blog(BlogDbContext context)
        // {
        //     _context = context;
        // }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Post> Posts { get; set; }
        public string AuthorId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Blog>> GetAll()
        {
             return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.FindAsync(id);
        }

        public void Update(Blog obj)
        {
            throw new NotImplementedException();
        }
    }
}
