

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using AmpsBlog.API.Constants;

namespace AmpsBlog.API.Models
{
    public class Post
    {
        public int Id { get; set; } 
        public string Title { get; set; }   
        public string Content { get; set; } 
        public PostStatus Status { get; set; }
        
        //TODO: Implement Comment
        //public List<Comment> Comments { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public bool IsActive { get; set; }

        public int BlogId { get; set; }
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }
    }
}