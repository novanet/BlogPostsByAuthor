using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BloggPostsByAuthor.AuthorData
{
    public class Post
    {
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public bool Featured { get; set; }
        public string Status { get; set; }
        public DateTime Created_At { get; set; }
        public int Created_By { get; set; }
        public DateTime Updated_At { get; set; }
        public int Updated_By { get; set; }
        public DateTime Published_At { get; set; }
        public int Published_By { get; set; }
        public string Author { get; set; }
    }
}