using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_WebAPiServer.Models
{
    public enum LibraryItemType { DVD, CD, Book };

    public class LibraryItemDTO
    {
        public int Id { get; set; }

        public virtual AuthorDTO Author { get; set; }

        public LibraryItemType ItemType { get; set; }

        public string Cover { get; set; }

        public DateTime IssueYear { get; set; }

        public string Title { get; set; }

        
    }
}
