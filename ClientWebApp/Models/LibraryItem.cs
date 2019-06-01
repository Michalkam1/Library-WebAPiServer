using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClientWebApp.Models
{
    public enum LibraryItemType { DVD, CD, Book };

    public class LibraryItem
    {
        public int Id { get; set; }

        public virtual Author Author { get; set; }

        public LibraryItemType ItemType { get; set; }

        public string Cover { get; set; }

        public DateTime IssueYear { get; set; }

        [Required]
        public string Title { get; set; }

        
    }
}
