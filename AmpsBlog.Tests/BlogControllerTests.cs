using System;
using Xunit;
using AmpsBlog.API.Controllers;
using AmpsBlog.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AmpsBlog.API.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using AmpsBlog.API.Models;
using System.Linq;

namespace AmpsBlog.Tests
{
    public class BlogControllerTests
    {
        [Fact]
        public async void PassingTest()
        {
            //var controller = new BlogController(new BlogDbContext());
            //var actionResult = await controller.Get(2);
            
            //var result = (actionResult as IActionResult);
            
            

            //var r1 = result;
            //Assert.NotNull(actionResult);
            //var r2 = r1.Value as Blog;

            // var res = Assert.IsAssignableFrom<Task<IActionResult>>(response);
            // //var assignable = Assert.IsAssignableFrom<IEnumerable<Blog>>(res.ToString());
            // var test = res as Blog;
            //Assert.Equal("Hello Blog", r2.Name);
            var mockBlogRepo = new Mock<BlogRepository>();
            var blogs = new List<Blog>(){
                new Blog {
                    Id = 1,
                    Name = "Blog 1"
                },
                new Blog {
                    Id = 2,
                    Name = "Blog 2"
                }
            };

            
            mockBlogRepo.Setup(m=>m.GetAll()).Returns(Task.FromResult(blogs));
            //var blogController = new BlogsController();

            //Act
            //var result = await blogController.Get();

            //Assert
            //var r = Assert.IsAssignableFrom<List<Blog>>(result);
            
            //var blogResult = Assert.IsAssignableFrom<List<Blog>>(r.Value);
            //Assert.Equal(blogResult.Count, 2);
        }

        
    }
}
