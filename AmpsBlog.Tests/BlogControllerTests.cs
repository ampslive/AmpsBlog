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
using AmpsBlog.API;

namespace AmpsBlog.Tests
{
    public class BlogControllerTests
    {
        [Fact]
        public async void PassingTest()
        {
            var mockBlogRepo = new Mock<IUnitofWork>();
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

            
            mockBlogRepo.Setup(m=>m.Blogs.GetAll()).Returns(Task.FromResult(blogs));
            var blogController = new BlogsController(mockBlogRepo.Object);
            var response = blogController.Get();
            
            //Act

            Task<IActionResult> bbb = blogController.Get();
            
            var bb = bbb.Result as OkObjectResult;
            
            var b = bb.Value as List<Blog>;

            //Assert
            await Assert.IsAssignableFrom<Task<IActionResult>>(response);
            Assert.Equal(b.First().Name, "Blog 1");
        }

        
    }
}
