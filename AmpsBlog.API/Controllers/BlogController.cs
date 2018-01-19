using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmpsBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Controllers
{
    [Route("api/[controller]")]
    public class BlogController : Controller
    {
        public readonly BlogDbContext _context;

        public BlogController(BlogDbContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/Blog/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Blog
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Blog blog)
        {
            if(ModelState.IsValid)
            {
                blog.DateCreated = DateTime.UtcNow;
                blog.DateModified = DateTime.UtcNow;
                blog.IsActive = true;
                
                _context.Add(blog);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return new AcceptedResult();
            }
            return NotFound();
        }

        // PUT api/Blog/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody] Blog blog)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingBlog = await _context.Blogs.SingleOrDefaultAsync(b => b.Id == id);
            if(existingBlog == null)
            {
                return NotFound();
            }

            //existingBlog.Name = (blog.Name != null) ? blog.Name : existingBlog.Name;
            //existingBlog.Description = (blog.Description != null) ? blog.Description : existingBlog.Description;
            existingBlog.DateModified = DateTime.UtcNow;
            
            _context.Update(existingBlog);
            await _context.SaveChangesAsync();

            return new OkObjectResult(blog);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.SingleOrDefaultAsync(b => b.Id == id);

            if(blog == null)
            {
                return NotFound();
            }

            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return new AcceptedResult();
        }
    }
}
