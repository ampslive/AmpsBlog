using System;
using System.Collections.Generic;

namespace AmpsBlog.Models
{
    public class Blog
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<Post> Posts { get; set; }
        public string AuthorId { get; set; }
        public DateTime DateCreated { get; set; }   
        public bool IsActive { get; set; }
    }
}
