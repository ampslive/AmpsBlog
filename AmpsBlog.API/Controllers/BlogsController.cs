using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AmpsBlog.API.Models;
using AmpsBlog.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AmpsBlog.API.Controllers
{
    [Route("api/[controller]")]
    public class BlogsController : Controller
    {
        public readonly BlogDbContext _context;
        private UnitOfWork _unitOfWork;
        
        // public BlogController()
        // {
        //     _context = new BlogDbContext();
        //     _unitOfWork = new UnitOfWork(_context);
        // }

        public BlogsController(BlogDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var blogs = await _unitOfWork.Blogs.GetAll();

            if(blogs.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(blogs);
        }

        // GET api/Blog/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var blog = await _unitOfWork.Blogs.Get(id);

            return new OkObjectResult(blog);
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
                
                _unitOfWork.Blogs.Add(blog);
                await _unitOfWork.SaveAsync();
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

            var existingBlog = await _unitOfWork.Blogs.Get(id);
            if(existingBlog == null)
            {
                return NotFound();
            }

            existingBlog.Name = (blog.Name != null) ? blog.Name : existingBlog.Name;
            existingBlog.Description = (blog.Description != null) ? blog.Description : existingBlog.Description;
            existingBlog.DateModified = DateTime.UtcNow;
            
            //_context.Update(existingBlog);
            await _unitOfWork.SaveAsync();

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
