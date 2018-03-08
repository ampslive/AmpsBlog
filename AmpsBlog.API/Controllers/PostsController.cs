using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AmpsBlog.API;
using AmpsBlog.API.Models;
using AmpsBlog.API.Repositories;

namespace AmpsBlog.API.Controllers
{
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly BlogDbContext _context;

        private UnitOfWork _unitOfWork;
        public PostsController(BlogDbContext context)
        {
            _context = context;
            _unitOfWork = new UnitOfWork(_context);
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts =  await _unitOfWork.Posts.GetAll();

            if(posts.Count == 0)
            {
                return new NoContentResult();
            }

            return new OkObjectResult(posts);
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _unitOfWork.Posts.Get(id);
            if (post == null)
            {
                return NotFound();
            }

            return new OkObjectResult(post);
        }


        // POST: api/Posts
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            //Id,Title,Content,Status,DateCreated,DateModified,IsActive
            if (ModelState.IsValid)
            {
                post.DateCreated = DateTime.UtcNow;
                post.DateModified = DateTime.UtcNow;
                post.IsActive = true;

                _unitOfWork.Posts.Add(post);
                await _unitOfWork.SaveAsync();
                //return RedirectToAction(nameof(Index));
                return new AcceptedResult();
            }
            return NotFound();
        }

        // GET: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int? id, [FromBody] Post post)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingPost = await _unitOfWork.Posts.Get(id);
            if (existingPost == null)
            {
                return NotFound();
            }

            existingPost.Title = (post.Title != null) ? post.Title : existingPost.Title;
            existingPost.Content = (post.Content != null) ? post.Content : existingPost.Content;
            existingPost.Status = (post.Status != null) ? post.Status : existingPost.Status;
            existingPost.DateModified = DateTime.UtcNow;

            await _unitOfWork.SaveAsync();

            return new OkObjectResult(existingPost);
        }

        // GET: Posts/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var existingPost = await _unitOfWork.Posts.Get(id);
            if (existingPost == null)
            {
                return NotFound();
            }

           //existingPost.IsActive = false;
            _unitOfWork.Posts.Remove(existingPost);
            await _unitOfWork.SaveAsync();
            return new AcceptedResult();
        }
    }
}
