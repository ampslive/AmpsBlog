using System;
using Xunit;
using AmpsBlog.API.Controllers;
using AmpsBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmpsBlog.Tests
{
    public class BlogControllerTests
    {
        //public BlogDbContext dbContext;

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
           
        }

        
    }
}
